﻿namespace IMS.Forms.Inventory.Dashboard
{
    partial class DashboardUC
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
            this.headerTemplate1 = new IMS.Forms.Common.Display.HeaderTemplate();
            this.SuspendLayout();
            // 
            // headerTemplate1
            // 
            this.headerTemplate1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.headerTemplate1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerTemplate1.Location = new System.Drawing.Point(0, 0);
            this.headerTemplate1.Name = "headerTemplate1";
            this.headerTemplate1.Size = new System.Drawing.Size(768, 27);
            this.headerTemplate1.TabIndex = 0;
            // 
            // DashboardUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerTemplate1);
            this.Name = "DashboardUC";
            this.Size = new System.Drawing.Size(768, 383);
            this.ResumeLayout(false);

        }

        #endregion

        private Common.Display.HeaderTemplate headerTemplate1;
    }
}
