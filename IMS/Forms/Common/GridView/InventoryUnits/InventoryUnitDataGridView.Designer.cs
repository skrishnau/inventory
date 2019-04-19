﻿using Service.Core.Inventory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWarehouseId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            // this.colWarehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colLotNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceiveReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceiveAdjustment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceiveDate = new System.Windows.Forms.DataGridViewTextBoxColumn();

            //----------------- Issue Remaining -----------------//

            this.colUnitQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackageQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalSupplyAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNetWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrossWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colUomId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            // this.colUom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            // this.colPackage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackageId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colSupplierId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            // this.colSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colProductionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpirationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colInStockQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOnOrderQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOnHoldQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOnComittedQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colIsHold = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();


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
            this.colProductId,
            this.colProduct,
            this.colSKU,
            this.colInStockQuantity,
            this.colOnHoldQuantity,
            this.colOnOrderQuantity,
            this.colOnComittedQuantity,
            this.colUnitQuantity,
             this.colUomId,
           // this.colUom,
            this.colPackageId,
           // this.colPackage,
            this.colPackageQuantity,
            this.colSupplyPrice,
            this.colTotalSupplyAmount,
            this.colNetWeight,
            this.colGrossWeight,
            this.colWarehouseId,
           // this.colWarehouse,
            this.colLotNumber,
            this.colProductionDate,
            this.colExpirationDate,
            this.colReceiveDate,
            this.colReceiveReference,
            this.colReceiveAdjustment,
            this.colSupplierId,
            //this.colSupplier,
            this.colIsHold,
            this.colRemark,
            this.colNotes});
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
            // colProductId
            // 
            this.colProductId.DataPropertyName = "ProductId";
            this.colProductId.HeaderText = "ProductId";
            this.colProductId.Name = "colProductId";
            this.colProductId.Visible = false;
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
            //this.colWarehouse.DataPropertyName = "Warehouse";
            //this.colWarehouse.HeaderText = "Warehouse";
            //this.colWarehouse.Name = "colWarehouse";
            //this.colWarehouse.ReadOnly = true;
            //this.colWarehouse.Visible = false;
            //this.colWarehouse.Width = 130;
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
            this.colReceiveReference.DataPropertyName = "ReceiveReference";
            this.colReceiveReference.HeaderText = "Rcv Ref";
            this.colReceiveReference.Name = "colReceiveReference";
            this.colReceiveReference.Visible = false;
            this.colReceiveReference.Width = 80;
            // 
            // colReceiveAdjustment
            // 
            this.colReceiveAdjustment.DataPropertyName = "ReceiveAdjustment";
            this.colReceiveAdjustment.HeaderText = "Rcv Adj";
            this.colReceiveAdjustment.Name = "colReceiveAdjustment";
            this.colReceiveAdjustment.Visible = false;
            this.colReceiveAdjustment.Width = 90;
            // 
            // colReceiveDate
            // 
            this.colReceiveDate.DataPropertyName = "ReceiveDate";
            this.colReceiveDate.HeaderText = "Rcv Date";
            this.colReceiveDate.Name = "colReceiveDate";
            this.colReceiveDate.Visible = false;
            this.colReceiveDate.Width = 70;
            //-------------------- Issue Remaining -----------------//
            // 
            // colUnitQuantity
            // 
            this.colUnitQuantity.DataPropertyName = "UnitQuantity";
            this.colUnitQuantity.HeaderText = "Units";
            this.colUnitQuantity.Name = "colUnitQuantity";
            this.colUnitQuantity.Visible = false;
            this.colUnitQuantity.Width = 70;
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
            this.colPackageId.HeaderText = "Pkg";
            this.colPackageId.Name = "colPackageId";
            this.colPackageId.Visible = false;
            this.colPackageId.Width = 70;
            //// 
            //// colPackage
            //// 
            //this.colPackage.DataPropertyName = "Package";
            //this.colPackage.HeaderText = "Package";
            //this.colPackage.Name = "colPackage";
            //this.colPackage.Visible = false;
            //this.colPackage.Width = 40;
            // 
            // colSupplyPrice
            // 
            this.colSupplyPrice.DataPropertyName = "SupplyPrice";
            this.colSupplyPrice.HeaderText = "Unit Cost";
            this.colSupplyPrice.Name = "colSupplyPrice";
            this.colSupplyPrice.Visible = false;
            this.colSupplyPrice.Width = 70;
            // 
            // colTotalSupplyAmount
            // 
            this.colTotalSupplyAmount.DataPropertyName = "TotalSupplyAmount";
            this.colTotalSupplyAmount.HeaderText = "Amount";
            this.colTotalSupplyAmount.Name = "colTotalSupplyAmount";
            this.colTotalSupplyAmount.Visible = false;
            this.colTotalSupplyAmount.Width = 70;
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
            this.colUomId.DataPropertyName = "UomId";
            this.colUomId.HeaderText = "Uom Id";
            this.colUomId.Name = "colUomId";
            this.colUomId.Visible = false;
            this.colUomId.Width = 50;
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
            //this.colSupplier.DataPropertyName = "Supplier";
            //this.colSupplier.HeaderText = "Supplier";
            //this.colSupplier.Name = "colSupplier";
            //this.colSupplier.Visible = false;
            //this.colSupplier.Width = 40;
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
            this.colInStockQuantity.DataPropertyName = "UnitQuantity";
            this.colInStockQuantity.HeaderText = "In Stock";
            this.colInStockQuantity.Name = "colInStockQuantity";
            this.colInStockQuantity.Visible = false;
            this.colInStockQuantity.Width = 40;
            // 
            // colOnHoldQuantity
            // 
            this.colOnHoldQuantity.DataPropertyName = "OnHoldQuantity";
            this.colOnHoldQuantity.HeaderText = "On Hold";
            this.colOnHoldQuantity.Name = "colOnHoldQuantity";
            this.colOnHoldQuantity.Visible = false;
            this.colOnHoldQuantity.Width = 40;
            // 
            // colOnOrderQuantity
            // 
            this.colOnOrderQuantity.DataPropertyName = "OnOrderQuantity";
            this.colOnOrderQuantity.HeaderText = "On Order";
            this.colOnOrderQuantity.Name = "colOnOrderQuantity";
            this.colOnOrderQuantity.Visible = false;
            this.colOnOrderQuantity.Width = 40;
            // 
            // colOnComittedQuantity
            // 
            this.colOnComittedQuantity.DataPropertyName = "OnComittedQuantity";
            this.colOnComittedQuantity.HeaderText = "On Comitted";
            this.colOnComittedQuantity.Name = "colOnComittedQuantity";
            this.colOnComittedQuantity.Visible = false;
            this.colOnComittedQuantity.Width = 40;
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
            // this
            //
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region Design For

        public void DesignForInventoryUnitListing()
        {
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            colProduct.Visible = true;
            colSKU.Visible = true;
            colUnitQuantity.Visible = true;
            colPackageId.Visible = true;
            colWarehouseId.Visible = true;
            colLotNumber.Visible = true;
            colProductionDate.Visible = true;
            colExpirationDate.Visible = true;
            colReceiveReference.Visible = true;
            colReceiveReference.HeaderText = "Reference";
            colIsHold.Visible = true;

            MakeAllColumnsReadOnly();
            this.colCheck.ReadOnly = false;
        }
        //
        // PO Receive designs
        //
        public void DesignForPurchaseOrderReceive()
        {
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            colProduct.Visible = true;
            colSKU.Visible = true;
            colUnitQuantity.Visible = true;
            colPackageId.Visible = true;
            colWarehouseId.Visible = true;
            colLotNumber.Visible = true;
            colProductionDate.Visible = true;
            colExpirationDate.Visible = true;
            colReceiveReference.Visible = true;
            colReceiveReference.HeaderText = "Reference";
            colIsHold.Visible = true;
        }
        //
        // Direct Receive designs
        //
        public void DesignForDirectReceive()
        {
            this.RowHeadersVisible = true;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.AllowUserToAddRows = true;
            this.AllowUserToDeleteRows = true;
            colProduct.Visible = true;
            colSKU.Visible = true;
            colUnitQuantity.Visible = true;
            colPackageId.Visible = true;
            colPackageId.ReadOnly = true;
            colWarehouseId.Visible = true;
            colLotNumber.Visible = true;
            colProductionDate.Visible = true;
            colExpirationDate.Visible = true;
            colReceiveReference.Visible = true;
            colReceiveReference.HeaderText = "Reference";
            colIsHold.Visible = true;
            colRemark.Visible = true;
        }
        //
        // Direct Issue designs
        //
        public void DesignForDirectIssue()
        {
            this.RowHeadersVisible = true;
            this.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //this.AllowUserToAddRows = true;
            //this.AllowUserToDeleteRows = true;
            colProduct.Visible = true;
            colSKU.Visible = true;
            colUnitQuantity.Visible = true;
            colPackageQuantity.Visible = true;
            //colPackageId.Visible = true;
            //colPackageId.ReadOnly = true;
            colWarehouseId.Visible = true;
            colLotNumber.Visible = true;
            colProductionDate.Visible = true;
            colExpirationDate.Visible = true;
            colReceiveReference.Visible = true;
            colReceiveReference.HeaderText = "Reference";
            colReceiveDate.Visible = true;
            colRemark.Visible = true;

            MakeAllColumnsReadOnly();
            colUnitQuantity.ReadOnly = false;
            colPackageQuantity.ReadOnly = false;
        }

        private void MakeAllColumnsReadOnly()
        {
            foreach (DataGridViewColumn column in this.Columns)
            {
                column.ReadOnly = true;
            }
        }

        #endregion


        #region Columns

        public System.Windows.Forms.DataGridViewTextBoxColumn colId;
        public System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        public System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        public System.Windows.Forms.DataGridViewTextBoxColumn colProduct;
        public System.Windows.Forms.DataGridViewTextBoxColumn colSKU;


        public System.Windows.Forms.DataGridViewTextBoxColumn colReceiveDate;
        public System.Windows.Forms.DataGridViewTextBoxColumn colReceiveReference;
        public System.Windows.Forms.DataGridViewTextBoxColumn colReceiveAdjustment;

        public System.Windows.Forms.DataGridViewTextBoxColumn colUnitQuantity;
        public System.Windows.Forms.DataGridViewTextBoxColumn colPackageQuantity;
        public System.Windows.Forms.DataGridViewTextBoxColumn colSupplyPrice;
        public System.Windows.Forms.DataGridViewTextBoxColumn colTotalSupplyAmount;
        public System.Windows.Forms.DataGridViewTextBoxColumn colNetWeight;
        public System.Windows.Forms.DataGridViewTextBoxColumn colGrossWeight;

        public System.Windows.Forms.DataGridViewComboBoxColumn colUomId;
        //  public System.Windows.Forms.DataGridViewTextBoxColumn colUom;
        public System.Windows.Forms.DataGridViewComboBoxColumn colPackageId;
        // public System.Windows.Forms.DataGridViewTextBoxColumn colPackage;
        public System.Windows.Forms.DataGridViewComboBoxColumn colSupplierId;
        // public System.Windows.Forms.DataGridViewTextBoxColumn colSupplier;

        public System.Windows.Forms.DataGridViewTextBoxColumn colExpirationDate;
        public System.Windows.Forms.DataGridViewTextBoxColumn colProductionDate;

        public System.Windows.Forms.DataGridViewTextBoxColumn colInStockQuantity;
        public System.Windows.Forms.DataGridViewTextBoxColumn colOnHoldQuantity;
        public System.Windows.Forms.DataGridViewTextBoxColumn colOnOrderQuantity;
        public System.Windows.Forms.DataGridViewTextBoxColumn colOnComittedQuantity;
        public System.Windows.Forms.DataGridViewTextBoxColumn colLotNumber;
        public System.Windows.Forms.DataGridViewComboBoxColumn colWarehouseId;
        //public System.Windows.Forms.DataGridViewTextBoxColumn colWarehouse;

        public System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        public System.Windows.Forms.DataGridViewTextBoxColumn colNotes;
        public System.Windows.Forms.DataGridViewCheckBoxColumn colIsHold;

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