using IMS.Forms.Common;
using IMS.Forms.Common.Dialogs;
using Service.Listeners;
using Service.Core.Inventory;
using Service.Listeners.Inventory;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ViewModel.Core.Inventory;
using Service.Core.Business;
using IMS.Forms.Common.Validations;
using IMS.Forms.Inventory.Categories;
using Service.Core.Users;
using Service.Interfaces;
using IMS.Forms.Inventory.Packages;
using System.Linq;
using ViewModel.Core.Common;

namespace IMS.Forms.Inventory.Products
{
    // design link : https://support.vendhq.com/hc/en-us/articles/201379180-What-are-Product-Variants-and-How-Do-I-Set-Them-Up-

    public partial class ProductCreateBasicForm : Form
    {
        public static readonly string REQUIRED = "Required";

        public readonly static string COL_NAME_PREFIX = "col";

        // references
        private readonly IProductService _productService;
        private readonly IInventoryService _inventoryService;
        private readonly IDatabaseChangeListener _listener;
        private readonly IBusinessService _businessService;
        private readonly IUserService _supplierService;

        private RequiredFieldValidator _requiredValidator;
        private GreaterThanZeroFieldValidator _greaterThanZeroFieldValidator;
        // variables
        private int _productId;
        private ProductModel _product;
        // track the start index of dynamic attributes
        private List<ProductAttributeModel> _productAttributes = new List<ProductAttributeModel>();

        public ProductCreateBasicForm(IProductService productService, IInventoryService inventoryService, IDatabaseChangeListener listener, IBusinessService businessService, IUserService supplierService)
        {
            _productService = productService;
            _inventoryService = inventoryService;
            _businessService = businessService;
            _supplierService = supplierService;
            _listener = listener;

            InitializeComponent();


            this.Load += ProductCreate_Load;
        }

        private void ProductCreate_Load(object sender, EventArgs e)
        {
            //tbInStockQuantity.Minimum = decimal.MinValue;
            //tbInStockQuantity.Maximum = decimal.MaxValue;

            InitializeEvents();

            //numSupplyPrice.Maximum = Int32.MaxValue;
            //numRetailPrice.Maximum = Int32.MaxValue;
            // active control
            this.ActiveControl = tbProductName;
            // call all the populating functions
            PopulateCategoryCombo();
            //PopulateUom();

            PopulateDataForEdit(_product);
            // Note: PopulatePackage() to be called only after PopulateDataForEdit()
            PopulatePackage();
            if (_product != null && _product.BasePackageId != null)
                cbPackage.SelectedValue = _product.BasePackageId;

        }


        #region Initialization Functions

        private void InitializeEvents()
        {
            var requiredControls = new Control[]
            {
                cbCategory, tbProductName, tbSKU, cbPackage, //cbUom, //cbWarehouse
            };
            _requiredValidator = new RequiredFieldValidator(errorProvider1, requiredControls);
            var greaterControls = new Control[]
            {
                //numSupplyPrice, numRetailPrice
            };
            _greaterThanZeroFieldValidator = new GreaterThanZeroFieldValidator(errorProvider1, greaterControls);

            lblCategory.DoubleClick += lblCategory_DoubleClick;
            //lblPackage.DoubleClick += LblPackage_DoubleClick;
            btnAddUom.Click += BtnAddUom_Click;
            lblPackage.DoubleClick += LblPackage_DoubleClick;


            _listener.CategoryUpdated += _listener_CategoryUpdated;
           // _listener.PackageUpdated += _listener_PackageUpdated;
            
        }

        private void LblPackage_DoubleClick(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var productCreate = Program.container.GetInstance<PackageCreateForm>();
                productCreate.SetDataForEdit(0);
                productCreate.ShowDialog();
            }
        }

        private void BtnAddUom_Click(object sender, EventArgs e)
        {
            AddUom(null);
            PopulatePackage();
        }
        
       
        #endregion


        #region Save Codes

