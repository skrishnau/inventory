namespace IMS.Forms.Inventory.Suppliers
{
    partial class ClientSideBarUC
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
            this.pnlBody = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlLinkList = new System.Windows.Forms.FlowLayoutPanel();
            this.lnkList = new System.Windows.Forms.LinkLabel();
            this.lnkTransfers = new System.Windows.Forms.LinkLabel();
            this.lnkFlow = new System.Windows.Forms.LinkLabel();
            this.lnkUsageReport = new System.Windows.Forms.LinkLabel();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.lnkList);
            this.pnlBody.Controls.Add(this.pnlLinkList);
            this.pnlBody.Controls.Add(this.lnkTransfers);
            this.pnlBody.Controls.Add(this.lnkFlow);
            this.pnlBody.Controls.Add(this.lnkUsageReport);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(173, 448);
            this.pnlBody.TabIndex = 4;
            this.pnlBody.WrapContents = false;
            // 
            // pnlLinkList
            // 
            this.pnlLinkList.AutoSize = true;
            this.pnlLinkList.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLinkList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlLinkList.Location = new System.Drawing.Point(0, 27);
            this.pnlLinkList.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLinkList.Name = "pnlLinkList";
            this.pnlLinkList.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pnlLinkList.Size = new System.Drawing.Size(156, 0);
            this.pnlLinkList.TabIndex = 1;
            this.pnlLinkList.WrapContents = false;
            // 
            // lnkList
            // 
            this.lnkList.AutoSize = true;
            this.lnkList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkList.Image = global::IMS.Properties.Resources.icons8_View_More_24px;
            this.lnkList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkList.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkList.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkList.Location = new System.Drawing.Point(5, 5);
            this.lnkList.Margin = new System.Windows.Forms.Padding(5);
            this.lnkList.Name = "lnkList";
            this.lnkList.Size = new System.Drawing.Size(115, 17);
            this.lnkList.TabIndex = 2;
            this.lnkList.TabStop = true;
            this.lnkList.Text = "     • Supplier List";
            this.lnkList.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // lnkTransfers
            // 
            this.lnkTransfers.AutoSize = true;
            this.lnkTransfers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkTransfers.Image = global::IMS.Properties.Resources.icons8_Hashtag_Activity_Grid_16px;
            this.lnkTransfers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkTransfers.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkTransfers.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkTransfers.Location = new System.Drawing.Point(5, 32);
            this.lnkTransfers.Margin = new System.Windows.Forms.Padding(5);
            this.lnkTransfers.Name = "lnkTransfers";
            this.lnkTransfers.Size = new System.Drawing.Size(146, 17);
            this.lnkTransfers.TabIndex = 3;
            this.lnkTransfers.TabStop = true;
            this.lnkTransfers.Text = "     • Reliability Metrics";
            this.lnkTransfers.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // lnkFlow
            // 
            this.lnkFlow.AutoSize = true;
            this.lnkFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkFlow.Image = global::IMS.Properties.Resources.icons8_Combo_Chart_16px;
            this.lnkFlow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkFlow.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkFlow.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkFlow.Location = new System.Drawing.Point(5, 59);
            this.lnkFlow.Margin = new System.Windows.Forms.Padding(5);
            this.lnkFlow.Name = "lnkFlow";
            this.lnkFlow.Size = new System.Drawing.Size(104, 17);
            this.lnkFlow.TabIndex = 4;
            this.lnkFlow.TabStop = true;
            this.lnkFlow.Text = "     • Txn Graph";
            this.lnkFlow.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // lnkUsageReport
            // 
            this.lnkUsageReport.AutoSize = true;
            this.lnkUsageReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkUsageReport.Image = global::IMS.Properties.Resources.icons8_Order_History_16px;
            this.lnkUsageReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkUsageReport.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkUsageReport.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkUsageReport.Location = new System.Drawing.Point(5, 86);
            this.lnkUsageReport.Margin = new System.Windows.Forms.Padding(5);
            this.lnkUsageReport.Name = "lnkUsageReport";
            this.lnkUsageReport.Size = new System.Drawing.Size(145, 17);
            this.lnkUsageReport.TabIndex = 5;
            this.lnkUsageReport.TabStop = true;
            this.lnkUsageReport.Text = "     • Fulfilment History";
            this.lnkUsageReport.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // SupplierSideBarUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBody);
            this.Name = "SupplierSideBarUC";
            this.Size = new System.Drawing.Size(173, 448);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlBody;
        protected internal System.Windows.Forms.LinkLabel lnkList;
        protected internal System.Windows.Forms.FlowLayoutPanel pnlLinkList;
        protected internal System.Windows.Forms.LinkLabel lnkTransfers;
        protected internal System.Windows.Forms.LinkLabel lnkFlow;
        protected internal System.Windows.Forms.LinkLabel lnkUsageReport;
    }
}
