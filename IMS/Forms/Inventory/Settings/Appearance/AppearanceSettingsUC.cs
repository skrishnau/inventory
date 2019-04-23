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

namespace IMS.Forms.Inventory.Settings.Appearance
{
    public partial class AppearanceSettingsUC : UserControl
    {
        private readonly IAppSettingService appSettingService;

        public AppearanceSettingsUC(IAppSettingService appSettingService)
        {
            this.appSettingService = appSettingService;
            InitializeComponent();

            this.Load += AppearanceSettingsUC_Load;
        }

        private void AppearanceSettingsUC_Load(object sender, EventArgs e)
        {
            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cbThemes.Text == "")
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
    }
}
