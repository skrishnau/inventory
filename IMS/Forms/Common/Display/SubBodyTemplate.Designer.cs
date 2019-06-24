namespace IMS.Forms.Common.Display
{
    partial class SubBodyTemplate
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
            this.pnlSideBar = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.subHeading = new IMS.Forms.Common.Display.SubHeaderTemplate();
            this.heading = new IMS.Forms.Common.Display.HeaderTemplate();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(185, 69);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(454, 420);
            this.pnlBody.TabIndex = 17;
            // 
            // pnlSideBar
            // 
            this.pnlSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideBar.Location = new System.Drawing.Point(5, 27);
            this.pnlSideBar.Name = "pnlSideBar";
            this.pnlSideBar.Padding = new System.Windows.Forms.Padding(5);
            this.pnlSideBar.Size = new System.Drawing.Size(175, 462);
            this.pnlSideBar.TabIndex = 14;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(180, 27);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 462);
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
            // subHeading
            // 
            this.subHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.subHeading.Location = new System.Drawing.Point(185, 27);
            this.subHeading.Name = "subHeading";
            this.subHeading.Size = new System.Drawing.Size(454, 42);
            this.subHeading.TabIndex = 12;
            // 
            // heading
            // 
            this.heading.BackColor = System.Drawing.SystemColors.ControlLight;
            this.heading.Dock = System.Windows.Forms.DockStyle.Top;
            this.heading.Location = new System.Drawing.Point(5, 0);
            this.heading.Name = "heading";
            this.heading.Size = new System.Drawing.Size(634, 27);
            this.heading.TabIndex = 13;
            // 
            // SubBodyTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.subHeading);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlSideBar);
            this.Controls.Add(this.heading);
            this.Controls.Add(this.splitter2);
            this.Name = "SubBodyTemplate";
            this.Size = new System.Drawing.Size(639, 489);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Splitter splitter1;
        protected internal System.Windows.Forms.Panel pnlBody;
        protected internal System.Windows.Forms.Panel pnlSideBar;
        protected internal System.Windows.Forms.ToolTip toolTip1;
        private HeaderTemplate heading;
        private SubHeaderTemplate subHeading;
        private System.Windows.Forms.Splitter splitter2;
    }
}
