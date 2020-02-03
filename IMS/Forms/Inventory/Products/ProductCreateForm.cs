using IMS.Forms.Common;
using IMS.Forms.Common.Dialogs;
using Service.Listeners;
using Service.Core.Inventory;
using Service.Listeners.Inventory;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ViewModel.Core.Inventory;
using ViewModel.Core.Common;
using System.Linq;
using Service.Core.Business;
using Service.Core.Suppliers;
using IMS.Forms.Common.Validations;
using IMS.Forms.Inventory.Create;
using IMS.Forms.Inventory.Categories;

namespace IMS.Forms.Inventory.Products
{
    // design link : https://support.vendhq.com/hc/en-us/articles/201379180-What-are-Product-Variants-and-How-Do-I-Set-Them-Up-

    public partial class ProductCreateForm : Form
    {
        public static readonly string REQUIRED = "Required";

        public readonly static string COL_NAME_PREFIX = "col";

        // references
        private readonly IInventoryService _inventoryService;
        private readonly IDatabaseChangeListener _listener;
        private readonly IBusinessService _businessService;
        private readonly ISupplierService _supplierService;

        private RequiredFieldValidator _requiredValidator;
        private GreaterThanZeroFieldValidator _greaterThanZeroFieldValidator;
        // variables
        private int _productId;
        private ProductModel _product;
        // track the start index of dynamic attributes
        private List<ProductAttributeModel> _productAttributes = new List<ProductAttributeModel>();

        public ProductCreateForm(IInventoryService inventoryService, IDatabaseChangeListener listener, IBusinessService businessService, ISupplierService supplierService)
        {
            _inventoryService = inventoryService;
            _businessService = businessService;
            _supplierService = supplierService;
            _listener = listener;

            InitializeComponent();
            InitializeEvents();
            InitializeDatabaseChangeListeners();


            this.Load += ProductCreate_Load;
        }

        private void ProductCreate_Load(object sender, EventArgs e)
        {
            // active control
            this.ActiveControl = tbProductName;
            // call all the populating functions
            PopulateCategoryCombo();
            PopulateWarehouse();
            PopulateSupplier();
            PopulateUom();
            PopulatePackage();

            PopulateDataForEdit(_product);

        }


        #region Initialization Functions

