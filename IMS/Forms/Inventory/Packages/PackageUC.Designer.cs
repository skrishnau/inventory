namespace IMS.Forms.Inventory.Packages
{
    partial class PackageUC
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
            this.dgvPackage = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackage)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPackage
            // 
            this.dgvPackage.AllowUserToDeleteRows = false;
            this.dgvPackage.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPackage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPackage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colUse});
            this.dgvPackage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPackage.Location = new System.Drawing.Point(0, 0);
            this.dgvPackage.Name = "dgvPackage";
            this.dgvPackage.Size = new System.Drawing.Size(448, 345);
            this.dgvPackage.TabIndex = 0;
            // 
            // colId
            // 
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colName
            // 
            this.colName.HeaderText = "Package Type";
            this.colName.Name = "colName";
            this.colName.Width = 180;
            // 
            // colUse
            // 
            this.colUse.HeaderText = "Use";
            this.colUse.Name = "colUse";
            this.colUse.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colUse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // PackageUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvPackage);
            this.Name = "PackageUC";
            this.Size = new System.Drawing.Size(448, 345);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPackage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUse;
    }
}
