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
using Service.Core.Inventory;
using IMS.Forms.Common;
using SimpleInjector.Lifestyles;
using IMS.Forms.Purchases;
using Service.Listeners;
using IMS.Forms.Inventory.Purchases.Order;

namespace IMS.Forms.Inventory.Purchases
{
    public partial class PurchaseOrderDetailUC : UserControl
    {
        private readonly IPurchaseService _purchaseService;
        private readonly IInventoryService _inventoryService;
        private readonly IDatabaseChangeListener _listener;

        //private PurchaseOrderModel _purchaseOrderModel;
        private int _purchaseOrderId;
        private PurchaseOrderModel _purchaseOrderModel;

        public PurchaseOrderDetailUC(IPurchaseService purchaseService, IInventoryService inventoryService, IDatabaseChangeListener listener)
        {
            _purchaseService = purchaseService;
            _inventoryService = inventoryService;
            _listener = listener;

            InitializeComponent();

            this.Load += PurchaseOrderDetailUC_Load;
        }

        private void PurchaseOrderDetailUC_Load(object sender, EventArgs e)
        {
            InitializeListener();
        }



        #region Initialize Functions

        private void InitializeListener()
        {
            _listener.PurchaseOrderUpdated += _listener_PurchaseOrderUpdated;
        }
      
        #endregion



        #region Event Handlers

        private void _listener_PurchaseOrderUpdated(object sender, Service.DbEventArgs.BaseEventArgs<PurchaseOrderModel> e)
        {
            if (e.Model.Id == _purchaseOrderId)
            {
                SetData(e.Model);
            }
        }

        #endregion



        #region Populating Functions

        public void SetData(int purchaseOrderId)
        {
            var model = _purchaseService.GetPurchaseOrder(purchaseOrderId);
            SetData(model);
        }

        public void SetData(PurchaseOrderModel model)
        {
            _purchaseOrderId = model == null ? 0 : model.Id;
            _purchaseOrderModel = model;
            if (model != null)
            {

                // populate
                lblExpectedDate.Text = model.ExpectedDate.ToShortDateString();
                lblLotNumber.Text = model.LotNumber.ToString();
                lblName.Text = model.Name;
                // lblOrderDate.Text = po.OrderDate.HasValue? po.OrderDate.Value.ToShortDateString(): " - ";
                lblOrderNumber.Text = model.OrderNumber;
                lblSupplier.Text = model.Supplier;
                lblSupplierInvoice.Text = model.SupplierInvoice;
                lblWarehouse.Text = model.Warehouse;
                lblNoItemsMessage.Visible = !model.PurchaseOrderItems.Any();

                dgvItems.AutoGenerateColumns = false;
                dgvItems.DataSource = model.PurchaseOrderItems;

                // logic to show buttons; the order must be maintained cause sent and received can be true at same time
                if (model.IsCancelled)
                {
                    DesignForCancelled();
                }
                else if (model.IsReceived)
                {
                    DesignForReceived();
                }
                else if (model.IsOrderSent)
                {
                    DesignForSent();
                }
                else
                {
                    DesignForOpen();
                }
            }
        }
        
        private void DesignForOpen()
        {
            btnCancelOrder.Enabled = true;
            btnCancelOrder.Visible = true;
            btnEditDetails.Enabled = true;
            btnEditDetails.Visible = true;
            btnEditItems.Enabled = true;
            btnEditItems.Visible= true;
            btnReceive.Enabled = false;
            btnReceive.Visible = false;
            btnSendOrder.Enabled = true;
            btnSendOrder.Visible = true;
            lblStatus.Text = "( Open )";
        }

        private void DesignForCancelled()
        {
            btnCancelOrder.Enabled = false;
            btnCancelOrder.Visible = false;
            btnEditDetails.Enabled = false;
            btnEditDetails.Visible = false;
            btnEditItems.Enabled = false;
            btnEditItems.Visible = false;
            btnReceive.Enabled = false;
            btnReceive.Visible = false;
            btnSendOrder.Enabled = false;
            btnSendOrder.Visible = false;
            lblStatus.Text = "( Cancelled )";
        }

