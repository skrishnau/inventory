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

namespace IMS.Forms.Inventory.Reports
{
    public partial class AccountsUC : UserControl
    {
        private readonly IUserService _userService;
        private readonly IPaymentService _paymentService;
        private readonly IReportService _reportService;
        private readonly IDatabaseChangeListener _databaseChangeListener;
        private readonly IAppSettingService _appSettingService;

        public AccountsUC(IUserService userService, IReportService reportService, IPaymentService paymentService, IDatabaseChangeListener databaseChangeListener, IAppSettingService appSettingService)
        {
            this._userService = userService;
            this._paymentService = paymentService;
            this._reportService = reportService;
            this._databaseChangeListener = databaseChangeListener;
            this._appSettingService = appSettingService;

            InitializeComponent();

            this.Load += AccountsUC_Load;
            this.Dock = DockStyle.Fill;
        }

        private void AccountsUC_Load(object sender, EventArgs e)
        {
            this.bodyTemplate.SubHeadingText = "";
            var sidebarUc = new AccountsSidebarUC();
            this.bodyTemplate.pnlSideBar.Controls.Add(sidebarUc);

            sidebarUc.btnPayments.Click += BtnPayments_Click;
            sidebarUc.btnLedger.Click += BtnLedger_Click;
            sidebarUc.btnProfitAndLoss.Click += BtnProfitAndLoss_Click;

        }

        private void BtnProfitAndLoss_Click(object sender, EventArgs e)
        {
            this.bodyTemplate.pnlBody.Controls.Clear();
            var ledgerUc = new ProfitAndLossUC(_reportService, _userService, _appSettingService, _databaseChangeListener);
            this.bodyTemplate.SubHeadingText = "Profit and Loss";
            this.bodyTemplate.pnlBody.Controls.Add(ledgerUc);
        }

        private void BtnPayments_Click(object sender, EventArgs e)
        {
            this.bodyTemplate.pnlBody.Controls.Clear();
            var paymentsUc = new PaymentListUC(_paymentService, _userService, _databaseChangeListener);
            this.bodyTemplate.SubHeadingText = "Payments";
            this.bodyTemplate.pnlBody.Controls.Add(paymentsUc);
        }

        private void BtnLedger_Click(object sender, EventArgs e)
        {
            this.bodyTemplate.pnlBody.Controls.Clear();
            var ledgerUc = new LedgerUC(_reportService, _userService, _appSettingService, _databaseChangeListener);
            this.bodyTemplate.SubHeadingText = "Ledger";
            this.bodyTemplate.pnlBody.Controls.Add(ledgerUc);
        }
    }
}
