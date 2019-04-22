namespace IMS.Forms.Inventory.Units.Details
{
    partial class InventoryMovementUC
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
            this.dgvMovement = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdjustmentCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovement)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMovement
            // 
            this.dgvMovement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colDate,
            this.colReference,
            this.colAdjustmentCode,
            this.colQuantity,
            this.colDescription});
            this.dgvMovement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMovement.Location = new System.Drawing.Point(0, 0);
            this.dgvMovement.Name = "dgvMovement";
            this.dgvMovement.Size = new System.Drawing.Size(429, 335);
            this.dgvMovement.TabIndex = 0;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "Date";
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            // 
            // colReference
            // 
            this.colReference.DataPropertyName = "Reference";
            this.colReference.HeaderText = "Reference";
            this.colReference.Name = "colReference";
            // 
            // colAdjustmentCode
            // 
            this.colAdjustmentCode.DataPropertyName = "AdjustmentCode";
            this.colAdjustmentCode.HeaderText = "Adj Code";
            this.colAdjustmentCode.Name = "colAdjustmentCode";
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "Quantity";
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.Name = "colQuantity";
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 300;
            // 
            // InventoryMovementUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvMovement);
            this.Name = "InventoryMovementUC";
            this.Size = new System.Drawing.Size(429, 335);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMovement;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdjustmentCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
    }
}
