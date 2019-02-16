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
            var purchaseOrderForm = Program.container.GetInstance<PurchaseOrderForm>();//new PurchaseOrderForm();
            purchaseOrderForm.ShowDialog();
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
    }
}
