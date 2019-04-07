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
using Service.Core.Inventory;
using ViewModel.Core.Inventory;
using IMS.Forms.Common;

namespace IMS.Forms.Inventory.Settings.Adjustments
{
    public partial class AdjustmentCodeUC : UserControl
    {
        private readonly IInventoryService _inventoryService;

        private bool _isRowDirty;

        public AdjustmentCodeUC(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;

            InitializeComponent();

            InitializeHeader();

            InitializeEvents();

            this.Load += AdjustmentUC_Load;
        }

        private void AdjustmentUC_Load(object sender, EventArgs e)
        {
            PopulateAdjustmentData();
        }

        private void PopulateAdjustmentData()
        {
            var adjustments = _inventoryService.GetAdjustmentCodeList();
            foreach (var adj in adjustments)
            {
                AddRow(adj);
            }
        }

        private void AddRow(AdjustmentCodeModel adj)
        {
            var row = (DataGridViewRow)dgvAdj.Rows[dgvAdj.RowCount - 1].Clone();
            row.Cells[colId.Index].Value = adj.Id;
            row.Cells[colName.Index].Value = adj.Name;
            row.Cells[colType.Index].Value = adj.Type;
            row.Cells[colAffectsDemand.Index].Value = adj.AffectsDemand;
            row.Cells[colUse.Index].Value = adj.Use;

            dgvAdj.Rows.Add(row);
        }

        private void InitializeEvents()
        {
            dgvAdj.RowValidated += DgvAdj_RowValidated;
            dgvAdj.CurrentCellDirtyStateChanged += DgvAdj_CurrentCellDirtyStateChanged;
        }

        private void DgvAdj_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            _isRowDirty = true;
        }

        private void DgvAdj_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            // get the data and save
            if (_isRowDirty && e.RowIndex < dgvAdj.RowCount - 1)
            {
                _isRowDirty = false;
                var adjData = GetAdjustmentData(e.RowIndex);
                if (adjData == null)
                {
                    return;
                }
                // save
                var msg = _inventoryService.SaveAdjustmentCode(adjData);
                if (string.IsNullOrEmpty(msg))
                {
                    // save success
                    PopupMessage.ShowSaveSuccessMessage();
                }
                else
                {
                    PopupMessage.ShowErrorMessage(msg);
                }
                dgvAdj.Focus();
            }
        }

        private AdjustmentCodeModel GetAdjustmentData(int rowIndex)
        {
            var row = dgvAdj.Rows[rowIndex];
            var name = row.Cells[colName.Name].Value;
            var id = row.Cells[colId.Name].Value;
            var type = row.Cells[colType.Name].Value;
            var affectsDemand = row.Cells[colAffectsDemand.Name].Value;
            var use = row.Cells[colUse.Name].Value;

            var isValid = true;
            if (name == null || string.IsNullOrEmpty(name.ToString()))
            {
                row.Cells[colName.Name].ErrorText = "Required";
                isValid = false;
            }
            if (type == null || string.IsNullOrEmpty(type.ToString()))
            {
                row.Cells[colType.Name].ErrorText = "Required";
                isValid = false;
            }

            if (!isValid)
                return null;

            row.Cells[colName.Name].ErrorText = string.Empty;
            row.Cells[colType.Name].ErrorText = string.Empty;

            return new AdjustmentCodeModel()
            {
                Id = int.Parse(id == null ? "0" : string.IsNullOrEmpty(id.ToString()) ? "0" : id.ToString()),
                Name = name == null ? "" : name.ToString(),
                Type = type == null ? "" : type.ToString(),
                AffectsDemand = affectsDemand == null ? false : bool.Parse(affectsDemand.ToString()),
                Use = use == null ? false : bool.Parse(use.ToString()),
            };
        }

        private void InitializeHeader()
        {
            var _header = SubHeadingTemplate.Instance;
            _header.lblHeading.Text = "Adjustment Codes";
            this.Controls.Add(_header);
            _header.SendToBack();
        }
    }
}
