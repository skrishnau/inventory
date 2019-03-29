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
            PopulateBasicInfoCombo();

            this.Load += UserCreate_Load;

        }

        private void UserCreate_Load(object sender, EventArgs e)
        {
            tbUsername.Focus();
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
        private void PopulateBasicInfoCombo()
        {
            var basicInfo = userService.GetBasicInfoList();
            cbBasicinfo.DataSource = basicInfo;
            cbBasicinfo.ValueMember = "Id";
            cbBasicinfo.DisplayMember = "Id";
        }
    }
}
