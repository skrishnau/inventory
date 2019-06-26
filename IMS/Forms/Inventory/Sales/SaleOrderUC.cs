using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Core.Orders;
using IMS.Forms.Common.Display;
using SimpleInjector.Lifestyles;
using Service.Listeners;
using IMS.Forms.Inventory.Purchases;
using Service.DbEventArgs;
using IMS.Forms.Common.Links;
using Service.Core.Orders;
using IMS.Forms.Inventory.Orders;

namespace IMS.Forms.Inventory.Sales
{
    public partial class SaleOrderUC : UserControl
    {
        private readonly IOrderService _orderService;
        private readonly IDatabaseChangeListener _listener;

        private LinkManager _linkManager;

        private List<int> _recentPurchaseOrderModelIds = new List<int>();

        private readonly SaleOrderDetailUC _saleOrderDetailUC;
        private readonly SaleOrderListUC _saleOrderListUC;

        public SaleOrderUC(IOrderService purchaseService, IDatabaseChangeListener listener,
            SaleOrderDetailUC saleOrderDetailUC,
            SaleOrderListUC saleOrderListUC
            )
        {
            _orderService = purchaseService;
            _listener = listener;
            _saleOrderDetailUC = saleOrderDetailUC;
            _saleOrderListUC = saleOrderListUC;

            InitializeComponent();
            this.Dock = DockStyle.Fill;


            this.Load += PurchaseListUC_Load;
        }

        private void PurchaseListUC_Load(object sender, EventArgs e)
        {

            //InitializeBody();

            //InitializeEvents();
            //InitializeLinkLabels();
            // ShowData(_sidebar.lnkList);

        }





        /*

               #region Initializing Functions

               private void InitializeBody()
               {
                  _sidebar = new OrderSidebarUC();
                   _body.pnlSideBar.Controls.Add(_sidebar);
                   _body.HeadingText = "Sale Orders";
                   _body.SubHeadingText = "";
                   _linkManager = new LinkManager(_sidebar.pnlLinkList, _body.toolTip1);
               }


               private void InitializeEvents()
               {
                   //_listener.PurchaseOrderUpdated += _listener_PurchaseOrderUpdated;
                   // dgvPurchases.CellMouseDoubleClick += DgvPurchases_CellMouseDoubleClick;
                   _saleOrderDetailUC.btnBackToList.Click += BtnBackToList_Click;
                   _sidebar.lnkList.Click += _linkManager.Link_Click;
                   _linkManager.LinkClicked += _linkManager_LinkClicked;
                   _saleOrderListUC.RowSelected += _purchaseOrderListUC_RowSelected;
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
                       _linkManager.AddAndGetLink(e.Model.Id, e.Model.ReferenceNumber, e.Model.Name);
                       ShowData(e.Model.Id);
                   }
               }

               private void InitializeLinkLabels()
               {
                   _sidebar.lnkList.LinkVisited = true;
               }
               #endregion



               #region Show Functions

               /// <summary>
               /// Displays list and also Detail based on parameter
               /// </summary>
               /// <param name="saleOrderId">Don't assign this if list to display</param>
               private void ShowData(object sender, int saleOrderId = 0)
               {
                   _body.pnlBody.Controls.Clear();
                   if (saleOrderId == 0)
                   {
                       _body.pnlBody.Controls.Add(_saleOrderListUC);
                       //this.Controls.Remove(_purchaseOrderDetailUC);
                       //this.Controls.Add(pnlDataBody);
                       //pnlDataBody.BringToFront();
                       _body.SubHeadingText = "Sale Orders";
                   }
                   else
                   {
                       _saleOrderDetailUC.SetData(saleOrderId);
                       _body.pnlBody.Controls.Add(_saleOrderDetailUC);
                       //this.Controls.Remove(pnlDataBody);
                       // _purchaseOrderDetailUC.BringToFront();
                       _body.SubHeadingText = "Sale Order Detail";
                   }
                   _sidebar.SetVisited(sender);
               }







               #endregion



               #region Populating Functions



               #endregion



               #region Events





               private void BtnBackToList_Click(object sender, EventArgs e)
               {
                   ShowData(_sidebar.lnkList);
               }



               #endregion





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
               */
    }
}
