namespace IMS.Forms.Purchases
{
    partial class PurchaseOrderUC
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
            this.pnlOrderLinkLint = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lnkPurchaseOrderList = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.lblPurchaseOrderHeaderText = new System.Windows.Forms.Label();
            this.pnlDataBody = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlOrderLinkLint);
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(175, 423);
            this.panel1.TabIndex = 2;
            // 
            // pnlOrderLinkLint
            // 
            this.pnlOrderLinkLint.AutoSize = true;
            this.pnlOrderLinkLint.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOrderLinkLint.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlOrderLinkLint.Location = new System.Drawing.Point(5, 28);
            this.pnlOrderLinkLint.MinimumSize = new System.Drawing.Size(0, 10);
            this.pnlOrderLinkLint.Name = "pnlOrderLinkLint";
            this.pnlOrderLinkLint.Padding = new System.Windows.Forms.Padding(10, 0, 0, 10);
            this.pnlOrderLinkLint.Size = new System.Drawing.Size(165, 10);
            this.pnlOrderLinkLint.TabIndex = 1;
            this.pnlOrderLinkLint.WrapContents = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lnkPurchaseOrderList);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(5, 5);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(165, 23);
            this.flowLayoutPanel2.TabIndex = 2;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // lnkPurchaseOrderList
            // 
            this.lnkPurchaseOrderList.AutoSize = true;
            this.lnkPurchaseOrderList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkPurchaseOrderList.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkPurchaseOrderList.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkPurchaseOrderList.Location = new System.Drawing.Point(3, 0);
            this.lnkPurchaseOrderList.Name = "lnkPurchaseOrderList";
            this.lnkPurchaseOrderList.Size = new System.Drawing.Size(144, 17);
            this.lnkPurchaseOrderList.TabIndex = 2;
            this.lnkPurchaseOrderList.TabStop = true;
            this.lnkPurchaseOrderList.Text = "• Purchase Order List";
            this.toolTip1.SetToolTip(this.lnkPurchaseOrderList, "Go to Purchase Order List");
            this.lnkPurchaseOrderList.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(180, 398);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 25);
            this.panel2.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.splitter1.Location = new System.Drawing.Point(175, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 423);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // lblPurchaseOrderHeaderText
            // 
            this.lblPurchaseOrderHeaderText.BackColor = System.Drawing.Color.SlateGray;
            this.lblPurchaseOrderHeaderText.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPurchaseOrderHeaderText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurchaseOrderHeaderText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPurchaseOrderHeaderText.Location = new System.Drawing.Point(180, 0);
            this.lblPurchaseOrderHeaderText.Name = "lblPurchaseOrderHeaderText";
            this.lblPurchaseOrderHeaderText.Size = new System.Drawing.Size(462, 42);
            this.lblPurchaseOrderHeaderText.TabIndex = 0;
            this.lblPurchaseOrderHeaderText.Text = "Purchase Orders";
            this.lblPurchaseOrderHeaderText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDataBody
            // 
            this.pnlDataBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataBody.Location = new System.Drawing.Point(180, 42);
            this.pnlDataBody.Name = "pnlDataBody";
            this.pnlDataBody.Size = new System.Drawing.Size(462, 356);
            this.pnlDataBody.TabIndex = 6;
            // 
            // PurchaseListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlDataBody);
            this.Controls.Add(this.lblPurchaseOrderHeaderText);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "PurchaseListUC";
            this.Size = new System.Drawing.Size(642, 423);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel pnlOrderLinkLint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel lnkPurchaseOrderList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label lblPurchaseOrderHeaderText;
        private System.Windows.Forms.Panel pnlDataBody;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
