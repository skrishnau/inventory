using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Listeners;
using Service.Core.Inventory;
using IMS.Forms.Common.Display;
using Service.Core.Business;
using ViewModel.Core.Business;
using ViewModel.Core.Common;
using Service.Interfaces;
using Service.DbEventArgs;
using ViewModel.Core.Inventory;

namespace IMS.Forms.Inventory.Units.Details
{
    public partial class WarehouseProductListUC : UserControl
    {
        private readonly IDatabaseChangeListener _listener;
        private readonly IInventoryService _inventoryService;
        private readonly IProductService _productService;
        private readonly IBusinessService _businessService;

      //  private HeaderTemplate _header;

        public WarehouseProductListUC(IDatabaseChangeListener listener,
            IInventoryService inventoryService,
            IProductService productService,
            IBusinessService businessService)
        {
            _listener = listener;
            _inventoryService = inventoryService;
            _productService = productService;
            _businessService = businessService;

            InitializeComponent();

            this.Load += WarehouseProductListUC_Load;

        }



        private void WarehouseProductListUC_Load(object sender, EventArgs e)
        {
           // PopulateWarehouses();
            PopulateProducts();
            PopulateWarehouseProducts();


            // events should be at the last
            InitializeComboBoxEvents();
            _listener.InventoryUnitUpdated += _listener_InventoryUnitUpdated;
            // _listener.WarehouseUpdated += _listener_WarehouseUpdated;
            _listener.ProductUpdated += _listener_ProductUpdated;
        }



        private void _listener_InventoryUnitUpdated(object sender, Service.DbEventArgs.BaseEventArgs<List<ViewModel.Core.Inventory.InventoryUnitModel>> e)
        {
            PopulateWarehouseProducts();
        }

        //private void _listener_WarehouseUpdated(object sender, Service.DbEventArgs.BaseEventArgs<WarehouseModel> e)
        //{
        //    PopulateWarehouses();
        //}
        private void _listener_ProductUpdated(object sender, BaseEventArgs<ProductModel> e)
        {
            PopulateProducts();
        }


        #region Initialize Functions

        //private void InitializeHeader()
        //{
        //    _header = HeaderTemplate.Instance;
        //    this.Controls.Add(_header);
        //    _header.SendToBack();
        //    // header text
        //    _header.lblHeading.Text = "Locate Inventory";
        //}

        private void InitializeComboBoxEvents()
        {
            //cbWarehouse.SelectedValueChanged += CbWarehouse_SelectedValueChanged;
            cbProduct.SelectedValueChanged += CbProduct_SelectedValueChanged;
        }


        #endregion



        #region Populate Functions

        //private void PopulateWarehouses()
        //{
        //    var warehouses = _inventoryService.GetWarehouseListForCombo();
        //    var allWarehouse = new IdNamePair { Id = 0, Name = " ---- All ---- " };
        //    warehouses.Insert(0, allWarehouse);
        //    cbWarehouse.DataSource = warehouses;
        //    cbWarehouse.DisplayMember = "Name";
        //    cbWarehouse.ValueMember = "Id";
        //}

        private void PopulateProducts()
        {
            var products = _productService.GetProductListForCombo();
            var allProduct = new IdNamePair { Id = 0, Name = " ---- All ---- " };
            products.Insert(0, allProduct);
            cbProduct.DataSource = products;
            cbProduct.DisplayMember = "Name";
            cbProduct.ValueMember = "Id";
        }

        private void PopulateWarehouseProducts()
        {
            //var warehouseId = int.Parse(cbWarehouse.SelectedValue.ToString());
            var productId = int.Parse(cbProduct.SelectedValue.ToString());
            var warehouseProducts = _inventoryService.GetWarehouseProductList(0, productId);
            dgvWarehouseProduct.AutoGenerateColumns = false;
            dgvWarehouseProduct.DataSource = warehouseProducts;
        }

        #endregion



        #region Events (filter controls)


        private void CbProduct_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateWarehouseProducts();
        }

        private void CbWarehouse_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateWarehouseProducts();
        }

        #endregion



    }
}
