namespace IMS.Forms.Common.Display
{
    partial class BodyTemplate
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
            this.pnlBody = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlMenuBarBackground = new System.Windows.Forms.Panel();
            this.pnlMenuBar = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHideMenuBar = new System.Windows.Forms.Button();
            this.btnShowMenuBar = new System.Windows.Forms.Button();
            this.lblHeading = new System.Windows.Forms.Label();
            this.pnlMenuBarBackground.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(5, 128);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(620, 366);
            this.pnlBody.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.LightSlateGray;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(5, 126);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(620, 2);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // pnlMenuBarBackground
            // 
            this.pnlMenuBarBackground.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMenuBarBackground.Controls.Add(this.pnlMenuBar);
            this.pnlMenuBarBackground.Controls.Add(this.panel1);
            this.pnlMenuBarBackground.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuBarBackground.Location = new System.Drawing.Point(5, 39);
            this.pnlMenuBarBackground.Name = "pnlMenuBarBackground";
            this.pnlMenuBarBackground.Size = new System.Drawing.Size(620, 87);
            this.pnlMenuBarBackground.TabIndex = 1;
            // 
            // pnlMenuBar
            // 
            this.pnlMenuBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenuBar.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuBar.Name = "pnlMenuBar";
            this.pnlMenuBar.Size = new System.Drawing.Size(598, 87);
            this.pnlMenuBar.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.btnHideMenuBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(598, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(22, 87);
            this.panel1.TabIndex = 0;
            // 
            // btnHideMenuBar
            // 
            this.btnHideMenuBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHideMenuBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHideMenuBar.Image = global::IMS.Properties.Resources.icons8_Double_Up_16px;
            this.btnHideMenuBar.Location = new System.Drawing.Point(0, 0);
            this.btnHideMenuBar.Name = "btnHideMenuBar";
            this.btnHideMenuBar.Size = new System.Drawing.Size(22, 22);
            this.btnHideMenuBar.TabIndex = 0;
            this.btnHideMenuBar.UseVisualStyleBackColor = true;
            this.btnHideMenuBar.Click += new System.EventHandler(this.btnShowHideMenuBar_Click);
            // 
            // btnShowMenuBar
            // 
            this.btnShowMenuBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowMenuBar.BackColor = System.Drawing.SystemColors.Control;
            this.btnShowMenuBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShowMenuBar.Image = global::IMS.Properties.Resources.icons8_Double_Down_16px;
            this.btnShowMenuBar.Location = new System.Drawing.Point(603, 16);
            this.btnShowMenuBar.Name = "btnShowMenuBar";
            this.btnShowMenuBar.Size = new System.Drawing.Size(19, 19);
            this.btnShowMenuBar.TabIndex = 7;
            this.btnShowMenuBar.UseVisualStyleBackColor = false;
            this.btnShowMenuBar.Visible = false;
            this.btnShowMenuBar.Click += new System.EventHandler(this.btnShowHideMenuBar_Click);
            // 
            // lblHeading
            // 
            this.lblHeading.BackColor = System.Drawing.Color.DarkSlateGray;
            this.lblHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeading.Font = new System.Drawing.Font("Myriad Pro Cond", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblHeading.Location = new System.Drawing.Point(5, 5);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(620, 34);
            this.lblHeading.TabIndex = 6;
            this.lblHeading.Text = "Heading";
            this.lblHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BodyTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.btnShowMenuBar);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlMenuBarBackground);
            this.Controls.Add(this.lblHeading);
            this.Name = "BodyTemplate";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(630, 499);
            this.pnlMenuBarBackground.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlMenuBarBackground;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHideMenuBar;
        private System.Windows.Forms.Button btnShowMenuBar;
        protected internal System.Windows.Forms.Panel pnlBody;
        protected internal System.Windows.Forms.Panel pnlMenuBar;
        protected internal System.Windows.Forms.Label lblHeading;
    }
}
