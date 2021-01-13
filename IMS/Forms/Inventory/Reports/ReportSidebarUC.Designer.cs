namespace IMS.Forms.Inventory.Reports
{
    partial class ReportSidebarUC
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
            this.splitter5 = new System.Windows.Forms.Splitter();
            this.btnLedger = new System.Windows.Forms.LinkLabel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.SuspendLayout();
            // 
            // splitter5
            // 
            this.splitter5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitter5.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter5.Location = new System.Drawing.Point(5, 5);
            this.splitter5.Name = "splitter5";
            this.splitter5.Size = new System.Drawing.Size(168, 3);
            this.splitter5.TabIndex = 16;
            this.splitter5.TabStop = false;
            // 
            // btnLedger
            // 
            this.btnLedger.AutoSize = true;
            this.btnLedger.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLedger.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLedger.Image = global::IMS.Properties.Resources.icons8_Deviation_16px;
            this.btnLedger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLedger.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.btnLedger.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnLedger.Location = new System.Drawing.Point(5, 8);
            this.btnLedger.Margin = new System.Windows.Forms.Padding(5);
            this.btnLedger.Name = "btnLedger";
            this.btnLedger.Padding = new System.Windows.Forms.Padding(5);
            this.btnLedger.Size = new System.Drawing.Size(87, 27);
            this.btnLedger.TabIndex = 11;
            this.btnLedger.TabStop = true;
            this.btnLedger.Text = "      Ledger";
            this.btnLedger.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(5, 35);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(168, 3);
            this.splitter2.TabIndex = 13;
            this.splitter2.TabStop = false;
            // 
            // ReportSidebarUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.btnLedger);
            this.Controls.Add(this.splitter5);
            this.Name = "ReportSidebarUC";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(178, 436);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Splitter splitter5;
        protected internal System.Windows.Forms.LinkLabel btnLedger;
        private System.Windows.Forms.Splitter splitter2;
    }
}
