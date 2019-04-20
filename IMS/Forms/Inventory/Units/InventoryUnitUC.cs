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
using IMS.Forms.Inventory.Products.WarehouseProducts;

namespace IMS.Forms.Inventory.Units
{
    public partial class InventoryUnitUC : UserControl
    {
        private SubBodyTemplate _body;
        private readonly InventoryUnitSideBarUC _sidebar;
        private readonly InventoryUnitListUC _inventoryUnitListUC;

        public InventoryUnitUC(InventoryUnitListUC inventoryUnitListUC , InventoryUnitSideBarUC sidebar)
        {
            _sidebar = sidebar;
            _inventoryUnitListUC = inventoryUnitListUC;

            InitializeComponent();

            this.Dock = DockStyle.Fill;

            InitializeBody();

            InitializeEvents();
        }

        private void InitializeBody()
        {
            _body = new SubBodyTemplate
            {
                HeadingText = "Inventory Units",
                SubHeadingText = ""
            };
            _body.pnlSideBar.Controls.Add(_sidebar);
            this.Controls.Add(_body);
        }

        private void InitializeEvents()
        {
            _sidebar.lnkSummary.LinkClicked += LnkSummary_LinkClicked;
            _sidebar.lnkManage.LinkClicked += LnkManage_LinkClicked;
        }

        private void LnkSummary_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var warehouseProductListUC = Program.container.GetInstance<WarehouseProductListUC>();
            _body.pnlBody.Controls.Clear();
            warehouseProductListUC.Dock = DockStyle.Fill;
            _body.pnlBody.Controls.Add(warehouseProductListUC);
            _sidebar.SetVisited(sender);
        }

        private void LnkManage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var inventoryUnitList = Program.container.GetInstance<InventoryUnitListUC>();
            _body.pnlBody.Controls.Clear();
            inventoryUnitList.Dock = DockStyle.Fill;
            _body.pnlBody.Controls.Add(inventoryUnitList);
            _sidebar.SetVisited(sender);
        }



    }
}
