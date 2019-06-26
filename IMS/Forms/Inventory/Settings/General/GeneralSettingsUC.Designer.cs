﻿namespace IMS.Forms.Inventory.Settings.General
{
    partial class GeneralSettingsUC
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
            this.btnSaveAppearance = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbThemes = new System.Windows.Forms.ComboBox();
            this.pnlAppearance = new System.Windows.Forms.Panel();
            this.pnlProfile = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSaveProfile = new System.Windows.Forms.Button();
            this.tbWebsite = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.tbPAN = new System.Windows.Forms.TextBox();
            this.tbVAT = new System.Windows.Forms.TextBox();
            this.tbOwner = new System.Windows.Forms.TextBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCompanyName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlAppearance.SuspendLayout();
            this.pnlProfile.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveAppearance
            // 
            this.btnSaveAppearance.Location = new System.Drawing.Point(244, 10);
            this.btnSaveAppearance.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveAppearance.Name = "btnSaveAppearance";
            this.btnSaveAppearance.Size = new System.Drawing.Size(56, 19);
            this.btnSaveAppearance.TabIndex = 5;
            this.btnSaveAppearance.Text = "Save";
            this.btnSaveAppearance.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Theme";
            // 
            // cbThemes
            // 
            this.cbThemes.FormattingEnabled = true;
            this.cbThemes.Items.AddRange(new object[] {
            "Light",
            "Dark"});
            this.cbThemes.Location = new System.Drawing.Point(51, 7);
            this.cbThemes.Margin = new System.Windows.Forms.Padding(2);
            this.cbThemes.Name = "cbThemes";
            this.cbThemes.Size = new System.Drawing.Size(169, 21);
            this.cbThemes.TabIndex = 4;
            // 
            // pnlAppearance
            // 
            this.pnlAppearance.Controls.Add(this.label1);
            this.pnlAppearance.Controls.Add(this.btnSaveAppearance);
            this.pnlAppearance.Controls.Add(this.cbThemes);
            this.pnlAppearance.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAppearance.Location = new System.Drawing.Point(0, 0);
            this.pnlAppearance.Name = "pnlAppearance";
            this.pnlAppearance.Size = new System.Drawing.Size(728, 38);
            this.pnlAppearance.TabIndex = 6;
            // 
            // pnlProfile
            // 
            this.pnlProfile.Controls.Add(this.tableLayoutPanel2);
            this.pnlProfile.Controls.Add(this.panel3);
            this.pnlProfile.Location = new System.Drawing.Point(10, 44);
            this.pnlProfile.Name = "pnlProfile";
            this.pnlProfile.Size = new System.Drawing.Size(262, 260);
            this.pnlProfile.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSaveProfile);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 231);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(262, 29);
            this.panel3.TabIndex = 4;
            // 
            // btnSaveProfile
            // 
            this.btnSaveProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveProfile.Location = new System.Drawing.Point(166, 3);
            this.btnSaveProfile.Name = "btnSaveProfile";
            this.btnSaveProfile.Size = new System.Drawing.Size(75, 23);
            this.btnSaveProfile.TabIndex = 3;
            this.btnSaveProfile.Text = "Save";
            this.btnSaveProfile.UseVisualStyleBackColor = true;
            // 
            // tbWebsite
            // 
            this.tbWebsite.Location = new System.Drawing.Point(133, 198);
            this.tbWebsite.Margin = new System.Windows.Forms.Padding(2);
            this.tbWebsite.Name = "tbWebsite";
            this.tbWebsite.Size = new System.Drawing.Size(127, 20);
            this.tbWebsite.TabIndex = 21;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(133, 170);
            this.tbEmail.Margin = new System.Windows.Forms.Padding(2);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(127, 20);
            this.tbEmail.TabIndex = 20;
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(133, 142);
            this.tbPhone.Margin = new System.Windows.Forms.Padding(2);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(127, 20);
            this.tbPhone.TabIndex = 19;
            // 
            // tbPAN
            // 
            this.tbPAN.Location = new System.Drawing.Point(133, 114);
            this.tbPAN.Margin = new System.Windows.Forms.Padding(2);
            this.tbPAN.Name = "tbPAN";
            this.tbPAN.Size = new System.Drawing.Size(127, 20);
            this.tbPAN.TabIndex = 18;
            // 
            // tbVAT
            // 
            this.tbVAT.Location = new System.Drawing.Point(133, 86);
            this.tbVAT.Margin = new System.Windows.Forms.Padding(2);
            this.tbVAT.Name = "tbVAT";
            this.tbVAT.Size = new System.Drawing.Size(127, 20);
            this.tbVAT.TabIndex = 17;
            // 
            // tbOwner
            // 
            this.tbOwner.Location = new System.Drawing.Point(133, 58);
            this.tbOwner.Margin = new System.Windows.Forms.Padding(2);
            this.tbOwner.Name = "tbOwner";
            this.tbOwner.Size = new System.Drawing.Size(127, 20);
            this.tbOwner.TabIndex = 16;
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(133, 30);
            this.tbAddress.Margin = new System.Windows.Forms.Padding(2);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(127, 20);
            this.tbAddress.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(2, 196);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Website";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 168);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Email";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 140);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Phone";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 112);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "PAN No";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 84);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "VAT No";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 56);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Owner\'s Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 28);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Address";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Company Name";
            // 
            // tbCompanyName
            // 
            this.tbCompanyName.Location = new System.Drawing.Point(133, 2);
            this.tbCompanyName.Margin = new System.Windows.Forms.Padding(2);
            this.tbCompanyName.Name = "tbCompanyName";
            this.tbCompanyName.Size = new System.Drawing.Size(127, 20);
            this.tbCompanyName.TabIndex = 1;
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
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(262, 231);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // GeneralSettingsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlProfile);
            this.Controls.Add(this.pnlAppearance);
            this.Name = "GeneralSettingsUC";
            this.Size = new System.Drawing.Size(728, 410);
            this.pnlAppearance.ResumeLayout(false);
            this.pnlAppearance.PerformLayout();
            this.pnlProfile.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveAppearance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbThemes;
        private System.Windows.Forms.Panel pnlAppearance;
        private System.Windows.Forms.Panel pnlProfile;
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSaveProfile;
    }
}
