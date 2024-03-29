﻿using System;
using System.Windows.Forms;
using SimpleInjector.Lifestyles;
using IMS.Forms.Common.Display;
using IMS.Forms.Inventory.Products;
using IMS.Forms.Inventory.Suppliers;
using IMS.Forms.Inventory.Warehouses;
using IMS.Forms.Inventory.Units;
using IMS.Forms.Inventory.Units.Actions;
using IMS.Forms.Inventory.Settings;
using IMS.Forms.Inventory.Orders;
using ViewModel.Enums;
using Service.Core.Orders;
using Service.Listeners;
using IMS.Forms.Inventory.Purchases;
using IMS.Forms.POS;
using IMS.Forms.Inventory.Dashboard;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using IMS.Forms.Inventory.InventoryDetail;
using Service.Core.Inventory;
using IMS.Forms.Inventory.Reports;
using Service.Interfaces;
using Service.Core.Users;
using Service.Core.Settings;
using ViewModel.Utility;

namespace IMS.Forms.Inventory
{
    public partial class InventoryUC : UserControl
    {
        private static readonly string MODULE_NAME = "Inventory";
        // private BodyTemplate _bodyTemplate;
        //  private InventoryMenuBar _menubar;

        private readonly IOrderService _orderService;
        private readonly IInventoryService _inventoryService;
        private readonly IProductService _productService;
        private readonly IDatabaseChangeListener _listener;
        private readonly IUserService _userService;
        private readonly IAppSettingService _appSettingService;

        private Transaction.TransactionListUC _transactionListUC;
        private Transaction.TransactionListUC _orderListUC;

        private OrderUC purchaseOrderUC;
        private OrderUC saleOrderUC;
        private OrderUC transferOrderUC;

        private Dictionary<string, Button> menuButtonsDictionary = new Dictionary<string, Button>();

        // dependency injection
        public InventoryUC(InventoryMenuBar menubar, IOrderService orderService, IProductService productService, IDatabaseChangeListener listener, IInventoryService inventoryService, IUserService userService, IAppSettingService appSettingService)
        {
            _orderService = orderService;
            _productService = productService;
            _inventoryService = inventoryService;
            _userService = userService;
            _listener = listener;
            _menubar = menubar;
            _appSettingService = appSettingService;


            InitializeComponent();

            this.Load += InventoryUC_Load;

           
            
        }

        private void InventoryUC_Load(object sender, EventArgs e)
        {
            InitializeLicense();
            this.Dock = DockStyle.Fill;
            // InitializeRootTemplate();
            InitializeMenubarButtonEvents();
            InitializeTabControl();
            ShowDashboard();
        }

        private void InitializeLicense()
        {
            var text = string.Empty;
            if (Constants.IS_TRIAL)
            {
                var date = _appSettingService.GetLicenseExpireDate();
                try
                {
                    text = "Trial Expires After " + (Math.Round((date[0].Value - DateTime.Now).TotalDays) + 1) + " days";
                }
                catch (Exception)
                {
                    text = "Trial Expires After 0 days";
                }
            }
            lblExpireDays.Text = text;
        }

        private void InitializeTabControl()
        {
            // sizes the tabs of tabControl
            this.tabControl.ItemSize = new Size(90, 25);
            this.tabControl.Padding = new Point(12, 4);
            this.tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            
           // this.tabControl.SizeMode = TabSizeMode.Fixed;

            this.tabControl.DrawItem += tabControl_DrawItem;
            this.tabControl.MouseDown += tabControl_MouseDown;
            // this.tabControl.Selecting += tabControl_Selecting;
            // this.tabControl.HandleCreated += tabControl_HandleCreated;
            this.tabControl.SelectedIndexChanged += TabControl_TabIndexChanged;
        }



        #region Tab Control Init


        private void TabControl_TabIndexChanged(object sender, EventArgs e)
        {
            foreach(var buttonText in menuButtonsDictionary.Keys)
            {
                menuButtonsDictionary[buttonText].BackColor = Color.Transparent;
            }
            menuButtonsDictionary[tabControl.SelectedTab.Text].BackColor = Color.Gainsboro;

        }

