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
using ViewModel.Enums;
using IMS.Forms.Common;

namespace IMS.Forms.Inventory.Settings.References
{
    public partial class ReferenceSettingsUC : UserControl
    {
        private readonly IAppSettingService _appSettingService;

        public ReferenceSettingsUC(IAppSettingService appSettingService)
        {
            this._appSettingService = appSettingService;
            InitializeComponent();

            this.Load += ReferenceSettingsUC_Load;
        }

        private void ReferenceSettingsUC_Load(object sender, EventArgs e)
        {
            PopulateBillSetting();
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;

            tbPurchaseBody.TextChanged += TbPurchase_TextChanged;
            tbPurchasePrefix.TextChanged += TbPurchase_TextChanged;
            tbPurchaseSuffix.TextChanged += TbPurchase_TextChanged;

            tbSaleBody.TextChanged += TbSale_TextChanged;
            tbSalePrefix.TextChanged += TbSale_TextChanged;
            tbSaleSuffix.TextChanged += TbSale_TextChanged;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            PopulateBillSetting();
        }


        #region Event Handlers

        private void TbPurchase_TextChanged(object sender, EventArgs e)
        {
            var billSettings = new BillSettingsModel
            {
                Body = tbPurchaseBody.Text,
                OrderType = OrderTypeEnum.Purchase,
                Prefix = tbPurchasePrefix.Text,
                Suffix = tbPurchaseSuffix.Text,
            };
            lblPurchaseReceiptsExample.Text = "Preview: \n";
            lblPurchaseReceiptsExample.Text += _appSettingService.GetReceiptNumber(billSettings, 1) + "\n";
            lblPurchaseReceiptsExample.Text += _appSettingService.GetReceiptNumber(billSettings, 2) + "\n";
            lblPurchaseReceiptsExample.Text += _appSettingService.GetReceiptNumber(billSettings, 3) + "\n";
        }

        private void TbSale_TextChanged(object sender, EventArgs e)
        {
            var billSettings = new BillSettingsModel
            {
                Body = tbSaleBody.Text,
                OrderType = OrderTypeEnum.Sale,
                Prefix = tbSalePrefix.Text,
                Suffix = tbSaleSuffix.Text,
            };
            lblSaleReceiptsExample.Text = "Preview: \n";
            lblSaleReceiptsExample.Text += _appSettingService.GetReceiptNumber(billSettings, 1) + "\n";
            lblSaleReceiptsExample.Text += _appSettingService.GetReceiptNumber(billSettings, 2) + "\n";
            lblSaleReceiptsExample.Text += _appSettingService.GetReceiptNumber(billSettings, 3) + "\n";
        }

        #endregion

        private void PopulateBillSetting()
        {
            var saleBillsetting = _appSettingService.GetBillSettings(ViewModel.Enums.OrderTypeEnum.Sale);
            tbSaleBody.Text = saleBillsetting.Body;
            tbSalePrefix.Text = saleBillsetting.Prefix;
            tbSaleSuffix.Text = saleBillsetting.Suffix;
            TbSale_TextChanged(this, null);

            var purchaseBillsetting = _appSettingService.GetBillSettings(ViewModel.Enums.OrderTypeEnum.Purchase);
            tbPurchaseBody.Text = purchaseBillsetting.Body;
            tbPurchasePrefix.Text = purchaseBillsetting.Prefix;
            tbPurchaseSuffix.Text = purchaseBillsetting.Suffix;
            TbPurchase_TextChanged(this, null);

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(this, "This will reset the current counter to zero. Are you sure to save?", "Save", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                var purchaseBillSetting = new BillSettingsModel()
                {
                    Body = tbPurchaseBody.Text,
                    Prefix = tbPurchasePrefix.Text,
                    Suffix = tbPurchaseSuffix.Text,
                    OrderType = ViewModel.Enums.OrderTypeEnum.Purchase,
                };
                var saleBillSetting = new BillSettingsModel()
                {
                    Body = tbSaleBody.Text,
                    Prefix = tbSalePrefix.Text,
                    Suffix = tbSaleSuffix.Text,
                    OrderType = ViewModel.Enums.OrderTypeEnum.Sale,
                };
                var list = new List<BillSettingsModel> { purchaseBillSetting, saleBillSetting };
                if (_appSettingService.SaveBillSetting(list))
                    PopupMessage.ShowSaveSuccessMessage();
                else
                    PopupMessage.ShowErrorMessage("Couldn't save");
                this.Focus();
            }
        }
    }
}
