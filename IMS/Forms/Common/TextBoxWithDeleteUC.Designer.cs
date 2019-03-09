namespace IMS.Forms.Common
{
    partial class TextBoxWithDeleteUC
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.cbInput = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = global::IMS.Properties.Resources.icons8_Delete_16px;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.Location = new System.Drawing.Point(179, 6);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(33, 29);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(172, 6);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(7, 29);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // cbInput
            // 
            this.cbInput.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbInput.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbInput.FormattingEnabled = true;
            this.cbInput.Location = new System.Drawing.Point(7, 6);
            this.cbInput.Margin = new System.Windows.Forms.Padding(4);
            this.cbInput.Name = "cbInput";
            this.cbInput.Size = new System.Drawing.Size(165, 24);
            this.cbInput.TabIndex = 3;
            // 
            // TextBoxWithDeleteUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cbInput);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.btnDelete);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TextBoxWithDeleteUC";
            this.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Size = new System.Drawing.Size(219, 41);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ComboBox cbInput;
        public System.Windows.Forms.Button btnDelete;
    }
}
