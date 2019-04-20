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

namespace IMS.Forms.Purchases
{
    public partial class PurchaseListUC : UserControl
    {
        private readonly IPurchaseService _purchaseService;
        private readonly IDatabaseChangeListener _listener;
        private readonly PurchaseOrderDetailUC _purchaseOrderDetailUC;

        private List<int> _recentPurchaseOrderModelIds = new List<int>();

        public PurchaseListUC(IPurchaseService purchaseService, IDatabaseChangeListener listener,
            PurchaseOrderDetailUC purchaseOrderDetailUC)
        {

            _purchaseService = purchaseService;
            _listener = listener;
            _purchaseOrderDetailUC = purchaseOrderDetailUC;

            InitializeComponent();

            this.Load += PurchaseListUC_Load;
        }

        private void PurchaseListUC_Load(object sender, EventArgs e)
        {
            InitializeHeader();
            InitializeGridView();
            PopulatePurchases();
            InitializeEvents();
            InitializeLinkLabels();
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

        private void InitializeGridView()
        {
            dgvPurchases.AutoGenerateColumns = false;
        }

        private void InitializeEvents()
        {
            _listener.PurchaseOrderUpdated += _listener_PurchaseOrderUpdated;
            dgvPurchases.CellMouseDoubleClick += DgvPurchases_CellMouseDoubleClick;
            _purchaseOrderDetailUC.btnBackToList.Click += BtnBackToList_Click;
            lnkPurchaseOrderList.Click += Link_Click;
            btnNew.Click += BtnNewOrder_Click;
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
            if (purchaseOrderId == 0)
            {
                this.Controls.Remove(_purchaseOrderDetailUC);
                this.Controls.Add(pnlDataBody);
                pnlDataBody.BringToFront();
                lblPurchaseOrderHeaderText.Text = "Purchase Orders";
            }
            else
            {
                _purchaseOrderDetailUC.Dock = DockStyle.Fill;
                _purchaseOrderDetailUC.SetData(purchaseOrderId);
                this.Controls.Remove(pnlDataBody);
                this.Controls.Add(_purchaseOrderDetailUC);
                _purchaseOrderDetailUC.BringToFront();
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

        private void ShowAddEditDialog(bool isEditMode)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var orderForm = Program.container.GetInstance<PurchaseOrderCreateForm>();
                orderForm.SetDataForEdit(isEditMode ? null : (PurchaseOrderModel)null);
                orderForm.ShowDialog();
            }
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

        private void PopulatePurchases()
        {
            var purchases = _purchaseService.GetAllPurchaseOrders();
            dgvPurchases.DataSource = purchases;
        }

        #endregion



        #region Events

        private void _listener_PurchaseOrderUpdated(object sender, Service.DbEventArgs.BaseEventArgs<PurchaseOrderModel> e)
        {
            PopulatePurchases();
        }

        private void BtnNewOrder_Click(object sender, EventArgs e)
        {
            ShowAddEditDialog(false);
        }

        private void DgvPurchases_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var model = dgvPurchases.Rows[e.RowIndex].DataBoundItem as PurchaseOrderModel;
            if (model != null)
            {
                AddLink(model);
                ShowData(model.Id);
            }
        }

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
