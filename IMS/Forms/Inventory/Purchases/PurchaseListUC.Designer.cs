namespace IMS.Forms.Purchases
{
    partial class PurchaseListUC
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
            this.dgvPurchases = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLotNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWarehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlOrderLinkLint = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lnkPurchaseOrderList = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblPurchaseOrderHeaderText = new System.Windows.Forms.Label();
            this.pnlDataBody = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchases)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlDataBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPurchases
            // 
            this.dgvPurchases.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPurchases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchases.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colOrderName,
            this.colOrderNumber,
            this.colLotNo,
            this.colWarehouse,
            this.colSupplier,
            this.colTotalAmount,
            this.colStatus});
            this.dgvPurchases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPurchases.Location = new System.Drawing.Point(0, 26);
            this.dgvPurchases.MultiSelect = false;
            this.dgvPurchases.Name = "dgvPurchases";
            this.dgvPurchases.ReadOnly = true;
            this.dgvPurchases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchases.Size = new System.Drawing.Size(462, 330);
            this.dgvPurchases.TabIndex = 1;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colOrderName
            // 
            this.colOrderName.DataPropertyName = "Name";
            this.colOrderName.HeaderText = "Name";
            this.colOrderName.Name = "colOrderName";
            this.colOrderName.ReadOnly = true;
            this.colOrderName.Width = 150;
            // 
            // colOrderNumber
            // 
            this.colOrderNumber.DataPropertyName = "OrderNumber";
            this.colOrderNumber.HeaderText = "Order No.";
            this.colOrderNumber.Name = "colOrderNumber";
            this.colOrderNumber.ReadOnly = true;
            this.colOrderNumber.Width = 120;
            // 
            // colLotNo
            // 
            this.colLotNo.DataPropertyName = "LotNumber";
            this.colLotNo.HeaderText = "Lot#";
            this.colLotNo.Name = "colLotNo";
            this.colLotNo.ReadOnly = true;
            // 
            // colWarehouse
            // 
            this.colWarehouse.DataPropertyName = "Warehouse";
            this.colWarehouse.HeaderText = "Warehouse";
            this.colWarehouse.Name = "colWarehouse";
            this.colWarehouse.ReadOnly = true;
            this.colWarehouse.Width = 150;
            // 
            // colSupplier
            // 
            this.colSupplier.DataPropertyName = "Supplier";
            this.colSupplier.HeaderText = "Supplier";
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.ReadOnly = true;
            this.colSupplier.Width = 150;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTotalAmount.DataPropertyName = "TotalAmount";
            this.colTotalAmount.HeaderText = "Total Amount";
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.ReadOnly = true;
            this.colTotalAmount.Width = 95;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlOrderLinkLint);
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(175, 423);
            this.panel1.TabIndex = 2;
            // 
            // pnlOrderLinkLint
            // 
            this.pnlOrderLinkLint.AutoSize = true;
            this.pnlOrderLinkLint.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOrderLinkLint.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlOrderLinkLint.Location = new System.Drawing.Point(5, 28);
            this.pnlOrderLinkLint.MinimumSize = new System.Drawing.Size(0, 10);
            this.pnlOrderLinkLint.Name = "pnlOrderLinkLint";
            this.pnlOrderLinkLint.Padding = new System.Windows.Forms.Padding(10, 0, 0, 10);
            this.pnlOrderLinkLint.Size = new System.Drawing.Size(165, 10);
            this.pnlOrderLinkLint.TabIndex = 1;
            this.pnlOrderLinkLint.WrapContents = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lnkPurchaseOrderList);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(5, 5);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(165, 23);
            this.flowLayoutPanel2.TabIndex = 2;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // lnkPurchaseOrderList
            // 
            this.lnkPurchaseOrderList.AutoSize = true;
            this.lnkPurchaseOrderList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkPurchaseOrderList.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkPurchaseOrderList.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lnkPurchaseOrderList.Location = new System.Drawing.Point(3, 0);
            this.lnkPurchaseOrderList.Name = "lnkPurchaseOrderList";
            this.lnkPurchaseOrderList.Size = new System.Drawing.Size(144, 17);
            this.lnkPurchaseOrderList.TabIndex = 2;
            this.lnkPurchaseOrderList.TabStop = true;
            this.lnkPurchaseOrderList.Text = "• Purchase Order List";
            this.toolTip1.SetToolTip(this.lnkPurchaseOrderList, "Go to Purchase Order List");
            this.lnkPurchaseOrderList.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(180, 398);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 25);
            this.panel2.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.splitter1.Location = new System.Drawing.Point(175, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 423);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.btnNew);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panel3.Size = new System.Drawing.Size(462, 26);
            this.panel3.TabIndex = 5;
            // 
            // btnNew
            // 
            this.btnNew.Image = global::IMS.Properties.Resources.icons8_Plus_Math_16px;
            this.btnNew.Location = new System.Drawing.Point(4, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(21, 19);
            this.btnNew.TabIndex = 1;
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnNew, "Create New Purchase Order");
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // lblPurchaseOrderHeaderText
            // 
            this.lblPurchaseOrderHeaderText.BackColor = System.Drawing.Color.SlateGray;
            this.lblPurchaseOrderHeaderText.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPurchaseOrderHeaderText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurchaseOrderHeaderText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPurchaseOrderHeaderText.Location = new System.Drawing.Point(180, 0);
            this.lblPurchaseOrderHeaderText.Name = "lblPurchaseOrderHeaderText";
            this.lblPurchaseOrderHeaderText.Size = new System.Drawing.Size(462, 42);
            this.lblPurchaseOrderHeaderText.TabIndex = 0;
            this.lblPurchaseOrderHeaderText.Text = "Purchase Orders";
            this.lblPurchaseOrderHeaderText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDataBody
            // 
            this.pnlDataBody.Controls.Add(this.dgvPurchases);
            this.pnlDataBody.Controls.Add(this.panel3);
            this.pnlDataBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataBody.Location = new System.Drawing.Point(180, 42);
            this.pnlDataBody.Name = "pnlDataBody";
            this.pnlDataBody.Size = new System.Drawing.Size(462, 356);
            this.pnlDataBody.TabIndex = 6;
            // 
            // PurchaseListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlDataBody);
            this.Controls.Add(this.lblPurchaseOrderHeaderText);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "PurchaseListUC";
            this.Size = new System.Drawing.Size(642, 423);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchases)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.pnlDataBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvPurchases;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLotNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWarehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel pnlOrderLinkLint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel lnkPurchaseOrderList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel3;
        protected internal System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblPurchaseOrderHeaderText;
        private System.Windows.Forms.Panel pnlDataBody;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
