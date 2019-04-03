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
using ViewModel.Core.Users;
using IMS.Forms.Common;

namespace IMS.Forms.Users
{
    public partial class UserUC : UserControl
    {
        private readonly IUserService userService;
        public UserUC(IUserService userService)
        {
            this.userService = userService;
            InitializeComponent();
            Populate();
           // PopulateBasicInfoCombo();
            PopulateBasicInfoData();
        }

        private void Populate()
        {
            gvUserList.AutoGenerateColumns = false;
            var user = userService.GetUserList();
            gvUserList.DataSource = user;
        }

        /*private void PopulateBasicInfoCombo()
        {
            var basicInfo = userService.GetBasicInfoList();
            
        }
        */

       

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
                PopulateBasicInfoData();
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            var user = (UserModel)gvUserList.SelectedRows[0].DataBoundItem;
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var userCreate = Program.container.GetInstance<UserCreate>();
                userCreate.PopulateUserForm(user);
                userCreate.ShowDialog();
                Populate();
                PopulateBasicInfoData();
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            var user = (UserModel)gvUserList.SelectedRows[0].DataBoundItem;
            var delete = MessageBox.Show(this, "Do you want to delete the user " + user.Name + "?", "Delete User???", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (delete.Equals(DialogResult.Yes))
            {
                userService.DeleteUser(user);
                PopupMessage.ShowPopupMessage("Delete Success", "User is Successsfully Deleted", PopupMessageType.SUCCESS);
                Populate();
            }
                
        }
    }
}
