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
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.cbUom = new System.Windows.Forms.ComboBox();
            this.tbSKU = new System.Windows.Forms.MaskedTextBox();
            this.lblUOM = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPackage = new System.Windows.Forms.ComboBox();
            this.lblPackage = new System.Windows.Forms.Label();
            this.tbProductName = new System.Windows.Forms.MaskedTextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numSupplyPrice = new System.Windows.Forms.NumericUpDown();
            this.label32 = new System.Windows.Forms.Label();
            this.numRetailPrice = new System.Windows.Forms.NumericUpDown();
            this.label33 = new System.Windows.Forms.Label();
            this.chkUse = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbInStockQuantity = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbBasicDetails = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tblBasicDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSupplyPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRetailPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInStockQuantity)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.gbBasicDetails.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblBasicDetails
            // 
            this.tblBasicDetails.ColumnCount = 4;
            this.tblBasicDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.4617F));
            this.tblBasicDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.29813F));
            this.tblBasicDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.25466F));
            this.tblBasicDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.98551F));
            this.tblBasicDetails.Controls.Add(this.cbCategory, 1, 2);
            this.tblBasicDetails.Controls.Add(this.tbSKU, 1, 1);
            this.tblBasicDetails.Controls.Add(this.label2, 0, 0);
            this.tblBasicDetails.Controls.Add(this.tbProductName, 1, 0);
            this.tblBasicDetails.Controls.Add(this.lblCategory, 0, 2);
            this.tblBasicDetails.Controls.Add(this.label12, 0, 1);
            this.tblBasicDetails.Controls.Add(this.label33, 0, 4);
            this.tblBasicDetails.Controls.Add(this.chkUse, 1, 4);
            this.tblBasicDetails.Controls.Add(this.label3, 0, 3);
            this.tblBasicDetails.Controls.Add(this.tbInStockQuantity, 1, 3);
            this.tblBasicDetails.Controls.Add(this.lblPackage, 2, 0);
            this.tblBasicDetails.Controls.Add(this.cbPackage, 3, 0);
            this.tblBasicDetails.Controls.Add(this.lblUOM, 2, 1);
            this.tblBasicDetails.Controls.Add(this.cbUom, 3, 1);
            this.tblBasicDetails.Controls.Add(this.label32, 2, 3);
            this.tblBasicDetails.Controls.Add(this.numRetailPrice, 3, 3);
            this.tblBasicDetails.Controls.Add(this.label9, 2, 2);
            this.tblBasicDetails.Controls.Add(this.numSupplyPrice, 3, 2);
            this.tblBasicDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblBasicDetails.Location = new System.Drawing.Point(10, 16);
            this.tblBasicDetails.Name = "tblBasicDetails";
            this.tblBasicDetails.RowCount = 5;
            this.tblBasicDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblBasicDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblBasicDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblBasicDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblBasicDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblBasicDetails.Size = new System.Drawing.Size(527, 182);
            this.tblBasicDetails.TabIndex = 1;
            // 
            // cbCategory
            // 
            this.cbCategory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(105, 75);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(149, 21);
            this.cbCategory.TabIndex = 5;
            // 
            // cbUom
            // 
            this.cbUom.FormattingEnabled = true;
            this.cbUom.Location = new System.Drawing.Point(376, 39);
            this.cbUom.Name = "cbUom";
            this.cbUom.Size = new System.Drawing.Size(124, 21);
            this.cbUom.TabIndex = 8;
            // 
            // tbSKU
            // 
            this.tbSKU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSKU.Location = new System.Drawing.Point(104, 38);
            this.tbSKU.Margin = new System.Windows.Forms.Padding(2);
            this.tbSKU.Name = "tbSKU";
            this.tbSKU.Size = new System.Drawing.Size(151, 21);
            this.tbSKU.TabIndex = 3;
            // 
            // lblUOM
            // 
            this.lblUOM.AutoSize = true;
            this.lblUOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUOM.Location = new System.Drawing.Point(275, 36);
            this.lblUOM.Name = "lblUOM";
            this.lblUOM.Size = new System.Drawing.Size(68, 26);
            this.lblUOM.TabIndex = 2;
            this.lblUOM.Text = "Base Unit of Measure";
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
            // cbPackage
            // 
            this.cbPackage.FormattingEnabled = true;
            this.cbPackage.Location = new System.Drawing.Point(376, 3);
            this.cbPackage.Name = "cbPackage";
            this.cbPackage.Size = new System.Drawing.Size(124, 21);
            this.cbPackage.TabIndex = 6;
            // 
            // lblPackage
            // 
            this.lblPackage.AutoSize = true;
            this.lblPackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPackage.Location = new System.Drawing.Point(275, 0);
            this.lblPackage.Name = "lblPackage";
            this.lblPackage.Size = new System.Drawing.Size(77, 13);
            this.lblPackage.TabIndex = 0;
            this.lblPackage.Text = "Package Type";
            // 
            // tbProductName
            // 
            this.tbProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProductName.Location = new System.Drawing.Point(104, 2);
            this.tbProductName.Margin = new System.Windows.Forms.Padding(2);
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(151, 21);
            this.tbProductName.TabIndex = 1;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(2, 72);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(56, 13);
            this.lblCategory.TabIndex = 16;
            this.lblCategory.Text = "Category *";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 26);
            this.label12.TabIndex = 41;
            this.label12.Text = "Product Code (SKU)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(275, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Cost Price";
            // 
            // numSupplyPrice
            // 
            this.numSupplyPrice.DecimalPlaces = 1;
            this.numSupplyPrice.Enabled = false;
            this.numSupplyPrice.Location = new System.Drawing.Point(376, 75);
            this.numSupplyPrice.Name = "numSupplyPrice";
            this.numSupplyPrice.Size = new System.Drawing.Size(124, 20);
            this.numSupplyPrice.TabIndex = 2;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(275, 108);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(65, 13);
            this.label32.TabIndex = 2;
            this.label32.Text = "Selling Price";
            // 
            // numRetailPrice
            // 
            this.numRetailPrice.DecimalPlaces = 1;
            this.numRetailPrice.Enabled = false;
            this.numRetailPrice.Location = new System.Drawing.Point(376, 111);
            this.numRetailPrice.Name = "numRetailPrice";
            this.numRetailPrice.Size = new System.Drawing.Size(124, 20);
            this.numRetailPrice.TabIndex = 4;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(3, 144);
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
            this.chkUse.Location = new System.Drawing.Point(105, 147);
            this.chkUse.Name = "chkUse";
            this.chkUse.Size = new System.Drawing.Size(15, 14);
            this.chkUse.TabIndex = 9;
            this.toolTip1.SetToolTip(this.chkUse, "Either to Include in product selection in other sections.");
            this.chkUse.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "In Stock Quantity";
            // 
            // tbInStockQuantity
            // 
            this.tbInStockQuantity.DecimalPlaces = 2;
            this.tbInStockQuantity.Enabled = false;
            this.tbInStockQuantity.Location = new System.Drawing.Point(105, 111);
            this.tbInStockQuantity.Name = "tbInStockQuantity";
            this.tbInStockQuantity.Size = new System.Drawing.Size(149, 20);
            this.tbInStockQuantity.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(450, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(358, 6);
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
            this.panel1.Location = new System.Drawing.Point(5, 206);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 37);
            this.panel1.TabIndex = 10;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // gbBasicDetails
            // 
            this.gbBasicDetails.Controls.Add(this.tblBasicDetails);
            this.gbBasicDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBasicDetails.Location = new System.Drawing.Point(0, 0);
            this.gbBasicDetails.Name = "gbBasicDetails";
            this.gbBasicDetails.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.gbBasicDetails.Size = new System.Drawing.Size(547, 201);
            this.gbBasicDetails.TabIndex = 1;
            this.gbBasicDetails.TabStop = false;
            this.gbBasicDetails.Text = "Basic Details";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gbBasicDetails);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(547, 201);
            this.panel2.TabIndex = 101;
            // 
            // ProductCreateBasicForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(557, 248);
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
            ((System.ComponentModel.ISupportInitialize)(this.numSupplyPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRetailPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInStockQuantity)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.gbBasicDetails.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox cbUom;
        private System.Windows.Forms.Label lblUOM;
        private System.Windows.Forms.Label lblPackage;
        private System.Windows.Forms.ComboBox cbPackage;
        private System.Windows.Forms.NumericUpDown numSupplyPrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.NumericUpDown numRetailPrice;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown tbInStockQuantity;
    }
}