        private void InitializeEvents()
        {
            //cbCategory.Validating += RequiredField_Validating;
            //tbLabelCode.Validating += RequiredField_Validating;
            //tbProductName.Validating += RequiredField_Validating;
            //tbSKU.Validating += RequiredField_Validating;
            //cbPackage.Validating += RequiredField_Validating;
            //cbSupplier.Validating += RequiredField_Validating;
            //cbUom.Validating += RequiredField_Validating;
            //cbWarehouse.Validating += RequiredField_Validating;

            var requiredControls = new Control[]
            {
                cbCategory, tbLabelCode, tbProductName, tbSKU, cbPackage, cbSupplier, cbUom, cbWarehouse
            };
            _requiredValidator = new RequiredFieldValidator(errorProvider1, requiredControls);
            var greaterControls = new Control[]
            {
                numSupplyPrice
            };
            _greaterThanZeroFieldValidator = new GreaterThanZeroFieldValidator(errorProvider1, greaterControls);

            //btnAddOption.Click += BtnAddOption_Click;
            dgvVariants.EditingControlShowing += DgvVariants_EditingControlShowing;

            btnAddCategory.Click += BtnAddCategory_Click;
        }
        
        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var categoryCreate = Program.container.GetInstance<CategoryCreate>();
                categoryCreate.ShowInTaskbar = false;
                categoryCreate.ShowDialog();
                //PopulateCategoryData();
            }
        }

        private void InitializeDatabaseChangeListeners()
        {
            _listener.CategoryUpdated += _listener_CategoryUpdated;
        }

        #endregion


        #region Save Codes

        private void SaveProduct()
        {
            var allValid = _requiredValidator.IsValid();
            allValid = allValid && _greaterThanZeroFieldValidator.IsValid();
            if (!allValid)
            {
                PopupMessage.ShowMissingInputsMessage();
                this.Focus(); // return the focus to the current form
                return;
            }

            // since category combo displays text only and doesn't hold id, hence get the category from db
            var category = _inventoryService.GetCategory(cbCategory.SelectedItem.ToString());
            //var variants = GetVariants();
            var product = new ProductModel()
            {
                Id = _productId,
               // Brands = GetBrands(),
                CategoryId = category.Id,
                ReorderPoint = numReorderPoint.Value,
                ReorderAlert = true,

                Name = tbProductName.Text,

                // Variants = variants,
                AttributesJSON = "",
                Barcode = tbBarcode.Text,
                BaseUomId = int.Parse(cbUom.SelectedValue.ToString()),
                Brand = tbBrand.Text,
                Description = tbDescription.Text,
                EOQ = numEOQ.Value,
                HasVariants = rbProductWithVariants.Checked,
                IsBuild = chkIsBuild.Checked,
                IsBuy = chkIsBuy.Checked,
                IsNotMovable = chkIsNotMovable.Checked,
                IsSell = chkIsSell.Checked,
                Label = tbLabelCode.Text,
                LeadDays = (int)numLeadDays.Value,
                Manufacturer = tbManufacturer.Text,
                PackageId = int.Parse(cbPackage.SelectedValue.ToString()),

                ParentProductId = null,
                IsVariant = false,
                Use = chkUse.Checked,

                //MarkupPercent = 
                MonthlyDemand = numMonthlyDemand.Value,
                SKU = tbSKU.Text,
                UnitNetWeight = numUnitNetWeight.Value,
                ReorderQuantity = numReorderQuantity.Value,
                MarkupPercent = numMarkupPercent.Value,
                RetailPrice = numRetailPrice.Value,
                SupplyPrice = numSupplyPrice.Value,
                UnitGrossWeight = numUnitGrossWeight.Value,
                UnitsInPackage = numUnitsInPackage.Value,
                WarehouseId = int.Parse(cbWarehouse.SelectedValue.ToString()),
                
            };
            product.ProductAttributes = _productAttributes;
            _inventoryService.AddUpdateProduct(product);
            PopupMessage.ShowSaveSuccessMessage();
            this.Close();

        }

        #endregion


        #region Control Events

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveProduct();
        }

        private void lblCategory_DoubleClick(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var categoryCreate = Program.container.GetInstance<CategoryCreate>();
                categoryCreate.ShowDialog();
            }
        }

        private void btnAddAttribute_Click(object sender, EventArgs e)
        {
            var dialog = new MessageBoxWithInput();
            dialog.lblMessage.Text = "Enter attribute that describes this product,\n e.g. \"Color\", \"Fabric\", \"Style\", etc.";
            dialog.lblLabel.Text = "Attribute";
            dialog.Text = "Attribute";
            dialog.DoneClicked += Dialog_DoneClicked;
            dialog.ShowDialog();
        }

        private void DgvVariants_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dgvVariants.CurrentCell.ColumnIndex == 3) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }

        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allowed only numeric value  ex.10
            //if (!char.IsControl(e.KeyChar)
            //    && !char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //}

            // allowed numeric and one dot  ex. 10.23
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                 && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        #endregion


        #region Extra Events

        private void _listener_CategoryUpdated(object sender, CategoryEventArgs e)
        {
            PopulateCategoryCombo();
            cbCategory.Text = e.Category.Name;
        }

        private void Dialog_DoneClicked(object sender, StringEventArgs e)
        {
            // check if the column already exists
            foreach (DataGridViewColumn col in dgvVariants.Columns)
            {
                if (col.HeaderText == e.Input)
                {
                    PopupMessage.ShowPopupMessage("Duplicate Attribute!", "The attribute already exists in the product!", PopupMessageType.INFO);
                    return;
                }
            }
            AddAttributeColumn(0, e.Input);
        }

        #endregion


        #region Populating Functions

        internal void SetDataForEdit(int productId)
        {
            _productId = productId;
            // get the product
            _product = _inventoryService.GetProductForEdit(productId);

            // SetDataForEdit(_product);
        }

        public void PopulateDataForEdit(ProductModel product)
        {
            if (_product != null)
            {
                this.Text = "Edit Product (" + product.Name + ")";

                tbBarcode.Text = product.Barcode;
                tbBrand.Text = product.Brand;
                tbDescription.Text = product.Description;
                tbLabelCode.Text = product.Label;
                tbManufacturer.Text = product.Manufacturer;
                tbProductName.Text = product.Name;
                tbSKU.Text = product.SKU;

                numEOQ.Value = product.EOQ;
                numLeadDays.Value = product.LeadDays;
                numMarkupPercent.Value = product.MarkupPercent;
                numMonthlyDemand.Value = product.MonthlyDemand;
                numReorderPoint.Value = product.ReorderPoint;
                numReorderQuantity.Value = product.ReorderQuantity;
                numRetailPrice.Value = product.RetailPrice;
                numSupplyPrice.Value = product.SupplyPrice;
                numUnitGrossWeight.Value = product.UnitGrossWeight;
                numUnitNetWeight.Value = product.UnitNetWeight;
                numUnitsInPackage.Value = product.UnitsInPackage;

                cbCategory.Text = product.Category;
                cbPackage.Text = product.Package == null ? "" : product.Package;
                cbUom.Text = product.BaseUom == null ? "" : product.BaseUom;
                cbWarehouse.Text = product.Warehouse == null ? "" : product.Warehouse;
                //cbSupplier.SelectedValue = product.

                chkIsBuild.Checked = product.IsBuild;
                chkIsBuy.Checked = product.IsBuy;
                chkIsNotMovable.Checked = product.IsNotMovable;
                chkIsSell.Checked = product.IsSell;
                chkUse.Checked = product.Use;
                // variants
                foreach (var prodAttr in product.ProductAttributes)
                {
                    AddAttributeColumn(prodAttr.Id, prodAttr.Attribute);
                }

                //foreach (var brand in product.Brands)
                //{
                //    tbBrands.Text += brand.Name + ", ";
                //}

                // PopulateVariants(product.Variants);
            }
        }

        private void PopulateCategoryCombo()
        {
            cbCategory.Items.Clear();
            cbCategory.FlatStyle = FlatStyle.Popup;
            cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            var categories = _inventoryService.GetCategoryList(null);
            //cbCategory.ValueMember = "Id";
            //cbCategory.DisplayMember = "Name";
            AddCategoryToCombo(null, null, null);
            cbCategory.Text = "Select";
            //cbCategory.SelectedIndex = 0;
        }

        private void AddCategoryToCombo(int? categoryId, CategoryModel category, string spaces)
        {
            if (category != null)
                cbCategory.Items.Add(spaces + category.Name);
            var subCategories = _inventoryService.GetCategoryList(categoryId);
            foreach (var sub in subCategories)
            {
                AddCategoryToCombo(sub.Id, sub, spaces == null ? "" : spaces + "   ");
            }
        }

        //private void PopulateVariants(List<ProductVariantModel> variants)
        //{
        //    foreach (var vari in variants)
        //    {
        //        var row = new DataGridViewRow();
        //        row.Cells.Add(new DataGridViewTextBoxCell()
        //        {
        //            Value = vari.Id,
        //        });
        //        row.Cells.Add(new DataGridViewTextBoxCell()
        //        {
        //            Value = vari.SKU,
        //        });
        //        row.Cells.Add(new DataGridViewCheckBoxCell()
        //        {
        //            Value = vari.Alert,
        //        });
        //        row.Cells.Add(new DataGridViewTextBoxCell()
        //        {
        //            Value = vari.AlertThreshold,
        //        });

        //        foreach (var att in _productAttributes)
        //        {
        //            var value = vari.Attributes.Find(x => x.Name == att.Attribute);
        //            row.Cells.Add(new DataGridViewTextBoxCell()
        //            {
        //                Value = value.Value
        //            });
        //        }
        //        dgvVariants.Rows.Add(row);
        //    }
        //}

        private void AddAttributeColumn(int attributeId, string attributeName)
        {
            // get the data ; add column in the grid view
            var column = new DataGridViewColumn();
            column.Name = COL_NAME_PREFIX + attributeName;
            column.HeaderText = attributeName;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.Width = 100;
            column.CellTemplate = new DataGridViewTextBoxCell();
            dgvVariants.Columns.Add(column);
            _productAttributes.Add(new ProductAttributeModel
            {
                Attribute = attributeName,
                Id = attributeId,
            });
        }

        private void PopulateWarehouse()
        {
            var warehouses = _inventoryService.GetWarehouseList();
            cbWarehouse.DataSource = warehouses;
            cbWarehouse.ValueMember = "Id";
            cbWarehouse.DisplayMember = "Name";
        }

        private void PopulatePackage()
        {
            var packages = _inventoryService.GetPackageList();
            cbPackage.DataSource = packages;
            cbPackage.ValueMember = "Id";
            cbPackage.DisplayMember = "Name";
        }

        private void PopulateUom()
        {
            var uoms = _inventoryService.GetUomList();
            cbUom.DataSource = uoms;
            cbUom.ValueMember = "Id";
            cbUom.DisplayMember = "Name";
        }

        private void PopulateSupplier()
        {
            var suppliers = _supplierService.GetSupplierListForCombo();
            cbSupplier.DataSource = suppliers;
            cbSupplier.ValueMember = "Id";
            cbSupplier.DisplayMember = "Name";
        }


        #endregion



    }
}

