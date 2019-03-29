namespace IMS
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnUserManagement = new System.Windows.Forms.Button();
            this.btnPOS = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnGeneral = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlBody = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(74, 416);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(531, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel2.Controls.Add(this.btnHelp);
            this.panel2.Controls.Add(this.btnSetting);
            this.panel2.Controls.Add(this.btnReport);
            this.panel2.Controls.Add(this.btnUserManagement);
            this.panel2.Controls.Add(this.btnPOS);
            this.panel2.Controls.Add(this.btnInventory);
            this.panel2.Controls.Add(this.btnGeneral);
            this.panel2.Controls.Add(this.btnDashboard);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(2, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4);
            this.panel2.Size = new System.Drawing.Size(72, 438);
            this.panel2.TabIndex = 0;
            // 
            // btnHelp
            // 
            this.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHelp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHelp.Image = global::IMS.Properties.Resources.icons8_Information_24px;
            this.btnHelp.Location = new System.Drawing.Point(4, 354);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(64, 50);
            this.btnHelp.TabIndex = 8;
            this.btnHelp.Text = "Help";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnHelp, "Settings");
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // btnSetting
            // 
            this.btnSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSetting.Image = global::IMS.Properties.Resources.icons8_Gear_24px;
            this.btnSetting.Location = new System.Drawing.Point(4, 304);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(64, 50);
            this.btnSetting.TabIndex = 7;
            this.btnSetting.Text = "Settings";
            this.btnSetting.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnSetting, "Settings");
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReport.Image = global::IMS.Properties.Resources.icons8_Pie_Chart_24px;
            this.btnReport.Location = new System.Drawing.Point(4, 254);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(64, 50);
            this.btnReport.TabIndex = 9;
            this.btnReport.Text = "Reports";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnReport, "User");
            this.btnReport.UseVisualStyleBackColor = true;
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUserManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUserManagement.Image = global::IMS.Properties.Resources.icons8_User_Account_24px;
            this.btnUserManagement.Location = new System.Drawing.Point(4, 204);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Size = new System.Drawing.Size(64, 50);
            this.btnUserManagement.TabIndex = 5;
            this.btnUserManagement.Text = "Users";
            this.btnUserManagement.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUserManagement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnUserManagement, "User Management");
            this.btnUserManagement.UseVisualStyleBackColor = true;
            // 
            // btnPOS
            // 
            this.btnPOS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPOS.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPOS.Image = global::IMS.Properties.Resources.icons8_Pointer_24px_7;
            this.btnPOS.Location = new System.Drawing.Point(4, 154);
            this.btnPOS.Margin = new System.Windows.Forms.Padding(4);
            this.btnPOS.Name = "btnPOS";
            this.btnPOS.Size = new System.Drawing.Size(64, 50);
            this.btnPOS.TabIndex = 6;
            this.btnPOS.Text = "POS";
            this.btnPOS.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPOS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnPOS, "Point of Sale");
            this.btnPOS.UseVisualStyleBackColor = true;
            this.btnPOS.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.AutoSize = true;
            this.btnInventory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventory.Image = global::IMS.Properties.Resources.icons8_Trolley_24px;
            this.btnInventory.Location = new System.Drawing.Point(4, 104);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(64, 50);
            this.btnInventory.TabIndex = 0;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnInventory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnInventory, "Inventory");
            this.btnInventory.UseVisualStyleBackColor = true;
            // 
            // btnGeneral
            // 
            this.btnGeneral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGeneral.Image = global::IMS.Properties.Resources.icons8_Home_Automation_24px;
            this.btnGeneral.Location = new System.Drawing.Point(4, 54);
            this.btnGeneral.Name = "btnGeneral";
            this.btnGeneral.Size = new System.Drawing.Size(64, 50);
            this.btnGeneral.TabIndex = 10;
            this.btnGeneral.Text = "General";
            this.btnGeneral.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGeneral.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnGeneral, "Settings");
            this.btnGeneral.UseVisualStyleBackColor = true;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.Image = global::IMS.Properties.Resources.icons8_Speed_24px;
            this.btnDashboard.Location = new System.Drawing.Point(4, 4);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(64, 50);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnDashboard, "Dashboard");
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(74, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(531, 416);
            this.pnlBody.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 438);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Text = "IMS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnUserManagement;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnPOS;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnGeneral;
    }
}