        //
        // Handle Click on Close button 
        //
        private void tabControl_MouseDown(object sender, MouseEventArgs e)
        {
            // don't start from zero cause we have dashboard at 0
            for (var i = 1; i < this.tabControl.TabPages.Count; i++)
            {
                var tabRect = this.tabControl.GetTabRect(i);
                tabRect.Inflate(-2, -2);
                var closeImage = Properties.Resources.icons8_Delete_16px;
                var imageRect = new Rectangle(
                    (tabRect.Right - closeImage.Width),
                    tabRect.Top + (tabRect.Height - closeImage.Height) / 2,
                    closeImage.Width,
                    closeImage.Height);
                if (imageRect.Contains(e.Location))
                {
                    this.tabControl.TabPages.RemoveAt(i);
                    break;
                }
            }


            //var lastIndex = this.tabControl.TabCount - 1;
            //if (this.tabControl.GetTabRect(lastIndex).Contains(e.Location))
            //{
            //    this.tabControl.TabPages.Insert(lastIndex, "New Tab");
            //    this.tabControl.SelectedIndex = lastIndex;
            //}
            //else
            //{
            //    for (var i = 0; i < this.tabControl.TabPages.Count; i++)
            //    {
            //        var tabRect = this.tabControl.GetTabRect(i);
            //        tabRect.Inflate(-2, -2);
            //        var closeImage = Properties.Resources.icons8_Delete_16px;
            //        var imageRect = new Rectangle(
            //            (tabRect.Right - closeImage.Width),
            //            tabRect.Top + (tabRect.Height - closeImage.Height) / 2,
            //            closeImage.Width,
            //            closeImage.Height);
            //        if (imageRect.Contains(e.Location))
            //        {
            //            this.tabControl.TabPages.RemoveAt(i);
            //            break;
            //        }
            //    }
            //}
        }

        // 
        // Draw close button
        //
        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            // don't show close button in dashboard
            if (e.Index < this.tabControl.TabPages.Count)
            {
                // font, backcolor and foreclor
                Font font;
                Brush backBrush;
              //  Brush foreBrush;
                Color foreColor;

                // decide if the tab is selected and design accordingly
                if (e.Index == this.tabControl.SelectedIndex)
                {
                    font = new Font(e.Font, FontStyle.Bold);
                    backBrush = new System.Drawing.SolidBrush(SystemColors.ControlLight);
                    //foreBrush = new System.Drawing.SolidBrush(Color.White);
                    foreColor = SystemColors.ControlText;// Color.DarkGray;
                }
                else
                {
                    font = e.Font;
                    backBrush = new SolidBrush(SystemColors.ControlLightLight);//e.BackColor);
                    //foreBrush = new SolidBrush(e.ForeColor);
                    foreColor = SystemColors.ControlText;// Color.DarkGray;
                }
                // background and foreground
                var rectangle = e.Bounds;
              //  rectangle.Inflate(-1, -1);
                e.Graphics.FillRectangle(backBrush, rectangle);

                var tabPage = this.tabControl.TabPages[e.Index];
                
                var tabRect = this.tabControl.GetTabRect(e.Index);
                tabRect.Inflate(-2, -2);

                if (e.Index > 0)
                {
                    var closeImage = Properties.Resources.icons8_Delete_16px;
                    e.Graphics.DrawImage(closeImage,
                        (tabRect.Right - closeImage.Width),
                        tabRect.Top + (tabRect.Height - closeImage.Height) / 2);
                }
                TextRenderer.DrawText(e.Graphics, tabPage.Text, font,
                    tabRect, foreColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

                backBrush.Dispose();
               
            }


            //if (e.Index == this.tabControl.TabCount - 1)
            //{
            //    var addImage = Properties.Resources.icons8_Plus_Math_16px;
            //    e.Graphics.DrawImage(addImage,
            //        tabRect.Left + (tabRect.Width - addImage.Width) / 2,
            //        tabRect.Top + (tabRect.Height - addImage.Height) / 2);
            //}
            //else
            //{
            //    var closeImage = Properties.Resources.icons8_Delete_16px;
            //    e.Graphics.DrawImage(closeImage,
            //        (tabRect.Right - closeImage.Width),
            //        tabRect.Top + (tabRect.Height - closeImage.Height) / 2);
            //    TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font,
            //        tabRect, tabPage.ForeColor, TextFormatFlags.Left);
            //}
        }

