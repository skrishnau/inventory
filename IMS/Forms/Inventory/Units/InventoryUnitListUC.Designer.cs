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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbWarehouse = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.gbInformation = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnProductDetail = new System.Windows.Forms.Button();
            this.btnUnitDetail = new System.Windows.Forms.Button();
            this.btnLabels = new System.Windows.Forms.Button();
            this.lblInformationMessage = new System.Windows.Forms.Label();
            this.gbSingleRowActions = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnReceive = new System.Windows.Forms.Button();
            this.btnSplit = new System.Windows.Forms.Button();
            this.btnDisassemble = new System.Windows.Forms.Button();
            this.lblSingleRowActionMessage = new System.Windows.Forms.Label();
            this.gbBulkActions = new System.Windows.Forms.GroupBox();
            this.chkBulkActions = new System.Windows.Forms.CheckBox();
            this.pnlBulkActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMerge = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            this.lblBulkActionsMessage = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dgvInventoryUnit = new IMS.Forms.Common.GridView.InventoryUnits.InventoryUnitDataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.gbInformation.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.gbSingleRowActions.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.gbBulkActions.SuspendLayout();
            this.pnlBulkActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryUnit)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 555F));
            this.tableLayoutPanel1.Controls.Add(this.cbProduct, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbWarehouse, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(801, 46);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // cbProduct
            // 
            this.cbProduct.FormattingEnabled = true;
            this.cbProduct.Location = new System.Drawing.Point(348, 13);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(167, 21);
            this.cbProduct.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Warehouse";
            // 
            // cbWarehouse
            // 
            this.cbWarehouse.FormattingEnabled = true;
            this.cbWarehouse.Location = new System.Drawing.Point(86, 13);
            this.cbWarehouse.Name = "cbWarehouse";
            this.cbWarehouse.Size = new System.Drawing.Size(167, 21);
            this.cbWarehouse.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Product";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.flowLayoutPanel1.Controls.Add(this.gbInformation);
            this.flowLayoutPanel1.Controls.Add(this.gbSingleRowActions);
            this.flowLayoutPanel1.Controls.Add(this.gbBulkActions);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 46);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(801, 140);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // gbInformation
            // 
            this.gbInformation.Controls.Add(this.flowLayoutPanel4);
            this.gbInformation.Controls.Add(this.lblInformationMessage);
            this.gbInformation.Location = new System.Drawing.Point(8, 8);
            this.gbInformation.Name = "gbInformation";
            this.gbInformation.Size = new System.Drawing.Size(299, 59);
            this.gbInformation.TabIndex = 6;
            this.gbInformation.TabStop = false;
            this.gbInformation.Text = "Information";
            this.gbInformation.Visible = false;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.btnProductDetail);
            this.flowLayoutPanel4.Controls.Add(this.btnUnitDetail);
            this.flowLayoutPanel4.Controls.Add(this.btnLabels);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(293, 29);
            this.flowLayoutPanel4.TabIndex = 13;
            // 
            // btnProductDetail
            // 
            this.btnProductDetail.Image = global::IMS.Properties.Resources.icons8_Product_16px_1;
            this.btnProductDetail.Location = new System.Drawing.Point(3, 3);
            this.btnProductDetail.Name = "btnProductDetail";
            this.btnProductDetail.Size = new System.Drawing.Size(110, 23);
            this.btnProductDetail.TabIndex = 0;
            this.btnProductDetail.Text = "Product Detail";
            this.btnProductDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProductDetail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnProductDetail, "View Product detail of the selected Inventory Unit (row)");
            this.btnProductDetail.UseVisualStyleBackColor = true;
            // 
            // btnUnitDetail
            // 
            this.btnUnitDetail.Image = global::IMS.Properties.Resources.icons8_Unity_16px_1;
            this.btnUnitDetail.Location = new System.Drawing.Point(119, 3);
            this.btnUnitDetail.Name = "btnUnitDetail";
            this.btnUnitDetail.Size = new System.Drawing.Size(87, 23);
            this.btnUnitDetail.TabIndex = 1;
            this.btnUnitDetail.Text = "Unit Detail";
            this.btnUnitDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUnitDetail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnUnitDetail, "View Unit Detail of the selected Inventory Unit (row)");
            this.btnUnitDetail.UseVisualStyleBackColor = true;
            // 
            // btnLabels
            // 
            this.btnLabels.Image = global::IMS.Properties.Resources.icons8_Postcard_With_Barcode_16px;
            this.btnLabels.Location = new System.Drawing.Point(212, 3);
            this.btnLabels.Name = "btnLabels";
            this.btnLabels.Size = new System.Drawing.Size(75, 23);
            this.btnLabels.TabIndex = 8;
            this.btnLabels.Text = "Labels";
            this.btnLabels.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLabels.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnLabels, "View Labels of the selected Inventory Unit (row)");
            this.btnLabels.UseVisualStyleBackColor = true;
            // 
            // lblInformationMessage
            // 
            this.lblInformationMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblInformationMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformationMessage.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblInformationMessage.Location = new System.Drawing.Point(3, 45);
            this.lblInformationMessage.Name = "lblInformationMessage";
            this.lblInformationMessage.Size = new System.Drawing.Size(293, 11);
            this.lblInformationMessage.TabIndex = 14;
            this.lblInformationMessage.Text = "Disable Bulk Actions to enable this";
            this.lblInformationMessage.Visible = false;
            // 
            // gbSingleRowActions
            // 
            this.gbSingleRowActions.Controls.Add(this.flowLayoutPanel2);
            this.gbSingleRowActions.Controls.Add(this.lblSingleRowActionMessage);
            this.gbSingleRowActions.Location = new System.Drawing.Point(313, 8);
            this.gbSingleRowActions.Name = "gbSingleRowActions";
            this.gbSingleRowActions.Size = new System.Drawing.Size(274, 59);
            this.gbSingleRowActions.TabIndex = 6;
            this.gbSingleRowActions.TabStop = false;
            this.gbSingleRowActions.Text = "Single Row Actions";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnReceive);
            this.flowLayoutPanel2.Controls.Add(this.btnSplit);
            this.flowLayoutPanel2.Controls.Add(this.btnDisassemble);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(268, 29);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // btnReceive
            // 
            this.btnReceive.Image = global::IMS.Properties.Resources.icons8_Lease_16px;
            this.btnReceive.Location = new System.Drawing.Point(3, 3);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(75, 23);
            this.btnReceive.TabIndex = 6;
            this.btnReceive.Text = "Receive";
            this.btnReceive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReceive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnReceive, "Split the selcted Inventory Unit (row)");
            this.btnReceive.UseVisualStyleBackColor = true;
            // 
            // btnSplit
            // 
            this.btnSplit.Image = global::IMS.Properties.Resources.icons8_Divider_16px;
            this.btnSplit.Location = new System.Drawing.Point(84, 3);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(75, 23);
            this.btnSplit.TabIndex = 5;
            this.btnSplit.Text = "Split";
            this.btnSplit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSplit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnSplit, "Split the selcted Inventory Unit (row)");
            this.btnSplit.UseVisualStyleBackColor = true;
            // 
            // btnDisassemble
            // 
            this.btnDisassemble.Enabled = false;
            this.btnDisassemble.Image = global::IMS.Properties.Resources.icons8_Split_Files_16px;
            this.btnDisassemble.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDisassemble.Location = new System.Drawing.Point(165, 3);
            this.btnDisassemble.Name = "btnDisassemble";
            this.btnDisassemble.Size = new System.Drawing.Size(95, 23);
            this.btnDisassemble.TabIndex = 4;
            this.btnDisassemble.Text = "Disassemble";
            this.btnDisassemble.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDisassemble.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnDisassemble, "Disassemble the selected Inventory Unit (row)");
            this.btnDisassemble.UseVisualStyleBackColor = true;
            // 
            // lblSingleRowActionMessage
            // 
            this.lblSingleRowActionMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSingleRowActionMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSingleRowActionMessage.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblSingleRowActionMessage.Location = new System.Drawing.Point(3, 45);
            this.lblSingleRowActionMessage.Name = "lblSingleRowActionMessage";
            this.lblSingleRowActionMessage.Size = new System.Drawing.Size(268, 11);
            this.lblSingleRowActionMessage.TabIndex = 12;
            this.lblSingleRowActionMessage.Text = "Disable Bulk Actions to enable this";
            this.lblSingleRowActionMessage.Visible = false;
            // 
            // gbBulkActions
            // 
            this.gbBulkActions.Controls.Add(this.chkBulkActions);
            this.gbBulkActions.Controls.Add(this.pnlBulkActions);
            this.gbBulkActions.Controls.Add(this.lblBulkActionsMessage);
            this.gbBulkActions.Location = new System.Drawing.Point(8, 73);
            this.gbBulkActions.Name = "gbBulkActions";
            this.gbBulkActions.Size = new System.Drawing.Size(253, 59);
            this.gbBulkActions.TabIndex = 6;
            this.gbBulkActions.TabStop = false;
            this.gbBulkActions.Text = "Bulk Actions";
            // 
            // chkBulkActions
            // 
            this.chkBulkActions.AutoSize = true;
            this.chkBulkActions.Checked = true;
            this.chkBulkActions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBulkActions.Enabled = false;
            this.chkBulkActions.Location = new System.Drawing.Point(188, -2);
            this.chkBulkActions.Name = "chkBulkActions";
            this.chkBulkActions.Size = new System.Drawing.Size(59, 17);
            this.chkBulkActions.TabIndex = 13;
            this.chkBulkActions.Text = "Enable";
            this.toolTip1.SetToolTip(this.chkBulkActions, "Enable/Disable the Bulk Action Mode");
            this.chkBulkActions.UseVisualStyleBackColor = true;
            this.chkBulkActions.CheckedChanged += new System.EventHandler(this.chkBulkActions_CheckedChanged);
            // 
            // pnlBulkActions
            // 
            this.pnlBulkActions.Controls.Add(this.btnMerge);
            this.pnlBulkActions.Controls.Add(this.btnMove);
            this.pnlBulkActions.Controls.Add(this.btnIssue);
            this.pnlBulkActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBulkActions.Location = new System.Drawing.Point(3, 16);
            this.pnlBulkActions.Name = "pnlBulkActions";
            this.pnlBulkActions.Size = new System.Drawing.Size(247, 27);
            this.pnlBulkActions.TabIndex = 12;
            // 
            // btnMerge
            // 
            this.btnMerge.Image = global::IMS.Properties.Resources.icons8_Merge_Horizontal_16px;
            this.btnMerge.Location = new System.Drawing.Point(3, 3);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(75, 23);
            this.btnMerge.TabIndex = 2;
            this.btnMerge.Text = "Merge";
            this.btnMerge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMerge.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnMerge, "Merge the checked Inventory Units (rows) into one");
            this.btnMerge.UseVisualStyleBackColor = true;
            // 
            // btnMove
            // 
            this.btnMove.Image = global::IMS.Properties.Resources.icons8_Move_16px;
            this.btnMove.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMove.Location = new System.Drawing.Point(84, 3);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(75, 23);
            this.btnMove.TabIndex = 6;
            this.btnMove.Text = "Move";
            this.btnMove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnMove, "Move the checked Inventory Units (rows) to different warehouse");
            this.btnMove.UseVisualStyleBackColor = true;
            // 
            // btnIssue
            // 
            this.btnIssue.Image = global::IMS.Properties.Resources.icons8_Sell_16px;
            this.btnIssue.Location = new System.Drawing.Point(165, 3);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(75, 23);
            this.btnIssue.TabIndex = 7;
            this.btnIssue.Text = "Issue";
            this.btnIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIssue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnIssue, "Issue the checked Inventory Units (rows)");
            this.btnIssue.UseVisualStyleBackColor = true;
            // 
            // lblBulkActionsMessage
            // 
            this.lblBulkActionsMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblBulkActionsMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBulkActionsMessage.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblBulkActionsMessage.Location = new System.Drawing.Point(3, 43);
            this.lblBulkActionsMessage.Name = "lblBulkActionsMessage";
            this.lblBulkActionsMessage.Size = new System.Drawing.Size(247, 13);
            this.lblBulkActionsMessage.TabIndex = 8;
            this.lblBulkActionsMessage.Text = "Check rows to do bulk action";
            // 
            // dgvInventoryUnit
            // 
            this.dgvInventoryUnit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventoryUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventoryUnit.Location = new System.Drawing.Point(0, 186);
            this.dgvInventoryUnit.Name = "dgvInventoryUnit";
            this.dgvInventoryUnit.Size = new System.Drawing.Size(801, 223);
            this.dgvInventoryUnit.TabIndex = 6;
            // 
            // InventoryUnitListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvInventoryUnit);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "InventoryUnitListUC";
            this.Size = new System.Drawing.Size(801, 409);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.gbInformation.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.gbSingleRowActions.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.gbBulkActions.ResumeLayout(false);
            this.gbBulkActions.PerformLayout();
            this.pnlBulkActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryUnit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbWarehouse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnProductDetail;
        private System.Windows.Forms.Button btnUnitDetail;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Button btnDisassemble;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnLabels;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel pnlBulkActions;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.GroupBox gbInformation;
        private System.Windows.Forms.GroupBox gbSingleRowActions;
        private System.Windows.Forms.GroupBox gbBulkActions;
        private System.Windows.Forms.CheckBox chkBulkActions;
        private System.Windows.Forms.Label lblBulkActionsMessage;
        private System.Windows.Forms.Label lblInformationMessage;
        private System.Windows.Forms.Label lblSingleRowActionMessage;
        private System.Windows.Forms.ToolTip toolTip1;
        private Common.GridView.InventoryUnits.InventoryUnitDataGridView dgvInventoryUnit;
        private System.Windows.Forms.Button btnReceive;
    }
}
