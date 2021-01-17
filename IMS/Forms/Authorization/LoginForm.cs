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

namespace IMS.Forms.Authorization
{
    public partial class LoginForm : Form
    {
        string _password;

        private readonly IAppSettingService _appSettingService;

        public LoginForm(IAppSettingService appSettingService)
        {
            _appSettingService = appSettingService;

            InitializeComponent();

            this.Load += LoginForm_Load;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            InitializeEvents();

            InitializePassword();
        }

        private void InitializePassword()
        {
            _password = _appSettingService.GetPassword();
        }

        private void InitializeEvents()
        {
            btnOk.Click += BtnOk_Click;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Authenticate();
        }

        private void Authenticate()
        {
            var success = false;
            if (string.IsNullOrEmpty(_password))
            {
                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    // save the password
                    success = _appSettingService.SavePassword(txtPassword.Text);
                    if(success)
                        PopupMessage.ShowSuccessMessage("Password saved Successfully");
                }
                else
                {
                    PopupMessage.ShowInfoMessage("Please enter password");
                    errorProvider1.SetError(txtPassword, "Required");
                }
            }
            else
            {
                // validate the password
                success = txtPassword.Text == _password;
                if(success)
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
    }
    
}
