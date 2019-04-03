﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleInjector.Lifestyles;
using IMS.Forms.Purchases;
using IMS.Forms.Sales;

namespace IMS.Forms.Dashboard
{
    public partial class DashboardMenuBar : UserControl
    {
        public DashboardMenuBar()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void btnPurchaseOrder_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var purchaseOrderForm = Program.container.GetInstance<PurchaseOrderForm>();//new PurchaseOrderForm();
                purchaseOrderForm.ShowDialog();
            }
        }

        private void btnDirectSale_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var directSaleForm = Program.container.GetInstance<DirectSaleForm>();
                directSaleForm.ShowDialog();
            }
        }
    }
}