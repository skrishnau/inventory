namespace IMS.Forms.Purchases
{
    partial class PurchaseListUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvPurchases = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLotNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWarehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchases)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPurchases
            // 
            this.dgvPurchases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchases.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colOrderName,
            this.colOrderNumber,
            this.colLotNo,
            this.colWarehouse,
            this.colSupplier,
            this.colTotalAmount,
            this.colStatus});
            this.dgvPurchases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPurchases.Location = new System.Drawing.Point(0, 0);
            this.dgvPurchases.MultiSelect = false;
            this.dgvPurchases.Name = "dgvPurchases";
            this.dgvPurchases.ReadOnly = true;
            this.dgvPurchases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchases.Size = new System.Drawing.Size(642, 423);
            this.dgvPurchases.TabIndex = 1;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colOrderName
            // 
            this.colOrderName.DataPropertyName = "Name";
            this.colOrderName.HeaderText = "Name";
            this.colOrderName.Name = "colOrderName";
            this.colOrderName.ReadOnly = true;
            this.colOrderName.Width = 150;
            // 
            // colOrderNumber
            // 
            this.colOrderNumber.DataPropertyName = "OrderNumber";
            this.colOrderNumber.HeaderText = "Order No.";
            this.colOrderNumber.Name = "colOrderNumber";
            this.colOrderNumber.ReadOnly = true;
            this.colOrderNumber.Width = 120;
            // 
            // colLotNo
            // 
            this.colLotNo.DataPropertyName = "LotNumber";
            this.colLotNo.HeaderText = "Lot#";
            this.colLotNo.Name = "colLotNo";
            this.colLotNo.ReadOnly = true;
            // 
            // colWarehouse
            // 
            this.colWarehouse.DataPropertyName = "Warehouse";
            this.colWarehouse.HeaderText = "Warehouse";
            this.colWarehouse.Name = "colWarehouse";
            this.colWarehouse.ReadOnly = true;
            this.colWarehouse.Width = 150;
            // 
            // colSupplier
            // 
            this.colSupplier.DataPropertyName = "Supplier";
            this.colSupplier.HeaderText = "Supplier";
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.ReadOnly = true;
            this.colSupplier.Width = 150;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTotalAmount.DataPropertyName = "TotalAmount";
            this.colTotalAmount.HeaderText = "Total Amount";
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.ReadOnly = true;
            this.colTotalAmount.Width = 95;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // PurchaseListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvPurchases);
            this.Name = "PurchaseListUC";
            this.Size = new System.Drawing.Size(642, 423);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchases)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvPurchases;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLotNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWarehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}
