namespace IMS.Forms.Inventory.Products
{
    partial class ProductUomUC
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbPackage = new System.Windows.Forms.ComboBox();
            this.cbRelatedPackage = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.NumericUpDown();
            this.pnlRelatedPackage = new System.Windows.Forms.Panel();
            this.btnDelete = new IMS.Forms.Common.Buttons.MenuButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            this.pnlRelatedPackage.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Package     1";
            // 
            // cbPackage
            // 
            this.cbPackage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPackage.FormattingEnabled = true;
            this.cbPackage.Location = new System.Drawing.Point(75, 2);
            this.cbPackage.Name = "cbPackage";
            this.cbPackage.Size = new System.Drawing.Size(121, 21);
            this.cbPackage.TabIndex = 1;
            // 
            // cbRelatedPackage
            // 
            this.cbRelatedPackage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRelatedPackage.FormattingEnabled = true;
            this.cbRelatedPackage.Location = new System.Drawing.Point(200, 3);
            this.cbRelatedPackage.Name = "cbRelatedPackage";
            this.cbRelatedPackage.Size = new System.Drawing.Size(121, 21);
            this.cbRelatedPackage.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contains";
            // 
            // txtQuantity
            // 
            this.txtQuantity.DecimalPlaces = 3;
            this.txtQuantity.Location = new System.Drawing.Point(57, 3);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(120, 20);
            this.txtQuantity.TabIndex = 4;
            // 
            // pnlRelatedPackage
            // 
            this.pnlRelatedPackage.Controls.Add(this.label2);
            this.pnlRelatedPackage.Controls.Add(this.cbRelatedPackage);
            this.pnlRelatedPackage.Controls.Add(this.txtQuantity);
            this.pnlRelatedPackage.Location = new System.Drawing.Point(211, 0);
            this.pnlRelatedPackage.Name = "pnlRelatedPackage";
            this.pnlRelatedPackage.Size = new System.Drawing.Size(340, 27);
            this.pnlRelatedPackage.TabIndex = 5;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = global::IMS.Properties.Resources.icons8_Delete_16px;
            this.btnDelete.Location = new System.Drawing.Point(550, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(19, 19);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // ProductUomUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.pnlRelatedPackage);
            this.Controls.Add(this.cbPackage);
            this.Controls.Add(this.label1);
            this.Name = "ProductUomUC";
            this.Size = new System.Drawing.Size(575, 27);
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            this.pnlRelatedPackage.ResumeLayout(false);
            this.pnlRelatedPackage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPackage;
        private System.Windows.Forms.ComboBox cbRelatedPackage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtQuantity;
        private System.Windows.Forms.Panel pnlRelatedPackage;
        private Common.Buttons.MenuButton btnDelete;
    }
}
