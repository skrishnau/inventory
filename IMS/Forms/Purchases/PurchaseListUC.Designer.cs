namespace IMS.Forms.Purchases
{
    partial class PurchaseListUC
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNewPurchaseOrder = new System.Windows.Forms.Button();
            this.dgvPurchases = new System.Windows.Forms.DataGridView();
            this.colReceiptNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIemsCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblReceiptNo = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.colSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchases)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNewPurchaseOrder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 38);
            this.panel1.TabIndex = 0;
            // 
            // btnNewPurchaseOrder
            // 
            this.btnNewPurchaseOrder.Location = new System.Drawing.Point(10, 8);
            this.btnNewPurchaseOrder.Name = "btnNewPurchaseOrder";
            this.btnNewPurchaseOrder.Size = new System.Drawing.Size(142, 23);
            this.btnNewPurchaseOrder.TabIndex = 1;
            this.btnNewPurchaseOrder.Text = "New Purchase Order";
            this.btnNewPurchaseOrder.UseVisualStyleBackColor = true;
            this.btnNewPurchaseOrder.Click += new System.EventHandler(this.btnNewPurchaseOrder_Click);
            // 
            // dgvPurchases
            // 
            this.dgvPurchases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchases.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colReceiptNo,
            this.colSupplier,
            this.colTotalAmount,
            this.colIemsCount});
            this.dgvPurchases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPurchases.Location = new System.Drawing.Point(5, 80);
            this.dgvPurchases.MultiSelect = false;
            this.dgvPurchases.Name = "dgvPurchases";
            this.dgvPurchases.ReadOnly = true;
            this.dgvPurchases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchases.Size = new System.Drawing.Size(313, 338);
            this.dgvPurchases.TabIndex = 1;
            this.dgvPurchases.SelectionChanged += new System.EventHandler(this.dgvPurchases_SelectionChanged);
            // 
            // colReceiptNo
            // 
            this.colReceiptNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colReceiptNo.DataPropertyName = "ReceiptNo";
            this.colReceiptNo.HeaderText = "Receipt";
            this.colReceiptNo.Name = "colReceiptNo";
            // 
            // colSupplier
            // 
            this.colSupplier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSupplier.DataPropertyName = "Supplier";
            this.colSupplier.HeaderText = "Supplier";
            this.colSupplier.Name = "colSupplier";
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTotalAmount.DataPropertyName = "TotalAmount";
            this.colTotalAmount.HeaderText = "Total Amount";
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.Width = 95;
            // 
            // colIemsCount
            // 
            this.colIemsCount.DataPropertyName = "ItemsCount";
            this.colIemsCount.HeaderText = "Items Count";
            this.colIemsCount.Name = "colIemsCount";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvItems);
            this.panel2.Controls.Add(this.lblSupplier);
            this.panel2.Controls.Add(this.lblReceiptNo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(318, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(319, 338);
            this.panel2.TabIndex = 2;
            // 
            // lblReceiptNo
            // 
            this.lblReceiptNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblReceiptNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiptNo.Location = new System.Drawing.Point(0, 0);
            this.lblReceiptNo.Name = "lblReceiptNo";
            this.lblReceiptNo.Size = new System.Drawing.Size(319, 38);
            this.lblReceiptNo.TabIndex = 0;
            this.lblReceiptNo.Text = "label2";
            this.lblReceiptNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSupplier
            // 
            this.lblSupplier.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplier.Location = new System.Drawing.Point(0, 38);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(319, 20);
            this.lblSupplier.TabIndex = 1;
            this.lblSupplier.Text = "label2";
            this.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvItems
            // 
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSKU,
            this.colProduct,
            this.colRate,
            this.colQuantity,
            this.coTotalAmount});
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Enabled = false;
            this.dgvItems.Location = new System.Drawing.Point(0, 58);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(319, 280);
            this.dgvItems.TabIndex = 2;
            // 
            // colSKU
            // 
            this.colSKU.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSKU.DataPropertyName = "SKU";
            this.colSKU.HeaderText = "SKU";
            this.colSKU.Name = "colSKU";
            // 
            // colProduct
            // 
            this.colProduct.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProduct.DataPropertyName = "Product";
            this.colProduct.HeaderText = "Product";
            this.colProduct.Name = "colProduct";
            // 
            // colRate
            // 
            this.colRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRate.DataPropertyName = "Rate";
            this.colRate.HeaderText = "Rate";
            this.colRate.Name = "colRate";
            this.colRate.Width = 55;
            // 
            // colQuantity
            // 
            this.colQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colQuantity.DataPropertyName = "Quantity";
            this.colQuantity.HeaderText = "Qty.";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Width = 51;
            // 
            // coTotalAmount
            // 
            this.coTotalAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.coTotalAmount.DataPropertyName = "TotalAmount";
            this.coTotalAmount.HeaderText = "Amt.";
            this.coTotalAmount.Name = "coTotalAmount";
            this.coTotalAmount.Width = 53;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(5, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(632, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "Purchases";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PurchaseListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvPurchases);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Name = "PurchaseListUC";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(642, 423);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchases)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNewPurchaseOrder;
        private System.Windows.Forms.DataGridView dgvPurchases;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceiptNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIemsCount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblReceiptNo;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn coTotalAmount;
        private System.Windows.Forms.Label label2;
    }
}
