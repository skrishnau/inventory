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

namespace IMS
{
    public partial class Form1 : Form
    {
        private readonly IAppSettingService _appSettingService;

        private TransactionCreateLargeForm form;

        public Form1(IAppSettingService appSettingService)
        {
            _appSettingService = appSettingService;

            InitializeComponent();

            // InitializeEvents();

            // open inventory at first initialization

            this.Load += Form1_Load;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = Constants.APP_NAME;
            //GetDatabaseConnection();
            //if (string.IsNullOrEmpty(UserSession.Database))
            //{

            //}
            //else
            //{
                ShowLoginFormOrLogin();
            //}
        }

        private void GetDatabaseConnection()
        {
            // get connection string
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var lines = File.ReadAllText(Path.Combine(path, Constants.DATABASE_CONFIG_FILENAME));
            var obj = JsonConvert.DeserializeObject<ApplicationSettings>(lines);
            if (obj != null)
            {
                UserSession.Database = obj.ConnectionString;
            }
            if (string.IsNullOrWhiteSpace(UserSession.Database))
            {
                // show database configuation page
               // var databaseConfigForm = new DatabaseConfigForm();
            }
        }

        private async void ShowLoginFormOrLogin()
        {
            // DisplayInventory();

            // check for trial
            if (Constants.IS_TRIAL)
            {
                bool expired = await _appSettingService.IsLicenseExpired();
                if (expired)
                {
                    MessageBox.Show(this, "Your license has expired. Please contact sales.", "License Expired!", MessageBoxButtons.OK);
                    CloseTheApp();
                }
            }

            // ask for password
            var loginForm = Program.container.GetInstance<LoginForm>();//new InventoryUC();

            DialogResult result = loginForm.ShowDialog();
            if (result == DialogResult.OK)
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
            var productListUC = Program.container.GetInstance<InventoryUC>();//new InventoryUC();
            this.Controls.Add(productListUC);
            /* }*/
        }
        private async void TransactionCreateLargeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (form != null)
                form.FormClosed -= TransactionCreateLargeForm_FormClosed;
            var lockTxnCreate = await _appSettingService.GetIsTransactionCreatePageLocked();
            if (lockTxnCreate)
            {
                this.Close();
                this?.Dispose();
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