//private void btnAttributeAdd_Click(object sender, EventArgs e)
//{
//    //var attributeEachItem = new TextBoxWithDeleteUC();
//    //attributeEachItem.OnRemoveClicked += AttributeEachItem_OnRemoveClicked;
//    //attributeEachItem.Dock = DockStyle.Top;
//    //pnlAttributesBody.Controls.Add(attributeEachItem);
//    var optionChooseForm = new OptionChoose();
//    optionChooseForm.DataSource = _optionsList;
//    optionChooseForm.OptionSelected += OptionChooseForm_OptionSelected;
//    optionChooseForm.ShowDialog();
//}

//private void OptionChooseForm_OptionSelected(object sender, OptionChooseEventArgs e)
//{
//    var optionViewUC = new OptionViewUC(e.Option);
//    optionViewUC.OnRemoveClicked += OptionViewUC_RemoveClicked;
//    pnlAttributesBody.Controls.Add(optionViewUC);
//}

//private void OptionViewUC_RemoveClicked(object sender, EventArgs e)
//{
//    pnlAttributesBody.Controls.Remove((OptionViewUC)sender);
//}

//private List<ProductOptionModel> GetOptions()
//{
//    var list = new List<ProductOptionModel>();
//    foreach (var control in pnlAttributesBody.Controls)
//    {
//        var optionViewUc = (OptionViewUC)control;
//        if (optionViewUc != null)
//        {
//            foreach (var optionValue in optionViewUc.OptionModel.OptionValues)
//            {
//                var model = new ProductOptionModel()
//                {
//                    CreatedAt = DateTime.Now,
//                    UpdatedAt = DateTime.Now,
//                    //Id = optionValue.Id,
//                    OptionId = optionValue.Id,

