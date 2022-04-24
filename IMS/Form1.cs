using IMS.Forms.Inventory;
using System;
using System.Windows.Forms;
using IMS.Forms.POS;
using IMS.Forms.Inventory.Orders;
using ViewModel.Enums;
using IMS.Forms.Inventory.Settings.General;
using Service.Core.Settings;
using ViewModel.Utility;
using ViewModel.Core.Orders;
using IMS.Forms.Inventory.Transaction;
using System.IO;
using Service;
using Newtonsoft.Json;
using System.Collections.Generic;
using IMS.Forms.Backup;
using System.Linq;
using Service.Utility;
using SimpleInjector.Lifestyles;
using Service.Core.Orders;
using Service.Interfaces;
using Service.Listeners;
using Service.Core.Inventory;
using Service.Core.Users;

namespace IMS
{
    public partial class Form1 : Form
    {
        //private readonly IOrderService _orderService;
        //private readonly IInventoryService _inventoryService;
        //private readonly IProductService _productService;
        //private readonly IDatabaseChangeListener _listener;
        //private readonly IUserService _userService;
        //private readonly IUomService _uomService;
        //private readonly IProductOwnerService _productOwnerService;
        //private readonly IManufactureService _manufactureService;
        private readonly IDIServiceInstance _dIServiceInstance;
        private readonly IAppSettingService _appSettingService;

        private TransactionCreateLargeForm form;

        public Form1(IDIServiceInstance dIServiceInstance, IAppSettingService appSettingService)//, IOrderService orderService, IProductService productService, IDatabaseChangeListener listener, IInventoryService inventoryService, IUserService userService, IUomService uomService, IProductOwnerService productOwnerService, IManufactureService manufactureService)
        {
            _dIServiceInstance = dIServiceInstance;
            _appSettingService = appSettingService;
            //_orderService = orderService;
            //_productService = productService;
            //_inventoryService = inventoryService;
            //_userService = userService;
            //_listener = listener;
            //_appSettingService = appSettingService;
            //_uomService = uomService;
            //_productOwnerService = productOwnerService;
            //_manufactureService = manufactureService;

            InitializeComponent();

            // InitializeEvents();

            // open inventory at first initialization

            this.Load += Form1_Load;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = Constants.APP_NAME;
            InitLoad();
        }

        private void InitLoad()
        {
            var settings = GetSettingsFromFile();
            var databaseConnectionSuccess = SetDatabaseConnection(settings);
            if (databaseConnectionSuccess)
            {
                ShowLoginFormOrLogin();
            }
            else
            {
                CloseTheApp();
            }
        }

        private bool SetDatabaseConnection(ApplicationSettings settings)
        {
            UserSession.ConnectionStrings = GetConnectionStringFromSettings(settings);
            if (UserSession.ConnectionStrings != null)
            {
                var testSuccess = DatabaseHelper.TestDatabaseConnection(UserSession.ConnectionStrings);
                if (testSuccess)
                {
                    return true;
                }
            }
            if(UserSession.ConnectionStrings == null || string.IsNullOrWhiteSpace(UserSession.ConnectionStrings.EDMXConnectionString))
            {
                // show database configuation page
                var databaseConfigForm = new DatabaseConfigForm();
                var dialogResult = databaseConfigForm.ShowDialog();
                if (dialogResult == DialogResult.Yes || dialogResult == DialogResult.OK)
                {
                    return true;
                }
                return false;
            }
            else
            {
                var result = MessageBox.Show(this, "Database Offline", "Database Offline", MessageBoxButtons.RetryCancel);
                if(result == DialogResult.Retry)
                {
                    InitLoad();
                }
            }
            return false;
        }
        private ConnectionStrings GetConnectionStringFromSettings(ApplicationSettings settings)
        {
            // get connection string
            if(settings!=null && !string.IsNullOrEmpty(settings.DatabaseName) && !string.IsNullOrEmpty(settings.DatabaseServer))
                return DatabaseHelper.GetConnectionString(settings.DatabaseServer, settings.DatabaseName);
            return null;
        }
        private ApplicationSettings GetSettingsFromFile()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var fileFullPath = Path.Combine(path, Constants.APP_NAME, Constants.DATABASE_CONFIG_FILENAME);
            List<ConfigKeyValue> settingsDictionary = new List<ConfigKeyValue>();

            if (File.Exists(fileFullPath))
            {
                var lines = File.ReadAllLines(fileFullPath);
                foreach (var l in lines)
                {
                    var keyValue = ApplicationSettings.TrimAndGetSettingsKeyAndValue(l);
                    if (keyValue == null)
                        continue;
                    settingsDictionary.Add(keyValue);
                }
            }
            // convert to class for easy access
            var settings = new ApplicationSettings();
            if (settingsDictionary.Any(x=>x.Key == ApplicationSettingsEnum.DB_Server))
                settings.DatabaseServer = settingsDictionary.First(x=>x.Key == ApplicationSettingsEnum.DB_Server).Value;
            if (settingsDictionary.Any(x=> x.Key  == ApplicationSettingsEnum.DB_Name))
                settings.DatabaseName = settingsDictionary.First(x=> x.Key == ApplicationSettingsEnum.DB_Name).Value;

