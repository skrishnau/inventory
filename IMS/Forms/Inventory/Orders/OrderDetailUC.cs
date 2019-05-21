using System;
using System.Linq;
using System.Windows.Forms;
using ViewModel.Core.Orders;
using Service.Core.Inventory;
using IMS.Forms.Common;
using SimpleInjector.Lifestyles;
using Service.Listeners;
using IMS.Forms.Inventory.Purchases.Order;
using IMS.Forms.Inventory.Units.Actions;
using Service.Core.Orders;
using IMS.Forms.Inventory.Orders;
using ViewModel.Enums;

namespace IMS.Forms.Inventory.Purchases
{
    public partial class OrderDetailUC : UserControl
    {
        private readonly IOrderService _orderService;
       // private readonly IInventoryService _inventoryService;
        private readonly IDatabaseChangeListener _listener;

        //private PurchaseOrderModel _purchaseOrderModel;
        private int _purchaseOrderId;
        private OrderModel _purchaseOrderModel;
        private OrderTypeEnum _orderType;

        public OrderDetailUC(IOrderService orderService, IDatabaseChangeListener listener)
        {
            _orderService = orderService;
            //_inventoryService = inventoryService;
            _listener = listener;

            InitializeComponent();
            this.Dock = DockStyle.Fill;

            this.Load += PurchaseOrderDetailUC_Load;
        }

        private void PurchaseOrderDetailUC_Load(object sender, EventArgs e)
        {
            PopulateData();
            UpdateViewForOrderType();
            InitializeListener();
        }




        #region Initialize Functions

        private void InitializeListener()
        {
            _listener.PurchaseOrderUpdated += _listener_PurchaseOrderUpdated;
        }

        #endregion



        #region Event Handlers

        private void _listener_PurchaseOrderUpdated(object sender, Service.DbEventArgs.BaseEventArgs<OrderModel> e)
        {
            if (e.Model.Id == _purchaseOrderId)
            {
                PopulateData(e.Model);
            }
        }

        #endregion



        #region Populating Functions


        private void UpdateViewForOrderType()
        {
            switch (_orderType)
            {
                case OrderTypeEnum.Purchase:

                    break;
                case OrderTypeEnum.Sale:
                    btnReceive.Text = "Issue";
                    btnSendOrder.Text = "Confirm";
                    break;
            }
        }

        public void SetData(OrderTypeEnum orderType, int purchaseOrderId)
        {
            _orderType = orderType;
            _purchaseOrderId = purchaseOrderId;

            PopulateData();
        }

        private void PopulateData(OrderModel model = null)
        {
            if (model == null)
                model = _orderService.GetOrder(_orderType, _purchaseOrderId);

            _purchaseOrderId = model == null ? 0 : model.Id;
            _purchaseOrderModel = model;
            if (model != null)
            {

                // populate
                lblExpectedDate.Text = model.ExpectedDate.ToShortDateString();
                lblLotNumber.Text = model.LotNumber.ToString();
                lblName.Text = model.Name;
                // lblOrderDate.Text = po.OrderDate.HasValue? po.OrderDate.Value.ToShortDateString(): " - ";
                lblOrderNumber.Text = model.ReferenceNumber;
                lblSupplier.Text = model.Supplier;
                lblSupplierInvoice.Text = model.SupplierInvoice;
                lblWarehouse.Text = model.Warehouse;
                lblNoItemsMessage.Visible = !model.OrderItems.Any();

                dgvItems.AutoGenerateColumns = false;
                dgvItems.DataSource = model.OrderItems;

                // logic to show buttons; the order must be maintained cause sent and received can be true at same time
                if (model.IsCancelled)
                {
                    DesignForCancelled();
                }
                else if (model.IsExecuted)
                {
                    DesignForReceived();
                }
                else if (model.IsVerified)
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
            btnEditItems.Visible = true;
            btnReceive.Enabled = false;
            btnReceive.Visible = false;
            btnSendOrder.Enabled = true;
            btnSendOrder.Visible = true;
            lblStatus.Text = "( Open )";
            pnlButtonsHeader.Visible = true;
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
            pnlButtonsHeader.Visible = false;
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
            pnlButtonsHeader.Visible = true;
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
            pnlButtonsHeader.Visible = false;
        }

        #endregion


        #region Actions Event Handlers

        private void btnEditDetails_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var po = Program.container.GetInstance<OrderCreateForm>();
                po.SetDataForEdit(_orderType, _purchaseOrderId);
                po.ShowDialog();
            }
        }

        private void btnEditItems_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var itemCreateForm = Program.container.GetInstance<PurchaseOrderItemCreateForm>();
                itemCreateForm.SetData(_orderType, _purchaseOrderModel.Id);
                itemCreateForm.ShowDialog();
            }
        }

        private void btnSendOrder_Click(object sender, EventArgs e)
        {
            if (!_purchaseOrderModel.OrderItems.Any())
            {
                MessageBox.Show("There aren't any items. Please add items to the order.", "No items!");
                return;
            }
            var dialogResult = MessageBox.Show(this, "Are you sure to send it to the Supplier? " +
                "You won't be able to edit the order after it's sent.", "Send?", MessageBoxButtons.YesNo);
            if (dialogResult.Equals(DialogResult.Yes))
            {
                var msg = _orderService.SetSent(_purchaseOrderId);
                if (string.IsNullOrEmpty(msg))
                    PopupMessage.ShowSuccessMessage("Successfully Sent!");
                else
                    PopupMessage.ShowErrorMessage(msg);
                this.Focus();
            }
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var invReceiveForm = Program.container.GetInstance<InventoryAdjustmentForm>();
                invReceiveForm.SetData(MovementTypeEnum.POReceive, _purchaseOrderId);
                invReceiveForm.ShowDialog();
            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(this, "Are you sure to cancel the order?", "Cancel?", MessageBoxButtons.YesNo);
            if (dialogResult.Equals(DialogResult.Yes))
            {
                var msg = _orderService.SetCancelled(_purchaseOrderId);
                if (string.IsNullOrEmpty(msg))
                    PopupMessage.ShowSuccessMessage("Successfully Cancelled!");
                else
                    PopupMessage.ShowErrorMessage(msg);
                this.Focus();
            }
        }

        #endregion


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