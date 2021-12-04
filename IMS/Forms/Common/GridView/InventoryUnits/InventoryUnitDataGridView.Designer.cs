using Service.Core.Inventory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Utility;

namespace IMS.Forms.Common.GridView.InventoryUnits
{
    public partial class InventoryUnitDataGridView
    {

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Columns Design

        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWarehouseId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colWarehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colLotNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceiveReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceiveAdjustment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceiveDate = new System.Windows.Forms.DataGridViewTextBoxColumn();

            //----------------- Issue Remaining -----------------//

            this.colUnitQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackageQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNetWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrossWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();

            //this.colUomId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            // this.colUom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackageId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPackage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplierId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colProductionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpirationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colInStockQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInStockQuantityWithPackage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOnOrderQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOnHoldQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOnComittedQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colIsHold = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colDelete = new System.Windows.Forms.DataGridViewImageColumn();

            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);

        }

        public void InitializeColumns()
        {

            // ----------- Assign -------------- //
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInventoryUnit
            // 
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToOrderColumns = true;
            this.AllowUserToResizeRows = false;
            this.AutoGenerateColumns = false;
            this.ColumnHeadersVisible = true;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colCheck,
            this.colDate,
            this.colProductId,
            this.colProduct,
            this.colSKU,
            this.colInStockQuantity,
            this.colInStockQuantityWithPackage,
            this.colOnHoldQuantity,
            this.colOnOrderQuantity,
            this.colOnComittedQuantity,
            this.colUnitQuantity,
            // this.colUomId,
           // this.colUom,
            this.colPackageId,
            this.colPackage,
            this.colPackageQuantity,
            this.colRate,
            this.colTotal,
            this.colNetWeight,
            this.colGrossWeight,
            this.colWarehouseId,
            this.colWarehouse,
            this.colLotNumber,
            this.colProductionDate,
            this.colExpirationDate,
            this.colReceiveDate,
            this.colReceiveReference,
            this.colReceiveAdjustment,
            this.colSupplierId,
            this.colSupplier,
            this.colIsHold,
            this.colRemark,
            this.colNotes,
            this.colDelete});
            // this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(100, 100);
            this.MultiSelect = false;
            this.Name = "dgvInventoryUnit";
            this.RowHeadersVisible = false;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // this.Size = new System.Drawing.Size(910, 209);
            this.TabIndex = 3;

            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "";
            this.colCheck.Name = "colCheck";
            this.colCheck.Visible = false;
            this.colCheck.Width = 30;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "DateString";
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colProduct";
            this.colDate.Visible = false;
            this.colDate.Width = 80;
            // 
            // colProductId
            // 
            this.colProductId.DataPropertyName = "ProductId";
            this.colProductId.HeaderText = "Product";
            this.colProductId.Name = "colProductId";
            this.colProductId.Visible = false;
            this.colProductId.Width = 150;
            //var comboBoxCell = new DataGridViewComboBoxCell();
            //comboBoxCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            //this.colProductId.CellTemplate = comboBoxCell;
            // 
            // colProduct
            // 
            this.colProduct.DataPropertyName = "Product";
            this.colProduct.HeaderText = "Product";
            this.colProduct.Name = "colProduct";
            this.colProduct.Visible = false;
            this.colProduct.Width = 150;
            // 
            // colSKU
            // 
            this.colSKU.DataPropertyName = "SKU";
            this.colSKU.HeaderText = "SKU";
            this.colSKU.Name = "colSKU";
            this.colSKU.Visible = false;
            this.colSKU.Width = 130;
            // 
            // colWarehouseId
            // 
            this.colWarehouseId.DataPropertyName = "WarehouseId";
            this.colWarehouseId.HeaderText = "Warehouse";
            this.colWarehouseId.Name = "colWarehouseId";
            this.colWarehouseId.Width = 90;
            this.colWarehouseId.Visible = false;
            //// 
            //// colWarehouse
            //// 
            this.colWarehouse.DataPropertyName = "Warehouse";
            this.colWarehouse.HeaderText = "Warehouse";
            this.colWarehouse.Name = "colWarehouse";
            this.colWarehouse.ReadOnly = true;
            this.colWarehouse.Visible = false;
            this.colWarehouse.Width = 90;
            // 
            // colLotNumber
            // 
            this.colLotNumber.DataPropertyName = "LotNumber";
            this.colLotNumber.HeaderText = "Lot #";
            this.colLotNumber.Name = "colLotNumber";
            this.colLotNumber.Visible = false;
            this.colLotNumber.Width = 60;
            // 
            // colReceiveReference
            // 
            this.colReceiveReference.DataPropertyName = "ReceiveReceipt";
            this.colReceiveReference.HeaderText = "Rcv Ref";
            this.colReceiveReference.Name = "colReceiveReceipt";
            this.colReceiveReference.Visible = false;
            this.colReceiveReference.Width = 80;
            // 
            // colReceiveAdjustment
            // 
            this.colReceiveAdjustment.DataPropertyName = "ReceiveAdjustmentCode";
            this.colReceiveAdjustment.HeaderText = "Rcv Adj";
            this.colReceiveAdjustment.Name = "colReceiveAdjustment";
            this.colReceiveAdjustment.Visible = false;
            this.colReceiveAdjustment.Width = 90;
            // 
            // colReceiveDate
            // 
            this.colReceiveDate.DataPropertyName = "ReceiveDateBS";
            this.colReceiveDate.HeaderText = "Rcv Date";
            this.colReceiveDate.Name = "colReceiveDate";
            this.colReceiveDate.Visible = false;
            this.colReceiveDate.Width = 70;
            //-------------------- Issue Remaining -----------------//
            // 
            // colUnitQuantity
            // 
            this.colUnitQuantity.DataPropertyName = "UnitQuantity";
            this.colUnitQuantity.HeaderText = "Qty.";
            this.colUnitQuantity.Name = "colUnitQuantity";
            this.colUnitQuantity.Visible = false;
            this.colUnitQuantity.Width = 70; // 
            // 
            // colPackageQuantity
            // 
            this.colPackageQuantity.DataPropertyName = "PackageQuantity";
            this.colPackageQuantity.HeaderText = "Pkg Qty";
            this.colPackageQuantity.Name = "colPackageQuantity";
            this.colPackageQuantity.Visible = false;
            this.colPackageQuantity.Width = 70;
            // 
            // colPackageId
            // 
            this.colPackageId.DataPropertyName = "PackageId";
            this.colPackageId.HeaderText = "Unit";
            this.colPackageId.Name = "colPackageId";
            this.colPackageId.Visible = false;
            this.colPackageId.Width = 70;
            //// 
            //// colPackage
            //// 
            this.colPackage.DataPropertyName = "Package";
            this.colPackage.HeaderText = "Unit";
            this.colPackage.Name = "colPackage";
            this.colPackage.Visible = false;
            this.colPackage.Width = 70;
            // 
            // colSupplyPrice
            // 
            this.colRate.DataPropertyName = "Rate";
            this.colRate.HeaderText = "Rate";
            this.colRate.Name = "colRate";
            this.colRate.Visible = false;
            this.colRate.Width = 70;
            // 
            // colTotalSupplyAmount
            // 
            this.colTotal.DataPropertyName = "Total";
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.Visible = false;
            this.colTotal.Width = 90;
            this.colTotal.ReadOnly = true;
            // 
            // colNetWeight
            // 
            this.colNetWeight.DataPropertyName = "NetWeight";
            this.colNetWeight.HeaderText = "Net Wt.";
            this.colNetWeight.Name = "colNetWeight";
            this.colNetWeight.Visible = false;
            this.colNetWeight.Width = 70;
            // 
            // colGrossWeight
            // 
            this.colGrossWeight.DataPropertyName = "GrossWeight";
            this.colGrossWeight.HeaderText = "Gross Wt.";
            this.colGrossWeight.Name = "colGrossWeight";
            this.colGrossWeight.Visible = false;
            this.colGrossWeight.Width = 70;
            // 
            // colUomId
            // 
            //this.colUomId.DataPropertyName = "UomId";
            //this.colUomId.HeaderText = "Uom Id";
            //this.colUomId.Name = "colUomId";
            //this.colUomId.Visible = false;
            //this.colUomId.Width = 50;
            //// 
            //// colUom
            //// 
            //this.colUom.DataPropertyName = "Uom";
            //this.colUom.HeaderText = "Uom";
            //this.colUom.Name = "colUom";
            //this.colUom.Visible = false;
            //this.colUom.Width = 40;
            // 
            // colSupplierId
            // 
            this.colSupplierId.DataPropertyName = "SupplierId";
            this.colSupplierId.HeaderText = "Supplier Id";
            this.colSupplierId.Name = "colSupplierId";
            this.colSupplierId.Visible = false;
            this.colSupplierId.Width = 50;
            //// 
            //// colSupplier
            //// 
            this.colSupplier.DataPropertyName = "Supplier";
            this.colSupplier.HeaderText = "Supplier";
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.Visible = false;
            this.colSupplier.Width = 70;
            // 
            // colProductionDate
            // 
            this.colProductionDate.DataPropertyName = "ProductionDate";
            this.colProductionDate.HeaderText = "Prod Date";
            this.colProductionDate.Name = "colProductionDate";
            this.colProductionDate.Visible = false;
            this.colProductionDate.Width = 80;
            // 
            // colExpirationDate
            // 
            this.colExpirationDate.DataPropertyName = "ExpirationDate";
            this.colExpirationDate.HeaderText = "Exp Date";
            this.colExpirationDate.Name = "colExpirationDate";
            this.colExpirationDate.Visible = false;
            this.colExpirationDate.Width = 80;
            // 
            // colInStockQuantity
            // 
            this.colInStockQuantity.DataPropertyName = "InStockQuantity";
            this.colInStockQuantity.HeaderText = "In Stock";
            this.colInStockQuantity.Name = "colInStockQuantity";
            this.colInStockQuantity.Visible = false;
            this.colInStockQuantity.Width = 70;
            this.colInStockQuantity.ReadOnly = true;
            // 
            // colInStockQuantityWithPackage
            // 
            this.colInStockQuantityWithPackage.DataPropertyName = "InStockQuantityWithPackage";
            this.colInStockQuantityWithPackage.HeaderText = "In Stock";
            this.colInStockQuantityWithPackage.Name = "colInStockQuantityWithPackage";
            this.colInStockQuantityWithPackage.Visible = false;
            this.colInStockQuantityWithPackage.Width = 70;
            this.colInStockQuantityWithPackage.ReadOnly = true;
            // 
            // colOnHoldQuantity
            // 
            this.colOnHoldQuantity.DataPropertyName = "OnHoldQuantity";
            this.colOnHoldQuantity.HeaderText = "On Hold";
            this.colOnHoldQuantity.Name = "colOnHoldQuantity";
            this.colOnHoldQuantity.Visible = false;
            this.colOnHoldQuantity.Width = 70;
            this.colOnHoldQuantity.ReadOnly = true;
            // 
            // colOnOrderQuantity
            // 
            this.colOnOrderQuantity.DataPropertyName = "OnOrderQuantity";
            this.colOnOrderQuantity.HeaderText = "On Order";
            this.colOnOrderQuantity.Name = "colOnOrderQuantity";
            this.colOnOrderQuantity.Visible = false;
            this.colOnOrderQuantity.Width = 70;
            this.colOnOrderQuantity.ReadOnly = true;
            // 
            // colOnComittedQuantity
            // 
            this.colOnComittedQuantity.DataPropertyName = "OnComittedQuantity";
            this.colOnComittedQuantity.HeaderText = "On Comitted";
            this.colOnComittedQuantity.Name = "colOnComittedQuantity";
            this.colOnComittedQuantity.Visible = false;
            this.colOnComittedQuantity.Width = 70;
            this.colOnComittedQuantity.ReadOnly = true;
            // 
            // colIsHold
            // 
            this.colIsHold.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colIsHold.DataPropertyName = "IsHold";
            this.colIsHold.HeaderText = "Hold";
            this.colIsHold.Name = "colIsHold";
            this.colIsHold.Visible = false;
            this.colIsHold.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsHold.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colRemark
            // 
            this.colRemark.DataPropertyName = "Remark";
            this.colRemark.HeaderText = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = false;
            this.colRemark.Width = 50;
            // 
            // colNotes
            // 
            this.colNotes.DataPropertyName = "Notes";
            this.colNotes.HeaderText = "Notes";
            this.colNotes.Name = "colNotes";
            this.colNotes.Visible = false;
            this.colNotes.Width = 50;

            // 
            // colDelete
            // 
            this.colDelete.DataPropertyName = "";
            this.colDelete.HeaderText = "";
            this.colDelete.Name = "colDelete";
            this.colDelete.Visible = false;
            this.colDelete.Width = 19;
            this.colDelete.Image = Properties.Resources.icons8_Delete_Red_16px;//global::IMS.Properties.Resources.icons8_Delete_Red_16px;
            this.colDelete.ImageLayout = DataGridViewImageCellLayout.Zoom;


            //
            // this
            //
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region Design For

        public void DisableAllExceptRate()
        {
            MakeAllColumnsReadOnly();
            colRate.ReadOnly = false;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            colDelete.Visible = false;
        }

        public void DesignForInventoryUnitListing()
        {
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //colProductId.Visible = true;
            colProduct.Visible = true;
            colSKU.Visible = true;
            colUnitQuantity.Visible = true;
            //colPackageId.Visible = true;
            //colWarehouseId.Visible = true;
            //colWarehouse.Visible = true;
            //colLotNumber.Visible = true;
            //colProductionDate.Visible = true;
            //colExpirationDate.Visible = true;
            //colReceiveReference.Visible = true;
            colReceiveReference.HeaderText = "Reference";
            colReceiveReference.Visible = true;

            colReceiveDate.Visible = true;

            colReceiveAdjustment.Visible = true;
            colRate.Visible = true;
            colSupplier.Visible = true;
            colPackage.Visible = true;
            colTotal.Visible = true;

            MakeAllColumnsReadOnly();
            this.colCheck.ReadOnly = false;


            // this.RowHeadersVisible = true;
            HideUnusedDefaults();


        }
        //
        // PO Receive designs
        //
        public void DesignForOrder(bool forEditMode)
        {
            SetEditMode(forEditMode);

            colProductId.Visible = true;
            colSKU.Visible = true;
            colUnitQuantity.Visible = true;
            //colPackageId.Visible = true;
            //colWarehouseId.Visible = true;
            //colWarehouse.Visible = true;
            //colLotNumber.Visible = true;
            //colProductionDate.Visible = true;
            //colExpirationDate.Visible = true;
            //colReceiveReference.Visible = true;
            //colReceiveReference.HeaderText = "Reference";
            colIsHold.Visible = true;
            colRate.Visible = true;
            colTotal.Visible = true;

            colInStockQuantity.Visible = true;
            //colOnHoldQuantity.Visible = true;

            HideUnusedDefaults();
        }

        private void SetEditMode(bool forEditMode)
        {
            _isEditable = forEditMode;
            if (forEditMode)
            {
                this.RowHeadersVisible = true;
                this.SelectionMode = DataGridViewSelectionMode.CellSelect;
                this.AllowUserToAddRows = true;
                this.AllowUserToDeleteRows = true;
                this.AllowUserToResizeRows = false;
                this.AllowUserToOrderColumns = false;
            }
            else
            {
                this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                MakeAllColumnsReadOnly();

            }
        }

        internal void DesignForTransactionCreate(bool forEditMode)
        {

            SetEditMode(forEditMode);
            //colProductId.Visible = true;
            colProduct.Visible = true;
            colSKU.Visible = true;
            colUnitQuantity.Visible = true;
            colRate.Visible = true;
            colTotal.Visible = true;
            colDelete.Visible = _isEditable;
            //colPackageId.Visible = true;
            colPackage.Visible = true;
            //colInStockQuantity.Visible = Constants.HAS_STOCK_MANAGEMENT;
            colInStockQuantityWithPackage.Visible = Constants.HAS_STOCK_MANAGEMENT;
            HideUnusedDefaults();
            colProduct.Width += 10;
            colSKU.Width += 10;
            colUnitQuantity.Width += 10;
            colRate.Width += 10;
            colTotal.Width += 10;
            colPackage.Width += 10;
            //colInStockQuantity.Width += 10;
            colInStockQuantityWithPackage.Width += 10;
        }

        internal void DesignForTransactionItemListing(bool forEditMode)
        {

            SetEditMode(forEditMode);
            //colProductId.Visible = true;
            colProduct.Visible = true;
            colSKU.Visible = true;
            colUnitQuantity.Visible = true;
            colRate.Visible = true;
            colTotal.Visible = true;
            colDelete.Visible = _isEditable;
            //colPackageId.Visible = true;
            colPackage.Visible = true;
            //colInStockQuantity.Visible = Constants.HAS_STOCK_MANAGEMENT;
            HideUnusedDefaults();
        }

        internal void DesignForMerging()
        {

            SetEditMode(false);
            //colProductId.Visible = true;
            colProduct.Visible = true;
            colSKU.Visible = true;
            colUnitQuantity.Visible = true;
            colRate.Visible = true;
            //colTotal.Visible = true;
            //colDelete.Visible = _isEditable;
            //colPackageId.Visible = true;
            colPackage.Visible = true;
            //colPackage.ReadOnly = false;
            //colInStockQuantity.Visible = Constants.HAS_STOCK_MANAGEMENT;
            HideUnusedDefaults();
        }

        //
        // Direct Receive designs
        //
        public void DesignForDirectReceive()
        {
            this.RowHeadersVisible = true;
            this.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.AllowUserToAddRows = true;
            this.AllowUserToDeleteRows = true;
            colProductId.Visible = true;
            colSKU.Visible = true;
            colUnitQuantity.Visible = true;
            colPackage.Visible = true;
            //colPackage.ReadOnly = true;
            //colPackageId.Visible = true;
            //colPackageId.ReadOnly = true;
            //colWarehouseId.Visible = true;
            // colWarehouse.Visible = true;
            //colLotNumber.Visible = true;
            //colProductionDate.Visible = true;
            //colExpirationDate.Visible = true;
            //colReceiveReference.Visible = true;
            //colReceiveReference.HeaderText = "Reference";
            //colIsHold.Visible = false;
            //colRemark.Visible = true;
            colInStockQuantity.Visible = true;
            colRate.Visible = true;
            HideUnusedDefaults();
        }
        //
        // Direct Issue of whole Inventory-Unit designs
        //
        public void DesignForDirectIssueInventoryUnit()
        {
            this.RowHeadersVisible = true;
            this.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //this.AllowUserToAddRows = true;
            //this.AllowUserToDeleteRows = true;
            colProduct.Visible = true;
            colSKU.Visible = true;
            colUnitQuantity.Visible = true;
            // colPackageQuantity.Visible = true;
            colPackage.Visible = true;
            colPackage.ReadOnly = true;
            //colPackageId.ReadOnly = true;
            //colWarehouseId.Visible = true;
            // colWarehouse.Visible = true;
            //colLotNumber.Visible = true;
            //colProductionDate.Visible = true;
            //colExpirationDate.Visible = true;
            //colReceiveReference.Visible = true;
            //colReceiveReference.HeaderText = "Reference";
            //colReceiveDate.Visible = true;
            //colRemark.Visible = true;
            //colIsHold.Visible = true;
            //colIsHold.ReadOnly = false;

            MakeAllColumnsReadOnly();
            colUnitQuantity.ReadOnly = false;
            colPackageQuantity.ReadOnly = false;

            HideUnusedDefaults();


        }

        //
        // Direct Issue of any product designs
        //
        public void DesignForDirectIssueAny()
        {
            this.RowHeadersVisible = true;
            this.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.AllowUserToAddRows = true;
            this.AllowUserToDeleteRows = true;
            colProductId.Visible = true;
            colSKU.Visible = true;
            colUnitQuantity.Visible = true;
            //colPackageId.Visible = true;
            //colPackageId.ReadOnly = true;
            //colWarehouseId.Visible = true;
            //colWarehouse.Visible = true;

            colInStockQuantity.Visible = true;
            // colLotNumber.Visible = true;
            // colProductionDate.Visible = true;
            // colExpirationDate.Visible = true;
            // colReceiveReference.Visible = true;
            //colReceiveReference.HeaderText = "Reference";
            // colIsHold.Visible = false;
            //colRemark.Visible = true;

            HideUnusedDefaults();

        }

        //
        // Direct Move designs
        //
        public void DesignForDirectMoveInventoryUnit()
        {
            this.RowHeadersVisible = true;
            this.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //this.AllowUserToAddRows = true;
            //this.AllowUserToDeleteRows = true;
            colProductId.Visible = true;
            colSKU.Visible = true;
            colUnitQuantity.Visible = true;
            colPackageQuantity.Visible = true;
            //colPackageId.Visible = true;
            //colPackageId.ReadOnly = true;
            //colWarehouseId.Visible = true;
            //colWarehouse.Visible = true;
            //colLotNumber.Visible = true;
            //colProductionDate.Visible = true;
            //colExpirationDate.Visible = true;
            //colReceiveReference.Visible = true;
            //colReceiveReference.HeaderText = "Reference";
            colReceiveDate.Visible = true;
            //colRemark.Visible = true;
            //colIsHold.Visible = true;
            //colIsHold.ReadOnly = true;

            MakeAllColumnsReadOnly();
            //colUnitQuantity.ReadOnly = false;
            //colPackageQuantity.ReadOnly = false;
            HideUnusedDefaults();
        }
        //
        // Direct Move designs
        //
        public void DesignForDirectMoveAny()
        {
            this.RowHeadersVisible = true;
            this.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.AllowUserToAddRows = true;
            this.AllowUserToDeleteRows = true;
            colProductId.Visible = true;
            colSKU.Visible = true;
            colUnitQuantity.Visible = true;
            colPackageQuantity.Visible = true;
            //colPackageId.Visible = true;
            //colPackageId.ReadOnly = true;
            //colWarehouseId.Visible = true;
            //colWarehouse.Visible = true;
            //colLotNumber.Visible = true;
            //colProductionDate.Visible = true;
            //colExpirationDate.Visible = true;
            //colReceiveReference.Visible = true;
            //colReceiveReference.HeaderText = "Reference";
            colReceiveDate.Visible = true;
            //colRemark.Visible = true;
            //colIsHold.Visible = true;
            //colIsHold.ReadOnly = true;

            // MakeAllColumnsReadOnly();
            //colUnitQuantity.ReadOnly = false;
            //colPackageQuantity.ReadOnly = false;
            HideUnusedDefaults();

        }
        public void DesignForPriceHistory(bool showDate, bool showProduct)
        {
            if (showDate)
                colDate.Visible = true;
            if (showProduct)
                colProduct.Visible = true;
            colRate.Visible = true;
            colPackage.Visible = true;

            colProduct.ReadOnly = true;
            colPackage.ReadOnly = true;
            colDate.ReadOnly = true;
            colRate.ReadOnly = true;
            this.SetSelectable(false);
            this.MakeAllColumnsReadOnly();
        }

        public void DesignForPriceHistoryCreate(bool showDate, bool showProduct)
        {
            if (showDate)
                colDate.Visible = true;
            if (showProduct)
                colProduct.Visible = true;
            colRate.Visible = true;
            colProduct.ReadOnly = true;
            colDate.ReadOnly = true;
            colPackage.Visible = true;
            colPackage.ReadOnly = true;
            
        }

        //
        // Direct Receive designs
        //
        public void DesignForManufactureProposedProducts()
        {
            _movementType = ViewModel.Enums.MovementTypeEnum.POReceive;
            this.RowHeadersVisible = true;
            this.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.AllowUserToAddRows = true;
            this.AllowUserToDeleteRows = true;
            colProductId.Visible = true;
            colSKU.Visible = true;
            colUnitQuantity.Visible = true;
            colPackage.Visible = true;
            colInStockQuantityWithPackage.Visible = false;
            colRate.Visible = false;
            colDelete.Visible = true;
            HideUnusedDefaults();
        }
        //
        // Consume Manufacture designs
        //
        public void DesignForUserManufactureConsume()
        {
            _quantityCanBeZero = true;
            _movementType = ViewModel.Enums.MovementTypeEnum.DirectIssueAny;
            this.RowHeadersVisible = true;
            this.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.AllowUserToAddRows = true;
            this.AllowUserToDeleteRows = true;
            colProduct.Visible = true;
            colSKU.Visible = true;
            colUnitQuantity.Visible = true;
            colPackageId.Visible = true;
            colInStockQuantityWithPackage.Visible = true;
            //colRate.Visible = false;
            colProduct.ReadOnly = true;
            colProductId.ReadOnly = true;
            AllowUserToAddRows = false;
            HideUnusedDefaults();
        }

        private void MakeAllColumnsReadOnly()
        {
            foreach (DataGridViewColumn column in this.Columns)
            {
                column.ReadOnly = true;
            }
        }

        private void HideUnusedDefaults()
        {
            this.colSKU.Visible = false;
        }


        #endregion


        #region Columns

        public System.Windows.Forms.DataGridViewTextBoxColumn colId;
        public System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        public System.Windows.Forms.DataGridViewComboBoxColumn colProductId;
        public System.Windows.Forms.DataGridViewTextBoxColumn colProduct;
        public System.Windows.Forms.DataGridViewTextBoxColumn colSKU;


        public System.Windows.Forms.DataGridViewTextBoxColumn colReceiveDate;
        public System.Windows.Forms.DataGridViewTextBoxColumn colReceiveReference;
        public System.Windows.Forms.DataGridViewTextBoxColumn colReceiveAdjustment;

        public System.Windows.Forms.DataGridViewTextBoxColumn colUnitQuantity;
        public System.Windows.Forms.DataGridViewTextBoxColumn colPackageQuantity;
        public System.Windows.Forms.DataGridViewTextBoxColumn colRate;
        public System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        public System.Windows.Forms.DataGridViewTextBoxColumn colNetWeight;
        public System.Windows.Forms.DataGridViewTextBoxColumn colGrossWeight;

        //public System.Windows.Forms.DataGridViewComboBoxColumn colUomId;
        //  public System.Windows.Forms.DataGridViewTextBoxColumn colUom;
        public System.Windows.Forms.DataGridViewComboBoxColumn colPackageId;
        public System.Windows.Forms.DataGridViewTextBoxColumn colPackage;
        public System.Windows.Forms.DataGridViewComboBoxColumn colSupplierId;
        public System.Windows.Forms.DataGridViewTextBoxColumn colSupplier;

        public System.Windows.Forms.DataGridViewTextBoxColumn colExpirationDate;
        public System.Windows.Forms.DataGridViewTextBoxColumn colProductionDate;

        public System.Windows.Forms.DataGridViewTextBoxColumn colInStockQuantity;
        public System.Windows.Forms.DataGridViewTextBoxColumn colInStockQuantityWithPackage;
        public System.Windows.Forms.DataGridViewTextBoxColumn colOnHoldQuantity;
        public System.Windows.Forms.DataGridViewTextBoxColumn colOnOrderQuantity;
        public System.Windows.Forms.DataGridViewTextBoxColumn colOnComittedQuantity;
        public System.Windows.Forms.DataGridViewTextBoxColumn colLotNumber;
        public System.Windows.Forms.DataGridViewComboBoxColumn colWarehouseId;
        /// <summary>
        /// Text Only Display 
        /// </summary>
        public System.Windows.Forms.DataGridViewTextBoxColumn colWarehouse;

        public System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        public System.Windows.Forms.DataGridViewTextBoxColumn colNotes;
        public System.Windows.Forms.DataGridViewCheckBoxColumn colIsHold;
        public System.Windows.Forms.DataGridViewImageColumn colDelete;


        // for rate / price history dispaly
        public System.Windows.Forms.DataGridViewTextBoxColumn colDate;

        #endregion

        //
        // Tooltip
        //
        public System.Windows.Forms.ToolTip toolTip1;
        //
        // DateTime Picker for Cells
        //
        DateTimePicker _dtPicker = new DateTimePicker();
        Rectangle _rectangle;



    }
}
