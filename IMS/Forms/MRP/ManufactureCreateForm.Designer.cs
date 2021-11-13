﻿namespace IMS.Forms.MRP
{
    partial class ManufactureCreateForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.cbFinalPackage = new System.Windows.Forms.ComboBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLotNo = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.cbFinalProduct = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlBasic = new System.Windows.Forms.Panel();
            this.pnlDepartments = new System.Windows.Forms.Panel();
            this.btnDepartmentAdd = new System.Windows.Forms.Button();
            this.dgvDepartments = new System.Windows.Forms.DataGridView();
            this.colDepartmentName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colDepartmentPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeparmentDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlEmployees = new System.Windows.Forms.Panel();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.lblEmployees = new System.Windows.Forms.Label();
            this.pnlExtra = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.colEmployeesId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployeesCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colEmployeesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployeesRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.pnlBasic.SuspendLayout();
            this.pnlDepartments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.pnlExtra.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.25952F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.74049F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 207F));
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown1, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbFinalPackage, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtRemarks, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtLotNo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbFinalProduct, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(572, 97);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(367, 67);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(170, 20);
            this.numericUpDown1.TabIndex = 7;
            // 
            // cbFinalPackage
            // 
            this.cbFinalPackage.FormattingEnabled = true;
            this.cbFinalPackage.Location = new System.Drawing.Point(367, 35);
            this.cbFinalPackage.Name = "cbFinalPackage";
            this.cbFinalPackage.Size = new System.Drawing.Size(169, 21);
            this.cbFinalPackage.TabIndex = 8;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(71, 67);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(170, 20);
            this.txtRemarks.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lot No. *";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name *";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Remarks";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(71, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(170, 20);
            this.txtName.TabIndex = 3;
            // 
            // txtLotNo
            // 
            this.txtLotNo.Enabled = false;
            this.txtLotNo.Location = new System.Drawing.Point(71, 35);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.Size = new System.Drawing.Size(170, 20);
            this.txtLotNo.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(273, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "Final Product *";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbFinalProduct
            // 
            this.cbFinalProduct.FormattingEnabled = true;
            this.cbFinalProduct.Location = new System.Drawing.Point(367, 3);
            this.cbFinalProduct.Name = "cbFinalProduct";
            this.cbFinalProduct.Size = new System.Drawing.Size(169, 21);
            this.cbFinalProduct.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(273, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 25);
            this.label7.TabIndex = 8;
            this.label7.Text = "Quantity *";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(273, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 25);
            this.label8.TabIndex = 9;
            this.label8.Text = "Package *";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(533, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(625, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(5, 392);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(711, 35);
            this.pnlFooter.TabIndex = 3;
            // 
            // pnlBasic
            // 
            this.pnlBasic.Controls.Add(this.tableLayoutPanel1);
            this.pnlBasic.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBasic.Location = new System.Drawing.Point(5, 5);
            this.pnlBasic.Name = "pnlBasic";
            this.pnlBasic.Size = new System.Drawing.Size(711, 97);
            this.pnlBasic.TabIndex = 4;
            // 
            // pnlDepartments
            // 
            this.pnlDepartments.BackColor = System.Drawing.SystemColors.Control;
            this.pnlDepartments.Controls.Add(this.btnDepartmentAdd);
            this.pnlDepartments.Controls.Add(this.dgvDepartments);
            this.pnlDepartments.Controls.Add(this.flowLayoutPanel1);
            this.pnlDepartments.Controls.Add(this.label4);
            this.pnlDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDepartments.Location = new System.Drawing.Point(0, 0);
            this.pnlDepartments.Name = "pnlDepartments";
            this.pnlDepartments.Size = new System.Drawing.Size(368, 287);
            this.pnlDepartments.TabIndex = 5;
            // 
            // btnDepartmentAdd
            // 
            this.btnDepartmentAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDepartmentAdd.Location = new System.Drawing.Point(293, 2);
            this.btnDepartmentAdd.Name = "btnDepartmentAdd";
            this.btnDepartmentAdd.Size = new System.Drawing.Size(39, 23);
            this.btnDepartmentAdd.TabIndex = 3;
            this.btnDepartmentAdd.Text = "Add";
            this.toolTip1.SetToolTip(this.btnDepartmentAdd, "Add Department");
            this.btnDepartmentAdd.UseVisualStyleBackColor = true;
            // 
            // dgvDepartments
            // 
            this.dgvDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDepartmentName,
            this.colDepartmentPosition,
            this.colDeparmentDelete});
            this.dgvDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDepartments.Location = new System.Drawing.Point(0, 26);
            this.dgvDepartments.Name = "dgvDepartments";
            this.dgvDepartments.Size = new System.Drawing.Size(329, 261);
            this.dgvDepartments.TabIndex = 1;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.DataPropertyName = "Name";
            this.colDepartmentName.HeaderText = "Name";
            this.colDepartmentName.Name = "colDepartmentName";
            this.colDepartmentName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDepartmentName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDepartmentName.Width = 180;
            // 
            // colDepartmentPosition
            // 
            this.colDepartmentPosition.HeaderText = "Sequence";
            this.colDepartmentPosition.Name = "colDepartmentPosition";
            this.colDepartmentPosition.Width = 50;
            // 
            // colDeparmentDelete
            // 
            this.colDeparmentDelete.HeaderText = "";
            this.colDeparmentDelete.Image = global::IMS.Properties.Resources.icons8_Delete_Red_16px;
            this.colDeparmentDelete.Name = "colDeparmentDelete";
            this.colDeparmentDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDeparmentDelete.ToolTipText = "Remove";
            this.colDeparmentDelete.Width = 26;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnMoveUp);
            this.flowLayoutPanel1.Controls.Add(this.btnMoveDown);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(329, 26);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(39, 261);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveUp.Location = new System.Drawing.Point(3, 3);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(30, 31);
            this.btnMoveUp.TabIndex = 0;
            this.btnMoveUp.Text = "↑";
            this.toolTip1.SetToolTip(this.btnMoveUp, "Move up in the sequence");
            this.btnMoveUp.UseVisualStyleBackColor = true;
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveDown.Location = new System.Drawing.Point(3, 40);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(30, 31);
            this.btnMoveDown.TabIndex = 1;
            this.btnMoveDown.Text = "↓";
            this.toolTip1.SetToolTip(this.btnMoveDown, "Move down in the sequence");
            this.btnMoveDown.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(368, 26);
            this.label4.TabIndex = 0;
            this.label4.Text = "Departments";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlEmployees
            // 
            this.pnlEmployees.BackColor = System.Drawing.SystemColors.Control;
            this.pnlEmployees.Controls.Add(this.dgvEmployees);
            this.pnlEmployees.Controls.Add(this.lblEmployees);
            this.pnlEmployees.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlEmployees.Location = new System.Drawing.Point(368, 0);
            this.pnlEmployees.Name = "pnlEmployees";
            this.pnlEmployees.Size = new System.Drawing.Size(343, 287);
            this.pnlEmployees.TabIndex = 6;
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEmployeesId,
            this.colEmployeesCheck,
            this.colEmployeesName,
            this.colEmployeesRate});
            this.dgvEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmployees.Location = new System.Drawing.Point(0, 26);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.Size = new System.Drawing.Size(343, 261);
            this.dgvEmployees.TabIndex = 2;
            // 
            // lblEmployees
            // 
            this.lblEmployees.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEmployees.Location = new System.Drawing.Point(0, 0);
            this.lblEmployees.Name = "lblEmployees";
            this.lblEmployees.Size = new System.Drawing.Size(343, 26);
            this.lblEmployees.TabIndex = 1;
            this.lblEmployees.Text = "Employees of ______";
            this.lblEmployees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlExtra
            // 
            this.pnlExtra.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlExtra.Controls.Add(this.splitter1);
            this.pnlExtra.Controls.Add(this.pnlDepartments);
            this.pnlExtra.Controls.Add(this.pnlEmployees);
            this.pnlExtra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlExtra.Location = new System.Drawing.Point(5, 105);
            this.pnlExtra.Name = "pnlExtra";
            this.pnlExtra.Size = new System.Drawing.Size(711, 287);
            this.pnlExtra.TabIndex = 7;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(363, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 287);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(5, 102);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(711, 3);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // colEmployeesId
            // 
            this.colEmployeesId.DataPropertyName = "Id";
            this.colEmployeesId.HeaderText = "Id";
            this.colEmployeesId.Name = "colEmployeesId";
            this.colEmployeesId.Visible = false;
            // 
            // colEmployeesCheck
            // 
            this.colEmployeesCheck.DataPropertyName = "Check";
            this.colEmployeesCheck.HeaderText = "Select";
            this.colEmployeesCheck.Name = "colEmployeesCheck";
            this.colEmployeesCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEmployeesCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEmployeesCheck.Width = 40;
            // 
            // colEmployeesName
            // 
            this.colEmployeesName.DataPropertyName = "Name";
            this.colEmployeesName.HeaderText = "Name";
            this.colEmployeesName.Name = "colEmployeesName";
            this.colEmployeesName.ReadOnly = true;
            this.colEmployeesName.Width = 180;
            // 
            // colEmployeesRate
            // 
            this.colEmployeesRate.DataPropertyName = "BuildRate";
            this.colEmployeesRate.HeaderText = "Rate";
            this.colEmployeesRate.Name = "colEmployeesRate";
            this.colEmployeesRate.Width = 70;
            // 
            // ManufactureCreateForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(721, 432);
            this.Controls.Add(this.pnlExtra);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.pnlBasic);
            this.Controls.Add(this.pnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ManufactureCreateForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manufacture Plan";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlBasic.ResumeLayout(false);
            this.pnlDepartments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.pnlExtra.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.NumericUpDown txtLotNo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlExtra;
        private System.Windows.Forms.Panel pnlEmployees;
        private System.Windows.Forms.Label lblEmployees;
        private System.Windows.Forms.Panel pnlDepartments;
        private System.Windows.Forms.Button btnDepartmentAdd;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView dgvDepartments;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlBasic;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbFinalProduct;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ComboBox cbFinalPackage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewComboBoxColumn colDepartmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartmentPosition;
        private System.Windows.Forms.DataGridViewImageColumn colDeparmentDelete;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployeesId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEmployeesCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployeesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployeesRate;
    }
}