using IMS.Forms.Inventory;
using IMS.Forms.Purchases;
using System;
using System.Windows.Forms;
using IMS.Forms.Business;
using IMS.Forms.Users;
using IMS.Forms.Settings;
using IMS.Forms.Dashboard;
using IMS.Forms.Inventory.Suppliers;
using IMS.Forms.POS;
using IMS.Forms.POS.Customers;
using IMS.Forms.Generals;
using IMS.Forms.UserManagement;
using IMS.Forms.Orders;

namespace IMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            InitializeEvents();
            // open dashboard at first initialization
            //DisplayDashboard();
            btnHome_Click(btnDashboard, EventArgs.Empty);

            btnScrollUp.FlatStyle = FlatStyle.Flat;
            btnScrollDown.FlatStyle = FlatStyle.Flat;

        }

        private void InitializeEvents()
        {
            btnInventory.Click += BtnInventory_Click;
            btnGeneral.Click += BtnGeneral_Click;
            btnUserManagement.Click += btnUserManagement_Click;
            btnOrders.Click += BtnOrders_Click;
            //btnSupplier.Click += btnSupplier_Click;
            //btnPurchaseOrder.Click += BtnPurchaseOrder_Click;
            //btnDirectSale.Click += BtnDirectSale_Click;
        }

        private void BtnOrders_Click(object sender, EventArgs e)
        {
            SetButtonSelection(sender);
            pnlBody.Controls.Clear();
            var productListUC = Program.container.GetInstance<OrdersUC>();//new InventoryUC();
            productListUC.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(productListUC);
        }

        private void BtnGeneral_Click(object sender, EventArgs e)
        {
            SetButtonSelection(sender);
            pnlBody.Controls.Clear();
            var productListUC = Program.container.GetInstance<GeneralUC>();//new InventoryUC();
            productListUC.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(productListUC);
        }

        private void BtnInventory_Click(object sender, EventArgs e)
        {
            SetButtonSelection(sender);
            pnlBody.Controls.Clear();
            var productListUC = Program.container.GetInstance<InventoryUC>();//new InventoryUC();
            productListUC.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(productListUC);
        }

        //private void BtnPurchaseOrder_Click(object sender, EventArgs e)
        //{
        //    using (AsyncScopedLifestyle.BeginScope(Program.container))
        //    {
        //        var purchaseOrderForm = Program.container.GetInstance<PurchaseOrderForm>();//new PurchaseOrderForm();
        //        purchaseOrderForm.ShowDialog();
        //    }
        //}

        //private void BtnDirectSale_Click(object sender, EventArgs e)
        //{
        //    var directSaleForm = Program.container.GetInstance<DirectSaleForm>();
        //    directSaleForm.ShowDialog();
        //}

        //private void btnSupplier_Click(object sender, EventArgs e)
        //{
        //    pnlBody.Controls.Clear();
        //    var supplierListUC = Program.container.GetInstance<SupplierUC>();//new SupplierUC();//
        //    supplierListUC.Dock = DockStyle.Fill;
        //    pnlBody.Controls.Add(supplierListUC);
        //}

        //private void btnCustomer_Click(object sender, EventArgs e)
        //{
        //    pnlBody.Controls.Clear();
        //    var customerListUC = Program.container.GetInstance<CustomerUC>();
        //    customerListUC.Dock = DockStyle.Fill;
        //    pnlBody.Controls.Add(customerListUC);
        //}

        //private void btnBusiness_Click(object sender, EventArgs e)
        //{
        //    var businessUC = Program.container.GetInstance<BusinessUC>();
        //    pnlBody.Controls.Clear();
        //    businessUC.Dock = DockStyle.Fill;
        //    pnlBody.Controls.Add(businessUC);
        //}

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            SetButtonSelection(sender);
            var userUC = Program.container.GetInstance<UserManagementUC>();
            pnlBody.Controls.Clear();
            userUC.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(userUC);
        }

        private void btnPurchases_Click(object sender, EventArgs e)
        {
            SetButtonSelection(sender);
            var purchaseListUC = Program.container.GetInstance<PurchaseListUC>();
            pnlBody.Controls.Clear();
            purchaseListUC.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(purchaseListUC);
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            //var saleUC = Program.container.GetInstance<SaleUC>();
            SetButtonSelection(sender);
            var posUC = Program.container.GetInstance<PosUC>();
            pnlBody.Controls.Clear();
            posUC.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(posUC);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            SetButtonSelection(sender);
            var settingsForm = Program.container.GetInstance<SettingsForm>();
            settingsForm.ShowDialog();

        }

        private void btnDirectSale_Click_1(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            SetButtonSelection(sender);
            // add the body
            pnlBody.Controls.Clear();
            var dashBoardUC = Program.container.GetInstance<DashboardUC>();
            dashBoardUC.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(dashBoardUC);
        }

        private void btnSupplier_Click_1(object sender, EventArgs e)
        {

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
    }
}
