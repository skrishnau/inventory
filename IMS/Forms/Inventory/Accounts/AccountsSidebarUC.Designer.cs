namespace IMS.Forms.Inventory.Reports
{
    partial class AccountsSidebarUC
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
            this.btnPayments = new System.Windows.Forms.LinkLabel();
            this.btnLedger = new System.Windows.Forms.LinkLabel();
            this.btnProfitAndLoss = new System.Windows.Forms.LinkLabel();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.pnlLinks = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlLinks.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPayments
            // 
            this.btnPayments.AutoSize = true;
            this.btnPayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnPayments.Image = global::IMS.Properties.Resources.icons8_Lease_16px;
            this.btnPayments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPayments.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.btnPayments.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPayments.Location = new System.Drawing.Point(5, 5);
            this.btnPayments.Margin = new System.Windows.Forms.Padding(5);
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Size = new System.Drawing.Size(94, 17);
            this.btnPayments.TabIndex = 11;
            this.btnPayments.TabStop = true;
            this.btnPayments.Text = "      Payments";
            this.btnPayments.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // btnLedger
            // 
            this.btnLedger.AutoSize = true;
            this.btnLedger.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLedger.Image = global::IMS.Properties.Resources.icons8_Deviation_16px;
            this.btnLedger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLedger.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.btnLedger.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnLedger.Location = new System.Drawing.Point(5, 32);
            this.btnLedger.Margin = new System.Windows.Forms.Padding(5);
            this.btnLedger.Name = "btnLedger";
            this.btnLedger.Size = new System.Drawing.Size(77, 17);
            this.btnLedger.TabIndex = 17;
            this.btnLedger.TabStop = true;
            this.btnLedger.Text = "      Ledger";
            this.btnLedger.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // btnProfitAndLoss
            // 
            this.btnProfitAndLoss.AutoSize = true;
            this.btnProfitAndLoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfitAndLoss.Image = global::IMS.Properties.Resources.icons8_Combo_Chart_16px;
            this.btnProfitAndLoss.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfitAndLoss.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.btnProfitAndLoss.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnProfitAndLoss.Location = new System.Drawing.Point(5, 59);
            this.btnProfitAndLoss.Margin = new System.Windows.Forms.Padding(5);
            this.btnProfitAndLoss.Name = "btnProfitAndLoss";
            this.btnProfitAndLoss.Size = new System.Drawing.Size(128, 17);
            this.btnProfitAndLoss.TabIndex = 19;
            this.btnProfitAndLoss.TabStop = true;
            this.btnProfitAndLoss.Text = "      Profit And Loss";
            this.btnProfitAndLoss.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // splitter3
            // 
            this.splitter3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(3, 84);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(132, 3);
            this.splitter3.TabIndex = 20;
            this.splitter3.TabStop = false;
            // 
            // pnlLinks
            // 
            this.pnlLinks.Controls.Add(this.btnPayments);
            this.pnlLinks.Controls.Add(this.btnLedger);
            this.pnlLinks.Controls.Add(this.btnProfitAndLoss);
            this.pnlLinks.Controls.Add(this.splitter3);
            this.pnlLinks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLinks.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlLinks.Location = new System.Drawing.Point(0, 0);
            this.pnlLinks.Name = "pnlLinks";
            this.pnlLinks.Size = new System.Drawing.Size(178, 436);
            this.pnlLinks.TabIndex = 21;
            this.pnlLinks.WrapContents = false;
            // 
            // AccountsSidebarUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlLinks);
            this.Name = "AccountsSidebarUC";
            this.Size = new System.Drawing.Size(178, 436);
            this.pnlLinks.ResumeLayout(false);
            this.pnlLinks.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        protected internal System.Windows.Forms.LinkLabel btnPayments;
        protected internal System.Windows.Forms.LinkLabel btnLedger;
        protected internal System.Windows.Forms.LinkLabel btnProfitAndLoss;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.FlowLayoutPanel pnlLinks;
    }
}
