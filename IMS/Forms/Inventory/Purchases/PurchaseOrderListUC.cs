using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Listeners;
using Service.Core.Purchases.PurchaseOrders;
using ViewModel.Core.Purchases;
using Service.DbEventArgs;
using SimpleInjector.Lifestyles;
using IMS.Forms.Purchases;

namespace IMS.Forms.Inventory.Purchases
{
    public partial class PurchaseOrderListUC : UserControl
    {
        public event EventHandler<BaseEventArgs<PurchaseOrderModel>> RowSelected;

        private readonly IPurchaseService _purchaseService;
        private readonly IDatabaseChangeListener _listener;

        public PurchaseOrderListUC(IPurchaseService purchaseService, IDatabaseChangeListener listener)
        {
            _purchaseService = purchaseService;
            _listener = listener;

            InitializeComponent();
            this.Load += PurchaseOrderListUC_Load;

        }

        private void PurchaseOrderListUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            InitializeGridView();
            InitializeEvents();

            PopulatePurchases();
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

        private void PopulatePurchases()
        {
            var purchases = _purchaseService.GetAllPurchaseOrders();
            dgvPurchases.DataSource = purchases;
        }

        #region Event Handlers

        private void _listener_PurchaseOrderUpdated(object sender, Service.DbEventArgs.BaseEventArgs<PurchaseOrderModel> e)
        {
            PopulatePurchases();
        }

        private void DgvPurchases_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var model = dgvPurchases.Rows[e.RowIndex].DataBoundItem as PurchaseOrderModel;
            if (model != null)
            {
                var eventArgs = new BaseEventArgs<PurchaseOrderModel>(model, Service.Utility.UpdateMode.NONE);
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
                var orderForm = Program.container.GetInstance<PurchaseOrderCreateForm>();
                orderForm.SetDataForEdit(isEditMode ? null : (PurchaseOrderModel)null);
                orderForm.ShowDialog();
            }
        }


    }
}
