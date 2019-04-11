using System;
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
using IMS.Forms.Common.Display;
using SimpleInjector.Lifestyles;
using Service.Listeners;
using IMS.Forms.Inventory.Purchases;

namespace IMS.Forms.Purchases
{
    public partial class PurchaseListUC : UserControl
    {
        private readonly IPurchaseService _purchaseService;
        private readonly IDatabaseChangeListener _listener;

        private readonly PurchaseOrderDetailUC _purchaseOrderDetailUC;

        public PurchaseListUC(IPurchaseService purchaseService, IDatabaseChangeListener listener,
            PurchaseOrderDetailUC purchaseOrderDetailUC)
        {
            _purchaseService = purchaseService;
            _listener = listener;
            _purchaseOrderDetailUC = purchaseOrderDetailUC;

            InitializeComponent();
            InitializeHeader();

            InitializeGridView();

            this.Load += PurchaseListUC_Load;
        }

        private void PurchaseListUC_Load(object sender, EventArgs e)
        {
            PopulatePurchases();
            _listener.PurchaseOrderUpdated += _listener_PurchaseOrderUpdated;
            dgvPurchases.CellMouseDoubleClick += DgvPurchases_CellMouseDoubleClick;
            _purchaseOrderDetailUC.btnBackToList.Click += BtnBackToList_Click;
        }

        private void BtnBackToList_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(_purchaseOrderDetailUC);
            this.Controls.Add(dgvPurchases);
            dgvPurchases.BringToFront();
        }

        private void DgvPurchases_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var row = dgvPurchases.Rows[e.RowIndex].DataBoundItem as PurchaseOrderModel;
            if (row != null)
            {
                _purchaseOrderDetailUC.Dock = DockStyle.Fill;
                _purchaseOrderDetailUC.SetData(row.Id);
                this.Controls.Remove(dgvPurchases);
                this.Controls.Add(_purchaseOrderDetailUC);
                _purchaseOrderDetailUC.BringToFront();
            }
        }

        private void _listener_PurchaseOrderUpdated(object sender, Service.DbEventArgs.BaseEventArgs<PurchaseOrderModel> e)
        {
            PopulatePurchases();
        }

        #region Initializing Functions

        private void InitializeHeader()
        {
            var _header = SubHeadingTemplate.Instance;
            _header.btnNew.Visible = true;
            _header.btnNew.Click += BtnNewOrder_Click;
            // add
            this.Controls.Add(_header);
            _header.SendToBack();
            // header text
            _header.lblHeading.Text = "Purchase Orders";
        }

        private void InitializeGridView()
        {
            dgvPurchases.AutoGenerateColumns = false;
        }


        #endregion


        #region Populating Functions

        private void PopulatePurchases()
        {
            var purchases = _purchaseService.GetAllPurchaseOrders();
            dgvPurchases.DataSource = purchases;
        }

        #endregion





        private void BtnNewOrder_Click(object sender, EventArgs e)
        {
            ShowAddEditDialog(false);
        }

        private void ShowAddEditDialog(bool isEditMode)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var orderForm = Program.container.GetInstance<PurchaseOrderCreateForm>();
                orderForm.SetDataForEdit(isEditMode ? null : (PurchaseOrderModel)null);
                orderForm.ShowDialog();
            }
        }

        //private void dgvPurchases_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dgvPurchases.SelectedRows.Count > 0)
        //    {
        //        var purchase = dgvPurchases.SelectedRows[0].DataBoundItem as PurchaseOrderModel;
        //        lblReceiptNo.Text = purchase.OrderNumber;
        //        lblSupplier.Text = purchase.Supplier;
        //        // get the purchase items
        //        var items = _purchaseService.GetPurchaseOrderItems(purchase.Id);
        //        dgvItems.DataSource = items;
        //    }
        //    else
        //    {
        //        lblReceiptNo.Text = "";
        //        lblSupplier.Text = "Please select a purchase...";
        //        dgvItems.DataSource = null;
        //    }
        //}
    }
}
