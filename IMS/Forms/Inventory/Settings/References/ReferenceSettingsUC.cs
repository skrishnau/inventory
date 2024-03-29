﻿using System;
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

            tbPaymentBody.TextChanged += TbPayment_TextChanged;
            tbPaymentPrefix.TextChanged += TbPayment_TextChanged;
            tbPaymentSuffix.TextChanged += TbPayment_TextChanged;
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
                Type = ReferencesTypeEnum.Purchase,
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
                Type = ReferencesTypeEnum.Sale,
                Prefix = tbSalePrefix.Text,
                Suffix = tbSaleSuffix.Text,
            };
            lblSaleReceiptsExample.Text = "Preview: \n";
            lblSaleReceiptsExample.Text += _appSettingService.GetReceiptNumber(billSettings, 1) + "\n";
            lblSaleReceiptsExample.Text += _appSettingService.GetReceiptNumber(billSettings, 2) + "\n";
            lblSaleReceiptsExample.Text += _appSettingService.GetReceiptNumber(billSettings, 3) + "\n";
        }


        private void TbPayment_TextChanged(object sender, EventArgs e)
        {
            var billSettings = new BillSettingsModel
            {
                Body = tbPaymentBody.Text,
                Type = ReferencesTypeEnum.Sale,
                Prefix = tbPaymentPrefix.Text,
                Suffix = tbPaymentSuffix.Text,
            };
            lblPaymentReceiptsExample.Text = "Preview: \n";
            lblPaymentReceiptsExample.Text += _appSettingService.GetReceiptNumber(billSettings, 1) + "\n";
            lblPaymentReceiptsExample.Text += _appSettingService.GetReceiptNumber(billSettings, 2) + "\n";
            lblPaymentReceiptsExample.Text += _appSettingService.GetReceiptNumber(billSettings, 3) + "\n";
        }

        #endregion

        private void PopulateBillSetting()
        {
            var saleBillsetting = _appSettingService.GetBillSettings(ReferencesTypeEnum.Sale);
            tbSaleBody.Text = saleBillsetting.Body;
            tbSalePrefix.Text = saleBillsetting.Prefix;
            tbSaleSuffix.Text = saleBillsetting.Suffix;
            TbSale_TextChanged(this, null);

            var purchaseBillsetting = _appSettingService.GetBillSettings(ReferencesTypeEnum.Purchase);
            tbPurchaseBody.Text = purchaseBillsetting.Body;
            tbPurchasePrefix.Text = purchaseBillsetting.Prefix;
            tbPurchaseSuffix.Text = purchaseBillsetting.Suffix;
            TbPurchase_TextChanged(this, null);

            var paymentBillsetting = _appSettingService.GetBillSettings(ReferencesTypeEnum.Payment);
            tbPaymentBody.Text = paymentBillsetting.Body;
            tbPaymentPrefix.Text = paymentBillsetting.Prefix;
            tbPaymentSuffix.Text = paymentBillsetting.Suffix;
            TbPayment_TextChanged(this, null);
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
                    Type = ReferencesTypeEnum.Purchase,
                };
                var saleBillSetting = new BillSettingsModel()
                {
                    Body = tbSaleBody.Text,
                    Prefix = tbSalePrefix.Text,
                    Suffix = tbSaleSuffix.Text,
                    Type = ReferencesTypeEnum.Sale,
                };
                var paymentBillSetting = new BillSettingsModel
                {
                    Body = tbPaymentBody.Text,
                    Prefix = tbPaymentPrefix.Text,
                    Suffix = tbPaymentSuffix.Text,
                    Type = ReferencesTypeEnum.Payment,
                };
                var list = new List<BillSettingsModel> { purchaseBillSetting, saleBillSetting , paymentBillSetting};
                if (_appSettingService.SaveBillSetting(list))
                    PopupMessage.ShowSaveSuccessMessage();
                else
                    PopupMessage.ShowErrorMessage("Couldn't save");
                this.Focus();
            }
        }
    }
}
