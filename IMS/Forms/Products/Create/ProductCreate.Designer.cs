namespace IMS.Forms.Create
{
    partial class ProductCreate
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
            this.addProductUC1 = new IMS.Forms.Create.UC.AddProductUC();
            this.SuspendLayout();
            // 
            // addProductUC1
            // 
            this.addProductUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addProductUC1.Location = new System.Drawing.Point(0, 0);
            this.addProductUC1.Margin = new System.Windows.Forms.Padding(2);
            this.addProductUC1.Name = "addProductUC1";
            this.addProductUC1.Padding = new System.Windows.Forms.Padding(2);
            this.addProductUC1.Size = new System.Drawing.Size(588, 420);
            this.addProductUC1.TabIndex = 0;
            // 
            // ProductCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 420);
            this.Controls.Add(this.addProductUC1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProductCreate";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ProductCreate";
            this.ResumeLayout(false);

        }

        #endregion

        private UC.AddProductUC addProductUC1;
    }
}