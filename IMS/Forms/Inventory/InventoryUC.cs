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
using ViewModel.Core.Orders;
using IMS.Forms.Common;
using IMS.Forms.MRP;
using IMS.Forms.MRP.Departments;
using Service;

namespace IMS.Forms.Inventory
{
    public partial class InventoryUC : UserControl
    {
        public static string CurrentTabTitle;
        public static string CurrentSubTabTitle;

        private static readonly string MODULE_NAME = "Inventory";
        // private BodyTemplate _bodyTemplate;
        //  private InventoryMenuBar _menubar;

        private readonly IOrderService _orderService;
        private readonly IInventoryService _inventoryService;
        private readonly IProductService _productService;
        private readonly IDatabaseChangeListener _listener;
        private readonly IUserService _userService;
        private readonly IAppSettingService _appSettingService;
        private readonly IUomService _uomService;
        private readonly IProductOwnerService _productOwnerService;
        private readonly IManufactureService _manufactureService;
        private readonly IDIServiceInstance _dIServiceInstance;

        private Transaction.TransactionListUC _transactionListUC;
        private Transaction.TransactionListUC _orderListUC;

        private OrderUC purchaseOrderUC;
        private OrderUC saleOrderUC;
        private OrderUC transferOrderUC;

        private Dictionary<string, Button> menuButtonsDictionary = new Dictionary<string, Button>();

        public event EventHandler LogoutClicked;
        // dependency injection
        public InventoryUC(InventoryMenuBar menubar, IOrderService orderService, IProductService productService, IDatabaseChangeListener listener, IInventoryService inventoryService, IUserService userService, IAppSettingService appSettingService, IUomService uomService, IProductOwnerService productOwnerService, IManufactureService manufactureService, IDIServiceInstance dIServiceInstance)
        {
            _orderService = orderService;
            _productService = productService;
            _inventoryService = inventoryService;
            _userService = userService;
            _listener = listener;
            _menubar = menubar;
            _appSettingService = appSettingService;
            _uomService = uomService;
            _productOwnerService = productOwnerService;
            _manufactureService = manufactureService;
            _dIServiceInstance = dIServiceInstance;

            InitializeComponent();

            this.Load += InventoryUC_Load;

        }

        private async void InventoryUC_Load(object sender, EventArgs e)
        {
            InitializeLicense();
            this.Dock = DockStyle.Fill;
            // InitializeRootTemplate();
            InitializeTabControl();
            ShowDashboard();
            var lockTxnCreate = await _appSettingService.GetIsTransactionCreatePageLocked();
            if (lockTxnCreate)
                BtnSaleTransaction_Click(_menubar.btnSaleTransaction, EventArgs.Empty);

            InitializeMenubarButtonEvents();
        }

