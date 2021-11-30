using IMS.Forms.Common;
using IMS.Forms.Common.GridView;
using IMS.Forms.Inventory.Suppliers;
using Service.Core.Settings;
using Service.Core.Users;
using Service.Interfaces;
using Service.Listeners;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ViewModel.Core;
using ViewModel.Core.Common;
using ViewModel.Enums;

namespace IMS.Forms.MRP
{
    public partial class DepartmentCreateForm : Form
    {
        private readonly IManufactureService _manufactureService;
        private readonly IAppSettingService _appSettingService;
        private readonly IUserService _userService;
        private readonly IDatabaseChangeListener _databaseChangeListener;

        DepartmentModel _model;
        GridViewColumnDecimalValidator _decimalValidator;

        public DepartmentCreateForm(IManufactureService manufactureService, IAppSettingService appSettingService, IUserService userService, IDatabaseChangeListener databaseChangeListener)
        {
            _manufactureService = manufactureService;
            _appSettingService = appSettingService;
            _userService = userService;
            _databaseChangeListener = databaseChangeListener;

            InitializeComponent();

            this.Load += DepartmentCreateForm_Load;
        }

        private void DepartmentCreateForm_Load(object sender, EventArgs e)
        {
            _decimalValidator = new GridViewColumnDecimalValidator(dgvEmployees);
            _decimalValidator.AddColumn(colRate, ColumnDataType.Decimal);
            _decimalValidator.Validate();

            PopulateDepartmentType();
            InitializeEmployeeGridView();
            btnSave.Click += BtnSave_Click;
            PopulateEmployeeCombo();
            cbDepartmentType.SelectedIndexChanged += CbDepartmentType_SelectedIndexChanged;
            btnAddUser.Click += BtnAddUser_Click;
            dgvEmployees.DataError += DgvEmployees_DataError;
            dgvEmployees.CellClick += DgvEmployees_CellClick;

            PopulateEditData();
        }

        private void DgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == colDelete.Index)
            {
                if (!dgvEmployees.Rows[e.RowIndex].IsNewRow)
                {
                    dgvEmployees.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void DgvEmployees_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            foreach (DataGridViewRow row in dgvEmployees.Rows)
            {
                var cell = row.Cells[colEmployeeName.Index] as DataGridViewComboBoxCell;
                if (cell != null)
                {
                    cell.Value = null;
                }
            }
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var type = GetSelectedDepartmentType();
                var userType = type == null ? UserTypeEnum.User : GetUserTypeFromDepartmentType((DepartmentTypeEnum)type);
                var form = Program.container.GetInstance<ClientCreateForm>();
                form.SetDataForEdit(0, userType);
                form.ShowDialog();
                PopulateEmployeeCombo();
            }
        }
        private DepartmentTypeEnum? GetSelectedDepartmentType()
        {
            var type = cbDepartmentType.SelectedItem as IdNamePair;
            if (type != null)
            {
                return (DepartmentTypeEnum)type.Id;
            }
            return null;
        }
        private UserTypeEnum GetUserTypeFromDepartmentType(DepartmentTypeEnum departmentType)
        {
            return departmentType == DepartmentTypeEnum.Vendor ? UserTypeEnum.Vendor : UserTypeEnum.User;
        }

