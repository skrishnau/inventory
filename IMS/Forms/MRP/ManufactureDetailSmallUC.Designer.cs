namespace IMS.Forms.MRP
{
    partial class ManufactureDetailSmallUC
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
            this.lblManufactureName = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFinalProduct = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFinalPackage = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFinalQuantity = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLotNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.pnlDepartments = new System.Windows.Forms.Panel();
            this.dgvDepartments = new System.Windows.Forms.DataGridView();
            this.colManufactureDepartmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartmentPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlDepartmentSingle = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitter5 = new System.Windows.Forms.Splitter();
            this.pnlEmployeesHisotory = new System.Windows.Forms.Panel();
            this.dgvEmployeeHistory = new System.Windows.Forms.DataGridView();
            this.colHistoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHistoryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHistoryProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHistoryPackageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHistoryQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAssignProduct = new System.Windows.Forms.Button();
            this.btnAddManufacture = new System.Windows.Forms.Button();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.pnlEmployees = new System.Windows.Forms.Panel();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.colEmployeesUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployeesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployeesRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblEmployeesVendor = new System.Windows.Forms.Label();
            this.lblIntermediateProducts = new System.Windows.Forms.Label();
            this.lblEmployees = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlDepartments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).BeginInit();
            this.pnlDepartmentSingle.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlEmployeesHisotory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeHistory)).BeginInit();
            this.panel3.SuspendLayout();
            this.pnlEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblManufactureName);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnComplete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(509, 41);
            this.panel1.TabIndex = 0;
            // 
            // lblManufactureName
            // 
            this.lblManufactureName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblManufactureName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManufactureName.Location = new System.Drawing.Point(5, 5);
            this.lblManufactureName.Name = "lblManufactureName";
            this.lblManufactureName.Size = new System.Drawing.Size(247, 31);
            this.lblManufactureName.TabIndex = 1;
            this.lblManufactureName.Text = "ManufactureName";
            this.lblManufactureName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(279, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 31);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(354, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnComplete
            // 
            this.btnComplete.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnComplete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnComplete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComplete.Location = new System.Drawing.Point(429, 5);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(75, 31);
            this.btnComplete.TabIndex = 9;
            this.btnComplete.Text = "Complete";
            this.btnComplete.UseVisualStyleBackColor = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(75, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.23895F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.00655F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.56629F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.18822F));
            this.tableLayoutPanel1.Controls.Add(this.lblStatus, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFinalProduct, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFinalPackage, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblFinalQuantity, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblLotNo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 49);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(509, 63);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Final Product";
            // 
            // lblFinalProduct
            // 
            this.lblFinalProduct.AutoSize = true;
            this.lblFinalProduct.Location = new System.Drawing.Point(332, 0);
            this.lblFinalProduct.Name = "lblFinalProduct";
            this.lblFinalProduct.Size = new System.Drawing.Size(35, 13);
            this.lblFinalProduct.TabIndex = 5;
            this.lblFinalProduct.Text = "label7";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(258, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Unit";
            // 
            // lblFinalPackage
            // 
            this.lblFinalPackage.AutoSize = true;
            this.lblFinalPackage.Location = new System.Drawing.Point(332, 21);
            this.lblFinalPackage.Name = "lblFinalPackage";
            this.lblFinalPackage.Size = new System.Drawing.Size(35, 13);
            this.lblFinalPackage.TabIndex = 6;
            this.lblFinalPackage.Text = "label8";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(258, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Quantity";
            // 
            // lblFinalQuantity
            // 
            this.lblFinalQuantity.AutoSize = true;
            this.lblFinalQuantity.Location = new System.Drawing.Point(332, 42);
            this.lblFinalQuantity.Name = "lblFinalQuantity";
            this.lblFinalQuantity.Size = new System.Drawing.Size(35, 13);
            this.lblFinalQuantity.TabIndex = 7;
            this.lblFinalQuantity.Text = "label9";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lot No.";
            // 
            // lblLotNo
            // 
            this.lblLotNo.AutoSize = true;
            this.lblLotNo.Location = new System.Drawing.Point(75, 21);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.Size = new System.Drawing.Size(35, 13);
            this.lblLotNo.TabIndex = 4;
            this.lblLotNo.Text = "label6";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Status";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(5, 46);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(509, 3);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(5, 291);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(509, 3);
            this.splitter2.TabIndex = 8;
            this.splitter2.TabStop = false;
            // 
            // pnlDepartments
            // 
            this.pnlDepartments.BackColor = System.Drawing.SystemColors.Control;
            this.pnlDepartments.Controls.Add(this.dgvDepartments);
            this.pnlDepartments.Controls.Add(this.flowLayoutPanel1);
            this.pnlDepartments.Controls.Add(this.label6);
            this.pnlDepartments.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDepartments.Location = new System.Drawing.Point(5, 112);
            this.pnlDepartments.Name = "pnlDepartments";
            this.pnlDepartments.Size = new System.Drawing.Size(509, 179);
            this.pnlDepartments.TabIndex = 5;
            // 
            // dgvDepartments
            // 
            this.dgvDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colManufactureDepartmentId,
            this.colDepartmentId,
            this.colDepartmentName,
            this.colDepartmentPosition});
            this.dgvDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDepartments.Location = new System.Drawing.Point(0, 26);
            this.dgvDepartments.MultiSelect = false;
            this.dgvDepartments.Name = "dgvDepartments";
            this.dgvDepartments.RowHeadersVisible = false;
            this.dgvDepartments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepartments.Size = new System.Drawing.Size(470, 153);
            this.dgvDepartments.TabIndex = 1;
            // 
            // colManufactureDepartmentId
            // 
            this.colManufactureDepartmentId.DataPropertyName = "Id";
            this.colManufactureDepartmentId.HeaderText = "Id";
            this.colManufactureDepartmentId.Name = "colManufactureDepartmentId";
            this.colManufactureDepartmentId.Visible = false;
            // 
            // colDepartmentId
            // 
            this.colDepartmentId.DataPropertyName = "DepartmentId";
            this.colDepartmentId.HeaderText = "DepartmentId";
            this.colDepartmentId.Name = "colDepartmentId";
            this.colDepartmentId.ReadOnly = true;
            this.colDepartmentId.Visible = false;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.DataPropertyName = "Name";
            this.colDepartmentName.HeaderText = "Name";
            this.colDepartmentName.Name = "colDepartmentName";
            this.colDepartmentName.ReadOnly = true;
            this.colDepartmentName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDepartmentName.Width = 180;
            // 
            // colDepartmentPosition
            // 
            this.colDepartmentPosition.DataPropertyName = "Position";
            this.colDepartmentPosition.HeaderText = "Sequence";
            this.colDepartmentPosition.Name = "colDepartmentPosition";
            this.colDepartmentPosition.ReadOnly = true;
            this.colDepartmentPosition.Width = 60;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(470, 26);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(39, 153);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(509, 26);
            this.label6.TabIndex = 0;
            this.label6.Text = "Departments";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDepartmentSingle
            // 
            this.pnlDepartmentSingle.Controls.Add(this.panel2);
            this.pnlDepartmentSingle.Controls.Add(this.lblIntermediateProducts);
            this.pnlDepartmentSingle.Controls.Add(this.lblEmployees);
            this.pnlDepartmentSingle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDepartmentSingle.Location = new System.Drawing.Point(5, 294);
            this.pnlDepartmentSingle.Name = "pnlDepartmentSingle";
            this.pnlDepartmentSingle.Size = new System.Drawing.Size(509, 287);
            this.pnlDepartmentSingle.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitter5);
            this.panel2.Controls.Add(this.pnlEmployeesHisotory);
            this.panel2.Controls.Add(this.pnlEmployees);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(509, 248);
            this.panel2.TabIndex = 2;
            // 
            // splitter5
            // 
            this.splitter5.Enabled = false;
            this.splitter5.Location = new System.Drawing.Point(229, 0);
            this.splitter5.Name = "splitter5";
            this.splitter5.Size = new System.Drawing.Size(5, 248);
            this.splitter5.TabIndex = 9;
            this.splitter5.TabStop = false;
            // 
            // pnlEmployeesHisotory
            // 
            this.pnlEmployeesHisotory.BackColor = System.Drawing.SystemColors.Control;
            this.pnlEmployeesHisotory.Controls.Add(this.dgvEmployeeHistory);
            this.pnlEmployeesHisotory.Controls.Add(this.panel3);
            this.pnlEmployeesHisotory.Controls.Add(this.lblEmployeeName);
            this.pnlEmployeesHisotory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEmployeesHisotory.Location = new System.Drawing.Point(229, 0);
            this.pnlEmployeesHisotory.Name = "pnlEmployeesHisotory";
            this.pnlEmployeesHisotory.Size = new System.Drawing.Size(280, 248);
            this.pnlEmployeesHisotory.TabIndex = 8;
            // 
            // dgvEmployeeHistory
            // 
            this.dgvEmployeeHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeeHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHistoryId,
            this.colHistoryDate,
            this.colHistoryProduct,
            this.colHistoryPackageName,
            this.colHistoryQuantity});
            this.dgvEmployeeHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmployeeHistory.Location = new System.Drawing.Point(0, 54);
            this.dgvEmployeeHistory.MultiSelect = false;
            this.dgvEmployeeHistory.Name = "dgvEmployeeHistory";
            this.dgvEmployeeHistory.RowHeadersVisible = false;
            this.dgvEmployeeHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployeeHistory.Size = new System.Drawing.Size(280, 194);
            this.dgvEmployeeHistory.TabIndex = 2;
            // 
            // colHistoryId
            // 
            this.colHistoryId.DataPropertyName = "UserId";
            this.colHistoryId.HeaderText = "Id";
            this.colHistoryId.Name = "colHistoryId";
            this.colHistoryId.ReadOnly = true;
            this.colHistoryId.Visible = false;
            // 
            // colHistoryDate
            // 
            this.colHistoryDate.DataPropertyName = "DateString";
            this.colHistoryDate.HeaderText = "Date";
            this.colHistoryDate.Name = "colHistoryDate";
            this.colHistoryDate.ReadOnly = true;
            this.colHistoryDate.Width = 70;
            // 
            // colHistoryProduct
            // 
            this.colHistoryProduct.DataPropertyName = "ProductName";
            this.colHistoryProduct.HeaderText = "Product";
            this.colHistoryProduct.Name = "colHistoryProduct";
            this.colHistoryProduct.ReadOnly = true;
            // 
            // colHistoryPackageName
            // 
            this.colHistoryPackageName.DataPropertyName = "PackageName";
            this.colHistoryPackageName.HeaderText = "Unit";
            this.colHistoryPackageName.Name = "colHistoryPackageName";
            this.colHistoryPackageName.ReadOnly = true;
            this.colHistoryPackageName.Width = 70;
            // 
            // colHistoryQuantity
            // 
            this.colHistoryQuantity.DataPropertyName = "Quantity";
            this.colHistoryQuantity.HeaderText = "Quantity";
            this.colHistoryQuantity.Name = "colHistoryQuantity";
            this.colHistoryQuantity.ReadOnly = true;
            this.colHistoryQuantity.Width = 60;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAssignProduct);
            this.panel3.Controls.Add(this.btnAddManufacture);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 26);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(280, 28);
            this.panel3.TabIndex = 4;
            // 
            // btnAssignProduct
            // 
            this.btnAssignProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssignProduct.Location = new System.Drawing.Point(59, 3);
            this.btnAssignProduct.Name = "btnAssignProduct";
            this.btnAssignProduct.Size = new System.Drawing.Size(105, 23);
            this.btnAssignProduct.TabIndex = 4;
            this.btnAssignProduct.Text = "Assign Products";
            this.btnAssignProduct.UseVisualStyleBackColor = true;
            // 
            // btnAddManufacture
            // 
            this.btnAddManufacture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddManufacture.Location = new System.Drawing.Point(170, 3);
            this.btnAddManufacture.Name = "btnAddManufacture";
            this.btnAddManufacture.Size = new System.Drawing.Size(105, 23);
            this.btnAddManufacture.TabIndex = 3;
            this.btnAddManufacture.Text = "Add Manufacture";
            this.btnAddManufacture.UseVisualStyleBackColor = true;
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEmployeeName.Location = new System.Drawing.Point(0, 0);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblEmployeeName.Size = new System.Drawing.Size(280, 26);
            this.lblEmployeeName.TabIndex = 1;
            this.lblEmployeeName.Text = "Manufacture History of ______";
            this.lblEmployeeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlEmployees
            // 
            this.pnlEmployees.BackColor = System.Drawing.SystemColors.Control;
            this.pnlEmployees.Controls.Add(this.dgvEmployees);
            this.pnlEmployees.Controls.Add(this.lblEmployeesVendor);
            this.pnlEmployees.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlEmployees.Location = new System.Drawing.Point(0, 0);
            this.pnlEmployees.Name = "pnlEmployees";
            this.pnlEmployees.Size = new System.Drawing.Size(229, 248);
            this.pnlEmployees.TabIndex = 6;
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEmployeesUserId,
            this.colEmployeesName,
            this.colEmployeesRate});
            this.dgvEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmployees.Location = new System.Drawing.Point(0, 26);
            this.dgvEmployees.MultiSelect = false;
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.RowHeadersVisible = false;
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.Size = new System.Drawing.Size(229, 222);
            this.dgvEmployees.TabIndex = 2;
            // 
            // colEmployeesUserId
            // 
            this.colEmployeesUserId.DataPropertyName = "UserId";
            this.colEmployeesUserId.HeaderText = "Id";
            this.colEmployeesUserId.Name = "colEmployeesUserId";
            this.colEmployeesUserId.ReadOnly = true;
            this.colEmployeesUserId.Visible = false;
            // 
            // colEmployeesName
            // 
            this.colEmployeesName.DataPropertyName = "Name";
            this.colEmployeesName.HeaderText = "Name";
            this.colEmployeesName.Name = "colEmployeesName";
            this.colEmployeesName.ReadOnly = true;
            this.colEmployeesName.Width = 130;
            // 
            // colEmployeesRate
            // 
            this.colEmployeesRate.DataPropertyName = "BuildRate";
            this.colEmployeesRate.HeaderText = "Rate";
            this.colEmployeesRate.Name = "colEmployeesRate";
            this.colEmployeesRate.ReadOnly = true;
            this.colEmployeesRate.Width = 70;
            // 
            // lblEmployeesVendor
            // 
            this.lblEmployeesVendor.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEmployeesVendor.Location = new System.Drawing.Point(0, 0);
            this.lblEmployeesVendor.Name = "lblEmployeesVendor";
            this.lblEmployeesVendor.Size = new System.Drawing.Size(229, 26);
            this.lblEmployeesVendor.TabIndex = 3;
            this.lblEmployeesVendor.Text = "Employees";
            this.lblEmployeesVendor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIntermediateProducts
            // 
            this.lblIntermediateProducts.AutoSize = true;
            this.lblIntermediateProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIntermediateProducts.Location = new System.Drawing.Point(0, 26);
            this.lblIntermediateProducts.Name = "lblIntermediateProducts";
            this.lblIntermediateProducts.Size = new System.Drawing.Size(122, 13);
            this.lblIntermediateProducts.TabIndex = 0;
            this.lblIntermediateProducts.Text = "Intermediate Products : -";
            // 
            // lblEmployees
            // 
            this.lblEmployees.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployees.Location = new System.Drawing.Point(0, 0);
            this.lblEmployees.Name = "lblEmployees";
            this.lblEmployees.Size = new System.Drawing.Size(509, 26);
            this.lblEmployees.TabIndex = 1;
            this.lblEmployees.Text = "Department Name";
            this.lblEmployees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ManufactureDetailSmallUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.pnlDepartmentSingle);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.pnlDepartments);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "ManufactureDetailSmallUC";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(519, 530);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlDepartments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).EndInit();
            this.pnlDepartmentSingle.ResumeLayout(false);
            this.pnlDepartmentSingle.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlEmployeesHisotory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeHistory)).EndInit();
            this.panel3.ResumeLayout(false);
            this.pnlEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblManufactureName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblFinalQuantity;
        private System.Windows.Forms.Label lblFinalPackage;
        private System.Windows.Forms.Label lblFinalProduct;
        private System.Windows.Forms.Label lblLotNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Panel pnlDepartments;
        private System.Windows.Forms.DataGridView dgvDepartments;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlDepartmentSingle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter5;
        private System.Windows.Forms.Panel pnlEmployeesHisotory;
        private System.Windows.Forms.Button btnAddManufacture;
        private System.Windows.Forms.DataGridView dgvEmployeeHistory;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.Panel pnlEmployees;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.Label lblEmployeesVendor;
        private System.Windows.Forms.Label lblIntermediateProducts;
        private System.Windows.Forms.Label lblEmployees;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployeesUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployeesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployeesRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManufactureDepartmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartmentPosition;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAssignProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistoryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistoryProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistoryPackageName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistoryQuantity;
    }
}
