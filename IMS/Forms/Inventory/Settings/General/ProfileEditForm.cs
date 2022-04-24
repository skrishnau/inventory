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
    public partial class ProfileEditForm : Form
    {
        private readonly IAppSettingService _appSettingService;
        public ProfileEditForm(IAppSettingService appSettingService)
        {
            this._appSettingService = appSettingService;
            InitializeComponent();

            this.Load += ProfileEditForm_Load;
        }

        private void ProfileEditForm_Load(object sender, EventArgs e)
        {
            PopulateCompanyInfoSetting();

            // events should be at the last
            btnSaveProfile.Click += BtnSave_Click;
        }

        private void PopulateCompanyInfoSetting()
        {
            var companysetting = _appSettingService.GetCompanyInfoSetting();
            tbAddress.Text = companysetting.Address;
            tbCompanyName.Text = companysetting.CompanyName;
            tbVAT.Text = companysetting.VATNo;
            tbPAN.Text = companysetting.PANNo;
            tbPhone.Text = companysetting.Phone;
            tbEmail.Text = companysetting.Email;
            tbWebsite.Text = companysetting.Website;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var companyInfoSettingModel = new CompanyInfoSettingModel()
            {
                Address = tbAddress.Text,
                CompanyName = tbCompanyName.Text,
                Email = tbEmail.Text,
                PANNo = tbPAN.Text,
                Phone = tbPhone.Text,
                VATNo = tbVAT.Text,
                Website = tbWebsite.Text,
            };

            if (_appSettingService.SaveCompanyInfoSetting(companyInfoSettingModel))
            {
                PopupMessage.ShowPopupMessage("Update Success", "Company Setting Successfully Updated", PopupMessageType.SUCCESS);
                this.Close();
            }else
            {
                PopupMessage.ShowErrorMessage("Couldn't Save!");
            }
        }
    }
}
