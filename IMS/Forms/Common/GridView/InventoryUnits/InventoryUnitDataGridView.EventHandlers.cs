using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ViewModel.Core.Common;
using ViewModel.Core.Inventory;
using ViewModel.Utility;

namespace IMS.Forms.Common.GridView.InventoryUnits
{
    //
    // Event Handlers
    //
    public partial class InventoryUnitDataGridView
    {
        public delegate void AmountChange(decimal totals);
        public event AmountChange AmountChnanged;

        private void InitializeEvents()
        {
            // 
            // this DataGridView
            //
            this.DataError += InventoryUnitDataGridView_DataError;
            this.EditingControlShowing += InventoryUnitDataGridView_EditingControlShowing;
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

            // ignore the last row
            if (e.RowIndex <= this.RowCount - 1)
            {
                var row = this.Rows[e.RowIndex];
                // below commented code adds product to the list in UI . YOu need to change datasource to AddItems
                //if (e.ColumnIndex == this.colProductId.Index)
                //{
                //    DataGridView dataGridView = sender as DataGridView;
                //    if (dataGridView == null) return;
                //    if (!dataGridView.CurrentCell.IsInEditMode) return;
                //    if (dataGridView.CurrentCell.GetType() != typeof(DataGridViewComboBoxCell)) return;
                //    DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                //    if (cell.Items.Contains(e.FormattedValue)) return;
                //    cell.Items.Add(e.FormattedValue);
                //    cell.Value = e.FormattedValue;
                //    if (((DataGridViewComboBoxColumn)dataGridView.Columns[colProductId.Index]).Items.Contains(e.FormattedValue)) return;
                //    ((DataGridViewComboBoxColumn)dataGridView.Columns[colProductId.Index]).Items.Add(e.FormattedValue);
                //}
                if (_isCellDirty)
                {
                    _isCellDirty = false;


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
                            UpdateProductInfo(row, product, e.RowIndex, e.ColumnIndex, e.FormattedValue);

                        }
                    }
                    // handle rate and quantity change to update Total
                    // don't do 'else' here cause supplyPrice and unitQuantity columns are already handeled above
                    if (e.ColumnIndex == colUnitQuantity.Index || e.ColumnIndex == colRate.Index)
                    {
                        UpdateTotalColumn(e.RowIndex, e.ColumnIndex, e.FormattedValue);
                    }
                }
            }
        }

        //
        // Update Product detail after product selection/change
        //
        private void UpdateProductInfo(DataGridViewRow row, ProductModel product,
            int currentRowIndex, int currentColumnIndex, object formattedValue)
        {
            row.Cells[this.colProductId.Index].Value = product.Id;
            // row.Cells[this.colProduct.Index].Value = product.Name;
            row.Cells[this.colSKU.Index].Value = product.SKU;
            switch (_movementType)
            {
                case ViewModel.Enums.MovementTypeEnum.SOIssueEditItems:
                    row.Cells[this.colRate.Index].Value = product.RetailPrice;
                    break;
                case ViewModel.Enums.MovementTypeEnum.POReceiveEditItems:
                    row.Cells[this.colRate.Index].Value = product.SupplyPrice;
                    break;
            }
            row.Cells[this.colPackageId.Index].Value = product.PackageId;
            row.Cells[this.colUomId.Index].Value = product.BaseUomId;
            row.Cells[this.colInStockQuantity.Index].Value = product.InStockQuantity;
            row.Cells[this.colOnOrderQuantity.Index].Value = product.OnOrderQuantity;
            row.Cells[this.colWarehouseId.Index].Value = product.WarehouseId;
            row.Cells[this.colWarehouse.Index].Value = product.Warehouse;
            UpdateTotalColumn(currentRowIndex, currentColumnIndex, formattedValue);
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
            if (_isEditable && (e.ColumnIndex == colProductionDate.Index
                || e.ColumnIndex == colExpirationDate.Index))
            {
                _rectangle = this.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                _dtPicker.Size = new Size(17, _rectangle.Height);
                _dtPicker.Location = new Point(_rectangle.X + _rectangle.Width - 17, _rectangle.Y);
                _dtPicker.Visible = true;
                // set
                _dtPicker.TextChanged -= _dtPicker_TextChanged;
                var value = this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (value != null)
                {
                    DateTime dt;
                    if (DateTime.TryParse(value.ToString(), out dt))
                    {
                        _dtPicker.Text = value == null ? "" : value.ToString();
                    }
                }
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
        // Editing Control Showing
        private void InventoryUnitDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.CurrentCell.ColumnIndex == this.colProductId.Index && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.DropDownStyle = ComboBoxStyle.DropDown;
                //var list = (ViewModel.Core.Common.IdNamePair)comboBox.DataSource;
                comboBox.AutoCompleteCustomSource.AddRange(_productList.Select(x => x.Name).ToArray());
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

                comboBox.SelectedIndexChanged -= ProductColumnComboSelectionChanged;
                comboBox.SelectedIndexChanged += ProductColumnComboSelectionChanged;
            }
        }

        private void ProductColumnComboSelectionChanged(object sender, EventArgs e)
        {
            // var currentcell = this.CurrentCellAddress;
            //var sendingCB = sender as DataGridViewComboBoxEditingControl;
            //DataGridViewTextBoxCell cel = (DataGridViewTextBoxCell)this.Rows[currentcell.Y].Cells[0];
            //cel.Value = sendingCB.EditingControlFormattedValue.ToString();

            if (this.CurrentCell.ColumnIndex != colProductId.Index)
                return;

            var combo = sender as ComboBox;
            if (combo != null)
            {
                var selectedItem = combo.SelectedItem as IdNamePair;
                if (selectedItem != null)
                {
                    var row = this.CurrentRow;
                    var productId = int.Parse(selectedItem.Id.ToString());
                    var productModel = _inventoryService.GetProductById(productId);

                    UpdateProductInfo(row, productModel, this.CurrentRow.Index, this.colProductId.Index, productId);
                }

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
            this.CurrentCell.Value = DateHelper.ToFormattedDateString(_dtPicker.Value);
            this.BeginEdit(true);
        }



        private void UpdateTotalColumn(int currentRowIndex, int currentColumnIndex, object formattedValue)
        //(DataGridViewCellValidatingEventArgs e)
        {
            var row = this.Rows[currentRowIndex];
            object qtyVal = row.Cells[colUnitQuantity.Name].Value;
            object rateVal = row.Cells[colRate.Name].Value;
            decimal quantity = 0, rate = 0;

            if (currentColumnIndex == colUnitQuantity.Index)
            {
                qtyVal = formattedValue; // row.Cells[colQuantity.Name].Value;
            }
            else if (currentColumnIndex == colRate.Index)
            {
                rateVal = formattedValue;
            }
            decimal.TryParse(qtyVal == null ? "0" : qtyVal.ToString(), out quantity);
            decimal.TryParse(rateVal == null ? "0" : rateVal.ToString(), out rate);
            row.Cells[colTotal.Index].Value = quantity * rate;

            //GetItems();
            AmountChnanged(GetTotalSumAmount());
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
