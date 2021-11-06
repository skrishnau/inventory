using IMS.Forms.Common;
using Service.Core.Settings;
using Service.Core.Users;
using Service.Interfaces;
using Service.Listeners;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Core;
using ViewModel.Core.Common;
using ViewModel.Core.Users;
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
            PopulateDepartmentType();
            InitializeEmployeeGridView();
            btnSave.Click += BtnSave_Click;
            PopulateEmployeeCombo();
            cbDepartmentType.SelectedIndexChanged += CbDepartmentType_SelectedIndexChanged;
        }

        private void CbDepartmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetEmployeeHeader();
            PopulateEmployeeCombo();
        }

        private void SetEmployeeHeader()
        {
            var type = cbDepartmentType.SelectedItem as IdNamePair;
            if (type != null)
            {
                lblEmployeesHeader.Text = type.Id == (int)DepartmentTypeEnum.Vendor ? "Vendors" : "Employees";
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
            var userIds = _model?.DepartmentUsers?.Select(x => x.Id).ToArray() ?? new int[0];
            var depType = cbDepartmentType.SelectedItem as IdNamePair;
            var userType = depType.Id == (int)DepartmentTypeEnum.Vendor ? UserTypeEnum.Vendor : ViewModel.Enums.UserTypeEnum.User;
            var users = _userService.GetUserListForCombo(userType, userIds);
            var userColumn = dgvEmployees.Columns[colEmployeeName.Index] as DataGridViewComboBoxColumn;
            if(userColumn != null)
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
            if (model != null)
            {
                _model = model;
                txtName.Text = model.Name;
                txtDescription.Text = model.Description;
                cbDepartmentType.SelectedValue = model.IsVendor ? (int)DepartmentTypeEnum.Vendor : (int)DepartmentTypeEnum.Internal;
                lblEmployeesHeader.Text = model.IsVendor ? "Vendors" : "Employees";
            }
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            var isInvalid = false;
            errorProvider1.SetError(txtName, string.Empty);
            errorProvider1.SetError(cbDepartmentType, string.Empty);
            if (string.IsNullOrEmpty(txtName.Text))
            {
                isInvalid = true;
                errorProvider1.SetError(txtName, "Required");
            }

            var departmentType = cbDepartmentType.SelectedItem as IdNamePair;
            if(departmentType == null)
            {
                isInvalid = true;
                errorProvider1.SetError(cbDepartmentType, "Required");
            }

            if (isInvalid)
                return;
            var users = new List<UserModel>();
            foreach(DataGridViewRow r in dgvEmployees.Rows)
            {
                var col = r.Cells[colEmployeeName.Index] as DataGridViewComboBoxCell;
                if(col != null)
                {
                    var id = col.Value as int?;
                    if (id != null)
                    {
                        users.Add(new UserModel
                        {
                            Id =  id ?? 0
                        });
                    }
                }
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
