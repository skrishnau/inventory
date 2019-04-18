using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Common.GridView.InventoryUnits
{
    //
    // Event Handlers
    //
    public partial class InventoryUnitDataGridView
    {
        private bool _isCellDirty;
        private int _checkCount;
        private bool _isUnSelectable;

        private void InitializeEvents()
        {
            this.DataError += InventoryUnitDataGridView_DataError;
            this.CurrentCellDirtyStateChanged += InventoryUnitDataGridView_CurrentCellDirtyStateChanged;
            this.CellValidating += InventoryUnitDataGridView_CellValidating;
            this.SelectionChanged += InventoryUnit_SelectionChanged;
            this.CellContentClick += InventoryUnit_CellContentClick;
        }

        //
        // Data Error
        //
        private void InventoryUnitDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            PopupMessage.ShowErrorMessage(e.Exception.Message);
            this.Focus();
        }
        //
        // Current Cell Dirty State Changed
        //
        private void InventoryUnitDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            _isCellDirty = true;
        }
        //
        // Cell Validating
        //
        private void InventoryUnitDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (_isCellDirty)
            {
                _isCellDirty = false;
                // ignore the last row
                if (e.RowIndex < this.RowCount - 1)
                {
                    var row = this.Rows[e.RowIndex];
                    if (e.ColumnIndex == this.colSKU.Index)
                    {
                        // check if the sku is valid
                        var product = _inventoryService.GetProductBySKU(e.FormattedValue.ToString());
                        if (product == null)
                        {
                            row.Cells[e.ColumnIndex].ErrorText = "Invalid SKU";
                        }
                        else
                        {
                            row.Cells[e.ColumnIndex].ErrorText = string.Empty;
                            // populate
                            row.Cells[this.colProduct.Index].Value = product.Name;
                            row.Cells[this.colPackageId.Index].Value = product.Package;
                            row.Cells[this.colProduct.Index].Value = product.Name;
                            row.Cells[this.colSupplyPrice.Index].Value = product.SupplyPrice;
                            row.Cells[this.colPackageId.Index].Value = product.PackageId;
                            row.Cells[this.colUomId.Index].Value = product.BaseUomId;
                            //row.Cells[this.colInStock.Index].Value = product.InStockQuantity;
                            //row.Cells[this.colOnOrder.Index].Value = product.OnOrderQuantity;
                            //row.Cells[this.colRate.Index].Value = product.SupplyPrice;
                            // UpdateTotalColumn(e);
                        }
                    }
                    // handle rate and quantity change to update Total
                    //else if (e.ColumnIndex == colQuantity.Index || e.ColumnIndex == colRate.Index)
                    //{
                    //    UpdateTotalColumn(e);
                    //}
                }
            }
        }
        //
        // Cell Content Click
        //
        private void InventoryUnit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.colCheck.Index)
            {
                this.CommitEdit(DataGridViewDataErrorContexts.Commit);
                var value = this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                var check = value == null ? false : bool.Parse(value.ToString());// this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                _checkCount += check ? 1 : -1;
            }
        }
        //
        // Selection Change
        //
        private void InventoryUnit_SelectionChanged(object sender, EventArgs e)
        {
            if (_isUnSelectable)
            {
                this.ClearSelection();
            }
        }



        #region Variables Expose

        public void SetSelectable(bool isSelectable)
        {
            _isUnSelectable = !isSelectable;
            if (!isSelectable)
                this.ClearSelection();
        }

        public void ResetCheckCount()
        {
            _checkCount = 0;
        }

        public void ShowCheckColumn(bool show)
        {
            colCheck.Visible = show;
            // when check box is shown, don't allow row selection
            SetSelectable(!show);
        }

        #endregion
    }
}
