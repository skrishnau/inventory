﻿using System;
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

namespace IMS.Forms.Inventory.Transaction
{
    public partial class TransactionListUC : UserControl
    {
        public event EventHandler<BaseEventArgs<OrderModel>> RowSelected;

        private OrderTypeEnum _orderType;
        private readonly IOrderService _orderService;
        private readonly IDatabaseChangeListener _listener;
        private readonly IInventoryService _inventoryService;

        public TransactionListUC(IOrderService orderService, IInventoryService inventoryService, IDatabaseChangeListener listener, OrderTypeEnum orderType)
        {
            _orderService = orderService;
            _inventoryService = inventoryService;
            _orderType = orderType; //OrderTypeEnum.Sale;//
            _listener = listener;

            InitializeComponent();
            this.Load += OrderListUC_Load;
        }

        private void OrderListUC_Load(object sender, EventArgs e)
        {
            dgvItems.InitializeGridViewControls(_inventoryService);
            dgvItems.DesignForTransaction(false);

            this.Dock = DockStyle.Fill;
            InitializeGridView();
            InitializeEvents();
            PopulateOrders();

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

        }

        private void InitializeEvents()
        {
            _listener.OrderUpdated += _listener_PurchaseOrderUpdated;
            dgvOrders.CellClick += DgvPurchases_CellClick;
            //_purchaseOrderDetailUC.btnBackToList.Click += BtnBackToList_Click;
            //lnkPurchaseOrderList.Click += Link_Click;
            btnNew.Click += BtnNewOrder_Click;
            rbAll.CheckedChanged += Type_CheckedChanged;
            rbPurchase.CheckedChanged += Type_CheckedChanged;
            rbSale.CheckedChanged += Type_CheckedChanged;
            btnPayment.Click += btnPayment_Click;
        }

        private void Type_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAll.Checked)
            {
                _orderType = OrderTypeEnum.All;
            }
            else if (rbSale.Checked)
            {
                _orderType = OrderTypeEnum.Sale;
            }
            else if (rbPurchase.Checked)
            {
                _orderType = OrderTypeEnum.Purchase;
            }
            PopulateOrders();
        }

        private void PopulateOrders()
        {
            List<OrderModel> _orderList = new List<OrderModel>();
            _orderList = _orderService.GetAllOrders(_orderType);
            dgvOrders.DataSource = _orderList;
            if (dgvOrders.SelectedRows.Count > 0)
            {
                var model = dgvOrders.Rows[dgvOrders.SelectedRows[0].Index].DataBoundItem as OrderModel;
                ShowDetail(this, model);
            }
        }

        #region Event Handlers

        private void _listener_PurchaseOrderUpdated(object sender, Service.DbEventArgs.BaseEventArgs<OrderModel> e)
        {
            PopulateOrders();
        }

        private void DgvPurchases_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == colViewDetail.Index)
            // {
            var model = dgvOrders.Rows[e.RowIndex].DataBoundItem as OrderModel;
            ShowDetail(sender, model);
            //  }
        }

        private void ShowDetail(object sender, OrderModel model)
        {
            if (model != null)
            {
                btnPayment.Visible = model.RemainingAmount > 0;
                btnPayment.Tag = model;
                //var eventArgs = new BaseEventArgs<OrderModel>(model, Service.Utility.UpdateMode.NONE);
                //RowSelected?.Invoke(sender, eventArgs);
                dgvItems.DataSource = _orderService.GetPurchaseOrderItems(model.Id);
                lblReferenceNo.Text = model.ReferenceNumber;
            }
            else
            {
                btnPayment.Tag = null;
                btnPayment.Visible = false;
            }
        }

        private void BtnNewOrder_Click(object sender, EventArgs e)
        {
            ShowAddEditDialog(false);
        }

        #endregion

        private void btnPayment_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var orderModel = btnPayment.Tag as OrderModel;
                if (orderModel != null)
                {
                    var po = Program.container.GetInstance<PaymentCreateForm>();
                    po.SetData(orderModel, null);
                    po.ShowDialog();
                }
            }
        }


        private void ShowAddEditDialog(bool isEditMode)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var orderForm = Program.container.GetInstance<TransactionCreateForm>();
                orderForm.SetDataForEdit(_orderType, 0);// isEditMode ? null : (OrderModel)null);
                orderForm.ShowDialog();
            }
        }

    }
}