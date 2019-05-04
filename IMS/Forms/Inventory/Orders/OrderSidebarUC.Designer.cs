namespace IMS.Forms.Inventory.Orders
{
    partial class OrderSidebarUC
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
            this.pnlLinkList = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBody = new System.Windows.Forms.FlowLayoutPanel();
            this.lnkList = new System.Windows.Forms.LinkLabel();
            this.lnkManage = new System.Windows.Forms.LinkLabel();
            this.lnkInventoryFlow = new System.Windows.Forms.LinkLabel();
            this.lnkTraffic = new System.Windows.Forms.LinkLabel();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
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
            this.pnlLinkList.Size = new System.Drawing.Size(160, 0);
            this.pnlLinkList.TabIndex = 1;
            this.pnlLinkList.WrapContents = false;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.lnkList);
            this.pnlBody.Controls.Add(this.pnlLinkList);
            this.pnlBody.Controls.Add(this.lnkManage);
            this.pnlBody.Controls.Add(this.lnkInventoryFlow);
            this.pnlBody.Controls.Add(this.lnkTraffic);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(181, 198);
            this.pnlBody.TabIndex = 7;
            this.pnlBody.WrapContents = false;
            // 
            // lnkList
            // 
            this.lnkList.AutoSize = true;
            this.lnkList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkList.Image = global::IMS.Properties.Resources.icons8_List_16px;
            this.lnkList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkList.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkList.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkList.Location = new System.Drawing.Point(5, 5);
            this.lnkList.Margin = new System.Windows.Forms.Padding(5);
            this.lnkList.Name = "lnkList";
            this.lnkList.Size = new System.Drawing.Size(100, 17);
            this.lnkList.TabIndex = 2;
            this.lnkList.TabStop = true;
            this.lnkList.Text = "     • Order List";
            this.lnkList.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // lnkManage
            // 
            this.lnkManage.AutoSize = true;
            this.lnkManage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkManage.Image = global::IMS.Properties.Resources.icons8_Maintenance_16px;
            this.lnkManage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkManage.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkManage.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkManage.Location = new System.Drawing.Point(5, 32);
            this.lnkManage.Margin = new System.Windows.Forms.Padding(5);
            this.lnkManage.Name = "lnkManage";
            this.lnkManage.Size = new System.Drawing.Size(150, 17);
            this.lnkManage.TabIndex = 3;
            this.lnkManage.TabStop = true;
            this.lnkManage.Text = "     • Manage Inventory";
            this.lnkManage.Visible = false;
            this.lnkManage.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // lnkInventoryFlow
            // 
            this.lnkInventoryFlow.AutoSize = true;
            this.lnkInventoryFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkInventoryFlow.Image = global::IMS.Properties.Resources.icons8_Inventory_Flow_16px;
            this.lnkInventoryFlow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkInventoryFlow.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkInventoryFlow.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkInventoryFlow.Location = new System.Drawing.Point(5, 59);
            this.lnkInventoryFlow.Margin = new System.Windows.Forms.Padding(5);
            this.lnkInventoryFlow.Name = "lnkInventoryFlow";
            this.lnkInventoryFlow.Size = new System.Drawing.Size(127, 17);
            this.lnkInventoryFlow.TabIndex = 4;
            this.lnkInventoryFlow.TabStop = true;
            this.lnkInventoryFlow.Text = "     • Inventory Flow";
            this.lnkInventoryFlow.Visible = false;
            this.lnkInventoryFlow.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // lnkTraffic
            // 
            this.lnkTraffic.AutoSize = true;
            this.lnkTraffic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkTraffic.Image = global::IMS.Properties.Resources.icons8_Traffic_Light_16px;
            this.lnkTraffic.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkTraffic.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkTraffic.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkTraffic.Location = new System.Drawing.Point(5, 86);
            this.lnkTraffic.Margin = new System.Windows.Forms.Padding(5);
            this.lnkTraffic.Name = "lnkTraffic";
            this.lnkTraffic.Size = new System.Drawing.Size(77, 17);
            this.lnkTraffic.TabIndex = 5;
            this.lnkTraffic.TabStop = true;
            this.lnkTraffic.Text = "     • Traffic";
            this.lnkTraffic.Visible = false;
            this.lnkTraffic.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // OrderSidebarUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBody);
            this.Name = "OrderSidebarUC";
            this.Size = new System.Drawing.Size(181, 198);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected internal System.Windows.Forms.FlowLayoutPanel pnlLinkList;
        protected internal System.Windows.Forms.FlowLayoutPanel pnlBody;
        protected internal System.Windows.Forms.LinkLabel lnkList;
        protected internal System.Windows.Forms.LinkLabel lnkManage;
        protected internal System.Windows.Forms.LinkLabel lnkInventoryFlow;
        protected internal System.Windows.Forms.LinkLabel lnkTraffic;
    }
}
