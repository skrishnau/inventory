namespace IMS.Forms.Inventory.Units.Actions
{
    partial class InventoryAdjustmentForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlAdjustmentCode = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAdjustmentCode = new System.Windows.Forms.ComboBox();
            this.dtReceiveDate = new System.Windows.Forms.DateTimePicker();
            this.pnlWarehouse = new System.Windows.Forms.TableLayoutPanel();
            this.cbWarehouse = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvInventoryUnit = new IMS.Forms.Common.GridView.InventoryUnits.InventoryUnitDataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlAdjustmentCode.SuspendLayout();
            this.pnlWarehouse.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryUnit)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 349F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 263F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tableLayoutPanel1.Controls.Add(this.pnlAdjustmentCode, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtReceiveDate, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlWarehouse, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(973, 34);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pnlAdjustmentCode
            // 
            this.pnlAdjustmentCode.ColumnCount = 2;
            this.pnlAdjustmentCode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.pnlAdjustmentCode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 193F));
            this.pnlAdjustmentCode.Controls.Add(this.label1, 0, 0);
            this.pnlAdjustmentCode.Controls.Add(this.cbAdjustmentCode, 1, 0);
            this.pnlAdjustmentCode.Location = new System.Drawing.Point(3, 3);
            this.pnlAdjustmentCode.Name = "pnlAdjustmentCode";
            this.pnlAdjustmentCode.RowCount = 1;
            this.pnlAdjustmentCode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlAdjustmentCode.Size = new System.Drawing.Size(270, 28);
            this.pnlAdjustmentCode.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ajustment Code";
            // 
            // cbAdjustmentCode
            // 
            this.cbAdjustmentCode.FormattingEnabled = true;
            this.cbAdjustmentCode.Location = new System.Drawing.Point(80, 3);
            this.cbAdjustmentCode.Name = "cbAdjustmentCode";
            this.cbAdjustmentCode.Size = new System.Drawing.Size(162, 21);
            this.cbAdjustmentCode.TabIndex = 8;
            // 
            // dtReceiveDate
            // 
            this.dtReceiveDate.Enabled = false;
            this.dtReceiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtReceiveDate.Location = new System.Drawing.Point(824, 3);
            this.dtReceiveDate.Name = "dtReceiveDate";
            this.dtReceiveDate.Size = new System.Drawing.Size(129, 20);
            this.dtReceiveDate.TabIndex = 5;
            // 
            // pnlWarehouse
            // 
            this.pnlWarehouse.ColumnCount = 2;
            this.pnlWarehouse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.pnlWarehouse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 255F));
            this.pnlWarehouse.Controls.Add(this.cbWarehouse, 1, 0);
            this.pnlWarehouse.Controls.Add(this.label2, 0, 0);
            this.pnlWarehouse.Location = new System.Drawing.Point(352, 3);
            this.pnlWarehouse.Name = "pnlWarehouse";
            this.pnlWarehouse.RowCount = 1;
            this.pnlWarehouse.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlWarehouse.Size = new System.Drawing.Size(257, 28);
            this.pnlWarehouse.TabIndex = 5;
            this.pnlWarehouse.Visible = false;
            // 
            // cbWarehouse
            // 
            this.cbWarehouse.FormattingEnabled = true;
            this.cbWarehouse.Location = new System.Drawing.Point(103, 3);
            this.cbWarehouse.Name = "cbWarehouse";
            this.cbWarehouse.Size = new System.Drawing.Size(146, 21);
            this.cbWarehouse.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Move to Warehouse";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(766, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Date";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(5, 408);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(973, 37);
            this.panel1.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(888, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(797, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Receive";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvInventoryUnit
            // 
            this.dgvInventoryUnit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventoryUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventoryUnit.Location = new System.Drawing.Point(5, 39);
            this.dgvInventoryUnit.Name = "dgvInventoryUnit";
            this.dgvInventoryUnit.Size = new System.Drawing.Size(973, 369);
            this.dgvInventoryUnit.TabIndex = 4;
            // 
            // InventoryAdjustmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(983, 450);
            this.Controls.Add(this.dgvInventoryUnit);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InventoryAdjustmentForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Direct Receive";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlAdjustmentCode.ResumeLayout(false);
            this.pnlAdjustmentCode.PerformLayout();
            this.pnlWarehouse.ResumeLayout(false);
            this.pnlWarehouse.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryUnit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtReceiveDate;
        private System.Windows.Forms.ComboBox cbAdjustmentCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private Common.GridView.InventoryUnits.InventoryUnitDataGridView dgvInventoryUnit;
        private System.Windows.Forms.ComboBox cbWarehouse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel pnlWarehouse;
        private System.Windows.Forms.TableLayoutPanel pnlAdjustmentCode;
    }
}