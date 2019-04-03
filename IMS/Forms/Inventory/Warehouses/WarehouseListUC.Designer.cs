namespace IMS.Forms.Inventory.Warehouses
{
    partial class WarehouseListUC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gvWarehouse = new System.Windows.Forms.DataGridView();
            this.Branch_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CanMoveStocksToBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvWarehouse)).BeginInit();
            this.SuspendLayout();
            // 
            // gvWarehouse
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvWarehouse.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvWarehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvWarehouse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Branch_ID,
            this.Code,
            this.CanMoveStocksToBranch});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvWarehouse.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvWarehouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvWarehouse.Location = new System.Drawing.Point(0, 0);
            this.gvWarehouse.Margin = new System.Windows.Forms.Padding(2);
            this.gvWarehouse.Name = "gvWarehouse";
            this.gvWarehouse.RowTemplate.Height = 24;
            this.gvWarehouse.Size = new System.Drawing.Size(452, 305);
            this.gvWarehouse.TabIndex = 4;
            // 
            // Branch_ID
            // 
            this.Branch_ID.DataPropertyName = "BranchId";
            this.Branch_ID.HeaderText = "BranchId";
            this.Branch_ID.Name = "Branch_ID";
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            // 
            // CanMoveStocksToBranch
            // 
            this.CanMoveStocksToBranch.DataPropertyName = "CanMoveStocksToBranch";
            this.CanMoveStocksToBranch.HeaderText = "CanMoveStocksToBranch";
            this.CanMoveStocksToBranch.Name = "CanMoveStocksToBranch";
            this.CanMoveStocksToBranch.Width = 150;
            // 
            // WarehouseListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gvWarehouse);
            this.Name = "WarehouseListUC";
            this.Size = new System.Drawing.Size(452, 305);
            ((System.ComponentModel.ISupportInitialize)(this.gvWarehouse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvWarehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn Branch_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn CanMoveStocksToBranch;
    }
}