        private void SaveProduct()
        {
            var allValid = true;
            var requiredValid = _requiredValidator.IsValid();
            var greaterThanZeroValid = _greaterThanZeroFieldValidator.IsValid();
            allValid = requiredValid && greaterThanZeroValid;
            if (!allValid)
            {
                PopupMessage.ShowMissingInputsMessage();
                this.Focus(); // return the focus to the current form
                return;
            }
            // since category combo displays text only and doesn't hold id, hence get the category from db
            var category = _productService.GetCategory(cbCategory.SelectedItem.ToString());
            //var uomId = 0;
            var warehouseId = 0;
            //int.TryParse(cbUom.SelectedValue as string, out uomId);
            var uomMessage = string.Empty;
            var uoms = GetUomList(ref uomMessage, true);

            if (!string.IsNullOrEmpty(uomMessage))
            {
                PopupMessage.ShowInfoMessage("You have error in UOM. Please check again");
                this.Focus();
                return;
            }
            var product = new ProductModel()
            {
                Id = _productId,
                CategoryId = category.Id,
                ReorderAlert = true,
                Name = tbProductName.Text,
                AttributesJSON = "",
               // BaseUomId = uomId == 0 ? null : (int?)uomId,
                BasePackageId = int.Parse(cbPackage.SelectedValue.ToString()),
                ParentProductId = null,
                IsVariant = false,
                Use = chkUse.Checked,
                IsBuild = chkIsABuild.Checked,
                SKU = tbSKU.Text,
                //RetailPrice = numRetailPrice.Value,
                //SupplyPrice = numSupplyPrice.Value,
                WarehouseId = warehouseId == 0 ? null : (int?)warehouseId,
               // InStockQuantity = (_product?.InStockQuantity??0) == 0 ?  tbInStockQuantity.Value : _product?.InStockQuantity??0,
                Uoms = uoms,
            };
            product.ProductAttributes = _productAttributes;
            var msg = _productService.AddUpdateProduct(product);
            if (string.IsNullOrEmpty(msg))
            {
                PopupMessage.ShowSaveSuccessMessage();
                this.Close();
            }
            else
            {
                PopupMessage.ShowInfoMessage(msg);
                this.Focus();
            }
        }

