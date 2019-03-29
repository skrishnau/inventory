using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Forms.Inventory.Create;
using Service.Core.Inventory;
using SimpleInjector.Lifestyles;
using ViewModel.Core.Inventory;
using IMS.Forms.Inventory.Categories;
using System.Threading;
using IMS.Forms.Inventory.Variants;
using IMS.Forms.Common.Display;
using IMS.Forms.Purchases;
using IMS.Forms.Inventory.Products;
using IMS.Forms.Inventory.Suppliers;
using IMS.Forms.Inventory.Attributes;
using IMS.Forms.Inventory.Warehouses;
using IMS.Forms.Business.Create;

namespace IMS.Forms.Inventory
{
    public partial class InventoryUC : UserControl
    {
        private static readonly string MODULE_NAME = "Inventory";
        private BodyTemplate _bodyTemplate;
        private InventoryMenuBar _menubar;

        // dependency injection
        public InventoryUC(InventoryMenuBar menubar)
        {
            _menubar = menubar;

            InitializeComponent();

            InitializeRootTemplate();

            InitializeMenubarButtonEvents();

        }

        private void InitializeRootTemplate()
        {
            // body
            _bodyTemplate = new BodyTemplate();
            _bodyTemplate.Dock = DockStyle.Fill;
            this.Controls.Add(_bodyTemplate);
            // heading
            _bodyTemplate.lblHeading.Text = MODULE_NAME;
            // menubar template
            _bodyTemplate.pnlMenuBar.Controls.Add(_menubar);
        }

        private void InitializeMenubarButtonEvents()
        {
           
            // order
            _menubar.btnOrderList.Click += BtnOrderList_Click;
            _menubar.btnNewOrder.Click += BtnNewOrder_Click;
            _menubar.btnDirectReceive.Click += BtnDirectReceive_Click;
            // supplier
            _menubar.btnSupplierList.Click += BtnSupplierList_Click;
            _menubar.btnNewSupplier.Click += BtnNewSupplier_Click;
            // warehouse
            _menubar.btnWarehouseList.Click += BtnWarehouseList_Click;
            _menubar.btnNewWarehouse.Click += BtnNewWarehouse_Click;
        }
        
        #region Supplier

        private void BtnSupplierList_Click(object sender, EventArgs e)
        {
            _bodyTemplate.pnlBody.Controls.Clear();
            var supplierListUC = Program.container.GetInstance<SupplierUC>();
            supplierListUC.Dock = DockStyle.Fill;
            _bodyTemplate.pnlBody.Controls.Add(supplierListUC);
            // set selection
            _menubar.ClearSelection();
            _menubar.btnSupplierList.FlatStyle = FlatStyle.Flat;
        }

        private void BtnNewSupplier_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var supplierCreate = Program.container.GetInstance<SupplierCreate>();// (supplier);
                supplierCreate.ShowInTaskbar = false;
                supplierCreate.ShowDialog();
            }
        }

        #endregion




        #region Order

        private void BtnOrderList_Click(object sender, EventArgs e)
        {
            var purchaseListUC = Program.container.GetInstance<PurchaseListUC>();
            _bodyTemplate.pnlBody.Controls.Clear();
            purchaseListUC.Dock = DockStyle.Fill;
            _bodyTemplate.pnlBody.Controls.Add(purchaseListUC);
            // set selection
            _menubar.ClearSelection();
            _menubar.btnOrderList.FlatStyle = FlatStyle.Flat;
        }

        private void BtnNewOrder_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var orderCreate = Program.container.GetInstance<PurchaseOrderForm>();
                orderCreate.ShowInTaskbar = false;
                orderCreate.ShowDialog();
            }
        }

        private void BtnDirectReceive_Click(object sender, EventArgs e)
        {

        }

        #endregion


        #region Warehouse

        private void BtnWarehouseList_Click(object sender, EventArgs e)
        {
            var warehouseListUC = Program.container.GetInstance<WarehouseListUC>();
            _bodyTemplate.pnlBody.Controls.Clear();
            warehouseListUC.Dock = DockStyle.Fill;
            _bodyTemplate.pnlBody.Controls.Add(warehouseListUC);
            // set selection
            _menubar.ClearSelection();
            _menubar.btnWarehouseList.FlatStyle = FlatStyle.Flat;
        }

        private void BtnNewWarehouse_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var wareHouseCreate = Program.container.GetInstance<WarehouseCreate>();
                wareHouseCreate.ShowInTaskbar = false;
                wareHouseCreate.ShowDialog();
                //PopulateWarehouseData();
            }
        }

        #endregion

    }
}
