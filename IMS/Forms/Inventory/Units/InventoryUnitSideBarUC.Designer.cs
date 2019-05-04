namespace IMS.Forms.Inventory.Units
{
    partial class InventoryUnitSideBarUC
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
            this.lnkSummary = new System.Windows.Forms.LinkLabel();
            this.pnlLinkList = new System.Windows.Forms.FlowLayoutPanel();
            this.lnkManage = new System.Windows.Forms.LinkLabel();
            this.lnkMovement = new System.Windows.Forms.LinkLabel();
            this.lnkInventoryFlow = new System.Windows.Forms.LinkLabel();
            this.lnkTraffic = new System.Windows.Forms.LinkLabel();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.lnkSummary);
            this.pnlBody.Controls.Add(this.pnlLinkList);
            this.pnlBody.Controls.Add(this.lnkManage);
            this.pnlBody.Controls.Add(this.lnkMovement);
            this.pnlBody.Controls.Add(this.lnkInventoryFlow);
            this.pnlBody.Controls.Add(this.lnkTraffic);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(185, 272);
            this.pnlBody.TabIndex = 5;
            this.pnlBody.WrapContents = false;
            // 
            // lnkSummary
            // 
            this.lnkSummary.AutoSize = true;
            this.lnkSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkSummary.Image = global::IMS.Properties.Resources.icons8_List_16px;
            this.lnkSummary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkSummary.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkSummary.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkSummary.Location = new System.Drawing.Point(5, 5);
            this.lnkSummary.Margin = new System.Windows.Forms.Padding(5);
            this.lnkSummary.Name = "lnkSummary";
            this.lnkSummary.Size = new System.Drawing.Size(96, 17);
            this.lnkSummary.TabIndex = 2;
            this.lnkSummary.TabStop = true;
            this.lnkSummary.Text = "     • Summary";
            this.lnkSummary.VisitedLinkColor = System.Drawing.Color.Black;
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
            this.lnkManage.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // lnkMovement
            // 
            this.lnkMovement.AutoSize = true;
            this.lnkMovement.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkMovement.Image = global::IMS.Properties.Resources.icons8_Inventory_Flow_16px;
            this.lnkMovement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkMovement.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkMovement.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkMovement.Location = new System.Drawing.Point(5, 59);
            this.lnkMovement.Margin = new System.Windows.Forms.Padding(5);
            this.lnkMovement.Name = "lnkMovement";
            this.lnkMovement.Size = new System.Drawing.Size(102, 17);
            this.lnkMovement.TabIndex = 6;
            this.lnkMovement.TabStop = true;
            this.lnkMovement.Text = "     • Movement";
            this.lnkMovement.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // lnkInventoryFlow
            // 
            this.lnkInventoryFlow.AutoSize = true;
            this.lnkInventoryFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkInventoryFlow.Image = global::IMS.Properties.Resources.icons8_Inventory_Flow_16px;
            this.lnkInventoryFlow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkInventoryFlow.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkInventoryFlow.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkInventoryFlow.Location = new System.Drawing.Point(5, 86);
            this.lnkInventoryFlow.Margin = new System.Windows.Forms.Padding(5);
            this.lnkInventoryFlow.Name = "lnkInventoryFlow";
            this.lnkInventoryFlow.Size = new System.Drawing.Size(127, 17);
            this.lnkInventoryFlow.TabIndex = 4;
            this.lnkInventoryFlow.TabStop = true;
            this.lnkInventoryFlow.Text = "     • Inventory Flow";
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
            this.lnkTraffic.Location = new System.Drawing.Point(5, 113);
            this.lnkTraffic.Margin = new System.Windows.Forms.Padding(5);
            this.lnkTraffic.Name = "lnkTraffic";
            this.lnkTraffic.Size = new System.Drawing.Size(77, 17);
            this.lnkTraffic.TabIndex = 5;
            this.lnkTraffic.TabStop = true;
            this.lnkTraffic.Text = "     • Traffic";
            this.lnkTraffic.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // InventoryUnitSideBarUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBody);
            this.Name = "InventoryUnitSideBarUC";
            this.Size = new System.Drawing.Size(185, 272);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlBody;
        protected internal System.Windows.Forms.LinkLabel lnkSummary;
        protected internal System.Windows.Forms.FlowLayoutPanel pnlLinkList;
        protected internal System.Windows.Forms.LinkLabel lnkManage;
        protected internal System.Windows.Forms.LinkLabel lnkInventoryFlow;
        protected internal System.Windows.Forms.LinkLabel lnkTraffic;
        protected internal System.Windows.Forms.LinkLabel lnkMovement;
    }
}
