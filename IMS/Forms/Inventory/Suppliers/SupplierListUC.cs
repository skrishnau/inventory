﻿using System;
using System.Windows.Forms;
using Service.Listeners;
using SimpleInjector.Lifestyles;
using Service.DbEventArgs;
using ViewModel.Core.Users;
using Service.Core.Users;
using ViewModel.Enums;
using System.Collections.Generic;
using System.Linq;
using IMS.Forms.Inventory.Payment;
using IMS.Forms.Common.Pagination;

namespace IMS.Forms.Inventory.Suppliers
{
    public partial class SupplierListUC : UserControl
    {
        public event EventHandler<BaseEventArgs<UserModel>> RowSelected;

        private readonly IUserService _userService;
        private readonly IDatabaseChangeListener _listener;

        UserModel _selectedSupplierModel;

        UserTypeEnum _userType = UserTypeEnum.Client;
        BindingSource _bindingSource = new BindingSource();

        private int _previousIndex;
        private bool _sortDirection;
        //HeaderTemplate _header;

        private ClientListPaginationHelper helper;


        public SupplierListUC(IUserService userService, IDatabaseChangeListener listener)
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
            PopulateUserList();
            
        }

        private void InitializeSearchTextBox()
        {
            txtName.AutoCompleteCustomSource.Clear();
            var users = _userService.GetUserListWithCompanyForCombo(_userType, new int[0]);
            txtName.AutoCompleteCustomSource.AddRange(users.Select(x => x.Name).ToArray());
            txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
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
        }


        #endregion



        #region Population Functions

        private void PopulateUserList()
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
                var supplierCreate = Program.container.GetInstance<SupplierCreate>();// (supplier);
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
            PopulateUserList();
        }

        private void _listener_SupplierUpdated(object sender, Service.DbEventArgs.BaseEventArgs<UserModel> e)
        {
            InitializeSearchTextBox();
            PopulateUserList();
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
                _userType = UserTypeEnum.Customer;
                // btnNew.Visible = true;
            }
            else if (rbSupplier.Checked)
            {
                _userType = UserTypeEnum.Supplier;
                //btnNew.Visible = true;
            }
            else
            {
                _userType = UserTypeEnum.Client;
                //btnNew.Visible = false;
            }
            PopulateUserList();
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
