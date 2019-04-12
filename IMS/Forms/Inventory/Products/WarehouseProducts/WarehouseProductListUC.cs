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

namespace IMS.Forms.Inventory.Products.WarehouseProducts
{
    public partial class WarehouseProductListUC : UserControl
    {
        private readonly IDatabaseChangeListener _listener;
        private readonly IInventoryService _inventoryService;
        private readonly IBusinessService _businessService;

        private SubHeadingTemplate _header;

        public WarehouseProductListUC(IDatabaseChangeListener listener, 
            IInventoryService inventoryService,
            IBusinessService businessService)
        {
            _listener = listener;
            _inventoryService = inventoryService;
            _businessService = businessService;

            InitializeComponent();

            this.Load += WarehouseProductListUC_Load;
        }

        private void WarehouseProductListUC_Load(object sender, EventArgs e)
        {
            InitializeHeader();
            PopulateWarehouses();
            PopulateProducts();
            PopulateWarehouseProducts();

            InitializeComboBoxEvents();
        }



        #region Initialize Functions

        private void InitializeHeader()
        {
            _header = SubHeadingTemplate.Instance;
            this.Controls.Add(_header);
            _header.SendToBack();
            // header text
            _header.lblHeading.Text = "Locate Inventory";
        }

        private void InitializeComboBoxEvents()
        {
            cbWarehouse.SelectedValueChanged += CbWarehouse_SelectedValueChanged;
            cbProduct.SelectedValueChanged += CbProduct_SelectedValueChanged;
        }


        #endregion



        #region Populate Functions

        private void PopulateWarehouses()
        {
            var warehouses = _businessService.GetWarehouseIdNameList();
            var allWarehouse = new IdNamePair{Id = 0, Name = " ---- All ---- "};
            warehouses.Insert(0, allWarehouse);
            cbWarehouse.DataSource = warehouses;
            cbWarehouse.DisplayMember = "Name";
            cbWarehouse.ValueMember = "Id";
        }

        private void PopulateProducts()
        {
            var products = _inventoryService.GetProductIdNameList();
            var allProduct = new IdNamePair { Id=0, Name=" ---- All ---- " };
            products.Insert(0, allProduct);
            cbProduct.DataSource = products;
            cbProduct.DisplayMember = "Name";
            cbProduct.ValueMember = "Id";
        }

        private void PopulateWarehouseProducts()
        {
            var warehouseId = int.Parse(cbWarehouse.SelectedValue.ToString());
            var productId = int.Parse(cbProduct.SelectedValue.ToString());
            var warehouseProducts = _inventoryService.GetWarehouseProductList(warehouseId, productId);
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
