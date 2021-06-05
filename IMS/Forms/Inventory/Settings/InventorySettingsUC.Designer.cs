namespace IMS.Forms.Inventory.Settings
{
    partial class InventorySettingsUC
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
            this._body = new IMS.Forms.Common.Display.SettingsBodyTemplate();
            this.SuspendLayout();
            // 
            // _body
            // 
            this._body.Dock = System.Windows.Forms.DockStyle.Fill;
            this._body.HeadingText = "Accounts";
            this._body.HeadingVisible = true;
            this._body.Location = new System.Drawing.Point(0, 0);
            this._body.Name = "_body";
            this._body.Size = new System.Drawing.Size(552, 369);
            this._body.SubHeadingText = "Heading";
            this._body.SubHeadingVisible = true;
            this._body.TabIndex = 1;
            // 
            // InventorySettingsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._body);
            this.Name = "InventorySettingsUC";
            this.Size = new System.Drawing.Size(552, 369);
            this.ResumeLayout(false);

        }

        #endregion

        private Common.Display.SettingsBodyTemplate _body;
    }
}
