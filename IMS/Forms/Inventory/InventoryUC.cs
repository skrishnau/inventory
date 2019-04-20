using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Forms.Inventory.Create;
using Service.Core.Inventory;
using SimpleInjector.Lifestyles;
using ViewModel.Core.Inventory;
using IMS.Forms.Inventory.Categories;
using System.Threading;
using IMS.Forms.Inventory.Variants;
using IMS.Forms.Common.Display;
using IMS.Forms.Purchases;
using IMS.Forms.Inventory.Products;
using IMS.Forms.Inventory.Suppliers;
using IMS.Forms.Inventory.Attributes;
using IMS.Forms.Inventory.Warehouses;
using IMS.Forms.Business.Create;
using IMS.Forms.Inventory.Transfers;
using IMS.Forms.Inventory.UOM;
using IMS.Forms.Inventory.Packages;
using IMS.Forms.Inventory.Settings.Adjustments;
using IMS.Forms.Inventory.Products.WarehouseProducts;
using IMS.Forms.Inventory.Units;
using IMS.Forms.Inventory.Units.Actions;
using Service.Enums;
using IMS.Forms.Inventory.Settings;
using IMS.Forms.Sales;

namespace IMS.Forms.Inventory
{
    public partial class InventoryUC : UserControl
    {
        private static readonly string MODULE_NAME = "Inventory";
        private BodyTemplate _bodyTemplate;
        private InventoryMenuBar _menubar;

        // dependency injection
        public InventoryUC(InventoryMenuBar menubar)
        {
            _menubar = menubar;

            InitializeComponent();

            InitializeRootTemplate();

            InitializeMenubarButtonEvents();

        }

        private void InitializeRootTemplate()
        {
            // body
            _bodyTemplate = new BodyTemplate();
            _bodyTemplate.Dock = DockStyle.Fill;
            this.Controls.Add(_bodyTemplate);
            // heading
            _bodyTemplate.lblHeading.Text = MODULE_NAME;
            // menubar template
            _bodyTemplate.pnlMenuBar.Controls.Add(_menubar);
        }

        private void InitializeMenubarButtonEvents()
        {
            // product
            _menubar.btnProductList.Click += BtnProductList_Click;

            // order
            //_menubar.btnOrderList.Click += BtnOrderList_Click;
            //_menubar.btnNewOrder.Click += BtnNewOrder_Click;

            // adjustments
            _menubar.btnDirectReceive.Click += BtnDirectReceive_Click;

            // transfers
           // _menubar.btnInventoryTransfers.Click += BtnInventoryTransfers_Click;
            _menubar.btnTransfer.Click += BtnTransfer_Click;
            // supplier
            _menubar.btnSupplierList.Click += BtnSupplierList_Click;
            // warehouse
            _menubar.btnWarehouseList.Click += BtnWarehouseList_Click;
            // settings
            _menubar.btnSettings.Click += BtnSettings_Click;
           

            _menubar.btnLocateInventory.Click += BtnLocateInventory_Click;
            _menubar.btnInventoryUnits.Click += BtnInventoryUnits_Click;

            _menubar.btnPurchaseOrder.Click += BtnPurchaseOrder_Click;
            _menubar.btnSellOrder.Click += BtnSellOrder_Click;
        }

        private void BtnSellOrder_Click(object sender, EventArgs e)
        {
            _bodyTemplate.pnlBody.Controls.Clear();
            var saleUc = Program.container.GetInstance<SaleUC>();
            saleUc.Dock = DockStyle.Fill;
            _bodyTemplate.pnlBody.Controls.Add(saleUc);
            // set selection
            _menubar.SetSelection(sender);
        }

        private void BtnPurchaseOrder_Click(object sender, EventArgs e)
        {
            var purchaseListUC = Program.container.GetInstance<PurchaseOrderUC>();
            _bodyTemplate.pnlBody.Controls.Clear();
            purchaseListUC.Dock = DockStyle.Fill;
            _bodyTemplate.pnlBody.Controls.Add(purchaseListUC);
            // set selection
            _menubar.SetSelection(sender);
        }

        private void BtnInventoryUnits_Click(object sender, EventArgs e)
        {
            var inventoryUnitList = Program.container.GetInstance<InventoryUnitUC>();
            _bodyTemplate.pnlBody.Controls.Clear();
            _bodyTemplate.pnlBody.Controls.Add(inventoryUnitList);
            _menubar.SetSelection(sender);
        }

        private void BtnLocateInventory_Click(object sender, EventArgs e)
        {
            

        }

        #region Products

        private void BtnProductList_Click(object sender, EventArgs e)
        {
            var productListUC = Program.container.GetInstance<ProductUC>();
            _bodyTemplate.pnlBody.Controls.Clear();
            //productListUC.Dock = DockStyle.Fill;
            _bodyTemplate.pnlBody.Controls.Add(productListUC);

            _menubar.SetSelection(sender);
        }



