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
            this.gbBranch = new System.Windows.Forms.GroupBox();
            this.btnBranchList = new System.Windows.Forms.Button();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.gbBranch.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBranch
            // 
            this.gbBranch.Controls.Add(this.btnBranchList);
            this.gbBranch.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbBranch.Location = new System.Drawing.Point(0, 0);
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
            this.splitter2.Location = new System.Drawing.Point(76, 0);
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
            this.Name = "GeneralMenuBar";
            this.Size = new System.Drawing.Size(798, 84);
            this.gbBranch.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbBranch;
        protected internal System.Windows.Forms.Button btnBranchList;
        private System.Windows.Forms.Splitter splitter2;
    }
}
