using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Forms.Common;
using Infrastructure.Context;
using Service.Core.Settings;
using ViewModel.Core.Settings;

namespace IMS.Forms.Settings
{
    public partial class SettingsForm : Form
    {
        private readonly IAppSettingService appSettingService;

        public SettingsForm(IAppSettingService appSettingService)
        {
            this.appSettingService = appSettingService;
            InitializeComponent();

            this.Load += SettingsForm_Load;

           
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            PopulateBillSetting();
            PopulateCompanyInfoSetting();
        }

        private void PopulateBillSetting()
        {
            var billsetting = appSettingService.GetBillSettings();
            tbEnd.Text = billsetting.EndNumber.ToString();
            tbPrefix.Text = billsetting.Prefix;
            tbStart.Text = billsetting.StartNumber.ToString();
            tbSuffix.Text = billsetting.Suffix;
        }


        private void PopulateCompanyInfoSetting()
        {
            var companysetting = appSettingService.GetCompanyInfoSetting();
            tbAddress.Text = companysetting.Address;
            tbCompanyName.Text = companysetting.CompanyName;
            tbOwner.Text = companysetting.OwnerName;
            tbVAT.Text = companysetting.VATNo;
            tbPAN.Text = companysetting.PANNo;
            tbPhone.Text = companysetting.Phone;
            tbEmail.Text = companysetting.Email;
            tbWebsite.Text = companysetting.Website;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if(cbThemes.Text == "")
            {
                cbThemes.BackColor = Color.LightPink;
                return;
            }
            var appsettingModel = new AppSettingModel()
            {
                DisplayName = "Themes",
                Name = "Themes",
                Group = "Themes",
                Value = cbThemes.Text
            };

            if (appSettingService.SaveAppSetting(appsettingModel))
                MessageBox.Show("Themes setting updated!!!");
            
        }

        private void btnBillSettingSave_Click(object sender, EventArgs e)
        {
            var billsettingmodel = new BillSettingsModel()
            {
                EndNumber = Int32.Parse(tbEnd.Text),
                Prefix = tbPrefix.Text,
                StartNumber = Int32.Parse(tbStart.Text),
                Suffix = tbSuffix.Text
            };
            if (appSettingService.SaveBillSetting(billsettingmodel))
                MessageBox.Show("Bill setting updated!!!");
        }

        private void btnCloseSetting_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOwnerInfoSave_Click(object sender, EventArgs e)
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

            if (appSettingService.SaveCompanyInfoSetting(companyInfoSettingModel))
                PopupMessage.ShowPopupMessage("Update Success", "Company Setting Successfully Updated", PopupMessageType.SUCCESS);
        }
    }
}
