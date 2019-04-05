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

namespace IMS.Forms.Inventory.Create
{
    public partial class ProductCreate : Form
    {
        public readonly static string COL_NAME_PREFIX = "col";
        // references
        private readonly IInventoryService _inventoryService;
        private readonly IDatabaseChangeListener _listener;
        // variables
        private int _productId;
        // track the start index of dynamic attributes
        private List<ProductAttributeModel> _productAttributes = new List<ProductAttributeModel>();

        public ProductCreate(IInventoryService inventoryService, IDatabaseChangeListener listener)
        {
            this._inventoryService = inventoryService;
            _listener = listener;

            InitializeComponent();

            PopulateCategoryCombo();

            InitializeEvents();
            // active control
            this.ActiveControl = tbProductName;

            InitializeDatabaseChangeListeners();

        }


        #region Initialization Functions

        private void InitializeEvents()
        {
            //btnSave.Click += btnSave_Click;
            //btnAddBrand.Click += btnAddBrand_Click;
            //btnAddCategory.Click += BtnAddCategory_Click;

            tbProductName.Validating += TbProductName_Validating;
            cbCategory.Validating += CbCategory_Validating;

            //btnAddOption.Click += BtnAddOption_Click;
            dgvVariants.EditingControlShowing += DgvVariants_EditingControlShowing;
            
        }

        private void InitializeDatabaseChangeListeners()
        {
            _listener.CategoryUpdated += _listener_CategoryUpdated;
        }

        #endregion


        #region Save Codes

        private void SaveProduct()
        {
            if (IsModelValid())
            {
                // since category combo displays text only and doesn't hold id, hence get the category from db
                var category = _inventoryService.GetCategory(cbCategory.SelectedItem.ToString());
                var variants = GetVariants();
                var product = new ProductModelForSave()
                {
                    Id = _productId,
                    Brands = GetBrands(),
                    CategoryId = category.Id,
                    MinStockCountForAlert = int.Parse(tbStockThreshold.Text),
                    ShowStockAlerts = cbShowStockAlert.Checked,
                    Name = tbProductName.Text,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Variants = variants,
                };
                product.ProductAttributes = _productAttributes;
                _inventoryService.AddUpdateProduct(product);
                PopupMessage.ShowSaveSuccessMessage();
                this.Close();
            }
        }

        private List<ProductVariantModel> GetVariants()
        {
            var variants = new List<ProductVariantModel>();
            for (int r = 0; r < dgvVariants.RowCount - 1; r++)
            {
                DataGridViewRow row = dgvVariants.Rows[r];
                var variant = new ProductVariantModel();
                variant.Id = int.Parse(row.Cells[colVariantId.Name].Value == null ? "0" : row.Cells[colVariantId.Name].Value.ToString());
                variant.SKU = row.Cells[colSKU.Name].Value.ToString();
                variant.Alert = bool.Parse(row.Cells[colAlert.Name].Value == null ? "False" : row.Cells[colAlert.Name].Value.ToString());
                variant.AlertThreshold = int.Parse(row.Cells[colAlertThreshold.Name].Value == null ? "0" : row.Cells[colAlertThreshold.Name].Value.ToString());
                foreach (var attribute in _productAttributes)
                {
                    // add to the dictionary
                    variant.Attributes.Add(new NameValuePair(attribute.Attribute, row.Cells[COL_NAME_PREFIX + attribute.Attribute].Value.ToString()));
                }
                variants.Add(variant);
            }

            return variants;
        }

        private List<BrandModel> GetBrands()
        {
            var list = new List<BrandModel>();
            // // when each branch is added via new Control TextBox
            //foreach (var brandControl in pnlBrandsBody.Controls)
            //{
            //    var inputUc = (TextBoxWithDeleteUC)brandControl;
            //    if (inputUc != null)
            //    {
            //        if (string.IsNullOrEmpty(inputUc.InputText))
            //        {
            //            return null;
            //        }
            //        var brandModel = new BrandModel()
            //        {
            //            Id = inputUc.Id,
            //            CreatedAt = inputUc.Id == 0 ? DateTime.Now : inputUc.CreatedAt,
            //            UpdatedAt = DateTime.Now,
            //            Name = inputUc.InputText,
            //            ProductId = Id,
            //        };
            //        list.Add(brandModel);
            //    }
            //}

            // new approach via textbox, comma separated
            var brandText = tbBrands.Text;
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

        private bool IsModelValid()
        {
            var valName = ValidateProductName();
            var valCategory = ValidateCategory();
            if (!(valName && valCategory))
            {
                PopupMessage.ShowMissingInputsMessage();
                this.Focus(); // return the focus to the current form
                return false;
            }
            return true;
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
            var product = _inventoryService.GetProductForEdit(productId);
            if (product != null)
            {
                this.Text = "Edit Product (" + product.Name + ")";
                tbProductName.Text = product.Name;
                tbStockThreshold.Value = product.MinStockCountForAlert;
                cbCategory.Text = product.Category.Name;
                cbShowStockAlert.Checked = product.ShowStockAlerts;

                // variants
                foreach (var prodAttr in product.ProductAttributes)
                {
                    AddAttributeColumn(prodAttr.Id, prodAttr.Attribute);
                }

                foreach (var brand in product.Brands)
                {
                    tbBrands.Text += brand.Name + ", ";
                }

                PopulateVariants(product.Variants);
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

        private void PopulateVariants(List<ProductVariantModel> variants)
        {
            foreach (var vari in variants)
            {
                var row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell()
                {
                    Value = vari.Id,
                });
                row.Cells.Add(new DataGridViewTextBoxCell()
                {
                    Value = vari.SKU,
                });
                row.Cells.Add(new DataGridViewCheckBoxCell()
                {
                    Value = vari.Alert,
                });
                row.Cells.Add(new DataGridViewTextBoxCell()
                {
                    Value = vari.AlertThreshold,
                });

                foreach (var att in _productAttributes)
                {
                    var value = vari.Attributes.Find(x => x.Name == att.Attribute);
                    row.Cells.Add(new DataGridViewTextBoxCell()
                    {
                        Value = value.Value
                    });
                }
                dgvVariants.Rows.Add(row);
            }
        }

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

        #endregion


        #region Validation

        private void CbCategory_Validating(object sender, CancelEventArgs e)
        {
            ValidateCategory();
        }

        private void TbProductName_Validating(object sender, CancelEventArgs e)
        {
            ValidateProductName();
        }

        private bool ValidateProductName()
        {
            if (tbProductName.Text.Trim() == "")
            {
                errorProvider1.SetError(tbProductName, "Required");
                return false;
            }
            errorProvider1.SetError(tbProductName, "");
            return true;
        }

        private bool ValidateCategory()
        {
            if (cbCategory.SelectedItem == null || (string)cbCategory.SelectedItem == "")
            {
                errorProvider1.SetError(cbCategory, "Required");
                return false;
            }
            errorProvider1.SetError(cbCategory, "");
            return true;
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