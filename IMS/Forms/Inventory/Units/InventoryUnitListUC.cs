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
using IMS.Forms.Inventory.Products;
using IMS.Forms.Common;

namespace IMS.Forms.Inventory.Units
{
    public partial class InventoryUnitListUC : BaseUserControl
    {
        private readonly InventoryManageUC _inventoryManageUC;
        private readonly RateListUC _rateListUC;
        private readonly InventoryMovementUC _inventoryMovementUC;
        // private readonly InventoryUnitsMenu _sidebar;

        public InventoryUnitListUC(InventoryManageUC inventoryManageUC, RateListUC rateListUC, InventoryMovementUC inventoryMovementUC)
        {
            //_sidebar = sidebar;
            _inventoryManageUC = inventoryManageUC;
            _rateListUC = rateListUC;
            _inventoryMovementUC = inventoryMovementUC;

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
        public override void ExecuteActions()
        {
            //base.ExecuteActions();
            _inventoryManageUC.ExecuteActions();
            _rateListUC.ExecuteActions();
            _inventoryMovementUC.ExecuteActions();
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
            _sidebar.btnRates.LinkClicked += BtnRates_LinkClicked;
        }

        private void BtnRates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //var _rateListUC = Program.container.GetInstance<RateListUC>();
            pnlBody.Controls.Clear();
            _rateListUC.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(_rateListUC);
            _sidebar.SetVisited(sender);
        }

        private void ShowInventoryUnitList()
        {
            //LnkSummary_LinkClicked(_sidebar.lnkSummary, null);
            LnkManage_LinkClicked(_sidebar.lnkManage, null);
        }

        private void LnkMovement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //var _inventoryMovementUC = Program.container.GetInstance<InventoryMovementUC>();
            pnlBody.Controls.Clear();
            _inventoryMovementUC.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(_inventoryMovementUC);
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
            //var _inventoryManageUC = Program.container.GetInstance<InventoryManageUC>();
            pnlBody.Controls.Clear();
            _inventoryManageUC.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(_inventoryManageUC);
            _sidebar.SetVisited(sender);
            //  SubHeadingText = "Manage Inventory";
        }
    }
}
