namespace IMS.Forms.UserManagement
{
    partial class UserManagementMenuBar
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
            this.gbUsers = new System.Windows.Forms.GroupBox();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.btnUserList = new System.Windows.Forms.Button();
            this.gbRole = new System.Windows.Forms.GroupBox();
            this.btnNewRole = new System.Windows.Forms.Button();
            this.btnRoleList = new System.Windows.Forms.Button();
            this.gbUsers.SuspendLayout();
            this.gbRole.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbUsers
            // 
            this.gbUsers.Controls.Add(this.btnNewUser);
            this.gbUsers.Controls.Add(this.btnUserList);
            this.gbUsers.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbUsers.Location = new System.Drawing.Point(0, 0);
            this.gbUsers.Name = "gbUsers";
            this.gbUsers.Size = new System.Drawing.Size(170, 83);
            this.gbUsers.TabIndex = 18;
            this.gbUsers.TabStop = false;
            this.gbUsers.Text = "User";
            // 
            // btnNewUser
            // 
            this.btnNewUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNewUser.Image = global::IMS.Properties.Resources.icons8_Shopping_Cart_24px;
            this.btnNewUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewUser.Location = new System.Drawing.Point(59, 16);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(108, 32);
            this.btnNewUser.TabIndex = 1;
            this.btnNewUser.Text = "New User";
            this.btnNewUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewUser.UseVisualStyleBackColor = true;
            // 
            // btnUserList
            // 
            this.btnUserList.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUserList.Image = global::IMS.Properties.Resources.icons8_Shopping_Cart_24px;
            this.btnUserList.Location = new System.Drawing.Point(3, 16);
            this.btnUserList.Name = "btnUserList";
            this.btnUserList.Size = new System.Drawing.Size(56, 64);
            this.btnUserList.TabIndex = 0;
            this.btnUserList.Text = "Users";
            this.btnUserList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUserList.UseVisualStyleBackColor = true;
            // 
            // gbRole
            // 
            this.gbRole.Controls.Add(this.btnNewRole);
            this.gbRole.Controls.Add(this.btnRoleList);
            this.gbRole.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbRole.Location = new System.Drawing.Point(170, 0);
            this.gbRole.Name = "gbRole";
            this.gbRole.Size = new System.Drawing.Size(159, 83);
            this.gbRole.TabIndex = 19;
            this.gbRole.TabStop = false;
            this.gbRole.Text = "Role";
            // 
            // btnNewRole
            // 
            this.btnNewRole.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNewRole.Image = global::IMS.Properties.Resources.icons8_Shopping_Cart_24px;
            this.btnNewRole.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewRole.Location = new System.Drawing.Point(59, 16);
            this.btnNewRole.Name = "btnNewRole";
            this.btnNewRole.Size = new System.Drawing.Size(97, 32);
            this.btnNewRole.TabIndex = 1;
            this.btnNewRole.Text = "New Role";
            this.btnNewRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewRole.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewRole.UseVisualStyleBackColor = true;
            // 
            // btnRoleList
            // 
            this.btnRoleList.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRoleList.Image = global::IMS.Properties.Resources.icons8_Shopping_Cart_24px;
            this.btnRoleList.Location = new System.Drawing.Point(3, 16);
            this.btnRoleList.Name = "btnRoleList";
            this.btnRoleList.Size = new System.Drawing.Size(56, 64);
            this.btnRoleList.TabIndex = 0;
            this.btnRoleList.Text = "Roles";
            this.btnRoleList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRoleList.UseVisualStyleBackColor = true;
            // 
            // UserManagementMenuBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbRole);
            this.Controls.Add(this.gbUsers);
            this.Name = "UserManagementMenuBar";
            this.Size = new System.Drawing.Size(848, 83);
            this.gbUsers.ResumeLayout(false);
            this.gbRole.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbUsers;
        protected internal System.Windows.Forms.Button btnNewUser;
        protected internal System.Windows.Forms.Button btnUserList;
        private System.Windows.Forms.GroupBox gbRole;
        protected internal System.Windows.Forms.Button btnNewRole;
        protected internal System.Windows.Forms.Button btnRoleList;
    }
}
