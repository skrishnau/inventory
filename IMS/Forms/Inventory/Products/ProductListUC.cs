﻿using System;
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
using IMS.Forms.Common.Pagination;
using ViewModel.Core.Common;
using IMS.Forms.Common;

namespace IMS.Forms.Inventory.Products
{
    public partial class ProductListUC : UserControl
    {
        public event EventHandler<BaseEventArgs<ProductModel>> RowSelected;

        private readonly IProductService _productService;
        private readonly IDatabaseChangeListener _listener;

        private ProductModel _selectedProduct;
        // private HeaderTemplate _header;

        BindingSource _bindingSource = new BindingSource();
        private ProductListPaginationHelper helper;
        int _previousSelectedIndex = -1;

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
            InitializeGridView();
            InitializeEvents();
            InitializeListeners();
            PopulateCategoryCombo();
            PopulateProductData();

        }

        private void PopulateCategoryCombo()
        {
            var cats = _productService.GetAllCategoriesForCombo();
            cats.Insert(0, new IdNamePair(0, ""));
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "Id";
            cbCategory.DataSource = cats;
        }


        #region Initialize Functions


        private void InitializeGridView()
        {
            dgvProductList.AutoGenerateColumns = false;
            helper = new ProductListPaginationHelper(_bindingSource, dgvProductList, bindingNavigator1, _productService);

        }


        private void InitializeEvents()
        {
            dgvProductList.SelectionChanged += DgvProductList_SelectionChanged;
            dgvProductList.CellDoubleClick += DgvProductList_CellDoubleClick;
            // dgvProductList.CellFormatting += DgvProductList_CellFormatting;
            btnNew.Click += BtnNew_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            // btnDelete.Click += BtnDelete_Click;
            cbCategory.SelectedIndexChanged += CbCategory_SelectedIndexChanged;
            txtName.TextChanged += TxtName_TextChanged;
           
        }


        private void InitializeListeners()
        {
            _listener.ProductUpdated += _listener_ProductUpdated;
            _listener.InventoryUnitUpdated += _listener_InventoryUnitUpdated;
            _listener.CategoryUpdated += _listener_CategoryUpdated;
        }




        #endregion

        #region Populate Functions


        private void PopulateProductData()
        {
            //_productList = _productService.GetProductList();
            //dgvProductList.DataSource = _productList;

            var category = cbCategory.SelectedItem as IdNamePair;


            if (helper != null)
                helper.Reset(category?.Id ?? 0, txtName.Text);

            // in case new product is added the index will change
            //if (_previousSelectedIndex > -1 && dgvProductList.Rows.Count)
            //{
            //    dgvProductList.Rows[_previousSelectedIndex].Selected = true;
            //}

            //dgvProductList.ClearSelection();
            //foreach (DataGridViewRow row in dgvProductList.Rows)
            //{
            //    row.Cells[this.colSKU.Index].Style.ForeColor = Color.Red;
            //}
        }

        private void ShowProductAddEditDialog(int productId)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var productCreate = Program.container.GetInstance<ProductCreateBasicForm>();
                productCreate.SetDataForEdit(productId);
                productCreate.ShowDialog();
            }
        }

        private void ShowDeleteDialog(ProductModel model)
        {
            var dialogResult = MessageBox.Show(this, "You won't be able to retrieve the product after you delete it." +
                " If you want do a soft-delete, you may uncheck 'Use' checkbox in product edit dialog.\n"+
                " Are you sure to permanently delete the product '" +
                model.Name +
                "'?",
               "Permanent Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                var deleted = _productService.DeleteProduct(model.Id);
                if (deleted)
                    PopupMessage.ShowSuccessMessage("Deleted successfully!");
            }
            //else
            //    PopupMessage.ShowErrorMessage("Couldn't delete! Please contact administrator.");
            this.Focus();
        }


        #endregion

        #region Event Handlers

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            PopulateProductData();
        }

        private void CbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateProductData();
        }

        private void _listener_CategoryUpdated(object sender, Service.Listeners.Inventory.CategoryEventArgs e)
        {
            PopulateCategoryCombo();
        }

        private void _listener_ProductUpdated(object sender, Service.Listeners.Inventory.ProductEventArgs e)
        {
            PopulateProductData();
        }

        private void _listener_InventoryUnitUpdated(object sender, BaseEventArgs<List<InventoryUnitModel>> e)
        {
            PopulateProductData();
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
                btnDelete.Visible = true;
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


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedProduct != null)
            {
                ShowDeleteDialog(_selectedProduct);
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