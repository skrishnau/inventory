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

namespace IMS.Forms.Inventory.Settings.Companies
{
    public partial class CompanySettingsUC : UserControl
    {
        private readonly IAppSettingService _appSettingService;

        public CompanySettingsUC(IAppSettingService appSettingService)
        {
            this._appSettingService = appSettingService;
            InitializeComponent();

            this.Load += CompanySettingsUC_Load;
        }

        private void CompanySettingsUC_Load(object sender, EventArgs e)
        {
            PopulateCompanyInfoSetting();

            btnSave.Click += BtnSave_Click;
        }

        private void PopulateCompanyInfoSetting()
        {
            var companysetting = _appSettingService.GetCompanyInfoSetting();
            tbAddress.Text = companysetting.Address;
            tbCompanyName.Text = companysetting.CompanyName;
            tbOwner.Text = companysetting.OwnerName;
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
                OwnerName = tbOwner.Text,
                PANNo = tbPAN.Text,
                Phone = tbPhone.Text,
                VATNo = tbVAT.Text,
                Website = tbWebsite.Text,
            };

            if (_appSettingService.SaveCompanyInfoSetting(companyInfoSettingModel))
                PopupMessage.ShowPopupMessage("Update Success", "Company Setting Successfully Updated", PopupMessageType.SUCCESS);
        }
    }
}
