namespace IMS.Forms.Inventory.Sales
{
    partial class SaleOrderUC
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
            this._body = new IMS.Forms.Common.Display.SubBodyTemplate();
            this.SuspendLayout();
            // 
            // _body
            // 
            this._body.Dock = System.Windows.Forms.DockStyle.Fill;
            this._body.HeadingText = "Heading";
            this._body.Location = new System.Drawing.Point(0, 0);
            this._body.Name = "_body";
            this._body.Size = new System.Drawing.Size(575, 362);
            this._body.SubHeadingText = "Heading";
            this._body.TabIndex = 0;
            // 
            // SaleOrderUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._body);
            this.Name = "SaleOrderUC";
            this.Size = new System.Drawing.Size(575, 362);
            this.ResumeLayout(false);

        }

        #endregion

        private Common.Display.SubBodyTemplate _body;
    }
}
