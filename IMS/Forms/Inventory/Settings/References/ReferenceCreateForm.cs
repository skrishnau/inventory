using IMS.Forms.Common;
using IMS.Forms.Common.Base;
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
using ViewModel.Enums;

namespace IMS.Forms.Inventory.Settings.References
{
    public partial class ReferenceCreateForm : BaseDialogForm
    {
        private readonly IAppSettingService _appSettingService;

        private ReferencesTypeEnum _type { get; set; }

        public ReferenceCreateForm(IAppSettingService appSettingService)
        {
            _appSettingService = appSettingService;

            InitializeComponent();

            this.Load += ReferenceCreateForm_Load;

        }
        public void SetData(ReferencesTypeEnum type)
        {
            _type = type;
        }

        private void ReferenceCreateForm_Load(object sender, EventArgs e)
        {
            PopulateBillSetting();
            btnSave.Click += BtnSave_Click;
            //btnCancel.Click += BtnCancel_Click;
            
            tbSaleBody.TextChanged += TbSale_TextChanged;
            tbSalePrefix.TextChanged += TbSale_TextChanged;
            tbSaleSuffix.TextChanged += TbSale_TextChanged;
            
        }

        private void PopulateBillSetting()
        {
            this.Text = _type.ToString() + " Receipts";
            var saleBillsetting = _appSettingService.GetBillSettings(_type);
            tbSaleBody.Text = saleBillsetting.Body;
            tbSalePrefix.Text = saleBillsetting.Prefix;
            tbSaleSuffix.Text = saleBillsetting.Suffix;
            TbSale_TextChanged(this, null);
            
        }

        private void TbSale_TextChanged(object sender, EventArgs e)
        {
            var billSettings = new BillSettingsModel
            {
                Body = tbSaleBody.Text,
                Type = _type,
                Prefix = tbSalePrefix.Text,
                Suffix = tbSaleSuffix.Text,
            };
            lblSaleReceiptsExample.Text = "Preview: \n";
            lblSaleReceiptsExample.Text += _appSettingService.GetReceiptNumber(billSettings, 1) + "\n";
            lblSaleReceiptsExample.Text += _appSettingService.GetReceiptNumber(billSettings, 2) + "\n";
            lblSaleReceiptsExample.Text += _appSettingService.GetReceiptNumber(billSettings, 3) + "\n";
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(this, "This will reset the current counter to zero. Are you sure to save?", "Save", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var saleBillSetting = new BillSettingsModel()
                {
                    Body = tbSaleBody.Text,
                    Prefix = tbSalePrefix.Text,
                    Suffix = tbSaleSuffix.Text,
                    Type = _type,
                };
                var list = new List<BillSettingsModel> {  saleBillSetting};
                if (_appSettingService.SaveBillSetting(list))
                {
                    PopupMessage.ShowSaveSuccessMessage();
                    this.Close();
                }
                else
                    PopupMessage.ShowErrorMessage("Couldn't save");
                this.Focus();
            }
        }
    }
}
