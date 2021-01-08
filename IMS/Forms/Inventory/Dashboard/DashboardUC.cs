using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Core.Inventory;
using Service.Listeners;

namespace IMS.Forms.Inventory.Dashboard
{
    public partial class DashboardUC : UserControl
    {
        private readonly IInventoryService _inventoryService;
        private readonly IDatabaseChangeListener _listener;

        public DashboardUC(IInventoryService inventoryService, IDatabaseChangeListener listener)
        {
            _inventoryService = inventoryService;
            _listener = listener;

            InitializeComponent();
            this.Dock = DockStyle.Fill;

            this.Load += DashboardUC_Load;
        }

        private void DashboardUC_Load(object sender, EventArgs e)
        {
            _listener.ProductUpdated += _listener_ProductUpdated;
            _listener.InventoryUnitUpdated += _listener_InventoryUnitUpdated;


            PopulateUnderstockProducts();
        }

        #region Listeners

        private void _listener_ProductUpdated(object sender, Service.Listeners.Inventory.ProductEventArgs e)
        {
            PopulateUnderstockProducts();

        }

        private void _listener_InventoryUnitUpdated(object sender, Service.DbEventArgs.BaseEventArgs<List<ViewModel.Core.Inventory.InventoryUnitModel>> e)
        {
            PopulateUnderstockProducts();
        }

        #endregion


        private void PopulateUnderstockProducts()
        {
            var products = _inventoryService.GetUnderStockProducts();
            lbUnderStockProducts.DataSource = products;
            lblTopUnderstockProducts.Text = "Understock Products - " + products.Count;
            lbUnderStockProducts.DisplayMember = "Name";
            lbUnderStockProducts.ValueMember = "Id";
            lbUnderStockProducts.ClearSelected();
            lbUnderStockProducts.SelectionMode = SelectionMode.None;
        }

    }
}
