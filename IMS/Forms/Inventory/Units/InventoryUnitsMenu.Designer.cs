namespace IMS.Forms.Inventory.Units
{
    partial class InventoryUnitsMenu
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
            this.lnkManage = new System.Windows.Forms.LinkLabel();
            this.lnkMovement = new System.Windows.Forms.LinkLabel();
            this.pnlLinkList = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.lnkSummary);
            this.pnlBody.Controls.Add(this.lnkManage);
            this.pnlBody.Controls.Add(this.lnkMovement);
            this.pnlBody.Controls.Add(this.pnlLinkList);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(8, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(857, 32);
            this.pnlBody.TabIndex = 5;
            this.pnlBody.WrapContents = false;
            // 
            // lnkSummary
            // 
            this.lnkSummary.AutoSize = true;
            this.lnkSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkSummary.Image = global::IMS.Properties.Resources.icons8_View_More_24px;
            this.lnkSummary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkSummary.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkSummary.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkSummary.Location = new System.Drawing.Point(5, 5);
            this.lnkSummary.Margin = new System.Windows.Forms.Padding(5);
            this.lnkSummary.Name = "lnkSummary";
            this.lnkSummary.Padding = new System.Windows.Forms.Padding(5);
            this.lnkSummary.Size = new System.Drawing.Size(106, 27);
            this.lnkSummary.TabIndex = 2;
            this.lnkSummary.TabStop = true;
            this.lnkSummary.Text = "     • Summary";
            this.lnkSummary.Visible = false;
            this.lnkSummary.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // lnkManage
            // 
            this.lnkManage.AutoSize = true;
            this.lnkManage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkManage.Image = global::IMS.Properties.Resources.icons8_Maintenance_16px;
            this.lnkManage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkManage.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkManage.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkManage.Location = new System.Drawing.Point(121, 5);
            this.lnkManage.Margin = new System.Windows.Forms.Padding(5);
            this.lnkManage.Name = "lnkManage";
            this.lnkManage.Padding = new System.Windows.Forms.Padding(5);
            this.lnkManage.Size = new System.Drawing.Size(160, 27);
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
            this.lnkMovement.Location = new System.Drawing.Point(291, 5);
            this.lnkMovement.Margin = new System.Windows.Forms.Padding(5);
            this.lnkMovement.Name = "lnkMovement";
            this.lnkMovement.Padding = new System.Windows.Forms.Padding(5);
            this.lnkMovement.Size = new System.Drawing.Size(112, 27);
            this.lnkMovement.TabIndex = 6;
            this.lnkMovement.TabStop = true;
            this.lnkMovement.Text = "     • Movement";
            this.lnkMovement.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // pnlLinkList
            // 
            this.pnlLinkList.AutoSize = true;
            this.pnlLinkList.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLinkList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlLinkList.Location = new System.Drawing.Point(408, 0);
            this.pnlLinkList.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLinkList.Name = "pnlLinkList";
            this.pnlLinkList.Size = new System.Drawing.Size(0, 0);
            this.pnlLinkList.TabIndex = 1;
            this.pnlLinkList.WrapContents = false;
            // 
            // InventoryUnitsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.pnlBody);
            this.Name = "InventoryUnitsMenu";
            this.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.Size = new System.Drawing.Size(865, 32);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlBody;
        protected internal System.Windows.Forms.LinkLabel lnkSummary;
        protected internal System.Windows.Forms.FlowLayoutPanel pnlLinkList;
        protected internal System.Windows.Forms.LinkLabel lnkManage;
        protected internal System.Windows.Forms.LinkLabel lnkMovement;
    }
}
