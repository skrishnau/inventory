namespace IMS.Forms.Inventory.Reports.All
{
    partial class LedgerUC
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
            this.lblLastClearanceDate = new System.Windows.Forms.Label();
            this.chkOnlyShowAfterLastClearance = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLedger = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtFrom = new IMS.Forms.Common.Date.NepaliDateTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtTo = new IMS.Forms.Common.Date.NepaliDateTextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnPrint = new IMS.Forms.Common.Buttons.MenuButton();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParticulars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDrCr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedger)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLastClearanceDate
            // 
            this.lblLastClearanceDate.AutoSize = true;
            this.lblLastClearanceDate.Location = new System.Drawing.Point(23, 21);
            this.lblLastClearanceDate.Name = "lblLastClearanceDate";
            this.lblLastClearanceDate.Size = new System.Drawing.Size(10, 13);
            this.lblLastClearanceDate.TabIndex = 8;
            this.lblLastClearanceDate.Text = "-";
            // 
            // chkOnlyShowAfterLastClearance
            // 
            this.chkOnlyShowAfterLastClearance.AutoSize = true;
            this.chkOnlyShowAfterLastClearance.Location = new System.Drawing.Point(3, 3);
            this.chkOnlyShowAfterLastClearance.Name = "chkOnlyShowAfterLastClearance";
            this.chkOnlyShowAfterLastClearance.Size = new System.Drawing.Size(239, 17);
            this.chkOnlyShowAfterLastClearance.TabIndex = 7;
            this.chkOnlyShowAfterLastClearance.Text = "Only show transaction after last full clearance";
            this.chkOnlyShowAfterLastClearance.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(3, 49);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer/Supplier";
            // 
            // dgvLedger
            // 
            this.dgvLedger.AllowUserToAddRows = false;
            this.dgvLedger.AllowUserToDeleteRows = false;
            this.dgvLedger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLedger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colParticulars,
            this.colDebit,
            this.colCredit,
            this.colDrCr,
            this.colBalance});
            this.dgvLedger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLedger.Location = new System.Drawing.Point(0, 79);
            this.dgvLedger.Name = "dgvLedger";
            this.dgvLedger.ReadOnly = true;
            this.dgvLedger.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLedger.Size = new System.Drawing.Size(697, 389);
            this.dgvLedger.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Controls.Add(this.panel5);
            this.flowLayoutPanel1.Controls.Add(this.btnSearch);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 29);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(609, 50);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtFrom);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(153, 27);
            this.panel3.TabIndex = 4;
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(41, 3);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(109, 20);
            this.dtFrom.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dtTo);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(162, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(141, 27);
            this.panel4.TabIndex = 5;
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(30, 3);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(108, 20);
            this.dtTo.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblLastClearanceDate);
            this.panel5.Controls.Add(this.chkOnlyShowAfterLastClearance);
            this.panel5.Location = new System.Drawing.Point(309, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(248, 40);
            this.panel5.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(697, 79);
            this.panel1.TabIndex = 4;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.cbCustomer);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.cbType);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(609, 29);
            this.panel7.TabIndex = 5;
            // 
            // cbCustomer
            // 
            this.cbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCustomer.FormattingEnabled = true;
            this.cbCustomer.Location = new System.Drawing.Point(289, 4);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(132, 21);
            this.cbCustomer.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Type";
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(45, 3);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(111, 21);
            this.cbType.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnPrint);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(609, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(88, 79);
            this.panel6.TabIndex = 5;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = global::IMS.Properties.Resources.icons8_print_16px;
            this.btnPrint.Location = new System.Drawing.Point(15, 7);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(60, 55);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "Date";
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colParticulars
            // 
            this.colParticulars.DataPropertyName = "Particulars";
            this.colParticulars.HeaderText = "Particulars";
            this.colParticulars.Name = "colParticulars";
            this.colParticulars.ReadOnly = true;
            this.colParticulars.Width = 250;
            // 
            // colDebit
            // 
            this.colDebit.DataPropertyName = "Debit";
            this.colDebit.HeaderText = "Debit (दिएको)";
            this.colDebit.Name = "colDebit";
            this.colDebit.ReadOnly = true;
            // 
            // colCredit
            // 
            this.colCredit.DataPropertyName = "Credit";
            this.colCredit.HeaderText = "Credit (लिएको)";
            this.colCredit.Name = "colCredit";
            this.colCredit.ReadOnly = true;
            // 
            // colDrCr
            // 
            this.colDrCr.DataPropertyName = "DrCrString";
            this.colDrCr.HeaderText = "Dr/Cr";
            this.colDrCr.Name = "colDrCr";
            this.colDrCr.ReadOnly = true;
            this.colDrCr.Width = 60;
            // 
            // colBalance
            // 
            this.colBalance.DataPropertyName = "Balance";
            this.colBalance.HeaderText = "Balance";
            this.colBalance.Name = "colBalance";
            this.colBalance.ReadOnly = true;
            // 
            // LedgerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvLedger);
            this.Controls.Add(this.panel1);
            this.Name = "LedgerUC";
            this.Size = new System.Drawing.Size(697, 468);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedger)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLedger;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblLastClearanceDate;
        private System.Windows.Forms.CheckBox chkOnlyShowAfterLastClearance;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private Common.Buttons.MenuButton btnPrint;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.ComboBox cbCustomer;
        private Common.Date.NepaliDateTextBox dtFrom;
        private Common.Date.NepaliDateTextBox dtTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParticulars;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDrCr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBalance;
    }
}
