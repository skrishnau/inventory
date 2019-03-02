namespace IMS.Forms.Inventory.Attributes
{
    partial class OptionViewUC
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
            this.lblOption = new System.Windows.Forms.Label();
            this.lblValues = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblOption
            // 
            this.lblOption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOption.Location = new System.Drawing.Point(3, 3);
            this.lblOption.Name = "lblOption";
            this.lblOption.Size = new System.Drawing.Size(142, 23);
            this.lblOption.TabIndex = 0;
            this.lblOption.Text = "label1";
            this.lblOption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValues
            // 
            this.lblValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblValues.Location = new System.Drawing.Point(3, 26);
            this.lblValues.Name = "lblValues";
            this.lblValues.Size = new System.Drawing.Size(142, 32);
            this.lblValues.TabIndex = 1;
            this.lblValues.Text = "Option Values here...";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.BackgroundImage = global::IMS.Properties.Resources.icons8_Delete_16px;
            this.btnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRemove.Location = new System.Drawing.Point(123, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(22, 21);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // OptionViewUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lblValues);
            this.Controls.Add(this.lblOption);
            this.Name = "OptionViewUC";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(148, 61);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblOption;
        private System.Windows.Forms.Label lblValues;
        internal System.Windows.Forms.Button btnRemove;
    }
}
