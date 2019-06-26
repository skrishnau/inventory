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

namespace IMS.Forms.Inventory.Units
{
    public partial class InventoryUnitUC : UserControl
    {
       // private SettingsBodyTemplate _body;
        private readonly InventoryUnitsMenu _sidebar;
        private readonly InventoryUnitListUC _inventoryUnitListUC;

        public InventoryUnitUC(InventoryUnitListUC inventoryUnitListUC , InventoryUnitsMenu sidebar)
        {
            _sidebar = sidebar;
            _inventoryUnitListUC = inventoryUnitListUC;

            InitializeComponent();

            this.Dock = DockStyle.Fill;

            this.Load += InventoryUnitUC_Load;

            

        }

        private void InventoryUnitUC_Load(object sender, EventArgs e)
        {
            InitializeBody();

            InitializeEvents();

            ShowInventoryUnitList();

        }

        private void ShowInventoryUnitList()
        {
            LnkManage_LinkClicked(_sidebar.lnkManage, null);
        }

        private void InitializeBody()
        {
            _body.HeadingText = "Inventory Units";
            //_body = new SettingsBodyTemplate
            //{
            //    HeadingText = "Inventory Units",
            //    SubHeadingText = ""
            //};
            _sidebar.Dock = DockStyle.Right;
            _body.headingControl.Controls.Add(_sidebar);
            _sidebar.BringToFront();
            //_body.pnlSideBar.Controls.Add(_sidebar);
           // this.Controls.Add(_body);
        }

        private void InitializeEvents()
        {
            _sidebar.lnkSummary.LinkClicked += LnkSummary_LinkClicked;
            _sidebar.lnkManage.LinkClicked += LnkManage_LinkClicked;
            _sidebar.lnkMovement.LinkClicked += LnkMovement_LinkClicked;
        }

        private void LnkMovement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var warehouseProductListUC = Program.container.GetInstance<InventoryMovementUC>();
            _body.pnlBody.Controls.Clear();
            warehouseProductListUC.Dock = DockStyle.Fill;
            _body.pnlBody.Controls.Add(warehouseProductListUC);
            _sidebar.SetVisited(sender);
           // _body.SubHeadingText = "Inentory Movements";
        }

        private void LnkSummary_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var warehouseProductListUC = Program.container.GetInstance<WarehouseProductListUC>();
            _body.pnlBody.Controls.Clear();
            warehouseProductListUC.Dock = DockStyle.Fill;
            _body.pnlBody.Controls.Add(warehouseProductListUC);
            _sidebar.SetVisited(sender);
           // _body.SubHeadingText = "Inentory Units Summary";
        }

        private void LnkManage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var inventoryUnitList = Program.container.GetInstance<InventoryUnitListUC>();
            _body.pnlBody.Controls.Clear();
            inventoryUnitList.Dock = DockStyle.Fill;
            _body.pnlBody.Controls.Add(inventoryUnitList);
            _sidebar.SetVisited(sender);
          //  _body.SubHeadingText = "Manage Inventory";
        }



    }
}
