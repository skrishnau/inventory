using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Core.Settings;
using ViewModel.Core.Settings;
using IMS.Forms.Common;
using SimpleInjector.Lifestyles;

namespace IMS.Forms.Inventory.Settings.General
{
    public partial class ProfileUC : BaseUserControl
    {
        private readonly IAppSettingService _appSettingService;

        public ProfileUC(IAppSettingService appSettingService)
        {
            this._appSettingService = appSettingService;
            InitializeComponent();

            this.Load += GeneralSettingsUC_Load;
        }

        private void GeneralSettingsUC_Load(object sender, EventArgs e)
        {
           // btnSaveAppearance.Click += BtnSaveAppearance_Click;

            PopulateCompanyInfoSetting();

            // events should be at the last
            btnEdit.Click += BtnEdit_Click;
            btnChangePassword.Click += BtnChangePassword_Click;
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var form = Program.container.GetInstance<PasswordEditForm>();
                form.ShowDialog();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var form = Program.container.GetInstance<ProfileEditForm>();
                form.ShowDialog();
                PopulateCompanyInfoSetting();
            }
        }

        #region Profile

        private void PopulateCompanyInfoSetting()
        {
            var companysetting = _appSettingService.GetCompanyInfoSetting();
            tbAddress.Text = companysetting.Address;
            tbCompanyName.Text = companysetting.CompanyName;
            //tbOwner.Text = companysetting.OwnerName;
            tbVAT.Text = companysetting.VATNo;
            tbPAN.Text = companysetting.PANNo;
            tbPhone.Text = companysetting.Phone;
            tbEmail.Text = companysetting.Email;
            tbWebsite.Text = companysetting.Website;
        }

       

        #endregion
    }
}
