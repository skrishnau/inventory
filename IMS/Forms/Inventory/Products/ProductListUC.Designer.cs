﻿namespace IMS.Forms.Inventory.Products
{
    partial class ProductListUC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductListUC));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvProductList = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRetailPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInStockQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOnHoldQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBaseUom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReorderPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProductList
            // 
            this.dgvProductList.AllowUserToAddRows = false;
            this.dgvProductList.AllowUserToDeleteRows = false;
            this.dgvProductList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colSKU,
            this.colName,
            this.colCategory,
            this.colRetailPrice,
            this.colInStockQuantity,
            this.colOnHoldQuantity,
            this.colBaseUom,
            this.colPackage,
            this.colReorderPoint,
            this.colUse});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductList.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductList.Location = new System.Drawing.Point(0, 56);
            this.dgvProductList.Name = "dgvProductList";
            this.dgvProductList.ReadOnly = true;
            this.dgvProductList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductList.Size = new System.Drawing.Size(888, 428);
            this.dgvProductList.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(888, 53);
            this.panel1.TabIndex = 10;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnNew);
            this.flowLayoutPanel1.Controls.Add(this.btnEdit);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(339, 45);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnNew
            // 
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Image = global::IMS.Properties.Resources.icons8_Plus_Math_16px;
            this.btnNew.Location = new System.Drawing.Point(3, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(42, 40);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(51, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(42, 40);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 53);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(888, 3);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            this.colId.Width = 20;
            // 
            // colSKU
            // 
            this.colSKU.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSKU.DataPropertyName = "SKU";
            this.colSKU.HeaderText = "Code";
            this.colSKU.Name = "colSKU";
            this.colSKU.ReadOnly = true;
            this.colSKU.Width = 57;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colName.DefaultCellStyle = dataGridViewCellStyle14;
            this.colName.HeaderText = "Description";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 200;
            // 
            // colCategory
            // 
            this.colCategory.DataPropertyName = "Category";
            this.colCategory.HeaderText = "Category";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 85;
            // 
            // colRetailPrice
            // 
            this.colRetailPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRetailPrice.DataPropertyName = "RetailPrice";
            this.colRetailPrice.HeaderText = "Sales Price";
            this.colRetailPrice.Name = "colRetailPrice";
            this.colRetailPrice.ReadOnly = true;
            this.colRetailPrice.Width = 85;
            // 
            // colInStockQuantity
            // 
            this.colInStockQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colInStockQuantity.DataPropertyName = "InStockQuantity";
            this.colInStockQuantity.HeaderText = "In Stock";
            this.colInStockQuantity.Name = "colInStockQuantity";
            this.colInStockQuantity.ReadOnly = true;
            this.colInStockQuantity.Width = 72;
            // 
            // colOnHoldQuantity
            // 
            this.colOnHoldQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colOnHoldQuantity.DataPropertyName = "OnHoldQuantity";
            this.colOnHoldQuantity.HeaderText = "On Hold";
            this.colOnHoldQuantity.Name = "colOnHoldQuantity";
            this.colOnHoldQuantity.ReadOnly = true;
            this.colOnHoldQuantity.Width = 71;
            // 
            // colBaseUom
            // 
            this.colBaseUom.DataPropertyName = "BaseUom";
            this.colBaseUom.HeaderText = "UOM";
            this.colBaseUom.Name = "colBaseUom";
            this.colBaseUom.ReadOnly = true;
            this.colBaseUom.ToolTipText = "Units of Measure";
            this.colBaseUom.Width = 70;
            // 
            // colPackage
            // 
            this.colPackage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPackage.DataPropertyName = "Package";
            this.colPackage.HeaderText = "Pkg Type";
            this.colPackage.Name = "colPackage";
            this.colPackage.ReadOnly = true;
            this.colPackage.Width = 78;
            // 
            // colReorderPoint
            // 
            this.colReorderPoint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colReorderPoint.DataPropertyName = "ReorderPoint";
            this.colReorderPoint.HeaderText = "Reorder At";
            this.colReorderPoint.Name = "colReorderPoint";
            this.colReorderPoint.ReadOnly = true;
            this.colReorderPoint.Width = 83;
            // 
            // colUse
            // 
            this.colUse.DataPropertyName = "Use";
            this.colUse.HeaderText = "Use";
            this.colUse.Name = "colUse";
            this.colUse.ReadOnly = true;
            this.colUse.Width = 40;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 484);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(888, 27);
            this.panel2.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(17, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(16, 13);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Below Min. Stock";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Above Max. Stock";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Blue;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(147, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(16, 13);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // ProductListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvProductList);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "ProductListUC";
            this.Size = new System.Drawing.Size(888, 511);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvProductList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        protected internal System.Windows.Forms.Button btnNew;
        protected internal System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRetailPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInStockQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOnHoldQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBaseUom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReorderPoint;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUse;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
    }
}
