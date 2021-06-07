using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Core.Orders;
using Service.Listeners;
using ViewModel.Enums;
using Service.DbEventArgs;
using ViewModel.Core.Orders;
using SimpleInjector.Lifestyles;
using Service.Core.Inventory;
using IMS.Forms.Inventory.Payment;
using Service.Interfaces;
using IMS.Forms.Common.Pagination;
using Service.Core.Users;
using IMS.Forms.Common;

namespace IMS.Forms.Inventory.Transaction
{
    public partial class TransactionListUC : BaseUserControl
    {
        public event EventHandler<BaseEventArgs<OrderModel>> RowSelected;

        private OrderTypeEnum _orderType;
        private readonly IOrderService _orderService;
        private readonly IDatabaseChangeListener _listener;
        private readonly IInventoryService _inventoryService;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IUomService _uomService;

        int _previousSelectedIndex = -1;
        BindingSource _bindingSource = new BindingSource();
        private TransactionListPaginationHelper helper;

        OrderListTypeEnum _orderListTypeEnum;

        public TransactionListUC(IOrderService orderService, IInventoryService inventoryService, IUserService userService, IProductService productService, IDatabaseChangeListener listener, OrderTypeEnum orderType, OrderListTypeEnum orderListTypeEnum, IUomService uomService)
        {
            _orderService = orderService;
            _inventoryService = inventoryService;
            _productService = productService;
            _orderType = orderType; //OrderTypeEnum.Sale;//
            _listener = listener;
            _userService = userService;
            _orderListTypeEnum = orderListTypeEnum;
            _uomService = uomService;
            InitializeComponent();
            this.Load += OrderListUC_Load;
        }

        private void OrderListUC_Load(object sender, EventArgs e)
        {
            dgvItems.InitializeGridViewControls(_inventoryService, _productService, _uomService);
            dgvItems.DesignForTransactionItemListing(false);

            this.Dock = DockStyle.Fill;
            InitializeGridView();
            InitializeEvents();
            PopulateOrders();

            btnPrint.Image = null;

            InitializeSearchTextBox();

            if (_orderListTypeEnum == OrderListTypeEnum.Order)
            {
                colOrderNumber.Visible = false;
                colOrderNumber.Width = 0;
                listHeaderTemplate1.Text = "Orders";
                colCompletedDate.Visible = false;
                colCompletedDate.Width = 0;
            }
            else
            {
                listHeaderTemplate1.Text = "Transactions";
                colCreatedDate.Visible = false;
                colCreatedDate.Width = 0;
            }

        }
        private void InitializeSearchTextBox()
        {
            var users = _userService.GetUserListWithCompanyForCombo(UserTypeEnum.All, new int[0]);
            txtSearchClient.AutoCompleteCustomSource.AddRange(users.Select(x => x.Name).ToArray());
            txtSearchClient.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSearchClient.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void InitializeGridView()
        {
            dgvOrders.AutoGenerateColumns = false;
            //switch (_orderType)
            //{
            //    case OrderTypeEnum.Purchase:
            //        break;
            //    case OrderTypeEnum.Sale:
            //        break;
            //    case OrderTypeEnum.Move:
            //        break;
            //}


            //dgvOrders.DataSource = _bindingSource;
            helper = new TransactionListPaginationHelper(_bindingSource, dgvOrders, bindingNavigator1, _orderService, _orderType, _orderListTypeEnum);
        }

        private void InitializeEvents()
        {
            _listener.OrderUpdated += _listener_OrderUpdated;
            // dgvOrders.CellClick += DgvPurchases_CellClick;
            dgvOrders.SelectionChanged += DgvOrders_SelectionChanged;
            //_purchaseOrderDetailUC.btnBackToList.Click += BtnBackToList_Click;
            //lnkPurchaseOrderList.Click += Link_Click;
            //btnNew.Click += BtnNewOrder_Click;
            btnSaleTransaction.Click += BtnSaleTransaction_Click;
            btnPurchaseTransaction.Click += BtnPurchaseTransaction_Click;
            rbAll.CheckedChanged += Type_CheckedChanged;
            rbPurchase.CheckedChanged += Type_CheckedChanged;
            rbSale.CheckedChanged += Type_CheckedChanged;
            // btnPayment.Click += btnPayment_Click;
            btnPrint.Click += BtnPrint_Click;
            btnEdit.Click += BtnEdit_Click;
            btnCancel.Click += BtnCancel_Click;
            dgvOrders.DataBindingComplete += DgvOrders_DataBindingComplete;
            txtSearchClient.TextChanged += TxtName_TextChanged;
            txtSearchReceiptNo.TextChanged += TxtSearchReceiptNo_TextChanged;
            btnViewParentOrder.Click += BtnViewParentOrder_Click;
        }


        private void Type_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAll.Checked)
            {
                _orderType = OrderTypeEnum.All;
                lblSearchClient.Text = "Search Client";
            }
            else if (rbSale.Checked)
            {
                _orderType = OrderTypeEnum.Sale;
                lblSearchClient.Text = "Search Customer";
            }
            else if (rbPurchase.Checked)
            {
                _orderType = OrderTypeEnum.Purchase;
                lblSearchClient.Text = "Search Supplier";
            }
            PopulateOrders();
        }

