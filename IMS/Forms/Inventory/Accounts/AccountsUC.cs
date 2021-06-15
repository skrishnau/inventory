using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Forms.Inventory.Reports.All;
using Service.Core.Reports;
using Service.Core.Users;
using Service.Core.Payment;
using Service.Listeners;
using Service.Core.Settings;
using IMS.Forms.Inventory.Accounts.All;
using IMS.Forms.Common;
using ViewModel.Utility;

namespace IMS.Forms.Inventory.Reports
{
    public partial class AccountsUC : BaseUserControl
    {
        //private readonly IUserService _userService;
        //private readonly IPaymentService _paymentService;
        //private readonly IReportService _reportService;
        //private readonly IAppSettingService _appSettingService;

        private BaseUserControl _currentTab;

        private readonly ProfitAndLossUC _profitAndLossUC;
        private readonly PaymentListUC _paymentListUC;
        private readonly LedgerUC _ledgerUC;
        private readonly AccountsSidebarUC sidebarUc;
        private readonly ProductLedgerUC _productLedgerUC;

        public AccountsUC(//IUserService userService, IReportService reportService, IPaymentService paymentService, IDatabaseChangeListener databaseChangeListener, IAppSettingService appSettingService,
            ProfitAndLossUC profitAndLossUC, PaymentListUC paymentListUC, LedgerUC ledgerUC, AccountsSidebarUC sidebarUC, ProductLedgerUC productLedgerUC)
        {
            //this._userService = userService;
            //this._paymentService = paymentService;
            //this._reportService = reportService;
            //this._databaseChangeListener = databaseChangeListener;
            //this._appSettingService = appSettingService;

            _profitAndLossUC = profitAndLossUC;
            _paymentListUC = paymentListUC;
            _ledgerUC = ledgerUC;
            this.sidebarUc = sidebarUC;
            _productLedgerUC = productLedgerUC;

            

            InitializeComponent();

            this.Load += AccountsUC_Load;
            this.Dock = DockStyle.Fill;
        }
        public override void ExecuteActions()
        {
            if (_currentTab != null)
            {
                _currentTab.ExecuteActions();
            }
        }

        private void AccountsUC_Load(object sender, EventArgs e)
        {
            _profitAndLossUC.MyTabTitle = MyTabTitle;
            _profitAndLossUC.MySubTabTitle = Constants.NAME_PROFIT_AND_LOSS;
            _ledgerUC.MyTabTitle = MyTabTitle;
            _ledgerUC.MySubTabTitle = Constants.NAME_LEDGER;
            _paymentListUC.MyTabTitle = MyTabTitle;
            _paymentListUC.MySubTabTitle = Constants.NAME_PAYMENT_LIST;
            _productLedgerUC.MyTabTitle = MyTabTitle;
            _productLedgerUC.MySubTabTitle = Constants.NAME_PRODUCT_LEDGER;

            this.bodyTemplate.SubHeadingText = "";
            this.bodyTemplate.pnlSideBar.Controls.Add(sidebarUc);

            sidebarUc.btnPayments.Click += BtnPayments_Click;
            sidebarUc.btnLedger.Click += BtnLedger_Click;
            sidebarUc.btnProductLedger.Click += BtnProductLedger_Click;
            sidebarUc.btnProfitAndLoss.Click += BtnProfitAndLoss_Click;
            BtnPayments_Click(sidebarUc.btnPayments, null);
        }


        private void BtnProfitAndLoss_Click(object sender, EventArgs e)
        {
            _currentTab = _profitAndLossUC;
            _currentTab.ExecuteActions();
            InventoryUC.CurrentSubTabTitle = _currentTab.MySubTabTitle;
            this.bodyTemplate.pnlBody.Controls.Clear();
            sidebarUc.SetVisited(sender);
            //var ledgerUc = new ProfitAndLossUC(_reportService, _userService, _appSettingService, _databaseChangeListener);
            this.bodyTemplate.SubHeadingText = "Profit and Loss";
            this.bodyTemplate.pnlBody.Controls.Add(_profitAndLossUC);
        }

        private void BtnPayments_Click(object sender, EventArgs e)
        {
            _currentTab = _paymentListUC;
            _currentTab.ExecuteActions();
            InventoryUC.CurrentSubTabTitle = _currentTab.MySubTabTitle;
            this.bodyTemplate.pnlBody.Controls.Clear();
            sidebarUc.SetVisited(sender);
            //var paymentsUc = new PaymentListUC(_paymentService, _userService, _databaseChangeListener);
            this.bodyTemplate.SubHeadingText = "Payments";
            this.bodyTemplate.pnlBody.Controls.Add(_paymentListUC);
        }

        private void BtnLedger_Click(object sender, EventArgs e)
        {
            _currentTab = _ledgerUC;
            _currentTab.ExecuteActions();
            InventoryUC.CurrentSubTabTitle = _currentTab.MySubTabTitle;
            this.bodyTemplate.pnlBody.Controls.Clear();
            sidebarUc.SetVisited(sender);
            //var ledgerUc = new LedgerUC(_reportService, _userService, _appSettingService, _databaseChangeListener);
            this.bodyTemplate.SubHeadingText = "Ledger";
            this.bodyTemplate.pnlBody.Controls.Add(_ledgerUC);
        }

        private void BtnProductLedger_Click(object sender, EventArgs e)
        {
            _currentTab = _productLedgerUC;
            _currentTab.ExecuteActions();
            InventoryUC.CurrentSubTabTitle = _currentTab.MySubTabTitle;
            this.bodyTemplate.pnlBody.Controls.Clear();
            sidebarUc.SetVisited(sender);
            this.bodyTemplate.SubHeadingText = "Product Ledger";
            this.bodyTemplate.pnlBody.Controls.Add(_productLedgerUC);
        }
    }
}
