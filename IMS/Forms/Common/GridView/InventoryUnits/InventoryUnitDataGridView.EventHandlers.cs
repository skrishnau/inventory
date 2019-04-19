﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace IMS.Forms.Common.GridView.InventoryUnits
{
    //
    // Event Handlers
    //
    public partial class InventoryUnitDataGridView
    {

        private void InitializeEvents()
        {
            // 
            // this DataGridView
            //
            this.DataError += InventoryUnitDataGridView_DataError;
            this.CurrentCellDirtyStateChanged += InventoryUnitDataGridView_CurrentCellDirtyStateChanged;
            this.CellValidating += InventoryUnitDataGridView_CellValidating;
            this.SelectionChanged += InventoryUnit_SelectionChanged;
            this.CellContentClick += InventoryUnit_CellContentClick;
            this.CellEnter += InventoryUnitDataGridView_CellEnter;
            this.CellLeave += InventoryUnitDataGridView_CellLeave;
            this.ColumnWidthChanged += InventoryUnitDataGridView_ColumnWidthChanged;
            this.Scroll += InventoryUnitDataGridView_Scroll;
            //
            // Datetime Picker
            //
            _dtPicker.TextChanged += _dtPicker_TextChanged;
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
                            row.Cells[this.colProductId.Index].Value = product.Name;
                            row.Cells[this.colProduct.Index].Value = product.Name;
                            row.Cells[this.colSupplyPrice.Index].Value = product.SupplyPrice;
                            row.Cells[this.colPackageId.Index].Value = product.PackageId;
                            row.Cells[this.colUomId.Index].Value = product.BaseUomId;
                            row.Cells[this.colInStockQuantity.Index].Value = product.InStockQuantity;
                            row.Cells[this.colOnOrderQuantity.Index].Value = product.OnOrderQuantity;
                            //row.Cells[this.colRate.Index].Value = product.SupplyPrice;
                            UpdateTotalColumn(e);
                        }
                    }
                    // handle rate and quantity change to update Total
                    // don't do 'else' here cause supplyPrice and unitQuantity columns are already handeled above
                    if (e.ColumnIndex == colUnitQuantity.Index || e.ColumnIndex == colSupplyPrice.Index)
                    {
                        UpdateTotalColumn(e);
                    }
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
        //
        // Cell Enter
        //
        private void InventoryUnitDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = string.Empty;
            if (e.ColumnIndex == colProductionDate.Index
                || e.ColumnIndex == colExpirationDate.Index)
            {
                _rectangle = this.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                _dtPicker.Size = new Size(17, _rectangle.Height);
                _dtPicker.Location = new Point(_rectangle.X + _rectangle.Width - 17, _rectangle.Y);
                _dtPicker.Visible = true;
                // set
                _dtPicker.TextChanged -= _dtPicker_TextChanged;
                var value = this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                _dtPicker.Text = value == null ? "" : value.ToString();
                _dtPicker.TextChanged += _dtPicker_TextChanged;
            }
        }
        //
        // Cell Leave
        //
        private void InventoryUnitDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colProductionDate.Index
               || e.ColumnIndex == colExpirationDate.Index)
            {
                _dtPicker.Visible = false;
            }
        }
        //
        // Scroll
        //
        private void InventoryUnitDataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            _dtPicker.Visible = false;
        }
        //
        // Column Width Changed
        //
        private void InventoryUnitDataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            _dtPicker.Visible = false;
        }

        //
        // DateTimePicker Text Changed
        // 
        private void _dtPicker_TextChanged(object sender, EventArgs e)
        {
            this.CurrentCell.Value = _dtPicker.Text;
            this.BeginEdit(true);
        }



        private void UpdateTotalColumn(DataGridViewCellValidatingEventArgs e)
        {
            var row = this.Rows[e.RowIndex];
            object qtyVal = row.Cells[colUnitQuantity.Name].Value;
            object rateVal = row.Cells[colSupplyPrice.Name].Value;
            decimal quantity = 0, rate = 0;

            if (e.ColumnIndex == colUnitQuantity.Index)
            {
                qtyVal = e.FormattedValue; // row.Cells[colQuantity.Name].Value;
            }
            else if (e.ColumnIndex == colSupplyPrice.Index)
            {
                rateVal = e.FormattedValue;
            }
            decimal.TryParse(qtyVal == null ? "0" : qtyVal.ToString(), out quantity);
            decimal.TryParse(rateVal == null ? "0" : rateVal.ToString(), out rate);
            row.Cells[colTotalSupplyAmount.Index].Value = quantity * rate;
        }
    }
}




/*
    if (e.ColumnIndex == colLotNumber.Index)
    {
        GetLotNumber(row, e.FormattedValue);
    }
    //else if (e.ColumnIndex == colPackageId.Index)
    //{
    //    GetPackageId(row, e.FormattedValue);
    //}
    else if (e.ColumnIndex == colUnitQuantity.Index)
    {
        GetUnitQuantity(row, e.FormattedValue);
    }
    else 
 */