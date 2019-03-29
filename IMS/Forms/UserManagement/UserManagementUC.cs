using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleInjector.Lifestyles;
using IMS.Forms.Users.Create;
using Service.Core.Users;
using IMS.Forms.Common.Display;
using IMS.Forms.UserManagement.Users;

namespace IMS.Forms.UserManagement
{
    public partial class UserManagementUC : UserControl
    {
        public static readonly string MODULE_NAME = "User Management";
        private BodyTemplate _bodyTemplate;
        private readonly UserManagementMenuBar _menubar;

        public UserManagementUC(UserManagementMenuBar menubar)
        {
            _menubar = menubar;

            InitializeComponent();

            InitializeRootTemplate();

            InitializeMenubarButtonEvents();

        }

        private void InitializeRootTemplate()
        {
            // body
            _bodyTemplate = new BodyTemplate();
            _bodyTemplate.Dock = DockStyle.Fill;
            this.Controls.Add(_bodyTemplate);
            // heading
            _bodyTemplate.lblHeading.Text = MODULE_NAME;
            // menubar template
            _bodyTemplate.pnlMenuBar.Controls.Add(_menubar);
        }

        private void InitializeMenubarButtonEvents()
        {
            // user
            _menubar.btnUserList.Click += BtnUserList_Click;
            _menubar.btnNewUser.Click += BtnNewUser_Click;
            // roles
            _menubar.btnRoleList.Click += BtnRoles_Click;
            _menubar.btnNewRole.Click += BtnNewRole_Click;
        }

        #region Users

        private void BtnUserList_Click(object sender, EventArgs e)
        {
            _bodyTemplate.pnlBody.Controls.Clear();
            var userListUC = Program.container.GetInstance<UserListUC>();
            userListUC.Dock = DockStyle.Fill;
            _bodyTemplate.pnlBody.Controls.Add(userListUC);
            // set selection
            _menubar.ClearSelection();
            _menubar.btnUserList.FlatStyle = FlatStyle.Flat;
        }

        private void BtnNewUser_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var userCreate = Program.container.GetInstance<UserCreate>();
                userCreate.ShowDialog();
               // Populate();
            }
        }

        #endregion


        private void BtnRoles_Click(object sender, EventArgs e)
        {
            // set selection
            _menubar.ClearSelection();
            _menubar.btnRoleList.FlatStyle = FlatStyle.Flat;
        }

        private void BtnNewRole_Click(object sender, EventArgs e)
        {

        }



        /*
       
        private void Populate()
        {
            gvUserList.AutoGenerateColumns = false;
            var user = userService.GetUserList();
            gvUserList.DataSource = user;
        }

        private void btnAddBasicInfo_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var basicInfoCreate = Program.container.GetInstance<BasicInfoCreate>();
                basicInfoCreate.ShowInTaskbar = false;
                basicInfoCreate.ShowDialog();
                PopulateBasicInfoData();
            }
        }

        public void PopulateBasicInfoData()
        {
            gvBasicInfoList.AutoGenerateColumns = false;
            var basicInfos = userService.GetBasicInfoList();
            gvBasicInfoList.DataSource = basicInfos;
        }

        private void btnEditBasicInfo_Click(object sender, EventArgs e)
        {
            if(gvBasicInfoList.SelectedRows != null && gvBasicInfoList.SelectedRows.Count > 0)
            {
                var basicInfo = (ViewModel.Core.Users.BasicInfoModel)gvBasicInfoList.SelectedRows[0].DataBoundItem;
                using (AsyncScopedLifestyle.BeginScope(Program.container))
                {
                    var basicInfoCreate = Program.container.GetInstance<BasicInfoCreate>();
                    basicInfoCreate.ShowInTaskbar = false;
                    basicInfoCreate.SetData(basicInfo);
                    basicInfoCreate.ShowDialog();
                    PopulateBasicInfoData();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var userCreate = Program.container.GetInstance<UserCreate>();
                userCreate.ShowDialog();
                Populate();
            }
        }
        */


    }
}