        //
        // Adjust Tab Width
        //
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        private const int TCM_SETMINTABWIDTH = 0x1300 + 49;
        private void tabControl1_HandleCreated(object sender, EventArgs e)
        {
            SendMessage(this.tabControl.Handle, TCM_SETMINTABWIDTH, IntPtr.Zero, (IntPtr)16);
        }


        #endregion



        private void ShowDashboard()
        {
            BtnHome_Click(_menubar.btnHome, EventArgs.Empty);
        }

        //private void InitializeRootTemplate()
        //{
        //    // body
        //    _bodyTemplate = new BodyTemplate();
        //    Dock = DockStyle.Fill;
        //    this.Controls.Add(_bodyTemplate);
        //    // heading
        //    lblHeading.Text = MODULE_NAME;
        //    // menubar template
        //    pnlMenuBar.Controls.Add(_menubar);
        //}

        private void InitializeMenubarButtonEvents()
        {
            _menubar.btnHome.Click += BtnHome_Click;
            // product
            _menubar.btnProductList.Click += BtnProductList_Click;

            // order
            //_menubar.btnOrderList.Click += BtnOrderList_Click;
            //_menubar.btnNewOrder.Click += BtnNewOrder_Click;

            // adjustments
            _menubar.btnDirectReceive.Click += BtnDirectReceive_Click;
            _menubar.btnDirectIssue.Click += BtnDirectIssue_Click;
           // _menubar.btnDirectMove.Click += BtnDirectMove_Click;

            // transfers
            // _menubar.btnInventoryTransfers.Click += BtnInventoryTransfers_Click;
            //  _menubar.btnTransfer.Click += BtnTransfer_Click;
            // supplier
            //_menubar.btnSupplierList.Click += BtnSupplierList_Click;
            //// warehouse
            //_menubar.btnWarehouseList.Click += BtnWarehouseList_Click;
            // settings
            _menubar.btnSettings.Click += BtnSettings_Click;
            _menubar.btnReports.Click += BtnReports_Click;
            _menubar.btnAccounts.Click += BtnAccounts_Click;


            //_menubar.btnLocateInventory.Click += BtnLocateInventory_Click;
            _menubar.btnInventoryUnits.Click += BtnInventoryUnits_Click;

            _menubar.btnPurchaseOrder.Click += BtnPurchaseOrder_Click;
            _menubar.btnSellOrder.Click += BtnSellOrder_Click;
            _menubar.btnTransferOrder.Click += BtnTransferOrder_Click;
            _menubar.btnPOS.Click += BtnPOS_Click;

            _menubar.btnSaleTransaction.Click += BtnSaleTransaction_Click;
            _menubar.btnPurchaseTransaction.Click += BtnPurchaseTransaction_Click;
            _menubar.btnSaleTransactionList.Click += BtnTransactionList_Click;
            _menubar.btnOrders.Click += BtnOrders_Click;

            _menubar.btnClients.Click += BtnClients_Click;
        }


        private void AddTabPage(String text, UserControl uc, Object sender)
        {
            text += "      ";
            TabPage toSelect = null;
            // loop through tab pages to find the string text
            foreach (TabPage tab in tabControl.TabPages)
            {
                if (tab.Text == text)
                {
                    toSelect = tab;
                    break;
                }
            }

            if (toSelect == null)
            {
                var tabPage = new TabPage(text);
                tabPage.Controls.Add(uc);
                tabControl.TabPages.Add(tabPage);

                toSelect = tabPage;

                AddToButtonsDictionary(text, (Button) sender);
            }

            tabControl.SelectedTab = toSelect;
        }

        private void AddToButtonsDictionary(string text, Button button)
        {
            if (!menuButtonsDictionary.ContainsKey(text))
            {
                menuButtonsDictionary.Add(text, button);
            }
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            var dashboard = Program.container.GetInstance<DashboardUC>();
            //pnlBody.Controls.Clear();
            //pnlBody.Controls.Add(dashboard);
            AddTabPage("Dashboard", dashboard, sender);
            //_menubar.SetSelection(sender);
        }

