namespace IMS.Forms.Inventory.Units.Actions
{
    partial class InventoryMergeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvInventoryUnit = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInStockQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLotNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWarehouseId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWarehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsHold = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colExpirationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryUnit)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(652, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Resulting Inventory Units";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvInventoryUnit
            // 
            this.dgvInventoryUnit.AllowUserToAddRows = false;
            this.dgvInventoryUnit.AllowUserToDeleteRows = false;
            this.dgvInventoryUnit.AllowUserToOrderColumns = true;
            this.dgvInventoryUnit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventoryUnit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colCheck,
            this.colProductId,
            this.colProduct,
            this.colSKU,
            this.colInStockQuantity,
            this.colLotNumber,
            this.colWarehouseId,
            this.colWarehouse,
            this.colIsHold,
            this.colExpirationDate,
            this.colProductionDate});
            this.dgvInventoryUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventoryUnit.Location = new System.Drawing.Point(0, 30);
            this.dgvInventoryUnit.MultiSelect = false;
            this.dgvInventoryUnit.Name = "dgvInventoryUnit";
            this.dgvInventoryUnit.RowHeadersVisible = false;
            this.dgvInventoryUnit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventoryUnit.Size = new System.Drawing.Size(652, 225);
            this.dgvInventoryUnit.TabIndex = 4;
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
            this.colProduct.ReadOnly = true;
            this.colProduct.Width = 150;
            // 
            // colSKU
            // 
            this.colSKU.DataPropertyName = "SKU";
            this.colSKU.HeaderText = "SKU";
            this.colSKU.Name = "colSKU";
            this.colSKU.ReadOnly = true;
            // 
            // colInStockQuantity
            // 
            this.colInStockQuantity.DataPropertyName = "UnitQuantity";
            this.colInStockQuantity.HeaderText = "Units";
            this.colInStockQuantity.Name = "colInStockQuantity";
            this.colInStockQuantity.ReadOnly = true;
            // 
            // colLotNumber
            // 
            this.colLotNumber.DataPropertyName = "LotNumber";
            this.colLotNumber.HeaderText = "Lot #";
            this.colLotNumber.Name = "colLotNumber";
            this.colLotNumber.ReadOnly = true;
            this.colLotNumber.Width = 90;
            // 
            // colWarehouseId
            // 
            this.colWarehouseId.DataPropertyName = "WarehouseId";
            this.colWarehouseId.HeaderText = "WarehouseId";
            this.colWarehouseId.Name = "colWarehouseId";
            this.colWarehouseId.Visible = false;
            // 
            // colWarehouse
            // 
            this.colWarehouse.DataPropertyName = "Warehouse";
            this.colWarehouse.HeaderText = "Warehouse";
            this.colWarehouse.Name = "colWarehouse";
            this.colWarehouse.ReadOnly = true;
            this.colWarehouse.Width = 130;
            // 
            // colIsHold
            // 
            this.colIsHold.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colIsHold.DataPropertyName = "IsHold";
            this.colIsHold.HeaderText = "Hold";
            this.colIsHold.Name = "colIsHold";
            this.colIsHold.ReadOnly = true;
            this.colIsHold.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsHold.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsHold.Width = 54;
            // 
            // colExpirationDate
            // 
            this.colExpirationDate.DataPropertyName = "ExpirationDate";
            this.colExpirationDate.HeaderText = "Exp Date";
            this.colExpirationDate.Name = "colExpirationDate";
            this.colExpirationDate.ReadOnly = true;
            this.colExpirationDate.Width = 95;
            // 
            // colProductionDate
            // 
            this.colProductionDate.DataPropertyName = "ProductionDate";
            this.colProductionDate.HeaderText = "Prod Date";
            this.colProductionDate.Name = "colProductionDate";
            this.colProductionDate.ReadOnly = true;
            this.colProductionDate.Width = 95;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 277);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(652, 33);
            this.panel1.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(569, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(475, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Merge";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(0, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(652, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "Note: Units in the same warehouse are only merged.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InventoryMergeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 310);
            this.Controls.Add(this.dgvInventoryUnit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InventoryMergeForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Merge Inventory Units";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryUnit)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvInventoryUnit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInStockQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLotNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWarehouseId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWarehouse;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsHold;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpirationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductionDate;
        private System.Windows.Forms.Label label2;
    }
}