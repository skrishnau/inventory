namespace IMS.Forms.Inventory.Reports
{
    partial class ReportsUC
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
            this.bodyTemplate = new IMS.Forms.Common.Display.SettingsBodyTemplate();
            this.SuspendLayout();
            // 
            // bodyTemplate
            // 
            this.bodyTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyTemplate.HeadingText = "Heading";
            this.bodyTemplate.HeadingVisible = true;
            this.bodyTemplate.Location = new System.Drawing.Point(0, 0);
            this.bodyTemplate.Name = "bodyTemplate";
            this.bodyTemplate.Size = new System.Drawing.Size(690, 443);
            this.bodyTemplate.SubHeadingText = "Heading";
            this.bodyTemplate.SubHeadingVisible = true;
            this.bodyTemplate.TabIndex = 0;
            // 
            // ReportsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bodyTemplate);
            this.Name = "ReportsUC";
            this.Size = new System.Drawing.Size(690, 443);
            this.ResumeLayout(false);

        }

        #endregion

        private Common.Display.SettingsBodyTemplate bodyTemplate;
    }
}