        private void BtnPurchaseOrder_Click(object sender, EventArgs e)
        {
            var orderType = OrderTypeEnum.Purchase;
            if (purchaseOrderUC == null)
            {
                // var purchaseOrderDetailUC = Program.container.GetInstance<OrderDetailUC>();
                purchaseOrderUC = new OrderUC(_orderService, _inventoryService,
                    _listener, orderType
                    );
            }

            //var purchaseOrderUC = Program.container.GetInstance<OrderUC>();
            AddTabPage("Purchases", purchaseOrderUC, sender);
            //pnlBody.Controls.Clear();
            //pnlBody.Controls.Add(purchaseOrderUC);
            // set selection
            //_menubar.SetSelection(sender);
        }


        private void BtnSellOrder_Click(object sender, EventArgs e)
        {
            var orderType = OrderTypeEnum.Sale;
            if (saleOrderUC == null)
            {

                // var orderDetailUC = new OrderDetailUC(_orderService,
                //   _listener);
                //Program.container.GetInstance<OrderDetailUC>();
                saleOrderUC = new OrderUC(_orderService, _inventoryService,
                    _listener,
                    orderType
                    );
            }

            // var saleOrderUC = Program.container.GetInstance<OrderUC>();
            //pnlBody.Controls.Clear();
            //pnlBody.Controls.Add(saleOrderUC);
            AddTabPage("Sales", saleOrderUC, sender);
            // set selection
           // _menubar.SetSelection(sender);
        }

        private void BtnTransferOrder_Click(object sender, EventArgs e)
        {
            var orderType = OrderTypeEnum.Move;
            if (transferOrderUC == null)
            {

                // var orderDetailUC = new OrderDetailUC(_orderService,
                //   _listener);
                //Program.container.GetInstance<OrderDetailUC>();
                transferOrderUC = new OrderUC(_orderService, _inventoryService,
                    _listener,
                    orderType
                    );
            }

            // var transferOrderUC = Program.container.GetInstance<OrderUC>();
            //pnlBody.Controls.Clear();
            //pnlBody.Controls.Add(transferOrderUC);
            AddTabPage("Transfers", transferOrderUC, sender);
            // set selection
            // _menubar.SetSelection(sender);
        }

        private void BtnClients_Click(object sender, EventArgs e)
        {
            var uc = Program.container.GetInstance<SupplierListUC>();
            AddTabPage("Clients", uc, sender);
        }

        private void BtnInventoryUnits_Click(object sender, EventArgs e)
        {
            var inventoryUnitList = Program.container.GetInstance<InventoryUnitUC>();
            AddTabPage("Inventory Units", inventoryUnitList, sender);

            //var inventoryDetailUC = Program.container.GetInstance<InventoryDetailUC>();
            //AddTabPage("Inventory", inventoryDetailUC);


            //pnlBody.Controls.Clear();
            //pnlBody.Controls.Add(inventoryUnitList);
           // _menubar.SetSelection(sender);
        }


        private void BtnPOS_Click(object sender, EventArgs e)
        {
            var posUC = Program.container.GetInstance<PosUC>();
            AddTabPage("POS", posUC, sender);
            //pnlBody.Controls.Clear();
            //pnlBody.Controls.Add(posUC);
           // _menubar.SetSelection(sender);
        }

        #region Products

        private void BtnProductList_Click(object sender, EventArgs e)
        {
            var productListUC = Program.container.GetInstance<ProductUC>();
            AddTabPage("Products", productListUC, sender);
            //pnlBody.Controls.Clear();
            //pnlBody.Controls.Add(productListUC);

           // _menubar.SetSelection(sender);
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
        //    pnlBody.Controls.Clear();
        //    var transferListUC = Program.container.GetInstance<InventoryTransfersListUC>();
        //    transferListUC.Dock = DockStyle.Fill;
        //    pnlBody.Controls.Add(transferListUC);
        //    // set selection
        //    _menubar.ClearSelection(sender);

        //}

        #endregion



        #region Supplier

        //private void BtnSupplierList_Click(object sender, EventArgs e)
        //{
        //    var supplierListUC = Program.container.GetInstance<SupplierUC>();
        //    AddTabPage("Suppliers", supplierListUC);
        //    //pnlBody.Controls.Clear();
        //    //pnlBody.Controls.Add(supplierListUC);
        //    // set selection
        //   // _menubar.SetSelection(sender);
        //}

        #endregion

        #region Transactions


        private void BtnSaleTransaction_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var form = Program.container.GetInstance<Transaction.TransactionCreateForm>();
                form.SetDataForEdit(OrderTypeEnum.Sale, 0);
                form.ShowDialog();
            }
        }

