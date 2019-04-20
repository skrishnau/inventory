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
using IMS.Forms.Common.Links;
using IMS.Forms.Inventory.Transfers;

namespace IMS.Forms.Inventory.Warehouses
{
    public partial class WarehouseUC : UserControl
    {

        private SubBodyTemplate _subBodyTemplate;

        private readonly WarehouseListUC _warehouseListUC;
        private readonly WarehouseSideBarUC _warehouseSideBarUC;
        private LinkManager _linkManager;

        public WarehouseUC(WarehouseListUC warehouseListUC, WarehouseSideBarUC warehouseSideBarUC)
        {
            _warehouseListUC = warehouseListUC;
            _warehouseSideBarUC = warehouseSideBarUC;

            InitializeComponent();
            this.Dock = DockStyle.Fill;

            this.Load += WarehouseUC_Load;
        }

        private void WarehouseUC_Load(object sender, EventArgs e)
        {
            InitializeSubBody();
            _linkManager = new LinkManager(_warehouseSideBarUC.pnlLinkList, _subBodyTemplate.toolTip1);
            _warehouseSideBarUC.lnkList.LinkClicked += _linkManager.Link_Click;
            _warehouseSideBarUC.lnkTransfers.LinkClicked += LnkTransfers_LinkClicked;
            _linkManager.LinkClicked += _linkManager_LinkClicked;
            ShowUI(_warehouseSideBarUC.lnkList, 0);
        }

        private void LnkTransfers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // show the list
            _subBodyTemplate.pnlBody.Controls.Clear();
            var transferListUC = Program.container.GetInstance<InventoryTransfersListUC>();
            transferListUC.Dock = DockStyle.Fill;
            _subBodyTemplate.pnlBody.Controls.Add(transferListUC);
            // set selection
            //_menubar.ClearSelection(sender);
            _warehouseSideBarUC.SetVisited(sender);
            _subBodyTemplate.SubHeadingText = "Transfers";
        }
        

        private void _linkManager_LinkClicked(object sender, Service.DbEventArgs.IdEventArgs e)
        {
            _warehouseSideBarUC.SetVisited(sender);
            ShowUI(sender, e.Id);
        }

        private void InitializeSubBody()
        {
            _subBodyTemplate = new SubBodyTemplate();
            this.Controls.Add(_subBodyTemplate);
            _subBodyTemplate.HeadingText = "Warehouses";
            _subBodyTemplate.SubHeadingText = "";

            _subBodyTemplate.pnlSideBar.Controls.Add(_warehouseSideBarUC);
        }

        private void ShowUI(object sender, int warehouseId)
        {
            _warehouseSideBarUC.SetVisited(sender);
            _subBodyTemplate.pnlBody.Controls.Clear();
            if (warehouseId == 0)
            {
                _subBodyTemplate.SubHeadingText = "Warehouse List";
                // show the list
                _subBodyTemplate.pnlBody.Controls.Add(_warehouseListUC);
            }
            else
            {
                _subBodyTemplate.SubHeadingText = "Warehouse Detail";
                // show the product detail
                //_productDetailUC.SetData(productId);
                //pnlBody.Controls.Add(_productDetailUC);
            }
        }
    }
}
