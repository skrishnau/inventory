using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Common.GridView.InventoryUnits
{
    //
    // Data
    //
    public partial class InventoryUnitDataGridView
    {
        #region Validations

        //
        // Decimal Validator
        // 
        private GridViewColumnDecimalValidator _decimalValidator;
        //
        // Initialize Validations
        //
        private void InitializeValidations()
        {
            _decimalValidator = new GridViewColumnDecimalValidator(this);
            _decimalValidator.AddColumn(this.colUnitQuantity, ColumnDataType.Decimal);
            _decimalValidator.AddColumn(this.colRate, ColumnDataType.Decimal);
            if(_movementType == ViewModel.Enums.MovementTypeEnum.DirectReceive)
                _decimalValidator.AddColumn(this.colLotNumber, ColumnDataType.Integer);
            _decimalValidator.Validate();
        }

        #endregion
        
        //
        // Combo Box Populations
        //
        private void InitializeComboBoxData()
        {
            //
            // Product
            //
            PopulateProduct();
            //
            // Warehouse
            //
            PopulateWarehouse();
            //
            // Package
            // 
            PopulatePackage();
            //
            // Supplier
            //
            PopulateSupplier();
            // 
            // UOM
            //
            PopulateUom();
            
        }
        // 
        // Product
        //
        private void PopulateProduct()
        {
            var productIdColumn = this.Columns[this.colProductId.Index] as DataGridViewComboBoxColumn;
            if (productIdColumn != null)
            {
                productIdColumn.AutoComplete = true;
                //var datasource = _productList;//
                //foreach(var n in datasource.Select(x => x.Name).ToList())
                //    column.Items.Add(n);
                productIdColumn.DataSource = _productList;
                productIdColumn.ValueMember = "Id";
                productIdColumn.DisplayMember = "Name";
            }
            
        }
        //
        // Warehouse Population
        //
        private void PopulateWarehouse()
        {
            var column = this.Columns[this.colWarehouseId.Index] as DataGridViewComboBoxColumn;
            if (column != null)
            {
                column.DataSource = _inventoryService.GetWarehouseListForCombo();
                column.ValueMember = "Id";
                column.DisplayMember = "Name";
            }
        }
        //
        // Package Population
        //
        private void PopulatePackage()
        {
            var column = this.Columns[this.colPackageId.Index] as DataGridViewComboBoxColumn;
            if (column != null)
            {
                column.DataSource = _inventoryService.GetPackageListForCombo();
                column.ValueMember = "Id";
                column.DisplayMember = "Name";
            }
        }
        //
        // Supplier
        //
        private void PopulateSupplier()
        {
            var column = this.Columns[this.colSupplierId.Index] as DataGridViewComboBoxColumn;
            if (column != null)
            {
                column.DataSource = _inventoryService.GetSupplierListForCombo();
                column.ValueMember = "Id";
                column.DisplayMember = "Name";
            }
        }
        //
        // UOM
        //
        private void PopulateUom()
        {
            var column = this.Columns[this.colSupplierId.Index] as DataGridViewComboBoxColumn;
            if (column != null)
            {
                column.DataSource = _inventoryService.GetUomListForCombo();
                column.ValueMember = "Id";
                column.DisplayMember = "Name";
            }
        }
        
        public void AddRows(List<ViewModel.Core.Inventory.InventoryUnitModel> modelList)
        {
            var rowsEmpty = this.Rows.Count == 0;
            if (rowsEmpty) // at first load there aren't any rows hence we need to add manually to copy it in AddRow()
                this.Rows.Add();
            foreach (var m in modelList)
            {
                AddRow(m);
            }
            if(rowsEmpty)
                this.Rows.RemoveAt(0);
        }
        public void AddRow(ViewModel.Core.Inventory.InventoryUnitModel model)
        {
            
            if (this.Rows.Count > 0)
            {
                
                DataGridViewRow row = (DataGridViewRow)this.Rows[0].Clone();
                row.Cells[colId.Index].Value = model.Id;
                row.Cells[colProductId.Index].Value = model.ProductId;
                row.Cells[colSKU.Index].Value = model.SKU;
                row.Cells[colInStockQuantity.Index].Value = model.InStockQuantity;
                row.Cells[colOnHoldQuantity.Index].Value = model.OnHoldQuantity;
                row.Cells[colOnOrderQuantity.Index].Value = model.OnOrderQuantity;
                row.Cells[colOnComittedQuantity.Index].Value = model.OnComittedQuantity;
                row.Cells[colUnitQuantity.Index].Value = model.UnitQuantity;
                row.Cells[colUomId.Index].Value = model.UomId;
                row.Cells[colPackageId.Index].Value = model.PackageId;
                row.Cells[colPackageQuantity.Index].Value = model.PackageQuantity;
                row.Cells[colRate.Index].Value = model.Rate;
                row.Cells[colTotal.Index].Value = model.Total;
                row.Cells[colNetWeight.Index].Value = model.NetWeight;
                row.Cells[colGrossWeight.Index].Value = model.GrossWeight;
                row.Cells[colWarehouseId.Index].Value = model.WarehouseId;
                row.Cells[colWarehouse.Index].Value = model.Warehouse;
                row.Cells[colLotNumber.Index].Value = model.LotNumber;
                row.Cells[colProductionDate.Index].Value = model.ProductionDate;
                row.Cells[colExpirationDate.Index].Value = model.ExpirationDate;
                row.Cells[colReceiveDate.Index].Value = model.ReceiveDate;
                row.Cells[colReceiveReference.Index].Value = model.ReceiveReceipt;
                row.Cells[colReceiveAdjustment.Index].Value = model.ReceiveAdjustmentCode;
                row.Cells[colSupplierId.Index].Value = model.SupplierId;
                row.Cells[colIsHold.Index].Value = model.IsHold;
                row.Cells[colRemark.Index].Value = model.Remark;
                row.Cells[colNotes.Index].Value = model.Notes;
                this.Rows.Add(row);
            }
        }

    }
}
