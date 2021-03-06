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
using Service.Listeners;
using ViewModel.Core.Common;
using IMS.Forms.Inventory.Accounts.All;
using Service.Core.Settings;
using IMS.Forms.Common;
using ViewModel.Enums;
using ViewModel.Utility;

namespace IMS.Forms.Inventory.Reports.All
{
    public partial class LedgerUC : UserControl
    {
        private readonly IReportService _reportService;
        private readonly IUserService _userService;
        private readonly IAppSettingService _appSettingService;
        private readonly IDatabaseChangeListener _listener;

        private LedgerMasterModel _ledgerMaster = new LedgerMasterModel();
        private LedgerMasterModel _ledgerMasterForPrint = new LedgerMasterModel();

        BindingSource _bindingSource;
        public LedgerUC(IReportService reportService, IUserService userService, IAppSettingService appSettingService, IDatabaseChangeListener listener)
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
            dtFrom.SetValue(DateTime.Now.AddDays(-7));
            dtTo.SetValue(DateTime.Now);

            InitializeEvents();
            PopulateType();
            PopulateCustomer();
            PopulateLedger();

        }

        private void InitializeEvents()
        {
            btnSearch.Click += BtnSearch_Click;
            dgvLedger.DataBindingComplete += DgvLedger_DataBindingComplete;
            _listener.UserUpdated += _listener_UserUpdated;
            chkOnlyShowAfterLastClearance.CheckedChanged += ChkOnlyShowAfterLastClearance_CheckedChanged;
            btnPrint.Click += BtnPrint_Click;

            cbCustomer.SelectedValueChanged += CbCustomer_SelectedValueChanged;
            //cbCustomer.TextChanged += CbCustomer_TextChanged;
            cbType.SelectedValueChanged += CbType_SelectedValueChanged;
        }

        private void CbType_SelectedValueChanged(object sender, EventArgs e)
        {
            //InitializeSearchTextBox();
            PopulateCustomer();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            //var ledgerMaster = GetLedger();
            if (_ledgerMasterForPrint != null)
            {
                var form = new LedgerPrintForm(_appSettingService, _ledgerMasterForPrint);
                form.ShowDialog();
            }
            else
            {
                PopupMessage.ShowInfoMessage("Empty ledger!");
            }
        }

        private void ChkOnlyShowAfterLastClearance_CheckedChanged(object sender, EventArgs e)
        {
            dtFrom.Enabled = !chkOnlyShowAfterLastClearance.Checked;
            dtTo.Enabled = !chkOnlyShowAfterLastClearance.Checked;
        }

        private void CbCustomer_SelectedValueChanged(object sender, EventArgs e)
        {
            var userItem = cbCustomer.SelectedItem as IdNamePair;
            if (userItem != null)
            {
                var user = _userService.GetUser(userItem.Id);
                if (user != null)
                    lblLastClearanceDate.Text = user.AllDuesClearDate.HasValue
                        ? DateConverter.Instance.ToBS(user.AllDuesClearDate.Value).ToString()//.ToString("(yyyy/MM/dd HH:mm:ss)")
                        : "";
            }

        }

        private void _listener_UserUpdated(object sender, Service.DbEventArgs.BaseEventArgs<ViewModel.Core.Users.UserModel> e)
        {
            PopulateCustomer();
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
            PopulateLedger();
        }
        private void PopulateType()
        {
            var values = Enum.GetValues(typeof(ClientTypeEnum)).Cast<ClientTypeEnum>()
                .Select(x => new NameValuePair(x.ToString(), x.ToString()))
                .ToList();
            cbType.ValueMember = "Value";
            cbType.DisplayMember = "Name";
            cbType.DataSource = values;
        }
        private void PopulateCustomer()
        {
            var item = cbType.SelectedItem as NameValuePair;
            if (item != null)
            {
                var userType = (UserTypeEnum)Enum.Parse(typeof(UserTypeEnum), item.Value);
                var customers = _userService.GetUserListForCombo(userType, new int[0]);
                customers.Insert(0, new IdNamePair(0, ""));
                cbCustomer.DataSource = customers;

                cbCustomer.ValueMember = "Id";
                cbCustomer.DisplayMember = "Name";
            }
            //var customers = _userService.GetUserListForCombo(ViewModel.Enums.UserTypeEnum.All, new int[0]);
            //cbCustomer.DataSource = customers;
            //cbCustomer.ValueMember = "Id";
            //cbCustomer.DisplayMember = "Name";
        }
       private LedgerMasterModel GetLedger()
        {
            var from = dtFrom.GetValue();
            var to = dtTo.GetValue();
            var customerIdStr = cbCustomer.SelectedValue?.ToString() ?? "";
            int customerId;
            int.TryParse(customerIdStr, out customerId);
            var model = new LedgerRequestModel
            {
                CustomerId = customerId,
                From = from,
                To = to,
                OnlyAfterLastClearance = chkOnlyShowAfterLastClearance.Checked,
            };
            return _reportService.GetLedger(model);
        }

        private void PopulateLedger()
        {
            _ledgerMaster = GetLedger();
            _ledgerMasterForPrint = GetLedger();

            if (_ledgerMaster != null)
            {
                _ledgerMaster.LedgerData.Add(new LedgerModel()
                {
                    IsManualNewRow = true,
                    Balance = _ledgerMaster.BalanceSum,
                    Credit = _ledgerMaster.CreditSum,
                    Debit = _ledgerMaster.DebitSum,
                    DrCr = _ledgerMaster.DrCr,
                    DrCrString = _ledgerMaster.DrCrString,
                    Particulars = "Total"
                });
                _bindingSource.DataSource = _ledgerMaster.LedgerData;
                _bindingSource.ResetBindings(false);
                //dgvLedger.DataSource = ledgerList;
                //dgvLedger.DataBindings.
            }
            else
            {
                _bindingSource.DataSource = null;
                _bindingSource.ResetBindings(false);
            }
        }
    }
}