        private void BtnPurchaseTransaction_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var form = Program.container.GetInstance<Transaction.TransactionCreateForm>();
                form.SetDataForEdit(OrderTypeEnum.Purchase, 0);
                form.ShowDialog();
            }
        }

        private void BtnTransactionList_Click(object sender, EventArgs e)
        {
            var orderType = OrderTypeEnum.All;
            if (_transactionListUC == null)
            {
                _transactionListUC = new Transaction.TransactionListUC(_orderService, 
                    _inventoryService,
                    _userService,
                    _productService,
                    _listener,
                    orderType,
                    OrderListTypeEnum.Transaction
                    );
            }
            AddTabPage("Transactions", _transactionListUC, sender);
        }

        private void BtnOrders_Click(object sender, EventArgs e)
        {
            var orderType = OrderTypeEnum.All;
            if (_orderListUC == null)
            {
                _orderListUC = new Transaction.TransactionListUC(_orderService,
                    _inventoryService,
                    _userService,
                    _productService,
                    _listener,
                    orderType,
                    OrderListTypeEnum.Order
                    );
            }
            AddTabPage("Orders", _orderListUC, sender);
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

        private void BtnDirectIssue_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var directReceiveForm = Program.container.GetInstance<InventoryAdjustmentForm>();
                directReceiveForm.SetData(MovementTypeEnum.DirectIssueAny);
                directReceiveForm.ShowDialog();
            }
        }

        private void BtnDirectMove_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var directReceiveForm = Program.container.GetInstance<InventoryAdjustmentForm>();
                directReceiveForm.SetData(MovementTypeEnum.DirectMoveAny);
                directReceiveForm.ShowDialog();
            }
        }

        #endregion


        #region Warehouse

        //private void BtnWarehouseList_Click(object sender, EventArgs e)
        //{
        //    var warehouseListUC = Program.container.GetInstance<WarehouseUC>();
        //    AddTabPage("Warehouses", warehouseListUC);
        //    //pnlBody.Controls.Clear();
        //    //pnlBody.Controls.Add(warehouseListUC);
        //    // set selection
        //   // _menubar.SetSelection(sender);
        //}

        #endregion


        #region Settings


        private void BtnSettings_Click(object sender, EventArgs e)
        {
            // using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var settingsUC = Program.container.GetInstance<InventorySettingsUC>();
                AddTabPage("Settings", settingsUC, sender);
                //pnlBody.Controls.Clear();
                //pnlBody.Controls.Add(settingsUC);
                // set selection
               // _menubar.SetSelection(sender);
            }
        }


        private void BtnReports_Click(object sender, EventArgs e)
        {
            var reportUc = Program.container.GetInstance<ReportsUC>();
            AddTabPage("Reports", reportUc, sender);
        }


        private void BtnAccounts_Click(object sender, EventArgs e)
        {
            var reportUc = Program.container.GetInstance<AccountsUC>();
            AddTabPage("Accounts", reportUc, sender);
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
//    pnlBody.Controls.Clear();
//    uomUC.Dock = DockStyle.Fill;
//    pnlBody.Controls.Add(uomUC);
//    // set selection
//    _menubar.ClearSelection(sender);
//}

//private void BtnPackage_Click(object sender, EventArgs e)
//{
//    var packageUC = Program.container.GetInstance<PackageUC>();
//    pnlBody.Controls.Clear();
//    packageUC.Dock = DockStyle.Fill;
//    pnlBody.Controls.Add(packageUC);
//    // set selection
//    _menubar.ClearSelection(sender);
//}

//private void BtnAdjustmentCodes_Click(object sender, EventArgs e)
//{
//    var packageUC = Program.container.GetInstance<AdjustmentCodeUC>();
//    pnlBody.Controls.Clear();
//    packageUC.Dock = DockStyle.Fill;
//    pnlBody.Controls.Add(packageUC);
//    // set selection
//    _menubar.ClearSelection(sender);
//}

//private void BtnCategoryList_Click(object sender, EventArgs e)
//{
//    var categoryListUC = Program.container.GetInstance<CategoryListUC>();
//    pnlBody.Controls.Clear();
//    categoryListUC.Dock = DockStyle.Fill;
//    pnlBody.Controls.Add(categoryListUC);

//    _menubar.ClearSelection(sender);
//}