            return settings;
        }

        private async void ShowLoginFormOrLogin()
        {
            // DisplayInventory();

            // check for trial
            if (UserSession.IsTrial)
            {
                bool expired = await _appSettingService.IsLicenseExpired();
                if (expired)
                {
                    MessageBox.Show(this, "Your license has expired. Please contact sales.", "License Expired!", MessageBoxButtons.OK);
                    CloseTheApp();
                }
            }
            DialogResult result = DialogResult.Abort;
            // ask for password
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var loginForm = Program.container.GetInstance<LoginForm>();//new InventoryUC();
                result = loginForm.ShowDialog();
            }
            if (result == DialogResult.OK && UserSession.IsLoggedIn())
            {
                DisplayInventory();
            }
            else if (result == DialogResult.Abort)
            {
                ShowLoginFormOrLogin();
            }
            else
            {
                CloseTheApp();
            }

        }

        private void CloseTheApp()
        {
            this.Close();
            try
            {
                this.Dispose();
            }
            catch (Exception) { }
        }
        private async void DisplayInventory()
        {
            /*
            var lockTxnCreate = await _appSettingService.GetIsTransactionCreatePageLocked();
            this.Controls.Clear();
            //var inventoryUC = Program.container.GetInstance<InventoryUC>();//new InventoryUC();
            //this.Controls.Add(inventoryUC);
            
            if (lockTxnCreate)
            {
                form = Program.container.GetInstance<TransactionCreateLargeForm>();
                var orderEditModel = new OrderEditModel
                {
                    OrderType = OrderTypeEnum.Sale,
                    OrderId = 0,
                    OrderOrDirect = OrderOrDirectEnum.Order
                };
                form.SetDataForEdit(orderEditModel); //OrderTypeEnum.Sale, 0
                form.Show();
                this.Hide();
                form.FormClosed += TransactionCreateLargeForm_FormClosed;

            }
            else
            {
            */
            this.Controls.Clear();
            var inventoryUc = _dIServiceInstance.GetInventoryUC(); //Program.container.GetInstance<InventoryUC>();//new InventoryUC();
                    //new InventoryUC(new InventoryMenuBar(), _orderService, _productService, _listener, _inventoryService, _userService, _appSettingService, _uomService, _productOwnerService, _manufactureService);
            this.Controls.Add(inventoryUc);
            inventoryUc.LogoutClicked -= ProductListUC_LogoutClicked;
            inventoryUc.LogoutClicked += ProductListUC_LogoutClicked;
            /* }*/
        }

        private void ProductListUC_LogoutClicked(object sender, EventArgs e)
        {
            UserSession.Logout();
            this.Controls.Clear();
            ShowLoginFormOrLogin();
        }

        private async void TransactionCreateLargeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (form != null)
                form.FormClosed -= TransactionCreateLargeForm_FormClosed;
            var lockTxnCreate = await _appSettingService.GetIsTransactionCreatePageLocked();
            if (lockTxnCreate)
            {
                CloseTheApp();
            }
            else
            {
                this.Controls.Clear();
                var productListUC = Program.container.GetInstance<InventoryUC>();//new InventoryUC();
                this.Controls.Add(productListUC);
                this.Show();
            }
        }

        //private void InitializeEvents()
        //{
        //}

        /*
       private void BtnInventory_Click(object sender, EventArgs e)
       {
          // SetButtonSelection(sender);
           pnlBody.Controls.Clear();
           var productListUC = Program.container.GetInstance<InventoryUC>();//new InventoryUC();
           productListUC.Dock = DockStyle.Fill;
           pnlBody.Controls.Add(productListUC);
       }

       private void btnHome_Click(object sender, EventArgs e)
       {
           //SetButtonSelection(sender);
           // add the body
           pnlBody.Controls.Clear();
           var dashBoardUC = Program.container.GetInstance<DashboardUC>();
           dashBoardUC.Dock = DockStyle.Fill;
           pnlBody.Controls.Add(dashBoardUC);
       }


       private void SetButtonSelection(object button)
       {
           var btn = button as Button;
           if (btn != null)
           {
               ClearButtonSelection();
               btn.FlatStyle = FlatStyle.Flat;
               btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
               //btn.BackColor = System.Drawing.SystemColors.ControlLight;
           }
       }

       private void ClearButtonSelection()
       {
           foreach(var control in pnlSidebarBody.Controls)
           {
               var btn = control as Button;
               if (btn != null)
               {
                   // clear the selection style
                   btn.FlatStyle = FlatStyle.Standard;//System.Drawing.SystemColors.Control;
                   btn.ForeColor = System.Drawing.SystemColors.ControlText;
                   //btn.BackColor = System.Drawing.SystemColors.ControlLight;
               }
           }
       }
       */

    }
}
