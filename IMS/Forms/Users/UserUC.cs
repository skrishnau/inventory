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
            PopulateBasicInfoCombo();
        }

        private void Populate()
        {
            gvUserList.AutoGenerateColumns = false;
            var user = userService.GetUserList();
            gvUserList.DataSource = user;
        }

        private void PopulateBasicInfoCombo()
        {

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var userCreate = Program.container.GetInstance<UserCreate>();
                userCreate.ShowDialog();
                Populate();
            }
        }
    }
}
