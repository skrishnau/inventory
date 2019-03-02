namespace IMS.Forms.Inventory
{
    partial class AddAttributeValueUC
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
            this.tbAddAttributeValue = new System.Windows.Forms.TextBox();
            this.btnCancelAttributeValue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbAddAttributeValue
            // 
            this.tbAddAttributeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAddAttributeValue.Location = new System.Drawing.Point(0, 0);
            this.tbAddAttributeValue.Name = "tbAddAttributeValue";
            this.tbAddAttributeValue.Size = new System.Drawing.Size(142, 22);
            this.tbAddAttributeValue.TabIndex = 0;
            this.tbAddAttributeValue.TextChanged += new System.EventHandler(this.tbAddAttributeValue_TextChanged);
            // 
            // btnCancelAttributeValue
            // 
            this.btnCancelAttributeValue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelAttributeValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancelAttributeValue.Image = global::IMS.Properties.Resources.icons8_Close_Window_50px_1;
            this.btnCancelAttributeValue.Location = new System.Drawing.Point(142, 0);
            this.btnCancelAttributeValue.Name = "btnCancelAttributeValue";
            this.btnCancelAttributeValue.Size = new System.Drawing.Size(23, 22);
            this.btnCancelAttributeValue.TabIndex = 1;
            this.btnCancelAttributeValue.UseVisualStyleBackColor = true;
            this.btnCancelAttributeValue.Click += new System.EventHandler(this.btnCancelAttributeValue_Click);
            // 
            // AddAttributeValueUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbAddAttributeValue);
            this.Controls.Add(this.btnCancelAttributeValue);
            this.Name = "AddAttributeValueUC";
            this.Size = new System.Drawing.Size(165, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbAddAttributeValue;
        private System.Windows.Forms.Button btnCancelAttributeValue;
    }
}
