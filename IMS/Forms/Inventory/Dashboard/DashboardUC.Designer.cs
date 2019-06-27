namespace IMS.Forms.Inventory.Dashboard
{
    partial class DashboardUC
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
            this.pnlTopUnderstockProducts = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTopUnderstockProducts = new System.Windows.Forms.Label();
            this.lbUnderStockProducts = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTopUnderstockProducts.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopUnderstockProducts
            // 
            this.pnlTopUnderstockProducts.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlTopUnderstockProducts.Controls.Add(this.lbUnderStockProducts);
            this.pnlTopUnderstockProducts.Controls.Add(this.lblTopUnderstockProducts);
            this.pnlTopUnderstockProducts.Location = new System.Drawing.Point(3, 3);
            this.pnlTopUnderstockProducts.Name = "pnlTopUnderstockProducts";
            this.pnlTopUnderstockProducts.Padding = new System.Windows.Forms.Padding(5);
            this.pnlTopUnderstockProducts.Size = new System.Drawing.Size(204, 159);
            this.pnlTopUnderstockProducts.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pnlTopUnderstockProducts);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(696, 383);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // lblTopUnderstockProducts
            // 
            this.lblTopUnderstockProducts.BackColor = System.Drawing.SystemColors.Control;
            this.lblTopUnderstockProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTopUnderstockProducts.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopUnderstockProducts.Location = new System.Drawing.Point(5, 5);
            this.lblTopUnderstockProducts.Name = "lblTopUnderstockProducts";
            this.lblTopUnderstockProducts.Size = new System.Drawing.Size(194, 23);
            this.lblTopUnderstockProducts.TabIndex = 0;
            this.lblTopUnderstockProducts.Text = "Top Understock Products";
            this.lblTopUnderstockProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbUnderStockProducts
            // 
            this.lbUnderStockProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbUnderStockProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbUnderStockProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUnderStockProducts.FormattingEnabled = true;
            this.lbUnderStockProducts.ItemHeight = 15;
            this.lbUnderStockProducts.Location = new System.Drawing.Point(5, 28);
            this.lbUnderStockProducts.Name = "lbUnderStockProducts";
            this.lbUnderStockProducts.Size = new System.Drawing.Size(194, 126);
            this.lbUnderStockProducts.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(213, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(204, 159);
            this.panel1.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(5, 28);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(194, 126);
            this.listBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Expired Inventory";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DashboardUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "DashboardUC";
            this.Size = new System.Drawing.Size(696, 383);
            this.pnlTopUnderstockProducts.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopUnderstockProducts;
        private System.Windows.Forms.ListBox lbUnderStockProducts;
        private System.Windows.Forms.Label lblTopUnderstockProducts;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
    }
}
