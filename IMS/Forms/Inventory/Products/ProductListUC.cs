using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Core.Inventory;
using SimpleInjector.Lifestyles;
using IMS.Forms.Inventory.Create;
using IMS.Forms.Inventory.Variants;
using ViewModel.Core.Inventory;
using IMS.Forms.Common.Display;
using Service.Listeners;

namespace IMS.Forms.Inventory.Products
{
    public partial class ProductListUC : UserControl
    {
        private readonly IInventoryService _inventoryService;
        private readonly IDatabaseChangeListener _listener;

        private ProductModel _selectedProduct;
        private HeaderTemplate _header;

        public ProductListUC(IInventoryService inventoryService, IDatabaseChangeListener listener)
        {
            this._inventoryService = inventoryService;
            this._listener = listener;

            InitializeComponent();
            // use Header template to display header.
            InitializeHeader();

            this.Load += ProductListUC_Load;
        }

        private void ProductListUC_Load(object sender, EventArgs e)
        {
            PopulateProductData();
            InitializeEvents();
            InitializeListeners();
        }

        private void InitializeListeners()
        {
            _listener.ProductUpdated += _listener_ProductUpdated;
        }

        private void _listener_ProductUpdated(object sender, Service.Listeners.Inventory.ProductEventArgs e)
        {
            PopulateProductData();
        }

        private void InitializeEvents()
        {
            dgvProductList.SelectionChanged += DgvProductList_SelectionChanged;
        }

        private void DgvProductList_SelectionChanged(object sender, EventArgs e)
        {
            // populate detail 
            PopulateProductDetail();

        }

        private void PopulateProductDetail()
        {
            // show product detail view
            if (dgvProductList.SelectedRows.Count > 0)
            {
                // show edit and delete buttons
                _header.btnEdit.Visible = true;
                _header.btnDelete.Visible = true;

                var data = (ProductModel)dgvProductList.SelectedRows[0].DataBoundItem;

                var model = _inventoryService.GetProductForEdit(data.Id);
                if (model != null)
                {
                    pnlProductDetail.Visible = true;
                    _selectedProduct = data;
                    lblProductName.Text = data.Name;
                    lblCategory.Text = data.Category;
                    // brand
                    lblBrands.Text = "";
                    foreach (var brand in model.Brands)
                    {
                        lblBrands.Text += brand.Name + ", ";
                    }
                    // attributes
                    lblAttributes.Text = "";
                    foreach (var att in model.ProductAttributes)
                    {
                        lblAttributes.Text += att.Attribute + ", ";
                    }
                    dgvSKUListing.AutoGenerateColumns = false;
                   // dgvSKUListing.DataSource = model.Variants;
                }
                else
                {
                    pnlProductDetail.Visible = false;
                    // show edit and delete buttons
                    _header.btnEdit.Visible = false;
                    _header.btnDelete.Visible = false;
                }
            }
            else
            {
                pnlProductDetail.Visible = false;
                // show edit and delete buttons
                _header.btnEdit.Visible = false;
                _header.btnDelete.Visible = false;
            }
        }

        private void InitializeHeader()
        {
            _header = HeaderTemplate.Instance;
            _header.btnNew.Visible = true;
            _header.btnNew.Click += BtnNew_Click;
            _header.btnEdit.Click += BtnEdit_Click;
            _header.btnDelete.Click += BtnDelete_Click;
            this.Controls.Add(_header);
            _header.SendToBack();
            // header text
            _header.lblHeading.Text = "Products";
        }
        
        private void BtnNew_Click(object sender, EventArgs e)
        {
            ShowProductAddEditDialog(0);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            // get the id from selected row
            if (_selectedProduct != null)
            {
                ShowProductAddEditDialog(_selectedProduct.Id);
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedProduct != null)
            {
                var dialogResult = MessageBox.Show(this, "Are you sure to delete?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult.Equals(DialogResult.Yes))
                {
                    // delete
                    _inventoryService.DeleteProduct(_selectedProduct.Id);
                }
            }
        }

        private void ShowProductAddEditDialog(int productId)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var productCreate = Program.container.GetInstance<ProductCreate>();
                productCreate.SetDataForEdit(productId);
                productCreate.ShowDialog();
            }
        }

        private void PopulateProductData()
        {
            dgvProductList.AutoGenerateColumns = false;
            var products = _inventoryService.GetProductListForGridView();
            dgvProductList.DataSource = products;
        }
       
    }
}


//private void btnEditSKU_Click(object sender, EventArgs e)
//{
//    // var skuEditForm = new VariantEditForm(inventoryService, _selectedProduct.Id);
//    //skuEditForm.ShowDialog();
//}

//private void BtnAddProduct_Click(object sender, EventArgs e)
//{
//    using (AsyncScopedLifestyle.BeginScope(Program.container))
//    {
//        var productCreate = Program.container.GetInstance<ProductCreate>();
//        productCreate.ShowInTaskbar = false;
//        productCreate.ShowDialog();
//    }
//}

//public void PopulateSKUGridView()
//{
//    var skus = _inventoryService.GetVariantList();
//    dgvSKUListing.AutoGenerateColumns = false;
//    dgvSKUListing.DataSource = skus;
//}