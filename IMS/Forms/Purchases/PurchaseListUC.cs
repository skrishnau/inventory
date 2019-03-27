﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Core.Purchases.PurchaseOrders;
using ViewModel.Core.Purchases;

namespace IMS.Forms.Purchases
{
    public partial class PurchaseListUC : UserControl
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseListUC(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;

            InitializeComponent();

            InitializeGridView();

            PopulatePurchases();
        }

        private void InitializeGridView()
        {
            dgvPurchases.AutoGenerateColumns = false;
            dgvItems.AutoGenerateColumns = false;
        }

        private void PopulatePurchases()
        {
            var purchases = _purchaseService.GetAllPurchaseOrders();
            dgvPurchases.DataSource = purchases;
        }

        private void btnNewPurchaseOrder_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvPurchases_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvPurchases.SelectedRows.Count > 0)
            {
                var purchase = dgvPurchases.SelectedRows[0].DataBoundItem as PurchaseOrderModelForGridView;
                lblReceiptNo.Text = purchase.ReceiptNo;
                lblSupplier.Text = purchase.Supplier;
                // get the purchase items
                var items = _purchaseService.GetPurchaseItems(purchase.Id);
                dgvItems.DataSource = items;
            }
            else
            {
                lblReceiptNo.Text = "";
                lblSupplier.Text = "Please select a purchase...";
                dgvItems.DataSource = null;
            }
        }
    }
}