using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Core.Reports;
using Service.Core.Users;
using Service.Core.Settings;
using Service.Listeners;
using ViewModel.Core.Reports;
using IMS.Forms.Common;

namespace IMS.Forms.Inventory.Accounts.All
{
    public partial class ProfitAndLossUC : BaseUserControl
    {
        private readonly IReportService _reportService;
        private readonly IUserService _userService;
        private readonly IAppSettingService _appSettingService;
        private readonly IDatabaseChangeListener _listener;

        private ProfitAndLossMasterModel _ledgerMaster = new ProfitAndLossMasterModel();
        private ProfitAndLossMasterModel _ledgerMasterForPrint = new ProfitAndLossMasterModel();

        BindingSource _bindingSource;
        public ProfitAndLossUC(IReportService reportService, IUserService userService, IAppSettingService appSettingService, IDatabaseChangeListener listener)
        {
            _reportService = reportService;
            _userService = userService;
            _appSettingService = appSettingService;
            _listener = listener;

            InitializeComponent();

            this.Load += LedgerUC_Load;
            this.Dock = DockStyle.Fill;
        }

        private void LedgerUC_Load(object sender, EventArgs e)
        {
            _bindingSource = new BindingSource();
            dgvLedger.DataSource = _bindingSource;
            dgvLedger.AutoGenerateColumns = false;
            dtFrom.SetValue(DateTime.Now);// (DateTime.Now.AddDays(-7));
            dtTo.SetValue(DateTime.Now);

            InitializeEvents();
            PopulateProfitAndLoss();

        }

        private void InitializeEvents()
        {
            btnSearch.Click += BtnSearch_Click;
            dgvLedger.DataBindingComplete += DgvLedger_DataBindingComplete;
            _listener.OrderUpdated += _listener_OrderUpdated;
            btnPrint.Click += BtnPrint_Click;
            chkYearlyData.CheckedChanged += ChkYearlyData_CheckedChanged;
        }

        private void ChkYearlyData_CheckedChanged(object sender, EventArgs e)
        {
            var check = chkYearlyData.Checked;
            dtFrom.Enabled = !check;
            dtTo.Enabled = !check;
        }

        private void _listener_OrderUpdated(object sender, Service.DbEventArgs.BaseEventArgs<ViewModel.Core.Orders.OrderModel> e)
        {
           AddListenerAction(PopulateProfitAndLoss, e);
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            //var ledgerMaster = GetLedger();
            //if (_ledgerMasterForPrint != null)
            //{
            //    var form = new LedgerPrintForm(_appSettingService, _ledgerMasterForPrint);
            //    form.ShowDialog();
            //}
            //else
            //{
            //    PopupMessage.ShowInfoMessage("Empty ledger!");
            //}
            PopupMessage.ShowInfoMessage("Not implemented yet!");
        }

        private void DgvLedger_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvLedger.DataBindingComplete -= DgvLedger_DataBindingComplete;
            int rowIndex = dgvLedger.Rows.GetLastRow(DataGridViewElementStates.Visible);
            if (rowIndex > 0)
            {
                dgvLedger.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                dgvLedger.Rows[rowIndex].DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                //dgvLedger.Rows[rowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);//
                // make bold if Dr
            }
            dgvLedger.DataBindingComplete += DgvLedger_DataBindingComplete;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            PopulateProfitAndLoss();
        }

        private ProfitAndLossMasterModel GetProfitAndLoss()
        {
            var from = dtFrom.GetValue();
            var to = dtTo.GetValue();
            var model = new ProfitAndLossRequestModel
            {
                From = from,
                To = to,
                YearlyData = chkYearlyData.Checked,
            };
            return _reportService.GetProfitAndLoss(model);
        }

        private void PopulateProfitAndLoss()
        {
            _ledgerMaster = GetProfitAndLoss();
            _ledgerMasterForPrint = GetProfitAndLoss();

            if (_ledgerMaster != null)
            {
                _ledgerMaster.ProfitAndLossData.Add(new ProfitAndLossModel()
                {
                    IsManualNewRow = true,
                    Balance = _ledgerMaster.BalanceSum,
                    Revenue = _ledgerMaster.RevenueSum,
                    Expense = _ledgerMaster.ExpenseSum,
                    ProfitLoss = _ledgerMaster.ProfitLoss,
                    ProfitLossString = _ledgerMaster.ProfitLossString,
                    Particulars = "Total"
                });
                _bindingSource.DataSource = _ledgerMaster.ProfitAndLossData;
                _bindingSource.ResetBindings(false);
            }
            else
            {
                _bindingSource.DataSource = null;
                _bindingSource.ResetBindings(false);
            }
        }

    }
}