        private List<UomModel> GetUomList(ref string uomMessage, bool doValidation)
        {
            var uoms = new List<UomModel>();
            foreach (var control in pnlUomList.Controls)
            {
                var productUomUc = control as ProductUomUC;
                if (productUomUc != null)
                {
                    var uom = productUomUc.GetData(errorProvider1, ref uomMessage, doValidation);
                    if (uom != null)
                        uoms.Add(uom);
                }
            }
            return uoms;
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
                categoryCreate.ShowInTaskbar = false;
                categoryCreate.ShowDialog();
            }
        }

        //private void LblPackage_DoubleClick(object sender, EventArgs e)
        //{
        //    using (AsyncScopedLifestyle.BeginScope(Program.container))
        //    {
        //        var categoryCreate = Program.container.GetInstance<PackageCreateForm>();
        //        categoryCreate.ShowInTaskbar = false;
        //        categoryCreate.ShowDialog();
        //    }
        //}


        #endregion


        #region Extra Events

        private void _listener_CategoryUpdated(object sender, CategoryEventArgs e)
        {
            PopulateCategoryCombo();
            if(e.Category !=null)
                cbCategory.Text = e.Category.Name;
        }
        //private void _listener_PackageUpdated(object sender, Service.DbEventArgs.BaseEventArgs<PackageModel> e)
        //{
        //    PopulatePackage();
        //    if(e.Model!=null)
        //        cbPackage.SelectedValue = e.Model.Id;
        //}


        #endregion


        #region Populating Functions

        internal void SetDataForEdit(int productId)
        {
            _productId = productId;
            // get the product
            _product = _productService.GetProductForEdit(productId);

            // SetDataForEdit(_product);
        }

        public void PopulateDataForEdit(ProductModel product)
        {
            if (_product != null)
            {
                this.Text = "Edit Product (" + product.Name + ")";

                tbProductName.Text = product.Name;
                tbSKU.Text = product.SKU;
                //numRetailPrice.Value = product.RetailPrice;
                //numSupplyPrice.Value = product.SupplyPrice;
                cbCategory.Text = product.Category;
                cbPackage.Text = product.BasePackage == null ? "" : product.BasePackage;
                //cbUom.Text = product.BaseUom == null ? "" : product.BaseUom;
                chkUse.Checked = product.Use;
                chkIsABuild.Checked = product.IsBuild;
                //tbInStockQuantity.Value = _product.InStockQuantity;// 0 ? 0 : _product.InStockQuantity;
                //if(_product.InStockQuantity != 0)
                //{
                //    tbInStockQuantity.Enabled = false;
                    
                //}
                if(product.Uoms.Count > 0)
                {
                    foreach(var uom in product.Uoms)
                    {
                        AddUom(uom);
                    }
                }
            }
        }

        private void AddUom(UomModel model)
        {
            if (model == null)
                model = new UomModel { ProductId = _product?.Id ?? 0 };
            var control = new ProductUomUC(_inventoryService, model);
            control.OnDelete += ProductUomUC_OnDelete;
            control.OnPackageComboChanged += ProductUomUC_OnPackageComboChanged;
            control.Dock = DockStyle.Top;
            pnlUomList.Controls.Add(control);
            control.BringToFront();
        }

        private void ProductUomUC_OnPackageComboChanged(object sender, EventArgs e)
        {
            PopulatePackage();
        }

        private void ProductUomUC_OnDelete(object sender, EventArgs e)
        {
            PopulatePackage();
        }

        private void PopulateCategoryCombo()
        {
            cbCategory.Items.Clear();
            cbCategory.FlatStyle = FlatStyle.Popup;
            cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            AddCategoryToCombo(null, null, null);
            cbCategory.Text = "Select";
        }

        private void AddCategoryToCombo(int? categoryId, CategoryModel category, string spaces)
        {
            if (category != null)
                cbCategory.Items.Add(spaces + category.Name);
            var subCategories = _productService.GetCategoryList(categoryId);
            foreach (var sub in subCategories)
            {
                AddCategoryToCombo(sub.Id, sub, spaces == null ? "" : spaces + "   ");
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
            _productAttributes.Add(new ProductAttributeModel
            {
                Attribute = attributeName,
                Id = attributeId,
            });
        }
        
        private void PopulatePackage()
        {
            var selectedItem = cbPackage.SelectedItem as IdNamePair;
            var uomMsg = string.Empty;
            var uomList = GetUomList(ref uomMsg, false);
            var packages = new List<IdNamePair>();
            foreach(var uom in uomList)
            {
                if(!packages.Any(x=>x.Id == uom.PackageId))
                {
                    packages.Add(new IdNamePair
                    {
                        Id = uom.PackageId,
                        Name = uom.Package
                    });
                }
                if (!packages.Any(x => x.Id == uom.RelatedPackageId))
                {
                    packages.Add(new IdNamePair
                    {
                        Id = uom.RelatedPackageId,
                        Name = uom.RelatedPackage
                    });
                }
            }
            //var packages = _inventoryService.GetPackageList();
            cbPackage.DataSource = packages.OrderBy(x=>x.Name).ToList();
            cbPackage.ValueMember = "Id";
            cbPackage.DisplayMember = "Name";
            if (selectedItem != null && packages.Any(x => x.Id == selectedItem.Id))
                cbPackage.SelectedValue = selectedItem.Id;
        }

        //private void PopulateUom()
        //{
        //    var uoms = _inventoryService.GetRootUomList();
        //    cbUom.DataSource = uoms;
        //    cbUom.ValueMember = "Id";
        //    cbUom.DisplayMember = "Name";
        //}


        #endregion



    }
}

