using IMS.Forms.Common;
using Service;
using Service.Core.Settings;
using Service.Core.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Core.Settings;
using ViewModel.Utility;

namespace IMS.Forms.Inventory.Settings.General
{
    public partial class LoginForm : Form
    {
        private readonly IUserService _userService;

        private bool _isAnyUserInSystem = false;

        public LoginForm(IUserService userService)
        {
            // this._appSettingService = appSettingService;
            this._userService = userService;
            InitializeComponent();

            this.Load += LoginForm_Load;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            _isAnyUserInSystem = _userService.IsAnyUser();
            if (!_isAnyUserInSystem)
            {
                tbUsername.Text = Constants.ADMIN_USERNAME;
                tbPassword.Focus();
            }
            else
            {
                this.Height = 156;
            }
            tbConfirmPassword.Visible = !_isAnyUserInSystem;
            lblConfirmPassword.Visible = !_isAnyUserInSystem;
            btnSaveProfile.Click += BtnSave_Click;
        }
       
        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            var isValid = ValidateInputs();
            if (isValid)
            {
                var model = new PasswordModel()
                {
                    Username = tbUsername.Text,
                    Password = tbPassword.Text,//GetHashString(tbPassword.Text),
                };
               
                // validate the password
                var authorizedUser = _userService.Authenticate(tbUsername.Text, tbPassword.Text);
                if (authorizedUser != null)
                {
                    UserSession.User = authorizedUser;
                    PopupMessage.ShowSuccessMessage("Login success!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    PopupMessage.ShowInfoMessage("Couldn't authenticate. Check again");
                    this.Focus();
                }
            }
            else
            {
                PopupMessage.ShowInfoMessage("Invalid Entries. Please verify!");
                this.Focus();
            }
        }

        private bool ValidateInputs()
        {
            var isValid = true;
            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                isValid = false;
                errorProvider1.SetError(tbPassword, "Required");
            }
            else
            {
                errorProvider1.SetError(tbPassword, string.Empty);
            }

            if (string.IsNullOrEmpty(tbUsername.Text))
            {
                isValid = false;
                errorProvider1.SetError(tbUsername, "Incorrect!");
            }
            else
            {
                errorProvider1.SetError(tbUsername, string.Empty);
            }
            if(!_isAnyUserInSystem && tbPassword.Text != tbConfirmPassword.Text)
            {
                isValid = false;
                errorProvider1.SetError(tbPassword, "Not same as Confirm Password!");
                errorProvider1.SetError(tbConfirmPassword, "Not same as Password!");
            }
            else
            {
                errorProvider1.SetError(tbPassword, string.Empty);
                errorProvider1.SetError(tbConfirmPassword, string.Empty);
            }
            return isValid;
        }
    }
}
