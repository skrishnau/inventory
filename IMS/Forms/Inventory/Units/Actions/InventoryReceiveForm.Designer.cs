namespace IMS.Forms.Inventory.Units.Actions
{
    partial class InventoryReceiveForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtReceiveDate = new System.Windows.Forms.DateTimePicker();
            this.cbAdjustmentCode = new System.Windows.Forms.ComboBox();
            this.dgvReceiveList = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackageId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUomId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWarehouse = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colLotNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProdDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdjustment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsHold = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiveList)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 477F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 322F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtReceiveDate, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbAdjustmentCode, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(973, 34);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ajustment Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(591, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Date";
            // 
            // dtReceiveDate
            // 
            this.dtReceiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtReceiveDate.Location = new System.Drawing.Point(654, 3);
            this.dtReceiveDate.Name = "dtReceiveDate";
            this.dtReceiveDate.Size = new System.Drawing.Size(129, 20);
            this.dtReceiveDate.TabIndex = 5;
            // 
            // cbAdjustmentCode
            // 
            this.cbAdjustmentCode.FormattingEnabled = true;
            this.cbAdjustmentCode.Location = new System.Drawing.Point(114, 3);
            this.cbAdjustmentCode.Name = "cbAdjustmentCode";
            this.cbAdjustmentCode.Size = new System.Drawing.Size(191, 21);
            this.cbAdjustmentCode.TabIndex = 8;
            // 
            // dgvReceiveList
            // 
            this.dgvReceiveList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceiveList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colProductId,
            this.colProduct,
            this.colSKU,
            this.colQuantity,
            this.colSupplyPrice,
            this.colTotalAmount,
            this.colPackageId,
            this.colPackage,
            this.colUomId,
            this.colWarehouse,
            this.colLotNumber,
            this.colProdDate,
            this.colExpDate,
            this.colReference,
            this.colAdjustment,
            this.colIsHold});
            this.dgvReceiveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReceiveList.Location = new System.Drawing.Point(5, 39);
            this.dgvReceiveList.Name = "dgvReceiveList";
            this.dgvReceiveList.Size = new System.Drawing.Size(973, 369);
            this.dgvReceiveList.TabIndex = 2;
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
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = false;
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
            this.colProduct.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colProduct.Width = 160;
            // 
            // colSKU
            // 
            this.colSKU.DataPropertyName = "SKU";
            this.colSKU.HeaderText = "SKU";
            this.colSKU.Name = "colSKU";
            this.colSKU.Width = 140;
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "UnitQuantity";
            this.colQuantity.HeaderText = "Units";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Width = 70;
            // 
            // colSupplyPrice
            // 
            this.colSupplyPrice.DataPropertyName = "SupplyPrice";
            this.colSupplyPrice.HeaderText = "Rate";
            this.colSupplyPrice.Name = "colSupplyPrice";
            this.colSupplyPrice.Visible = false;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.DataPropertyName = "TotalSupplyAmount";
            this.colTotalAmount.HeaderText = "Total";
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.Visible = false;
            // 
            // colPackageId
            // 
            this.colPackageId.DataPropertyName = "PackageId";
            this.colPackageId.HeaderText = "PackageId";
            this.colPackageId.Name = "colPackageId";
            this.colPackageId.Visible = false;
            // 
            // colPackage
            // 
            this.colPackage.DataPropertyName = "Package";
            this.colPackage.HeaderText = "Package";
            this.colPackage.Name = "colPackage";
            this.colPackage.ReadOnly = true;
            // 
            // colUomId
            // 
            this.colUomId.HeaderText = "Uom Id";
            this.colUomId.Name = "colUomId";
            this.colUomId.Visible = false;
            // 
            // colWarehouse
            // 
            this.colWarehouse.DataPropertyName = "WarehouseId";
            this.colWarehouse.HeaderText = "Warehouse";
            this.colWarehouse.Name = "colWarehouse";
            this.colWarehouse.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colWarehouse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colLotNumber
            // 
            this.colLotNumber.DataPropertyName = "LotNumber";
            this.colLotNumber.HeaderText = "Lot #";
            this.colLotNumber.Name = "colLotNumber";
            this.colLotNumber.Width = 60;
            // 
            // colProdDate
            // 
            this.colProdDate.DataPropertyName = "ProductionDate";
            this.colProdDate.HeaderText = "Prod. Date";
            this.colProdDate.Name = "colProdDate";
            this.colProdDate.Width = 80;
            // 
            // colExpDate
            // 
            this.colExpDate.DataPropertyName = "ExpirationDate";
            this.colExpDate.HeaderText = "Exp. Date";
            this.colExpDate.Name = "colExpDate";
            this.colExpDate.Width = 80;
            // 
            // colReference
            // 
            this.colReference.DataPropertyName = "ReceiveReceipt";
            this.colReference.HeaderText = "Reference";
            this.colReference.Name = "colReference";
            this.colReference.ReadOnly = true;
            // 
            // colAdjustment
            // 
            this.colAdjustment.DataPropertyName = "ReceiveAdjustment";
            this.colAdjustment.HeaderText = "Adjustment";
            this.colAdjustment.Name = "colAdjustment";
            this.colAdjustment.Visible = false;
            // 
            // colIsHold
            // 
            this.colIsHold.DataPropertyName = "IsHold";
            this.colIsHold.HeaderText = "Hold";
            this.colIsHold.Name = "colIsHold";
            this.colIsHold.Width = 35;
            // 
            // InventoryReceiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(983, 450);
            this.Controls.Add(this.dgvReceiveList);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InventoryReceiveForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Direct Receive";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiveList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtReceiveDate;
        private System.Windows.Forms.DataGridView dgvReceiveList;
        private System.Windows.Forms.ComboBox cbAdjustmentCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackageId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUomId;
        private System.Windows.Forms.DataGridViewComboBoxColumn colWarehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLotNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProdDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdjustment;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsHold;
    }
}