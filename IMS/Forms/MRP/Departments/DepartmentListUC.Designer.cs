namespace IMS.Forms.MRP.Departments
{
    partial class DepartmentListUC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepartmentListUC));
            this.dgvDepartmentList = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInStockQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReleaseProducts = new System.Windows.Forms.Button();
            this.btnAssignProducts = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
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
            this.pnlSideGridView = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvDepartmentProducts = new System.Windows.Forms.DataGridView();
            this.colOwnerProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOwnerQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOwnerPackage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblProductsOnHold = new System.Windows.Forms.Label();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.colEmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSellingPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployeeRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployeeAssign = new System.Windows.Forms.DataGridViewImageColumn();
            this.colEmployeeRelease = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblEmployeesVendors = new System.Windows.Forms.Label();
            this.lblDepartmentName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartmentList)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.pnlSideGridView.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartmentProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDepartmentList
            // 
            this.dgvDepartmentList.AllowUserToAddRows = false;
            this.dgvDepartmentList.AllowUserToDeleteRows = false;
            this.dgvDepartmentList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDepartmentList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDepartmentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartmentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colInStockQuantity});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDepartmentList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDepartmentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDepartmentList.Location = new System.Drawing.Point(0, 56);
            this.dgvDepartmentList.MultiSelect = false;
            this.dgvDepartmentList.Name = "dgvDepartmentList";
            this.dgvDepartmentList.ReadOnly = true;
            this.dgvDepartmentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepartmentList.Size = new System.Drawing.Size(545, 375);
            this.dgvDepartmentList.TabIndex = 7;
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
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colName.DefaultCellStyle = dataGridViewCellStyle2;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 200;
            // 
            // colInStockQuantity
            // 
            this.colInStockQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colInStockQuantity.DataPropertyName = "Type";
            this.colInStockQuantity.HeaderText = "Type";
            this.colInStockQuantity.Name = "colInStockQuantity";
            this.colInStockQuantity.ReadOnly = true;
            this.colInStockQuantity.Width = 90;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(910, 53);
            this.panel1.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtName);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(317, 45);
            this.panel3.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Search Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(97, 14);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(124, 20);
            this.txtName.TabIndex = 8;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnNew);
            this.flowLayoutPanel1.Controls.Add(this.btnEdit);
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Controls.Add(this.btnReleaseProducts);
            this.flowLayoutPanel1.Controls.Add(this.btnAssignProducts);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(473, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(433, 45);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnNew
            // 
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Image = global::IMS.Properties.Resources.icons8_Plus_Math_16px;
            this.btnNew.Location = new System.Drawing.Point(388, 3);
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
            this.btnEdit.Location = new System.Drawing.Point(340, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(42, 40);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = global::IMS.Properties.Resources.icons8_Delete_16px_Dark;
            this.btnDelete.Location = new System.Drawing.Point(285, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(49, 40);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            // 
            // btnReleaseProducts
            // 
            this.btnReleaseProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReleaseProducts.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReleaseProducts.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnReleaseProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReleaseProducts.Image = global::IMS.Properties.Resources.icons8_Forward_Arrow_16px;
            this.btnReleaseProducts.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReleaseProducts.Location = new System.Drawing.Point(172, 3);
            this.btnReleaseProducts.Name = "btnReleaseProducts";
            this.btnReleaseProducts.Size = new System.Drawing.Size(107, 39);
            this.btnReleaseProducts.TabIndex = 4;
            this.btnReleaseProducts.Text = "Release Products";
            this.btnReleaseProducts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReleaseProducts.UseVisualStyleBackColor = false;
            this.btnReleaseProducts.Visible = false;
            // 
            // btnAssignProducts
            // 
            this.btnAssignProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssignProducts.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAssignProducts.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnAssignProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignProducts.Image = global::IMS.Properties.Resources.icons8_Sell_16px;
            this.btnAssignProducts.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAssignProducts.Location = new System.Drawing.Point(72, 3);
            this.btnAssignProducts.Name = "btnAssignProducts";
            this.btnAssignProducts.Size = new System.Drawing.Size(94, 39);
            this.btnAssignProducts.TabIndex = 3;
            this.btnAssignProducts.Text = "Assign Products";
            this.btnAssignProducts.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAssignProducts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAssignProducts.UseVisualStyleBackColor = false;
            this.btnAssignProducts.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 53);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(910, 3);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 431);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(910, 25);
            this.bindingNavigator1.TabIndex = 12;
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
            // pnlSideGridView
            // 
            this.pnlSideGridView.Controls.Add(this.panel2);
            this.pnlSideGridView.Controls.Add(this.dgvEmployees);
            this.pnlSideGridView.Controls.Add(this.lblEmployeesVendors);
            this.pnlSideGridView.Controls.Add(this.lblDepartmentName);
            this.pnlSideGridView.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSideGridView.Location = new System.Drawing.Point(545, 56);
            this.pnlSideGridView.Name = "pnlSideGridView";
            this.pnlSideGridView.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.pnlSideGridView.Size = new System.Drawing.Size(365, 375);
            this.pnlSideGridView.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvDepartmentProducts);
            this.panel2.Controls.Add(this.lblProductsOnHold);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 231);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(360, 144);
            this.panel2.TabIndex = 3;
            // 
            // dgvDepartmentProducts
            // 
            this.dgvDepartmentProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartmentProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOwnerProduct,
            this.colOwnerQuantity,
            this.colOwnerPackage});
            this.dgvDepartmentProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDepartmentProducts.Location = new System.Drawing.Point(0, 35);
            this.dgvDepartmentProducts.MultiSelect = false;
            this.dgvDepartmentProducts.Name = "dgvDepartmentProducts";
            this.dgvDepartmentProducts.RowHeadersVisible = false;
            this.dgvDepartmentProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepartmentProducts.Size = new System.Drawing.Size(360, 109);
            this.dgvDepartmentProducts.TabIndex = 1;
            // 
            // colOwnerProduct
            // 
            this.colOwnerProduct.DataPropertyName = "ProductName";
            this.colOwnerProduct.HeaderText = "Product";
            this.colOwnerProduct.Name = "colOwnerProduct";
            this.colOwnerProduct.Width = 150;
            // 
            // colOwnerQuantity
            // 
            this.colOwnerQuantity.DataPropertyName = "Quantity";
            this.colOwnerQuantity.HeaderText = "Quantity";
            this.colOwnerQuantity.Name = "colOwnerQuantity";
            // 
            // colOwnerPackage
            // 
            this.colOwnerPackage.DataPropertyName = "PackageName";
            this.colOwnerPackage.HeaderText = "Unit";
            this.colOwnerPackage.Name = "colOwnerPackage";
            // 
            // lblProductsOnHold
            // 
            this.lblProductsOnHold.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProductsOnHold.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductsOnHold.Location = new System.Drawing.Point(0, 0);
            this.lblProductsOnHold.Name = "lblProductsOnHold";
            this.lblProductsOnHold.Size = new System.Drawing.Size(360, 35);
            this.lblProductsOnHold.TabIndex = 2;
            this.lblProductsOnHold.Text = "Products On Hold";
            this.lblProductsOnHold.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEmployeeId,
            this.colSellingPrice,
            this.colEmployeeRate,
            this.colEmployeeAssign,
            this.colEmployeeRelease});
            this.dgvEmployees.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvEmployees.Location = new System.Drawing.Point(5, 40);
            this.dgvEmployees.MultiSelect = false;
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.RowHeadersVisible = false;
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.Size = new System.Drawing.Size(360, 191);
            this.dgvEmployees.TabIndex = 0;
            // 
            // colEmployeeId
            // 
            this.colEmployeeId.DataPropertyName = "UserId";
            this.colEmployeeId.HeaderText = "UserId";
            this.colEmployeeId.Name = "colEmployeeId";
            this.colEmployeeId.Visible = false;
            // 
            // colSellingPrice
            // 
            this.colSellingPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSellingPrice.DataPropertyName = "User";
            this.colSellingPrice.HeaderText = "Name";
            this.colSellingPrice.Name = "colSellingPrice";
            // 
            // colEmployeeRate
            // 
            this.colEmployeeRate.DataPropertyName = "BuildRate";
            this.colEmployeeRate.HeaderText = "Rate";
            this.colEmployeeRate.Name = "colEmployeeRate";
            // 
            // colEmployeeAssign
            // 
            this.colEmployeeAssign.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colEmployeeAssign.HeaderText = "Asssign";
            this.colEmployeeAssign.Image = global::IMS.Properties.Resources.icons8_Sell_16px;
            this.colEmployeeAssign.Name = "colEmployeeAssign";
            this.colEmployeeAssign.ToolTipText = "Assign";
            this.colEmployeeAssign.Width = 49;
            // 
            // colEmployeeRelease
            // 
            this.colEmployeeRelease.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colEmployeeRelease.HeaderText = "Release";
            this.colEmployeeRelease.Image = global::IMS.Properties.Resources.icons8_Forward_Arrow_16px;
            this.colEmployeeRelease.Name = "colEmployeeRelease";
            this.colEmployeeRelease.ToolTipText = "Release";
            this.colEmployeeRelease.Width = 52;
            // 
            // lblEmployeesVendors
            // 
            this.lblEmployeesVendors.AutoSize = true;
            this.lblEmployeesVendors.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEmployeesVendors.Location = new System.Drawing.Point(5, 27);
            this.lblEmployeesVendors.Name = "lblEmployeesVendors";
            this.lblEmployeesVendors.Size = new System.Drawing.Size(10, 13);
            this.lblEmployeesVendors.TabIndex = 2;
            this.lblEmployeesVendors.Text = "-";
            // 
            // lblDepartmentName
            // 
            this.lblDepartmentName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDepartmentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartmentName.Location = new System.Drawing.Point(5, 0);
            this.lblDepartmentName.Name = "lblDepartmentName";
            this.lblDepartmentName.Size = new System.Drawing.Size(360, 27);
            this.lblDepartmentName.TabIndex = 1;
            this.lblDepartmentName.Text = "-";
            this.lblDepartmentName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DepartmentListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvDepartmentList);
            this.Controls.Add(this.pnlSideGridView);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "DepartmentListUC";
            this.Size = new System.Drawing.Size(910, 456);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartmentList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.pnlSideGridView.ResumeLayout(false);
            this.pnlSideGridView.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartmentProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDepartmentList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel pnlSideGridView;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.Label lblDepartmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInStockQuantity;
        private System.Windows.Forms.Label lblEmployeesVendors;
        protected internal System.Windows.Forms.Button btnAssignProducts;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvDepartmentProducts;
        private System.Windows.Forms.Label lblProductsOnHold;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOwnerProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOwnerQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOwnerPackage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        protected internal System.Windows.Forms.Button btnNew;
        protected internal System.Windows.Forms.Button btnEdit;
        protected internal System.Windows.Forms.Button btnDelete;
        protected internal System.Windows.Forms.Button btnReleaseProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSellingPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployeeRate;
        private System.Windows.Forms.DataGridViewImageColumn colEmployeeAssign;
        private System.Windows.Forms.DataGridViewImageColumn colEmployeeRelease;
    }
}