//                };
//                list.Add(model);
//            }

//        }
//    }
//    return list;
//}



//private void BtnAddCategory_Click(object sender, EventArgs e)
//{

//    var categoryCreate = Program.container.GetInstance<CategoryCreate>();
//    categoryCreate.StartPosition = FormStartPosition.CenterParent;
//    categoryCreate.ShowDialog();
//}

//private void btnAddBrand_Click(object sender, EventArgs e)
//{
//    var brandCreate = Program.container.GetInstance<BrandCreate>();
//    brandCreate.StartPosition = FormStartPosition.CenterParent;
//    brandCreate.ShowDialog();
//}



//private List<ProductAttributeModel> GetProductAttributes()
//{
//    var list = new List<ProductAttributeModel>();
//    foreach(var att in _attributeList)
//    {
//        list.Add(new ProductAttributeModel()
//        {
//            Attribute = att.Attribute,
//        });
//    }
//    return list;
//}

/*
private void SaveProduct()
{
    ProductModelForSave product = null;
    try
    {
        var valName = ValidateProductName();
        var valCategory = ValidateCategory();
        if (!(valName && valCategory))
        {
            PopupMessage.ShowPopupMessage("Unfilled Inputs", "Please fill all the required fields", PopupMessageType.ERROR);
            this.Focus(); // return the focus to the current form
            return;
        }
        var brands = GetBrands();
        if (brands == null)
        {
            PopupMessage.ShowPopupMessage("Missing Brand Names", "Some of the brands are without name!", PopupMessageType.ERROR);
            this.Focus(); // return the focus to the current form
            return;
        }
        else if (!IsBrandNamesUnique(brands))
        {
            PopupMessage.ShowPopupMessage("Duplicate Brands", "There are duplicate Brand names in the list", PopupMessageType.INFO);
            this.Focus(); // return the focus to the current form
            return;
        }

        //var options = GetOptions();
        //if (options.Count == 0)
        //{
        //    PopupMessage.ShowPopupMessage("No Attribute", "You haven't added any attributes. Attributes describe the product.", PopupMessageType.NONE);
        //    this.Focus();
        //    return;
        //}
        var category = _inventoryService.GetCategory(cbCategory.SelectedItem.ToString());
        product = new ProductModelForSave()
        {
            Brands = brands, // GetBrands(), //((BrandModel)cbBrand.SelectedItem).Id,
            CategoryId = category.Id,
            CreatedAt = DateTime.Now,
            MinStockCountForAlert = int.Parse(tbStockThreshold.Text),
            ShowStockAlerts = cbShowStockAlert.Checked,
            Name = tbProductName.Text,
            UpdatedAt = DateTime.Now,
            // ProductOptions = options,
        };
    }
    catch (Exception ex) { throw; }
    if (product != null)
    {
        _inventoryService.AddProduct(product);
        PopupMessage.ShowPopupMessage("Save Success", "Product has been saved successfully", PopupMessageType.SUCCESS);
        this.Close();
    }
}
*/

