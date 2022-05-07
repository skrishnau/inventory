using System;
using System.Windows.Forms;
using Service.Listeners;
using SimpleInjector.Lifestyles;
using Service.DbEventArgs;
using Service.Core.Users;
using ViewModel.Enums;
using System.Collections.Generic;
using System.Linq;
using IMS.Forms.Inventory.Payment;
using IMS.Forms.Common.Pagination;
using IMS.Forms.Common;
using ViewModel.Core;
using IMS.Forms.Inventory.Accounts.All;
using ViewModel.Core.Reports;
using Service.Core.Settings;
using ViewModel.Utility;
using IMS.Forms.Accounts;
using IMS.Forms.Inventory.Settings.General;

namespace IMS.Forms.Inventory.Suppliers
{
    public partial class ClientListUC : BaseUserControl
    {
        public event EventHandler<BaseEventArgs<UserModel>> RowSelected;

        private readonly IUserService _userService;
        private readonly IDatabaseChangeListener _listener;
        private readonly IAppSettingService _appSettingService;

        UserModel _selectedSupplierModel;

        List<UserTypeEnum> _userType = new List<UserTypeEnum>();//.Customer;//Client;
        BindingSource _bindingSource = new BindingSource();

        private int _previousIndex;
        private bool _sortDirection;
        //HeaderTemplate _header;

        private ClientListPaginationHelper helper;

        private UserTypeCategoryEnum _userTypeCategory;


        public ClientListUC(IUserService userService, IDatabaseChangeListener listener, IAppSettingService appSettingService)
        {
            this._userService = userService;
            _listener = listener;
            _appSettingService = appSettingService;

            InitializeComponent();

            this.Load += SupplierUC_Load;
        }

        private void SupplierUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            // InitializeHeader();
            //dgvSuppliers.DataSource = _bindingSource;
            InitializeGridView();
            InitializeSearchTextBox();
            PopulateData();
            PopulateList();

            InitializeEvents();
        }

        private void PopulateData()
        {
            switch (_userTypeCategory)
            {
                case UserTypeCategoryEnum.CustomerAndSupplier:
                    rbCustomer.Text = UserTypeEnum.Customer.ToString();
                    rbSupplier.Text = UserTypeEnum.Supplier.ToString();
                    colManufacturedAmount.Visible = false;
                    colResetPassword.Visible = false;
                    break;
                case UserTypeCategoryEnum.UserAndVendor:
                    colResetPassword.Visible = true;
                    rbCustomer.Text = UserTypeEnum.Employee.ToString();
                    rbSupplier.Text = UserTypeEnum.Vendor.ToString();
                    rbSupplier.Visible = false;
                    // columns
                    //colTotalAmount.Visible = false;
                    //colPaidAmount.Visible = false;
                    colAllDuesClearDate.Visible = false;
                    colPaymentDueDate.Visible = false;

                    //colRemainAmount.Visible = false;
                    if (!Constants.IS_MANUFACTURE_REQUIRED || _userType.All(x=>x == UserTypeEnum.Employee))
                    {
                        btnPrint.Visible = false;
                        btnPayment.Visible = false;

                        this.colCompany.Visible = false;
                        this.colManufacturedAmount.Visible = false;
                        this.colPaidAmount.Visible = false;
                        this.colRemainAmount.Visible = false;
                        this.colTotalAmount.Visible = false;
                    }
                    break;
            }
        }

