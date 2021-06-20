using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Core.Common;
using ViewModel.Utility;
using Service.Core.Settings;
using IMS.Forms.Common;

namespace IMS.Forms.Inventory.Settings.General
{
    public partial class PreferenceSettingsUC : BaseUserControl
    {
        private readonly IAppSettingService _appSettingService;

        List<NameValuePair> yesNoPairs = new List<NameValuePair>
        {
            new NameValuePair(Constants.YES, Constants.YES),
            new NameValuePair(Constants.NO, Constants.NO),
        };

        public void SetViewMode(bool editMode)
        {
            pnlFooter.Visible = editMode;
            pnlMenu.Visible = !editMode;
        }

        public PreferenceSettingsUC(IAppSettingService appSettingService)
        {
            _appSettingService = appSettingService;
            InitializeComponent();
            this.Load += GeneralSettingsUC_Load;
        }

        private void GeneralSettingsUC_Load(object sender, EventArgs e)
        {
            PopulateShowTransactionCreateFormInMaximizeMode();

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            PopulateShowTransactionCreateFormInMaximizeMode();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var value = cbShowTxnCreateFormInMaximizeMode.SelectedValue?.ToString();
            var showTxnCreateFormInMaximizeMode = false;
            if (value == Constants.YES)
                showTxnCreateFormInMaximizeMode = true;
            _appSettingService.SaveShowTransactionCreateInFullPage(showTxnCreateFormInMaximizeMode);
        }

        private async void PopulateShowTransactionCreateFormInMaximizeMode()
        {
            cbShowTxnCreateFormInMaximizeMode.DataSource = yesNoPairs;
            cbShowTxnCreateFormInMaximizeMode.DisplayMember = "Value";
            cbShowTxnCreateFormInMaximizeMode.ValueMember = "Name";
            var val = await _appSettingService.GetShowTransactionCreateInFullPage();
            var value = val ? Constants.YES : Constants.NO;
            cbShowTxnCreateFormInMaximizeMode.SelectedValue = value;
        }
    }
}
