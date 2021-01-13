using System;
using System.Windows.Forms;
using Service.Listeners;
using SimpleInjector.Lifestyles;
using Service.DbEventArgs;
using ViewModel.Core.Users;
using Service.Core.Users;
using ViewModel.Enums;
using System.Collections.Generic;
using System.Linq;

namespace IMS.Forms.Inventory.Suppliers
{
    public partial class SupplierListUC : UserControl
    {
        public event EventHandler<BaseEventArgs<UserModel>> RowSelected;

        private readonly IUserService _supplierService;
        private readonly IDatabaseChangeListener _listener;

        UserModel _selectedSupplierModel;

        UserTypeEnum _userType = UserTypeEnum.Client;
        BindingSource _bindingSource = new BindingSource();

        private int _previousIndex;
        private bool _sortDirection;
        //HeaderTemplate _header;

        public SupplierListUC(IUserService supplierService, IDatabaseChangeListener listener)
        {
            this._supplierService = supplierService;
            _listener = listener;

            InitializeComponent();

            this.Load += SupplierUC_Load;

            this.Dock = DockStyle.Fill;

        }

        private void SupplierUC_Load(object sender, EventArgs e)
        {
            // InitializeHeader();
            dgvSuppliers.DataSource = _bindingSource;
            Populate();

            InitializeEvents();
            this.dgvSuppliers.AllowUserToOrderColumns = true;
        }


        #region Initialization Functions

        //private void InitializeHeader()
        //{
        //    _header = HeaderTemplate.Instance;
        //    _header.btnNew.Visible = true;
        //    _header.btnNew.Click += BtnNew_Click;
        //    _header.btnEdit.Click += BtnEdit_Click;
        //    _header.btnDelete.Click += BtnDelete_Click;
        //    this.Controls.Add(_header);
        //    _header.SendToBack();

        //    _header.lblHeading.Text = "Suppliers";
        //}

        private void InitializeEvents()
        {
            _listener.UserUpdated += _listener_SupplierUpdated;
            dgvSuppliers.SelectionChanged += DgvSuppliers_SelectionChanged;
            btnNew.Click += BtnNew_Click;
            btnEdit.Click += BtnEdit_Click;
            dgvSuppliers.CellMouseDoubleClick += DgvSuppliers_CellMouseDoubleClick;
            rbAll.CheckedChanged += UserType_CheckedChanged;
            rbCustomer.CheckedChanged += UserType_CheckedChanged;
            rbSupplier.CheckedChanged += UserType_CheckedChanged;
            btnSearch.Click += BtnSearch_Click;
            dgvSuppliers.ColumnHeaderMouseClick += DgvSuppliers_ColumnHeaderMouseClick;
            dgvSuppliers.CellClick += DgvSuppliers_CellClick;
        }

        private void DgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                if(e.ColumnIndex == colEdit.Index)
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

            _bindingSource.DataSource = SortData(
                (List<UserModel>)_bindingSource.DataSource, dgvSuppliers.Columns[e.ColumnIndex].DataPropertyName, _sortDirection);

            _previousIndex = e.ColumnIndex;
        }
        public List<UserModel> SortData(List<UserModel> list, string column, bool ascending)
        {
            return ascending ?
                list.OrderBy(_ => _.GetType().GetProperty(column).GetValue(_)).ToList() :
                list.OrderByDescending(_ => _.GetType().GetProperty(column).GetValue(_)).ToList();
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Populate();
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
            Populate();
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

        #endregion



        #region EventHandlers

        private void _listener_SupplierUpdated(object sender, Service.DbEventArgs.BaseEventArgs<UserModel> e)
        {
            Populate();
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

        //private void BtnDelete_Click(object sender, EventArgs e)
        //{
        //    if (_selectedSupplierModel != null)
        //    {
        //        var dialogResult = MessageBox.Show(this, "Are you sure to delete?", "Delete", MessageBoxButtons.YesNo);
        //        if (dialogResult.Equals(DialogResult.Yes))
        //        {
        //            _supplierService.DeleteSupplier(_selectedSupplierModel.Id);
        //        }
        //    }
        //}

        #endregion



        #region Population Functions

        private void Populate()
        {
            dgvSuppliers.AutoGenerateColumns = false;
            var supplier = _supplierService.GetUserList(_userType, txtName.Text);
            _bindingSource.DataSource = supplier;
            _bindingSource.ResetBindings(false);
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
            //  btnDelete.Visible = visible;
        }


        #endregion

    }
}
