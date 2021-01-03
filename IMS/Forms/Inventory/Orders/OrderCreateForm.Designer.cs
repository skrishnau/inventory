namespace IMS.Forms.Inventory.Orders
{
    partial class OrderCreateForm
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
            this.tblBase = new System.Windows.Forms.TableLayoutPanel();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numLotNumber = new System.Windows.Forms.NumericUpDown();
            this.lblClient = new System.Windows.Forms.Label();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.lblClientInfo = new System.Windows.Forms.Label();
            this.tbClientInfo = new System.Windows.Forms.TextBox();
            this.cbWarehouse = new System.Windows.Forms.ComboBox();
            this.lblExpectedDate = new System.Windows.Forms.Label();
            this.dtExpectedDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbOrderNumber = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.tblToWarehouse = new System.Windows.Forms.TableLayoutPanel();
            this.lblToWarehouse = new System.Windows.Forms.Label();
            this.cbToWarehouse = new System.Windows.Forms.ComboBox();
            this.dtPaymentDueDate = new System.Windows.Forms.DateTimePicker();
            this.tblBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLotNumber)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tblToWarehouse.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblBase
            // 
            this.tblBase.ColumnCount = 4;
            this.tblBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.72018F));
            this.tblBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.44645F));
            this.tblBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.99436F));
            this.tblBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.83902F));
            this.tblBase.Controls.Add(this.tbPhone, 3, 2);
            this.tblBase.Controls.Add(this.lblPhone, 2, 2);
            this.tblBase.Controls.Add(this.lblPaymentMethod, 0, 4);
            this.tblBase.Controls.Add(this.label2, 0, 2);
            this.tblBase.Controls.Add(this.numLotNumber, 1, 2);
            this.tblBase.Controls.Add(this.lblClient, 2, 0);
            this.tblBase.Controls.Add(this.cbClient, 3, 0);
            this.tblBase.Controls.Add(this.lblWarehouse, 0, 3);
            this.tblBase.Controls.Add(this.lblClientInfo, 2, 1);
            this.tblBase.Controls.Add(this.tbClientInfo, 3, 1);
            this.tblBase.Controls.Add(this.cbWarehouse, 1, 3);
            this.tblBase.Controls.Add(this.lblExpectedDate, 2, 3);
            this.tblBase.Controls.Add(this.dtExpectedDate, 3, 3);
            this.tblBase.Controls.Add(this.label7, 0, 1);
            this.tblBase.Controls.Add(this.label8, 0, 0);
            this.tblBase.Controls.Add(this.tbName, 1, 1);
            this.tblBase.Controls.Add(this.tbOrderNumber, 1, 0);
            this.tblBase.Controls.Add(this.dtPaymentDueDate, 1, 4);
            this.tblBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblBase.Location = new System.Drawing.Point(8, 8);
            this.tblBase.Name = "tblBase";
            this.tblBase.RowCount = 5;
            this.tblBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblBase.Size = new System.Drawing.Size(574, 143);
            this.tblBase.TabIndex = 0;
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(398, 58);
            this.tbPhone.Margin = new System.Windows.Forms.Padding(2);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(146, 20);
            this.tbPhone.TabIndex = 15;
            this.tbPhone.Visible = false;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(296, 56);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(38, 13);
            this.lblPhone.TabIndex = 14;
            this.lblPhone.Text = "Phone";
            this.lblPhone.Visible = false;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Location = new System.Drawing.Point(3, 112);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(97, 13);
            this.lblPaymentMethod.TabIndex = 10;
            this.lblPaymentMethod.Text = "Payment Due Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lot # *";
            // 
            // numLotNumber
            // 
            this.numLotNumber.Location = new System.Drawing.Point(115, 58);
            this.numLotNumber.Margin = new System.Windows.Forms.Padding(2);
            this.numLotNumber.Name = "numLotNumber";
            this.numLotNumber.Size = new System.Drawing.Size(141, 20);
            this.numLotNumber.TabIndex = 6;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClient.Location = new System.Drawing.Point(296, 0);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(52, 13);
            this.lblClient.TabIndex = 0;
            this.lblClient.Text = "Supplier *";
            this.lblClient.DoubleClick += new System.EventHandler(this.lblClient_Click);
            // 
            // cbClient
            // 
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(398, 2);
            this.cbClient.Margin = new System.Windows.Forms.Padding(2);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(146, 21);
            this.cbClient.TabIndex = 8;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarehouse.Location = new System.Drawing.Point(2, 84);
            this.lblWarehouse.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(69, 13);
            this.lblWarehouse.TabIndex = 2;
            this.lblWarehouse.Text = "Warehouse *";
            // 
            // lblClientInfo
            // 
            this.lblClientInfo.AutoSize = true;
            this.lblClientInfo.Location = new System.Drawing.Point(296, 28);
            this.lblClientInfo.Name = "lblClientInfo";
            this.lblClientInfo.Size = new System.Drawing.Size(54, 13);
            this.lblClientInfo.TabIndex = 13;
            this.lblClientInfo.Text = "Client Info";
            // 
            // tbClientInfo
            // 
            this.tbClientInfo.Location = new System.Drawing.Point(398, 30);
            this.tbClientInfo.Margin = new System.Windows.Forms.Padding(2);
            this.tbClientInfo.Name = "tbClientInfo";
            this.tbClientInfo.Size = new System.Drawing.Size(146, 20);
            this.tbClientInfo.TabIndex = 14;
            // 
            // cbWarehouse
            // 
            this.cbWarehouse.FormattingEnabled = true;
            this.cbWarehouse.Location = new System.Drawing.Point(115, 86);
            this.cbWarehouse.Margin = new System.Windows.Forms.Padding(2);
            this.cbWarehouse.Name = "cbWarehouse";
            this.cbWarehouse.Size = new System.Drawing.Size(141, 21);
            this.cbWarehouse.TabIndex = 9;
            // 
            // lblExpectedDate
            // 
            this.lblExpectedDate.AutoSize = true;
            this.lblExpectedDate.Location = new System.Drawing.Point(295, 84);
            this.lblExpectedDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExpectedDate.Name = "lblExpectedDate";
            this.lblExpectedDate.Size = new System.Drawing.Size(85, 13);
            this.lblExpectedDate.TabIndex = 4;
            this.lblExpectedDate.Text = "Expected Date *";
            // 
            // dtExpectedDate
            // 
            this.dtExpectedDate.Checked = false;
            this.dtExpectedDate.CustomFormat = "yyyy/MM/dd";
            this.dtExpectedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtExpectedDate.Location = new System.Drawing.Point(398, 86);
            this.dtExpectedDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtExpectedDate.Name = "dtExpectedDate";
            this.dtExpectedDate.Size = new System.Drawing.Size(146, 20);
            this.dtExpectedDate.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 28);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Name/Reference *";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Order No. *";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(115, 30);
            this.tbName.Margin = new System.Windows.Forms.Padding(2);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(141, 20);
            this.tbName.TabIndex = 12;
            // 
            // tbOrderNumber
            // 
            this.tbOrderNumber.Location = new System.Drawing.Point(115, 2);
            this.tbOrderNumber.Margin = new System.Windows.Forms.Padding(2);
            this.tbOrderNumber.Name = "tbOrderNumber";
            this.tbOrderNumber.Size = new System.Drawing.Size(141, 20);
            this.tbOrderNumber.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(8, 257);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(574, 40);
            this.panel3.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(489, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(328, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(144, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save and Add Items";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSavePurchaseOrder_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(8, 178);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label4.Size = new System.Drawing.Size(30, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Note";
            // 
            // tbNotes
            // 
            this.tbNotes.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbNotes.Location = new System.Drawing.Point(8, 201);
            this.tbNotes.Margin = new System.Windows.Forms.Padding(2);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(564, 56);
            this.tbNotes.TabIndex = 3;
            // 
            // tblToWarehouse
            // 
            this.tblToWarehouse.ColumnCount = 4;
            this.tblToWarehouse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.72018F));
            this.tblToWarehouse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.44644F));
            this.tblToWarehouse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.99436F));
            this.tblToWarehouse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.83901F));
            this.tblToWarehouse.Controls.Add(this.lblToWarehouse, 0, 0);
            this.tblToWarehouse.Controls.Add(this.cbToWarehouse, 1, 0);
            this.tblToWarehouse.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblToWarehouse.Location = new System.Drawing.Point(8, 151);
            this.tblToWarehouse.Name = "tblToWarehouse";
            this.tblToWarehouse.RowCount = 1;
            this.tblToWarehouse.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblToWarehouse.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tblToWarehouse.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tblToWarehouse.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tblToWarehouse.Size = new System.Drawing.Size(574, 27);
            this.tblToWarehouse.TabIndex = 4;
            // 
            // lblToWarehouse
            // 
            this.lblToWarehouse.AutoSize = true;
            this.lblToWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToWarehouse.Location = new System.Drawing.Point(2, 0);
            this.lblToWarehouse.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblToWarehouse.Name = "lblToWarehouse";
            this.lblToWarehouse.Size = new System.Drawing.Size(85, 13);
            this.lblToWarehouse.TabIndex = 2;
            this.lblToWarehouse.Text = "To Warehouse *";
            // 
            // cbToWarehouse
            // 
            this.cbToWarehouse.FormattingEnabled = true;
            this.cbToWarehouse.Location = new System.Drawing.Point(115, 2);
            this.cbToWarehouse.Margin = new System.Windows.Forms.Padding(2);
            this.cbToWarehouse.Name = "cbToWarehouse";
            this.cbToWarehouse.Size = new System.Drawing.Size(141, 21);
            this.cbToWarehouse.TabIndex = 9;
            // 
            // dtPaymentDueDate
            // 
            this.dtPaymentDueDate.CustomFormat = "yyyy/MM/dd";
            this.dtPaymentDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPaymentDueDate.Location = new System.Drawing.Point(116, 115);
            this.dtPaymentDueDate.Name = "dtPaymentDueDate";
            this.dtPaymentDueDate.Size = new System.Drawing.Size(140, 20);
            this.dtPaymentDueDate.TabIndex = 17;
            // 
            // OrderCreateForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(590, 305);
            this.Controls.Add(this.tbNotes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tblToWarehouse);
            this.Controls.Add(this.tblBase);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderCreateForm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Order";
            this.tblBase.ResumeLayout(false);
            this.tblBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLotNumber)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tblToWarehouse.ResumeLayout(false);
            this.tblToWarehouse.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblBase;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblExpectedDate;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.NumericUpDown numLotNumber;
        private System.Windows.Forms.DateTimePicker dtExpectedDate;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.ComboBox cbWarehouse;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label lblClientInfo;
        private System.Windows.Forms.TextBox tbClientInfo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbOrderNumber;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TableLayoutPanel tblToWarehouse;
        private System.Windows.Forms.Label lblToWarehouse;
        private System.Windows.Forms.ComboBox cbToWarehouse;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.DateTimePicker dtPaymentDueDate;
    }
}