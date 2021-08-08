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

namespace IMS.Forms.Inventory.Settings.General
{
    public partial class PasswordEditForm : Form
    {
        private readonly IUserService _userService;
        
        public PasswordEditForm(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();

            this.Load += ProfileEditForm_Load;
        }

        private void ProfileEditForm_Load(object sender, EventArgs e)
        {
            tbUsername.Text = UserSession.User.Username;
            tbUsername.Enabled = false;
            tbNewPassword.Focus();
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
                    Password = tbNewPassword.Text,
                    ConfirmPassword = tbConfirmPassword.Text,
                    OldPassword = tbOldPassword.Text,
                };
                var success = false;
                // save the password
                var isAuthorized = _userService.Authenticate(tbUsername.Text, tbOldPassword.Text);
                if(isAuthorized == null)
                {
                    PopupMessage.ShowInfoMessage("Invalid password!");
                    this.Focus();
                    return;
                }
                success = _userService.SavePassword(model);
                if (success)
                {
                    PopupMessage.ShowSuccessMessage("Password updated successfully!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    PopupMessage.ShowInfoMessage("Couldn't update password!");
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
            if (tbConfirmPassword.Text != tbNewPassword.Text)
            {
                isValid = false;
                errorProvider1.SetError(tbConfirmPassword, "Confirm Password should be equal to Password");
                errorProvider1.SetError(tbNewPassword, "Confirm Password should be equal to Password");
            }
            else
            {
                errorProvider1.SetError(tbConfirmPassword, string.Empty);
                errorProvider1.SetError(tbNewPassword, string.Empty);
            }
            if (string.IsNullOrEmpty(tbConfirmPassword.Text))
            {
                isValid = false;
                errorProvider1.SetError(tbConfirmPassword, "Required");
            }
            else
            {
                errorProvider1.SetError(tbConfirmPassword, string.Empty);
            }

            if (string.IsNullOrEmpty(tbNewPassword.Text))
            {
                isValid = false;
                errorProvider1.SetError(tbNewPassword, "Required");
            }
            else
            {
                errorProvider1.SetError(tbNewPassword, string.Empty);
            }
            
            return isValid;
        }



    }
}
