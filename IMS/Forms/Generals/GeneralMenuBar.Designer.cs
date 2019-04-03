namespace IMS.Forms.Generals
{
    partial class GeneralMenuBar
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
            this.gbProduct = new System.Windows.Forms.GroupBox();
            this.btnCategoryList = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnProductList = new System.Windows.Forms.Button();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.gbBranch = new System.Windows.Forms.GroupBox();
            this.btnBranchList = new System.Windows.Forms.Button();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.gbProduct.SuspendLayout();
            this.gbBranch.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbProduct
            // 
            this.gbProduct.Controls.Add(this.btnCategoryList);
            this.gbProduct.Controls.Add(this.splitter1);
            this.gbProduct.Controls.Add(this.btnProductList);
            this.gbProduct.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbProduct.Location = new System.Drawing.Point(0, 0);
            this.gbProduct.Name = "gbProduct";
            this.gbProduct.Size = new System.Drawing.Size(145, 84);
            this.gbProduct.TabIndex = 12;
            this.gbProduct.TabStop = false;
            this.gbProduct.Text = "Product";
            // 
            // btnCategoryList
            // 
            this.btnCategoryList.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCategoryList.Image = global::IMS.Properties.Resources.icons8_Categorize_16px;
            this.btnCategoryList.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCategoryList.Location = new System.Drawing.Point(77, 16);
            this.btnCategoryList.Name = "btnCategoryList";
            this.btnCategoryList.Size = new System.Drawing.Size(65, 65);
            this.btnCategoryList.TabIndex = 17;
            this.btnCategoryList.Text = "Categories";
            this.btnCategoryList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCategoryList.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(69, 16);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 65);
            this.splitter1.TabIndex = 12;
            this.splitter1.TabStop = false;
            // 
            // btnProductList
            // 
            this.btnProductList.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnProductList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnProductList.Image = global::IMS.Properties.Resources.icons8_Product_24px;
            this.btnProductList.Location = new System.Drawing.Point(3, 16);
            this.btnProductList.Name = "btnProductList";
            this.btnProductList.Size = new System.Drawing.Size(66, 65);
            this.btnProductList.TabIndex = 15;
            this.btnProductList.Text = "Products";
            this.btnProductList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnProductList.UseVisualStyleBackColor = true;
            // 
            // splitter4
            // 
            this.splitter4.Location = new System.Drawing.Point(145, 0);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(8, 84);
            this.splitter4.TabIndex = 17;
            this.splitter4.TabStop = false;
            // 
            // gbBranch
            // 
            this.gbBranch.Controls.Add(this.btnBranchList);
            this.gbBranch.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbBranch.Location = new System.Drawing.Point(153, 0);
            this.gbBranch.Name = "gbBranch";
            this.gbBranch.Size = new System.Drawing.Size(76, 84);
            this.gbBranch.TabIndex = 28;
            this.gbBranch.TabStop = false;
            this.gbBranch.Text = "Branch";
            // 
            // btnBranchList
            // 
            this.btnBranchList.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBranchList.Image = global::IMS.Properties.Resources.icons8_Cactus_24px;
            this.btnBranchList.Location = new System.Drawing.Point(3, 16);
            this.btnBranchList.Name = "btnBranchList";
            this.btnBranchList.Size = new System.Drawing.Size(71, 65);
            this.btnBranchList.TabIndex = 0;
            this.btnBranchList.Text = "Branches";
            this.btnBranchList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBranchList.UseVisualStyleBackColor = true;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(229, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(8, 84);
            this.splitter2.TabIndex = 29;
            this.splitter2.TabStop = false;
            // 
            // GeneralMenuBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.gbBranch);
            this.Controls.Add(this.splitter4);
            this.Controls.Add(this.gbProduct);
            this.Name = "GeneralMenuBar";
            this.Size = new System.Drawing.Size(798, 84);
            this.gbProduct.ResumeLayout(false);
            this.gbBranch.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbProduct;
        private System.Windows.Forms.Splitter splitter1;
        protected internal System.Windows.Forms.Button btnProductList;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.GroupBox gbBranch;
        protected internal System.Windows.Forms.Button btnBranchList;
        private System.Windows.Forms.Splitter splitter2;
        protected internal System.Windows.Forms.Button btnCategoryList;
    }
}
