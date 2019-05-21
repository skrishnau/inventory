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

        public OrderListUC(IOrderService purchaseService, IDatabaseChangeListener listener, OrderTypeEnum orderType)
        {
            _orderType = orderType; //OrderTypeEnum.Sale;//
            _orderService = purchaseService;
            _listener = listener;

            InitializeComponent();
            this.Load += PurchaseOrderListUC_Load;

        }

        private void PurchaseOrderListUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            InitializeGridView();
            InitializeEvents();

            PopulateOrders();
        }

        private void InitializeGridView()
        {
            dgvPurchases.AutoGenerateColumns = false;
        }

        private void InitializeEvents()
        {
            _listener.PurchaseOrderUpdated += _listener_PurchaseOrderUpdated;
            dgvPurchases.CellMouseDoubleClick += DgvPurchases_CellMouseDoubleClick;
            //_purchaseOrderDetailUC.btnBackToList.Click += BtnBackToList_Click;
            //lnkPurchaseOrderList.Click += Link_Click;
            btnNew.Click += BtnNewOrder_Click;
        }

        private void PopulateOrders()
        {
            List<OrderModel> orders = new List<OrderModel>();
            orders = _orderService.GetAllOrders(_orderType);
            //switch (_orderType)
            //{
            //    case OrderTypeEnum.Purchase:
            //        break;
            //    case OrderTypeEnum.Sale:
            //        break;
            //}

            dgvPurchases.DataSource = orders;
        }

        #region Event Handlers

        private void _listener_PurchaseOrderUpdated(object sender, Service.DbEventArgs.BaseEventArgs<OrderModel> e)
        {
            PopulateOrders();
        }

        private void DgvPurchases_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var model = dgvPurchases.Rows[e.RowIndex].DataBoundItem as OrderModel;
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
