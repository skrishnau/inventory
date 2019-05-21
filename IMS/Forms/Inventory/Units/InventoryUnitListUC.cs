using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Service.Listeners;
using Service.Core.Inventory;
using Service.Core.Business;
using IMS.Forms.Common.Display;
using ViewModel.Core.Inventory;
using IMS.Forms.Common;
using SimpleInjector.Lifestyles;
using IMS.Forms.Inventory.Units.Actions;
using Service.Core.Inventory.Units;
using ViewModel.Enums;
using ViewModel.Core.Common;
using ViewModel.Core.Business;

namespace IMS.Forms.Inventory.Units
{
    public partial class InventoryUnitListUC : UserControl
    {

        private readonly IDatabaseChangeListener _listener;
        private readonly IInventoryService _inventoryService;
        private readonly IInventoryUnitService _inventoryUnitService;
        private readonly IBusinessService _businessService;

        // private HeaderTemplate _header;
        // private int checkCount;
        // private bool _bulkActionsEnabled;

        public InventoryUnitListUC(IDatabaseChangeListener listener,
            IInventoryService inventoryService,
            IInventoryUnitService inventoryUnitService,
            IBusinessService businessService)
        {
            _listener = listener;
            _inventoryService = inventoryService;
            _inventoryUnitService = inventoryUnitService;
            _businessService = businessService;

            InitializeComponent();
            this.Dock = DockStyle.Fill; ;
            dgvInventoryUnit.InitializeGridViewControls(_inventoryService);

            this.Load += InventoryUnitListUC_Load;
        }

        private void InventoryUnitListUC_Load(object sender, EventArgs e)
        {
            // InitializeHeader();  
            _listener.WarehouseUpdated += _listener_WarehouseUpdated;
            _listener.ProductUpdated += _listener_ProductUpdated;
            // InitializeHeader();
            PopulateWarehouses();
            PopulateProducts();

            InitializeEvents();
            InitializeGridView();
            PopulateInventoryUnits();

            InitializeListeners();
        }

        private void _listener_WarehouseUpdated(object sender, Service.DbEventArgs.BaseEventArgs<WarehouseModel> e)
        {
            PopulateWarehouses();
        }

        private void _listener_ProductUpdated(object sender, Service.Listeners.Inventory.ProductEventArgs e)
        {
            PopulateProducts();
        }

        #region Intialization Funcitons

        private void InitializeListeners()
        {
            _listener.InventoryUnitUpdated += _listener_InventoryUnitUpdated;
        }

        private void _listener_InventoryUnitUpdated(object sender, Service.DbEventArgs.BaseEventArgs<List<InventoryUnitModel>> e)
        {
            PopulateInventoryUnits();
        }

        //private void InitializeHeader()
        //{
        //    _header = HeaderTemplate.Instance;
        //    this.Controls.Add(_header);
        //    _header.SendToBack();
        //    // header text
        //    _header.lblHeading.Text = "Inventory Units";
        //}

        private void InitializeEvents()
        {
            cbWarehouse.SelectedValueChanged += CbWarehouse_SelectedValueChanged;
            cbProduct.SelectedValueChanged += CbProduct_SelectedValueChanged;

            btnMerge.Click += BtnMerge_Click;
            btnSplit.Click += BtnSplit_Click;
            btnMove.Click += BtnMove_Click;
            btnIssue.Click += BtnIssue_Click;
            btnDisassemble.Click += BtnDisassemble_Click;
            btnReceive.Click += BtnReceive_Click;
        }

