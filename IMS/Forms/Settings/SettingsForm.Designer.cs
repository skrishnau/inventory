namespace IMS.Forms.Settings
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbThemes = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnBillSettingSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbSuffix = new System.Windows.Forms.TextBox();
            this.tbPrefix = new System.Windows.Forms.TextBox();
            this.tbEnd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbStart = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnCloseSetting = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCompanyName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnOwnerInfoSave = new System.Windows.Forms.Button();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.tbOwner = new System.Windows.Forms.TextBox();
            this.tbVAT = new System.Windows.Forms.TextBox();
            this.tbPAN = new System.Windows.Forms.TextBox();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbWebsite = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Theme";
            // 
            // cbThemes
            // 
            this.cbThemes.FormattingEnabled = true;
            this.cbThemes.Items.AddRange(new object[] {
            "Light",
            "Dark"});
            this.cbThemes.Location = new System.Drawing.Point(140, 76);
            this.cbThemes.Name = "cbThemes";
            this.cbThemes.Size = new System.Drawing.Size(121, 24);
            this.cbThemes.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(186, 159);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(502, 396);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnBillSettingSave);
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(25, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(473, 388);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bill Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnBillSettingSave
            // 
            this.btnBillSettingSave.Location = new System.Drawing.Point(164, 250);
            this.btnBillSettingSave.Name = "btnBillSettingSave";
            this.btnBillSettingSave.Size = new System.Drawing.Size(75, 23);
            this.btnBillSettingSave.TabIndex = 5;
            this.btnBillSettingSave.Text = "Save";
            this.btnBillSettingSave.UseVisualStyleBackColor = true;
            this.btnBillSettingSave.Click += new System.EventHandler(this.btnBillSettingSave_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tbSuffix, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbPrefix, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbEnd, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbStart, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(50, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(273, 175);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tbSuffix
            // 
            this.tbSuffix.Location = new System.Drawing.Point(139, 132);
            this.tbSuffix.Name = "tbSuffix";
            this.tbSuffix.Size = new System.Drawing.Size(94, 22);
            this.tbSuffix.TabIndex = 7;
            // 
            // tbPrefix
            // 
            this.tbPrefix.Location = new System.Drawing.Point(139, 89);
            this.tbPrefix.Name = "tbPrefix";
            this.tbPrefix.Size = new System.Drawing.Size(94, 22);
            this.tbPrefix.TabIndex = 6;
            // 
            // tbEnd
            // 
            this.tbEnd.Location = new System.Drawing.Point(139, 46);
            this.tbEnd.Name = "tbEnd";
            this.tbEnd.Size = new System.Drawing.Size(94, 22);
            this.tbEnd.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Start";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Suffix";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "End";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Prefix";
            // 
            // tbStart
            // 
            this.tbStart.Location = new System.Drawing.Point(139, 3);
            this.tbStart.Name = "tbStart";
            this.tbStart.Size = new System.Drawing.Size(100, 22);
            this.tbStart.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cbThemes);
            this.tabPage1.Location = new System.Drawing.Point(25, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(473, 388);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Themes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnCloseSetting
            // 
            this.btnCloseSetting.Location = new System.Drawing.Point(285, 479);
            this.btnCloseSetting.Name = "btnCloseSetting";
            this.btnCloseSetting.Size = new System.Drawing.Size(149, 42);
            this.btnCloseSetting.TabIndex = 6;
            this.btnCloseSetting.Text = "Close Setting";
            this.btnCloseSetting.UseVisualStyleBackColor = true;
            this.btnCloseSetting.Click += new System.EventHandler(this.btnCloseSetting_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnOwnerInfoSave);
            this.tabPage3.Controls.Add(this.tableLayoutPanel2);
            this.tabPage3.Location = new System.Drawing.Point(25, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(473, 388);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Owner\'s Info";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tbWebsite, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.tbEmail, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.tbPhone, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.tbPAN, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.tbVAT, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.tbOwner, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbAddress, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label13, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbCompanyName, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(49, 32);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(375, 265);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Company Name";
            // 
            // tbCompanyName
            // 
            this.tbCompanyName.Location = new System.Drawing.Point(190, 3);
            this.tbCompanyName.Name = "tbCompanyName";
            this.tbCompanyName.Size = new System.Drawing.Size(169, 22);
            this.tbCompanyName.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Address";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Owner\'s Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "VAT No";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 17);
            this.label10.TabIndex = 8;
            this.label10.Text = "PAN No";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 165);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 17);
            this.label11.TabIndex = 10;
            this.label11.Text = "Phone";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 198);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 17);
            this.label12.TabIndex = 12;
            this.label12.Text = "Email";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 231);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 17);
            this.label13.TabIndex = 14;
            this.label13.Text = "Website";
            // 
            // btnOwnerInfoSave
            // 
            this.btnOwnerInfoSave.Location = new System.Drawing.Point(322, 327);
            this.btnOwnerInfoSave.Name = "btnOwnerInfoSave";
            this.btnOwnerInfoSave.Size = new System.Drawing.Size(75, 23);
            this.btnOwnerInfoSave.TabIndex = 1;
            this.btnOwnerInfoSave.Text = "Save";
            this.btnOwnerInfoSave.UseVisualStyleBackColor = true;
            this.btnOwnerInfoSave.Click += new System.EventHandler(this.btnOwnerInfoSave_Click);
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(190, 36);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(169, 22);
            this.tbAddress.TabIndex = 15;
            // 
            // tbOwner
            // 
            this.tbOwner.Location = new System.Drawing.Point(190, 69);
            this.tbOwner.Name = "tbOwner";
            this.tbOwner.Size = new System.Drawing.Size(169, 22);
            this.tbOwner.TabIndex = 16;
            // 
            // tbVAT
            // 
            this.tbVAT.Location = new System.Drawing.Point(190, 102);
            this.tbVAT.Name = "tbVAT";
            this.tbVAT.Size = new System.Drawing.Size(169, 22);
            this.tbVAT.TabIndex = 17;
            // 
            // tbPAN
            // 
            this.tbPAN.Location = new System.Drawing.Point(190, 135);
            this.tbPAN.Name = "tbPAN";
            this.tbPAN.Size = new System.Drawing.Size(169, 22);
            this.tbPAN.TabIndex = 18;
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(190, 168);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(169, 22);
            this.tbPhone.TabIndex = 19;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(190, 201);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(169, 22);
            this.tbEmail.TabIndex = 20;
            // 
            // tbWebsite
            // 
            this.tbWebsite.Location = new System.Drawing.Point(190, 234);
            this.tbWebsite.Name = "tbWebsite";
            this.tbWebsite.Size = new System.Drawing.Size(169, 22);
            this.tbWebsite.TabIndex = 21;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 595);
            this.Controls.Add(this.btnCloseSetting);
            this.Controls.Add(this.tabControl1);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbThemes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnBillSettingSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbSuffix;
        private System.Windows.Forms.TextBox tbPrefix;
        private System.Windows.Forms.TextBox tbEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbStart;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnCloseSetting;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnOwnerInfoSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox tbWebsite;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.TextBox tbPAN;
        private System.Windows.Forms.TextBox tbVAT;
        private System.Windows.Forms.TextBox tbOwner;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCompanyName;
    }
}