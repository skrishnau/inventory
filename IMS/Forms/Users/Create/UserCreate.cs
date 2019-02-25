using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Core.Users;
using ViewModel.Core.Users;

namespace IMS.Forms.Users.Create
{
    public partial class UserCreate : Form
    {
        private readonly IUserService userService;
        public UserCreate(IUserService userService)
        {
            this.userService = userService;
            InitializeComponent();
          //  PopulateBasicInfoCombo();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var model = new UserModel
            {
                BasicInfoId = int.Parse(cbBasicinfo.Text),
                CanLogin = true,
                CreatedAt = DateTime.Now,
                Password = "hello",
                Username = tbUsername.Text,
                UserType = cbUserType.Text,

            };
            userService.AddOrUpdateUser(model);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //private void PopulateBasicInfoCombo()
        //{
        //    cbBasicinfo.FlatStyle = FlatStyle.Popup;
        //    cbBasicinfo.DropDownStyle = ComboBoxStyle.DropDownList;
        //    var basicInfo = businessService.GetBranchList();
        //    cbBranchId.DataSource = branches;
        //    cbBranchId.ValueMember = "Id";
        //    cbBranchId.DisplayMember = "Name";
        //    //cbBranchId.SelectedIndex = 0;
        //}
    }
}
