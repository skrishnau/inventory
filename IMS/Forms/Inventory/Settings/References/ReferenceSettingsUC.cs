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

namespace IMS.Forms.Inventory.Settings.References
{
    public partial class ReferenceSettingsUC : UserControl
    {
        private readonly IAppSettingService appSettingService;

        public ReferenceSettingsUC(IAppSettingService appSettingService)
        {
            this.appSettingService = appSettingService;
            InitializeComponent();

            this.Load += ReferenceSettingsUC_Load;
        }

        private void ReferenceSettingsUC_Load(object sender, EventArgs e)
        {
            PopulateBillSetting();

            btnSave.Click += BtnSave_Click;
        }



        private void PopulateBillSetting()
        {
            var billsetting = appSettingService.GetBillSettings();
            tbEnd.Text = billsetting.EndNumber.ToString();
            tbPrefix.Text = billsetting.Prefix;
            tbStart.Text = billsetting.StartNumber.ToString();
            tbSuffix.Text = billsetting.Suffix;
        }

        private void BtnSave_Click(object sender, EventArgs e)
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
    }
}
