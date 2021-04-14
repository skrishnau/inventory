using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Forms.Inventory.Units.Details;

namespace IMS.Forms.Inventory.Units
{
    public partial class InventoryUnitListUC : UserControl
    {
        private readonly InventoryManageUC _inventoryManageUC;
       // private readonly InventoryUnitsMenu _sidebar;

        public InventoryUnitListUC(InventoryManageUC inventoryManageUC)
        {
            //_sidebar = sidebar;
            _inventoryManageUC = inventoryManageUC;

            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += InventoryUnitListUC_Load;
        }

        private void InventoryUnitListUC_Load(object sender, EventArgs e)
        {
            InitializeBody();

            InitializeEvents();

            ShowInventoryUnitList();

        }

        private void InitializeBody()
        {
            // working -- uncomment later
            //_sidebar.Dock = DockStyle.Right;
            //headingControl.Controls.Add(_sidebar);
            //_sidebar.BringToFront();

            //pnlBody.Controls.Add(_sidebar);
            //_sidebar.BringToFront();

            //pnlSideBar.Controls.Add(_sidebar);
            // this.Controls.Add(_body);
        }

        private void InitializeEvents()
        {
            _sidebar.lnkSummary.LinkClicked += LnkSummary_LinkClicked;
            _sidebar.lnkManage.LinkClicked += LnkManage_LinkClicked;
            _sidebar.lnkMovement.LinkClicked += LnkMovement_LinkClicked;
        }

        private void ShowInventoryUnitList()
        {
            //LnkSummary_LinkClicked(_sidebar.lnkSummary, null);
            LnkManage_LinkClicked(_sidebar.lnkManage, null);
        }

        private void LnkMovement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var warehouseProductListUC = Program.container.GetInstance<InventoryMovementUC>();
            pnlBody.Controls.Clear();
            warehouseProductListUC.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(warehouseProductListUC);
            _sidebar.SetVisited(sender);
            // SubHeadingText = "Inentory Movements";
        }

        private void LnkSummary_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var warehouseProductListUC = Program.container.GetInstance<WarehouseProductListUC>();
            pnlBody.Controls.Clear();
            warehouseProductListUC.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(warehouseProductListUC);
            _sidebar.SetVisited(sender);
            // SubHeadingText = "Inentory Units Summary";
        }

        private void LnkManage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var inventoryUnitList = Program.container.GetInstance<InventoryManageUC>();
            pnlBody.Controls.Clear();
            inventoryUnitList.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(inventoryUnitList);
            _sidebar.SetVisited(sender);
            //  SubHeadingText = "Manage Inventory";
        }
    }
}
