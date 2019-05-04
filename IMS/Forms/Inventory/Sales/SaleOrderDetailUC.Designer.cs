namespace IMS.Forms.Inventory.Sales
{
    partial class SaleOrderDetailUC
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
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.lblLotNumber = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOnOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsHold = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblSupplierInvoice = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblExpectedDate = new System.Windows.Forms.Label();
            this.lblNoItemsMessage = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnBackToList = new System.Windows.Forms.LinkLabel();
            this.pnlButtonsHeader = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.btnSendOrder = new System.Windows.Forms.Button();
            this.btnPartialReceive = new System.Windows.Forms.Button();
            this.btnReceive = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnEditDetails = new System.Windows.Forms.Button();
            this.btnEditItems = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlButtonsHeader.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(278, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Supplier Invoice";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Order No.";
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Location = new System.Drawing.Point(84, 0);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(35, 13);
            this.lblOrderNumber.TabIndex = 16;
            this.lblOrderNumber.Text = "label7";
            // 
            // lblLotNumber
            // 
            this.lblLotNumber.AutoSize = true;
            this.lblLotNumber.Location = new System.Drawing.Point(84, 23);
            this.lblLotNumber.Name = "lblLotNumber";
            this.lblLotNumber.Size = new System.Drawing.Size(35, 13);
            this.lblLotNumber.TabIndex = 17;
            this.lblLotNumber.Text = "label7";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colProduct,
            this.colSKU,
            this.colInStock,
            this.colOnOrder,
            this.colQuantity,
            this.colRate,
            this.colTotal,
            this.colIsHold});
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 190);
            this.dgvItems.Margin = new System.Windows.Forms.Padding(2);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(622, 201);
            this.dgvItems.TabIndex = 17;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colProduct
            // 
            this.colProduct.DataPropertyName = "Product";
            this.colProduct.HeaderText = "Product";
            this.colProduct.Name = "colProduct";
            this.colProduct.ReadOnly = true;
            this.colProduct.Width = 200;
            // 
            // colSKU
            // 
            this.colSKU.DataPropertyName = "SKU";
            this.colSKU.HeaderText = "SKU";
            this.colSKU.Name = "colSKU";
            this.colSKU.ReadOnly = true;
            this.colSKU.Width = 150;
            // 
            // colInStock
            // 
            this.colInStock.DataPropertyName = "InStock";
            this.colInStock.HeaderText = "In Stock";
            this.colInStock.Name = "colInStock";
            this.colInStock.ReadOnly = true;
            // 
            // colOnOrder
            // 
            this.colOnOrder.DataPropertyName = "OnOrder";
            this.colOnOrder.HeaderText = "On Order";
            this.colOnOrder.Name = "colOnOrder";
            this.colOnOrder.ReadOnly = true;
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "Quantity";
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            // 
            // colRate
            // 
            this.colRate.DataPropertyName = "Rate";
            this.colRate.HeaderText = "Rate";
            this.colRate.Name = "colRate";
            this.colRate.ReadOnly = true;
            // 
            // colTotal
            // 
            this.colTotal.DataPropertyName = "TotalAmount";
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // colIsHold
            // 
            this.colIsHold.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colIsHold.DataPropertyName = "IsHold";
            this.colIsHold.HeaderText = "Hold ?";
            this.colIsHold.Name = "colIsHold";
            this.colIsHold.ReadOnly = true;
            this.colIsHold.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsHold.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsHold.Width = 63;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.SlateGray;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 182);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(622, 8);
            this.splitter1.TabIndex = 14;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 99);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(622, 83);
            this.panel2.TabIndex = 18;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 194F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 353F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblOrderNumber, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblLotNumber, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblWarehouse, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblSupplier, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblSupplierInvoice, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblExpectedDate, 3, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(602, 71);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lot #";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Warehouse";
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new System.Drawing.Point(84, 46);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(35, 13);
            this.lblWarehouse.TabIndex = 18;
            this.lblWarehouse.Text = "label7";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(372, 0);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(35, 13);
            this.lblSupplier.TabIndex = 19;
            this.lblSupplier.Text = "label7";
            // 
            // lblSupplierInvoice
            // 
            this.lblSupplierInvoice.AutoSize = true;
            this.lblSupplierInvoice.Location = new System.Drawing.Point(372, 23);
            this.lblSupplierInvoice.Name = "lblSupplierInvoice";
            this.lblSupplierInvoice.Size = new System.Drawing.Size(35, 13);
            this.lblSupplierInvoice.TabIndex = 20;
            this.lblSupplierInvoice.Text = "label7";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(277, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Expected Date";
            // 
            // lblExpectedDate
            // 
            this.lblExpectedDate.AutoSize = true;
            this.lblExpectedDate.Location = new System.Drawing.Point(372, 46);
            this.lblExpectedDate.Name = "lblExpectedDate";
            this.lblExpectedDate.Size = new System.Drawing.Size(35, 13);
            this.lblExpectedDate.TabIndex = 22;
            this.lblExpectedDate.Text = "label7";
            // 
            // lblNoItemsMessage
            // 
            this.lblNoItemsMessage.AutoSize = true;
            this.lblNoItemsMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNoItemsMessage.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNoItemsMessage.Location = new System.Drawing.Point(56, 0);
            this.lblNoItemsMessage.Name = "lblNoItemsMessage";
            this.lblNoItemsMessage.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblNoItemsMessage.Size = new System.Drawing.Size(283, 23);
            this.lblNoItemsMessage.TabIndex = 11;
            this.lblNoItemsMessage.Text = "There aren\'t any items. Please add items to send the order.";
            this.lblNoItemsMessage.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblNoItemsMessage);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 69);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(622, 30);
            this.panel3.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(56, 30);
            this.label4.TabIndex = 12;
            this.label4.Text = "Items";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.btnBackToList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(622, 31);
            this.panel1.TabIndex = 15;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(56, 5);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(51, 20);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "label2";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(5, 5);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "label1";
            // 
            // btnBackToList
            // 
            this.btnBackToList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBackToList.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnBackToList.Location = new System.Drawing.Point(549, 5);
            this.btnBackToList.Name = "btnBackToList";
            this.btnBackToList.Size = new System.Drawing.Size(68, 21);
            this.btnBackToList.TabIndex = 2;
            this.btnBackToList.TabStop = true;
            this.btnBackToList.Text = "Back to list...";
            this.btnBackToList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlButtonsHeader
            // 
            this.pnlButtonsHeader.BackColor = System.Drawing.Color.Lavender;
            this.pnlButtonsHeader.Controls.Add(this.flowLayoutPanel2);
            this.pnlButtonsHeader.Controls.Add(this.flowLayoutPanel1);
            this.pnlButtonsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtonsHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlButtonsHeader.Name = "pnlButtonsHeader";
            this.pnlButtonsHeader.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pnlButtonsHeader.Size = new System.Drawing.Size(622, 38);
            this.pnlButtonsHeader.TabIndex = 16;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnCancelOrder);
            this.flowLayoutPanel2.Controls.Add(this.btnSendOrder);
            this.flowLayoutPanel2.Controls.Add(this.btnPartialReceive);
            this.flowLayoutPanel2.Controls.Add(this.btnReceive);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(248, 5);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(364, 28);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelOrder.Location = new System.Drawing.Point(259, 3);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(102, 23);
            this.btnCancelOrder.TabIndex = 9;
            this.btnCancelOrder.Text = "Cancel Order";
            this.btnCancelOrder.UseVisualStyleBackColor = false;
            // 
            // btnSendOrder
            // 
            this.btnSendOrder.BackColor = System.Drawing.SystemColors.Control;
            this.btnSendOrder.Location = new System.Drawing.Point(160, 3);
            this.btnSendOrder.Name = "btnSendOrder";
            this.btnSendOrder.Size = new System.Drawing.Size(93, 23);
            this.btnSendOrder.TabIndex = 8;
            this.btnSendOrder.Text = "Send Order";
            this.btnSendOrder.UseVisualStyleBackColor = false;
            // 
            // btnPartialReceive
            // 
            this.btnPartialReceive.BackColor = System.Drawing.SystemColors.Control;
            this.btnPartialReceive.Location = new System.Drawing.Point(42, 3);
            this.btnPartialReceive.Name = "btnPartialReceive";
            this.btnPartialReceive.Size = new System.Drawing.Size(112, 23);
            this.btnPartialReceive.TabIndex = 3;
            this.btnPartialReceive.Text = "Partial Receive";
            this.btnPartialReceive.UseVisualStyleBackColor = false;
            this.btnPartialReceive.Visible = false;
            // 
            // btnReceive
            // 
            this.btnReceive.BackColor = System.Drawing.SystemColors.Control;
            this.btnReceive.Location = new System.Drawing.Point(280, 32);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(81, 23);
            this.btnReceive.TabIndex = 2;
            this.btnReceive.Text = "Receive";
            this.btnReceive.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnEditDetails);
            this.flowLayoutPanel1.Controls.Add(this.btnEditItems);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(238, 28);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnEditDetails
            // 
            this.btnEditDetails.Location = new System.Drawing.Point(3, 3);
            this.btnEditDetails.Name = "btnEditDetails";
            this.btnEditDetails.Size = new System.Drawing.Size(99, 23);
            this.btnEditDetails.TabIndex = 0;
            this.btnEditDetails.Text = "Edit Details";
            this.btnEditDetails.UseVisualStyleBackColor = true;
            // 
            // btnEditItems
            // 
            this.btnEditItems.Location = new System.Drawing.Point(108, 3);
            this.btnEditItems.Name = "btnEditItems";
            this.btnEditItems.Size = new System.Drawing.Size(119, 23);
            this.btnEditItems.TabIndex = 1;
            this.btnEditItems.Text = "Edit Product Items";
            this.btnEditItems.UseVisualStyleBackColor = true;
            // 
            // SaleOrderDetailUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlButtonsHeader);
            this.Name = "SaleOrderDetailUC";
            this.Size = new System.Drawing.Size(622, 391);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlButtonsHeader.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label lblLotNumber;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOnOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsHold;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblSupplierInvoice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblExpectedDate;
        private System.Windows.Forms.Label lblNoItemsMessage;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblName;
        protected internal System.Windows.Forms.LinkLabel btnBackToList;
        private System.Windows.Forms.Panel pnlButtonsHeader;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Button btnSendOrder;
        private System.Windows.Forms.Button btnPartialReceive;
        private System.Windows.Forms.Button btnReceive;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnEditDetails;
        private System.Windows.Forms.Button btnEditItems;
    }
}
