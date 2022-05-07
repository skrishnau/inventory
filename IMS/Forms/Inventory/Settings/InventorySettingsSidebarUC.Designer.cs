﻿namespace IMS.Forms.Inventory.Settings
{
    partial class InventorySettingsSidebarUC
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
            this.pnlLinks = new System.Windows.Forms.FlowLayoutPanel();
            this.lnkProfile = new System.Windows.Forms.LinkLabel();
            this.lnkPreferences = new System.Windows.Forms.LinkLabel();
            this.lnkReferences = new System.Windows.Forms.LinkLabel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.lnkProductCategory = new System.Windows.Forms.LinkLabel();
            this.lnkPackages = new System.Windows.Forms.LinkLabel();
            this.lnkUom = new System.Windows.Forms.LinkLabel();
            this.lnkAdjustmentCodes = new System.Windows.Forms.LinkLabel();
            this.splitter6 = new System.Windows.Forms.Splitter();
            this.lnkWarehouses = new System.Windows.Forms.LinkLabel();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.lnkUsers = new System.Windows.Forms.LinkLabel();
            this.lnkPermissions = new System.Windows.Forms.LinkLabel();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.pnlLinks.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLinks
            // 
            this.pnlLinks.Controls.Add(this.lnkProfile);
            this.pnlLinks.Controls.Add(this.lnkPreferences);
            this.pnlLinks.Controls.Add(this.lnkReferences);
            this.pnlLinks.Controls.Add(this.splitter2);
            this.pnlLinks.Controls.Add(this.lnkProductCategory);
            this.pnlLinks.Controls.Add(this.lnkPackages);
            this.pnlLinks.Controls.Add(this.lnkUom);
            this.pnlLinks.Controls.Add(this.lnkAdjustmentCodes);
            this.pnlLinks.Controls.Add(this.splitter6);
            this.pnlLinks.Controls.Add(this.lnkWarehouses);
            this.pnlLinks.Controls.Add(this.splitter3);
            this.pnlLinks.Controls.Add(this.lnkUsers);
            this.pnlLinks.Controls.Add(this.lnkPermissions);
            this.pnlLinks.Controls.Add(this.splitter4);
            this.pnlLinks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLinks.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlLinks.Location = new System.Drawing.Point(0, 0);
            this.pnlLinks.Name = "pnlLinks";
            this.pnlLinks.Size = new System.Drawing.Size(179, 484);
            this.pnlLinks.TabIndex = 3;
            this.pnlLinks.WrapContents = false;
            // 
            // lnkProfile
            // 
            this.lnkProfile.AutoSize = true;
            this.lnkProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkProfile.Image = global::IMS.Properties.Resources.icons8_Information_16px;
            this.lnkProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkProfile.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkProfile.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkProfile.Location = new System.Drawing.Point(5, 5);
            this.lnkProfile.Margin = new System.Windows.Forms.Padding(5);
            this.lnkProfile.Name = "lnkProfile";
            this.lnkProfile.Size = new System.Drawing.Size(72, 17);
            this.lnkProfile.TabIndex = 11;
            this.lnkProfile.TabStop = true;
            this.lnkProfile.Text = "      Profile";
            this.lnkProfile.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // lnkPreferences
            // 
            this.lnkPreferences.AutoSize = true;
            this.lnkPreferences.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkPreferences.Image = global::IMS.Properties.Resources.icons8_Adjust_16px;
            this.lnkPreferences.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkPreferences.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkPreferences.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkPreferences.Location = new System.Drawing.Point(5, 32);
            this.lnkPreferences.Margin = new System.Windows.Forms.Padding(5);
            this.lnkPreferences.Name = "lnkPreferences";
            this.lnkPreferences.Size = new System.Drawing.Size(109, 17);
            this.lnkPreferences.TabIndex = 20;
            this.lnkPreferences.TabStop = true;
            this.lnkPreferences.Text = "      Preferences";
            this.lnkPreferences.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // lnkReferences
            // 
            this.lnkReferences.AutoSize = true;
            this.lnkReferences.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkReferences.Image = global::IMS.Properties.Resources.icons8_Receipt_16px;
            this.lnkReferences.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkReferences.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkReferences.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkReferences.Location = new System.Drawing.Point(5, 59);
            this.lnkReferences.Margin = new System.Windows.Forms.Padding(5);
            this.lnkReferences.Name = "lnkReferences";
            this.lnkReferences.Size = new System.Drawing.Size(146, 17);
            this.lnkReferences.TabIndex = 8;
            this.lnkReferences.TabStop = true;
            this.lnkReferences.Text = "      Voucher Numbers";
            this.lnkReferences.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(3, 84);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(150, 3);
            this.splitter2.TabIndex = 13;
            this.splitter2.TabStop = false;
            // 
            // lnkProductCategory
            // 
            this.lnkProductCategory.AutoSize = true;
            this.lnkProductCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkProductCategory.Image = global::IMS.Properties.Resources.icons8_Categorize_16px;
            this.lnkProductCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkProductCategory.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkProductCategory.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkProductCategory.Location = new System.Drawing.Point(5, 95);
            this.lnkProductCategory.Margin = new System.Windows.Forms.Padding(5);
            this.lnkProductCategory.Name = "lnkProductCategory";
            this.lnkProductCategory.Size = new System.Drawing.Size(142, 17);
            this.lnkProductCategory.TabIndex = 2;
            this.lnkProductCategory.TabStop = true;
            this.lnkProductCategory.Text = "      Product Category";
            this.lnkProductCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkProductCategory.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // lnkPackages
            // 
            this.lnkPackages.AutoSize = true;
            this.lnkPackages.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkPackages.Image = global::IMS.Properties.Resources.icons8_Packaging_16px;
            this.lnkPackages.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkPackages.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkPackages.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkPackages.Location = new System.Drawing.Point(5, 122);
            this.lnkPackages.Margin = new System.Windows.Forms.Padding(5);
            this.lnkPackages.Name = "lnkPackages";
            this.lnkPackages.Size = new System.Drawing.Size(94, 17);
            this.lnkPackages.TabIndex = 5;
            this.lnkPackages.TabStop = true;
            this.lnkPackages.Text = "      Packages";
            this.lnkPackages.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // lnkUom
            // 
            this.lnkUom.AutoSize = true;
            this.lnkUom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkUom.Image = global::IMS.Properties.Resources.icons8_Scales_16px;
            this.lnkUom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkUom.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkUom.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkUom.Location = new System.Drawing.Point(5, 149);
            this.lnkUom.Margin = new System.Windows.Forms.Padding(5);
            this.lnkUom.Name = "lnkUom";
            this.lnkUom.Size = new System.Drawing.Size(139, 17);
            this.lnkUom.TabIndex = 4;
            this.lnkUom.TabStop = true;
            this.lnkUom.Text = "      Units of Measure";
            this.lnkUom.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // lnkAdjustmentCodes
            // 
            this.lnkAdjustmentCodes.AutoSize = true;
            this.lnkAdjustmentCodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAdjustmentCodes.Image = global::IMS.Properties.Resources.icons8_Adjust_16px;
            this.lnkAdjustmentCodes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkAdjustmentCodes.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkAdjustmentCodes.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkAdjustmentCodes.Location = new System.Drawing.Point(5, 176);
            this.lnkAdjustmentCodes.Margin = new System.Windows.Forms.Padding(5);
            this.lnkAdjustmentCodes.Name = "lnkAdjustmentCodes";
            this.lnkAdjustmentCodes.Size = new System.Drawing.Size(146, 17);
            this.lnkAdjustmentCodes.TabIndex = 3;
            this.lnkAdjustmentCodes.TabStop = true;
            this.lnkAdjustmentCodes.Text = "      Adjustment Codes";
            this.lnkAdjustmentCodes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkAdjustmentCodes.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // splitter6
            // 
            this.splitter6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitter6.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter6.Location = new System.Drawing.Point(3, 201);
            this.splitter6.Name = "splitter6";
            this.splitter6.Size = new System.Drawing.Size(150, 3);
            this.splitter6.TabIndex = 19;
            this.splitter6.TabStop = false;
            // 
            // lnkWarehouses
            // 
            this.lnkWarehouses.AutoSize = true;
            this.lnkWarehouses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkWarehouses.Image = global::IMS.Properties.Resources.icons8_Depot_16px;
            this.lnkWarehouses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkWarehouses.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkWarehouses.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkWarehouses.Location = new System.Drawing.Point(5, 212);
            this.lnkWarehouses.Margin = new System.Windows.Forms.Padding(5);
            this.lnkWarehouses.Name = "lnkWarehouses";
            this.lnkWarehouses.Size = new System.Drawing.Size(112, 17);
            this.lnkWarehouses.TabIndex = 17;
            this.lnkWarehouses.TabStop = true;
            this.lnkWarehouses.Text = "      Warehouses";
            this.lnkWarehouses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkWarehouses.Visible = false;
            this.lnkWarehouses.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // splitter3
            // 
            this.splitter3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(3, 237);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(150, 3);
            this.splitter3.TabIndex = 14;
            this.splitter3.TabStop = false;
            // 
            // lnkUsers
            // 
            this.lnkUsers.AutoSize = true;
            this.lnkUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkUsers.Image = global::IMS.Properties.Resources.icons8_User_Account_16px;
            this.lnkUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkUsers.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkUsers.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkUsers.Location = new System.Drawing.Point(5, 248);
            this.lnkUsers.Margin = new System.Windows.Forms.Padding(5);
            this.lnkUsers.Name = "lnkUsers";
            this.lnkUsers.Size = new System.Drawing.Size(69, 17);
            this.lnkUsers.TabIndex = 6;
            this.lnkUsers.TabStop = true;
            this.lnkUsers.Text = "      Users";
            this.lnkUsers.Visible = false;
            this.lnkUsers.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // lnkPermissions
            // 
            this.lnkPermissions.AutoSize = true;
            this.lnkPermissions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkPermissions.Image = global::IMS.Properties.Resources.icons8_Access_16px;
            this.lnkPermissions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkPermissions.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkPermissions.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkPermissions.Location = new System.Drawing.Point(5, 275);
            this.lnkPermissions.Margin = new System.Windows.Forms.Padding(5);
            this.lnkPermissions.Name = "lnkPermissions";
            this.lnkPermissions.Size = new System.Drawing.Size(108, 17);
            this.lnkPermissions.TabIndex = 7;
            this.lnkPermissions.TabStop = true;
            this.lnkPermissions.Text = "      Permissions";
            this.lnkPermissions.Visible = false;
            this.lnkPermissions.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // splitter4
            // 
            this.splitter4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter4.Location = new System.Drawing.Point(3, 300);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(150, 3);
            this.splitter4.TabIndex = 15;
            this.splitter4.TabStop = false;
            this.splitter4.Visible = false;
            // 
            // InventorySettingsSidebarUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlLinks);
            this.Name = "InventorySettingsSidebarUC";
            this.Size = new System.Drawing.Size(179, 484);
            this.pnlLinks.ResumeLayout(false);
            this.pnlLinks.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlLinks;
        protected internal System.Windows.Forms.LinkLabel lnkReferences;
        protected internal System.Windows.Forms.LinkLabel lnkProductCategory;
        protected internal System.Windows.Forms.LinkLabel lnkPackages;
        protected internal System.Windows.Forms.LinkLabel lnkUom;
        protected internal System.Windows.Forms.LinkLabel lnkAdjustmentCodes;
        protected internal System.Windows.Forms.LinkLabel lnkUsers;
        protected internal System.Windows.Forms.LinkLabel lnkPermissions;
        protected internal System.Windows.Forms.LinkLabel lnkProfile;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter6;
        protected internal System.Windows.Forms.LinkLabel lnkWarehouses;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Splitter splitter4;
        protected internal System.Windows.Forms.LinkLabel lnkPreferences;
    }
}
