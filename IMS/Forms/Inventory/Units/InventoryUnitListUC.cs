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
using ViewModel.Utility;

namespace IMS.Forms.Inventory.Units
{
    public partial class InventoryUnitListUC : BaseUserControl
    {
        private readonly InventoryManageUC _inventoryManageUC;
        private readonly RateListUC _rateListUC;
        private readonly InventoryMovementUC _inventoryMovementUC;
        // private readonly InventoryUnitsMenu _sidebar;

        private BaseUserControl _currentTab;

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
            _inventoryManageUC.MyTabTitle = MyTabTitle;
            _inventoryManageUC.MySubTabTitle = Constants.NAME_INVENTORY_MANAGE;
            _rateListUC.MyTabTitle = MyTabTitle;
            _rateListUC.MySubTabTitle = Constants.NAME_RATE_LIST;
            _inventoryMovementUC.MyTabTitle = MyTabTitle;
            _inventoryMovementUC.MySubTabTitle = Constants.NAME_INVENTORY_MOVEMENT;

            InitializeBody();

            InitializeEvents();

            ShowInventoryUnitList();
            this.headingControl.HeadingText = "Inventory";

        }
        public override void ExecuteActions()
        {
            if(_currentTab != null)
            {
                _currentTab.ExecuteActions();
            }
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
            _currentTab = _rateListUC;// _sidebar.btnRates.Name;
            InventoryUC.CurrentSubTabTitle = _currentTab.MySubTabTitle;
            //var _rateListUC = Program.container.GetInstance<RateListUC>();
            pnlBody.Controls.Clear();
            _rateListUC.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(_rateListUC);
            _sidebar.SetVisited(sender);
            ExecuteActions();
        }

        private void ShowInventoryUnitList()
        {
            //LnkSummary_LinkClicked(_sidebar.lnkSummary, null);
            LnkManage_LinkClicked(_sidebar.lnkManage, null);
        }

        private void LnkMovement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _currentTab = _inventoryMovementUC;//_sidebar.lnkMovement.Name;
            InventoryUC.CurrentSubTabTitle = _currentTab.MySubTabTitle;

            //var _inventoryMovementUC = Program.container.GetInstance<InventoryMovementUC>();
            pnlBody.Controls.Clear();
            _inventoryMovementUC.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(_inventoryMovementUC);
            _sidebar.SetVisited(sender);
            // SubHeadingText = "Inentory Movements";
            
            ExecuteActions();
        }

        private void LnkSummary_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //_currentTab = _wa _sidebar.lnkSummary.Name;
            var warehouseProductListUC = Program.container.GetInstance<WarehouseProductListUC>();
            pnlBody.Controls.Clear();
            warehouseProductListUC.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(warehouseProductListUC);
            _sidebar.SetVisited(sender);
            // SubHeadingText = "Inentory Units Summary";
            ExecuteActions();
        }

        private void LnkManage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _currentTab = _inventoryManageUC;// _sidebar.lnkManage.Name;
            InventoryUC.CurrentSubTabTitle = _currentTab.MySubTabTitle;
            //var _inventoryManageUC = Program.container.GetInstance<InventoryManageUC>();
            pnlBody.Controls.Clear();
            _inventoryManageUC.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(_inventoryManageUC);
            _sidebar.SetVisited(sender);
            //  SubHeadingText = "Manage Inventory";
            ExecuteActions();
        }
    }
}
