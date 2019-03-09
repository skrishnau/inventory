namespace IMS.Forms.Inventory
{
    partial class InventoryUC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabProducts = new System.Windows.Forms.TabPage();
            this.dgvProductList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrands = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOptions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShowStockAlerts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinStockCountForAlert = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStocksCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.tabCategories = new System.Windows.Forms.TabPage();
            this.tabBrands = new System.Windows.Forms.TabPage();
            this.dgvBrandList = new System.Windows.Forms.DataGridView();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAddBrand = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tabAttributes = new System.Windows.Forms.TabPage();
            this.dgvAttributeList = new System.Windows.Forms.DataGridView();
            this.AttributeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbAttributeName = new System.Windows.Forms.TextBox();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnEditSKU = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).BeginInit();
            this.pnl.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabBrands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrandList)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabAttributes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributeList)).BeginInit();
            this.contextMenuStrip3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1439, 614);
            this.panel2.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabProducts);
            this.tabControl1.Controls.Add(this.tabCategories);
            this.tabControl1.Controls.Add(this.tabBrands);
            this.tabControl1.Controls.Add(this.tabAttributes);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1439, 614);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabProducts
            // 
            this.tabProducts.Controls.Add(this.dgvProductList);
            this.tabProducts.Controls.Add(this.pnl);
            this.tabProducts.Controls.Add(this.panel5);
            this.tabProducts.Location = new System.Drawing.Point(4, 29);
            this.tabProducts.Margin = new System.Windows.Forms.Padding(4);
            this.tabProducts.Name = "tabProducts";
            this.tabProducts.Padding = new System.Windows.Forms.Padding(4);
            this.tabProducts.Size = new System.Drawing.Size(1431, 581);
            this.tabProducts.TabIndex = 0;
            this.tabProducts.Text = "Products";
            // 
            // dgvProductList
            // 
            this.dgvProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.colCategory,
            this.colBrands,
            this.colOptions,
            this.colShowStockAlerts,
            this.colMinStockCountForAlert,
            this.colUpdatedAt,
            this.colStocksCount});
            this.dgvProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductList.Location = new System.Drawing.Point(4, 59);
            this.dgvProductList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProductList.Name = "dgvProductList";
            this.dgvProductList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductList.Size = new System.Drawing.Size(954, 518);
            this.dgvProductList.TabIndex = 4;
            this.dgvProductList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductList_CellClick);
            this.dgvProductList.SelectionChanged += new System.EventHandler(this.dgvProductList_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn2.HeaderText = "Product";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 86;
            // 
            // colCategory
            // 
            this.colCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCategory.DataPropertyName = "Category";
            this.colCategory.HeaderText = "Category";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 94;
            // 
            // colBrands
            // 
            this.colBrands.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBrands.DataPropertyName = "Brands";
            this.colBrands.HeaderText = "Brands";
            this.colBrands.MinimumWidth = 50;
            this.colBrands.Name = "colBrands";
            this.colBrands.ReadOnly = true;
            // 
            // colOptions
            // 
            this.colOptions.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOptions.DataPropertyName = "OptionValues";
            this.colOptions.HeaderText = "Attributes";
            this.colOptions.MinimumWidth = 50;
            this.colOptions.Name = "colOptions";
            this.colOptions.ReadOnly = true;
            // 
            // colShowStockAlerts
            // 
            this.colShowStockAlerts.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colShowStockAlerts.DataPropertyName = "ShowStockAlerts";
            this.colShowStockAlerts.HeaderText = "Alerts";
            this.colShowStockAlerts.Name = "colShowStockAlerts";
            this.colShowStockAlerts.ReadOnly = true;
            this.colShowStockAlerts.Width = 73;
            // 
            // colMinStockCountForAlert
            // 
            this.colMinStockCountForAlert.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colMinStockCountForAlert.DataPropertyName = "MinStockCountForAlert ";
            this.colMinStockCountForAlert.HeaderText = "Alert Threshold";
            this.colMinStockCountForAlert.Name = "colMinStockCountForAlert";
            this.colMinStockCountForAlert.ReadOnly = true;
            this.colMinStockCountForAlert.Width = 123;
            // 
            // colUpdatedAt
            // 
            this.colUpdatedAt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colUpdatedAt.DataPropertyName = "UpdatedAt ";
            this.colUpdatedAt.HeaderText = "Updated At";
            this.colUpdatedAt.Name = "colUpdatedAt";
            this.colUpdatedAt.ReadOnly = true;
            // 
            // colStocksCount
            // 
            this.colStocksCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colStocksCount.DataPropertyName = "QuantityInStocks ";
            this.colStocksCount.HeaderText = "Stocks Count";
            this.colStocksCount.Name = "colStocksCount";
            this.colStocksCount.ReadOnly = true;
            this.colStocksCount.Width = 110;
            // 
            // pnl
            // 
            this.pnl.Controls.Add(this.btnEditSKU);
            this.pnl.Controls.Add(this.label8);
            this.pnl.Controls.Add(this.label7);
            this.pnl.Controls.Add(this.label6);
            this.pnl.Controls.Add(this.label5);
            this.pnl.Controls.Add(this.lblProductName);
            this.pnl.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl.Location = new System.Drawing.Point(958, 59);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(469, 518);
            this.pnl.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "BrandName Here";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Properties";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(136, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Category Here";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Category";
            // 
            // lblProductName
            // 
            this.lblProductName.Location = new System.Drawing.Point(37, 26);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(132, 17);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "ProductName";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.btnAddProduct);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(4, 4);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1423, 55);
            this.panel5.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(143, 55);
            this.label2.TabIndex = 3;
            this.label2.Text = "Products";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.BackgroundImage = global::IMS.Properties.Resources.icons8_Plus_48px;
            this.btnAddProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddProduct.Location = new System.Drawing.Point(192, 6);
            this.btnAddProduct.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(28, 28);
            this.btnAddProduct.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btnAddProduct, "Add Product");
            this.btnAddProduct.UseVisualStyleBackColor = true;
            // 
            // tabCategories
            // 
            this.tabCategories.Location = new System.Drawing.Point(4, 29);
            this.tabCategories.Margin = new System.Windows.Forms.Padding(4);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.Padding = new System.Windows.Forms.Padding(4);
            this.tabCategories.Size = new System.Drawing.Size(1431, 581);
            this.tabCategories.TabIndex = 1;
            this.tabCategories.Text = "Categories";
            // 
            // tabBrands
            // 
            this.tabBrands.Controls.Add(this.dgvBrandList);
            this.tabBrands.Controls.Add(this.panel3);
            this.tabBrands.Location = new System.Drawing.Point(4, 29);
            this.tabBrands.Margin = new System.Windows.Forms.Padding(4);
            this.tabBrands.Name = "tabBrands";
            this.tabBrands.Padding = new System.Windows.Forms.Padding(4);
            this.tabBrands.Size = new System.Drawing.Size(1431, 581);
            this.tabBrands.TabIndex = 2;
            this.tabBrands.Text = "Brands";
            // 
            // dgvBrandList
            // 
            this.dgvBrandList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBrandList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Brand});
            this.dgvBrandList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBrandList.Location = new System.Drawing.Point(4, 45);
            this.dgvBrandList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvBrandList.Name = "dgvBrandList";
            this.dgvBrandList.Size = new System.Drawing.Size(1423, 532);
            this.dgvBrandList.TabIndex = 1;
            // 
            // Brand
            // 
            this.Brand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Brand.DataPropertyName = "Name";
            this.Brand.HeaderText = "Brand";
            this.Brand.Name = "Brand";
            this.Brand.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAddBrand);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1423, 41);
            this.panel3.TabIndex = 2;
            // 
            // btnAddBrand
            // 
            this.btnAddBrand.BackgroundImage = global::IMS.Properties.Resources.icons8_Plus_48px;
            this.btnAddBrand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddBrand.Location = new System.Drawing.Point(133, 5);
            this.btnAddBrand.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddBrand.Name = "btnAddBrand";
            this.btnAddBrand.Size = new System.Drawing.Size(28, 28);
            this.btnAddBrand.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnAddBrand, "Add Brand");
            this.btnAddBrand.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(113, 41);
            this.label4.TabIndex = 2;
            this.label4.Text = "Brands";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabAttributes
            // 
            this.tabAttributes.Controls.Add(this.dgvAttributeList);
            this.tabAttributes.Controls.Add(this.panel4);
            this.tabAttributes.Location = new System.Drawing.Point(4, 29);
            this.tabAttributes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabAttributes.Name = "tabAttributes";
            this.tabAttributes.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabAttributes.Size = new System.Drawing.Size(1431, 581);
            this.tabAttributes.TabIndex = 3;
            this.tabAttributes.Text = "Attributes";
            this.tabAttributes.UseVisualStyleBackColor = true;
            // 
            // dgvAttributeList
            // 
            this.dgvAttributeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttributeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AttributeName,
            this.Value});
            this.dgvAttributeList.ContextMenuStrip = this.contextMenuStrip3;
            this.dgvAttributeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttributeList.Location = new System.Drawing.Point(3, 64);
            this.dgvAttributeList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvAttributeList.Name = "dgvAttributeList";
            this.dgvAttributeList.RowTemplate.Height = 24;
            this.dgvAttributeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttributeList.Size = new System.Drawing.Size(1425, 515);
            this.dgvAttributeList.TabIndex = 1;
            // 
            // AttributeName
            // 
            this.AttributeName.DataPropertyName = "Name";
            this.AttributeName.HeaderText = "AttributeName";
            this.AttributeName.Name = "AttributeName";
            this.AttributeName.ReadOnly = true;
            this.AttributeName.Width = 300;
            // 
            // Value
            // 
            this.Value.DataPropertyName = "Value";
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Width = 200;
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(123, 52);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tbAttributeName);
            this.panel4.Controls.Add(this.tbValue);
            this.panel4.Controls.Add(this.btnEdit);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 2);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1425, 62);
            this.panel4.TabIndex = 0;
            // 
            // tbAttributeName
            // 
            this.tbAttributeName.Location = new System.Drawing.Point(480, 20);
            this.tbAttributeName.Name = "tbAttributeName";
            this.tbAttributeName.Size = new System.Drawing.Size(129, 23);
            this.tbAttributeName.TabIndex = 5;
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(676, 18);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(121, 23);
            this.tbValue.TabIndex = 4;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(181, 18);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::IMS.Properties.Resources.icons8_Plus_48px;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(117, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 28);
            this.button1.TabIndex = 2;
            this.toolTip1.SetToolTip(this.button1, "Add Attribute");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Attributes";
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
            this.label1.Size = new System.Drawing.Size(1439, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inventory";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1439, 12);
            this.panel1.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnEditSKU
            // 
            this.btnEditSKU.Location = new System.Drawing.Point(82, 307);
            this.btnEditSKU.Name = "btnEditSKU";
            this.btnEditSKU.Size = new System.Drawing.Size(75, 23);
            this.btnEditSKU.TabIndex = 5;
            this.btnEditSKU.Text = "Edit SKU";
            this.btnEditSKU.UseVisualStyleBackColor = true;
            this.btnEditSKU.Click += new System.EventHandler(this.btnEditSKU_Click);
            // 
            // InventoryUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InventoryUC";
            this.Size = new System.Drawing.Size(1439, 672);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).EndInit();
            this.pnl.ResumeLayout(false);
            this.pnl.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.tabBrands.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrandList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tabAttributes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributeList)).EndInit();
            this.contextMenuStrip3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabProducts;
        private System.Windows.Forms.TabPage tabCategories;
        private System.Windows.Forms.TabPage tabBrands;
        private System.Windows.Forms.DataGridView dgvBrandList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand;
        private System.Windows.Forms.DataGridView dgvProductList;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAddBrand;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabAttributes;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvAttributeList;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrands;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOptions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShowStockAlerts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinStockCountForAlert;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpdatedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStocksCount;
        private System.Windows.Forms.TextBox tbAttributeName;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttributeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnEditSKU;
    }
}
