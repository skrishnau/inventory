namespace IMS.Forms.Inventory.Products
{
    partial class ProductCreateBasicForm
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
            this.tblBasicDetails = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbProductName = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbSKU = new System.Windows.Forms.MaskedTextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.chkUse = new System.Windows.Forms.CheckBox();
            this.lblPackage = new System.Windows.Forms.Label();
            this.cbPackage = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbBasicDetails = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gbUom = new System.Windows.Forms.GroupBox();
            this.pnlUomList = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAddUom = new IMS.Forms.Common.Buttons.MenuButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tblBasicDetails.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.gbBasicDetails.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbUom.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblBasicDetails
            // 
            this.tblBasicDetails.ColumnCount = 4;
            this.tblBasicDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.4617F));
            this.tblBasicDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.76923F));
            this.tblBasicDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.62937F));
            this.tblBasicDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.98551F));
            this.tblBasicDetails.Controls.Add(this.label2, 0, 0);
            this.tblBasicDetails.Controls.Add(this.tbProductName, 1, 0);
            this.tblBasicDetails.Controls.Add(this.label12, 2, 0);
            this.tblBasicDetails.Controls.Add(this.tbSKU, 3, 0);
            this.tblBasicDetails.Controls.Add(this.lblCategory, 0, 1);
            this.tblBasicDetails.Controls.Add(this.cbCategory, 1, 1);
            this.tblBasicDetails.Controls.Add(this.label33, 2, 1);
            this.tblBasicDetails.Controls.Add(this.chkUse, 3, 1);
            this.tblBasicDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblBasicDetails.Location = new System.Drawing.Point(10, 16);
            this.tblBasicDetails.Name = "tblBasicDetails";
            this.tblBasicDetails.RowCount = 2;
            this.tblBasicDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblBasicDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblBasicDetails.Size = new System.Drawing.Size(586, 70);
            this.tblBasicDetails.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Product Name *";
            // 
            // tbProductName
            // 
            this.tbProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProductName.Location = new System.Drawing.Point(116, 2);
            this.tbProductName.Margin = new System.Windows.Forms.Padding(2);
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(151, 21);
            this.tbProductName.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(297, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 13);
            this.label12.TabIndex = 41;
            this.label12.Text = "Product Code (SKU)";
            // 
            // tbSKU
            // 
            this.tbSKU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSKU.Location = new System.Drawing.Point(417, 2);
            this.tbSKU.Margin = new System.Windows.Forms.Padding(2);
            this.tbSKU.Name = "tbSKU";
            this.tbSKU.Size = new System.Drawing.Size(151, 21);
            this.tbSKU.TabIndex = 3;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(2, 35);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(56, 13);
            this.lblCategory.TabIndex = 16;
            this.lblCategory.Text = "Category *";
            // 
            // cbCategory
            // 
            this.cbCategory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(117, 38);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(149, 21);
            this.cbCategory.TabIndex = 5;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(297, 35);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(35, 13);
            this.label33.TabIndex = 48;
            this.label33.Text = "Use ?";
            this.toolTip1.SetToolTip(this.label33, "Either to Include in product selection in other sections.");
            // 
            // chkUse
            // 
            this.chkUse.AutoSize = true;
            this.chkUse.Checked = true;
            this.chkUse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUse.Location = new System.Drawing.Point(418, 38);
            this.chkUse.Name = "chkUse";
            this.chkUse.Size = new System.Drawing.Size(15, 14);
            this.chkUse.TabIndex = 9;
            this.toolTip1.SetToolTip(this.chkUse, "Either to Include in product selection in other sections.");
            this.chkUse.UseVisualStyleBackColor = true;
            // 
            // lblPackage
            // 
            this.lblPackage.AutoSize = true;
            this.lblPackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPackage.Location = new System.Drawing.Point(342, 10);
            this.lblPackage.Name = "lblPackage";
            this.lblPackage.Size = new System.Drawing.Size(104, 13);
            this.lblPackage.TabIndex = 0;
            this.lblPackage.Text = "Base Package Type";
            // 
            // cbPackage
            // 
            this.cbPackage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPackage.FormattingEnabled = true;
            this.cbPackage.Location = new System.Drawing.Point(452, 5);
            this.cbPackage.Name = "cbPackage";
            this.cbPackage.Size = new System.Drawing.Size(124, 21);
            this.cbPackage.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(509, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(417, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(5, 368);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(606, 37);
            this.panel1.TabIndex = 10;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // gbBasicDetails
            // 
            this.gbBasicDetails.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbBasicDetails.Controls.Add(this.tblBasicDetails);
            this.gbBasicDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbBasicDetails.Location = new System.Drawing.Point(0, 0);
            this.gbBasicDetails.Name = "gbBasicDetails";
            this.gbBasicDetails.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.gbBasicDetails.Size = new System.Drawing.Size(606, 89);
            this.gbBasicDetails.TabIndex = 1;
            this.gbBasicDetails.TabStop = false;
            this.gbBasicDetails.Text = "Basic Details";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gbUom);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.gbBasicDetails);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(606, 363);
            this.panel2.TabIndex = 101;
            // 
            // gbUom
            // 
            this.gbUom.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbUom.Controls.Add(this.pnlUomList);
            this.gbUom.Controls.Add(this.panel3);
            this.gbUom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbUom.Location = new System.Drawing.Point(0, 99);
            this.gbUom.Name = "gbUom";
            this.gbUom.Size = new System.Drawing.Size(606, 264);
            this.gbUom.TabIndex = 3;
            this.gbUom.TabStop = false;
            this.gbUom.Text = "UOM (Unit of Measurements)";
            // 
            // pnlUomList
            // 
            this.pnlUomList.AutoScroll = true;
            this.pnlUomList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUomList.Location = new System.Drawing.Point(3, 48);
            this.pnlUomList.Name = "pnlUomList";
            this.pnlUomList.Size = new System.Drawing.Size(600, 213);
            this.pnlUomList.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAddUom);
            this.panel3.Controls.Add(this.lblPackage);
            this.panel3.Controls.Add(this.cbPackage);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(600, 32);
            this.panel3.TabIndex = 0;
            // 
            // btnAddUom
            // 
            this.btnAddUom.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnAddUom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUom.Image = global::IMS.Properties.Resources.icons8_Plus_Math_16px;
            this.btnAddUom.Location = new System.Drawing.Point(4, 4);
            this.btnAddUom.Name = "btnAddUom";
            this.btnAddUom.Size = new System.Drawing.Size(34, 25);
            this.btnAddUom.TabIndex = 0;
            this.btnAddUom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddUom.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 89);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(606, 10);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // ProductCreateBasicForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(616, 410);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProductCreateBasicForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Product";
            this.tblBasicDetails.ResumeLayout(false);
            this.tblBasicDetails.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.gbBasicDetails.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.gbUom.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel tblBasicDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox tbProductName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.MaskedTextBox tbSKU;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox gbBasicDetails;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.CheckBox chkUse;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label lblPackage;
        private System.Windows.Forms.ComboBox cbPackage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gbUom;
        private System.Windows.Forms.Panel pnlUomList;
        private System.Windows.Forms.Panel panel3;
        private Common.Buttons.MenuButton btnAddUom;
        private System.Windows.Forms.Splitter splitter1;
    }
}