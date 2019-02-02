﻿using IMS.Forms.Inventory;
using IMS.Forms.Purchases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            btnCustomer.Click += BtnCustomer_Click;
            btnPurchaseOrder.Click += BtnPurchaseOrder_Click;
        }

        private void BtnCustomer_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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



    }
}
