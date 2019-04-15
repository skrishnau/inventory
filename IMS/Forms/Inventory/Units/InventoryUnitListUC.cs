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
using ViewModel.Core.Inventory;
using IMS.Forms.Common;
using SimpleInjector.Lifestyles;
using IMS.Forms.Inventory.Units.Actions;
using IMS.Forms.Common.Dialogs;

namespace IMS.Forms.Inventory.Units
{
    public partial class InventoryUnitListUC : UserControl
    {

        private readonly IDatabaseChangeListener _listener;
        private readonly IInventoryService _inventoryService;
        private readonly IBusinessService _businessService;

        private SubHeadingTemplate _header;
        private int checkCount;
        private bool _bulkActionsEnabled;

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
            InitializeEvents();
            InitializeGridView();
            PopulateInventoryUnits();

            InitializeListeners();
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

        private void InitializeHeader()
        {
            _header = SubHeadingTemplate.Instance;
            this.Controls.Add(_header);
            _header.SendToBack();
            // header text
            _header.lblHeading.Text = "Inventory Units";
        }

        private void InitializeEvents()
        {
            btnMerge.Click += BtnMerge_Click;
            btnSplit.Click += BtnSplit_Click;
            btnMove.Click += BtnMove_Click;
            btnIssue.Click += BtnIssue_Click;
            btnDisassemble.Click += BtnDisassemble_Click;
        }

        private void InitializeGridView()
        {
            dgvInventoryUnit.SelectionChanged += DgvInventoryUnit_SelectionChanged;
            dgvInventoryUnit.CellContentClick += DgvInventoryUnit_CellContentClick;
        }

        #endregion



        #region Populate and Get Data

        private void PopulateInventoryUnits()
        {
            checkCount = 0;
            var inventoryUnits = _inventoryService.GetInventoryUnitList();
            dgvInventoryUnit.AutoGenerateColumns = false;
            dgvInventoryUnit.DataSource = inventoryUnits;
        }

        private List<InventoryUnitModel> GetSelectedRows()
        {
            var list = new List<InventoryUnitModel>();
            // get the rows
            foreach (DataGridViewRow row in dgvInventoryUnit.Rows)
            {
                // get the cell
                var check = row.Cells[colCheck.Index].Value;
                var checkBool = check == null ? false : bool.Parse(check.ToString());
                if (checkBool)
                {
                    list.Add(row.DataBoundItem as InventoryUnitModel);
                }
            }
            return list;
        }

        #endregion


        #region GridView Event Handlers

        private void DgvInventoryUnit_SelectionChanged(object sender, EventArgs e)
        {
            if (_bulkActionsEnabled)
            {
                dgvInventoryUnit.ClearSelection();
            }
        }

        private void DgvInventoryUnit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colCheck.Index)
            {
                dgvInventoryUnit.CommitEdit(DataGridViewDataErrorContexts.Commit);
                var value = dgvInventoryUnit.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                var check = value == null ? false : bool.Parse(value.ToString());// dgvInventoryUnit.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                checkCount += check ? 1 : -1;
            }
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
                var moveForm = Program.container.GetInstance<InventoryMoveForm>();
                moveForm.SetData(list);
                moveForm.ShowDialog();
            }
        }

        private void BtnIssue_Click(object sender, EventArgs e)
        {

        }

        private void BtnDisassemble_Click(object sender, EventArgs e)
        {

        }

        private void chkBulkActions_CheckedChanged(object sender, EventArgs e)
        {
            var check = chkBulkActions.Checked;
            _bulkActionsEnabled = check; // set in variable
            gbSingleRowActions.Enabled = !check;
            gbInformation.Enabled = !check;
            pnlBulkActions.Enabled = check;

            dgvInventoryUnit.Columns[colCheck.Index].Visible = check;
            dgvInventoryUnit.ClearSelection();

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
