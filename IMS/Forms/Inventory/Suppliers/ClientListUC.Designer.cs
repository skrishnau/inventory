namespace IMS.Forms.Inventory.Suppliers
{
    partial class ClientListUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientListUC));
            this.dgvSuppliers = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.rbSupplier = new System.Windows.Forms.RadioButton();
            this.rbCustomer = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnPayment = new IMS.Forms.Common.Buttons.MenuButton();
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
            this.listHeaderTemplate1 = new IMS.Forms.Common.Display.ListHeaderTemplate();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaidAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManufacturedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemainAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaymentDueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAllDuesClearDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSuppliers
            // 
            this.dgvSuppliers.AllowUserToAddRows = false;
            this.dgvSuppliers.AllowUserToDeleteRows = false;
            this.dgvSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSuppliers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.SupplierName,
            this.colCompany,
            this.Address,
            this.Phone,
            this.colUserType,
            this.colTotalAmount,
            this.colPaidAmount,
            this.colManufacturedAmount,
            this.colRemainAmount,
            this.colPaymentDueDate,
            this.colAllDuesClearDate,
            this.colUse,
            this.colEdit});
            this.dgvSuppliers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSuppliers.Location = new System.Drawing.Point(0, 85);
            this.dgvSuppliers.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSuppliers.MultiSelect = false;
            this.dgvSuppliers.Name = "dgvSuppliers";
            this.dgvSuppliers.ReadOnly = true;
            this.dgvSuppliers.RowTemplate.Height = 24;
            this.dgvSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSuppliers.Size = new System.Drawing.Size(1044, 399);
            this.dgvSuppliers.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.flowLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4);
            this.panel2.Size = new System.Drawing.Size(1044, 53);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtName);
            this.panel3.Controls.Add(this.rbSupplier);
            this.panel3.Controls.Add(this.rbCustomer);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.rbAll);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(553, 45);
            this.panel3.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Search Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(407, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(124, 20);
            this.txtName.TabIndex = 6;
            // 
            // rbSupplier
            // 
            this.rbSupplier.AutoSize = true;
            this.rbSupplier.Location = new System.Drawing.Point(223, 15);
            this.rbSupplier.Name = "rbSupplier";
            this.rbSupplier.Size = new System.Drawing.Size(68, 17);
            this.rbSupplier.TabIndex = 3;
            this.rbSupplier.Text = "Suppliers";
            this.rbSupplier.UseVisualStyleBackColor = true;
            // 
            // rbCustomer
            // 
            this.rbCustomer.AutoSize = true;
            this.rbCustomer.Location = new System.Drawing.Point(130, 15);
            this.rbCustomer.Name = "rbCustomer";
            this.rbCustomer.Size = new System.Drawing.Size(74, 17);
            this.rbCustomer.TabIndex = 2;
            this.rbCustomer.Text = "Customers";
            this.rbCustomer.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Type";
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(66, 15);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(36, 17);
            this.rbAll.TabIndex = 0;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "All";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnNew);
            this.flowLayoutPanel2.Controls.Add(this.btnEdit);
            this.flowLayoutPanel2.Controls.Add(this.btnPayment);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(723, 4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(317, 45);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // btnNew
            // 
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Image = global::IMS.Properties.Resources.icons8_Plus_Math_16px;
            this.btnNew.Location = new System.Drawing.Point(272, 3);
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
            this.btnEdit.Location = new System.Drawing.Point(224, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(42, 40);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Visible = false;
            // 
            // btnPayment
            // 
            this.btnPayment.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPayment.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayment.Image = global::IMS.Properties.Resources.icons8_Lease_16px;
            this.btnPayment.Location = new System.Drawing.Point(140, 3);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(78, 40);
            this.btnPayment.TabIndex = 16;
            this.btnPayment.Text = "Payment";
            this.btnPayment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Visible = false;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 484);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1044, 25);
            this.bindingNavigator1.TabIndex = 15;
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
            // listHeaderTemplate1
            // 
            this.listHeaderTemplate1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listHeaderTemplate1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listHeaderTemplate1.HeadingText = "Clients";
            this.listHeaderTemplate1.Location = new System.Drawing.Point(0, 0);
            this.listHeaderTemplate1.Name = "listHeaderTemplate1";
            this.listHeaderTemplate1.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.listHeaderTemplate1.Size = new System.Drawing.Size(1044, 32);
            this.listHeaderTemplate1.TabIndex = 14;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // SupplierName
            // 
            this.SupplierName.DataPropertyName = "Name";
            this.SupplierName.HeaderText = "Name";
            this.SupplierName.Name = "SupplierName";
            this.SupplierName.ReadOnly = true;
            this.SupplierName.Width = 140;
            // 
            // colCompany
            // 
            this.colCompany.DataPropertyName = "Company";
            this.colCompany.HeaderText = "Company";
            this.colCompany.Name = "colCompany";
            this.colCompany.ReadOnly = true;
            this.colCompany.Width = 110;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 150;
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            this.Phone.HeaderText = "Phone";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // colUserType
            // 
            this.colUserType.DataPropertyName = "UserType";
            this.colUserType.HeaderText = "Type";
            this.colUserType.Name = "colUserType";
            this.colUserType.ReadOnly = true;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.DataPropertyName = "TotalAmount";
            this.colTotalAmount.HeaderText = "Debit (दिएको)";
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.ReadOnly = true;
            this.colTotalAmount.Width = 120;
            // 
            // colPaidAmount
            // 
            this.colPaidAmount.DataPropertyName = "PaidAmount";
            this.colPaidAmount.HeaderText = "Credit (लिएको)";
            this.colPaidAmount.Name = "colPaidAmount";
            this.colPaidAmount.ReadOnly = true;
            // 
            // colManufacturedAmount
            // 
            this.colManufacturedAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colManufacturedAmount.DataPropertyName = "ManufacturedAmount";
            this.colManufacturedAmount.HeaderText = "Manufactured Amt.";
            this.colManufacturedAmount.Name = "colManufacturedAmount";
            this.colManufacturedAmount.ReadOnly = true;
            this.colManufacturedAmount.Width = 112;
            // 
            // colRemainAmount
            // 
            this.colRemainAmount.DataPropertyName = "DueAmountString";
            this.colRemainAmount.HeaderText = "Balance";
            this.colRemainAmount.Name = "colRemainAmount";
            this.colRemainAmount.ReadOnly = true;
            // 
            // colPaymentDueDate
            // 
            this.colPaymentDueDate.DataPropertyName = "PaymentDueDate";
            this.colPaymentDueDate.HeaderText = "Due Date";
            this.colPaymentDueDate.Name = "colPaymentDueDate";
            this.colPaymentDueDate.ReadOnly = true;
            this.colPaymentDueDate.Width = 90;
            // 
            // colAllDuesClearDate
            // 
            this.colAllDuesClearDate.DataPropertyName = "AllDuesClearDateBS";
            this.colAllDuesClearDate.HeaderText = "Last Full Clear";
            this.colAllDuesClearDate.Name = "colAllDuesClearDate";
            this.colAllDuesClearDate.ReadOnly = true;
            // 
            // colUse
            // 
            this.colUse.DataPropertyName = "Use";
            this.colUse.HeaderText = "Use";
            this.colUse.Name = "colUse";
            this.colUse.ReadOnly = true;
            this.colUse.Width = 40;
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.Image = global::IMS.Properties.Resources.icons8_Edit_16px;
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Width = 30;
            // 
            // ClientListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvSuppliers);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.listHeaderTemplate1);
            this.Name = "ClientListUC";
            this.Size = new System.Drawing.Size(1044, 509);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSuppliers;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        protected internal System.Windows.Forms.Button btnNew;
        protected internal System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbSupplier;
        private System.Windows.Forms.RadioButton rbCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbAll;
        private Common.Display.ListHeaderTemplate listHeaderTemplate1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private Common.Buttons.MenuButton btnPayment;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaidAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManufacturedAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemainAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaymentDueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAllDuesClearDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUse;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
    }
}