        private async void InitializeLicense()
        {
            var text = string.Empty;
            if (UserSession.IsTrial)
            {
                var date = await _appSettingService.GetLicenseStartDate();
                try
                {
                    var days = Math.Round((date[0].Value.AddDays(50) - DateTime.Now).TotalDays + 1);
                    text = "Trial Expires After " + days + " days"; //(Math.Round((date[0].Value - DateTime.Now).TotalDays) + 1) 
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

            this.tabControl.DrawItem -= tabControl_DrawItem;
            this.tabControl.DrawItem += tabControl_DrawItem;

            this.tabControl.MouseDown -= tabControl_MouseDown;
            this.tabControl.MouseDown += tabControl_MouseDown;
            // this.tabControl.Selecting += tabControl_Selecting;
            // this.tabControl.HandleCreated += tabControl_HandleCreated;
            this.tabControl.SelectedIndexChanged += TabControl_TabIndexChanged;
        }



        #region Tab Control Init


        private void TabControl_TabIndexChanged(object sender, EventArgs e)
        {
            foreach (var buttonText in menuButtonsDictionary.Keys)
            {
                menuButtonsDictionary[buttonText].BackColor = Color.Transparent;
            }
            if (menuButtonsDictionary.ContainsKey(tabControl.SelectedTab.Text))
                menuButtonsDictionary[tabControl.SelectedTab.Text].BackColor = Color.Gainsboro;
            var baseUc = tabControl.Controls.Count > 0 ? tabControl.SelectedTab.Controls[0] as BaseUserControl : null;
            if (baseUc != null)
            {
                //if (tabControl.SelectedTab.Text.Trim() == "Dashboard")
                //{
                baseUc.ExecuteActions();
                //}
            }
            CurrentTabTitle = tabControl.SelectedTab.Text;
            CurrentSubTabTitle = null;
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
            _menubar.btnBackup.Click += BtnBackup_Click;
            _menubar.btnManufacturings.Click += BtnManufacturings_Click;
            _menubar.btnDepartment.Click += BtnDepartment_Click;
            _menubar.btnVendor.Click += BtnVendor_Click;
            _menubar.btnLogout.Click += BtnLogout_Click;
            _menubar.btnRefresh.Click += BtnRefresh_Click;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshCurrentTab();
        }

        private void RefreshCurrentTab()
        {
            var tab = tabControl.SelectedTab;

            var menuAction = GetMenuAction(tab.Text?.Trim());
            menuAction?.Invoke(_menubar.btnRefresh, EventArgs.Empty);


        }
        private Action<object, EventArgs> GetMenuAction(string tabTitle)
        {
            switch (tabTitle)
            {
                case Constants.TAB_DASHBOARD:
                    return BtnHome_Click;// (_menubar.btnRefresh, EventArgs.Empty);
                case Constants.TAB_PURCHASES:
                    return BtnPurchaseOrder_Click;// (_menubar.btnRefresh, EventArgs.Empty);
                case Constants.TAB_SALES:
                    return BtnSellOrder_Click;// (_menubar.btnRefresh, EventArgs.Empty);
                case Constants.TAB_TRANSFERS:
                    return BtnTransferOrder_Click;// (_menubar.btnRefresh, EventArgs.Empty);
                case Constants.TAB_CLIENTS:
                    return BtnClients_Click;// (_menubar.btnRefresh, EventArgs.Empty);
                case Constants.TAB_VENDOR:
                    return BtnVendor_Click;
                case Constants.TAB_DEPARTMENT:
                    return BtnDepartment_Click;
                case Constants.TAB_INVENTORY_UNITS:
                    return BtnInventoryUnits_Click;
                case Constants.TAB_POS:
                    return BtnPOS_Click;
                case Constants.TAB_PRODUCTS:
                    return BtnProductList_Click;
                case Constants.TAB_MANUFACTURE:
                    return BtnManufacturings_Click;
                case Constants.TAB_TRANSACTIONS:
                    return BtnTransactionList_Click;
                case Constants.TAB_ORDERS:
                    return BtnOrders_Click;
                case Constants.TAB_SETTINGS:
                    return BtnSettings_Click;
                case Constants.TAB_REPORTS:
                    return BtnReports_Click;
                case Constants.TAB_ACCOUNTS:
                    return BtnAccounts_Click;
            }
            return null;
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            LogoutClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            //var folder = "D:\\sysBackups";
            //var conn = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseContextBackup"].ConnectionString;
            //var backupService = new Service.Core.BackupService(conn, folder);
            //backupService.BackupDatabase("IMS");
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var transferForm = Program.container.GetInstance<Backup.DatabaseBackupForm>();
                transferForm.ShowDialog();
            }
        }

        private TabPage AddTabPage(String text, UserControl userControlToAdd, Object sender)
        {
            text += "      ";
            TabPage alreadyExistingTab = null;
            // loop through tab pages to find the string text
            foreach (TabPage tab in tabControl.TabPages)
            {
                if (tab.Text == text)
                {
                    alreadyExistingTab = tab;
                    break;
                }
            }

            bool replacePageContent = (sender as Button)?.Name == _menubar.btnRefresh.Name;

            BaseUserControl currentUserControl;
            if (alreadyExistingTab == null)
            {
                alreadyExistingTab = new TabPage(text);
                if (sender is Button)
                {
                    AddToButtonsDictionary(text, (Button)sender);
                }
                currentUserControl = userControlToAdd as BaseUserControl;
                if (currentUserControl != null)
                {
                    currentUserControl.MyTabTitle = alreadyExistingTab.Text;
                }
                try
                {
                    alreadyExistingTab.Controls.Add(userControlToAdd);
                    tabControl.TabPages.Add(alreadyExistingTab);
                }
                catch (Exception ex)
                {
                    PopupMessage.ShowErrorMessage(ex.Message);
                }
            }
            else
            {
                currentUserControl = alreadyExistingTab.Controls.Count > 0 ? alreadyExistingTab.Controls[0] as BaseUserControl : null;
                if (replacePageContent)
                {
                    alreadyExistingTab.Controls.Clear();
                    alreadyExistingTab.Controls.Add(userControlToAdd);
                }
            }
            //if (currentUserControl != null)
            //{
            //    currentUserControl.ExecuteActions();
            //}
            if (alreadyExistingTab == tabControl.SelectedTab)
                currentUserControl.ExecuteActions();
            else
                tabControl.SelectedTab = alreadyExistingTab;
            return alreadyExistingTab;
        }

        private void AddToButtonsDictionary(string text, Button button)
        {
            if (!menuButtonsDictionary.ContainsKey(text))
            {
                menuButtonsDictionary.Add(text, button);
            }
        }
        private DashboardUC dashboard;
        private void BtnHome_Click(object sender, EventArgs e)
        {
            dashboard = //Program.container.GetInstance<DashboardUC>();
                        //Program.container.GetNewInstanceOfDashboardUC();
                _dIServiceInstance.GetDashboardUC();

            var tabPage = AddTabPage(Constants.TAB_DASHBOARD, dashboard, sender);
        }
        private void BtnPurchaseOrder_Click(object sender, EventArgs e)
        {
            //if (purchaseOrderUC == null)
            //{

            //}
            //var purchaseOrderUC = new OrderUC(_orderService, _inventoryService,
            //        _listener, orderType
            //        );
            var purchaseOrderUc = _dIServiceInstance.GetOrderUC(OrderTypeEnum.Purchase);
            AddTabPage(Constants.TAB_PURCHASES, purchaseOrderUC, sender);
            //pnlBody.Controls.Clear();
            //pnlBody.Controls.Add(purchaseOrderUC);
            // set selection
            //_menubar.SetSelection(sender);
        }
        private void BtnSellOrder_Click(object sender, EventArgs e)
        {
            //var orderType = OrderTypeEnum.Sale;
            //if (saleOrderUC == null)
            //{

            //}
            //var saleOrderUC = new OrderUC(_orderService, _inventoryService,
            //        _listener,
            //        orderType
            //        );
            var saleOrderUC = _dIServiceInstance.GetOrderUC(OrderTypeEnum.Sale);

            // var saleOrderUC = Program.container.GetInstance<OrderUC>();
            //pnlBody.Controls.Clear();
            //pnlBody.Controls.Add(saleOrderUC);
            AddTabPage(Constants.TAB_SALES, saleOrderUC, sender);
            // set selection
            // _menubar.SetSelection(sender);
        }
        private void BtnTransferOrder_Click(object sender, EventArgs e)
        {
            //var orderType = OrderTypeEnum.Move;
            //if (transferOrderUC == null)
            //{

            //    // var orderDetailUC = new OrderDetailUC(_orderService,
            //    //   _listener);
            //    //Program.container.GetInstance<OrderDetailUC>();

            //}
            var transferOrderUC = _dIServiceInstance.GetOrderUC(OrderTypeEnum.Move);
            //new OrderUC(_orderService, _inventoryService,
            //    _listener,
            //    orderType
            //    );

            // var transferOrderUC = Program.container.GetInstance<OrderUC>();
            //pnlBody.Controls.Clear();
            //pnlBody.Controls.Add(transferOrderUC);
            AddTabPage(Constants.TAB_TRANSFERS, transferOrderUC, sender);
            // set selection
            // _menubar.SetSelection(sender);
        }

        private void BtnClients_Click(object sender, EventArgs e)
        {
            var uc = _dIServiceInstance.GetClientListUc();//Program.container.GetInstance<ClientListUC>();
            uc.SetData(UserTypeCategoryEnum.CustomerAndSupplier);
            AddTabPage(Constants.TAB_CLIENTS, uc, sender);
        }

        private void BtnVendor_Click(object sender, EventArgs e)
        {
            //var uc = Program.container.GetInstance<ClientListUC>();
            var uc = _dIServiceInstance.GetClientListUc();//new ClientListUC(_userService, _listener, _appSettingService);
            uc.SetData(UserTypeCategoryEnum.UserAndVendor);
            AddTabPage(Constants.TAB_VENDOR, uc, sender);
        }
        private void BtnDepartment_Click(object sender, EventArgs e)
        {
            var inventoryUnitList = _dIServiceInstance.GetDepartmentListUC();//Program.container.GetInstance<DepartmentListUC>();
            AddTabPage(Constants.TAB_DEPARTMENT, inventoryUnitList, sender);
        }

        private void BtnInventoryUnits_Click(object sender, EventArgs e)
        {
            var inventoryUnitList = _dIServiceInstance.GetInventoryUnitListUC();//Program.container.GetInstance<InventoryUnitListUC>();
            AddTabPage(Constants.TAB_INVENTORY_UNITS, inventoryUnitList, sender);

            //var inventoryDetailUC = Program.container.GetInstance<InventoryDetailUC>();
            //AddTabPage("Inventory", inventoryDetailUC);


            //pnlBody.Controls.Clear();
            //pnlBody.Controls.Add(inventoryUnitList);
            // _menubar.SetSelection(sender);
        }


        private void BtnPOS_Click(object sender, EventArgs e)
        {
            var posUC = _dIServiceInstance.GetPosUC();//Program.container.GetInstance<PosUC>();
            AddTabPage(Constants.TAB_POS, posUC, sender);
            //pnlBody.Controls.Clear();
            //pnlBody.Controls.Add(posUC);
            // _menubar.SetSelection(sender);
        }

        #region Products
        private void BtnProductList_Click(object sender, EventArgs e)
        {
            var productUC = _dIServiceInstance.GetProductUC();//Program.container.GetInstance<ProductUC>();
            AddTabPage(Constants.TAB_PRODUCTS, productUC, sender);
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

        private void BtnManufacturings_Click(object sender, EventArgs e)
        {
            var uc = _dIServiceInstance.GetManufactureListUC();//Program.container.GetInstance<ManufactureListUC>();
            uc.RowSelected -= Uc_RowSelected;
            uc.RowSelected += Uc_RowSelected;
            AddTabPage(Constants.TAB_MANUFACTURE, uc, sender);
        }

        private void Uc_RowSelected(object sender, Service.DbEventArgs.BaseEventArgs<ViewModel.Core.ManufactureModel> e)
        {
            var uc = new ManufactureDetailSmallUC(_manufactureService);
            uc.PopulateData(e.Model);
            AddTabPage(e.Model.Name + "-" + e.Model.LotNo, uc, sender);
        }

        #region Transactions


        private async void BtnSaleTransaction_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {

                var form = Program.container.GetInstance<Transaction.TransactionCreateForm>();
                var orderEditModel = new OrderEditModel
                {
                    OrderType = OrderTypeEnum.Sale,
                    OrderId = 0,
                    OrderOrDirect = OrderOrDirectEnum.Order
                };
                form.SetDataForEdit(orderEditModel); //OrderTypeEnum.Sale, 0
                form.ShowDialog();

                /*
                var form = Program.container.GetInstance<Transaction.TransactionCreateLargeForm>();
                var orderEditModel = new OrderEditModel
                {
                    OrderType = OrderTypeEnum.Sale,
                    OrderId = 0,
                    OrderOrDirect = OrderOrDirectEnum.Order
                };
                form.SetDataForEdit(orderEditModel); //OrderTypeEnum.Sale, 0
                var showTransactionCreateInFullPage = await _appSettingService.GetShowTransactionCreateInFullPage();
                if (showTransactionCreateInFullPage)
                {
                    form.Show();
                    ParentForm.Hide();
                    form.FormClosed += TransactionCreateLargeForm_FormClosed;
                }
                else
                {
                    form.ShowDialog();
                }
                */
            }
        }

        private async void TransactionCreateLargeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var showTransactionCreateInFullPage = await _appSettingService.GetShowTransactionCreateInFullPage();
            var isTransactionCreateLocked = await _appSettingService.GetIsTransactionCreatePageLocked();
            if (showTransactionCreateInFullPage)
            {
                if (isTransactionCreateLocked)
                {
                    ParentForm.Close();
                    ParentForm?.Dispose();
                }
                else
                {
                    ParentForm.Show();
                }
            }
        }

