using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Forms.Common.Display;
using IMS.Forms.Inventory.Units.Details;
using IMS.Forms.Common;

namespace IMS.Forms.Inventory.Units
{
    public partial class InventoryUnitUC : BaseUserControl
    {
        // private SettingsBodyTemplate _body;

        private InventoryUnitListUC _inventoryUnitListUC;

        public InventoryUnitUC(InventoryUnitListUC inventoryUnitListUC)
        {
            _inventoryUnitListUC = inventoryUnitListUC;
            InitializeComponent();

            this.Dock = DockStyle.Fill;

            this.Load += InventoryUnitUC_Load;

        }
        public override void ExecuteActions()
        {
            //base.ExecuteActions();
            _inventoryUnitListUC.ExecuteActions();
        }

        private void InventoryUnitUC_Load(object sender, EventArgs e)
        {
            InitializeBody();

        }


        private void InitializeBody()
        {
            _body.HeadingText = "Inventory Units";
            //_body = new SettingsBodyTemplate
            //{
            //    HeadingText = "Inventory Units",
            //    SubHeadingText = ""
            //};
            _body.pnlBody.Controls.Add(_inventoryUnitListUC);
           
        }

    }
}
