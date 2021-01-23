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
using Service.Listeners;

namespace IMS.Forms.Inventory.Reports
{
    public partial class ReportsUC : UserControl
    {
        private readonly IReportService _reportService;
        private readonly IUserService _userService;
        private readonly IDatabaseChangeListener _listener;

        public ReportsUC(IReportService reportService, IUserService userService, IDatabaseChangeListener listener)
        {
            this._reportService = reportService;
            this._userService = userService;
            _listener = listener;

            InitializeComponent();

            this.Load += ReportsUC_Load;
            this.Dock = DockStyle.Fill;
        }

        private void ReportsUC_Load(object sender, EventArgs e)
        {
            this.bodyTemplate.SubHeadingText = "";
            var sidebarUc = new ReportSidebarUC();
            this.bodyTemplate.pnlSideBar.Controls.Add(sidebarUc);

           // sidebarUc.btnLedger.Click += BtnLedger_Click;
        }

        //private void BtnLedger_Click(object sender, EventArgs e)
        //{
        //    var ledgerUc = new LedgerUC(_reportService, _userService, _listener);
        //    this.bodyTemplate.SubHeadingText = "Ledger";
        //    this.bodyTemplate.pnlBody.Controls.Add(ledgerUc);
        //}
    }
}
