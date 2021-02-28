namespace IMS.Forms.Inventory.Dashboard
{
    partial class DashboardUC
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
            this.pnlTopUnderstockProducts = new System.Windows.Forms.Panel();
            this.lbUnderStockProducts = new System.Windows.Forms.ListBox();
            this.lblTopUnderstockProducts = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbStartNepali = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblProducts = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblSale = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblPurchase = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblCustomers = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dgvDueReceivables = new System.Windows.Forms.DataGridView();
            this.colUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDueAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDueDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlCompany = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.nepaliDateTextBox1 = new IMS.Forms.Common.Date.NepaliDateTextBox();
            this.pnlTopUnderstockProducts.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDueReceivables)).BeginInit();
            this.pnlCompany.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopUnderstockProducts
            // 
            this.pnlTopUnderstockProducts.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlTopUnderstockProducts.Controls.Add(this.lbUnderStockProducts);
            this.pnlTopUnderstockProducts.Controls.Add(this.lblTopUnderstockProducts);
            this.pnlTopUnderstockProducts.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTopUnderstockProducts.Location = new System.Drawing.Point(460, 0);
            this.pnlTopUnderstockProducts.Name = "pnlTopUnderstockProducts";
            this.pnlTopUnderstockProducts.Padding = new System.Windows.Forms.Padding(5);
            this.pnlTopUnderstockProducts.Size = new System.Drawing.Size(231, 252);
            this.pnlTopUnderstockProducts.TabIndex = 0;
            this.pnlTopUnderstockProducts.Visible = false;
            // 
            // lbUnderStockProducts
            // 
            this.lbUnderStockProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbUnderStockProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbUnderStockProducts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUnderStockProducts.FormattingEnabled = true;
            this.lbUnderStockProducts.ItemHeight = 21;
            this.lbUnderStockProducts.Location = new System.Drawing.Point(5, 28);
            this.lbUnderStockProducts.Name = "lbUnderStockProducts";
            this.lbUnderStockProducts.Size = new System.Drawing.Size(221, 219);
            this.lbUnderStockProducts.TabIndex = 1;
            // 
            // lblTopUnderstockProducts
            // 
            this.lblTopUnderstockProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTopUnderstockProducts.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopUnderstockProducts.Location = new System.Drawing.Point(5, 5);
            this.lblTopUnderstockProducts.Name = "lblTopUnderstockProducts";
            this.lblTopUnderstockProducts.Size = new System.Drawing.Size(221, 23);
            this.lblTopUnderstockProducts.TabIndex = 0;
            this.lblTopUnderstockProducts.Text = "Understock";
            this.lblTopUnderstockProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nepaliDateTextBox1);
            this.panel2.Controls.Add(this.tbStartNepali);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dtEnd);
            this.panel2.Controls.Add(this.dtStart);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1138, 38);
            this.panel2.TabIndex = 2;
            // 
            // tbStartNepali
            // 
            this.tbStartNepali.Location = new System.Drawing.Point(593, 9);
            this.tbStartNepali.Name = "tbStartNepali";
            this.tbStartNepali.Size = new System.Drawing.Size(138, 20);
            this.tbStartNepali.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "End";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtEnd
            // 
            this.dtEnd.CustomFormat = "yyyy/MM/dd";
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd.Location = new System.Drawing.Point(207, 9);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(98, 20);
            this.dtEnd.TabIndex = 1;
            // 
            // dtStart
            // 
            this.dtStart.CustomFormat = "yyyy/MM/dd";
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.Location = new System.Drawing.Point(50, 9);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(98, 20);
            this.dtStart.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.lblProducts);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.Location = new System.Drawing.Point(573, 11);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(5);
            this.panel7.Size = new System.Drawing.Size(272, 63);
            this.panel7.TabIndex = 4;
            // 
            // lblProducts
            // 
            this.lblProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProducts.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducts.Location = new System.Drawing.Point(5, 5);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(262, 28);
            this.lblProducts.TabIndex = 1;
            this.lblProducts.Text = "0";
            this.lblProducts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.Location = new System.Drawing.Point(5, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(262, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Products";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblSale);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(11, 11);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(272, 63);
            this.panel3.TabIndex = 5;
            // 
            // lblSale
            // 
            this.lblSale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSale.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSale.Location = new System.Drawing.Point(5, 5);
            this.lblSale.Name = "lblSale";
            this.lblSale.Size = new System.Drawing.Size(262, 28);
            this.lblSale.TabIndex = 1;
            this.lblSale.Text = "0";
            this.lblSale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Location = new System.Drawing.Point(5, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(262, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Sale Transactioons";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblPurchase);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(292, 11);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5);
            this.panel4.Size = new System.Drawing.Size(272, 63);
            this.panel4.TabIndex = 6;
            // 
            // lblPurchase
            // 
            this.lblPurchase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPurchase.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurchase.Location = new System.Drawing.Point(5, 5);
            this.lblPurchase.Name = "lblPurchase";
            this.lblPurchase.Size = new System.Drawing.Size(262, 28);
            this.lblPurchase.TabIndex = 1;
            this.lblPurchase.Text = "0";
            this.lblPurchase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label7.Location = new System.Drawing.Point(5, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(262, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Purchase Transactions";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lblCustomers);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(854, 11);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(5);
            this.panel6.Size = new System.Drawing.Size(273, 63);
            this.panel6.TabIndex = 8;
            // 
            // lblCustomers
            // 
            this.lblCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustomers.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomers.Location = new System.Drawing.Point(5, 5);
            this.lblCustomers.Name = "lblCustomers";
            this.lblCustomers.Size = new System.Drawing.Size(263, 28);
            this.lblCustomers.TabIndex = 1;
            this.lblCustomers.Text = "0";
            this.lblCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label11.Location = new System.Drawing.Point(5, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(263, 25);
            this.label11.TabIndex = 0;
            this.label11.Text = "Customers";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.panel6, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 87);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1138, 85);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.splitter2);
            this.panel1.Controls.Add(this.pnlTopUnderstockProducts);
            this.panel1.Controls.Add(this.reportViewer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 177);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1138, 252);
            this.panel1.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel8.Controls.Add(this.dgvDueReceivables);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(699, 0);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(5);
            this.panel8.Size = new System.Drawing.Size(413, 252);
            this.panel8.TabIndex = 1;
            // 
            // dgvDueReceivables
            // 
            this.dgvDueReceivables.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvDueReceivables.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDueReceivables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDueReceivables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUser,
            this.colTotalAmount,
            this.colDueAmount,
            this.colDueDays});
            this.dgvDueReceivables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDueReceivables.Location = new System.Drawing.Point(5, 28);
            this.dgvDueReceivables.Name = "dgvDueReceivables";
            this.dgvDueReceivables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDueReceivables.Size = new System.Drawing.Size(403, 219);
            this.dgvDueReceivables.TabIndex = 1;
            // 
            // colUser
            // 
            this.colUser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUser.DataPropertyName = "User";
            this.colUser.HeaderText = "Customer";
            this.colUser.Name = "colUser";
            this.colUser.ReadOnly = true;
            this.colUser.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTotalAmount.DataPropertyName = "TransactionAmount";
            this.colTotalAmount.HeaderText = "Total Amt";
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.ReadOnly = true;
            this.colTotalAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTotalAmount.Width = 77;
            // 
            // colDueAmount
            // 
            this.colDueAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDueAmount.DataPropertyName = "DueAmount";
            this.colDueAmount.HeaderText = "Due Amt.";
            this.colDueAmount.Name = "colDueAmount";
            this.colDueAmount.ReadOnly = true;
            this.colDueAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDueAmount.Width = 76;
            // 
            // colDueDays
            // 
            this.colDueDays.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDueDays.DataPropertyName = "DueDays";
            this.colDueDays.HeaderText = "Due Days";
            this.colDueDays.Name = "colDueDays";
            this.colDueDays.ReadOnly = true;
            this.colDueDays.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDueDays.Width = 79;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(403, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Due Receivables";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(691, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(8, 252);
            this.splitter2.TabIndex = 2;
            this.splitter2.TabStop = false;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "IMS.Reports.TransactionBarReportUC.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.ShowToolBar = false;
            this.reportViewer1.Size = new System.Drawing.Size(460, 252);
            this.reportViewer1.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 172);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1138, 5);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // pnlCompany
            // 
            this.pnlCompany.BackColor = System.Drawing.Color.Gray;
            this.pnlCompany.Controls.Add(this.panel9);
            this.pnlCompany.Controls.Add(this.lblCompanyName);
            this.pnlCompany.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCompany.ForeColor = System.Drawing.Color.White;
            this.pnlCompany.Location = new System.Drawing.Point(0, 0);
            this.pnlCompany.Name = "pnlCompany";
            this.pnlCompany.Padding = new System.Windows.Forms.Padding(4);
            this.pnlCompany.Size = new System.Drawing.Size(1138, 49);
            this.pnlCompany.TabIndex = 3;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.lblPhone);
            this.panel9.Controls.Add(this.lblAddress);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(861, 4);
            this.panel9.Name = "panel9";
            this.panel9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel9.Size = new System.Drawing.Size(273, 41);
            this.panel9.TabIndex = 2;
            // 
            // lblPhone
            // 
            this.lblPhone.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPhone.ForeColor = System.Drawing.Color.White;
            this.lblPhone.Location = new System.Drawing.Point(0, 19);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPhone.Size = new System.Drawing.Size(273, 20);
            this.lblPhone.TabIndex = 1;
            this.lblPhone.Text = "Phone";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAddress
            // 
            this.lblAddress.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblAddress.Location = new System.Drawing.Point(0, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblAddress.Size = new System.Drawing.Size(273, 19);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "Address";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCompanyName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.Location = new System.Drawing.Point(4, 4);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(1130, 41);
            this.lblCompanyName.TabIndex = 0;
            this.lblCompanyName.Text = "My Company";
            this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nepaliDateTextBox1
            // 
            this.nepaliDateTextBox1.Location = new System.Drawing.Point(373, 9);
            this.nepaliDateTextBox1.Name = "nepaliDateTextBox1";
            this.nepaliDateTextBox1.Size = new System.Drawing.Size(128, 20);
            this.nepaliDateTextBox1.TabIndex = 5;
            // 
            // DashboardUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlCompany);
            this.Name = "DashboardUC";
            this.Size = new System.Drawing.Size(1138, 525);
            this.pnlTopUnderstockProducts.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDueReceivables)).EndInit();
            this.pnlCompany.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopUnderstockProducts;
        private System.Windows.Forms.Label lblTopUnderstockProducts;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblCustomers;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblPurchase;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSale;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbUnderStockProducts;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.DataGridView dgvDueReceivables;
        private System.Windows.Forms.Panel pnlCompany;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblPhone;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDueAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDueDays;
        private System.Windows.Forms.TextBox tbStartNepali;
        private Common.Date.NepaliDateTextBox nepaliDateTextBox1;
    }
}