//private void btnAddBrand_Click(object sender, EventArgs e)
//{
//    var brandEachItem = new TextBoxWithDeleteUC();
//    brandEachItem.DataSource = _brandsList.Select(x => x.Name).Distinct().ToList();
//    brandEachItem.OnRemoveClicked += BrandEachItem_OnRemoveClicked;
//    //brandEachItem.Dock = DockStyle.Top;
//    pnlBrandsBody.Controls.Add(brandEachItem);
//}

//private void BrandEachItem_OnRemoveClicked(object sender, EventArgs e)
//{
//    pnlBrandsBody.Controls.Remove((TextBoxWithDeleteUC)sender);
//}

// for variant

/*private bool IsBrandNamesUnique(List<BrandModel> brands)
  {

      for (int i = 0; i < brands.Count; i++)
      {
          var otherBrands = new List<BrandModel>();
          if (i > 0)
          {
              // get lower limits
              otherBrands.AddRange(brands.GetRange(0, i));
          }
          if (i < brands.Count - 1)
          {
              // get upper limits
              otherBrands.AddRange(brands.GetRange(i + 1, brands.Count - 1 - i));
          }
          if (otherBrands.Any(x => x.Name.Equals(brands[i].Name, StringComparison.CurrentCultureIgnoreCase)))
              return false;
      }
      return true;
  }*/

//private bool ValidateBrand()
//{
//    if (cbBrand.SelectedItem == null)
//    {
//        errorProvider1.SetError(cbBrand, "Required");
//        return false;
//    }
//    errorProvider1.SetError(cbBrand, "");
//    return true;
//}

#region Validation

//private void RequiredField_Validating(object sender, CancelEventArgs e)
//{
//    ValidateControl(sender);

//}

//private bool ValidateControl(object sender)
//{
//    var type = sender.GetType();
//    if (type == typeof(TextBox))
//    {
//        return ValidateTextBox((TextBox)sender);
//    }
//    else if (type == typeof(ComboBox))
//    {
//        return ValidateComboBox((ComboBox)sender);
//    }
//    else if (type == typeof(MaskedTextBox))
//    {
//        return ValidateMaskedTextBox((MaskedTextBox)sender);
//    }
//    return false;
//}


