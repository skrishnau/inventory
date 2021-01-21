using IMS.Forms.Common;
using Service.Core.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Core.Settings;

namespace IMS.Forms.Inventory.Settings.General
{
    public partial class PasswordEditForm : Form
    {
        private readonly IAppSettingService _appSettingService;

        private PasswordModel _passwordModel;

        private bool _editMode;
        private bool _authMode;

        public PasswordEditForm(IAppSettingService appSettingService)
        {
            this._appSettingService = appSettingService;
            InitializeComponent();

            this.Load += ProfileEditForm_Load;
        }

        public void SetData(bool editMode, bool authMode)
        {
            _editMode = editMode;
            _authMode = authMode;
        }

        private void ProfileEditForm_Load(object sender, EventArgs e)
        {
            PopulatePassword();
            btnSaveProfile.Click += BtnSave_Click;

        }

        private void PopulatePassword()
        {
            _passwordModel = _appSettingService.GetPassword();
            //tbPassword.Text = companysetting.Password;
            tbUsername.Text = _passwordModel.Username;
            //tbConfirmPassword.Text = companysetting.VATNo;
            //tbOldPassword.Text = companysetting.PANNo;
            if (_authMode)
            {
                if (!string.IsNullOrEmpty(_passwordModel.Username))
                {
                    // authenticate
                    tbConfirmPassword.Visible = false;
                    tbOldPassword.Visible = false;
                    lblOldPassword.Visible = false;
                    lblConfirmPassword.Visible = false;
                    this.Text = "Login";
                    this.Height = 144; // small size cause confirmpassword and old password are not shown
                }
                else
                {
                    tbOldPassword.Visible = false;
                    lblOldPassword.Visible = false;
                    this.Height = 174; // hide old password section
                }
            }
            

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
                var passwordModel = new PasswordModel()
                {
                    Username = tbUsername.Text,
                    Password = tbPassword.Text,
                    ConfirmPassword = tbConfirmPassword.Text,
                    OldPassword = tbConfirmPassword.Text,
                };
                var success = false;
                if(_authMode && string.IsNullOrEmpty(_passwordModel.Username))
                {
                    _editMode = true;
                }
                if (_editMode)
                {
                    // save the password
                    success = _appSettingService.SavePassword(passwordModel);
                    if (success)
                        PopupMessage.ShowSuccessMessage("Password saved Successfully");
                }
                else if(_authMode)
                {
                    // validate the password
                     success = tbPassword.Text == _passwordModel.Password && tbUsername.Text == _passwordModel.Username;
                    if (success)
                        PopupMessage.ShowSuccessMessage("Login success!");
                    else
                        PopupMessage.ShowInfoMessage("Couldn't authenticate. Check again");
                }
                this.Focus();
                if (success)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
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
            if (_editMode && tbConfirmPassword.Text != tbPassword.Text)
            {
                isValid = false;
                errorProvider1.SetError(tbConfirmPassword, "Confirm Password should be equal to Password");
                errorProvider1.SetError(tbPassword, "Confirm Password should be equal to Password");
            }
            else
            {
                errorProvider1.SetError(tbConfirmPassword, string.Empty);
                errorProvider1.SetError(tbPassword, string.Empty);
            }
            if (_editMode && string.IsNullOrEmpty(tbConfirmPassword.Text))
            {
                isValid = false;
                errorProvider1.SetError(tbConfirmPassword, "Required");
            }
            else
            {
                errorProvider1.SetError(tbConfirmPassword, string.Empty);
            }

            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                isValid = false;
                errorProvider1.SetError(tbPassword, "Required");
            }
            else
            {
                errorProvider1.SetError(tbPassword, string.Empty);
            }

            if (_editMode && !string.IsNullOrEmpty(_passwordModel.Password) && tbOldPassword.Text != _passwordModel.Password)
            {
                isValid = false;
                errorProvider1.SetError(tbOldPassword, "Incorrect!");
            }
            else
            {
                errorProvider1.SetError(tbOldPassword, string.Empty);
            }

            if (!string.IsNullOrEmpty(_passwordModel.Username) && tbUsername.Text != _passwordModel.Username)
            {
                isValid = false;
                errorProvider1.SetError(tbUsername, "Incorrect!");
            }
            else
            {
                errorProvider1.SetError(tbUsername, string.Empty);
            }
            return isValid;
        }
    }
}
