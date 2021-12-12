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

namespace IMS.Forms.Inventory.Suppliers
{
    public partial class ClientListUC : BaseUserControl
    {
        public event EventHandler<BaseEventArgs<UserModel>> RowSelected;

        private readonly IUserService _userService;
        private readonly IDatabaseChangeListener _listener;

        UserModel _selectedSupplierModel;

        List<UserTypeEnum> _userType = new List<UserTypeEnum>();//.Customer;//Client;
        BindingSource _bindingSource = new BindingSource();

        private int _previousIndex;
        private bool _sortDirection;
        //HeaderTemplate _header;

        private ClientListPaginationHelper helper;

        private UserTypeCategoryEnum _userTypeCategory;


        public ClientListUC(IUserService userService, IDatabaseChangeListener listener)
        {
            this._userService = userService;
            _listener = listener;

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
            InitializeEvents();
            PopulateData();
            PopulateList();
            
        }

        private void PopulateData()
        {
            switch (_userTypeCategory)
            {
                case UserTypeCategoryEnum.CustomerAndSupplier:
                    rbCustomer.Text = UserTypeEnum.Customer.ToString();
                    rbSupplier.Text = UserTypeEnum.Supplier.ToString();
                    break;
                case UserTypeCategoryEnum.UserAndVendor:
                    btnPayment.Visible = false;
                    rbCustomer.Text = UserTypeEnum.Employee.ToString();
                    rbSupplier.Text = UserTypeEnum.Vendor.ToString();
                    // columns
                    colCompany.Visible = false;
                    //colTotalAmount.Visible = false;
                    //colPaidAmount.Visible = false;
                    //colAllDuesClearDate.Visible = false;
                    //colPaymentDueDate.Visible = false;
                    //colRemainAmount.Visible = false;
                    break;
            }
        }

        private void InitializeSearchTextBox()
        {
            txtName.AutoCompleteCustomSource.Clear();
            var users = _userService.GetUserListWithCompanyForCombo( _userType, new int[0]);
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
            helper = new ClientListPaginationHelper(_bindingSource, dgvSuppliers, bindingNavigator1, _userService, _userType , txtName?.Text);
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
                var supplierCreate = Program.container.GetInstance<ClientCreateForm>();// (supplier);
                supplierCreate.SetDataForEdit(isEditMode ? _selectedSupplierModel == null ? 0 : _selectedSupplierModel.Id : 0, _userType);
                supplierCreate.ShowDialog();
            }
        }

        private void ShowEditDeleteButtons()
        {
            var visible = _selectedSupplierModel != null;
            btnEdit.Visible = visible;
            btnPayment.Visible = visible;
            //  btnDelete.Visible = visible;
        }


        #endregion



        #region EventHandlers


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

        private void DgvSuppliers_SelectionChanged(object sender, EventArgs e)
        {
            _selectedSupplierModel = dgvSuppliers.SelectedRows.Count > 0 ? dgvSuppliers.SelectedRows[0].DataBoundItem as UserModel : null;
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
            return ascending ?
                list.OrderBy(_ => _.GetType().GetProperty(column).GetValue(_)).ToList() :
                list.OrderByDescending(_ => _.GetType().GetProperty(column).GetValue(_)).ToList();
        }
        private void DgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == colEdit.Index)
                {
                    var data = dgvSuppliers.Rows[e.RowIndex].DataBoundItem as UserModel;
                    if (data != null)
                    {
                        ShowAddEditDialog(true);
                    }

                }
            }
        }

        private void DgvSuppliers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == _previousIndex)
                _sortDirection ^= true; // toggle direction

            dgvSuppliers.DataSource = SortData((List<UserModel>)dgvSuppliers.DataSource, dgvSuppliers.Columns[e.ColumnIndex].DataPropertyName, _sortDirection);

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
