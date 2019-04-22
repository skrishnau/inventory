namespace IMS.Forms.Business
{
    partial class BusinessUC
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gvBranch = new System.Windows.Forms.DataGridView();
            this.colbranchName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddBrand = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gvCounter = new System.Windows.Forms.DataGridView();
            this.CounterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BranchId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutOfOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddCounter = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gvWarehouse = new System.Windows.Forms.DataGridView();
            this.Branch_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CanMoveStocksToBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAddWarehouse = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDeleteBranch = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvBranch)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCounter)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvWarehouse)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(761, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Business";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 46);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(761, 723);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gvBranch);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(753, 690);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Branch";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gvBranch
            // 
            this.gvBranch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvBranch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colbranchName});
            this.gvBranch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvBranch.Location = new System.Drawing.Point(3, 62);
            this.gvBranch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gvBranch.Name = "gvBranch";
            this.gvBranch.RowTemplate.Height = 24;
            this.gvBranch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvBranch.Size = new System.Drawing.Size(747, 626);
            this.gvBranch.TabIndex = 1;
            // 
            // colbranchName
            // 
            this.colbranchName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colbranchName.DataPropertyName = "Name";
            this.colbranchName.HeaderText = "BranchName";
            this.colbranchName.Name = "colbranchName";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDeleteBranch);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnAddBrand);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 60);
            this.panel1.TabIndex = 0;
            // 
            // btnAddBrand
            // 
            this.btnAddBrand.BackgroundImage = global::IMS.Properties.Resources.icons8_Plus_Math_16px;
            this.btnAddBrand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddBrand.Location = new System.Drawing.Point(141, 16);
            this.btnAddBrand.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddBrand.Name = "btnAddBrand";
            this.btnAddBrand.Size = new System.Drawing.Size(28, 28);
            this.btnAddBrand.TabIndex = 2;
            this.btnAddBrand.UseVisualStyleBackColor = true;
            this.btnAddBrand.Click += new System.EventHandler(this.btnAddBrand_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 60);
            this.label2.TabIndex = 0;
            this.label2.Text = "Branch";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gvCounter);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(753, 691);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Counter";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gvCounter
            // 
            this.gvCounter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCounter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CounterName,
            this.BranchId,
            this.OutOfOrder});
            this.gvCounter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvCounter.Location = new System.Drawing.Point(3, 62);
            this.gvCounter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gvCounter.Name = "gvCounter";
            this.gvCounter.RowTemplate.Height = 24;
            this.gvCounter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCounter.Size = new System.Drawing.Size(747, 627);
            this.gvCounter.TabIndex = 3;
            // 
            // CounterName
            // 
            this.CounterName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CounterName.DataPropertyName = "Name";
            this.CounterName.HeaderText = "Name";
            this.CounterName.Name = "CounterName";
            // 
            // BranchId
            // 
            this.BranchId.DataPropertyName = "BranchId";
            this.BranchId.HeaderText = "Branch";
            this.BranchId.Name = "BranchId";
            // 
            // OutOfOrder
            // 
            this.OutOfOrder.DataPropertyName = "OutOfOrder";
            this.OutOfOrder.HeaderText = "Out Of Order";
            this.OutOfOrder.Name = "OutOfOrder";
            this.OutOfOrder.Width = 150;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAddCounter);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(747, 60);
            this.panel2.TabIndex = 2;
            // 
            // btnAddCounter
            // 
            this.btnAddCounter.BackgroundImage = global::IMS.Properties.Resources.icons8_Plus_Math_16px;
            this.btnAddCounter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddCounter.Location = new System.Drawing.Point(141, 16);
            this.btnAddCounter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddCounter.Name = "btnAddCounter";
            this.btnAddCounter.Size = new System.Drawing.Size(28, 28);
            this.btnAddCounter.TabIndex = 2;
            this.btnAddCounter.UseVisualStyleBackColor = true;
            this.btnAddCounter.Click += new System.EventHandler(this.btnAddCounter_Click);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 60);
            this.label3.TabIndex = 0;
            this.label3.Text = "Counter";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.gvWarehouse);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(753, 691);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Warehouse";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gvWarehouse
            // 
            this.gvWarehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvWarehouse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Branch_ID,
            this.Code,
            this.CanMoveStocksToBranch});
            this.gvWarehouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvWarehouse.Location = new System.Drawing.Point(0, 60);
            this.gvWarehouse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gvWarehouse.Name = "gvWarehouse";
            this.gvWarehouse.RowTemplate.Height = 24;
            this.gvWarehouse.Size = new System.Drawing.Size(753, 631);
            this.gvWarehouse.TabIndex = 3;
            // 
            // Branch_ID
            // 
            this.Branch_ID.DataPropertyName = "BranchId";
            this.Branch_ID.HeaderText = "BranchId";
            this.Branch_ID.Name = "Branch_ID";
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            // 
            // CanMoveStocksToBranch
            // 
            this.CanMoveStocksToBranch.DataPropertyName = "CanMoveStocksToBranch";
            this.CanMoveStocksToBranch.HeaderText = "CanMoveStocksToBranch";
            this.CanMoveStocksToBranch.Name = "CanMoveStocksToBranch";
            this.CanMoveStocksToBranch.Width = 150;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAddWarehouse);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(753, 60);
            this.panel3.TabIndex = 2;
            // 
            // btnAddWarehouse
            // 
            this.btnAddWarehouse.BackgroundImage = global::IMS.Properties.Resources.icons8_Plus_Math_16px;
            this.btnAddWarehouse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddWarehouse.Location = new System.Drawing.Point(141, 16);
            this.btnAddWarehouse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddWarehouse.Name = "btnAddWarehouse";
            this.btnAddWarehouse.Size = new System.Drawing.Size(28, 28);
            this.btnAddWarehouse.TabIndex = 2;
            this.btnAddWarehouse.UseVisualStyleBackColor = true;
            this.btnAddWarehouse.Click += new System.EventHandler(this.btnAddWarehouse_Click);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 60);
            this.label4.TabIndex = 0;
            this.label4.Text = "Warehouse";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(198, 19);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDeleteBranch
            // 
            this.btnDeleteBranch.Location = new System.Drawing.Point(300, 19);
            this.btnDeleteBranch.Name = "btnDeleteBranch";
            this.btnDeleteBranch.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteBranch.TabIndex = 4;
            this.btnDeleteBranch.Text = "Delete";
            this.btnDeleteBranch.UseVisualStyleBackColor = true;
           // this.btnDeleteBranch.Click += new System.EventHandler(this.btnDeleteBranch_Click);
            // 
            // BusinessUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "BusinessUC";
            this.Size = new System.Drawing.Size(761, 769);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvBranch)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvCounter)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvWarehouse)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddBrand;
        private System.Windows.Forms.DataGridView gvBranch;
        private System.Windows.Forms.DataGridView gvCounter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddCounter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gvWarehouse;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAddWarehouse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn CounterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutOfOrder;
        //private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn Branch_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn CanMoveStocksToBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colbranchName;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDeleteBranch;
    }
}
