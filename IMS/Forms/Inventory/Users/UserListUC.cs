﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Forms.Common.Display;
using SimpleInjector.Lifestyles;
using Service.Core.Users;

namespace IMS.Forms.Inventory.Users
{
    public partial class UserListUC : UserControl
    {
        private readonly IUserService _userService;

        public UserListUC(IUserService userService)
        {
            this._userService = userService;

            InitializeComponent();
            this.Dock = DockStyle.Fill;
            InitializeHeader();
        }

        private void InitializeHeader()
        {
            var _header = HeaderTemplate.Instance;
            _header.lblHeading.Text = "Users";
            _header.btnNew.Visible = true;
            _header.btnNew.Click += BtnNew_Click;
            // set icon
            //_header.btn
            this.Controls.Add(_header);
            _header.SendToBack();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var userCreate = Program.container.GetInstance<UserCreate>();
                userCreate.ShowDialog();
                Populate();
            }
        }

        private void Populate()
        {
            gvUserList.AutoGenerateColumns = false;
            var user = _userService.GetUserList();
            gvUserList.DataSource = user;
        }
    }
}