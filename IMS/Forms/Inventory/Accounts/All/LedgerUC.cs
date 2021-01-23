﻿using System;
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

namespace IMS.Forms.Inventory.Reports.All
{
    public partial class LedgerUC : UserControl
    {
        private readonly IReportService _reportService;
        private readonly IUserService _userService;
        private readonly IDatabaseChangeListener _listener;

        private LedgerMasterModel _ledgerMaster = new LedgerMasterModel();

        BindingSource _bindingSource;
        public LedgerUC(IReportService reportService, IUserService userService, IDatabaseChangeListener listener)
        {
            _reportService = reportService;
            _userService = userService;
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
            dtFrom.Value = DateTime.Now.AddDays(-7);

            InitializeEvents();
            PopulateCustomer();
            PopulateLedger();

        }

        private void InitializeEvents()
        {
            btnSearch.Click += BtnSearch_Click;
            dgvLedger.DataBindingComplete += DgvLedger_DataBindingComplete;
            _listener.UserUpdated += _listener_UserUpdated;
            cbCustomer.SelectedValueChanged += CbCustomer_SelectedValueChanged;
            chkOnlyShowAfterLastClearance.CheckedChanged += ChkOnlyShowAfterLastClearance_CheckedChanged;
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
                        ? user.AllDuesClearDate.Value.ToString("(yyyy/MM/dd HH:mm:ss)")
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

        private void PopulateCustomer()
        {
            var customers = _userService.GetUserListForCombo(ViewModel.Enums.UserTypeEnum.All, new int[0]);
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
            var model = new LedgerRequestModel
            {
                CustomerId = customerId,
                From = from,
                To = to,
                OnlyAfterLastClearance = chkOnlyShowAfterLastClearance.Checked,
            };
            _ledgerMaster = _reportService.GetLedger(model);

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
    }
}