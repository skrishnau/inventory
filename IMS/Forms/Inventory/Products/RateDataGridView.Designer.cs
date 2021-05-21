namespace IMS.Forms.Inventory.Products
{
    partial class RateDataGridView
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
            this.dgvRates = new IMS.Forms.Common.GridView.InventoryUnits.InventoryUnitDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRates)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRates
            // 
            this.dgvRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRates.Location = new System.Drawing.Point(0, 0);
            this.dgvRates.Name = "dgvRates";
            this.dgvRates.Size = new System.Drawing.Size(506, 394);
            this.dgvRates.TabIndex = 14;
            // 
            // RateDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvRates);
            this.Name = "RateDataGridView";
            this.Size = new System.Drawing.Size(506, 394);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRates)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Common.GridView.InventoryUnits.InventoryUnitDataGridView dgvRates;
    }
}
