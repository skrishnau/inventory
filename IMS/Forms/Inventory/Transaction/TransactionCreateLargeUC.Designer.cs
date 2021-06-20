namespace IMS.Forms.Inventory.Transaction
{
    partial class TransactionCreateLargeUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionCreateLargeUC));
            this.pnlReceipt = new System.Windows.Forms.Panel();
            this.cbAdjustmentCode = new System.Windows.Forms.ComboBox();
            this.dtCompletedDate = new IMS.Forms.Common.Date.NepaliDateTextBox();
            this.lblAdjustmentCode = new System.Windows.Forms.Label();
            this.lblCheckoutDate = new System.Windows.Forms.Label();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.lblReceoptNo = new System.Windows.Forms.Label();
            this.pnlCustomer = new System.Windows.Forms.TableLayoutPanel();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.saveFooterUC1 = new IMS.Forms.Common.Display.SaveFooterUC();
            this.pnlBottomInputs = new System.Windows.Forms.Panel();
            this.pnlPayment = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtPaidAmount = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlPaymentDueDate = new System.Windows.Forms.Panel();
            this.dtPaymentDueDate = new IMS.Forms.Common.Date.NepaliDateTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbCash = new System.Windows.Forms.RadioButton();
            this.rbCredit = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtExpectedDate = new IMS.Forms.Common.Date.NepaliDateTextBox();
            this.lblExpectedDate = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDiscountType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.NumericUpDown();
            this.txtDiscount = new System.Windows.Forms.NumericUpDown();
            this.txtSum = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvItems = new IMS.Forms.Common.GridView.InventoryUnits.InventoryUnitDataGridView();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTotalAdd = new System.Windows.Forms.NumericUpDown();
            this.txtQuantityAdd = new System.Windows.Forms.NumericUpDown();
            this.txtRateAdd = new System.Windows.Forms.NumericUpDown();
            this.cbPackageAdd = new System.Windows.Forms.ComboBox();
            this.cbProductAdd = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtInStockQuantityAdd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnResetAdd = new System.Windows.Forms.Button();
            this.btnAddAdd = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlReceipt.SuspendLayout();
            this.pnlCustomer.SuspendLayout();
            this.pnlBottomInputs.SuspendLayout();
            this.pnlPayment.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaidAmount)).BeginInit();
            this.pnlPaymentDueDate.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantityAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateAdd)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlReceipt
            // 
            this.pnlReceipt.Controls.Add(this.cbAdjustmentCode);
            this.pnlReceipt.Controls.Add(this.dtCompletedDate);
            this.pnlReceipt.Controls.Add(this.lblAdjustmentCode);
            this.pnlReceipt.Controls.Add(this.lblCheckoutDate);
            this.pnlReceipt.Controls.Add(this.txtReceiptNo);
            this.pnlReceipt.Controls.Add(this.lblReceoptNo);
            this.pnlReceipt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReceipt.Location = new System.Drawing.Point(0, 0);
            this.pnlReceipt.Name = "pnlReceipt";
            this.pnlReceipt.Size = new System.Drawing.Size(1036, 26);
            this.pnlReceipt.TabIndex = 1;
            // 
            // cbAdjustmentCode
            // 
            this.cbAdjustmentCode.FormattingEnabled = true;
            this.cbAdjustmentCode.Location = new System.Drawing.Point(296, 2);
            this.cbAdjustmentCode.Name = "cbAdjustmentCode";
            this.cbAdjustmentCode.Size = new System.Drawing.Size(144, 21);
            this.cbAdjustmentCode.TabIndex = 8;
            this.cbAdjustmentCode.Visible = false;
            // 
            // dtCompletedDate
            // 
            this.dtCompletedDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtCompletedDate.Location = new System.Drawing.Point(914, 2);
            this.dtCompletedDate.Name = "dtCompletedDate";
            this.dtCompletedDate.Size = new System.Drawing.Size(100, 20);
            this.dtCompletedDate.TabIndex = 13;
            this.dtCompletedDate.Validate = false;
            // 
            // lblAdjustmentCode
            // 
            this.lblAdjustmentCode.AutoSize = true;
            this.lblAdjustmentCode.Location = new System.Drawing.Point(213, 6);
            this.lblAdjustmentCode.Name = "lblAdjustmentCode";
            this.lblAdjustmentCode.Size = new System.Drawing.Size(81, 13);
            this.lblAdjustmentCode.TabIndex = 0;
            this.lblAdjustmentCode.Text = "Ajustment Code";
            this.lblAdjustmentCode.Visible = false;
            // 
            // lblCheckoutDate
            // 
            this.lblCheckoutDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCheckoutDate.AutoSize = true;
            this.lblCheckoutDate.Location = new System.Drawing.Point(828, 5);
            this.lblCheckoutDate.Name = "lblCheckoutDate";
            this.lblCheckoutDate.Size = new System.Drawing.Size(79, 13);
            this.lblCheckoutDate.TabIndex = 12;
            this.lblCheckoutDate.Text = "Checkout Date";
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Location = new System.Drawing.Point(67, 3);
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.Size = new System.Drawing.Size(141, 20);
            this.txtReceiptNo.TabIndex = 0;
            // 
            // lblReceoptNo
            // 
            this.lblReceoptNo.AutoSize = true;
            this.lblReceoptNo.Location = new System.Drawing.Point(0, 6);
            this.lblReceoptNo.Name = "lblReceoptNo";
            this.lblReceoptNo.Size = new System.Drawing.Size(64, 13);
            this.lblReceoptNo.TabIndex = 5;
            this.lblReceoptNo.Text = "Receipt No.";
            // 
            // pnlCustomer
            // 
            this.pnlCustomer.ColumnCount = 6;
            this.pnlCustomer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.74131F));
            this.pnlCustomer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.41313F));
            this.pnlCustomer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.81081F));
            this.pnlCustomer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.81467F));
            this.pnlCustomer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.23166F));
            this.pnlCustomer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.79537F));
            this.pnlCustomer.Controls.Add(this.cbClient, 1, 0);
            this.pnlCustomer.Controls.Add(this.lblClient, 0, 0);
            this.pnlCustomer.Controls.Add(this.label5, 2, 0);
            this.pnlCustomer.Controls.Add(this.txtAddress, 3, 0);
            this.pnlCustomer.Controls.Add(this.txtPhone, 5, 0);
            this.pnlCustomer.Controls.Add(this.label4, 4, 0);
            this.pnlCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCustomer.Location = new System.Drawing.Point(0, 26);
            this.pnlCustomer.Name = "pnlCustomer";
            this.pnlCustomer.RowCount = 1;
            this.pnlCustomer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlCustomer.Size = new System.Drawing.Size(1036, 27);
            this.pnlCustomer.TabIndex = 3;
            // 
            // cbClient
            // 
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(134, 2);
            this.cbClient.Margin = new System.Windows.Forms.Padding(2);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(138, 21);
            this.cbClient.TabIndex = 2;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(419, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(531, 3);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(137, 20);
            this.txtAddress.TabIndex = 3;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(863, 3);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(92, 20);
            this.txtPhone.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(757, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Phone";
            // 
            // saveFooterUC1
            // 
            this.saveFooterUC1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.saveFooterUC1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.saveFooterUC1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveFooterUC1.Location = new System.Drawing.Point(0, 477);
            this.saveFooterUC1.Name = "saveFooterUC1";
            this.saveFooterUC1.Padding = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.saveFooterUC1.Size = new System.Drawing.Size(1036, 35);
            this.saveFooterUC1.TabIndex = 51;
            // 
            // pnlBottomInputs
            // 
            this.pnlBottomInputs.Controls.Add(this.pnlPayment);
            this.pnlBottomInputs.Controls.Add(this.tableLayoutPanel2);
            this.pnlBottomInputs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomInputs.Location = new System.Drawing.Point(0, 378);
            this.pnlBottomInputs.Name = "pnlBottomInputs";
            this.pnlBottomInputs.Size = new System.Drawing.Size(1036, 99);
            this.pnlBottomInputs.TabIndex = 52;
            // 
            // pnlPayment
            // 
            this.pnlPayment.Controls.Add(this.panel3);
            this.pnlPayment.Controls.Add(this.panel4);
            this.pnlPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPayment.Location = new System.Drawing.Point(0, 0);
            this.pnlPayment.Name = "pnlPayment";
            this.pnlPayment.Size = new System.Drawing.Size(780, 99);
            this.pnlPayment.TabIndex = 52;
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
            this.dtPaymentDueDate.Validate = false;
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
            // panel4
            // 
            this.panel4.Controls.Add(this.dtExpectedDate);
            this.panel4.Controls.Add(this.lblExpectedDate);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 75);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(780, 24);
            this.panel4.TabIndex = 52;
            // 
            // dtExpectedDate
            // 
            this.dtExpectedDate.Location = new System.Drawing.Point(84, 2);
            this.dtExpectedDate.Name = "dtExpectedDate";
            this.dtExpectedDate.Size = new System.Drawing.Size(100, 20);
            this.dtExpectedDate.TabIndex = 11;
            this.dtExpectedDate.Validate = false;
            // 
            // lblExpectedDate
            // 
            this.lblExpectedDate.AutoSize = true;
            this.lblExpectedDate.Location = new System.Drawing.Point(7, 6);
            this.lblExpectedDate.Name = "lblExpectedDate";
            this.lblExpectedDate.Size = new System.Drawing.Size(71, 13);
            this.lblExpectedDate.TabIndex = 3;
            this.lblExpectedDate.Text = "Delivery Date";
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(780, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(256, 99);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cbDiscountType);
            this.panel2.Location = new System.Drawing.Point(3, 36);
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
            this.txtDiscount.Location = new System.Drawing.Point(99, 36);
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
            this.txtSum.Location = new System.Drawing.Point(99, 69);
            this.txtSum.Name = "txtSum";
            this.txtSum.ReadOnly = true;
            this.txtSum.Size = new System.Drawing.Size(139, 20);
            this.txtSum.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Sum";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvItems
            // 
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 104);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.OrderId = 0;
            this.dgvItems.Size = new System.Drawing.Size(1036, 274);
            this.dgvItems.TabIndex = 53;
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.5761F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.38406F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.50996F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.50996F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.50996F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.50996F));
            this.tableLayoutPanel1.Controls.Add(this.txtTotalAdd, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtQuantityAdd, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtRateAdd, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbPackageAdd, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbProductAdd, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label14, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label13, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label12, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label11, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label10, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtInStockQuantityAdd, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(37, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.09524F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.90476F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(972, 42);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtTotalAdd
            // 
            this.txtTotalAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotalAdd.Enabled = false;
            this.txtTotalAdd.Location = new System.Drawing.Point(842, 19);
            this.txtTotalAdd.Name = "txtTotalAdd";
            this.txtTotalAdd.ReadOnly = true;
            this.txtTotalAdd.Size = new System.Drawing.Size(127, 20);
            this.txtTotalAdd.TabIndex = 11;
            // 
            // txtQuantityAdd
            // 
            this.txtQuantityAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuantityAdd.Location = new System.Drawing.Point(449, 19);
            this.txtQuantityAdd.Name = "txtQuantityAdd";
            this.txtQuantityAdd.Size = new System.Drawing.Size(125, 20);
            this.txtQuantityAdd.TabIndex = 8;
            // 
            // txtRateAdd
            // 
            this.txtRateAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRateAdd.Location = new System.Drawing.Point(711, 19);
            this.txtRateAdd.Name = "txtRateAdd";
            this.txtRateAdd.Size = new System.Drawing.Size(125, 20);
            this.txtRateAdd.TabIndex = 10;
            // 
            // cbPackageAdd
            // 
            this.cbPackageAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbPackageAdd.FormattingEnabled = true;
            this.cbPackageAdd.Location = new System.Drawing.Point(580, 19);
            this.cbPackageAdd.Name = "cbPackageAdd";
            this.cbPackageAdd.Size = new System.Drawing.Size(125, 21);
            this.cbPackageAdd.TabIndex = 9;
            // 
            // cbProductAdd
            // 
            this.cbProductAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbProductAdd.FormattingEnabled = true;
            this.cbProductAdd.Location = new System.Drawing.Point(3, 19);
            this.cbProductAdd.Name = "cbProductAdd";
            this.cbProductAdd.Size = new System.Drawing.Size(262, 21);
            this.cbProductAdd.TabIndex = 6;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(842, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Total";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(711, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Rate";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(580, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Unit";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(449, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Quantity";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(271, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "In Stock Quantity";
            // 
            // txtInStockQuantityAdd
            // 
            this.txtInStockQuantityAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInStockQuantityAdd.Enabled = false;
            this.txtInStockQuantityAdd.Location = new System.Drawing.Point(271, 19);
            this.txtInStockQuantityAdd.Name = "txtInStockQuantityAdd";
            this.txtInStockQuantityAdd.ReadOnly = true;
            this.txtInStockQuantityAdd.Size = new System.Drawing.Size(172, 20);
            this.txtInStockQuantityAdd.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Product";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1036, 51);
            this.panel1.TabIndex = 54;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(37, 51);
            this.panel5.TabIndex = 55;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnResetAdd);
            this.panel6.Controls.Add(this.btnAddAdd);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(1009, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(27, 51);
            this.panel6.TabIndex = 56;
            // 
            // btnResetAdd
            // 
            this.btnResetAdd.BackColor = System.Drawing.Color.Pink;
            this.btnResetAdd.Location = new System.Drawing.Point(5, 25);
            this.btnResetAdd.Name = "btnResetAdd";
            this.btnResetAdd.Size = new System.Drawing.Size(20, 23);
            this.btnResetAdd.TabIndex = 13;
            this.btnResetAdd.Text = "X";
            this.toolTip1.SetToolTip(this.btnResetAdd, "Reset");
            this.btnResetAdd.UseVisualStyleBackColor = false;
            // 
            // btnAddAdd
            // 
            this.btnAddAdd.BackColor = System.Drawing.Color.GreenYellow;
            this.btnAddAdd.Location = new System.Drawing.Point(4, 2);
            this.btnAddAdd.Name = "btnAddAdd";
            this.btnAddAdd.Size = new System.Drawing.Size(20, 23);
            this.btnAddAdd.TabIndex = 12;
            this.btnAddAdd.Text = "+";
            this.toolTip1.SetToolTip(this.btnAddAdd, "Add");
            this.btnAddAdd.UseVisualStyleBackColor = false;
            // 
            // TransactionCreateLargeUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBottomInputs);
            this.Controls.Add(this.saveFooterUC1);
            this.Controls.Add(this.pnlCustomer);
            this.Controls.Add(this.pnlReceipt);
            this.Name = "TransactionCreateLargeUC";
            this.Size = new System.Drawing.Size(1036, 512);
            this.pnlReceipt.ResumeLayout(false);
            this.pnlReceipt.PerformLayout();
            this.pnlCustomer.ResumeLayout(false);
            this.pnlCustomer.PerformLayout();
            this.pnlBottomInputs.ResumeLayout(false);
            this.pnlPayment.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaidAmount)).EndInit();
            this.pnlPaymentDueDate.ResumeLayout(false);
            this.pnlPaymentDueDate.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantityAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateAdd)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlReceipt;
        private System.Windows.Forms.ComboBox cbAdjustmentCode;
        private Common.Date.NepaliDateTextBox dtCompletedDate;
        private System.Windows.Forms.Label lblAdjustmentCode;
        private System.Windows.Forms.Label lblCheckoutDate;
        private System.Windows.Forms.TextBox txtReceiptNo;
        private System.Windows.Forms.Label lblReceoptNo;
        private System.Windows.Forms.TableLayoutPanel pnlCustomer;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label4;
        private Common.Display.SaveFooterUC saveFooterUC1;
        private System.Windows.Forms.Panel pnlBottomInputs;
        private System.Windows.Forms.Panel pnlPayment;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown txtPaidAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlPaymentDueDate;
        private Common.Date.NepaliDateTextBox dtPaymentDueDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbCash;
        private System.Windows.Forms.RadioButton rbCredit;
        private System.Windows.Forms.Panel panel4;
        private Common.Date.NepaliDateTextBox dtExpectedDate;
        private System.Windows.Forms.Label lblExpectedDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDiscountType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown txtTotal;
        private System.Windows.Forms.NumericUpDown txtDiscount;
        private System.Windows.Forms.NumericUpDown txtSum;
        private System.Windows.Forms.Label label2;
        private Common.GridView.InventoryUnits.InventoryUnitDataGridView dgvItems;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtInStockQuantityAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbProductAdd;
        private System.Windows.Forms.Button btnResetAdd;
        private System.Windows.Forms.Button btnAddAdd;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cbPackageAdd;
        private System.Windows.Forms.NumericUpDown txtQuantityAdd;
        private System.Windows.Forms.NumericUpDown txtRateAdd;
        private System.Windows.Forms.NumericUpDown txtTotalAdd;
    }
}