        private void CbDepartmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetEmployeeHeader();
            PopulateEmployeeCombo();
        }

        private void SetEmployeeHeader()
        {
            //var type = cbDepartmentType.SelectedItem as IdNamePair;
            var type = GetSelectedDepartmentType();
            if (type != null)
            {
                lblEmployeesHeader.Text = type == DepartmentTypeEnum.Vendor ? "Vendors" : "Employees";
            }
        }

        private void InitializeEmployeeGridView()
        {
            dgvEmployees.AutoGenerateColumns = false;
            dgvEmployees.AllowUserToAddRows = true;
            dgvEmployees.AllowUserToDeleteRows = true;
        }

        private void PopulateEmployeeCombo()
        {
            var userIds = _model?.DepartmentUsers?.Where(x => x.UserId != null).Select(x => x.UserId.Value).ToArray() ?? new int[0];
            var depType = cbDepartmentType.SelectedItem as IdNamePair;
            var userType = depType.Id == (int)DepartmentTypeEnum.Vendor ? UserTypeEnum.Vendor : ViewModel.Enums.UserTypeEnum.User;
            var users = _userService.GetUserListForCombo(userType, userIds);
            var userColumn = dgvEmployees.Columns[colEmployeeName.Index] as DataGridViewComboBoxColumn;
            if (userColumn != null)
            {
                userColumn.DataSource = users;
                userColumn.ValueMember = "Id";
                userColumn.DisplayMember = "Name";
            }
        }

        private void PopulateDepartmentType()
        {
            var types = Enum.GetValues(typeof(DepartmentTypeEnum)).Cast<DepartmentTypeEnum>().Select(x => new IdNamePair { Id = (int)x, Name = x.ToString() }).ToList();
            cbDepartmentType.DataSource = types;
            cbDepartmentType.ValueMember = "Id";
            cbDepartmentType.DisplayMember = "Name";
        }


        public void SetDataForEdit(int id)
        {
            var model = _manufactureService.GetDepartment(id);
            _model = model;

        }

        private void PopulateEditData()
        {
            if (_model != null)
            {
                txtName.Text = _model.Name;
                txtDescription.Text = _model.Description;
                cbDepartmentType.SelectedValue = _model.IsVendor ? (int)DepartmentTypeEnum.Vendor : (int)DepartmentTypeEnum.Internal;
                lblEmployeesHeader.Text = _model.IsVendor ? "Vendors" : "Employees";

                
                var templateRowAdded = false;
                if (dgvEmployees.Rows.Count == 0)
                {
                    dgvEmployees.Rows.Add();
                    templateRowAdded = true;
                }
                cbDepartmentType.Enabled = false;
                foreach (var du in _model.DepartmentUsers)
                {
                    var row = (DataGridViewRow)dgvEmployees.Rows[0].Clone();
                    row.Cells[colEmployeeName.Index].Value = du.UserId;
                    row.Cells[colRate.Index].Value = du.BuildRate;
                    dgvEmployees.Rows.Add(row);
                }
                if (templateRowAdded)
                    dgvEmployees.Rows.RemoveAt(0);
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {

            string message = string.Empty;
            var isInvalid = false;
            errorProvider1.SetError(txtName, string.Empty);
            errorProvider1.SetError(cbDepartmentType, string.Empty);
            errorProvider1.SetError(dgvEmployees, string.Empty);
            if (string.IsNullOrEmpty(txtName.Text))
            {
                isInvalid = true;
                errorProvider1.SetError(txtName, "Required");
            }

            var departmentType = cbDepartmentType.SelectedItem as IdNamePair;
            if (departmentType == null)
            {
                isInvalid = true;
                errorProvider1.SetError(cbDepartmentType, "Required");
            }

            var users = new List<DepartmentUserModel>();
            foreach (DataGridViewRow r in dgvEmployees.Rows)
            {
                var col = r.Cells[colEmployeeName.Index] as DataGridViewComboBoxCell;
                if (col != null)
                {
                    var id = col.Value as int?;
                    if (id != null)
                    {
                        var du = new DepartmentUserModel
                        {
                            UserId = id ?? 0,
                        };
                        if (decimal.TryParse(r.Cells[colRate.Index].Value?.ToString(), out decimal rate))
                        {
                            du.BuildRate = rate;
                        }
                        users.Add(du);
                    }
                }
            }
            if (users.Count == 0)
            {
                isInvalid = true;
                errorProvider1.SetError(dgvEmployees, "At one one required");
                message += "At least one employee/vendor is required";
            }

            if (isInvalid)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    PopupMessage.ShowInfoMessage(message);
                    this.Focus();
                }
                return;
            }

            var model = new DepartmentModel()
            {
                Id = _model?.Id ?? 0,
                IsVendor = departmentType.Id == (int)DepartmentTypeEnum.Vendor,
                Name = txtName.Text,
                Description = txtDescription.Text,
                DepartmentUsers = users
            };
            var success = _manufactureService.SaveDepartment(model);
            PopupMessage.ShowMessage(success.Success, success.Message);
            this.Close();
        }
    }
}
