namespace IMS.Forms.Inventory.Lists.Category
{
    partial class CategoryEditControlPanel
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCreateSubCategory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = global::IMS.Properties.Resources.icons8_Delete_Bin_16px;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDelete.Location = new System.Drawing.Point(62, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(30, 22);
            this.btnDelete.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnDelete, "Delete");
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.BackgroundImage = global::IMS.Properties.Resources.icons8_Edit_16px;
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEdit.Location = new System.Drawing.Point(30, 0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(32, 22);
            this.btnEdit.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btnEdit, "Edit");
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnCreateSubCategory
            // 
            this.btnCreateSubCategory.BackgroundImage = global::IMS.Properties.Resources.icons8_Add_Row_16px;
            this.btnCreateSubCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCreateSubCategory.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCreateSubCategory.Location = new System.Drawing.Point(0, 0);
            this.btnCreateSubCategory.Name = "btnCreateSubCategory";
            this.btnCreateSubCategory.Size = new System.Drawing.Size(30, 22);
            this.btnCreateSubCategory.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnCreateSubCategory, "Add Sub-category");
            this.btnCreateSubCategory.UseVisualStyleBackColor = true;
            // 
            // CategoryEditControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCreateSubCategory);
            this.Name = "CategoryEditControlPanel";
            this.Size = new System.Drawing.Size(94, 22);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCreateSubCategory;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
