using System;
using System.Windows.Forms;
using SimpleInjector.Lifestyles;
using IMS.Forms.Common.Display;
using IMS.Forms.Inventory.Products;
using IMS.Forms.Inventory.Suppliers;
using IMS.Forms.Inventory.Warehouses;
using IMS.Forms.Inventory.Units;
using IMS.Forms.Inventory.Units.Actions;
using IMS.Forms.Inventory.Settings;
using IMS.Forms.Inventory.Sales;
using IMS.Forms.Inventory.Orders;
using ViewModel.Enums;
using Service.Core.Orders;
using Service.Listeners;
using IMS.Forms.Inventory.Purchases;

namespace IMS.Forms.Production
{
    public partial class ProductionUC : UserControl
    {
        private static readonly string MODULE_NAME = "Production";
        private BodyTemplate _bodyTemplate;
        private ProductionMenuBar _menubar;

        private readonly IOrderService _orderService;
        private readonly IDatabaseChangeListener _listener;

        // dependency injection
        public ProductionUC(ProductionMenuBar menubar, IOrderService orderService, IDatabaseChangeListener listener)
        {
            _orderService = orderService;
            _listener = listener;
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
            //  _menubar.btnTransfer.Click += BtnTransfer_Click;
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

        private OrderUC purchaseOrderUC;
        private OrderUC saleOrderUC;

        private void BtnSellOrder_Click(object sender, EventArgs e)
        {
            var orderType = OrderTypeEnum.Sale;
            if (saleOrderUC == null)
            {

                // var orderDetailUC = new OrderDetailUC(_orderService,
                //   _listener);
                //Program.container.GetInstance<OrderDetailUC>();
                saleOrderUC = new OrderUC(_orderService,
                    _listener,
                    orderType
                    );
            }

            // var saleOrderUC = Program.container.GetInstance<OrderUC>();
            _bodyTemplate.pnlBody.Controls.Clear();
            _bodyTemplate.pnlBody.Controls.Add(saleOrderUC);
            // set selection
            _menubar.SetSelection(sender);
        }

        private void BtnPurchaseOrder_Click(object sender, EventArgs e)
        {
            var orderType = OrderTypeEnum.Purchase;
            if (purchaseOrderUC == null)
            {
                // var purchaseOrderDetailUC = Program.container.GetInstance<OrderDetailUC>();
                purchaseOrderUC = new OrderUC(_orderService,
                    _listener, orderType
                    );
            }

            //var purchaseOrderUC = Program.container.GetInstance<OrderUC>();
            _bodyTemplate.pnlBody.Controls.Clear();
            _bodyTemplate.pnlBody.Controls.Add(purchaseOrderUC);
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

        //private void BtnTransfer_Click(object sender, EventArgs e)
        //{
        //    // show transfer dialog
        //    using (AsyncScopedLifestyle.BeginScope(Program.container))
        //    {
        //        var transferForm = Program.container.GetInstance<InventoryAdjustmentForm>();
        //        transferForm.SetData(AdjustmentTypeEnum.DirectMove, 0);
        //        transferForm.ShowDialog();
        //    }
        //}

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
                directReceiveForm.SetData(MovementTypeEnum.DirectReceive);
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
            // using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var settingsUC = Program.container.GetInstance<InventorySettingsUC>();
                _bodyTemplate.pnlBody.Controls.Clear();
                settingsUC.Dock = DockStyle.Fill;
                _bodyTemplate.pnlBody.Controls.Add(settingsUC);
                // set selection
                _menubar.SetSelection(sender);
            }
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
