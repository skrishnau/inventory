using IMS.Forms.Inventory;
using IMS.Forms.Purchases;
using IMS.Forms.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Forms.Suppliers;
using IMS.Forms.Business;
using IMS.Forms.Users;
using IMS.Forms.Sales;
using SimpleInjector.Lifestyles;
using IMS.Forms.Settings;

namespace IMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            InitializeEvents();

        }

        private void InitializeEvents()
        {
            btnProducts.Click += BtnProducts_Click;
            btnSupplier.Click += btnSupplier_Click;
            btnPurchaseOrder.Click += BtnPurchaseOrder_Click;
            btnDirectSale.Click += BtnDirectSale_Click;
        }

        private void BtnDirectSale_Click(object sender, EventArgs e)
        {
            var directSaleForm = Program.container.GetInstance<DirectSaleForm>();
            directSaleForm.ShowDialog();

        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            var productListUC = Program.container.GetInstance<InventoryUC>();//new InventoryUC();
            productListUC.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(productListUC);
        }

        private void BtnPurchaseOrder_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var purchaseOrderForm = Program.container.GetInstance<PurchaseOrderForm>();//new PurchaseOrderForm();
                purchaseOrderForm.ShowDialog();
            }
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            var supplierListUC = Program.container.GetInstance<SupplierUC>();//new SupplierUC();//
            supplierListUC.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(supplierListUC);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            var customerListUC = Program.container.GetInstance<CustomerUC>();
            customerListUC.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(customerListUC);
        }

        private void btnBusiness_Click(object sender, EventArgs e)
        {
            var businessUC = Program.container.GetInstance<BusinessUC>();
            pnlBody.Controls.Clear();
            businessUC.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(businessUC);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            var userUC = Program.container.GetInstance<UserUC>();
            pnlBody.Controls.Clear();
            userUC.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(userUC);
        }

        private void btnPurchases_Click(object sender, EventArgs e)
        {
            var purchaseListUC = Program.container.GetInstance<PurchaseListUC>();
            pnlBody.Controls.Clear();
            purchaseListUC.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(purchaseListUC);
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            var saleUC = Program.container.GetInstance<SaleUC>();
            pnlBody.Controls.Clear();
            saleUC.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(saleUC);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            var settingsForm = Program.container.GetInstance<SettingsForm>();
            settingsForm.ShowDialog();

        }
    }
}
