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

namespace IMS.Forms.Purchases
{
    public partial class PurchaseOrderUC : UserControl
    {
        private readonly IPurchaseService _purchaseService;
        private readonly IDatabaseChangeListener _listener;
        private readonly PurchaseOrderDetailUC _purchaseOrderDetailUC;
        private readonly PurchaseOrderListUC _purchaseOrderListUC;

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
            lnkPurchaseOrderList.Click += Link_Click;
            _purchaseOrderListUC.RowSelected += _purchaseOrderListUC_RowSelected;
            // btnNew.Click += BtnNewOrder_Click;
        }

        private void _purchaseOrderListUC_RowSelected(object sender, BaseEventArgs<PurchaseOrderModel> e)
        {
            if (e.Model != null)
            {
                AddLink(e.Model);
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

        private void AddLink(PurchaseOrderModel model)
        {
            LinkLabel link = null;
            var index = _recentPurchaseOrderModelIds.IndexOf(model.Id);
            if (index >= 0)
            {
                // exists
                link = pnlOrderLinkLint.Controls[index] as LinkLabel;

            }
            else
            {
                // doesn't exist
                link = new LinkLabel();
                link.AutoEllipsis = true;
                link.Text = "● " + model.OrderNumber;
                pnlOrderLinkLint.Controls.Add(link);
                link.Tag = model.Id;
                _recentPurchaseOrderModelIds.Add(model.Id);
                link.Click += Link_Click;
                link.LinkBehavior = LinkBehavior.HoverUnderline;
                link.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
                link.VisitedLinkColor = Color.Black;// System.Drawing.SystemColors.ControlText;
                toolTip1.SetToolTip(link, model.Name);
            }
            //if (link != null)
            //{
            //    link.BringToFront();
            //}
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

        private void Link_Click(object sender, EventArgs e)
        {
            var linkLabel = sender as LinkLabel;
            if (linkLabel != null)
            {
                // link's Tag has purchase Order Id 
                var id = int.Parse(linkLabel.Tag == null ? "0" : linkLabel.Tag.ToString());
                ShowData(id);
            }
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
