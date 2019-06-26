namespace IMS.Forms.Inventory.Units
{
    partial class InventoryUnitListUC
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkBulkActions = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbWarehouse = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvInventoryUnit = new IMS.Forms.Common.GridView.InventoryUnits.InventoryUnitDataGridView();
            this.btnProductDetail = new IMS.Forms.Common.Buttons.MenuButton();
            this.btnUnitDetail = new IMS.Forms.Common.Buttons.MenuButton();
            this.btnLabels = new IMS.Forms.Common.Buttons.MenuButton();
            this.pnlSingleRowActions = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnReceive = new IMS.Forms.Common.Buttons.MenuButton();
            this.btnSplit = new IMS.Forms.Common.Buttons.MenuButton();
            this.btnDisassemble = new IMS.Forms.Common.Buttons.MenuButton();
            this.pnlBulkActions = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMerge = new IMS.Forms.Common.Buttons.MenuButton();
            this.btnMove = new IMS.Forms.Common.Buttons.MenuButton();
            this.btnIssue = new IMS.Forms.Common.Buttons.MenuButton();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel5 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel6 = new System.Windows.Forms.Panel();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.panel7 = new System.Windows.Forms.Panel();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryUnit)).BeginInit();
            this.pnlSingleRowActions.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.pnlBulkActions.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.panel7);
            this.flowLayoutPanel1.Controls.Add(this.pnlInfo);
            this.flowLayoutPanel1.Controls.Add(this.panel6);
            this.flowLayoutPanel1.Controls.Add(this.pnlSingleRowActions);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.pnlBulkActions);
            this.flowLayoutPanel1.Controls.Add(this.panel5);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(579, 91);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // chkBulkActions
            // 
            this.chkBulkActions.AutoSize = true;
            this.chkBulkActions.Checked = true;
            this.chkBulkActions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBulkActions.Enabled = false;
            this.chkBulkActions.Location = new System.Drawing.Point(141, 60);
            this.chkBulkActions.Name = "chkBulkActions";
            this.chkBulkActions.Size = new System.Drawing.Size(59, 17);
            this.chkBulkActions.TabIndex = 13;
            this.chkBulkActions.Text = "Enable";
            this.toolTip1.SetToolTip(this.chkBulkActions, "Enable/Disable the Bulk Action Mode");
            this.chkBulkActions.UseVisualStyleBackColor = true;
            this.chkBulkActions.CheckedChanged += new System.EventHandler(this.chkBulkActions_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 188F));
            this.tableLayoutPanel1.Controls.Add(this.cbWarehouse, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbProduct, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(326, 69);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // cbProduct
            // 
            this.cbProduct.FormattingEnabled = true;
            this.cbProduct.Location = new System.Drawing.Point(146, 36);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(167, 21);
            this.cbProduct.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Product";
            // 
            // cbWarehouse
            // 
            this.cbWarehouse.FormattingEnabled = true;
            this.cbWarehouse.Location = new System.Drawing.Point(146, 4);
            this.cbWarehouse.Name = "cbWarehouse";
            this.cbWarehouse.Size = new System.Drawing.Size(167, 21);
            this.cbWarehouse.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Warehouse";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Filter";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.panel1);
            this.pnlInfo.Controls.Add(this.label3);
            this.pnlInfo.Location = new System.Drawing.Point(25, 8);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(200, 75);
            this.pnlInfo.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 60);
            this.panel1.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(0, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Information";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnProductDetail);
            this.flowLayoutPanel3.Controls.Add(this.btnUnitDetail);
            this.flowLayoutPanel3.Controls.Add(this.btnLabels);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(200, 60);
            this.flowLayoutPanel3.TabIndex = 10;
            // 
            // dgvInventoryUnit
            // 
            this.dgvInventoryUnit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInventoryUnit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventoryUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventoryUnit.Location = new System.Drawing.Point(0, 91);
            this.dgvInventoryUnit.Name = "dgvInventoryUnit";
            this.dgvInventoryUnit.Size = new System.Drawing.Size(913, 318);
            this.dgvInventoryUnit.TabIndex = 6;
            // 
            // btnProductDetail
            // 
            this.btnProductDetail.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnProductDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductDetail.Image = global::IMS.Properties.Resources.icons8_Product_16px_1;
            this.btnProductDetail.Location = new System.Drawing.Point(3, 3);
            this.btnProductDetail.Name = "btnProductDetail";
            this.btnProductDetail.Size = new System.Drawing.Size(60, 55);
            this.btnProductDetail.TabIndex = 0;
            this.btnProductDetail.Text = "Product Detail";
            this.btnProductDetail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnProductDetail.UseVisualStyleBackColor = true;
            // 
            // btnUnitDetail
            // 
            this.btnUnitDetail.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnUnitDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnitDetail.Image = global::IMS.Properties.Resources.icons8_Unity_16px_1;
            this.btnUnitDetail.Location = new System.Drawing.Point(69, 3);
            this.btnUnitDetail.Name = "btnUnitDetail";
            this.btnUnitDetail.Size = new System.Drawing.Size(60, 55);
            this.btnUnitDetail.TabIndex = 1;
            this.btnUnitDetail.Text = "Unit Detail";
            this.btnUnitDetail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUnitDetail.UseVisualStyleBackColor = true;
            // 
            // btnLabels
            // 
            this.btnLabels.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnLabels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLabels.Image = global::IMS.Properties.Resources.icons8_Postcard_With_Barcode_16px;
            this.btnLabels.Location = new System.Drawing.Point(135, 3);
            this.btnLabels.Name = "btnLabels";
            this.btnLabels.Size = new System.Drawing.Size(60, 55);
            this.btnLabels.TabIndex = 2;
            this.btnLabels.Text = "Labels";
            this.btnLabels.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLabels.UseVisualStyleBackColor = true;
            // 
            // pnlSingleRowActions
            // 
            this.pnlSingleRowActions.Controls.Add(this.panel3);
            this.pnlSingleRowActions.Controls.Add(this.label5);
            this.pnlSingleRowActions.Location = new System.Drawing.Point(248, 8);
            this.pnlSingleRowActions.Name = "pnlSingleRowActions";
            this.pnlSingleRowActions.Size = new System.Drawing.Size(200, 75);
            this.pnlSingleRowActions.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.flowLayoutPanel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 60);
            this.panel3.TabIndex = 14;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.btnReceive);
            this.flowLayoutPanel4.Controls.Add(this.btnSplit);
            this.flowLayoutPanel4.Controls.Add(this.btnDisassemble);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(200, 60);
            this.flowLayoutPanel4.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(0, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Single Row Actions";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReceive
            // 
            this.btnReceive.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnReceive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceive.Image = global::IMS.Properties.Resources.icons8_Lease_16px;
            this.btnReceive.Location = new System.Drawing.Point(3, 3);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(60, 55);
            this.btnReceive.TabIndex = 0;
            this.btnReceive.Text = "Receive";
            this.btnReceive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReceive.UseVisualStyleBackColor = true;
            // 
            // btnSplit
            // 
            this.btnSplit.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnSplit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSplit.Image = global::IMS.Properties.Resources.icons8_Divider_16px;
            this.btnSplit.Location = new System.Drawing.Point(69, 3);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(60, 55);
            this.btnSplit.TabIndex = 1;
            this.btnSplit.Text = "Split";
            this.btnSplit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSplit.UseVisualStyleBackColor = true;
            // 
            // btnDisassemble
            // 
            this.btnDisassemble.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnDisassemble.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisassemble.Image = global::IMS.Properties.Resources.icons8_Split_Files_16px;
            this.btnDisassemble.Location = new System.Drawing.Point(135, 3);
            this.btnDisassemble.Name = "btnDisassemble";
            this.btnDisassemble.Size = new System.Drawing.Size(60, 55);
            this.btnDisassemble.TabIndex = 2;
            this.btnDisassemble.Text = "Disassemble";
            this.btnDisassemble.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDisassemble.UseVisualStyleBackColor = true;
            // 
            // pnlBulkActions
            // 
            this.pnlBulkActions.Controls.Add(this.chkBulkActions);
            this.pnlBulkActions.Controls.Add(this.panel4);
            this.pnlBulkActions.Controls.Add(this.label6);
            this.pnlBulkActions.Location = new System.Drawing.Point(8, 89);
            this.pnlBulkActions.Name = "pnlBulkActions";
            this.pnlBulkActions.Size = new System.Drawing.Size(200, 75);
            this.pnlBulkActions.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.flowLayoutPanel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 60);
            this.panel4.TabIndex = 14;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnMerge);
            this.flowLayoutPanel2.Controls.Add(this.btnMove);
            this.flowLayoutPanel2.Controls.Add(this.btnIssue);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(200, 60);
            this.flowLayoutPanel2.TabIndex = 10;
            // 
            // btnMerge
            // 
            this.btnMerge.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnMerge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMerge.Image = global::IMS.Properties.Resources.icons8_Merge_Horizontal_16px;
            this.btnMerge.Location = new System.Drawing.Point(3, 3);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(60, 55);
            this.btnMerge.TabIndex = 0;
            this.btnMerge.Text = "Merge";
            this.btnMerge.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMerge.UseVisualStyleBackColor = true;
            // 
            // btnMove
            // 
            this.btnMove.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMove.Image = global::IMS.Properties.Resources.icons8_Move_16px;
            this.btnMove.Location = new System.Drawing.Point(69, 3);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(60, 55);
            this.btnMove.TabIndex = 1;
            this.btnMove.Text = "Move";
            this.btnMove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMove.UseVisualStyleBackColor = true;
            // 
            // btnIssue
            // 
            this.btnIssue.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssue.Image = global::IMS.Properties.Resources.icons8_Sell_16px;
            this.btnIssue.Location = new System.Drawing.Point(135, 3);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(60, 55);
            this.btnIssue.TabIndex = 2;
            this.btnIssue.Text = "Issue";
            this.btnIssue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnIssue.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label6.Location = new System.Drawing.Point(0, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Bulk Actions";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(454, 8);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5, 4, 4, 4);
            this.panel2.Size = new System.Drawing.Size(11, 75);
            this.panel2.TabIndex = 41;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitter1.Location = new System.Drawing.Point(5, 4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(2, 67);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.splitter2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(214, 89);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(5, 4, 4, 4);
            this.panel5.Size = new System.Drawing.Size(11, 75);
            this.panel5.TabIndex = 42;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitter2.Location = new System.Drawing.Point(5, 4);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(2, 67);
            this.splitter2.TabIndex = 0;
            this.splitter2.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.splitter3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(231, 8);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(5, 4, 4, 4);
            this.panel6.Size = new System.Drawing.Size(11, 75);
            this.panel6.TabIndex = 43;
            // 
            // splitter3
            // 
            this.splitter3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitter3.Location = new System.Drawing.Point(5, 4);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(2, 67);
            this.splitter3.TabIndex = 0;
            this.splitter3.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.splitter4);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(8, 8);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(5, 4, 4, 4);
            this.panel7.Size = new System.Drawing.Size(11, 75);
            this.panel7.TabIndex = 44;
            // 
            // splitter4
            // 
            this.splitter4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitter4.Location = new System.Drawing.Point(5, 4);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(2, 67);
            this.splitter4.TabIndex = 0;
            this.splitter4.TabStop = false;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.tableLayoutPanel1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(579, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(334, 91);
            this.panel8.TabIndex = 7;
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlHeader.BackColor = System.Drawing.SystemColors.Control;
            this.pnlHeader.Controls.Add(this.flowLayoutPanel1);
            this.pnlHeader.Controls.Add(this.panel8);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(913, 91);
            this.pnlHeader.TabIndex = 8;
            // 
            // InventoryUnitListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvInventoryUnit);
            this.Controls.Add(this.pnlHeader);
            this.Name = "InventoryUnitListUC";
            this.Size = new System.Drawing.Size(913, 409);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryUnit)).EndInit();
            this.pnlSingleRowActions.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.pnlBulkActions.ResumeLayout(false);
            this.pnlBulkActions.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox chkBulkActions;
        private System.Windows.Forms.ToolTip toolTip1;
        private Common.GridView.InventoryUnits.InventoryUnitDataGridView dgvInventoryUnit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbWarehouse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private Common.Buttons.MenuButton btnProductDetail;
        private Common.Buttons.MenuButton btnUnitDetail;
        private Common.Buttons.MenuButton btnLabels;
        private System.Windows.Forms.Panel pnlSingleRowActions;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private Common.Buttons.MenuButton btnReceive;
        private Common.Buttons.MenuButton btnSplit;
        private Common.Buttons.MenuButton btnDisassemble;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlBulkActions;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Common.Buttons.MenuButton btnMerge;
        private Common.Buttons.MenuButton btnMove;
        private Common.Buttons.MenuButton btnIssue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel pnlHeader;
    }
}
