namespace IMS.Forms.Orders
{
    partial class OrdersMenuBar
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnNewPurchaseOrder = new System.Windows.Forms.Button();
            this.btnPurchaseOrderList = new System.Windows.Forms.Button();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNewSalesOrder = new System.Windows.Forms.Button();
            this.btnSalesOrderList = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(155, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 79);
            this.splitter1.TabIndex = 27;
            this.splitter1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnNewPurchaseOrder);
            this.groupBox3.Controls.Add(this.btnPurchaseOrderList);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(153, 79);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Purchase";
            // 
            // btnNewPurchaseOrder
            // 
            this.btnNewPurchaseOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNewPurchaseOrder.Image = global::IMS.Properties.Resources.icons8_Create_Order_16px;
            this.btnNewPurchaseOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewPurchaseOrder.Location = new System.Drawing.Point(65, 16);
            this.btnNewPurchaseOrder.Name = "btnNewPurchaseOrder";
            this.btnNewPurchaseOrder.Size = new System.Drawing.Size(85, 24);
            this.btnNewPurchaseOrder.TabIndex = 1;
            this.btnNewPurchaseOrder.Text = "New Order";
            this.btnNewPurchaseOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewPurchaseOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewPurchaseOrder.UseVisualStyleBackColor = true;
            // 
            // btnPurchaseOrderList
            // 
            this.btnPurchaseOrderList.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPurchaseOrderList.Image = global::IMS.Properties.Resources.icons8_Purchase_Order_24px;
            this.btnPurchaseOrderList.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPurchaseOrderList.Location = new System.Drawing.Point(3, 16);
            this.btnPurchaseOrderList.Name = "btnPurchaseOrderList";
            this.btnPurchaseOrderList.Size = new System.Drawing.Size(62, 60);
            this.btnPurchaseOrderList.TabIndex = 0;
            this.btnPurchaseOrderList.Text = "Purchase Orders";
            this.btnPurchaseOrderList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPurchaseOrderList.UseVisualStyleBackColor = true;
            // 
            // splitter2
            // 
            this.splitter2.Enabled = false;
            this.splitter2.Location = new System.Drawing.Point(354, 2);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(8, 79);
            this.splitter2.TabIndex = 29;
            this.splitter2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnNewSalesOrder);
            this.groupBox1.Controls.Add(this.btnSalesOrderList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(163, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 79);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sales";
            // 
            // btnNewSalesOrder
            // 
            this.btnNewSalesOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNewSalesOrder.Image = global::IMS.Properties.Resources.icons8_Shopping_Cart_24px;
            this.btnNewSalesOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewSalesOrder.Location = new System.Drawing.Point(71, 16);
            this.btnNewSalesOrder.Name = "btnNewSalesOrder";
            this.btnNewSalesOrder.Size = new System.Drawing.Size(117, 32);
            this.btnNewSalesOrder.TabIndex = 1;
            this.btnNewSalesOrder.Text = "New Order";
            this.btnNewSalesOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewSalesOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewSalesOrder.UseVisualStyleBackColor = true;
            // 
            // btnSalesOrderList
            // 
            this.btnSalesOrderList.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSalesOrderList.Image = global::IMS.Properties.Resources.icons8_Shopping_Cart_24px;
            this.btnSalesOrderList.Location = new System.Drawing.Point(3, 16);
            this.btnSalesOrderList.Name = "btnSalesOrderList";
            this.btnSalesOrderList.Size = new System.Drawing.Size(68, 60);
            this.btnSalesOrderList.TabIndex = 0;
            this.btnSalesOrderList.Text = "Sale Orders";
            this.btnSalesOrderList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalesOrderList.UseVisualStyleBackColor = true;
            // 
            // OrdersMenuBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox3);
            this.Name = "OrdersMenuBar";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(790, 83);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox3;
        protected internal System.Windows.Forms.Button btnNewPurchaseOrder;
        protected internal System.Windows.Forms.Button btnPurchaseOrderList;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.GroupBox groupBox1;
        protected internal System.Windows.Forms.Button btnNewSalesOrder;
        protected internal System.Windows.Forms.Button btnSalesOrderList;
    }
}
