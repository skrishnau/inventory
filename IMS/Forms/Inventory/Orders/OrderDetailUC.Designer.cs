namespace IMS.Forms.Inventory.Purchases
{
    partial class OrderDetailUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderDetailUC));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.btnBackToList = new System.Windows.Forms.Button();
            this.pnlButtonsHeader = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancelOrder = new IMS.Forms.Common.Buttons.MenuButton();
            this.btnSendOrder = new IMS.Forms.Common.Buttons.MenuButton();
            this.btnPartialReceive = new IMS.Forms.Common.Buttons.MenuButton();
            this.btnReceive = new IMS.Forms.Common.Buttons.MenuButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnEditDetails = new IMS.Forms.Common.Buttons.MenuButton();
            this.btnEditItems = new IMS.Forms.Common.Buttons.MenuButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblOrderNumber1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblExpectedDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLotNumber = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblSupplierInvoice = new System.Windows.Forms.Label();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.tblCustomer = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tblSupplier = new System.Windows.Forms.TableLayoutPanel();
            this.lblNoItemsMessage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.pnlButtonsHeader.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.panel2.SuspendLayout();
            this.tblCustomer.SuspendLayout();
            this.tblSupplier.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.lblOrderNumber);
            this.panel1.Controls.Add(this.btnBackToList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(1044, 31);
            this.panel1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.panel1, "Back to list");
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(84, 5);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(51, 20);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "label2";
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNumber.Location = new System.Drawing.Point(33, 5);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(51, 20);
            this.lblOrderNumber.TabIndex = 3;
            this.lblOrderNumber.Text = "label1";
            // 
            // btnBackToList
            // 
            this.btnBackToList.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBackToList.Location = new System.Drawing.Point(5, 5);
            this.btnBackToList.Name = "btnBackToList";
            this.btnBackToList.Size = new System.Drawing.Size(28, 21);
            this.btnBackToList.TabIndex = 4;
            this.btnBackToList.Text = "<--";
            this.btnBackToList.UseVisualStyleBackColor = true;
            // 
            // pnlButtonsHeader
            // 
            this.pnlButtonsHeader.BackColor = System.Drawing.SystemColors.Window;
            this.pnlButtonsHeader.Controls.Add(this.flowLayoutPanel2);
            this.pnlButtonsHeader.Controls.Add(this.flowLayoutPanel1);
            this.pnlButtonsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtonsHeader.Location = new System.Drawing.Point(0, 31);
            this.pnlButtonsHeader.Name = "pnlButtonsHeader";
            this.pnlButtonsHeader.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.pnlButtonsHeader.Size = new System.Drawing.Size(1044, 67);
            this.pnlButtonsHeader.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnCancelOrder);
            this.flowLayoutPanel2.Controls.Add(this.btnSendOrder);
            this.flowLayoutPanel2.Controls.Add(this.btnPartialReceive);
            this.flowLayoutPanel2.Controls.Add(this.btnReceive);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(243, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(796, 63);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancelOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelOrder.Image = global::IMS.Properties.Resources.icons8_Delete_16px_Dark;
            this.btnCancelOrder.Location = new System.Drawing.Point(733, 3);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(60, 55);
            this.btnCancelOrder.TabIndex = 12;
            this.btnCancelOrder.Text = "Cancel Order";
            this.btnCancelOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelOrder.UseVisualStyleBackColor = true;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // btnSendOrder
            // 
            this.btnSendOrder.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnSendOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendOrder.Image = global::IMS.Properties.Resources.icons8_Forward_Arrow_16px;
            this.btnSendOrder.Location = new System.Drawing.Point(667, 3);
            this.btnSendOrder.Name = "btnSendOrder";
            this.btnSendOrder.Size = new System.Drawing.Size(60, 55);
            this.btnSendOrder.TabIndex = 11;
            this.btnSendOrder.Text = "Send Order";
            this.btnSendOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSendOrder.UseVisualStyleBackColor = true;
            this.btnSendOrder.Click += new System.EventHandler(this.btnSendOrder_Click);
            // 
            // btnPartialReceive
            // 
            this.btnPartialReceive.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnPartialReceive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPartialReceive.Image = ((System.Drawing.Image)(resources.GetObject("btnPartialReceive.Image")));
            this.btnPartialReceive.Location = new System.Drawing.Point(601, 3);
            this.btnPartialReceive.Name = "btnPartialReceive";
            this.btnPartialReceive.Size = new System.Drawing.Size(60, 55);
            this.btnPartialReceive.TabIndex = 13;
            this.btnPartialReceive.Text = "Partial Receive";
            this.btnPartialReceive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPartialReceive.UseVisualStyleBackColor = true;
            this.btnPartialReceive.Visible = false;
            // 
            // btnReceive
            // 
            this.btnReceive.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnReceive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceive.Image = global::IMS.Properties.Resources.icons8_Lease_16px;
            this.btnReceive.Location = new System.Drawing.Point(535, 3);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(60, 55);
            this.btnReceive.TabIndex = 10;
            this.btnReceive.Text = "Receive Order";
            this.btnReceive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReceive.UseVisualStyleBackColor = true;
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnEditDetails);
            this.flowLayoutPanel1.Controls.Add(this.btnEditItems);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(238, 63);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnEditDetails
            // 
            this.btnEditDetails.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnEditDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditDetails.Image = global::IMS.Properties.Resources.icons8_Edit_16px;
            this.btnEditDetails.Location = new System.Drawing.Point(3, 3);
            this.btnEditDetails.Name = "btnEditDetails";
            this.btnEditDetails.Size = new System.Drawing.Size(60, 55);
            this.btnEditDetails.TabIndex = 11;
            this.btnEditDetails.Text = "Edit Order";
            this.btnEditDetails.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditDetails.UseVisualStyleBackColor = true;
            this.btnEditDetails.Click += new System.EventHandler(this.btnEditDetails_Click);
            // 
            // btnEditItems
            // 
            this.btnEditItems.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnEditItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditItems.Image = global::IMS.Properties.Resources.icons8_Edit_Property_16px;
            this.btnEditItems.Location = new System.Drawing.Point(69, 3);
            this.btnEditItems.Name = "btnEditItems";
            this.btnEditItems.Size = new System.Drawing.Size(60, 55);
            this.btnEditItems.TabIndex = 10;
            this.btnEditItems.Text = "Add/Edit Items";
            this.btnEditItems.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditItems.UseVisualStyleBackColor = true;
            this.btnEditItems.Click += new System.EventHandler(this.btnEditItems_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 184F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.Controls.Add(this.lblOrderNumber1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblExpectedDate, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLotNumber, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(523, 63);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblOrderNumber1
            // 
            this.lblOrderNumber1.AutoSize = true;
            this.lblOrderNumber1.Location = new System.Drawing.Point(83, 0);
            this.lblOrderNumber1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrderNumber1.Name = "lblOrderNumber1";
            this.lblOrderNumber1.Size = new System.Drawing.Size(35, 13);
            this.lblOrderNumber1.TabIndex = 16;
            this.lblOrderNumber1.Text = "label7";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 21);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Name/Ref.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(267, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Expected Date";
            // 
            // lblExpectedDate
            // 
            this.lblExpectedDate.AutoSize = true;
            this.lblExpectedDate.Location = new System.Drawing.Point(363, 0);
            this.lblExpectedDate.Name = "lblExpectedDate";
            this.lblExpectedDate.Size = new System.Drawing.Size(35, 13);
            this.lblExpectedDate.TabIndex = 22;
            this.lblExpectedDate.Text = "label7";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lot #";
            // 
            // lblLotNumber
            // 
            this.lblLotNumber.AutoSize = true;
            this.lblLotNumber.Location = new System.Drawing.Point(84, 42);
            this.lblLotNumber.Name = "lblLotNumber";
            this.lblLotNumber.Size = new System.Drawing.Size(35, 13);
            this.lblLotNumber.TabIndex = 17;
            this.lblLotNumber.Text = "label7";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(84, 21);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 18;
            this.lblName.Text = "label7";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Supplier Invoice";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Warehouse";
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new System.Drawing.Point(128, 42);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(35, 13);
            this.lblWarehouse.TabIndex = 18;
            this.lblWarehouse.Text = "label7";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(128, 0);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(35, 13);
            this.lblSupplier.TabIndex = 19;
            this.lblSupplier.Text = "label7";
            // 
            // lblSupplierInvoice
            // 
            this.lblSupplierInvoice.AutoSize = true;
            this.lblSupplierInvoice.Location = new System.Drawing.Point(128, 21);
            this.lblSupplierInvoice.Name = "lblSupplierInvoice";
            this.lblSupplierInvoice.Size = new System.Drawing.Size(35, 13);
            this.lblSupplierInvoice.TabIndex = 20;
            this.lblSupplierInvoice.Text = "label7";
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
            this.dgvItems.Location = new System.Drawing.Point(0, 211);
            this.dgvItems.Margin = new System.Windows.Forms.Padding(2);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(1044, 230);
            this.dgvItems.TabIndex = 10;
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.tblCustomer);
            this.panel2.Controls.Add(this.tblSupplier);
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 98);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(1044, 83);
            this.panel2.TabIndex = 11;
            // 
            // tblCustomer
            // 
            this.tblCustomer.ColumnCount = 2;
            this.tblCustomer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCustomer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCustomer.Controls.Add(this.label9, 0, 0);
            this.tblCustomer.Controls.Add(this.lblCustomer, 1, 0);
            this.tblCustomer.Controls.Add(this.lblPhone, 1, 2);
            this.tblCustomer.Controls.Add(this.label12, 0, 2);
            this.tblCustomer.Controls.Add(this.lblAddress, 1, 1);
            this.tblCustomer.Controls.Add(this.label14, 0, 1);
            this.tblCustomer.Dock = System.Windows.Forms.DockStyle.Left;
            this.tblCustomer.Location = new System.Drawing.Point(783, 10);
            this.tblCustomer.Name = "tblCustomer";
            this.tblCustomer.RowCount = 3;
            this.tblCustomer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblCustomer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblCustomer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblCustomer.Size = new System.Drawing.Size(250, 63);
            this.tblCustomer.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Customer";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(128, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(35, 13);
            this.lblCustomer.TabIndex = 19;
            this.lblCustomer.Text = "label7";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(128, 42);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(35, 13);
            this.lblPhone.TabIndex = 18;
            this.lblPhone.Text = "label7";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 42);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Phone";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(128, 21);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(35, 13);
            this.lblAddress.TabIndex = 20;
            this.lblAddress.Text = "label7";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Address";
            // 
            // tblSupplier
            // 
            this.tblSupplier.ColumnCount = 2;
            this.tblSupplier.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSupplier.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSupplier.Controls.Add(this.label1, 0, 0);
            this.tblSupplier.Controls.Add(this.lblSupplier, 1, 0);
            this.tblSupplier.Controls.Add(this.lblWarehouse, 1, 2);
            this.tblSupplier.Controls.Add(this.label3, 0, 2);
            this.tblSupplier.Controls.Add(this.lblSupplierInvoice, 1, 1);
            this.tblSupplier.Controls.Add(this.label6, 0, 1);
            this.tblSupplier.Dock = System.Windows.Forms.DockStyle.Left;
            this.tblSupplier.Location = new System.Drawing.Point(533, 10);
            this.tblSupplier.Name = "tblSupplier";
            this.tblSupplier.RowCount = 3;
            this.tblSupplier.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblSupplier.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblSupplier.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblSupplier.Size = new System.Drawing.Size(250, 63);
            this.tblSupplier.TabIndex = 14;
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
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.lblNoItemsMessage);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 181);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1044, 30);
            this.panel3.TabIndex = 13;
            // 
            // OrderDetailUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlButtonsHeader);
            this.Controls.Add(this.panel1);
            this.Name = "OrderDetailUC";
            this.Size = new System.Drawing.Size(1044, 441);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlButtonsHeader.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tblCustomer.ResumeLayout(false);
            this.tblCustomer.PerformLayout();
            this.tblSupplier.ResumeLayout(false);
            this.tblSupplier.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel pnlButtonsHeader;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblLotNumber;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblSupplierInvoice;
        private System.Windows.Forms.Label lblExpectedDate;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNoItemsMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOnOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsHold;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblOrderNumber1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tblCustomer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TableLayoutPanel tblSupplier;
        private System.Windows.Forms.Label label12;
        private Common.Buttons.MenuButton btnEditItems;
        private Common.Buttons.MenuButton btnEditDetails;
        private Common.Buttons.MenuButton btnReceive;
        private Common.Buttons.MenuButton btnCancelOrder;
        private Common.Buttons.MenuButton btnSendOrder;
        private Common.Buttons.MenuButton btnPartialReceive;
        private System.Windows.Forms.ToolTip toolTip1;
        protected internal System.Windows.Forms.Button btnBackToList;
    }
}
