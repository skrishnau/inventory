namespace IMS.Forms.Inventory.UOM
{
    partial class UomUC
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
            this.dgvUom = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBaseUnitId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBaseUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUom)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUom
            // 
            this.dgvUom.AllowUserToDeleteRows = false;
            this.dgvUom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colUnit,
            this.colQuantity,
            this.colBaseUnitId,
            this.colBaseUnit,
            this.colUse});
            this.dgvUom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUom.Location = new System.Drawing.Point(0, 0);
            this.dgvUom.Name = "dgvUom";
            this.dgvUom.Size = new System.Drawing.Size(551, 362);
            this.dgvUom.TabIndex = 0;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colUnit
            // 
            this.colUnit.DataPropertyName = "Unit";
            this.colUnit.HeaderText = "Unit Of Measure";
            this.colUnit.Name = "colUnit";
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "Quantity";
            this.colQuantity.HeaderText = "Contains";
            this.colQuantity.Name = "colQuantity";
            // 
            // colBaseUnitId
            // 
            this.colBaseUnitId.DataPropertyName = "BaseUnitId";
            this.colBaseUnitId.HeaderText = "BaseUnitId";
            this.colBaseUnitId.Name = "colBaseUnitId";
            this.colBaseUnitId.Visible = false;
            // 
            // colBaseUnit
            // 
            this.colBaseUnit.DataPropertyName = "BaseUnit";
            this.colBaseUnit.HeaderText = "Of Base Unit";
            this.colBaseUnit.Name = "colBaseUnit";
            // 
            // colUse
            // 
            this.colUse.DataPropertyName = "Use";
            this.colUse.HeaderText = "Use";
            this.colUse.Name = "colUse";
            this.colUse.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colUse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // UomUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvUom);
            this.Name = "UomUC";
            this.Size = new System.Drawing.Size(551, 362);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBaseUnitId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBaseUnit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUse;
    }
}