        private void InitializeSearchTextBox()
        {
            txtName.AutoCompleteCustomSource.Clear();
            var users = _userService.GetUserListWithCompanyForCombo(_userType, new int[0]);
            txtName.AutoCompleteCustomSource.AddRange(users.Select(x => x.Name).ToArray());
            txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        public void SetData(UserTypeCategoryEnum userTypeCategory)
        {
            _userTypeCategory = userTypeCategory;
            switch (_userTypeCategory)
            {
                case UserTypeCategoryEnum.CustomerAndSupplier:
                    _userType = UserTypeEnumHelper.CustomerSupplier;// UserTypeEnum.Customer;
                    break;
                case UserTypeCategoryEnum.UserAndVendor:
                    _userType = UserTypeEnumHelper.UserAndVendor;// UserTypeEnum.User;
                    break;
            }
        }


        #region Initialization Functions


        private void InitializeGridView()
        {
            dgvSuppliers.AutoGenerateColumns = false;
            dgvSuppliers.AllowUserToOrderColumns = true;
            helper = new ClientListPaginationHelper(_bindingSource, dgvSuppliers, bindingNavigator1, _userService, _userType, txtName?.Text);
        }

        private void InitializeEvents()
        {
            _listener.UserUpdated += _listener_SupplierUpdated;
            dgvSuppliers.SelectionChanged += DgvSuppliers_SelectionChanged;
            btnNew.Click += BtnNew_Click;
            btnEdit.Click += BtnEdit_Click;
            btnPayment.Click += btnPayment_Click;
            dgvSuppliers.CellMouseDoubleClick += DgvSuppliers_CellMouseDoubleClick;
            rbAll.CheckedChanged += UserType_CheckedChanged;
            rbCustomer.CheckedChanged += UserType_CheckedChanged;
            rbSupplier.CheckedChanged += UserType_CheckedChanged;
            dgvSuppliers.ColumnHeaderMouseClick += DgvSuppliers_ColumnHeaderMouseClick;
            dgvSuppliers.CellClick += DgvSuppliers_CellClick;
            txtName.TextChanged += TxtName_TextChanged;
            dgvSuppliers.DataBindingComplete += DgvSuppliers_DataBindingComplete;
            btnPrint.Click += BtnPrint_Click;

        }

        private void DgvSuppliers_DataBindingComplete(object sender, EventArgs e)
        {
            PaginationHelper.SetRowNumber(dgvSuppliers, helper.offset);
        }



        #endregion



        #region Population Functions

        private void PopulateList()
        {
            //var supplier = _userService.GetUserList(_userType, txtName.Text);
            //_bindingSource.DataSource = supplier;
            //_bindingSource.ResetBindings(false);
            helper.Reset(_userType, txtName?.Text);
        }

        private void ShowAddEditDialog(bool isEditMode)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var withoutVendor = Constants.IS_MANUFACTURE_REQUIRED ? _userType : _userType.Where(x => x != UserTypeEnum.Vendor).ToList();
                var supplierCreate = new ClientCreateForm(_userService, _listener);//Program.container.GetInstance<ClientCreateForm>();// (supplier);
                var user = GetSelectedUser();
                supplierCreate.SetDataForEdit(isEditMode ? user == null ? 0 : user.Id : 0, withoutVendor);
                supplierCreate.ShowDialog();
            }
        }

        private void ShowEditDeleteButtons()
        {
            var user = GetSelectedUser();
            var visible = user != null;//_selectedSupplierModel != null;
            btnEdit.Visible = visible;
            btnPayment.Visible = _userType.Contains(UserTypeEnum.Employee) ? false : visible;
            //  btnDelete.Visible = visible;
        }


        #endregion



        #region EventHandlers

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            var usersForPrint = _userService.GetAllUsers(_userType, 0, 0, txtName?.Text);
            var lengthToTruncate = 15;
            var dataList = usersForPrint.DataList.Select(x => new ClientListPrintModel
            {
                Address = x.Address?.Length > lengthToTruncate ? $"{x.Address.Substring(0, lengthToTruncate)}..." : x.Address,
                Balance = x.DueAmountString, //x.DueAmount.ToString("0.00"),
                Company = x.Company?.Length > lengthToTruncate ? $"{x.Company.Substring(0, lengthToTruncate)}..." : x.Company,
                Credit = x.PaidAmount.ToString("0.00"),
                Debit = x.TotalAmount.ToString("0.00"),
                DrCr = Math.Sign(x.DueAmount),
                DrCrString = x.DueAmount > 0 ? "Dr" : x.DueAmount < 0 ? "Cr" : "",
                DueDateBS = x.PaymentDueDateBS,//x.PaymentDueDate.HasValue ? DateConverter.Instance.ToBS(x.PaymentDueDate.Value).ToString() : string.Empty,//x.PaymentDueDate.ToString(), // should be in bs
                IsManualNewRow = false,
                LastFullClearDateBS = x.AllDuesClearDateBS,
                Name = x.Name,
                Phone = x.Phone,
                Type = x.UserType,
                Use = x.Use,
            }).ToList();
            if (usersForPrint != null)
            {
                var debit = usersForPrint.DataList.Sum(x => x.TotalAmount);
                var credit = usersForPrint.DataList.Sum(x => x.PaidAmount);
                var total = usersForPrint.DataList.Sum(x => x.DueAmount);
                var model = new ClientListMasterPrintModel
                {
                    BalanceSum = total >= 0 ? total.ToString("0.00") : $"({total.ToString("0.00")})",
                    ClientList = dataList,
                    CreditSum = credit.ToString("0.00"),
                    DebitSum = debit.ToString("0.00"),
                    DrCr = total > 0 ? -1 : 1,
                    DrCrString = total > 0 ? "Dr" : total < 0 ? "Cr" : "",
                    UserType = string.Join(", ", _userType.Select(x => x.ToString())),
                    SearchText = txtName?.Text,
                };
                var form = new ClientListPrintForm(_appSettingService, model, _userService);
                form.ShowDialog();
            }
            else
            {
                PopupMessage.ShowInfoMessage("Empty ledger!");
            }
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            PopulateList();
        }

        private void _listener_SupplierUpdated(object sender, Service.DbEventArgs.BaseEventArgs<UserModel> e)
        {
            //InitializeSearchTextBox();
            //PopulateUserList();
            AddListenerAction(InitializeSearchTextBox, e);
            AddListenerAction(PopulateList, e);
        }

        private UserModel GetSelectedUser()
        {
            return dgvSuppliers.SelectedRows.Count > 0 ? dgvSuppliers.SelectedRows[0].DataBoundItem as UserModel : null;
        }
        private void DgvSuppliers_SelectionChanged(object sender, EventArgs e)
        {
            _selectedSupplierModel = GetSelectedUser();
            ShowEditDeleteButtons();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ShowAddEditDialog(false);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            ShowAddEditDialog(true);
        }
        public List<UserModel> SortData(List<UserModel> list, string column, bool ascending)
        {
            if (string.IsNullOrWhiteSpace(column)) return list;
            return ascending ?
                list.OrderBy(_ => _.GetType().GetProperty(column).GetValue(_)).ToList() :
                list.OrderByDescending(_ => _.GetType().GetProperty(column).GetValue(_)).ToList();
        }
        private void DgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var data = dgvSuppliers.Rows[e.RowIndex].DataBoundItem as UserModel;
                if (data != null)
                {
                    if (e.ColumnIndex == colEdit.Index)
                    {
                        ShowAddEditDialog(true);
                    }
                    else if (e.ColumnIndex == colResetPassword.Index)
                    {
                        if (!data.CanLogin)
                        {
                            PopupMessage.ShowInfoMessage($"Please set {data.Name} 's Username from edit page.");
                            return;
                        }
                        var loginUserCreateForm = new PasswordEditForm(_userService);
                        loginUserCreateForm.SetData(data.Username);
                        loginUserCreateForm.ShowDialog(this);
                    }
                }
            }
        }

        private void DgvSuppliers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == _previousIndex)
                _sortDirection ^= true; // toggle direction
            var column = dgvSuppliers.Columns[e.ColumnIndex].DataPropertyName;
            if (string.IsNullOrWhiteSpace(column)) return;
            dgvSuppliers.DataSource = SortData((List<UserModel>)dgvSuppliers.DataSource, column, _sortDirection);

            _previousIndex = e.ColumnIndex;
        }


        private void UserType_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCustomer.Checked)
            {
                if (_userTypeCategory == UserTypeCategoryEnum.CustomerAndSupplier)
                    _userType = new List<UserTypeEnum> { UserTypeEnum.Customer };
                else if (_userTypeCategory == UserTypeCategoryEnum.UserAndVendor)
                    _userType = new List<UserTypeEnum> { UserTypeEnum.Employee };
                // btnNew.Visible = true;
            }
            else if (rbSupplier.Checked)
            {
                if (_userTypeCategory == UserTypeCategoryEnum.CustomerAndSupplier)
                    _userType = new List<UserTypeEnum> { UserTypeEnum.Supplier };
                else if (_userTypeCategory == UserTypeCategoryEnum.UserAndVendor)
                    _userType = new List<UserTypeEnum> { UserTypeEnum.Vendor };
                //btnNew.Visible = true;
            }
            else
            {
                _userType = UserTypeEnumHelper.ConvertToUserTypeEnum(_userTypeCategory);
                //_userType = UserTypeEnum.All;// Client;
                //btnNew.Visible = false;
            }
            PopulateList();
        }

        private void DgvSuppliers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var rowData = dgvSuppliers.Rows[e.RowIndex].DataBoundItem as UserModel;
                if (rowData != null)
                {
                    var args = new BaseEventArgs<UserModel>(rowData, Service.Utility.UpdateMode.NONE);
                    RowSelected?.Invoke(sender, args);
                }
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                //var orderModel = dgvOrders.SelectedRows.Count > 0 ? dgvOrders.SelectedRows[0].DataBoundItem as OrderModel : null;
                var userModel = dgvSuppliers.SelectedRows.Count > 0 ? dgvSuppliers.SelectedRows[0].DataBoundItem as UserModel : null;
                if (userModel != null)
                {
                    var po = Program.container.GetInstance<PaymentCreateForm>();
                    po.SetData(userModel);
                    po.ShowDialog();
                }
            }
        }

        #endregion




    }
}
