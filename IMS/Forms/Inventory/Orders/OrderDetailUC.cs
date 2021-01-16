using System;
using System.Linq;
using System.Windows.Forms;
using ViewModel.Core.Orders;
using Service.Core.Inventory;
using IMS.Forms.Common;
using SimpleInjector.Lifestyles;
using Service.Listeners;
using IMS.Forms.Inventory.Units.Actions;
using Service.Core.Orders;
using IMS.Forms.Inventory.Orders;
using ViewModel.Enums;
using Service.Utility;
using ViewModel.Utility;
using IMS.Forms.Inventory.Payment;

namespace IMS.Forms.Inventory.Purchases
{
    public partial class OrderDetailUC : UserControl
    {
        private readonly IOrderService _orderService;
        private readonly IInventoryService _inventoryService;
        private readonly IDatabaseChangeListener _listener;

        //private PurchaseOrderModel _purchaseOrderModel;
        private int _orderId;
        private OrderModel _orderModel;
        private OrderTypeEnum _orderType;

        public OrderDetailUC(IOrderService orderService, IDatabaseChangeListener listener, IInventoryService inventoryService)
        {
            _orderService = orderService;
            _inventoryService = inventoryService;
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
            _listener.OrderUpdated += _listener_PurchaseOrderUpdated;
        }

        #endregion



        #region Event Handlers

        private void _listener_PurchaseOrderUpdated(object sender, Service.DbEventArgs.BaseEventArgs<OrderModel> e)
        {
            if (e.Model.Id == _orderId)
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
                    tblSupplier.Visible = true;
                    tblCustomer.Visible = false;
                    break;
                case OrderTypeEnum.Sale:
                    tblSupplier.Visible = false;
                    tblCustomer.Visible = true;
                    btnReceive.Text = "Issue";
                    btnSendOrder.Text = "Confirm Package";
                    break;
            }
        }

        public void SetData(OrderTypeEnum orderType, int orderId)
        {
            _orderType = orderType;
            _orderId = orderId;

            PopulateData();
        }

        private void PopulateData(OrderModel model = null)
        {
            if (model == null)
                model = _orderService.GetOrderForDetailView( _orderId); //_orderType,
            else
            {
                if(model.OrderItems == null || !model.OrderItems.Any())
                {
                    model.OrderItems = _orderService.GetPurchaseOrderItems(model.Id);
                }
            }
            _orderId = model == null ? 0 : model.Id;
            _orderModel = model;
            if (model != null)
            {
                
                // populate
                lblName.Text = model.Name;
                lblExpectedDate.Text = model.DeliveryDate.ToShortDateString();
                lblLotNumber.Text = model.LotNumber.ToString();
                lblOrderNumber.Text = model.Name;
                // lblOrderDate.Text = po.OrderDate.HasValue? po.OrderDate.Value.ToShortDateString(): " - ";
                lblOrderNumber.Text = model.ReferenceNumber;
                lblOrderNumber1.Text = model.ReferenceNumber;
                lblSupplier.Text = model.User;
                lblCustomer.Text = model.User;

                lblSupplierInvoice.Text = model.SupplierInvoice;
                lblWarehouse.Text = model.Warehouse;

                lblWarehouseLabel.Text = model.ToWarehouse;
                lblToWarehouse.Text = model.ToWarehouse;
                lblToWarehouseLabel.Visible = !string.IsNullOrEmpty(model.ToWarehouse);
                lblWarehouseLabel.Text = string.IsNullOrEmpty(model.ToWarehouse)? "Warehouse": "From Warehouse";
                
                lblAddress.Text = model.Address;
                lblPhone.Text = model.Phone;
                lblNoItemsMessage.Visible = !model.OrderItems.Any();

                lblPaymentDueDate.Text = DateHelper.ToFormattedDateString(model.PaymentDueDate);
                lblTotalAmount.Text = model.TotalAmount.ToString();
                lblRemainingAmount.Text = model.DueAmount == 0 ? "All Paid" : model.DueAmount.ToString();
                btnPayment.Visible = model.DueAmount > 0;

                dgvItems.AutoGenerateColumns = false;
                dgvItems.DataSource = model.OrderItems;

                // logic to show buttons; the order must be maintained cause sent and received can be true at same time
                if (model.IsCancelled)
                {
                    DesignForCancelled();
                }
                else if (model.IsCompleted)
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

                switch (_orderType)
                {
                    case OrderTypeEnum.Move:
                        colInStock.Visible = false;
                        colOnOrder.Visible = false;
                        break;
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
            lblStatus.Text = _orderType == OrderTypeEnum.Sale? "( Packaged )" : "( Sent )";
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
            var executedText = _orderType == OrderTypeEnum.Purchase ? "( Received )"
                : _orderType == OrderTypeEnum.Sale ? "( Issued )"
                : "( Moved )";
            lblStatus.Text = executedText;
            pnlButtonsHeader.Visible = false;
        }

        #endregion


        #region Actions Event Handlers

        private void btnPayment_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var po = Program.container.GetInstance<PaymentCreateForm>();
                po.SetData(_orderModel, null);
                po.ShowDialog();
            }
        }

