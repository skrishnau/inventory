namespace IMS.Forms.Inventory.Settings.Adjustments
{
    partial class AdjustmentCodeUC
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
            this.dgvAdj = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colAffectsDemand = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdj)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAdj
            // 
            this.dgvAdj.AllowUserToDeleteRows = false;
            this.dgvAdj.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvAdj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdj.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colType,
            this.colAffectsDemand,
            this.colUse});
            this.dgvAdj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAdj.Location = new System.Drawing.Point(0, 0);
            this.dgvAdj.Name = "dgvAdj";
            this.dgvAdj.Size = new System.Drawing.Size(509, 359);
            this.dgvAdj.TabIndex = 0;
            // 
            // colId
            // 
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colName
            // 
            this.colName.HeaderText = "Description";
            this.colName.Name = "colName";
            this.colName.Width = 200;
            // 
            // colType
            // 
            this.colType.HeaderText = "Adjustment Type";
            this.colType.Items.AddRange(new object[] {
            "Positive",
            "Negative"});
            this.colType.Name = "colType";
            // 
            // colAffectsDemand
            // 
            this.colAffectsDemand.HeaderText = "Affects Demand";
            this.colAffectsDemand.Name = "colAffectsDemand";
            // 
            // colUse
            // 
            this.colUse.HeaderText = "Use";
            this.colUse.Name = "colUse";
            // 
            // AdjustmentCodeUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvAdj);
            this.Name = "AdjustmentCodeUC";
            this.Size = new System.Drawing.Size(509, 359);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdj)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAdj;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAffectsDemand;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUse;
    }
}
