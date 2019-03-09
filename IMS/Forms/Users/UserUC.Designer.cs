namespace IMS.Forms.Users
{
    partial class UserUC
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
            this.gvUserList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gvBasicInfoList = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DobOrEstd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsMarried = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEditBasicInfo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddBasicInfo = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvUserList)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvBasicInfoList)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.label1.Size = new System.Drawing.Size(761, 48);
            this.label1.TabIndex = 8;
            this.label1.Text = "User";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 48);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(761, 721);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gvUserList);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(753, 692);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Users";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gvUserList
            // 
            this.gvUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvUserList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.gvUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvUserList.Location = new System.Drawing.Point(3, 72);
            this.gvUserList.Name = "gvUserList";
            this.gvUserList.RowTemplate.Height = 24;
            this.gvUserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvUserList.Size = new System.Drawing.Size(747, 617);
            this.gvUserList.TabIndex = 12;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Username";
            this.dataGridViewTextBoxColumn1.HeaderText = "Username";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Password";
            this.dataGridViewTextBoxColumn2.HeaderText = "Password";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "BasicInfoId";
            this.dataGridViewTextBoxColumn3.HeaderText = "BasicInfo";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "UserType";
            this.dataGridViewTextBoxColumn4.HeaderText = "User Type";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CanLogin";
            this.dataGridViewTextBoxColumn5.HeaderText = "CanLogin";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(747, 69);
            this.panel2.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(123, 43);
            this.label3.TabIndex = 4;
            this.label3.Text = "Users";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::IMS.Properties.Resources.icons8_Plus_48px;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(154, 22);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 30);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gvBasicInfoList);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(753, 692);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Basic Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gvBasicInfoList
            // 
            this.gvBasicInfoList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvBasicInfoList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.DobOrEstd,
            this.Email,
            this.Address,
            this.Phone,
            this.Gender,
            this.IsMarried});
            this.gvBasicInfoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvBasicInfoList.Location = new System.Drawing.Point(3, 72);
            this.gvBasicInfoList.Name = "gvBasicInfoList";
            this.gvBasicInfoList.RowTemplate.Height = 24;
            this.gvBasicInfoList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvBasicInfoList.Size = new System.Drawing.Size(747, 617);
            this.gvBasicInfoList.TabIndex = 15;
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Title.DataPropertyName = "Name";
            this.Title.HeaderText = "Name";
            this.Title.Name = "Title";
            // 
            // DobOrEstd
            // 
            this.DobOrEstd.DataPropertyName = "DOB";
            this.DobOrEstd.HeaderText = "DOB / Estd";
            this.DobOrEstd.Name = "DobOrEstd";
            // 
            // Email
            // 
            this.Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // Address
            // 
            this.Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            this.Phone.HeaderText = "Phone";
            this.Phone.Name = "Phone";
            // 
            // Gender
            // 
            this.Gender.DataPropertyName = "Gender";
            this.Gender.HeaderText = "Gender (If applicable)";
            this.Gender.Name = "Gender";
            // 
            // IsMarried
            // 
            this.IsMarried.DataPropertyName = "IsMarried";
            this.IsMarried.HeaderText = "Marital Status (If applicable)";
            this.IsMarried.Name = "IsMarried";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEditBasicInfo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnAddBasicInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 69);
            this.panel1.TabIndex = 14;
            // 
            // btnEditBasicInfo
            // 
            this.btnEditBasicInfo.BackgroundImage = global::IMS.Properties.Resources.icons8_Edit_Property_50px;
            this.btnEditBasicInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditBasicInfo.Location = new System.Drawing.Point(237, 15);
            this.btnEditBasicInfo.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditBasicInfo.Name = "btnEditBasicInfo";
            this.btnEditBasicInfo.Size = new System.Drawing.Size(36, 37);
            this.btnEditBasicInfo.TabIndex = 6;
            this.btnEditBasicInfo.UseVisualStyleBackColor = true;
            this.btnEditBasicInfo.Click += new System.EventHandler(this.btnEditBasicInfo_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(123, 43);
            this.label2.TabIndex = 4;
            this.label2.Text = "BasicInfo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAddBasicInfo
            // 
            this.btnAddBasicInfo.BackgroundImage = global::IMS.Properties.Resources.icons8_Add_50px;
            this.btnAddBasicInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddBasicInfo.Location = new System.Drawing.Point(166, 15);
            this.btnAddBasicInfo.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddBasicInfo.Name = "btnAddBasicInfo";
            this.btnAddBasicInfo.Size = new System.Drawing.Size(36, 37);
            this.btnAddBasicInfo.TabIndex = 5;
            this.btnAddBasicInfo.UseVisualStyleBackColor = true;
            this.btnAddBasicInfo.Click += new System.EventHandler(this.btnAddBasicInfo_Click);
            // 
            // UserUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Name = "UserUC";
            this.Size = new System.Drawing.Size(761, 769);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvUserList)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvBasicInfoList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView gvUserList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView gvBasicInfoList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn DobOrEstd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsMarried;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEditBasicInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddBasicInfo;
    }
}
