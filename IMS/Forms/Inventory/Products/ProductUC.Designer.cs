namespace IMS.Forms.Inventory.Products
{
    partial class ProductUC
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlLinkList = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lnkList = new System.Windows.Forms.LinkLabel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.subHeading = new IMS.Forms.Common.Display.SubHeaderTemplate();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(175, 457);
            this.panel1.TabIndex = 8;
            // 
            // pnlLinkList
            // 
            this.pnlLinkList.AutoSize = true;
            this.pnlLinkList.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLinkList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlLinkList.Location = new System.Drawing.Point(3, 20);
            this.pnlLinkList.MinimumSize = new System.Drawing.Size(0, 10);
            this.pnlLinkList.Name = "pnlLinkList";
            this.pnlLinkList.Padding = new System.Windows.Forms.Padding(10, 0, 0, 10);
            this.pnlLinkList.Size = new System.Drawing.Size(92, 10);
            this.pnlLinkList.TabIndex = 1;
            this.pnlLinkList.WrapContents = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lnkList);
            this.flowLayoutPanel2.Controls.Add(this.pnlLinkList);
            this.flowLayoutPanel2.Controls.Add(this.linkLabel1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(5, 5);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(165, 427);
            this.flowLayoutPanel2.TabIndex = 2;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // lnkList
            // 
            this.lnkList.AutoSize = true;
            this.lnkList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkList.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkList.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkList.Location = new System.Drawing.Point(3, 0);
            this.lnkList.Name = "lnkList";
            this.lnkList.Size = new System.Drawing.Size(92, 17);
            this.lnkList.TabIndex = 2;
            this.lnkList.TabStop = true;
            this.lnkList.Text = "• Product List";
            this.toolTip1.SetToolTip(this.lnkList, "Go to Purchase Order List");
            this.lnkList.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // pnlBody
            // 
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(180, 42);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(466, 390);
            this.pnlBody.TabIndex = 11;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(180, 432);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(466, 25);
            this.pnlFooter.TabIndex = 9;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(175, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 457);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            // 
            // subHeading
            // 
            this.subHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.subHeading.Location = new System.Drawing.Point(180, 0);
            this.subHeading.Name = "subHeading";
            this.subHeading.Size = new System.Drawing.Size(466, 42);
            this.subHeading.TabIndex = 0;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.linkLabel1.Location = new System.Drawing.Point(3, 33);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(92, 17);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "• Product List";
            this.toolTip1.SetToolTip(this.linkLabel1, "Go to Purchase Order List");
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // ProductUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.subHeading);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "ProductUC";
            this.Size = new System.Drawing.Size(646, 457);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel pnlLinkList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.LinkLabel lnkList;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Splitter splitter1;
        private Common.Display.SubHeaderTemplate subHeading;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}
