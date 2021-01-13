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
using ViewModel.Core.Reports;

namespace IMS.Forms.Inventory.Reports.All
{
    public partial class LedgerUC : UserControl
    {
        private readonly IReportService _reportService;
        private readonly IUserService _userService;

        private List<LedgerModel> _ledgerList = new List<LedgerModel>();

        BindingSource _bindingSource;
        public LedgerUC(IReportService reportService, IUserService userService)
        {
            _reportService = reportService;
            _userService = userService;

            InitializeComponent();

            this.Load += LedgerUC_Load;
            this.Dock = DockStyle.Fill;
        }

        private void LedgerUC_Load(object sender, EventArgs e)
        {
            _bindingSource = new BindingSource();
            dgvLedger.DataSource = _bindingSource;

            dgvLedger.AutoGenerateColumns = false;
            dtFrom.Value = DateTime.Now.AddDays(-7);
            InitializeEvents();

            PopulateCustomer();
            PopulateLedger();

        }

        private void InitializeEvents()
        {
            btnSearch.Click += BtnSearch_Click;
            dgvLedger.DataBindingComplete += DgvLedger_DataBindingComplete;
        }

        private void DgvLedger_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvLedger.DataBindingComplete -= DgvLedger_DataBindingComplete;
            foreach (DataGridViewRow row in dgvLedger.Rows)
            {
                var data = row.DataBoundItem as LedgerModel;
                if (data != null)
                {
                    //row.Cells[colBalance.Index].ValueType = typeof(string);
                    //row.Cells[colBalance.Index].Value = data.DrCr < 0 ? $"({data.Balance})" : data.Balance.ToString();
                }
            }

            //If you want to do some formating on the footer row
            int rowIndex = dgvLedger.Rows.GetLastRow(DataGridViewElementStates.Visible);
            if (rowIndex <= 0)
            {
                return;
            }
            dgvLedger.Rows[rowIndex].Cells[colParticulars.Index].Value = "Total";
            dgvLedger.Rows[rowIndex].Cells[colDate.Index].Value = "";
            //dgvLedger.Rows[rowIndex].Cells[colBalance.Index].Value = _ledgerList.Where(x => !x.IsManualNewRow).Select(x => (x.DrCr * x.Balance)).Sum();
            //dgvLedger.Rows[rowIndex].Cells[colCredit.Index].Value = _ledgerList.Where(x => !x.IsManualNewRow).Sum(x => x.Credit);
            //dgvLedger.Rows[rowIndex].Cells[colDebit.Index].Value = _ledgerList.Where(x => !x.IsManualNewRow).Sum(x => x.Debit);

            dgvLedger.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            dgvLedger.Rows[rowIndex].DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            //dgvLedger.Rows[rowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);//
            dgvLedger.DataBindingComplete += DgvLedger_DataBindingComplete;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            PopulateLedger();
        }

        private void PopulateCustomer()
        {
            var customers = _userService.GetUserListForCombo(ViewModel.Enums.UserTypeEnum.Customer, new int[0]);
            cbCustomer.DataSource = customers;

            cbCustomer.ValueMember = "Id";
            cbCustomer.DisplayMember = "Name";
        }

        private void PopulateLedger()
        {
            var from = dtFrom.Value;
            var to = dtTo.Value;
            var customerIdStr = cbCustomer.SelectedValue?.ToString() ?? "";
            int customerId;
            int.TryParse(customerIdStr, out customerId);
            _ledgerList = _reportService.GetLedger(customerId, from, to);
            _ledgerList.Add(new LedgerModel() { IsManualNewRow = true });
            _ledgerList.Add(new LedgerModel() { IsManualNewRow = true });
            _bindingSource.DataSource = _ledgerList;
            _bindingSource.ResetBindings(false);
            //dgvLedger.DataSource = ledgerList;
            //dgvLedger.DataBindings.
        }
    }
}
