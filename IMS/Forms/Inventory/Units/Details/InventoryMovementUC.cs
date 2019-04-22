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
using Service.Core.Inventory.Units;
using Service.Listeners;

namespace IMS.Forms.Inventory.Units.Details
{
    public partial class InventoryMovementUC : UserControl
    {
        private readonly IInventoryUnitService _inventoryUnitService;
        private readonly IDatabaseChangeListener _listener;

        public InventoryMovementUC(IInventoryUnitService inventoryUnitService, IDatabaseChangeListener listener)
        {
            _inventoryUnitService = inventoryUnitService;
            _listener = listener;
            InitializeComponent();

            this.Dock = DockStyle.Fill;

            this.Load += InventoryMovementUC_Load;
        }

        private void InventoryMovementUC_Load(object sender, EventArgs e)
        {
            dgvMovement.AutoGenerateColumns = false;
            PopulateMovements();
            _listener.InventoryUnitUpdated += _listener_InventoryUnitUpdated;
        }

        private void _listener_InventoryUnitUpdated(object sender, Service.DbEventArgs.BaseEventArgs<List<ViewModel.Core.Inventory.InventoryUnitModel>> e)
        {
            PopulateMovements();
        }

        private void PopulateMovements()
        {
            var movements = _inventoryUnitService.GetMovementList();
            dgvMovement.DataSource = movements;
        }
    }
}
