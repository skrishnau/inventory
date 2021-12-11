namespace IMS.Forms.MRP
{
    partial class UserManufactureCreateForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelProduct = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPackage = new System.Windows.Forms.TextBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.chkAssignToNextDepartment = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.dgvDepartments = new System.Windows.Forms.DataGridView();
            this.colManufactureDepartmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartmentQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlInputBase = new System.Windows.Forms.Panel();
            this.pnlConsumed = new System.Windows.Forms.GroupBox();
            this.dgvItems = new IMS.Forms.Common.GridView.InventoryUnits.InventoryUnitDataGridView();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.pnlManufactured = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).BeginInit();
            this.pnlInputBase.SuspendLayout();
            this.pnlConsumed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.pnlManufactured.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEmployeeName.Location = new System.Drawing.Point(5, 5);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(752, 24);
            this.lblEmployeeName.TabIndex = 0;
            this.lblEmployeeName.Text = "Employee Name";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(85, 59);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(191, 20);
            this.txtQuantity.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.67857F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.32143F));
            this.tableLayoutPanel1.Controls.Add(this.labelProduct, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtQuantity, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbProduct, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPackage, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(298, 85);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // labelProduct
            // 
            this.labelProduct.AutoSize = true;
            this.labelProduct.Location = new System.Drawing.Point(3, 0);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(51, 13);
            this.labelProduct.TabIndex = 0;
            this.labelProduct.Text = "Product *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Unit *";
            // 
            // cbProduct
            // 
            this.cbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProduct.FormattingEnabled = true;
            this.cbProduct.Location = new System.Drawing.Point(85, 3);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(191, 21);
            this.cbProduct.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Quantity *";
            // 
            // txtPackage
            // 
            this.txtPackage.Location = new System.Drawing.Point(85, 31);
            this.txtPackage.Name = "txtPackage";
            this.txtPackage.ReadOnly = true;
            this.txtPackage.Size = new System.Drawing.Size(191, 20);
            this.txtPackage.TabIndex = 5;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(5, 230);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(752, 35);
            this.pnlFooter.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(666, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(574, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(5, 172);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(752, 3);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // chkAssignToNextDepartment
            // 
            this.chkAssignToNextDepartment.AutoSize = true;
            this.chkAssignToNextDepartment.Location = new System.Drawing.Point(3, 6);
            this.chkAssignToNextDepartment.Name = "chkAssignToNextDepartment";
            this.chkAssignToNextDepartment.Size = new System.Drawing.Size(152, 17);
            this.chkAssignToNextDepartment.TabIndex = 0;
            this.chkAssignToNextDepartment.Text = "Assign to Next Department";
            this.chkAssignToNextDepartment.UseVisualStyleBackColor = true;
            this.chkAssignToNextDepartment.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkAssignToNextDepartment);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 212);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(752, 26);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(5, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(752, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Note: The manufactured quantity entered above will be assigned to the same depart" +
    "ment. ";
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(5, 209);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(752, 3);
            this.splitter2.TabIndex = 9;
            this.splitter2.TabStop = false;
            // 
            // dgvDepartments
            // 
            this.dgvDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colManufactureDepartmentId,
            this.colDepartmentId,
            this.colDepartmentName,
            this.colDepartmentQuantity});
            this.dgvDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDepartments.Location = new System.Drawing.Point(5, 238);
            this.dgvDepartments.MultiSelect = false;
            this.dgvDepartments.Name = "dgvDepartments";
            this.dgvDepartments.Size = new System.Drawing.Size(752, 0);
            this.dgvDepartments.TabIndex = 10;
            this.dgvDepartments.Visible = false;
            // 
            // colManufactureDepartmentId
            // 
            this.colManufactureDepartmentId.DataPropertyName = "Id";
            this.colManufactureDepartmentId.HeaderText = "ManufactureDepartmentId";
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
            // colDepartmentQuantity
            // 
            this.colDepartmentQuantity.DataPropertyName = "Quantity";
            this.colDepartmentQuantity.HeaderText = "Assigned Quantity";
            this.colDepartmentQuantity.Name = "colDepartmentQuantity";
            this.colDepartmentQuantity.Width = 120;
            // 
            // pnlInputBase
            // 
            this.pnlInputBase.Controls.Add(this.pnlConsumed);
            this.pnlInputBase.Controls.Add(this.splitter3);
            this.pnlInputBase.Controls.Add(this.pnlManufactured);
            this.pnlInputBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInputBase.Location = new System.Drawing.Point(5, 29);
            this.pnlInputBase.Name = "pnlInputBase";
            this.pnlInputBase.Size = new System.Drawing.Size(752, 143);
            this.pnlInputBase.TabIndex = 11;
            // 
            // pnlConsumed
            // 
            this.pnlConsumed.Controls.Add(this.dgvItems);
            this.pnlConsumed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConsumed.Location = new System.Drawing.Point(309, 0);
            this.pnlConsumed.Name = "pnlConsumed";
            this.pnlConsumed.Size = new System.Drawing.Size(443, 143);
            this.pnlConsumed.TabIndex = 13;
            this.pnlConsumed.TabStop = false;
            this.pnlConsumed.Text = "Consumed";
            // 
            // dgvItems
            // 
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(3, 16);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.OrderId = 0;
            this.dgvItems.Size = new System.Drawing.Size(437, 124);
            this.dgvItems.TabIndex = 6;
            // 
            // splitter3
            // 
            this.splitter3.Enabled = false;
            this.splitter3.Location = new System.Drawing.Point(304, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(5, 143);
            this.splitter3.TabIndex = 0;
            this.splitter3.TabStop = false;
            // 
            // pnlManufactured
            // 
            this.pnlManufactured.Controls.Add(this.tableLayoutPanel1);
            this.pnlManufactured.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlManufactured.Location = new System.Drawing.Point(0, 0);
            this.pnlManufactured.Name = "pnlManufactured";
            this.pnlManufactured.Size = new System.Drawing.Size(304, 143);
            this.pnlManufactured.TabIndex = 12;
            this.pnlManufactured.TabStop = false;
            this.pnlManufactured.Text = "Manufactured";
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(5, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(752, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Assign the manufactured product to next department from below section.";
            this.label4.Visible = false;
            // 
            // UserManufactureCreateForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(762, 270);
            this.Controls.Add(this.dgvDepartments);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlInputBase);
            this.Controls.Add(this.lblEmployeeName);
            this.Controls.Add(this.pnlFooter);
            this.Name = "UserManufactureCreateForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Manufactured Quantity";
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).EndInit();
            this.pnlInputBase.ResumeLayout(false);
            this.pnlConsumed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.pnlManufactured.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.NumericUpDown txtQuantity;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkAssignToNextDepartment;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox txtPackage;
        private System.Windows.Forms.DataGridView dgvDepartments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManufactureDepartmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartmentQuantity;
        private System.Windows.Forms.Panel pnlInputBase;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.GroupBox pnlConsumed;
        private System.Windows.Forms.GroupBox pnlManufactured;
        private Common.GridView.InventoryUnits.InventoryUnitDataGridView dgvItems;
        private System.Windows.Forms.Label label4;
    }
}