namespace IMS.Forms.Inventory.Transaction
{
    partial class TransactionCreateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionCreateForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDiscountType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.NumericUpDown();
            this.txtDiscount = new System.Windows.Forms.NumericUpDown();
            this.txtSum = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtPaidAmount = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlPaymentDueDate = new System.Windows.Forms.Panel();
            this.dtPaymentDueDate = new IMS.Forms.Common.Date.NepaliDateTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbCash = new System.Windows.Forms.RadioButton();
            this.rbCredit = new System.Windows.Forms.RadioButton();
            this.lblClient = new System.Windows.Forms.Label();
            this.lblExpectedDate = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dtExpectedDate = new IMS.Forms.Common.Date.NepaliDateTextBox();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.pnlParticulars = new System.Windows.Forms.Panel();
            this.txtParticulars = new System.Windows.Forms.TextBox();
            this.rbCustomParticulars = new System.Windows.Forms.RadioButton();
            this.rbAllItemsParticulars = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.rbReceiptNoParticulars = new System.Windows.Forms.RadioButton();
            this.dgvItems = new IMS.Forms.Common.GridView.InventoryUnits.InventoryUnitDataGridView();
            this.saveFooterUC1 = new IMS.Forms.Common.Display.SaveFooterUC();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSum)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaidAmount)).BeginInit();
            this.pnlPaymentDueDate.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.pnlParticulars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 396);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 75);
            this.panel1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtTotal, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtDiscount, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtSum, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(262, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(256, 75);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cbDiscountType);
            this.panel2.Location = new System.Drawing.Point(3, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(90, 19);
            this.panel2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "Discount";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbDiscountType
            // 
            this.cbDiscountType.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbDiscountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDiscountType.FormattingEnabled = true;
            this.cbDiscountType.Items.AddRange(new object[] {
            "%",
            "Rs."});
            this.cbDiscountType.Location = new System.Drawing.Point(58, 0);
            this.cbDiscountType.Name = "cbDiscountType";
            this.cbDiscountType.Size = new System.Drawing.Size(32, 21);
            this.cbDiscountType.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "Total";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotal
            // 
            this.txtTotal.DecimalPlaces = 1;
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(99, 3);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(139, 20);
            this.txtTotal.TabIndex = 9;
            // 
            // txtDiscount
            // 
            this.txtDiscount.DecimalPlaces = 1;
            this.txtDiscount.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.txtDiscount.Location = new System.Drawing.Point(99, 28);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(139, 20);
            this.txtDiscount.TabIndex = 13;
            // 
            // txtSum
            // 
            this.txtSum.DecimalPlaces = 1;
            this.txtSum.Enabled = false;
            this.txtSum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.txtSum.Location = new System.Drawing.Point(99, 53);
            this.txtSum.Name = "txtSum";
            this.txtSum.ReadOnly = true;
            this.txtSum.Size = new System.Drawing.Size(139, 20);
            this.txtSum.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Sum";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtPaidAmount);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.pnlPaymentDueDate);
            this.panel3.Controls.Add(this.rbCash);
            this.panel3.Controls.Add(this.rbCredit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(256, 75);
            this.panel3.TabIndex = 6;
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.DecimalPlaces = 1;
            this.txtPaidAmount.Enabled = false;
            this.txtPaidAmount.Location = new System.Drawing.Point(73, 50);
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.Size = new System.Drawing.Size(139, 20);
            this.txtPaidAmount.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Payment";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 24);
            this.label7.TabIndex = 10;
            this.label7.Text = "Paid Amt.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlPaymentDueDate
            // 
            this.pnlPaymentDueDate.Controls.Add(this.dtPaymentDueDate);
            this.pnlPaymentDueDate.Controls.Add(this.label3);
            this.pnlPaymentDueDate.Location = new System.Drawing.Point(4, 23);
            this.pnlPaymentDueDate.Name = "pnlPaymentDueDate";
            this.pnlPaymentDueDate.Size = new System.Drawing.Size(216, 23);
            this.pnlPaymentDueDate.TabIndex = 8;
            this.pnlPaymentDueDate.Visible = false;
            // 
            // dtPaymentDueDate
            // 
            this.dtPaymentDueDate.Location = new System.Drawing.Point(107, 3);
            this.dtPaymentDueDate.Name = "dtPaymentDueDate";
            this.dtPaymentDueDate.Size = new System.Drawing.Size(100, 20);
            this.dtPaymentDueDate.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Payment Due Date";
            // 
            // rbCash
            // 
            this.rbCash.AutoSize = true;
            this.rbCash.Location = new System.Drawing.Point(60, 2);
            this.rbCash.Name = "rbCash";
            this.rbCash.Size = new System.Drawing.Size(74, 17);
            this.rbCash.TabIndex = 6;
            this.rbCash.Text = "Cash (Full)";
            this.rbCash.UseVisualStyleBackColor = true;
            // 
            // rbCredit
            // 
            this.rbCredit.AutoSize = true;
            this.rbCredit.Location = new System.Drawing.Point(140, 2);
            this.rbCredit.Name = "rbCredit";
            this.rbCredit.Size = new System.Drawing.Size(90, 17);
            this.rbCredit.TabIndex = 7;
            this.rbCredit.Text = "Credit (Partial)";
            this.rbCredit.UseVisualStyleBackColor = true;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClient.Location = new System.Drawing.Point(3, 0);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(51, 13);
            this.lblClient.TabIndex = 0;
            this.lblClient.Text = "Customer";
            // 
            // lblExpectedDate
            // 
            this.lblExpectedDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExpectedDate.AutoSize = true;
            this.lblExpectedDate.Location = new System.Drawing.Point(333, 6);
            this.lblExpectedDate.Name = "lblExpectedDate";
            this.lblExpectedDate.Size = new System.Drawing.Size(71, 13);
            this.lblExpectedDate.TabIndex = 3;
            this.lblExpectedDate.Text = "Delivery Date";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.74131F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.41313F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.81081F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.81467F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.23166F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.79537F));
            this.tableLayoutPanel1.Controls.Add(this.cbClient, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblClient, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtAddress, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPhone, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(518, 27);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // cbClient
            // 
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(68, 2);
            this.cbClient.Margin = new System.Windows.Forms.Padding(2);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(138, 21);
            this.cbClient.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(211, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(267, 3);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(107, 20);
            this.txtAddress.TabIndex = 3;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(433, 3);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(82, 20);
            this.txtPhone.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(380, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Phone";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.dtExpectedDate);
            this.panel9.Controls.Add(this.lblExpectedDate);
            this.panel9.Controls.Add(this.txtReceiptNo);
            this.panel9.Controls.Add(this.label8);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(518, 26);
            this.panel9.TabIndex = 0;
            // 
            // dtExpectedDate
            // 
            this.dtExpectedDate.Location = new System.Drawing.Point(410, 3);
            this.dtExpectedDate.Name = "dtExpectedDate";
            this.dtExpectedDate.Size = new System.Drawing.Size(100, 20);
            this.dtExpectedDate.TabIndex = 6;
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Location = new System.Drawing.Point(67, 3);
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.Size = new System.Drawing.Size(141, 20);
            this.txtReceiptNo.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Receipt No.";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // pnlParticulars
            // 
            this.pnlParticulars.Controls.Add(this.txtParticulars);
            this.pnlParticulars.Controls.Add(this.rbCustomParticulars);
            this.pnlParticulars.Controls.Add(this.rbAllItemsParticulars);
            this.pnlParticulars.Controls.Add(this.label10);
            this.pnlParticulars.Controls.Add(this.rbReceiptNoParticulars);
            this.pnlParticulars.Location = new System.Drawing.Point(93, 213);
            this.pnlParticulars.Name = "pnlParticulars";
            this.pnlParticulars.Size = new System.Drawing.Size(293, 44);
            this.pnlParticulars.TabIndex = 51;
            this.pnlParticulars.Visible = false;
            // 
            // txtParticulars
            // 
            this.txtParticulars.Location = new System.Drawing.Point(4, 21);
            this.txtParticulars.Name = "txtParticulars";
            this.txtParticulars.Size = new System.Drawing.Size(285, 20);
            this.txtParticulars.TabIndex = 4;
            // 
            // rbCustomParticulars
            // 
            this.rbCustomParticulars.AutoSize = true;
            this.rbCustomParticulars.Location = new System.Drawing.Point(229, 2);
            this.rbCustomParticulars.Name = "rbCustomParticulars";
            this.rbCustomParticulars.Size = new System.Drawing.Size(60, 17);
            this.rbCustomParticulars.TabIndex = 3;
            this.rbCustomParticulars.Text = "Custom";
            this.rbCustomParticulars.UseVisualStyleBackColor = true;
            // 
            // rbAllItemsParticulars
            // 
            this.rbAllItemsParticulars.AutoSize = true;
            this.rbAllItemsParticulars.Location = new System.Drawing.Point(159, 3);
            this.rbAllItemsParticulars.Name = "rbAllItemsParticulars";
            this.rbAllItemsParticulars.Size = new System.Drawing.Size(64, 17);
            this.rbAllItemsParticulars.TabIndex = 2;
            this.rbAllItemsParticulars.Text = "All Items";
            this.rbAllItemsParticulars.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(-1, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Particulars";
            // 
            // rbReceiptNoParticulars
            // 
            this.rbReceiptNoParticulars.AutoSize = true;
            this.rbReceiptNoParticulars.Checked = true;
            this.rbReceiptNoParticulars.Location = new System.Drawing.Point(71, 2);
            this.rbReceiptNoParticulars.Name = "rbReceiptNoParticulars";
            this.rbReceiptNoParticulars.Size = new System.Drawing.Size(82, 17);
            this.rbReceiptNoParticulars.TabIndex = 0;
            this.rbReceiptNoParticulars.TabStop = true;
            this.rbReceiptNoParticulars.Text = "Receipt No.";
            this.rbReceiptNoParticulars.UseVisualStyleBackColor = true;
            // 
            // dgvItems
            // 
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 57);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.Size = new System.Drawing.Size(518, 339);
            this.dgvItems.TabIndex = 5;
            // 
            // saveFooterUC1
            // 
            this.saveFooterUC1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.saveFooterUC1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.saveFooterUC1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveFooterUC1.Location = new System.Drawing.Point(0, 471);
            this.saveFooterUC1.Name = "saveFooterUC1";
            this.saveFooterUC1.Padding = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.saveFooterUC1.Size = new System.Drawing.Size(518, 35);
            this.saveFooterUC1.TabIndex = 50;
            // 
            // TransactionCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 506);
            this.Controls.Add(this.pnlParticulars);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.saveFooterUC1);
            this.MinimizeBox = false;
            this.Name = "TransactionCreateForm";
            this.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Transaction";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSum)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaidAmount)).EndInit();
            this.pnlPaymentDueDate.ResumeLayout(false);
            this.pnlPaymentDueDate.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.pnlParticulars.ResumeLayout(false);
            this.pnlParticulars.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbCredit;
        private System.Windows.Forms.RadioButton rbCash;
        private System.Windows.Forms.Label lblExpectedDate;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Panel pnlPaymentDueDate;
        private System.Windows.Forms.Label label3;
        private Common.GridView.InventoryUnits.InventoryUnitDataGridView dgvItems;
        private System.Windows.Forms.NumericUpDown txtTotal;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.NumericUpDown txtPaidAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TextBox txtReceiptNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox cbClient;
        private Common.Display.SaveFooterUC saveFooterUC1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtDiscount;
        private System.Windows.Forms.NumericUpDown txtSum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlParticulars;
        private System.Windows.Forms.RadioButton rbCustomParticulars;
        private System.Windows.Forms.RadioButton rbAllItemsParticulars;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rbReceiptNoParticulars;
        private System.Windows.Forms.TextBox txtParticulars;
        private Common.Date.NepaliDateTextBox dtPaymentDueDate;
        private Common.Date.NepaliDateTextBox dtExpectedDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbDiscountType;
    }
}