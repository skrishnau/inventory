namespace IMS.Forms.Common.Display
{
    partial class ListBodyTemplate
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
            this.components = new System.ComponentModel.Container();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.headingControl = new IMS.Forms.Common.Display.ListHeaderTemplate();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(5, 32);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(629, 457);
            this.pnlBody.TabIndex = 17;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(634, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 489);
            this.splitter1.TabIndex = 16;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(5, 489);
            this.splitter2.TabIndex = 0;
            this.splitter2.TabStop = false;
            // 
            // headingControl
            // 
            this.headingControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.headingControl.HeadingText = "Heading";
            this.headingControl.Location = new System.Drawing.Point(5, 0);
            this.headingControl.Name = "headingControl";
            this.headingControl.Size = new System.Drawing.Size(629, 32);
            this.headingControl.TabIndex = 0;
            // 
            // ListBodyTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.headingControl);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Name = "ListBodyTemplate";
            this.Size = new System.Drawing.Size(639, 489);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Splitter splitter1;
        protected internal System.Windows.Forms.Panel pnlBody;
        protected internal System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Splitter splitter2;
        protected internal ListHeaderTemplate headingControl;
    }
}