        private void DesignForSent()
        {
            btnCancelOrder.Enabled = true;
            btnCancelOrder.Visible = true;
            btnEditDetails.Enabled = false;
            btnEditDetails.Visible = false;
            btnEditItems.Enabled = false;
            btnEditItems.Visible = false;
            btnReceive.Enabled = true;
            btnReceive.Visible = true;
            btnSendOrder.Enabled = false;
            btnSendOrder.Visible = false;
            lblStatus.Text = "( Sent )";
        }

        private void DesignForReceived()
        {
            btnCancelOrder.Enabled = false;
            btnCancelOrder.Visible = false;
            btnEditDetails.Enabled = false;
            btnEditDetails.Visible = false;
            btnEditItems.Enabled = false;
            btnEditItems.Visible = false;
            btnReceive.Enabled = false;
            btnReceive.Visible = false;
            btnSendOrder.Enabled = false;
            btnSendOrder.Visible = false;
            lblStatus.Text = "( Received )";
        }
        
        #endregion


        #region Actions Event Handlers
        
        private void btnEditDetails_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var po = Program.container.GetInstance<PurchaseOrderCreateForm>();
                po.SetDataForEdit(_purchaseOrderId);
                po.ShowDialog();
            }
        }

        private void btnEditItems_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var itemCreateForm = Program.container.GetInstance<PurchaseOrderItemCreateForm>();
                itemCreateForm.SetData(_purchaseOrderModel);
                itemCreateForm.ShowDialog();
            }
        }

        private void btnSendOrder_Click(object sender, EventArgs e)
        {
            if (!_purchaseOrderModel.PurchaseOrderItems.Any())
            {
                MessageBox.Show("There aren't any items. Please add items to the order.", "No items!");
                return;
            }
            var dialogResult = MessageBox.Show(this, "Are you sure to send it to the Supplier? "+
                "You won't be able to edit the order after it's sent.", "Send?", MessageBoxButtons.YesNo);
            if (dialogResult.Equals(DialogResult.Yes))
            {
                var msg = _purchaseService.SetSent(_purchaseOrderId);
                if (string.IsNullOrEmpty(msg))
                    PopupMessage.ShowSuccessMessage("Successfully Sent!");
                else
                    PopupMessage.ShowErrorMessage(msg);
                this.Focus();
            }
        }


        #endregion

        private void btnReceive_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(this, "Are you sure to receive items against this purchase order?", "Receive?", MessageBoxButtons.YesNo);
            if (dialogResult.Equals(DialogResult.Yes))
            {
               var msg = _purchaseService.SetReceived(_purchaseOrderId);
                if (string.IsNullOrEmpty(msg))
                    PopupMessage.ShowSuccessMessage("Successfully Received!");
                else 
                    PopupMessage.ShowErrorMessage(msg);
                this.Focus();
            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(this, "Are you sure to cancel the order?", "Cancel?", MessageBoxButtons.YesNo);
            if (dialogResult.Equals(DialogResult.Yes))
            {
                var msg = _purchaseService.SetCancelled(_purchaseOrderId);
                if (string.IsNullOrEmpty(msg))
                    PopupMessage.ShowSuccessMessage("Successfully Cancelled!");
                else
                    PopupMessage.ShowErrorMessage(msg);
                this.Focus();
            }
        }

    }
}

//private void DesignForNew()
//{
//    btnCancelOrder.Enabled = true;
//    btnCancelOrder.Visible = true;
//    btnEditDetails.Enabled = true;
//    btnEditDetails.Visible = true;
//    btnEditItems.Enabled = false;
//    btnEditItems.Visible = false;
//    btnReceive.Visible = false;
//    btnReceive.Enabled = false;
//    btnSendOrder.Enabled = false;
//    lblStatus.Text = "( Newly Opened )";
//}