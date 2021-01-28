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
using ViewModel.Core.Common;
using ViewModel.Enums;
using Service.Core.Payment;
using IMS.Forms.Common.Pagination;
using Service.Listeners;
using ViewModel.Core.Orders;
using IMS.Forms.Inventory.Payment;
using SimpleInjector.Lifestyles;

namespace IMS.Forms.Inventory.Reports.All
{
    public partial class PaymentListUC : UserControl
    {
        private readonly IPaymentService _paymentService;
        private readonly IUserService _userService;

        private readonly IDatabaseChangeListener _listener;

        private LedgerMasterModel _ledgerMaster = new LedgerMasterModel();

        BindingSource _bindingSource = new BindingSource();
        private PaymentListPaginationHelper paginationHelper;

        public PaymentListUC(IPaymentService reportService, IUserService userService, IDatabaseChangeListener listener)
        {
            _paymentService = reportService;
            _userService = userService;
            _listener = listener;

            InitializeComponent();

            this.Load += LedgerUC_Load;
        }

        private void LedgerUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            InitializeGridView();
            InitializeEvents();

            PopulateType();
            PopulateCustomer();
            // InitializeSearchTextBox();
            PopulatePayments();

        }

        private void InitializeGridView()
        {
            //dgvLedger.DataSource = _bindingSource;
            dgvLedger.AutoGenerateColumns = false;
            paginationHelper = new PaymentListPaginationHelper(_bindingSource, dgvLedger, bindingNavigator1, _paymentService, ClientTypeEnum.All, string.Empty);
        }

        private void InitializeEvents()
        {
            //txtName.TextChanged += TxtName_TextChanged;
            cbCustomer.SelectedValueChanged += CbCustomer_SelectedValueChanged;
            cbType.SelectedValueChanged += CbType_SelectedValueChanged;
            _listener.PaymentUpdated += _listener_PaymentUpdated;
            dgvLedger.SelectionChanged += DgvLedger_SelectionChanged;
            btnPayment.Click += btnPayment_Click;
            btnPrint.Click += BtnPrint_Click;
        }


        private void DgvLedger_SelectionChanged(object sender, EventArgs e)
        {
            var paymentModel = dgvLedger.SelectedRows.Count > 0 ? dgvLedger.SelectedRows[0].DataBoundItem as PaymentModel : null;
            var selectedUser = cbCustomer.SelectedItem as IdNamePair;
            btnPayment.Visible = paymentModel != null || selectedUser != null;
            btnPrint.Visible = paymentModel != null || selectedUser != null;
        }
        private void btnPayment_Click(object sender, EventArgs e)
        {
            ShowPaymentDialog(false);
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            ShowPaymentDialog(true);
        }

        private void ShowPaymentDialog(bool showPrint)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var paymentModel = dgvLedger.SelectedRows.Count > 0 ? dgvLedger.SelectedRows[0].DataBoundItem as PaymentModel : null;
                var userId = paymentModel?.UserId;
                if ((userId ?? 0) <= 0)
                {
                    var selectedUser = cbCustomer.SelectedItem as IdNamePair;
                    userId = selectedUser?.Id;
                }
                if ((userId ?? 0) > 0)
                {
                    var po = Program.container.GetInstance<PaymentCreateForm>();
                    po.SetData(userId ?? 0, paymentModel?.Id??0, showPrint);
                    po.ShowDialog();
                }
            }
        }

        private void _listener_PaymentUpdated(object sender, Service.DbEventArgs.BaseEventArgs<ViewModel.Core.Orders.PaymentModel> e)
        {
            PopulatePayments();
        }

        private void CbCustomer_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulatePayments();
        }

        //private void BtnSearch_Click(object sender, EventArgs e)
        //{
        //    PopulatePayments();
        //}

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
        }

        //private void InitializeSearchTextBox()
        //{
        //    txtName.AutoCompleteCustomSource.Clear();
        //    var item = cbType.SelectedItem as NameValuePair;
        //    if (item != null)
        //    {
        //        var userType = (UserTypeEnum)Enum.Parse(typeof(UserTypeEnum), item.Value);
        //        var users = _userService.GetUserListWithCompanyForCombo(userType, new int[0]);
        //        txtName.AutoCompleteCustomSource.AddRange(users.Select(x => x.Name).ToArray());
        //        txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //        txtName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    }
        //}

        private void PopulatePayments()
        {
            var item = cbType.SelectedItem as NameValuePair;
            if (item != null)
            {
                var userType = (ClientTypeEnum)Enum.Parse(typeof(ClientTypeEnum), item.Value);
                paginationHelper.Reset(userType, cbCustomer.Text);
            }
            //var customerIdStr = cbCustomer.SelectedValue?.ToString() ?? "";
            //int customerId;
            //int.TryParse(customerIdStr, out customerId);
            //_ledgerMaster = _paymentService.GetAllPayments(customerId, );

            //_ledgerMaster.LedgerData.Add(new LedgerModel()
            //{
            //    IsManualNewRow = true,
            //    Balance = _ledgerMaster.BalanceSum,
            //    Credit = _ledgerMaster.CreditSum,
            //    Debit = _ledgerMaster.DebitSum,
            //    DrCr = _ledgerMaster.DrCr,
            //    DrCrString = _ledgerMaster.DrCrString,
            //    Particulars ="Total"
            //});
            //_bindingSource.DataSource = _ledgerMaster.LedgerData;
            //_bindingSource.ResetBindings(false);
            //dgvLedger.DataSource = ledgerList;
            //dgvLedger.DataBindings.
        }


        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            PopulatePayments();
        }

        private void CbType_SelectedValueChanged(object sender, EventArgs e)
        {
            //InitializeSearchTextBox();
            PopulateCustomer();
        }
    }
}

