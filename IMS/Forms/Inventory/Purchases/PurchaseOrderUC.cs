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
using Service.DbEventArgs;
using IMS.Forms.Common.Links;

namespace IMS.Forms.Purchases
{
    public partial class PurchaseOrderUC : UserControl
    {
        private readonly IPurchaseService _purchaseService;
        private readonly IDatabaseChangeListener _listener;
        private readonly PurchaseOrderDetailUC _purchaseOrderDetailUC;
        private readonly PurchaseOrderListUC _purchaseOrderListUC;

        private LinkManager _linkManager;

        private List<int> _recentPurchaseOrderModelIds = new List<int>();

        public PurchaseOrderUC(IPurchaseService purchaseService, IDatabaseChangeListener listener,
            PurchaseOrderDetailUC purchaseOrderDetailUC,
            PurchaseOrderListUC purchaseOrderListUC)
        {

            _purchaseService = purchaseService;
            _listener = listener;
            _purchaseOrderDetailUC = purchaseOrderDetailUC;
            _purchaseOrderListUC = purchaseOrderListUC;

            InitializeComponent();

            this.Load += PurchaseListUC_Load;
        }

        private void PurchaseListUC_Load(object sender, EventArgs e)
        {
            _linkManager = new LinkManager(pnlOrderLinkLint, toolTip1);
            InitializeHeader();
            // InitializeGridView();
            // PopulatePurchases();
            InitializeEvents();
            InitializeLinkLabels();
            ShowData();

        }





        #region Initializing Functions

        private void InitializeHeader()
        {
            var _header = HeaderTemplate.Instance;
            //_header.btnNew.Visible = true;
            //_header.btnNew.Click += BtnNewOrder_Click;
            // add
            this.Controls.Add(_header);
            _header.SendToBack();
            // header text
            _header.lblHeading.Text = "Purchase Orders";
        }


        private void InitializeEvents()
        {
            //_listener.PurchaseOrderUpdated += _listener_PurchaseOrderUpdated;
            // dgvPurchases.CellMouseDoubleClick += DgvPurchases_CellMouseDoubleClick;
            _purchaseOrderDetailUC.btnBackToList.Click += BtnBackToList_Click;
            lnkPurchaseOrderList.Click += _linkManager.Link_Click;
            _linkManager.LinkClicked += _linkManager_LinkClicked;
            _purchaseOrderListUC.RowSelected += _purchaseOrderListUC_RowSelected;
            // btnNew.Click += BtnNewOrder_Click;
        }

        private void _linkManager_LinkClicked(object sender, IdEventArgs e)
        {
            ShowData(e.Id);
        }

        private void _purchaseOrderListUC_RowSelected(object sender, BaseEventArgs<PurchaseOrderModel> e)
        {
            if (e.Model != null)
            {
                _linkManager.AddLink(e.Model.Id, e.Model.OrderNumber, e.Model.Name);
                ShowData(e.Model.Id);
            }
        }

        private void InitializeLinkLabels()
        {
            lnkPurchaseOrderList.LinkVisited = true;
        }
        #endregion



        #region Show Functions

        /// <summary>
        /// Displays list and also Detail based on parameter
        /// </summary>
        /// <param name="purchaseOrderId">Don't assign this if list to display</param>
        private void ShowData(int purchaseOrderId = 0)
        {
            pnlDataBody.Controls.Clear();
            if (purchaseOrderId == 0)
            {
                pnlDataBody.Controls.Add(_purchaseOrderListUC);
                //this.Controls.Remove(_purchaseOrderDetailUC);
                //this.Controls.Add(pnlDataBody);
                //pnlDataBody.BringToFront();
                lblPurchaseOrderHeaderText.Text = "Purchase Orders";
            }
            else
            {
                _purchaseOrderDetailUC.SetData(purchaseOrderId);
                pnlDataBody.Controls.Add(_purchaseOrderDetailUC);
                //this.Controls.Remove(pnlDataBody);
                // _purchaseOrderDetailUC.BringToFront();
                lblPurchaseOrderHeaderText.Text = "Purchase Order Detail";
            }
            SetLinkVisited(purchaseOrderId);
        }

       



        private void SetLinkVisited(int purchaseOrderId)
        {
            foreach (LinkLabel link in pnlOrderLinkLint.Controls)
            {
                link.LinkVisited = false;
            }
            if (purchaseOrderId > 0)
            {
                lnkPurchaseOrderList.LinkVisited = false;
                var index = _recentPurchaseOrderModelIds.IndexOf(purchaseOrderId);
                if (index >= 0)
                {
                    (pnlOrderLinkLint.Controls[index] as LinkLabel).LinkVisited = true;
                }
            }
            else
            {
                lnkPurchaseOrderList.LinkVisited = true;
            }

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
