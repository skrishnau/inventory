namespace IMS.Forms.Inventory.Suppliers
{
    partial class SupplierUC
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
            this.listHeaderTemplate1 = new IMS.Forms.Common.Display.ListHeaderTemplate();
            this.SuspendLayout();
            // 
            // listHeaderTemplate1
            // 
            this.listHeaderTemplate1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listHeaderTemplate1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listHeaderTemplate1.HeadingText = "Clients";
            this.listHeaderTemplate1.Location = new System.Drawing.Point(0, 0);
            this.listHeaderTemplate1.Name = "listHeaderTemplate1";
            this.listHeaderTemplate1.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.listHeaderTemplate1.Size = new System.Drawing.Size(644, 32);
            this.listHeaderTemplate1.TabIndex = 0;
            // 
            // SupplierUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listHeaderTemplate1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SupplierUC";
            this.Size = new System.Drawing.Size(644, 524);
            this.ResumeLayout(false);

        }

        #endregion

        private Common.Display.ListHeaderTemplate listHeaderTemplate1;
    }
}
