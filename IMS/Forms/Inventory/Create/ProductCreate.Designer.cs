namespace IMS.Forms.Inventory.Create
{
    partial class ProductCreate
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label15 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tbSellPrice = new System.Windows.Forms.NumericUpDown();
            this.tbUnitCost = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tbStockThreshold = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.cbShowStockAlert = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbProductName = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pnlAttributesBody = new System.Windows.Forms.FlowLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel9 = new System.Windows.Forms.Panel();
            this.pnlBrandsBody = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageDetails = new System.Windows.Forms.TabPage();
            this.tabPageBrands = new System.Windows.Forms.TabPage();
            this.tabPageAttributes = new System.Windows.Forms.TabPage();
            this.tabPageAlerts = new System.Windows.Forms.TabPage();
            this.tabPrices = new System.Windows.Forms.TabPage();
            this.btnAddBrand = new System.Windows.Forms.Button();
            this.btnAttributeAdd = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSellPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUnitCost)).BeginInit();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbStockThreshold)).BeginInit();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageDetails.SuspendLayout();
            this.tabPageBrands.SuspendLayout();
            this.tabPageAttributes.SuspendLayout();
            this.tabPageAlerts.SuspendLayout();
            this.tabPrices.SuspendLayout();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(741, 34);
            this.label15.TabIndex = 32;
            this.label15.Text = "Attributes";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label15, "Stock Keeping Unit");
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tableLayoutPanel2);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(743, 326);
            this.panel3.TabIndex = 32;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tbSellPrice, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbUnitCost, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(741, 65);
            this.tableLayoutPanel2.TabIndex = 31;
            // 
            // tbSellPrice
            // 
            this.tbSellPrice.Enabled = false;
            this.tbSellPrice.Location = new System.Drawing.Point(374, 36);
            this.tbSellPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbSellPrice.Name = "tbSellPrice";
            this.tbSellPrice.Size = new System.Drawing.Size(193, 22);
            this.tbSellPrice.TabIndex = 33;
            // 
            // tbUnitCost
            // 
            this.tbUnitCost.Enabled = false;
            this.tbUnitCost.Location = new System.Drawing.Point(374, 4);
            this.tbUnitCost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbUnitCost.Name = "tbUnitCost";
            this.tbUnitCost.Size = new System.Drawing.Size(193, 22);
            this.tbUnitCost.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 18);
            this.label6.TabIndex = 20;
            this.label6.Text = "Unit Cost";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 18);
            this.label7.TabIndex = 22;
            this.label7.Text = "Sell Price";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(741, 28);
            this.label4.TabIndex = 32;
            this.label4.Text = "Prices";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label10.Location = new System.Drawing.Point(0, 307);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(218, 17);
            this.label10.TabIndex = 34;
            this.label10.Text = "Cost is set once you do purchase";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.tableLayoutPanel3);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(4, 4);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(743, 326);
            this.panel4.TabIndex = 33;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tbStockThreshold, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbShowStockAlert, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 34);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(741, 75);
            this.tableLayoutPanel3.TabIndex = 31;
            // 
            // tbStockThreshold
            // 
            this.tbStockThreshold.Location = new System.Drawing.Point(374, 41);
            this.tbStockThreshold.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbStockThreshold.Name = "tbStockThreshold";
            this.tbStockThreshold.Size = new System.Drawing.Size(193, 22);
            this.tbStockThreshold.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 18);
            this.label8.TabIndex = 24;
            this.label8.Text = "Show Stock Alert";
            // 
            // cbShowStockAlert
            // 
            this.cbShowStockAlert.AutoSize = true;
            this.cbShowStockAlert.Location = new System.Drawing.Point(373, 2);
            this.cbShowStockAlert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbShowStockAlert.Name = "cbShowStockAlert";
            this.cbShowStockAlert.Size = new System.Drawing.Size(18, 17);
            this.cbShowStockAlert.TabIndex = 25;
            this.cbShowStockAlert.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 18);
            this.label9.TabIndex = 26;
            this.label9.Text = "Stock Threshold";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(741, 34);
            this.label12.TabIndex = 32;
            this.label12.Text = "Alerts";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.tableLayoutPanel1);
            this.panel6.Controls.Add(this.label14);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(4, 4);
            this.panel6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(743, 326);
            this.panel6.TabIndex = 34;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbProductName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbCategory, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 34);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(741, 117);
            this.tableLayoutPanel1.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Product Name";
            // 
            // tbProductName
            // 
            this.tbProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProductName.Location = new System.Drawing.Point(373, 2);
            this.tbProductName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(208, 24);
            this.tbProductName.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Category";
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(373, 41);
            this.cbCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(208, 24);
            this.cbCategory.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label14.Dock = System.Windows.Forms.DockStyle.Top;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(0, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(741, 34);
            this.label14.TabIndex = 32;
            this.label14.Text = "Details";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.pnlAttributesBody);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(4, 4);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(743, 326);
            this.panel5.TabIndex = 35;
            // 
            // pnlAttributesBody
            // 
            this.pnlAttributesBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAttributesBody.Location = new System.Drawing.Point(0, 73);
            this.pnlAttributesBody.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlAttributesBody.Name = "pnlAttributesBody";
            this.pnlAttributesBody.Size = new System.Drawing.Size(741, 251);
            this.pnlAttributesBody.TabIndex = 37;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnAttributeAdd);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 34);
            this.panel7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(741, 39);
            this.panel7.TabIndex = 36;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(691, 34);
            this.label11.TabIndex = 32;
            this.label11.Text = "Brands";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label11, "Stock Keeping Unit");
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(139, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(13, 10);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 357);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(709, 46);
            this.panel1.TabIndex = 37;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.pnlBrandsBody);
            this.panel9.Controls.Add(this.panel2);
            this.panel9.Controls.Add(this.label11);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(4, 4);
            this.panel9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(693, 317);
            this.panel9.TabIndex = 37;
            // 
            // pnlBrandsBody
            // 
            this.pnlBrandsBody.AutoScroll = true;
            this.pnlBrandsBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBrandsBody.Location = new System.Drawing.Point(0, 72);
            this.pnlBrandsBody.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlBrandsBody.Name = "pnlBrandsBody";
            this.pnlBrandsBody.Size = new System.Drawing.Size(691, 243);
            this.pnlBrandsBody.TabIndex = 36;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAddBrand);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 34);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(691, 38);
            this.panel2.TabIndex = 35;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPageDetails);
            this.tabControl1.Controls.Add(this.tabPageBrands);
            this.tabControl1.Controls.Add(this.tabPageAttributes);
            this.tabControl1.Controls.Add(this.tabPageAlerts);
            this.tabControl1.Controls.Add(this.tabPrices);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(709, 357);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 33;
            // 
            // tabPageDetails
            // 
            this.tabPageDetails.Controls.Add(this.panel6);
            this.tabPageDetails.Location = new System.Drawing.Point(4, 28);
            this.tabPageDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageDetails.Name = "tabPageDetails";
            this.tabPageDetails.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageDetails.Size = new System.Drawing.Size(751, 334);
            this.tabPageDetails.TabIndex = 0;
            this.tabPageDetails.Text = "Details";
            this.tabPageDetails.UseVisualStyleBackColor = true;
            // 
            // tabPageBrands
            // 
            this.tabPageBrands.Controls.Add(this.panel9);
            this.tabPageBrands.Location = new System.Drawing.Point(4, 28);
            this.tabPageBrands.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageBrands.Name = "tabPageBrands";
            this.tabPageBrands.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageBrands.Size = new System.Drawing.Size(701, 325);
            this.tabPageBrands.TabIndex = 1;
            this.tabPageBrands.Text = "Brands";
            this.tabPageBrands.UseVisualStyleBackColor = true;
            // 
            // tabPageAttributes
            // 
            this.tabPageAttributes.Controls.Add(this.panel5);
            this.tabPageAttributes.Location = new System.Drawing.Point(4, 28);
            this.tabPageAttributes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageAttributes.Name = "tabPageAttributes";
            this.tabPageAttributes.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageAttributes.Size = new System.Drawing.Size(751, 334);
            this.tabPageAttributes.TabIndex = 3;
            this.tabPageAttributes.Text = "Attributes";
            this.tabPageAttributes.UseVisualStyleBackColor = true;
            // 
            // tabPageAlerts
            // 
            this.tabPageAlerts.Controls.Add(this.panel4);
            this.tabPageAlerts.Location = new System.Drawing.Point(4, 28);
            this.tabPageAlerts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageAlerts.Name = "tabPageAlerts";
            this.tabPageAlerts.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageAlerts.Size = new System.Drawing.Size(751, 334);
            this.tabPageAlerts.TabIndex = 2;
            this.tabPageAlerts.Text = "Alerts";
            this.tabPageAlerts.UseVisualStyleBackColor = true;
            // 
            // tabPrices
            // 
            this.tabPrices.Controls.Add(this.panel3);
            this.tabPrices.Location = new System.Drawing.Point(4, 28);
            this.tabPrices.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPrices.Name = "tabPrices";
            this.tabPrices.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPrices.Size = new System.Drawing.Size(751, 334);
            this.tabPrices.TabIndex = 4;
            this.tabPrices.Text = "Prices";
            this.tabPrices.UseVisualStyleBackColor = true;
            // 
            // btnAddBrand
            // 
            this.btnAddBrand.BackgroundImage = global::IMS.Properties.Resources.icons8_Plus_Math_16px;
            this.btnAddBrand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddBrand.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddBrand.Location = new System.Drawing.Point(5, 4);
            this.btnAddBrand.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddBrand.Name = "btnAddBrand";
            this.btnAddBrand.Size = new System.Drawing.Size(32, 30);
            this.btnAddBrand.TabIndex = 33;
            this.btnAddBrand.UseVisualStyleBackColor = true;
            this.btnAddBrand.Click += new System.EventHandler(this.btnAddBrand_Click);
            // 
            // btnAttributeAdd
            // 
            this.btnAttributeAdd.BackgroundImage = global::IMS.Properties.Resources.icons8_Plus_Math_16px;
            this.btnAttributeAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAttributeAdd.Location = new System.Drawing.Point(7, 5);
            this.btnAttributeAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAttributeAdd.Name = "btnAttributeAdd";
            this.btnAttributeAdd.Size = new System.Drawing.Size(32, 30);
            this.btnAttributeAdd.TabIndex = 34;
            this.btnAttributeAdd.UseVisualStyleBackColor = true;
            this.btnAttributeAdd.Click += new System.EventHandler(this.btnAttributeAdd_Click);
            // 
            // ProductCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 403);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ProductCreate";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Product";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSellPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUnitCost)).EndInit();
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbStockThreshold)).EndInit();
            this.panel6.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageDetails.ResumeLayout(false);
            this.tabPageBrands.ResumeLayout(false);
            this.tabPageAttributes.ResumeLayout(false);
            this.tabPageAlerts.ResumeLayout(false);
            this.tabPrices.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbShowStockAlert;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox tbProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown tbSellPrice;
        private System.Windows.Forms.NumericUpDown tbUnitCost;
        private System.Windows.Forms.NumericUpDown tbStockThreshold;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnAddBrand;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnAttributeAdd;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageDetails;
        private System.Windows.Forms.TabPage tabPageBrands;
        private System.Windows.Forms.TabPage tabPageAttributes;
        private System.Windows.Forms.TabPage tabPageAlerts;
        private System.Windows.Forms.TabPage tabPrices;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel pnlBrandsBody;
        private System.Windows.Forms.FlowLayoutPanel pnlAttributesBody;
    }
}