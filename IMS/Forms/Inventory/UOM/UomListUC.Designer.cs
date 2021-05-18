namespace IMS.Forms.Inventory.UOM
{
    partial class UomListUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UomListUC));
            this.dgvUom = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbFrom = new System.Windows.Forms.ComboBox();
            this.cbTo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBaseUnitId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBaseUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtValue = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUom)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUom
            // 
            this.dgvUom.AllowUserToDeleteRows = false;
            this.dgvUom.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvUom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colUnit,
            this.colQuantity,
            this.colBaseUnitId,
            this.colBaseUnit,
            this.colUse});
            this.dgvUom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUom.Location = new System.Drawing.Point(0, 52);
            this.dgvUom.Name = "dgvUom";
            this.dgvUom.ReadOnly = true;
            this.dgvUom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUom.Size = new System.Drawing.Size(753, 258);
            this.dgvUom.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(753, 52);
            this.panel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnNew);
            this.flowLayoutPanel1.Controls.Add(this.btnEdit);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(609, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(144, 52);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // btnNew
            // 
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Image = global::IMS.Properties.Resources.icons8_Plus_Math_16px;
            this.btnNew.Location = new System.Drawing.Point(93, 6);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(42, 40);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(45, 6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(42, 40);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtValue);
            this.panel2.Controls.Add(this.btnConvert);
            this.panel2.Controls.Add(this.txtResult);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cbTo);
            this.panel2.Controls.Add(this.cbFrom);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 310);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(753, 52);
            this.panel2.TabIndex = 3;
            // 
            // cbFrom
            // 
            this.cbFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFrom.FormattingEnabled = true;
            this.cbFrom.Location = new System.Drawing.Point(141, 4);
            this.cbFrom.Name = "cbFrom";
            this.cbFrom.Size = new System.Drawing.Size(121, 21);
            this.cbFrom.TabIndex = 0;
            // 
            // cbTo
            // 
            this.cbTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTo.FormattingEnabled = true;
            this.cbTo.Location = new System.Drawing.Point(301, 4);
            this.cbTo.Name = "cbTo";
            this.cbTo.Size = new System.Drawing.Size(121, 21);
            this.cbTo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(533, 5);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(194, 20);
            this.txtResult.TabIndex = 4;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(450, 3);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 5;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colUnit
            // 
            this.colUnit.DataPropertyName = "Package";
            this.colUnit.HeaderText = "Unit Of Measure";
            this.colUnit.Name = "colUnit";
            this.colUnit.ReadOnly = true;
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "Quantity";
            this.colQuantity.HeaderText = "Contains";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            this.colQuantity.Width = 200;
            // 
            // colBaseUnitId
            // 
            this.colBaseUnitId.DataPropertyName = "RelatedPackageId";
            this.colBaseUnitId.HeaderText = "BaseUnitId";
            this.colBaseUnitId.Name = "colBaseUnitId";
            this.colBaseUnitId.ReadOnly = true;
            this.colBaseUnitId.Visible = false;
            // 
            // colBaseUnit
            // 
            this.colBaseUnit.DataPropertyName = "RelatedPackage";
            this.colBaseUnit.HeaderText = "Of Base Unit";
            this.colBaseUnit.Name = "colBaseUnit";
            this.colBaseUnit.ReadOnly = true;
            // 
            // colUse
            // 
            this.colUse.DataPropertyName = "Use";
            this.colUse.HeaderText = "Use";
            this.colUse.Name = "colUse";
            this.colUse.ReadOnly = true;
            this.colUse.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colUse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // txtValue
            // 
            this.txtValue.DecimalPlaces = 3;
            this.txtValue.Location = new System.Drawing.Point(142, 28);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(120, 20);
            this.txtValue.TabIndex = 6;
            this.txtValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Convert UOM";
            // 
            // UomUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvUom);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "UomUC";
            this.Size = new System.Drawing.Size(753, 362);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUom)).EndInit();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        protected internal System.Windows.Forms.Button btnNew;
        protected internal System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTo;
        private System.Windows.Forms.ComboBox cbFrom;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBaseUnitId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBaseUnit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUse;
        private System.Windows.Forms.NumericUpDown txtValue;
        private System.Windows.Forms.Label label3;
    }
}