        private void BtnReceive_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var directReceiveForm = Program.container.GetInstance<InventoryAdjustmentForm>();
                directReceiveForm.SetData(MovementTypeEnum.DirectReceive);
                directReceiveForm.ShowDialog();
            }
        }

        private void InitializeGridView()
        {
            //dgvInventoryUnit.SelectionChanged += DgvInventoryUnit_SelectionChanged;
            //dgvInventoryUnit.CellContentClick += DgvInventoryUnit_CellContentClick;
            dgvInventoryUnit.DesignForInventoryUnitListing();
            dgvInventoryUnit.ShowCheckColumn(true); // 1. first show
            dgvInventoryUnit.SetSelectable(true); // 2. Second set selectable
        }

        #endregion



        #region Populate and Get Data

        private void PopulateWarehouses()
        {
            var warehouses = _inventoryService.GetWarehouseListForCombo();
            var allWarehouse = new IdNamePair { Id = 0, Name = " ---- All ---- " };
            warehouses.Insert(0, allWarehouse);
            cbWarehouse.DataSource = warehouses;
            cbWarehouse.DisplayMember = "Name";
            cbWarehouse.ValueMember = "Id";
        }

        private void PopulateProducts()
        {
            var products = _inventoryService.GetProductListForCombo();
            var allProduct = new IdNamePair { Id = 0, Name = " ---- All ---- " };
            products.Insert(0, allProduct);
            cbProduct.DataSource = products;
            cbProduct.DisplayMember = "Name";
            cbProduct.ValueMember = "Id";
        }

        private void PopulateInventoryUnits()
        {
            dgvInventoryUnit.ResetCheckCount();
            var warehouseId = int.Parse(cbWarehouse.SelectedValue.ToString());
            var productId = int.Parse(cbProduct.SelectedValue.ToString());
            var inventoryUnits = _inventoryUnitService.GetInventoryUnitList(warehouseId, productId);
            dgvInventoryUnit.DataSource = inventoryUnits;
        }

        private List<InventoryUnitModel> GetSelectedRows()
        {
            var list = new List<InventoryUnitModel>();
            // get the rows
            foreach (DataGridViewRow row in dgvInventoryUnit.Rows)
            {
                // get the cell
                var check = row.Cells[dgvInventoryUnit.colCheck.Index].Value;
                var checkBool = check == null ? false : bool.Parse(check.ToString());
                if (checkBool)
                {
                    list.Add(row.DataBoundItem as InventoryUnitModel);
                }
            }
            return list;
        }

        #endregion


        #region Events (filter controls)


        private void CbProduct_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateInventoryUnits();
        }

        private void CbWarehouse_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateInventoryUnits();
        }

        #endregion




        #region Controls Event Handlers

        private void BtnMerge_Click(object sender, EventArgs e)
        {
            var list = GetSelectedRows();
            if (list.Count < 2)
            {
                PopupMessage.ShowInfoMessage("Please check two or more rows to perform Merge!");
                this.Focus();
                return;
            }
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var mergeForm = Program.container.GetInstance<InventoryMergeForm>();
                mergeForm.SetData(list);
                mergeForm.ShowDialog();
            }

        }

        private void BtnSplit_Click(object sender, EventArgs e)
        {
            if (dgvInventoryUnit.SelectedRows.Count == 0)
            {
                PopupMessage.ShowInfoMessage("Select a record to \"Split\"");
                this.Focus();
                return;
            }
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var data = dgvInventoryUnit.SelectedRows[0].DataBoundItem as InventoryUnitModel;
                var splitForm = Program.container.GetInstance<InventorySplitForm>();
                splitForm.SetData(data);
                splitForm.ShowDialog();
            }
        }

        private void BtnMove_Click(object sender, EventArgs e)
        {
            var list = GetSelectedRows();
            if (list.Count == 0)
            {
                PopupMessage.ShowInfoMessage("Please check at least one record to perform \"Move\"!");
                this.Focus();
                return;
            }
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var moveForm = Program.container.GetInstance<InventoryAdjustmentForm>();
                //Program.container.GetInstance<InventoryMoveForm>();
                moveForm.SetData(MovementTypeEnum.DirectMove, 0, list);
                moveForm.ShowDialog();
            }
        }

        private void BtnIssue_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var directReceiveForm = Program.container.GetInstance<InventoryAdjustmentForm>();
                directReceiveForm.SetData(MovementTypeEnum.DirectIssue, 0, GetSelectedRows());
                directReceiveForm.ShowDialog();
            }
        }

        private void BtnDisassemble_Click(object sender, EventArgs e)
        {

        }

        private void chkBulkActions_CheckedChanged(object sender, EventArgs e)
        {
            var check = chkBulkActions.Checked;

            gbSingleRowActions.Enabled = !check;
            gbInformation.Enabled = !check;
            pnlBulkActions.Enabled = check;

            dgvInventoryUnit.ShowCheckColumn(check);


            lblInformationMessage.Visible = check;
            lblSingleRowActionMessage.Visible = check;

            if (check)
            {
                chkBulkActions.Text = "Disable";
                lblBulkActionsMessage.Text = "Check rows to perform bulk action";
                // PopupMessage.ShowInfoMessage("Check rows to perform bulk action");
            }
            else
            {
                chkBulkActions.Text = "Enable";
                lblBulkActionsMessage.Text = "Check \"Enable\" button above";
            }
        }

        #endregion







    }
}
