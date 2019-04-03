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
        private int userId;

        public UserCreate(IUserService userService)
        {
            this.userService = userService;
            InitializeComponent();
            PopulateBasicInfoCombo();
            InitializeValidationEvents();


        }
        private void InitializeValidationEvents()
        {
            tbPassword.Validating += TbPassword_Validating;
            tbRePassword.Validating += TbRePassword_Validating;
            
        }

        private void TbRePassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbPassword.Text != tbRePassword.Text)
                errorProvider1.SetError(tbRePassword, "Password Missmatch");
            else
                errorProvider1.SetError(tbRePassword, "");
        }

        private void TbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbPassword.Text == "" || tbPassword.Text.Length < 6)
                errorProvider1.SetError(tbPassword, "At least 6 letters.");
            else
                errorProvider1.SetError(tbPassword, "");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if(errorProvider1.GetError(tbPassword) != "")
            {
                MessageBox.Show("Invalid password!!!");
            }
            if(errorProvider1.GetError(tbRePassword) !="")
            {
                MessageBox.Show("Password Missmatch!!!");
            }

            var model = new UserModel()
            {
                Address = tbAddress.Text,
                CanLogin = cbCanLogIn.Checked,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DOB = DateTime.Now, // will manage later
                Email = tbEmail.Text,
                Gender = cbGender.Text,
                IsCompany = cbIsCompany.Checked,
                IsMarried = cbMarried.Text,
                Name = tbName.Text,
                Password = tbPassword.Text, // validate later
                Phone = tbPhone.Text,
                Username = tbUserName.Text,
                UserType = cbUserType.Text,
                Website = tbWebsite.Text,
                Id = userId,
                
            };

            userService.AddOrUpdateUser(model);
            this.Close();
            
        }

        private bool ValidatePassword()
        {
            return errorProvider1.GetError(tbPassword) == "" ? true : false;   
         
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PopulateBasicInfoCombo()
        {
            //    var basicInfo = userService.GetBasicInfoList();
            //    cbBasicinfo.DataSource = basicInfo;
            //    cbBasicinfo.ValueMember = "Id";
            //    cbBasicinfo.DisplayMember = "Id";
        }

        internal void PopulateUserForm(UserModel user)
        {
            userId = user.Id;
            tbName.Text = user.Name;
            tbDOB.Text = user.DOB.ToString();
            cbGender.Text = user.Gender;
            cbMarried.Text = user.IsMarried;
            if (user.IsCompany)
                cbIsCompany.Checked = true;
            tbAddress.Text = user.Address;
            tbPhone.Text = user.Phone;
            tbEmail.Text = user.Email;
            tbWebsite.Text = user.Website;
            tbUserName.Text = user.Username;
            cbUserType.Text = user.UserType;
            if (user.CanLogin)
                cbCanLogIn.Checked = true;
        }
    }
}
