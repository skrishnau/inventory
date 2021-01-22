using System;
using System.Windows.Forms;
using Service.Listeners;
using ViewModel.Core.Orders;
using Service.DbEventArgs;
using SimpleInjector.Lifestyles;
using Service.Core.Orders;
using IMS.Forms.Inventory.Orders;
using ViewModel.Enums;
using System.Collections.Generic;

namespace IMS.Forms.Inventory.Purchases
{
    public partial class OrderListUC : UserControl
    {
        public event EventHandler<BaseEventArgs<OrderModel>> RowSelected;

        private readonly OrderTypeEnum _orderType;
        private readonly IOrderService _orderService;
        private readonly IDatabaseChangeListener _listener;

        public OrderListUC(IOrderService orderService, IDatabaseChangeListener listener, OrderTypeEnum orderType)
        {
            _orderType = orderType; //OrderTypeEnum.Sale;//
            _orderService = orderService;
            _listener = listener;

            InitializeComponent();
            this.Load += OrderListUC_Load;

        }

        private void OrderListUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            InitializeGridView();
            InitializeEvents();

            PopulateOrders();
        }

        private void InitializeGridView()
        {
            dgvPurchases.AutoGenerateColumns = false;
            switch (_orderType)
            {
                case OrderTypeEnum.Purchase:
                    this.colSupplier.Visible = true; 
                    this.colCustomer.Visible = false;
                    this.colWarehouse.Visible = true;
                    this.colToWarehouse.Visible = false;
                    break;
                case OrderTypeEnum.Sale:
                    this.colSupplier.Visible = false;
                    this.colCustomer.Visible = true;
                    this.colWarehouse.Visible = false;
                    this.colToWarehouse.Visible = false;
                    break;
                case OrderTypeEnum.Move:
                    this.colSupplier.Visible = false;
                    this.colCustomer.Visible = false;
                    this.colWarehouse.Visible = true;
                    this.colWarehouse.HeaderText = "From Warehouse";
                    this.colToWarehouse.Visible = true;
                    break;
            }

        }

        private void InitializeEvents()
        {
            _listener.OrderUpdated += _listener_PurchaseOrderUpdated;
            dgvPurchases.CellMouseDoubleClick += DgvPurchases_CellMouseDoubleClick;
            dgvPurchases.CellClick += DgvPurchases_CellClick;
            //_purchaseOrderDetailUC.btnBackToList.Click += BtnBackToList_Click;
            //lnkPurchaseOrderList.Click += Link_Click;
            btnNew.Click += BtnNewOrder_Click;
        }

        private void PopulateOrders()
        {
            var orderListModel = _orderService.GetAllOrders(_orderType, string.Empty, string.Empty, -1, -1);
            dgvPurchases.DataSource = orderListModel.OrderList;
        }

        #region Event Handlers

        private void _listener_PurchaseOrderUpdated(object sender, Service.DbEventArgs.BaseEventArgs<OrderModel> e)
        {
            PopulateOrders();
        }

        private void DgvPurchases_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colViewDetail.Index)
            {
                var model = dgvPurchases.Rows[e.RowIndex].DataBoundItem as OrderModel;
                ShowDetail(sender, model);
            }
        }

        private void DgvPurchases_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var model = dgvPurchases.Rows[e.RowIndex].DataBoundItem as OrderModel;
            ShowDetail(sender, model);
        }

        private void ShowDetail(object sender, OrderModel model)
        {
            if (model != null)
            {
                var eventArgs = new BaseEventArgs<OrderModel>(model, Service.Utility.UpdateMode.NONE);
                RowSelected?.Invoke(sender, eventArgs);
            }
        }

        private void BtnNewOrder_Click(object sender, EventArgs e)
        {
            ShowAddEditDialog(false);
        }

        #endregion


        private void ShowAddEditDialog(bool isEditMode)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var orderForm = Program.container.GetInstance<OrderCreateForm>();
                orderForm.SetDataForEdit(_orderType, 0);// isEditMode ? null : (OrderModel)null);
                orderForm.ShowDialog();
            }
        }


    }
}
