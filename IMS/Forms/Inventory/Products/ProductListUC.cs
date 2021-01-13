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
using Service.DbEventArgs;
using Service.Interfaces;

namespace IMS.Forms.Inventory.Products
{
    public partial class ProductListUC : UserControl
    {
        public event EventHandler<BaseEventArgs<ProductModel>> RowSelected;

        private readonly IProductService _productService;
        private readonly IDatabaseChangeListener _listener;

        private ProductModel _selectedProduct;
        // private HeaderTemplate _header;

        private List<ProductModel> _productList;

        public ProductListUC(IProductService inventoryService, IDatabaseChangeListener listener)
        {
            this._productService = inventoryService;
            this._listener = listener;

            InitializeComponent();
            // use Header template to display header.
            // InitializeHeader();

            this.dgvProductList.AutoGenerateColumns = false;
            this.Load += ProductListUC_Load;
        }

        private void ProductListUC_Load(object sender, EventArgs e)
        {
            // this.heading.Text = "Product List";
            this.Dock = DockStyle.Fill;
            PopulateProductData();
            InitializeEvents();
            InitializeListeners();


        }


        #region Initialize Functions

        private void InitializeEvents()
        {
            dgvProductList.SelectionChanged += DgvProductList_SelectionChanged;
            dgvProductList.CellDoubleClick += DgvProductList_CellDoubleClick;
            dgvProductList.CellFormatting += DgvProductList_CellFormatting;
            btnNew.Click += BtnNew_Click;
            btnEdit.Click += BtnEdit_Click;
            // btnDelete.Click += BtnDelete_Click;
        }

        private void DgvProductList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           // if (e.ColumnIndex == this.colSKU.Index || e.ColumnIndex == this.colName.Index)
            {
                try
                {
                    if (_productList[e.RowIndex].IsLessThanMinimumStock)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Red;
                        // e.CellStyle.BackColor = Color.LightBlue;
                        e.CellStyle.SelectionBackColor = SystemColors.GradientInactiveCaption; //Color.LightBlue;
                    }
                }
                catch (Exception ex) { }
            }
        }

        private void InitializeListeners()
        {
            _listener.ProductUpdated += _listener_ProductUpdated;
            _listener.InventoryUnitUpdated += _listener_InventoryUnitUpdated;
        }



        #endregion


        #region Event Handlers

        private void _listener_ProductUpdated(object sender, Service.Listeners.Inventory.ProductEventArgs e)
        {
            PopulateProductData();
        }

        private void _listener_InventoryUnitUpdated(object sender, BaseEventArgs<List<InventoryUnitModel>> e)
        {
            PopulateProductData();
        }

        private void DgvProductList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var model = dgvProductList.Rows[e.RowIndex].DataBoundItem as ProductModel;
                if (model != null)
                {
                    var args = new BaseEventArgs<ProductModel>(model, Service.Utility.UpdateMode.NONE);
                    RowSelected?.Invoke(sender, args);
                }
            }
        }

        private void DgvProductList_SelectionChanged(object sender, EventArgs e)
        {
            // populate detail 
            //PopulateProductDetail();
            if (dgvProductList.SelectedRows.Count > 0)
            {
                // show edit and delete buttons
                btnEdit.Visible = true;
                // btnDelete.Visible = true;
                var data = (ProductModel)dgvProductList.SelectedRows[0].DataBoundItem;
                _selectedProduct = data;
                //var model = _inventoryService.GetProductForEdit(data.Id);
            }

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

        //private void BtnDelete_Click(object sender, EventArgs e)
        //{
        //    if (_selectedProduct != null)
        //    {
        //        var dialogResult = MessageBox.Show(this, "Are you sure to delete?", "Delete", MessageBoxButtons.YesNo);
        //        if (dialogResult.Equals(DialogResult.Yes))
        //        {
        //            // delete
        //            _inventoryService.DeleteProduct(_selectedProduct.Id);
        //        }
        //    }
        //}


        #endregion



        #region Populate Functions



        private void ShowProductAddEditDialog(int productId)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var productCreate = Program.container.GetInstance<ProductCreateForm>();
                productCreate.SetDataForEdit(productId);
                productCreate.ShowDialog();
            }
        }

        private void PopulateProductData()
        {
            dgvProductList.AutoGenerateColumns = false;
            _productList = _productService.GetProductListForGridView();
            dgvProductList.DataSource = _productList;
            //dgvProductList.ClearSelection();
            //foreach (DataGridViewRow row in dgvProductList.Rows)
            //{
            //    row.Cells[this.colSKU.Index].Style.ForeColor = Color.Red;
            //}
        }

        #endregion



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

//private void InitializeHeader()
//{
//    _header = HeaderTemplate.Instance;
//    _header.btnNew.Visible = true;
//    _header.btnNew.Click += BtnNew_Click;
//    _header.btnEdit.Click += BtnEdit_Click;
//    _header.btnDelete.Click += BtnDelete_Click;
//    this.Controls.Add(_header);
//    _header.SendToBack();
//    // header text
//    _header.lblHeading.Text = "Products";
//}