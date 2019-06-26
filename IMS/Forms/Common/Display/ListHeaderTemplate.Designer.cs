namespace IMS.Forms.Common.Display
{
    partial class ListHeaderTemplate
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
            this.lblText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblText.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(0, 1);
            this.lblText.Name = "lblText";
            this.lblText.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblText.Size = new System.Drawing.Size(563, 30);
            this.lblText.TabIndex = 8;
            this.lblText.Text = "Heading";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ListHeaderTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.lblText);
            this.Name = "ListHeaderTemplate";
            this.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.Size = new System.Drawing.Size(563, 32);
            this.ResumeLayout(false);

        }

        #endregion

        protected internal System.Windows.Forms.Label lblText;
    }
}
