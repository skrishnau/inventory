namespace IMS.Forms.Inventory.Suppliers
{
    partial class SupplierListUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierListUC));
            this.dgvSuppliers = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.rbSupplier = new System.Windows.Forms.RadioButton();
            this.rbCustomer = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.listHeaderTemplate1 = new IMS.Forms.Common.Display.ListHeaderTemplate();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaidAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemainAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
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
            this.Address,
            this.Phone,
            this.colUserType,
            this.colTotalAmount,
            this.colPaidAmount,
            this.colRemainAmount,
            this.colUse,
            this.colEdit});
            this.dgvSuppliers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSuppliers.Location = new System.Drawing.Point(0, 85);
            this.dgvSuppliers.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSuppliers.Name = "dgvSuppliers";
            this.dgvSuppliers.ReadOnly = true;
            this.dgvSuppliers.RowTemplate.Height = 24;
            this.dgvSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSuppliers.Size = new System.Drawing.Size(909, 424);
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
            this.panel2.Size = new System.Drawing.Size(909, 53);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtName);
            this.panel3.Controls.Add(this.rbSupplier);
            this.panel3.Controls.Add(this.rbCustomer);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.rbAll);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(689, 45);
            this.panel3.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(537, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
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
            this.txtName.Location = new System.Drawing.Point(407, 10);
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
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(769, 4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(136, 45);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // btnNew
            // 
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Image = global::IMS.Properties.Resources.icons8_Plus_Math_16px;
            this.btnNew.Location = new System.Drawing.Point(91, 3);
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
            this.btnEdit.Location = new System.Drawing.Point(43, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(42, 40);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Visible = false;
            // 
            // listHeaderTemplate1
            // 
            this.listHeaderTemplate1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listHeaderTemplate1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listHeaderTemplate1.HeadingText = "Clients";
            this.listHeaderTemplate1.Location = new System.Drawing.Point(0, 0);
            this.listHeaderTemplate1.Name = "listHeaderTemplate1";
            this.listHeaderTemplate1.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.listHeaderTemplate1.Size = new System.Drawing.Size(909, 32);
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
            this.colTotalAmount.HeaderText = "Total Txn Amount";
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.ReadOnly = true;
            this.colTotalAmount.Width = 120;
            // 
            // colPaidAmount
            // 
            this.colPaidAmount.DataPropertyName = "PaidAmount";
            this.colPaidAmount.HeaderText = "Paid Amount";
            this.colPaidAmount.Name = "colPaidAmount";
            this.colPaidAmount.ReadOnly = true;
            // 
            // colRemainAmount
            // 
            this.colRemainAmount.DataPropertyName = "DueAmount";
            this.colRemainAmount.HeaderText = "Due Amount";
            this.colRemainAmount.Name = "colRemainAmount";
            this.colRemainAmount.ReadOnly = true;
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
            // SupplierListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvSuppliers);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.listHeaderTemplate1);
            this.Name = "SupplierListUC";
            this.Size = new System.Drawing.Size(909, 509);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaidAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemainAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUse;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
    }
}
