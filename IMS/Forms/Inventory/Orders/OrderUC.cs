using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ViewModel.Core.Orders;
using Service.Listeners;
using IMS.Forms.Inventory.Purchases;
using Service.DbEventArgs;
using IMS.Forms.Common.Links;
using Service.Core.Orders;
using ViewModel.Enums;

namespace IMS.Forms.Inventory.Orders
{
    public partial class OrderUC : UserControl
    {
       // private readonly IOrderService _orderService;
        private readonly IDatabaseChangeListener _listener;
        private readonly OrderDetailUC _orderDetailUC;
        private readonly OrderListUC _orderListUC;
       // private OrderSidebarUC _sidebar;

      //  private LinkManager _linkManager;

        private List<int> _recentPurchaseOrderModelIds = new List<int>();
        private OrderTypeEnum _orderType;

        public OrderUC(IOrderService orderService,IDatabaseChangeListener listener, // 
             OrderTypeEnum orderType)
        {
            _orderType = orderType;
            //_orderService = orderService;
            _listener = listener;
            _orderDetailUC = new OrderDetailUC(orderService, listener);// orderDetailUC;
            _orderListUC = new OrderListUC(orderService, listener, orderType);

            InitializeComponent();
            this.Dock = DockStyle.Fill;

            this.Load += PurchaseListUC_Load;
        }

        private void PurchaseListUC_Load(object sender, EventArgs e)
        {
            InitializeBody();

           // _linkManager = new LinkManager(_sidebar.pnlLinkList, _body.toolTip1);

            InitializeEvents();
           // InitializeLinkLabels();
            ShowData();

        }

        private void InitializeBody()
        {
           // _sidebar = new OrderSidebarUC();
            switch (_orderType)
            {
                case OrderTypeEnum.Purchase:
                    _body.HeadingText = "Purchase Orders";
                   // _sidebar.lnkList.Text = "     • Purchase Order List";
                    break;
                case OrderTypeEnum.Sale:
                    _body.HeadingText = "Sale Orders";
                    //_sidebar.lnkList.Text = "     • Sale Order List";
                    break;
            }

            //_body.SubHeadingText = "";

            //_body.pnlSideBar.Controls.Add(_sidebar);

        }





        #region Initializing Functions

        private void InitializeEvents()
        {
            //_listener.PurchaseOrderUpdated += _listener_PurchaseOrderUpdated;
            // dgvPurchases.CellMouseDoubleClick += DgvPurchases_CellMouseDoubleClick;
            _orderDetailUC.btnBackToList.Click += BtnBackToList_Click;
            //_sidebar.lnkList.Click += _linkManager.Link_Click;
            //_linkManager.LinkClicked += _linkManager_LinkClicked;
            _orderListUC.RowSelected += _purchaseOrderListUC_RowSelected;
            // btnNew.Click += BtnNewOrder_Click;
        }

        private void _linkManager_LinkClicked(object sender, IdEventArgs e)
        {
            ShowData(e.Id);
        }

        private void _purchaseOrderListUC_RowSelected(object sender, BaseEventArgs<OrderModel> e)
        {
            if (e.Model != null)
            {
               // _linkManager.AddAndGetLink(e.Model.Id, e.Model.ReferenceNumber, e.Model.Name);
                ShowData(e.Model.Id);
            }
        }

        //private void InitializeLinkLabels()
        //{
        //    _sidebar.lnkList.LinkVisited = true;
        //}
        #endregion



        #region Show Functions

        /// <summary>
        /// Displays list and also Detail based on parameter
        /// </summary>
        /// <param name="orderId">Don't assign this if list to display</param>
        private void ShowData(int orderId = 0)
        {
            _body.pnlBody.Controls.Clear();
            //switch (_orderType)
            //{
            //    case OrderTypeEnum.Purchase:
            //        _body.SubHeadingText = orderId == 0 ? "Purchase Orders" : "Purchase Order Detail";
            //        break;
            //    case OrderTypeEnum.Sale:
            //        _body.SubHeadingText = orderId == 0 ? "Sale Orders" : "Sale Order Detail";
            //        break;
            //}

            if (orderId == 0)
            {
                _body.pnlBody.Controls.Add(_orderListUC);
            }
            else
            {
                switch (_orderType)
                {
                    case OrderTypeEnum.Purchase:
                        _orderDetailUC.SetData(_orderType, orderId);
                        _body.pnlBody.Controls.Add(_orderDetailUC);
                        break;
                    case OrderTypeEnum.Sale:
                        _orderDetailUC.SetData(_orderType, orderId);
                        _body.pnlBody.Controls.Add(_orderDetailUC);
                        break;
                }
            }
           // _sidebar.SetVisited(orderId);
        }


        #endregion



        #region Populating Functions



        #endregion



        #region Events





        private void BtnBackToList_Click(object sender, EventArgs e)
        {
            ShowData();
        }



        #endregion


        //private void SetLinkVisited(int purchaseOrderId)
        //{
        //    foreach (LinkLabel link in pnlOrderLinkLint.Controls)
        //    {
        //        link.LinkVisited = false;
        //    }
        //    if (purchaseOrderId > 0)
        //    {
        //        lnkPurchaseOrderList.LinkVisited = false;
        //        var index = _recentPurchaseOrderModelIds.IndexOf(purchaseOrderId);
        //        if (index >= 0)
        //        {
        //            (pnlOrderLinkLint.Controls[index] as LinkLabel).LinkVisited = true;
        //        }
        //    }
        //    else
        //    {
        //        lnkPurchaseOrderList.LinkVisited = true;
        //    }
        //}




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
