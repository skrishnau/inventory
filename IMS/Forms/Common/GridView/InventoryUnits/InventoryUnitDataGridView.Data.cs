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
            //PopulateProduct();
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
            var column = this.Columns[this.colProductId.Index] as DataGridViewComboBoxColumn;
            if (column != null)
            {
                column.DataSource = _inventoryService.GetProductListForCombo();
                column.ValueMember = "Id";
                column.DisplayMember = "Name";
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

    }
}
