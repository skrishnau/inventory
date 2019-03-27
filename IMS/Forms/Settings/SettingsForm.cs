using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infrastructure.Context;
using Service.Core.Settings;
using ViewModel.Core.Settings;

namespace IMS.Forms.Settings
{
    public partial class SettingsForm : Form
    {
        private readonly IAppSettingService appSettingService;
        public SettingsForm()
        {
            InitializeComponent();
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
                Value = cbThemes.Text
            };
            appSettingService.SaveAppSetting(appsettingModel);
            
        }
    }
}
