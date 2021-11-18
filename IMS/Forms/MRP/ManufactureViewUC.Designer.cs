namespace IMS.Forms.MRP
{
    partial class ManufactureViewUC
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
            this.pnlExtra = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlDepartments = new System.Windows.Forms.Panel();
            this.dgvDepartments = new System.Windows.Forms.DataGridView();
            this.colDepartmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartmentPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlDepartmentSingle = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlEmployees = new System.Windows.Forms.Panel();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.colEmployeesId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployeesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployeesRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.pnlEmployeesHisotory = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colHistoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHistoryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHistoryProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHistoryQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.lblIntermediateProducts = new System.Windows.Forms.Label();
            this.lblEmployees = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlExtra.SuspendLayout();
            this.pnlDepartments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).BeginInit();
            this.pnlDepartmentSingle.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.pnlEmployeesHisotory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlExtra
            // 
            this.pnlExtra.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlExtra.Controls.Add(this.splitter1);
            this.pnlExtra.Controls.Add(this.pnlDepartments);
            this.pnlExtra.Controls.Add(this.pnlDepartmentSingle);
            this.pnlExtra.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlExtra.Location = new System.Drawing.Point(0, 43);
            this.pnlExtra.Name = "pnlExtra";
            this.pnlExtra.Size = new System.Drawing.Size(895, 287);
            this.pnlExtra.TabIndex = 8;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(321, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 287);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // pnlDepartments
            // 
            this.pnlDepartments.BackColor = System.Drawing.SystemColors.Control;
            this.pnlDepartments.Controls.Add(this.dgvDepartments);
            this.pnlDepartments.Controls.Add(this.flowLayoutPanel1);
            this.pnlDepartments.Controls.Add(this.label4);
            this.pnlDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDepartments.Location = new System.Drawing.Point(0, 0);
            this.pnlDepartments.Name = "pnlDepartments";
            this.pnlDepartments.Size = new System.Drawing.Size(326, 287);
            this.pnlDepartments.TabIndex = 5;
            // 
            // dgvDepartments
            // 
            this.dgvDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDepartmentName,
            this.colDepartmentPosition});
            this.dgvDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDepartments.Location = new System.Drawing.Point(0, 26);
            this.dgvDepartments.Name = "dgvDepartments";
            this.dgvDepartments.Size = new System.Drawing.Size(287, 261);
            this.dgvDepartments.TabIndex = 1;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.DataPropertyName = "Name";
            this.colDepartmentName.HeaderText = "Name";
            this.colDepartmentName.Name = "colDepartmentName";
            this.colDepartmentName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDepartmentName.Width = 180;
            // 
            // colDepartmentPosition
            // 
            this.colDepartmentPosition.DataPropertyName = "Position";
            this.colDepartmentPosition.HeaderText = "Sequence";
            this.colDepartmentPosition.Name = "colDepartmentPosition";
            this.colDepartmentPosition.Width = 60;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(287, 26);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(39, 261);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(326, 26);
            this.label4.TabIndex = 0;
            this.label4.Text = "Departments";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDepartmentSingle
            // 
            this.pnlDepartmentSingle.Controls.Add(this.panel2);
            this.pnlDepartmentSingle.Controls.Add(this.lblIntermediateProducts);
            this.pnlDepartmentSingle.Controls.Add(this.lblEmployees);
            this.pnlDepartmentSingle.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDepartmentSingle.Location = new System.Drawing.Point(326, 0);
            this.pnlDepartmentSingle.Name = "pnlDepartmentSingle";
            this.pnlDepartmentSingle.Size = new System.Drawing.Size(569, 287);
            this.pnlDepartmentSingle.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnlEmployees);
            this.panel2.Controls.Add(this.splitter2);
            this.panel2.Controls.Add(this.pnlEmployeesHisotory);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(569, 248);
            this.panel2.TabIndex = 2;
            // 
            // pnlEmployees
            // 
            this.pnlEmployees.BackColor = System.Drawing.SystemColors.Control;
            this.pnlEmployees.Controls.Add(this.dgvEmployees);
            this.pnlEmployees.Controls.Add(this.label2);
            this.pnlEmployees.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlEmployees.Location = new System.Drawing.Point(0, 0);
            this.pnlEmployees.Name = "pnlEmployees";
            this.pnlEmployees.Size = new System.Drawing.Size(285, 248);
            this.pnlEmployees.TabIndex = 6;
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEmployeesId,
            this.colEmployeesName,
            this.colEmployeesRate});
            this.dgvEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmployees.Location = new System.Drawing.Point(0, 26);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.Size = new System.Drawing.Size(285, 222);
            this.dgvEmployees.TabIndex = 2;
            // 
            // colEmployeesId
            // 
            this.colEmployeesId.DataPropertyName = "UserId";
            this.colEmployeesId.HeaderText = "Id";
            this.colEmployeesId.Name = "colEmployeesId";
            this.colEmployeesId.Visible = false;
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
            this.colEmployeesRate.Width = 70;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(285, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Employees";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Enabled = false;
            this.splitter2.Location = new System.Drawing.Point(285, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(5, 248);
            this.splitter2.TabIndex = 9;
            this.splitter2.TabStop = false;
            // 
            // pnlEmployeesHisotory
            // 
            this.pnlEmployeesHisotory.BackColor = System.Drawing.SystemColors.Control;
            this.pnlEmployeesHisotory.Controls.Add(this.button1);
            this.pnlEmployeesHisotory.Controls.Add(this.dataGridView1);
            this.pnlEmployeesHisotory.Controls.Add(this.lblEmployeeName);
            this.pnlEmployeesHisotory.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlEmployeesHisotory.Location = new System.Drawing.Point(290, 0);
            this.pnlEmployeesHisotory.Name = "pnlEmployeesHisotory";
            this.pnlEmployeesHisotory.Size = new System.Drawing.Size(279, 248);
            this.pnlEmployeesHisotory.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(189, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add Quantity";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHistoryId,
            this.colHistoryDate,
            this.colHistoryProduct,
            this.colHistoryQuantity});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(279, 222);
            this.dataGridView1.TabIndex = 2;
            // 
            // colHistoryId
            // 
            this.colHistoryId.DataPropertyName = "UserId";
            this.colHistoryId.HeaderText = "Id";
            this.colHistoryId.Name = "colHistoryId";
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
            this.colHistoryProduct.HeaderText = "Product";
            this.colHistoryProduct.Name = "colHistoryProduct";
            // 
            // colHistoryQuantity
            // 
            this.colHistoryQuantity.DataPropertyName = "Quantity";
            this.colHistoryQuantity.HeaderText = "Quantity";
            this.colHistoryQuantity.Name = "colHistoryQuantity";
            this.colHistoryQuantity.Width = 60;
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEmployeeName.Location = new System.Drawing.Point(0, 0);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(279, 26);
            this.lblEmployeeName.TabIndex = 1;
            this.lblEmployeeName.Text = "Manufacture History of ______";
            this.lblEmployeeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lblEmployees.Location = new System.Drawing.Point(0, 0);
            this.lblEmployees.Name = "lblEmployees";
            this.lblEmployees.Size = new System.Drawing.Size(569, 26);
            this.lblEmployees.TabIndex = 1;
            this.lblEmployees.Text = "Department Name";
            this.lblEmployees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 43);
            this.panel1.TabIndex = 0;
            // 
            // ManufactureViewUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlExtra);
            this.Controls.Add(this.panel1);
            this.Name = "ManufactureViewUC";
            this.Size = new System.Drawing.Size(895, 421);
            this.pnlExtra.ResumeLayout(false);
            this.pnlDepartments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).EndInit();
            this.pnlDepartmentSingle.ResumeLayout(false);
            this.pnlDepartmentSingle.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.pnlEmployeesHisotory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlExtra;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlDepartments;
        private System.Windows.Forms.DataGridView dgvDepartments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartmentPosition;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlEmployees;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployeesId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployeesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployeesRate;
        private System.Windows.Forms.Label lblEmployees;
        private System.Windows.Forms.Panel pnlEmployeesHisotory;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistoryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistoryProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistoryQuantity;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Label lblIntermediateProducts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlDepartmentSingle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}