        #endregion

        #region Transfers

        private void BtnTransfer_Click(object sender, EventArgs e)
        {
            // show transfer dialog
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var transferForm = Program.container.GetInstance<TransferForm>();
                transferForm.ShowDialog();
            }
        }

        //private void BtnInventoryTransfers_Click(object sender, EventArgs e)
        //{
        //    // show the list
        //    _bodyTemplate.pnlBody.Controls.Clear();
        //    var transferListUC = Program.container.GetInstance<InventoryTransfersListUC>();
        //    transferListUC.Dock = DockStyle.Fill;
        //    _bodyTemplate.pnlBody.Controls.Add(transferListUC);
        //    // set selection
        //    _menubar.ClearSelection(sender);

        //}

        #endregion



        #region Supplier

        private void BtnSupplierList_Click(object sender, EventArgs e)
        {
            _bodyTemplate.pnlBody.Controls.Clear();
            var supplierListUC = Program.container.GetInstance<SupplierUC>();
            supplierListUC.Dock = DockStyle.Fill;
            _bodyTemplate.pnlBody.Controls.Add(supplierListUC);
            // set selection
            _menubar.SetSelection(sender);
        }

        #endregion




        #region Adjustments
        
        private void BtnDirectReceive_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var directReceiveForm = Program.container.GetInstance<InventoryAdjustmentForm>();
                directReceiveForm.SetData(AdjustmentTypeEnum.DirectReceive);
                directReceiveForm.ShowDialog();
            }
        }


        #endregion


        #region Warehouse

        private void BtnWarehouseList_Click(object sender, EventArgs e)
        {
            var warehouseListUC = Program.container.GetInstance<WarehouseUC>();
            _bodyTemplate.pnlBody.Controls.Clear();
            warehouseListUC.Dock = DockStyle.Fill;
            _bodyTemplate.pnlBody.Controls.Add(warehouseListUC);
            // set selection
            _menubar.SetSelection(sender);
        }

        #endregion


        #region Settings


        private void BtnSettings_Click(object sender, EventArgs e)
        {
            var settingsUC = Program.container.GetInstance<InventorySettingsUC>();
            _bodyTemplate.pnlBody.Controls.Clear();
            settingsUC.Dock = DockStyle.Fill;
            _bodyTemplate.pnlBody.Controls.Add(settingsUC);
            // set selection
            _menubar.SetSelection(sender);
        }
        


        #endregion
    }
}


//private void BtnNewSupplier_Click(object sender, EventArgs e)
//{
//    using (AsyncScopedLifestyle.BeginScope(Program.container))
//    {
//        var supplierCreate = Program.container.GetInstance<SupplierCreate>();// (supplier);
//        supplierCreate.ShowInTaskbar = false;
//        supplierCreate.ShowDialog();
//    }
//}

//private void BtnNewWarehouse_Click(object sender, EventArgs e)
//{
//    using (AsyncScopedLifestyle.BeginScope(Program.container))
//    {
//        var wareHouseCreate = Program.container.GetInstance<WarehouseCreate>();
//        wareHouseCreate.ShowInTaskbar = false;
//        wareHouseCreate.ShowDialog();
//        //PopulateWarehouseData();
//    }
//}


//private void BtnUom_Click(object sender, EventArgs e)
//{
//    var uomUC = Program.container.GetInstance<UomUC>();
//    _bodyTemplate.pnlBody.Controls.Clear();
//    uomUC.Dock = DockStyle.Fill;
//    _bodyTemplate.pnlBody.Controls.Add(uomUC);
//    // set selection
//    _menubar.ClearSelection(sender);
//}

//private void BtnPackage_Click(object sender, EventArgs e)
//{
//    var packageUC = Program.container.GetInstance<PackageUC>();
//    _bodyTemplate.pnlBody.Controls.Clear();
//    packageUC.Dock = DockStyle.Fill;
//    _bodyTemplate.pnlBody.Controls.Add(packageUC);
//    // set selection
//    _menubar.ClearSelection(sender);
//}

//private void BtnAdjustmentCodes_Click(object sender, EventArgs e)
//{
//    var packageUC = Program.container.GetInstance<AdjustmentCodeUC>();
//    _bodyTemplate.pnlBody.Controls.Clear();
//    packageUC.Dock = DockStyle.Fill;
//    _bodyTemplate.pnlBody.Controls.Add(packageUC);
//    // set selection
//    _menubar.ClearSelection(sender);
//}

//private void BtnCategoryList_Click(object sender, EventArgs e)
//{
//    var categoryListUC = Program.container.GetInstance<CategoryListUC>();
//    _bodyTemplate.pnlBody.Controls.Clear();
//    categoryListUC.Dock = DockStyle.Fill;
//    _bodyTemplate.pnlBody.Controls.Add(categoryListUC);

//    _menubar.ClearSelection(sender);
//}
