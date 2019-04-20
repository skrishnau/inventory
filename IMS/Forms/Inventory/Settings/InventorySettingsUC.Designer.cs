namespace IMS.Forms.Inventory.Settings
{
    partial class InventorySettingsUC
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lnkProductCategory = new System.Windows.Forms.LinkLabel();
            this.lnkAdjustmentCodes = new System.Windows.Forms.LinkLabel();
            this.lnkUom = new System.Windows.Forms.LinkLabel();
            this.lnkPackages = new System.Windows.Forms.LinkLabel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlLinks = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.heading = new IMS.Forms.Common.Display.HeaderTemplate();
            this.subHeading = new IMS.Forms.Common.Display.SubHeaderTemplate();
            this.panel1.SuspendLayout();
            this.pnlLinks.SuspendLayout();
            this.SuspendLayout();
            // 
            // lnkProductCategory
            // 
            this.lnkProductCategory.AutoSize = true;
            this.lnkProductCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkProductCategory.Image = global::IMS.Properties.Resources.icons8_Categorize_16px;
            this.lnkProductCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkProductCategory.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkProductCategory.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkProductCategory.Location = new System.Drawing.Point(5, 5);
            this.lnkProductCategory.Margin = new System.Windows.Forms.Padding(5);
            this.lnkProductCategory.Name = "lnkProductCategory";
            this.lnkProductCategory.Size = new System.Drawing.Size(147, 17);
            this.lnkProductCategory.TabIndex = 2;
            this.lnkProductCategory.TabStop = true;
            this.lnkProductCategory.Text = "     • Product Category";
            this.lnkProductCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.lnkProductCategory, "Product Category Settings");
            this.lnkProductCategory.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // lnkAdjustmentCodes
            // 
            this.lnkAdjustmentCodes.AutoSize = true;
            this.lnkAdjustmentCodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAdjustmentCodes.Image = global::IMS.Properties.Resources.icons8_Adjust_16px;
            this.lnkAdjustmentCodes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkAdjustmentCodes.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkAdjustmentCodes.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkAdjustmentCodes.Location = new System.Drawing.Point(5, 59);
            this.lnkAdjustmentCodes.Margin = new System.Windows.Forms.Padding(5);
            this.lnkAdjustmentCodes.Name = "lnkAdjustmentCodes";
            this.lnkAdjustmentCodes.Size = new System.Drawing.Size(151, 17);
            this.lnkAdjustmentCodes.TabIndex = 3;
            this.lnkAdjustmentCodes.TabStop = true;
            this.lnkAdjustmentCodes.Text = "     • Adjustment Codes";
            this.lnkAdjustmentCodes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.lnkAdjustmentCodes, "Go to Purchase Order List");
            this.lnkAdjustmentCodes.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // lnkUom
            // 
            this.lnkUom.AutoSize = true;
            this.lnkUom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkUom.Image = global::IMS.Properties.Resources.icons8_Scales_16px;
            this.lnkUom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkUom.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkUom.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkUom.Location = new System.Drawing.Point(5, 32);
            this.lnkUom.Margin = new System.Windows.Forms.Padding(5);
            this.lnkUom.Name = "lnkUom";
            this.lnkUom.Size = new System.Drawing.Size(144, 17);
            this.lnkUom.TabIndex = 4;
            this.lnkUom.TabStop = true;
            this.lnkUom.Text = "     • Units of Measure";
            this.toolTip1.SetToolTip(this.lnkUom, "Go to Purchase Order List");
            this.lnkUom.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // lnkPackages
            // 
            this.lnkPackages.AutoSize = true;
            this.lnkPackages.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkPackages.Image = global::IMS.Properties.Resources.icons8_Packaging_16px;
            this.lnkPackages.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkPackages.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkPackages.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkPackages.Location = new System.Drawing.Point(5, 86);
            this.lnkPackages.Margin = new System.Windows.Forms.Padding(5);
            this.lnkPackages.Name = "lnkPackages";
            this.lnkPackages.Size = new System.Drawing.Size(99, 17);
            this.lnkPackages.TabIndex = 5;
            this.lnkPackages.TabStop = true;
            this.lnkPackages.Text = "     • Packages";
            this.toolTip1.SetToolTip(this.lnkPackages, "Go to Purchase Order List");
            this.lnkPackages.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(180, 417);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(616, 25);
            this.pnlFooter.TabIndex = 9;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.splitter1.Location = new System.Drawing.Point(175, 27);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 415);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlLinks);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(175, 415);
            this.panel1.TabIndex = 8;
            // 
            // pnlLinks
            // 
            this.pnlLinks.Controls.Add(this.lnkProductCategory);
            this.pnlLinks.Controls.Add(this.lnkUom);
            this.pnlLinks.Controls.Add(this.lnkAdjustmentCodes);
            this.pnlLinks.Controls.Add(this.lnkPackages);
            this.pnlLinks.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLinks.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlLinks.Location = new System.Drawing.Point(5, 5);
            this.pnlLinks.Name = "pnlLinks";
            this.pnlLinks.Size = new System.Drawing.Size(165, 263);
            this.pnlLinks.TabIndex = 2;
            this.pnlLinks.WrapContents = false;
            // 
            // pnlBody
            // 
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(180, 69);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(616, 348);
            this.pnlBody.TabIndex = 11;
            // 
            // heading
            // 
            this.heading.BackColor = System.Drawing.Color.DarkSlateGray;
            this.heading.Dock = System.Windows.Forms.DockStyle.Top;
            this.heading.Location = new System.Drawing.Point(0, 0);
            this.heading.Name = "heading";
            this.heading.Size = new System.Drawing.Size(796, 27);
            this.heading.TabIndex = 6;
            // 
            // subHeading
            // 
            this.subHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.subHeading.Location = new System.Drawing.Point(180, 27);
            this.subHeading.Name = "subHeading";
            this.subHeading.Size = new System.Drawing.Size(616, 42);
            this.subHeading.TabIndex = 6;
            // 
            // InventorySettingsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.subHeading);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.heading);
            this.Name = "InventorySettingsUC";
            this.Size = new System.Drawing.Size(796, 442);
            this.panel1.ResumeLayout(false);
            this.pnlLinks.ResumeLayout(false);
            this.pnlLinks.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel lnkProductCategory;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.LinkLabel lnkAdjustmentCodes;
        private System.Windows.Forms.LinkLabel lnkUom;
        private System.Windows.Forms.FlowLayoutPanel pnlLinks;
        private System.Windows.Forms.LinkLabel lnkPackages;
        private Common.Display.HeaderTemplate heading;
        private Common.Display.SubHeaderTemplate subHeading;
    }
}
