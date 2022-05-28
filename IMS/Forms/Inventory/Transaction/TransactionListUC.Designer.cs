namespace IMS.Forms.Inventory.Transaction
{
    partial class TransactionListUC
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionListUC));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlNewTransaction = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPurchaseTransaction = new System.Windows.Forms.Button();
            this.btnSaleTransaction = new System.Windows.Forms.Button();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchReceiptNo = new System.Windows.Forms.TextBox();
            this.lblSearchClient = new System.Windows.Forms.Label();
            this.txtSearchClient = new System.Windows.Forms.TextBox();
            this.rbPurchase = new System.Windows.Forms.RadioButton();
            this.rbSale = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.pnlTransactionActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrint = new IMS.Forms.Common.Buttons.MenuButton();
            this.btnView = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.colOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompletedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscountPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaidAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvItems = new IMS.Forms.Common.GridView.InventoryUnits.InventoryUnitDataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblReferenceNo = new System.Windows.Forms.Label();
            this.pnlEditedOrder = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnViewParentOrder = new System.Windows.Forms.Button();
            this.listHeaderTemplate1 = new IMS.Forms.Common.Display.ListHeaderTemplate();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdvanceSearch = new System.Windows.Forms.LinkLabel();
            this.chkAdvanceSearch = new System.Windows.Forms.CheckBox();
            this.lblAdvanceSearchData = new System.Windows.Forms.Label();
            this.pnlNewTransaction.SuspendLayout();
            this.pnlTransactionActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.panel5.SuspendLayout();
            this.pnlEditedOrder.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 69);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1076, 3);
            this.splitter1.TabIndex = 15;
            this.splitter1.TabStop = false;
            // 
            // pnlNewTransaction
            // 
            this.pnlNewTransaction.Controls.Add(this.btnPurchaseTransaction);
            this.pnlNewTransaction.Controls.Add(this.btnSaleTransaction);
            this.pnlNewTransaction.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlNewTransaction.Location = new System.Drawing.Point(798, 0);
            this.pnlNewTransaction.Name = "pnlNewTransaction";
            this.pnlNewTransaction.Size = new System.Drawing.Size(263, 36);
            this.pnlNewTransaction.TabIndex = 3;
            this.pnlNewTransaction.Visible = false;
            // 
            // btnPurchaseTransaction
            // 
            this.btnPurchaseTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPurchaseTransaction.BackColor = System.Drawing.SystemColors.Control;
            this.btnPurchaseTransaction.FlatAppearance.BorderSize = 0;
            this.btnPurchaseTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchaseTransaction.Image = global::IMS.Properties.Resources.icons8_In_Transit_plus_24px;
            this.btnPurchaseTransaction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPurchaseTransaction.Location = new System.Drawing.Point(135, 3);
            this.btnPurchaseTransaction.Name = "btnPurchaseTransaction";
            this.btnPurchaseTransaction.Size = new System.Drawing.Size(125, 28);
            this.btnPurchaseTransaction.TabIndex = 52;
            this.btnPurchaseTransaction.Text = "  New Purchase";
            this.btnPurchaseTransaction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPurchaseTransaction.UseVisualStyleBackColor = false;
            // 
            // btnSaleTransaction
            // 
            this.btnSaleTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaleTransaction.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaleTransaction.FlatAppearance.BorderSize = 0;
            this.btnSaleTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaleTransaction.Image = global::IMS.Properties.Resources.icons8_Sell_Stock_plus_24px;
            this.btnSaleTransaction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaleTransaction.Location = new System.Drawing.Point(27, 3);
            this.btnSaleTransaction.Name = "btnSaleTransaction";
            this.btnSaleTransaction.Size = new System.Drawing.Size(102, 28);
            this.btnSaleTransaction.TabIndex = 51;
            this.btnSaleTransaction.Text = "  New Sale";
            this.btnSaleTransaction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaleTransaction.UseVisualStyleBackColor = false;
            // 
            // cbProduct
            // 
            this.cbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProduct.FormattingEnabled = true;
            this.cbProduct.Location = new System.Drawing.Point(53, 3);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(121, 21);
            this.cbProduct.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Product";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Search Receipt No.";
            // 
            // txtSearchReceiptNo
            // 
            this.txtSearchReceiptNo.Location = new System.Drawing.Point(110, 3);
            this.txtSearchReceiptNo.Name = "txtSearchReceiptNo";
            this.txtSearchReceiptNo.Size = new System.Drawing.Size(108, 20);
            this.txtSearchReceiptNo.TabIndex = 10;
            // 
            // lblSearchClient
            // 
            this.lblSearchClient.AutoSize = true;
            this.lblSearchClient.Location = new System.Drawing.Point(3, 6);
            this.lblSearchClient.Name = "lblSearchClient";
            this.lblSearchClient.Size = new System.Drawing.Size(70, 13);
            this.lblSearchClient.TabIndex = 9;
            this.lblSearchClient.Text = "Search Client";
            // 
            // txtSearchClient
            // 
            this.txtSearchClient.Location = new System.Drawing.Point(89, 3);
            this.txtSearchClient.Name = "txtSearchClient";
            this.txtSearchClient.Size = new System.Drawing.Size(108, 20);
            this.txtSearchClient.TabIndex = 8;
            // 
            // rbPurchase
            // 
            this.rbPurchase.AutoSize = true;
            this.rbPurchase.Location = new System.Drawing.Point(134, 5);
            this.rbPurchase.Name = "rbPurchase";
            this.rbPurchase.Size = new System.Drawing.Size(70, 17);
            this.rbPurchase.TabIndex = 3;
            this.rbPurchase.Text = "Purchase";
            this.rbPurchase.UseVisualStyleBackColor = true;
            // 
            // rbSale
            // 
            this.rbSale.AutoSize = true;
            this.rbSale.Location = new System.Drawing.Point(82, 5);
            this.rbSale.Name = "rbSale";
            this.rbSale.Size = new System.Drawing.Size(46, 17);
            this.rbSale.TabIndex = 2;
            this.rbSale.Text = "Sale";
            this.rbSale.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Type";
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(40, 5);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(36, 17);
            this.rbAll.TabIndex = 0;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "All";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // pnlTransactionActions
            // 
            this.pnlTransactionActions.Controls.Add(this.btnPrint);
            this.pnlTransactionActions.Controls.Add(this.btnView);
            this.pnlTransactionActions.Controls.Add(this.btnEdit);
            this.pnlTransactionActions.Controls.Add(this.btnCancel);
            this.pnlTransactionActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTransactionActions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlTransactionActions.Location = new System.Drawing.Point(0, 0);
            this.pnlTransactionActions.Name = "pnlTransactionActions";
            this.pnlTransactionActions.Padding = new System.Windows.Forms.Padding(0, 2, 5, 0);
            this.pnlTransactionActions.Size = new System.Drawing.Size(441, 38);
            this.pnlTransactionActions.TabIndex = 17;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.Location = new System.Drawing.Point(337, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(96, 28);
            this.btnPrint.TabIndex = 16;
            this.btnPrint.Text = "Print Receipt";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnView.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Image = global::IMS.Properties.Resources.icons8_eye_16;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.Location = new System.Drawing.Point(226, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(105, 28);
            this.btnView.TabIndex = 18;
            this.btnView.Text = "View";
            this.btnView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnView.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.Location = new System.Drawing.Point(115, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(105, 28);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::IMS.Properties.Resources.icons8_Delete_16px_Dark;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(37, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 28);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // dgvOrders
            // 
            this.dgvOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderNumber,
            this.colCreatedDate,
            this.colCompletedDate,
            this.colOrderType,
            this.colCustomer,
            this.colTotalAmount,
            this.colDiscountPercent,
            this.colPaidAmount,
            this.colDeliveryDate,
            this.colStatus});
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.Location = new System.Drawing.Point(0, 0);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(630, 420);
            this.dgvOrders.TabIndex = 13;
            // 
            // colOrderNumber
            // 
            this.colOrderNumber.DataPropertyName = "ReferenceNumber";
            this.colOrderNumber.HeaderText = "Receipt No.";
            this.colOrderNumber.Name = "colOrderNumber";
            this.colOrderNumber.ReadOnly = true;
            this.colOrderNumber.Width = 120;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.DataPropertyName = "UpdatedAtBS";
            this.colCreatedDate.HeaderText = "Updated On";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.ReadOnly = true;
            this.colCreatedDate.Width = 80;
            // 
            // colCompletedDate
            // 
            this.colCompletedDate.DataPropertyName = "CompletedDateBS";
            this.colCompletedDate.HeaderText = "Checkout Date";
            this.colCompletedDate.Name = "colCompletedDate";
            this.colCompletedDate.ReadOnly = true;
            // 
            // colOrderType
            // 
            this.colOrderType.DataPropertyName = "OrderType";
            this.colOrderType.HeaderText = "Type";
            this.colOrderType.Name = "colOrderType";
            this.colOrderType.ReadOnly = true;
            this.colOrderType.Width = 80;
            // 
            // colCustomer
            // 
            this.colCustomer.DataPropertyName = "User";
            this.colCustomer.HeaderText = "Customer";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            this.colCustomer.Width = 150;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTotalAmount.DataPropertyName = "TotalAmount";
            this.colTotalAmount.HeaderText = "Total Amount";
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.ReadOnly = true;
            this.colTotalAmount.Width = 87;
            // 
            // colDiscountPercent
            // 
            this.colDiscountPercent.DataPropertyName = "DiscountString";
            this.colDiscountPercent.HeaderText = "Discount";
            this.colDiscountPercent.Name = "colDiscountPercent";
            this.colDiscountPercent.ReadOnly = true;
            this.colDiscountPercent.Width = 80;
            // 
            // colPaidAmount
            // 
            this.colPaidAmount.DataPropertyName = "PaidAmount";
            this.colPaidAmount.HeaderText = "Paid Amount";
            this.colPaidAmount.Name = "colPaidAmount";
            this.colPaidAmount.ReadOnly = true;
            // 
            // colDeliveryDate
            // 
            this.colDeliveryDate.DataPropertyName = "DeliveryDateBS";
            this.colDeliveryDate.HeaderText = "Delivery Date";
            this.colDeliveryDate.Name = "colDeliveryDate";
            this.colDeliveryDate.ReadOnly = true;
            this.colDeliveryDate.Width = 80;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 70;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvOrders);
            this.panel2.Controls.Add(this.bindingNavigator1);
            this.panel2.Controls.Add(this.splitter2);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1076, 445);
            this.panel2.TabIndex = 16;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 420);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(630, 25);
            this.bindingNavigator1.TabIndex = 17;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(630, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(5, 445);
            this.splitter2.TabIndex = 15;
            this.splitter2.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvItems);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.pnlEditedOrder);
            this.panel4.Controls.Add(this.pnlTransactionActions);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(635, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(441, 445);
            this.panel4.TabIndex = 16;
            // 
            // dgvItems
            // 
            this.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 102);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.OrderId = 0;
            this.dgvItems.Size = new System.Drawing.Size(441, 343);
            this.dgvItems.TabIndex = 14;
            // 
            // panel5
            // 
            this.panel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel5.Controls.Add(this.lblCustomer);
            this.panel5.Controls.Add(this.lblReferenceNo);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 63);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(441, 39);
            this.panel5.TabIndex = 15;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCustomer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(0, 19);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(11, 13);
            this.lblCustomer.TabIndex = 18;
            this.lblCustomer.Text = "-";
            // 
            // lblReferenceNo
            // 
            this.lblReferenceNo.AutoSize = true;
            this.lblReferenceNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblReferenceNo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblReferenceNo.Location = new System.Drawing.Point(0, 0);
            this.lblReferenceNo.Name = "lblReferenceNo";
            this.lblReferenceNo.Size = new System.Drawing.Size(15, 19);
            this.lblReferenceNo.TabIndex = 0;
            this.lblReferenceNo.Text = "-";
            // 
            // pnlEditedOrder
            // 
            this.pnlEditedOrder.Controls.Add(this.label3);
            this.pnlEditedOrder.Controls.Add(this.btnViewParentOrder);
            this.pnlEditedOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEditedOrder.Location = new System.Drawing.Point(0, 38);
            this.pnlEditedOrder.Name = "pnlEditedOrder";
            this.pnlEditedOrder.Size = new System.Drawing.Size(441, 25);
            this.pnlEditedOrder.TabIndex = 19;
            this.pnlEditedOrder.Visible = false;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Font = new System.Drawing.Font("Rod", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(252, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Edited";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnViewParentOrder
            // 
            this.btnViewParentOrder.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnViewParentOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewParentOrder.Location = new System.Drawing.Point(321, 0);
            this.btnViewParentOrder.Name = "btnViewParentOrder";
            this.btnViewParentOrder.Size = new System.Drawing.Size(120, 25);
            this.btnViewParentOrder.TabIndex = 0;
            this.btnViewParentOrder.Text = "View Parent Txn";
            this.btnViewParentOrder.UseVisualStyleBackColor = true;
            // 
            // listHeaderTemplate1
            // 
            this.listHeaderTemplate1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listHeaderTemplate1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listHeaderTemplate1.HeadingText = "Transactions";
            this.listHeaderTemplate1.Location = new System.Drawing.Point(0, 0);
            this.listHeaderTemplate1.Name = "listHeaderTemplate1";
            this.listHeaderTemplate1.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.listHeaderTemplate1.Size = new System.Drawing.Size(1076, 35);
            this.listHeaderTemplate1.TabIndex = 17;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.panel7);
            this.flowLayoutPanel1.Controls.Add(this.panel8);
            this.flowLayoutPanel1.Controls.Add(this.panel9);
            this.flowLayoutPanel1.Controls.Add(this.panel6);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.chkAdvanceSearch);
            this.flowLayoutPanel1.Controls.Add(this.lblAdvanceSearchData);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 35);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1076, 34);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label1);
            this.panel7.Controls.Add(this.rbAll);
            this.panel7.Controls.Add(this.rbSale);
            this.panel7.Controls.Add(this.rbPurchase);
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(221, 28);
            this.panel7.TabIndex = 19;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lblSearchClient);
            this.panel8.Controls.Add(this.txtSearchClient);
            this.panel8.Location = new System.Drawing.Point(230, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(200, 28);
            this.panel8.TabIndex = 19;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.txtSearchReceiptNo);
            this.panel9.Controls.Add(this.label2);
            this.panel9.Location = new System.Drawing.Point(436, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(223, 28);
            this.panel9.TabIndex = 19;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cbProduct);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Location = new System.Drawing.Point(665, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(179, 28);
            this.panel6.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAdvanceSearch);
            this.panel1.Location = new System.Drawing.Point(850, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(97, 24);
            this.panel1.TabIndex = 19;
            // 
            // btnAdvanceSearch
            // 
            this.btnAdvanceSearch.AutoSize = true;
            this.btnAdvanceSearch.Location = new System.Drawing.Point(3, 5);
            this.btnAdvanceSearch.Name = "btnAdvanceSearch";
            this.btnAdvanceSearch.Size = new System.Drawing.Size(87, 13);
            this.btnAdvanceSearch.TabIndex = 18;
            this.btnAdvanceSearch.TabStop = true;
            this.btnAdvanceSearch.Text = "Advance Search";
            // 
            // chkAdvanceSearch
            // 
            this.chkAdvanceSearch.AutoSize = true;
            this.chkAdvanceSearch.Location = new System.Drawing.Point(953, 3);
            this.chkAdvanceSearch.Name = "chkAdvanceSearch";
            this.chkAdvanceSearch.Size = new System.Drawing.Size(15, 14);
            this.chkAdvanceSearch.TabIndex = 20;
            this.chkAdvanceSearch.UseVisualStyleBackColor = true;
            // 
            // lblAdvanceSearchData
            // 
            this.lblAdvanceSearchData.AutoSize = true;
            this.lblAdvanceSearchData.Location = new System.Drawing.Point(974, 0);
            this.lblAdvanceSearchData.Name = "lblAdvanceSearchData";
            this.lblAdvanceSearchData.Size = new System.Drawing.Size(0, 13);
            this.lblAdvanceSearchData.TabIndex = 21;
            // 
            // TransactionListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlNewTransaction);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.listHeaderTemplate1);
            this.Name = "TransactionListUC";
            this.Size = new System.Drawing.Size(1076, 517);
            this.pnlNewTransaction.ResumeLayout(false);
            this.pnlTransactionActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.pnlEditedOrder.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.FlowLayoutPanel pnlNewTransaction;
        protected internal System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Panel panel2;
        private Common.GridView.InventoryUnits.InventoryUnitDataGridView dgvItems;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.RadioButton rbPurchase;
        private System.Windows.Forms.RadioButton rbSale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblReferenceNo;
        private Common.Display.ListHeaderTemplate listHeaderTemplate1;
        private Common.Buttons.MenuButton btnPrint;
        private System.Windows.Forms.FlowLayoutPanel pnlTransactionActions;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        protected internal System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSearchClient;
        private System.Windows.Forms.TextBox txtSearchClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearchReceiptNo;
        private System.Windows.Forms.Panel pnlEditedOrder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnViewParentOrder;
        protected internal System.Windows.Forms.Button btnPurchaseTransaction;
        protected internal System.Windows.Forms.Button btnSaleTransaction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompletedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscountPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaidAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.CheckBox chkAdvanceSearch;
        private System.Windows.Forms.Label lblAdvanceSearchData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel btnAdvanceSearch;
        protected internal System.Windows.Forms.Button btnView;
    }
}
