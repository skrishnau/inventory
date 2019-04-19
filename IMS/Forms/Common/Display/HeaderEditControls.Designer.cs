namespace IMS.Forms.Common.Display
{
    partial class HeaderEditControls
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
            this.subHeadingTemplate1 = new IMS.Forms.Common.Display.SubHeadingTemplate();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // subHeadingTemplate1
            // 
            this.subHeadingTemplate1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.subHeadingTemplate1.Dock = System.Windows.Forms.DockStyle.Top;
            this.subHeadingTemplate1.Location = new System.Drawing.Point(0, 0);
            this.subHeadingTemplate1.Name = "subHeadingTemplate1";
            this.subHeadingTemplate1.Size = new System.Drawing.Size(439, 27);
            this.subHeadingTemplate1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Location = new System.Drawing.Point(0, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 123);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // HeaderEditControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.subHeadingTemplate1);
            this.Name = "HeaderEditControls";
            this.Size = new System.Drawing.Size(439, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private SubHeadingTemplate subHeadingTemplate1;
        private System.Windows.Forms.Button button1;
    }
}