        private void BtnPurchaseTransaction_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var form = Program.container.GetInstance<Transaction.TransactionCreateForm>();
                var orderEditModel = new OrderEditModel
                {
                    OrderType = OrderTypeEnum.Purchase,
                    OrderId = 0,
                    OrderOrDirect = OrderOrDirectEnum.Order
                };
                form.SetDataForEdit(orderEditModel);//OrderTypeEnum.Purchase, 0
                form.ShowDialog();
            }
        }

        private void BtnTransactionList_Click(object sender, EventArgs e)
        {
            var orderType = OrderTypeEnum.All;
            //if (_transactionListUC == null)
            //{

            //}
            var _transactionListUC = new Transaction.TransactionListUC(_orderService,
                    _inventoryService,
                    _userService,
                    _productService,
                    _listener,
                    orderType,
                    OrderListTypeEnum.Transaction,
                    _uomService,
                    _productOwnerService
                    );
            AddTabPage(Constants.TAB_TRANSACTIONS, _transactionListUC, sender);
        }

        private void BtnOrders_Click(object sender, EventArgs e)
        {
            var orderType = OrderTypeEnum.All;
            var _orderListUC = new Transaction.TransactionListUC(_orderService,
                _inventoryService,
                _userService,
                _productService,
                _listener,
                orderType,
                OrderListTypeEnum.Order,
                _uomService,
                _productOwnerService
                );
            AddTabPage(Constants.TAB_ORDERS, _orderListUC, sender);
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
            //{
            var settingsUC = _dIServiceInstance.GetInventorySettingsUC();//Program.container.GetInstance<InventorySettingsUC>();
            AddTabPage(Constants.TAB_SETTINGS, settingsUC, sender);
            //pnlBody.Controls.Clear();
            //pnlBody.Controls.Add(settingsUC);
            // set selection
            // _menubar.SetSelection(sender);
            //}
        }


        private void BtnReports_Click(object sender, EventArgs e)
        {
            var reportUc = _dIServiceInstance.GetReportsUC();//Program.container.GetInstance<ReportsUC>();
            AddTabPage(Constants.TAB_REPORTS, reportUc, sender);
        }


        private void BtnAccounts_Click(object sender, EventArgs e)
        {
            var reportUc = _dIServiceInstance.GetAccountsUC();//Program.container.GetInstance<AccountsUC>();
            AddTabPage(Constants.TAB_ACCOUNTS, reportUc, sender);
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