//private bool ValidateTextBox(TextBox textBox)
//{
//    if (string.IsNullOrEmpty(textBox.Text.Trim()))
//    {
//        errorProvider1.SetError(textBox, REQUIRED);
//        return false;
//    }
//    errorProvider1.SetError(textBox, string.Empty);
//    return true;
//}

//private bool ValidateMaskedTextBox(MaskedTextBox textBox)
//{
//    if (string.IsNullOrEmpty(textBox.Text.Trim()))
//    {
//        errorProvider1.SetError(textBox, REQUIRED);
//        return false;
//    }
//    errorProvider1.SetError(textBox, string.Empty);
//    return true;
//}

//private bool ValidateComboBox(ComboBox comboBox)
//{
//    //if(string.IsNullOrEmpty(comboBox.SelectedText))
//    if (comboBox.SelectedItem == null)
//    {
//        errorProvider1.SetError(comboBox, REQUIRED);
//        return false;
//    }
//    errorProvider1.SetError(comboBox, string.Empty);
//    return true;
//}

#endregion


/*
private List<BrandModel> GetBrands()
{
    var list = new List<BrandModel>();

    // new approach via textbox, comma separated
    var brandText = tbBrand.Text;
    var split = brandText.Split(new char[] { '\n', ';', ',' });
    foreach (var sp in split)
    {

        if (!string.IsNullOrEmpty(sp))
        {
            // ignore the repeated
            var name = sp.Trim();
            if (!list.Any(x => x.Name == name))
            {
                var brandModel = new BrandModel()
                {
                    //Id = inputUc.Id,
                    CreatedAt = DateTime.Now,//inputUc.Id == 0 ? DateTime.Now : inputUc.CreatedAt,
                    UpdatedAt = DateTime.Now,
                    Name = sp.Trim(), //inputUc.InputText,
                    ProductId = _productId,
                };
                list.Add(brandModel);
            }
        }
    }
    return list;
}
*/


//private List<ProductVariantModel> GetVariants()
//{
//    var variants = new List<ProductVariantModel>();
//    for (int r = 0; r < dgvVariants.RowCount - 1; r++)
//    {
//        DataGridViewRow row = dgvVariants.Rows[r];
//        var variant = new ProductVariantModel();
//        variant.Id = int.Parse(row.Cells[colVariantId.Name].Value == null ? "0" : row.Cells[colVariantId.Name].Value.ToString());
//        variant.SKU = row.Cells[colSKU.Name].Value.ToString();
//        variant.Alert = bool.Parse(row.Cells[colAlert.Name].Value == null ? "False" : row.Cells[colAlert.Name].Value.ToString());
//        variant.AlertThreshold = int.Parse(row.Cells[colAlertThreshold.Name].Value == null ? "0" : row.Cells[colAlertThreshold.Name].Value.ToString());
//        foreach (var attribute in _productAttributes)
//        {
//            // add to the dictionary
//            variant.Attributes.Add(new NameValuePair(attribute.Attribute, row.Cells[COL_NAME_PREFIX + attribute.Attribute].Value.ToString()));
//        }
//        variants.Add(variant);
//    }

//    return variants;
//}
//private bool IsModelValid()
//{
//    // return Validate();

//    //var nameValid = ValidateControl(tbProductName);
//    //var skuValid = ValidateControl(tbSKU);
//    //var categoryValid = ValidateControl(cbCategory);
//    //var labelValid = ValidateControl(tbLabelCode);
//    //var packageValid = ValidateControl(cbPackage);
//    //var supplierValid = ValidateControl(cbSupplier);
//    //var uomValid = ValidateControl(cbUom);
//    //var warehouseValid = ValidateControl(cbWarehouse);

//    //var allValid = nameValid &&
//    //    categoryValid &&
//    //    labelValid &&
//    //    packageValid &&
//    //    supplierValid &&
//    //    uomValid &&
//    //    warehouseValid;

//    var allValid = _requiredValidator.IsValid();
//    if (!allValid)
//    {
//        PopupMessage.ShowMissingInputsMessage();
//        this.Focus(); // return the focus to the current form
//    }
//    return allValid;
//}

