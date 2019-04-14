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
using Service.Core.Inventory;
using Service.Core.Business;
using IMS.Forms.Common.Display;

namespace IMS.Forms.Inventory.Units
{
    public partial class InventoryUnitListUC : UserControl
    {

        private readonly IDatabaseChangeListener _listener;
        private readonly IInventoryService _inventoryService;
        private readonly IBusinessService _businessService;

        private SubHeadingTemplate _header;

        public InventoryUnitListUC(IDatabaseChangeListener listener,
            IInventoryService inventoryService,
            IBusinessService businessService)
        {
            _listener = listener;
            _inventoryService = inventoryService;
            _businessService = businessService;

            InitializeComponent();
            this.Load += InventoryUnitListUC_Load;
        }

        private void InventoryUnitListUC_Load(object sender, EventArgs e)
        {
            InitializeHeader();
            PopulateInventoryUnits();
        }

        private void PopulateInventoryUnits()
        {
           var inventoryUnits = _inventoryService.GetInventoryUnitList();
            dgvInventoryUnit.AutoGenerateColumns = false;
            dgvInventoryUnit.DataSource = inventoryUnits;
        }

        private void InitializeHeader()
        {
            _header = SubHeadingTemplate.Instance;
            this.Controls.Add(_header);
            _header.SendToBack();
            // header text
            _header.lblHeading.Text = "Inventory Units";
        }

    }
}