        private void btnEditDetails_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var po = Program.container.GetInstance<OrderCreateForm>();
                po.SetDataForEdit(_orderType, _orderId);
                po.ShowDialog();
            }
        }

        private void btnEditItems_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                //var itemCreateForm = Program.container.GetInstance<PurchaseOrderItemCreateForm>();
                //itemCreateForm.SetData(_orderType, _orderModel.Id);
                //itemCreateForm.ShowDialog();
                var invAdjForm = Program.container.GetInstance<InventoryAdjustmentForm>();
                var movementType = _orderType == OrderTypeEnum.Purchase
                    ? MovementTypeEnum.POReceiveEditItems
                    : _orderType == OrderTypeEnum.Sale
                    ? MovementTypeEnum.SOIssueEditItems
                    : MovementTypeEnum.TOMove;
                invAdjForm.SetData(movementType, _orderId);
                invAdjForm.ShowDialog();
            }
        }

        private void btnSendOrder_Click(object sender, EventArgs e)
        {
            if (!_orderModel.OrderItems.Any())
            {
                MessageBox.Show("There aren't any items. Please add items to the order.", "No items!");
                return;
            }
            var question = "";
            var buttonText = "Send?";
            var successMsg = "Successfully Sent!";
            switch (_orderType)
            {
                case OrderTypeEnum.Purchase:
                    question = "Are you sure to send the order to the Supplier? " + "You won't be able to edit the order after it's sent.";
                    break;
                case OrderTypeEnum.Sale:
                    if(_orderModel.WarehouseId == null)
                    {
                        MessageBox.Show(this, "You haven't entered warehouse from which the sales request is fulfilled. Edit the order and try again.");
                        return;
                    }
                    var isValid = true;
                    // check if the items are available in the given warehouse
                    for(var i=0; i< _orderModel.OrderItems.Count; i++)
                    {
                        var item = _orderModel.OrderItems.ElementAt(i);
                        var wp = _inventoryService.GetWarehouseProductList(_orderModel.WarehouseId??0, item.ProductId).FirstOrDefault();
                        var inStock = (wp?.InStockQuantity)??0;
                        if(item.UnitQuantity > inStock)
                        {
                            dgvItems.Rows[i].ErrorText = "Greater than in-stock quantity";//.Cells[colQuantity.Name].ErrorText = ""
                            isValid = false;
                        }
                    }
                    if (!isValid)
                    {
                        MessageBox.Show(this, "Some items are greater than in-stock quantity. Please verify!");
                        return;
                    }
                    question = "Are you sure to package the items? " + "You won't be able to edit the order once it's packaged.";
                    buttonText = "Package?";
                    successMsg = "Successfully Packaged!";
                    break;
                case OrderTypeEnum.Move:
                    question = "Are you sure to send the order to the warehouse? " + "You won't be able to edit the order once it's sent.";
                    break;
            }
            var dialogResult = MessageBox.Show(this, question, buttonText, MessageBoxButtons.YesNo);
            if (dialogResult.Equals(DialogResult.Yes))
            {
                var msg = _orderService.SetSent(_orderId);
                if (string.IsNullOrEmpty(msg))
                    PopupMessage.ShowSuccessMessage(successMsg);
                else
                    PopupMessage.ShowErrorMessage(msg);
                this.Focus();
            }
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var invAdjForm = Program.container.GetInstance<InventoryAdjustmentForm>();
                var movementType = _orderType == OrderTypeEnum.Purchase
                    ? MovementTypeEnum.POReceive
                    : _orderType == OrderTypeEnum.Sale
                    ? MovementTypeEnum.SOIssue
                    : MovementTypeEnum.TOMove;
                invAdjForm.SetData(movementType, _orderId);
                invAdjForm.ShowDialog();
            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(this, "Are you sure to cancel the order?", "Cancel?", MessageBoxButtons.YesNo);
            if (dialogResult.Equals(DialogResult.Yes))
            {
                var msg = _orderService.SetCancelled(_orderId);
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