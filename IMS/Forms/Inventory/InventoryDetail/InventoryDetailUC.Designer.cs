namespace IMS.Forms.Inventory.InventoryDetail
{
    partial class InventoryDetailUC
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
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblSKU = new System.Windows.Forms.Label();
            this.dgvWarehouseProducts = new IMS.Forms.Common.GridView.DataGridViewCustom();
            this.dgvProductList = new IMS.Forms.Common.GridView.DataGridViewCustom();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOnHold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._heading = new IMS.Forms.Common.Display.ListHeaderTemplate();
            this.colWarehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInStock_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOnHold_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.pnlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouseProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDetail
            // 
            this.pnlDetail.Controls.Add(this.label3);
            this.pnlDetail.Controls.Add(this.splitter2);
            this.pnlDetail.Controls.Add(this.dgvWarehouseProducts);
            this.pnlDetail.Controls.Add(this.label4);
            this.pnlDetail.Controls.Add(this.splitter1);
            this.pnlDetail.Controls.Add(this.lblProduct);
            this.pnlDetail.Controls.Add(this.lblSKU);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetail.Location = new System.Drawing.Point(0, 13);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Padding = new System.Windows.Forms.Padding(5);
            this.pnlDetail.Size = new System.Drawing.Size(430, 417);
            this.pnlDetail.TabIndex = 1;
            this.pnlDetail.Visible = false;
            // 
            // lblProduct
            // 
            this.lblProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProduct.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.Location = new System.Drawing.Point(5, 25);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(420, 29);
            this.lblProduct.TabIndex = 0;
            this.lblProduct.Text = "label1";
            // 
            // lblSKU
            // 
            this.lblSKU.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSKU.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSKU.Location = new System.Drawing.Point(5, 5);
            this.lblSKU.Name = "lblSKU";
            this.lblSKU.Size = new System.Drawing.Size(420, 20);
            this.lblSKU.TabIndex = 1;
            this.lblSKU.Text = "label2";
            this.lblSKU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvWarehouseProducts
            // 
            this.dgvWarehouseProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvWarehouseProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWarehouseProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colWarehouse,
            this.colInStock_1,
            this.colOnHold_1});
            this.dgvWarehouseProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvWarehouseProducts.Location = new System.Drawing.Point(5, 92);
            this.dgvWarehouseProducts.MultiSelect = false;
            this.dgvWarehouseProducts.Name = "dgvWarehouseProducts";
            this.dgvWarehouseProducts.ReadOnly = true;
            this.dgvWarehouseProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWarehouseProducts.Size = new System.Drawing.Size(420, 118);
            this.dgvWarehouseProducts.TabIndex = 3;
            // 
            // dgvProductList
            // 
            this.dgvProductList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colSKU,
            this.colProduct,
            this.colInStock,
            this.colOnHold});
            this.dgvProductList.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvProductList.Location = new System.Drawing.Point(0, 13);
            this.dgvProductList.MultiSelect = false;
            this.dgvProductList.Name = "dgvProductList";
            this.dgvProductList.ReadOnly = true;
            this.dgvProductList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductList.Size = new System.Drawing.Size(456, 417);
            this.dgvProductList.TabIndex = 0;
            // 
            // colId
            // 
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colSKU
            // 
            this.colSKU.DataPropertyName = "SKU";
            this.colSKU.HeaderText = "Code";
            this.colSKU.Name = "colSKU";
            this.colSKU.ReadOnly = true;
            // 
            // colProduct
            // 
            this.colProduct.DataPropertyName = "Name";
            this.colProduct.HeaderText = "Description";
            this.colProduct.Name = "colProduct";
            this.colProduct.ReadOnly = true;
            this.colProduct.Width = 150;
            // 
            // colInStock
            // 
            this.colInStock.DataPropertyName = "InStockQuantity";
            this.colInStock.HeaderText = "In Stock";
            this.colInStock.Name = "colInStock";
            this.colInStock.ReadOnly = true;
            this.colInStock.Width = 80;
            // 
            // colOnHold
            // 
            this.colOnHold.DataPropertyName = "OnHoldQuantity";
            this.colOnHold.HeaderText = "On Hold";
            this.colOnHold.Name = "colOnHold";
            this.colOnHold.ReadOnly = true;
            this.colOnHold.Width = 80;
            // 
            // _heading
            // 
            this._heading.BackColor = System.Drawing.SystemColors.ControlLight;
            this._heading.Dock = System.Windows.Forms.DockStyle.Top;
            this._heading.HeadingText = "Heading";
            this._heading.Location = new System.Drawing.Point(0, 0);
            this._heading.Name = "_heading";
            this._heading.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this._heading.Size = new System.Drawing.Size(890, 32);
            this._heading.TabIndex = 2;
            // 
            // colWarehouse
            // 
            this.colWarehouse.DataPropertyName = "Warehouse";
            this.colWarehouse.HeaderText = "Warehouse";
            this.colWarehouse.Name = "colWarehouse";
            this.colWarehouse.ReadOnly = true;
            // 
            // colInStock_1
            // 
            this.colInStock_1.DataPropertyName = "InStockQuantity";
            this.colInStock_1.HeaderText = "In Stock";
            this.colInStock_1.Name = "colInStock_1";
            this.colInStock_1.ReadOnly = true;
            // 
            // colOnHold_1
            // 
            this.colOnHold_1.DataPropertyName = "OnHoldQuantity";
            this.colOnHold_1.HeaderText = "On Hold";
            this.colOnHold_1.Name = "colOnHold_1";
            this.colOnHold_1.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvProductList);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 430);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnlDetail);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(460, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(430, 430);
            this.panel2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(460, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Products";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(430, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Details";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(5, 220);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5);
            this.label3.Size = new System.Drawing.Size(420, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Units";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(5, 64);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5);
            this.label4.Size = new System.Drawing.Size(420, 28);
            this.label4.TabIndex = 5;
            this.label4.Text = "Warehouse Stocks";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(5, 54);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(420, 10);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(5, 210);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(420, 10);
            this.splitter2.TabIndex = 7;
            this.splitter2.TabStop = false;
            // 
            // InventoryDetailUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._heading);
            this.Name = "InventoryDetailUC";
            this.Size = new System.Drawing.Size(890, 462);
            this.pnlDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouseProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Common.GridView.DataGridViewCustom dgvProductList;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblSKU;
        private Common.GridView.DataGridViewCustom dgvWarehouseProducts;
        private Common.Display.ListHeaderTemplate _heading;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOnHold;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWarehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInStock_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOnHold_1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Splitter splitter1;
    }
}
