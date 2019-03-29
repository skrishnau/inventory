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
            this.dgvPurchases = new System.Windows.Forms.DataGridView();
            this.colReceiptNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIemsCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.colSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblReceiptNo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchases)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
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
            this.dgvPurchases.Location = new System.Drawing.Point(0, 0);
            this.dgvPurchases.MultiSelect = false;
            this.dgvPurchases.Name = "dgvPurchases";
            this.dgvPurchases.ReadOnly = true;
            this.dgvPurchases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchases.Size = new System.Drawing.Size(323, 423);
            this.dgvPurchases.TabIndex = 1;
            this.dgvPurchases.SelectionChanged += new System.EventHandler(this.dgvPurchases_SelectionChanged);
            // 
            // colReceiptNo
            // 
            this.colReceiptNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colReceiptNo.DataPropertyName = "ReceiptNo";
            this.colReceiptNo.HeaderText = "Receipt";
            this.colReceiptNo.Name = "colReceiptNo";
            this.colReceiptNo.ReadOnly = true;
            // 
            // colSupplier
            // 
            this.colSupplier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSupplier.DataPropertyName = "Supplier";
            this.colSupplier.HeaderText = "Supplier";
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.ReadOnly = true;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTotalAmount.DataPropertyName = "TotalAmount";
            this.colTotalAmount.HeaderText = "Total Amount";
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.ReadOnly = true;
            this.colTotalAmount.Width = 95;
            // 
            // colIemsCount
            // 
            this.colIemsCount.DataPropertyName = "ItemsCount";
            this.colIemsCount.HeaderText = "Items Count";
            this.colIemsCount.Name = "colIemsCount";
            this.colIemsCount.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvItems);
            this.panel2.Controls.Add(this.lblSupplier);
            this.panel2.Controls.Add(this.lblReceiptNo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(323, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(319, 423);
            this.panel2.TabIndex = 2;
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
            this.dgvItems.Size = new System.Drawing.Size(319, 365);
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
            // PurchaseListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvPurchases);
            this.Controls.Add(this.panel2);
            this.Name = "PurchaseListUC";
            this.Size = new System.Drawing.Size(642, 423);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchases)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
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
    }
}