        private void PopulateOrders()
        {
            //List<OrderModel> _orderList = new List<OrderModel>();
            //_orderList = _orderService.GetAllOrders(_orderType);
            //_bindingSource.DataSource = _orderList;
            //bindingNavigator1.BindingSource = _bindingSource;

            if (helper != null)
                helper.Reset(_orderType, _orderListTypeEnum, txtSearchClient.Text, txtSearchReceiptNo.Text);

            if (_previousSelectedIndex > -1 && dgvOrders.Rows.Count > _previousSelectedIndex)
            {
                dgvOrders.Rows[_previousSelectedIndex].Selected = true;
            }

            if (dgvOrders.SelectedRows.Count > 0)
            {
                var model = dgvOrders.Rows[dgvOrders.SelectedRows[0].Index].DataBoundItem as OrderModel;
                ShowDetail(this, model);
            }


        }

        #region Event Handlers

        private void BtnViewParentOrder_Click(object sender, EventArgs e)
        {
            var order = GetRowDataAndStoreSelectedIndex();
            if (order != null && order.ParentOrderId > 0)
            {
                var parentOrder = _orderService.GetOrder((OrderTypeEnum)Enum.Parse(typeof(OrderTypeEnum), order.OrderType), order.ParentOrderId ?? 0);
                if (parentOrder != null)
                {
                    dgvOrders.DataSource = null;
                    dgvOrders.DataSource = new List<OrderModel> { parentOrder };
                }
            }
        }


        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            _previousSelectedIndex = -1;
            PopulateOrders();
        }

        private void TxtSearchReceiptNo_TextChanged(object sender, EventArgs e)
        {
            _previousSelectedIndex = -1;
            PopulateOrders();
        }


        private void _listener_OrderUpdated(object sender, Service.DbEventArgs.BaseEventArgs<OrderModel> e)
        {
            //PopulateOrders();
            AddListenerAction(PopulateOrders, e);
        }


        private void DgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            var model = GetRowDataAndStoreSelectedIndex();
            // var model = dgvOrders.Rows[e.RowIndex].DataBoundItem as OrderModel;
            ShowDetail(sender, model);
        }

        //private void DgvPurchases_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {

        //    }
        //}

        private void DgvOrders_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var selectedIndex = dgvItems.SelectedRows.Count > 0 ? dgvItems.SelectedRows[0].Index : -1;
            if (selectedIndex > -1)
            {
                if (dgvOrders.Rows.Count > selectedIndex)
                    dgvOrders.Rows[selectedIndex].Selected = true;
            }
            PaginationHelper.SetRowNumber(dgvOrders, helper.offset);
        }

        private void ShowDetail(object sender, OrderModel model)
        {
            if (model != null)
            {
                btnEdit.Visible = !model.IsVoid && !model.IsCancelled; //!model.IsCompleted &&
                btnEdit.Text = (model.IsVerified && !model.IsCompleted) ? "Update Rates" : "Edit";
                btnPrint.Visible = model.IsCompleted; //model.OrderType == OrderTypeEnum.Sale.ToString() && 
                btnCancel.Visible = (!model.IsVoid && !model.IsCancelled) && (!(!model.IsCompleted && model.IsVerified)); //!model.IsCompleted && 
                // btnPayment.Visible =  model.IsCompleted && model.DueAmount > 0;
                //var eventArgs = new BaseEventArgs<OrderModel>(model, Service.Utility.UpdateMode.NONE);
                //RowSelected?.Invoke(sender, eventArgs);
                dgvItems.DataSource = _orderService.GetPurchaseOrderItems(model.Id);
                lblReferenceNo.Text = model.ReferenceNumber + "  (" + model.Status + ")";
                lblCustomer.Text = model.User;
                pnlEditedOrder.Visible = model.ParentOrderId > 0;
            }
            else
            {
                // btnPayment.Visible = false;
                btnPrint.Visible = false;
                btnEdit.Visible = false;
                btnCancel.Visible = false;
            }
        }

        //private void BtnNewOrder_Click(object sender, EventArgs e)
        //{
        //    ShowAddEditDialog(_orderType, 0);
        //}

        private void BtnSaleTransaction_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var form = Program.container.GetInstance<Transaction.TransactionCreateForm>();
                var orderEditModel = new OrderEditModel
                {
                    OrderType = OrderTypeEnum.Sale,
                    OrderId = 0,
                    OrderOrDirect = OrderOrDirectEnum.Order
                };
                form.SetDataForEdit(orderEditModel); //OrderTypeEnum.Sale, 0
                form.ShowDialog();
            }
        }

        private void BtnPurchaseTransaction_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var form = Program.container.GetInstance<Transaction.TransactionCreateForm>();
                var orderEditModel = new OrderEditModel
                {
                    OrderType = OrderTypeEnum.Purchase,
                    OrderId = 0,
                    OrderOrDirect = OrderOrDirectEnum.Order
                };
                form.SetDataForEdit(orderEditModel);//OrderTypeEnum.Purchase, 0
                form.ShowDialog();
            }
        }


        #endregion

        //private void btnPayment_Click(object sender, EventArgs e)
        //{
        //    using (AsyncScopedLifestyle.BeginScope(Program.container))
        //    {
        //        var orderModel = dgvOrders.SelectedRows.Count > 0 ? dgvOrders.SelectedRows[0].DataBoundItem as OrderModel : null;
        //        if (orderModel != null)
        //        {
        //            var po = Program.container.GetInstance<PaymentCreateForm>();
        //            po.SetData(orderModel, null);
        //            po.ShowDialog();
        //        }
        //    }
        //}

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var orderModel = dgvOrders.SelectedRows.Count > 0 ? dgvOrders.SelectedRows[0].DataBoundItem as OrderModel : null;
                if (orderModel != null)
                {
                    var po = Program.container.GetInstance<TransactionCreateForm>();
                    var orderEditModel = new OrderEditModel
                    {
                        OrderType = (OrderTypeEnum)Enum.Parse(typeof(OrderTypeEnum), orderModel.OrderType),
                        OrderId = orderModel.Id,
                        ShowPrintView = true
                    };
                    po.SetDataForEdit(orderEditModel);//(OrderTypeEnum)Enum.Parse(typeof(OrderTypeEnum), orderModel.OrderType), orderModel.Id, true
                    po.ShowDialog();
                }
            }
        }

        private OrderModel GetRowDataAndStoreSelectedIndex()
        {
            OrderModel order = null;
            if (dgvOrders.SelectedRows.Count > 0)
            {
                order = dgvOrders.SelectedRows[0].DataBoundItem as OrderModel;
                _previousSelectedIndex = dgvOrders.SelectedRows[0].Index;
            }
            else
            {
                _previousSelectedIndex = -1;
            }

            return order;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            var order = GetRowDataAndStoreSelectedIndex();
            if (order != null)
            {
                //if(order.OrderType == OrderTypeEnum.Purchase.ToString() && order.IsVerified && !order.IsCompleted)
                //{
                //    // zero rate edit case
                //    var dialogResult = MessageBox.Show(this, "This transaction has items with zero rate. Updating the rates will " +
                //       "update it's related ledger and also updates cost prices in all of the corresponding sale transactions and their ledger too. " +
                //       "Are you sure to edit?",
                //       "Are you sure to edit ?", MessageBoxButtons.YesNo);
                //    if (dialogResult == DialogResult.Yes)
                //    {
                //        ShowAddEditDialog((OrderTypeEnum)Enum.Parse(typeof(OrderTypeEnum), order.OrderType), order?.Id ?? 0);
                //    }
                //}
                //else 
                if (order.IsCompleted)
                {
                    //MessageBox.Show("Currently, editing of completed transaction is not available. Please contact administrator.");
                    //return;
                    var dialogResult = MessageBox.Show(this, "This transaction is complete. " +
                        "By editing a completed transaction makes it void (cancelled) and a new transaction will be created. "+
                        "Are you sure to edit ?"+
                        "\n\nWarning: If you click \"Yes\", this transaction will be cancelled now and a copy will be saved automatically." ,
                        "Are you sure to edit ?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        _orderService.SetCancelled(order.Id);
                        //var savedOrder = _orderService.SaveOrder(order, false);

                        ShowAddEditDialog((OrderTypeEnum)Enum.Parse(typeof(OrderTypeEnum), order.OrderType), order.Id, true);
                        //var newOrderId = 0;
                        //ShowAddEditDialog((OrderTypeEnum)Enum.Parse(typeof(OrderTypeEnum), order.OrderType), newOrderId);
                    }
                }
                else
                {
                    ShowAddEditDialog((OrderTypeEnum)Enum.Parse(typeof(OrderTypeEnum), order.OrderType), order?.Id ?? 0);
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            var order = GetRowDataAndStoreSelectedIndex();
            if (order != null)
            {
                var dialog = MessageBox.Show(this, "Are you sure to cancel the order?", "Cancel?", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    var msg = _orderService.SetCancelled(order.Id);
                    if (string.IsNullOrEmpty(msg))
                    {
                        PopupMessage.ShowSuccessMessage("Successfully cancelled!");
                    }
                    else
                    {
                        PopupMessage.ShowInfoMessage(msg);
                    }
                    this.Focus();
                }
            }
        }


        // saveOrderImmediatelyAfterLoading: saves the order after loading the ui without giving user to enter anything
        private void ShowAddEditDialog(OrderTypeEnum orderType, int orderId = 0, bool saveOrderImmediatelyAfterLoading = false)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                _previousSelectedIndex = dgvOrders.SelectedRows.Count > 0 ? dgvOrders.SelectedRows[0].Index : -1;
                var orderForm = Program.container.GetInstance<TransactionCreateForm>();
                var orderEditModel = new OrderEditModel
                {
                    OrderType = orderType,
                    OrderId = orderId
                };
                orderForm.SetDataForEdit(orderEditModel, saveOrderImmediatelyAfterLoading);//orderType, orderId
                orderForm.SavedOrderImmediatelyAfterLoading += OrderForm_SavedOrderImmediatelyAfterLoading;
                orderForm.ShowDialog(this);
            }
        }

        // Note : this function is called after the crate form saves order immedialy after loading it.
        //          This occurs in case of editing completed transaaction.
        private void OrderForm_SavedOrderImmediatelyAfterLoading(object sender, BaseEventArgs<OrderModel> e)
        {
            ShowAddEditDialog((OrderTypeEnum)Enum.Parse(typeof(OrderTypeEnum), e.Model.OrderType), e.Model.Id);
        }
    }
}
