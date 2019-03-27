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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDirectSale = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnPurchaseOrder = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnPurchases = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnBusiness = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(3, 792);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 25, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1490, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.viewToolStripMenuItem1,
            this.toolsToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1490, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.viewToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem1
            // 
            this.viewToolStripMenuItem1.Name = "viewToolStripMenuItem1";
            this.viewToolStripMenuItem1.Size = new System.Drawing.Size(53, 24);
            this.viewToolStripMenuItem1.Text = "View";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDirectSale);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.btnPurchaseOrder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1490, 86);
            this.panel1.TabIndex = 2;
            // 
            // btnDirectSale
            // 
            this.btnDirectSale.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDirectSale.Location = new System.Drawing.Point(125, 0);
            this.btnDirectSale.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnDirectSale.Name = "btnDirectSale";
            this.btnDirectSale.Size = new System.Drawing.Size(161, 86);
            this.btnDirectSale.TabIndex = 3;
            this.btnDirectSale.Text = "Direct Sale";
            this.btnDirectSale.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDirectSale.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitter1.Location = new System.Drawing.Point(121, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 86);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // btnPurchaseOrder
            // 
            this.btnPurchaseOrder.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPurchaseOrder.Location = new System.Drawing.Point(0, 0);
            this.btnPurchaseOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPurchaseOrder.Name = "btnPurchaseOrder";
            this.btnPurchaseOrder.Size = new System.Drawing.Size(121, 86);
            this.btnPurchaseOrder.TabIndex = 1;
            this.btnPurchaseOrder.Text = "Purchase Order";
            this.btnPurchaseOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPurchaseOrder.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this.btnSetting);
            this.panel2.Controls.Add(this.btnPurchases);
            this.panel2.Controls.Add(this.btnSales);
            this.panel2.Controls.Add(this.btnUser);
            this.panel2.Controls.Add(this.btnBusiness);
            this.panel2.Controls.Add(this.btnCustomer);
            this.panel2.Controls.Add(this.btnSupplier);
            this.panel2.Controls.Add(this.btnProducts);
            this.panel2.Controls.Add(this.btnHome);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(3, 119);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel2.Size = new System.Drawing.Size(112, 673);
            this.panel2.TabIndex = 0;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(115, 119);
            this.splitter2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(5, 673);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(3, 114);
            this.splitter3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(1490, 5);
            this.splitter3.TabIndex = 4;
            this.splitter3.TabStop = false;
            // 
            // pnlBody
            // 
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(120, 119);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1373, 673);
            this.pnlBody.TabIndex = 5;
            // 
            // btnSetting
            // 
            this.btnSetting.BackgroundImage = global::IMS.Properties.Resources.icons8_Settings_50px;
            this.btnSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSetting.Location = new System.Drawing.Point(5, 622);
            this.btnSetting.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(102, 75);
            this.btnSetting.TabIndex = 7;
            this.btnSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnSetting, "Settings");
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnPurchases
            // 
            this.btnPurchases.BackgroundImage = global::IMS.Properties.Resources.icons8_Buy_48px;
            this.btnPurchases.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPurchases.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPurchases.Location = new System.Drawing.Point(5, 547);
            this.btnPurchases.Margin = new System.Windows.Forms.Padding(4);
            this.btnPurchases.Name = "btnPurchases";
            this.btnPurchases.Size = new System.Drawing.Size(102, 75);
            this.btnPurchases.TabIndex = 6;
            this.btnPurchases.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnPurchases, "Purchases");
            this.btnPurchases.UseVisualStyleBackColor = true;
            this.btnPurchases.Click += new System.EventHandler(this.btnPurchases_Click);
            // 
            // btnSales
            // 
            this.btnSales.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSales.BackgroundImage")));
            this.btnSales.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSales.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSales.Location = new System.Drawing.Point(5, 455);
            this.btnSales.Margin = new System.Windows.Forms.Padding(5);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(102, 92);
            this.btnSales.TabIndex = 6;
            this.btnSales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnSales, "User");
            this.btnSales.UseVisualStyleBackColor = true;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // btnUser
            // 
            this.btnUser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUser.BackgroundImage")));
            this.btnUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUser.Location = new System.Drawing.Point(5, 380);
            this.btnUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(102, 75);
            this.btnUser.TabIndex = 5;
            this.btnUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnUser, "User");
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnBusiness
            // 
            this.btnBusiness.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusiness.BackgroundImage")));
            this.btnBusiness.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusiness.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBusiness.Location = new System.Drawing.Point(5, 305);
            this.btnBusiness.Margin = new System.Windows.Forms.Padding(4);
            this.btnBusiness.Name = "btnBusiness";
            this.btnBusiness.Size = new System.Drawing.Size(102, 75);
            this.btnBusiness.TabIndex = 4;
            this.btnBusiness.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnBusiness, "Business");
            this.btnBusiness.UseVisualStyleBackColor = true;
            this.btnBusiness.Click += new System.EventHandler(this.btnBusiness_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackgroundImage = global::IMS.Properties.Resources.icons8_User_50px;
            this.btnCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomer.Location = new System.Drawing.Point(5, 230);
            this.btnCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(102, 75);
            this.btnCustomer.TabIndex = 3;
            this.btnCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnCustomer, "Customer");
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSupplier.BackgroundImage")));
            this.btnSupplier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSupplier.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSupplier.Location = new System.Drawing.Point(5, 155);
            this.btnSupplier.Margin = new System.Windows.Forms.Padding(4);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(102, 75);
            this.btnSupplier.TabIndex = 2;
            this.btnSupplier.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnSupplier, "Supplier");
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.AutoSize = true;
            this.btnProducts.BackgroundImage = global::IMS.Properties.Resources.icons8_Commodity_50px;
            this.btnProducts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProducts.Location = new System.Drawing.Point(5, 80);
            this.btnProducts.Margin = new System.Windows.Forms.Padding(4);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(102, 75);
            this.btnProducts.TabIndex = 0;
            this.btnProducts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnProducts, "Inventory");
            this.btnProducts.UseVisualStyleBackColor = true;
            // 
            // btnHome
            // 
            this.btnHome.BackgroundImage = global::IMS.Properties.Resources.icons8_Home_40px;
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.Location = new System.Drawing.Point(5, 5);
            this.btnHome.Margin = new System.Windows.Forms.Padding(4);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(102, 75);
            this.btnHome.TabIndex = 1;
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnHome, "Home");
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1496, 814);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btnPurchaseOrder;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnBusiness;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnDirectSale;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Button btnPurchases;
        private System.Windows.Forms.Button btnSetting;
    }
}

