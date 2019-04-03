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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlSidebarBody = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlBody = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnUserManagement = new System.Windows.Forms.Button();
            this.btnKitting = new System.Windows.Forms.Button();
            this.btnPOS = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnGeneral = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnScrollDown = new System.Windows.Forms.Button();
            this.btnScrollUp = new System.Windows.Forms.Button();
            this.pnlSidebar.SuspendLayout();
            this.pnlSidebarBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(74, 553);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(531, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.LightSlateGray;
            this.pnlSidebar.Controls.Add(this.pnlSidebarBody);
            this.pnlSidebar.Controls.Add(this.splitter2);
            this.pnlSidebar.Controls.Add(this.btnScrollDown);
            this.pnlSidebar.Controls.Add(this.splitter1);
            this.pnlSidebar.Controls.Add(this.btnScrollUp);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSidebar.Location = new System.Drawing.Point(2, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(4);
            this.pnlSidebar.Size = new System.Drawing.Size(72, 575);
            this.pnlSidebar.TabIndex = 0;
            // 
            // pnlSidebarBody
            // 
            this.pnlSidebarBody.Controls.Add(this.btnHelp);
            this.pnlSidebarBody.Controls.Add(this.btnSetting);
            this.pnlSidebarBody.Controls.Add(this.btnReport);
            this.pnlSidebarBody.Controls.Add(this.btnUserManagement);
            this.pnlSidebarBody.Controls.Add(this.btnKitting);
            this.pnlSidebarBody.Controls.Add(this.btnPOS);
            this.pnlSidebarBody.Controls.Add(this.btnOrders);
            this.pnlSidebarBody.Controls.Add(this.btnInventory);
            this.pnlSidebarBody.Controls.Add(this.btnGeneral);
            this.pnlSidebarBody.Controls.Add(this.btnDashboard);
            this.pnlSidebarBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSidebarBody.Location = new System.Drawing.Point(4, 23);
            this.pnlSidebarBody.Name = "pnlSidebarBody";
            this.pnlSidebarBody.Size = new System.Drawing.Size(64, 529);
            this.pnlSidebarBody.TabIndex = 0;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Enabled = false;
            this.splitter2.Location = new System.Drawing.Point(4, 552);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(64, 5);
            this.splitter2.TabIndex = 14;
            this.splitter2.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(4, 18);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(64, 5);
            this.splitter1.TabIndex = 13;
            this.splitter1.TabStop = false;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(74, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(531, 553);
            this.pnlBody.TabIndex = 5;
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.SystemColors.Control;
            this.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHelp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHelp.Image = global::IMS.Properties.Resources.icons8_Information_24px;
            this.btnHelp.Location = new System.Drawing.Point(0, 450);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(64, 50);
            this.btnHelp.TabIndex = 8;
            this.btnHelp.Text = "Help";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnHelp, "Settings");
            this.btnHelp.UseVisualStyleBackColor = false;
            // 
            // btnSetting
            // 
            this.btnSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSetting.Image = global::IMS.Properties.Resources.icons8_Gear_24px;
            this.btnSetting.Location = new System.Drawing.Point(0, 400);
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
            this.btnReport.Location = new System.Drawing.Point(0, 350);
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
            this.btnUserManagement.Location = new System.Drawing.Point(0, 300);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Size = new System.Drawing.Size(64, 50);
            this.btnUserManagement.TabIndex = 5;
            this.btnUserManagement.Text = "Users";
            this.btnUserManagement.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUserManagement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnUserManagement, "User Management");
            this.btnUserManagement.UseVisualStyleBackColor = true;
            // 
            // btnKitting
            // 
            this.btnKitting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnKitting.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKitting.Image = global::IMS.Properties.Resources.icons8_Pointer_24px_7;
            this.btnKitting.Location = new System.Drawing.Point(0, 250);
            this.btnKitting.Margin = new System.Windows.Forms.Padding(4);
            this.btnKitting.Name = "btnKitting";
            this.btnKitting.Size = new System.Drawing.Size(64, 50);
            this.btnKitting.TabIndex = 11;
            this.btnKitting.Text = "Kitting";
            this.btnKitting.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnKitting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnKitting, "Point of Sale");
            this.btnKitting.UseVisualStyleBackColor = true;
            // 
            // btnPOS
            // 
            this.btnPOS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPOS.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPOS.Image = global::IMS.Properties.Resources.icons8_Pointer_24px_7;
            this.btnPOS.Location = new System.Drawing.Point(0, 200);
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
            // btnOrders
            // 
            this.btnOrders.AutoSize = true;
            this.btnOrders.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOrders.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrders.Image = global::IMS.Properties.Resources.icons8_In_Transit_24px;
            this.btnOrders.Location = new System.Drawing.Point(0, 150);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(64, 50);
            this.btnOrders.TabIndex = 12;
            this.btnOrders.Text = "Orders";
            this.btnOrders.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOrders.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnOrders, "Inventory");
            this.btnOrders.UseVisualStyleBackColor = true;
            // 
            // btnInventory
            // 
            this.btnInventory.AutoSize = true;
            this.btnInventory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventory.Image = global::IMS.Properties.Resources.icons8_Trolley_24px;
            this.btnInventory.Location = new System.Drawing.Point(0, 100);
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
            this.btnGeneral.Location = new System.Drawing.Point(0, 50);
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
            this.btnDashboard.Location = new System.Drawing.Point(0, 0);
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
            // btnScrollDown
            // 
            this.btnScrollDown.BackColor = System.Drawing.Color.Transparent;
            this.btnScrollDown.BackgroundImage = global::IMS.Properties.Resources.icons8_Double_Down_16px;
            this.btnScrollDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnScrollDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnScrollDown.FlatAppearance.BorderSize = 0;
            this.btnScrollDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnScrollDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnScrollDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScrollDown.Location = new System.Drawing.Point(4, 557);
            this.btnScrollDown.Name = "btnScrollDown";
            this.btnScrollDown.Size = new System.Drawing.Size(64, 14);
            this.btnScrollDown.TabIndex = 14;
            this.btnScrollDown.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnScrollDown, "Scroll Down");
            this.btnScrollDown.UseVisualStyleBackColor = false;
            // 
            // btnScrollUp
            // 
            this.btnScrollUp.BackColor = System.Drawing.Color.Transparent;
            this.btnScrollUp.BackgroundImage = global::IMS.Properties.Resources.icons8_Double_Up_16px;
            this.btnScrollUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnScrollUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnScrollUp.FlatAppearance.BorderSize = 0;
            this.btnScrollUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnScrollUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnScrollUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScrollUp.Location = new System.Drawing.Point(4, 4);
            this.btnScrollUp.Name = "btnScrollUp";
            this.btnScrollUp.Size = new System.Drawing.Size(64, 14);
            this.btnScrollUp.TabIndex = 13;
            this.btnScrollUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnScrollUp, "Scroll Up");
            this.btnScrollUp.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 575);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Text = "IMS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebarBody.ResumeLayout(false);
            this.pnlSidebarBody.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel pnlSidebar;
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
        private System.Windows.Forms.Button btnKitting;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Panel pnlSidebarBody;
        private System.Windows.Forms.Button btnScrollDown;
        private System.Windows.Forms.Button btnScrollUp;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
    }
}

