using Service.Core.Settings;
using Service.Core.Users;
using Service.Interfaces;
using Service.Listeners;
using SimpleInjector.Lifestyles;
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

namespace IMS.Forms.MRP
{
    public partial class ManufactureCreateForm : Form
    {
        private readonly IManufactureService _manufactureService;
        private readonly IAppSettingService _appSettingService;
        private readonly IProductService _productService;
        private readonly IDatabaseChangeListener _databaseChangeListener;
        private readonly IUserService _userService;

        int _id = 0;


        public ManufactureCreateForm(IManufactureService manufactureService, IAppSettingService appSettingService, IProductService productService, IDatabaseChangeListener databaseChangeListener, IUserService userService)
        {
            _manufactureService = manufactureService;
            _appSettingService = appSettingService;
            _productService = productService;
            _databaseChangeListener = databaseChangeListener;
            _userService = userService;

            InitializeComponent();

            this.Load += ManufactureCreateForm_Load;
        }

        private void ManufactureCreateForm_Load(object sender, EventArgs e)
        {
            InitializeDepartmentGridView();
            btnSave.Click += BtnSave_Click;
            PopulateFinalProduct();
            PopulateFinalPackage();
            cbFinalProduct.SelectedValueChanged += CbFinalProduct_SelectedValueChanged;
            PopulateDepartmentCombo();
            btnDepartmentAdd.Click += BtnDepartmentAdd_Click;
            dgvDepartments.DataError += DgvDepartments_DataError;
            dgvDepartments.SelectionChanged += DgvDepartments_SelectionChanged;
        }

        #region Populate Functions

        private void InitializeDepartmentGridView()
        {
            dgvDepartments.AutoGenerateColumns = false;
            dgvDepartments.AllowUserToAddRows = true;
            dgvDepartments.AllowUserToDeleteRows = true;
            dgvDepartments.MultiSelect = false;
            dgvDepartments.SelectionMode = DataGridViewSelectionMode.CellSelect;

            //dgvDepartments.AutoGenerateColumns = false;
            //dgvDepartments.AllowUserToAddRows = true;
            //dgvDepartments.AllowUserToDeleteRows = true;
            //dgvDepartments.MultiSelect = false;
            //dgvDepartments.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }
        public void SetDataForEdit(int id)
        {
            var model = _manufactureService.GetManufacture(id);
            if (model != null)
            {
                _id = model.Id;
                txtName.Text = model.Name;
                txtLotNo.Value = model.LotNo;
                txtRemarks.Text = model.Remarks;
            }
            else
            {
                txtLotNo.Value = _manufactureService.GetLastLotNo() + 1;
            }
        }

        private void Save()
        {
            var isInvalid = false;
            errorProvider1.SetError(txtName, string.Empty);
            errorProvider1.SetError(txtLotNo, string.Empty);
            if (string.IsNullOrEmpty(txtName.Text))
            {
                isInvalid = true;
                errorProvider1.SetError(txtName, "Required");
            }
            if (txtLotNo.Value <= 0)
            {
                isInvalid = true;
                errorProvider1.SetError(txtLotNo, "Should be greater than zero");
            }

            if (isInvalid)
                return;
            var model = new ManufactureModel()
            {
                Id = _id,
                LotNo = (int)txtLotNo.Value,
                Name = txtName.Text,
                Remarks = txtRemarks.Text,
            };
            bool success = _manufactureService.SaveManufacture(model);
            this.Close();
        }

        private void PopulateFinalProduct()
        {
            var products = _productService.GetBuildProductListForCombo();
            products.Insert(0, new IdNamePair { Id = 0, Name = "--- Select ---" });
            cbFinalProduct.DataSource = products;
            cbFinalProduct.ValueMember = "Id";
            cbFinalProduct.DisplayMember = "Name";
        }
        private void PopulateFinalPackage()
        {
            var product = cbFinalProduct.SelectedItem as IdNamePair;
            if (product != null)
            {
                var packages = _productService.GetPackagesOfProduct(product.Id);
                cbFinalPackage.DataSource = packages;
                cbFinalPackage.ValueMember = "Id";
                cbFinalPackage.DisplayMember = "Name";
            }
        }

        private void PopulateDepartmentCombo()
        {
            var departments = _manufactureService.GetDepartmentList();
            var departmentColumn = dgvDepartments.Columns[colDepartmentId.Index] as DataGridViewComboBoxColumn;
            if (departmentColumn != null)
            {
                departmentColumn.DataSource = departments;
                departmentColumn.ValueMember = "Id";
                departmentColumn.DisplayMember = "Name";
            }
        }

        private void PopulateEmployees(int depId)
        {
            var users = _userService.GetUserListForComboByDepartmentId(depId, new int[0]);
            dgvEmployees.DataSource = users;
        }

        #endregion


        #region Events


        private void CbFinalProduct_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateFinalPackage();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void BtnDepartmentAdd_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var form = Program.container.GetInstance<DepartmentCreateForm>();
                form.ShowDialog();
                this.Focus();
                PopulateDepartmentCombo();
            }
        }
        private void DgvDepartments_SelectionChanged(object sender, EventArgs e)
        {
            var row = dgvDepartments.SelectedRows.Count > 0 ? dgvDepartments.SelectedRows[0] : null;
            if (row != null)
            {
                var cell = dgvDepartments.SelectedRows[0].Cells[colDepartmentName.Index] as DataGridViewComboBoxCell;
                if (cell != null)
                {
                    var depId = cell.Value as int?;
                    if (depId != null)
                    {
                        PopulateEmployees((int)depId);
                    }
                }
            }
        }

        private void DgvDepartments_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            foreach (DataGridViewRow row in dgvDepartments.Rows)
            {
                var cell = row.Cells[colDepartmentName.Index] as DataGridViewComboBoxCell;
                if (cell != null)
                {
                    cell.Value = null;
                }
            }
        }

        #endregion


    }
}
