using IMS.Forms.Common;
using IMS.Forms.Common.GridView;
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

        private GridViewColumnDecimalValidator _decimalValidator;

        private Dictionary<int, List<ManufactureDepartmentUserModel>> _employees = new Dictionary<int, List<ManufactureDepartmentUserModel>>();

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
            InitializeGridView();
            btnSave.Click += BtnSave_Click;
            PopulateFinalProduct();
            PopulateFinalPackage();
            cbFinalProduct.SelectedValueChanged += CbFinalProduct_SelectedValueChanged;
            PopulateDepartmentCombo();
            btnDepartmentAdd.Click += BtnDepartmentAdd_Click;
            dgvDepartments.DataError += DgvDepartments_DataError;
            dgvEmployees.DataError += DgvEmployees_DataError;
            dgvDepartments.SelectionChanged += DgvDepartments_SelectionChanged;
            dgvEmployees.CellEndEdit += DgvEmployees_CellEndEdit;
            dgvDepartments.EditingControlShowing += DgvDepartments_EditingControlShowing;
            btnMoveUp.Click += BtnMoveUp_Click;
            btnMoveDown.Click += BtnMoveDown_Click;
            dgvDepartments.RowsAdded += DgvDepartments_RowsAdded;
            dgvDepartments.CellClick += DgvDepartments_CellClick;

            PopulateDataForEdit();

            // decimal validator
            _decimalValidator = new GridViewColumnDecimalValidator(dgvEmployees);
            _decimalValidator.AddColumn(this.colEmployeesRate, ColumnDataType.Decimal);
            _decimalValidator.Validate();
        }

        private void DgvDepartments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colDeparmentDelete.Index)
            {
                if (!dgvDepartments.Rows[e.RowIndex].IsNewRow)
                {
                    var selectedDepartment = GetSelectedDepartmentId();
                    if (selectedDepartment != null)
                    {
                        dgvDepartments.Rows.RemoveAt(e.RowIndex);
                        if (_employees.ContainsKey(selectedDepartment ?? 0))
                        {
                            _employees.Remove(selectedDepartment ?? 0);
                        }
                    }
                }
            }
        }

        private void PopulateDataForEdit()
        {
            var model = _manufactureService.GetManufacture(_id);
            if (model != null)
            {
                txtName.Text = model.Name;
                txtLotNo.Value = model.LotNo;
                txtRemarks.Text = model.Remarks;

                var rowsEmpty = dgvDepartments.Rows.Count == 0;
                if (rowsEmpty)
                    dgvDepartments.Rows.Add(new DataGridViewRow());
                foreach (var dep in model.ManufactureDepartments)
                {

                    AddRow(dep);
                    // employees data add
                    if (!_employees.ContainsKey(dep.DepartmentId))
                        _employees.Add(dep.DepartmentId, new List<ManufactureDepartmentUserModel>());
                    _employees[dep.DepartmentId].Clear();
                    _employees[dep.DepartmentId].AddRange(dep.ManufactureDepartmentUsers.Select(x => new ManufactureDepartmentUserModel { UserId = x.UserId, Check = true, BuildRate = x.BuildRate }).ToList());
                }

                var manuProd = model.ManufactureProducts?.FirstOrDefault(x => x.InOut == false && x.ProposedOrProduction == false);
                if (manuProd != null)
                {
                    txtFinalQuantity.Value = manuProd.Quantity ?? 0;
                    cbFinalProduct.SelectedValue = manuProd.ProductId;
                    //PopulateFinalPackage();
                    cbFinalPackage.SelectedValue = manuProd.PackageId;
                }

                if (rowsEmpty)
                    dgvDepartments.Rows.RemoveAt(0);

                //PopulateEmployeesDataAndGridview();
            }
            else
            {
                txtLotNo.Value = _manufactureService.GetLastLotNo() + 1;
            }
        }

        private void AddRow(ManufactureDepartmentModel dep)
        {
            if (dgvDepartments.Rows.Count > 0)
            {
                DataGridViewRow row = (DataGridViewRow)dgvDepartments.Rows[dgvDepartments.Rows.Count - 1].Clone();
                row.Cells[colDepartmentName.Index].Value = dep.DepartmentId;
                row.Cells[colDepartmentPosition.Index].Value = dep.Position;
                row.DefaultCellStyle.BackColor = Color.White;
                dgvDepartments.Rows.Add(row);

            }
        }



        #region Populate Functions


        private void InitializeGridView()
        {
            dgvDepartments.AutoGenerateColumns = false;
            dgvDepartments.AllowUserToAddRows = true;
            dgvDepartments.AllowUserToDeleteRows = true;
            dgvDepartments.MultiSelect = false;
            dgvDepartments.SelectionMode = DataGridViewSelectionMode.CellSelect;

            dgvEmployees.AutoGenerateColumns = false;
            //dgvEmployees.AllowUserToAddRows = true;
            //dgvEmployees.AllowUserToDeleteRows = true;
            dgvEmployees.MultiSelect = false;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        public void SetDataForEdit(int id)
        {
            _id = id;
        }

        private void Save()
        {
            List<string> message = new List<string>();
            var isInvalid = false;
            errorProvider1.SetError(txtName, string.Empty);
            errorProvider1.SetError(txtLotNo, string.Empty);
            errorProvider1.SetError(cbFinalProduct, string.Empty);
            errorProvider1.SetError(cbFinalPackage, string.Empty);
            errorProvider1.SetError(txtFinalQuantity, string.Empty);
            errorProvider1.SetError(dgvDepartments, string.Empty);
            errorProvider1.SetError(dgvEmployees, string.Empty);
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
            var departments = new List<ManufactureDepartmentModel>();
            var i = 1;
            foreach (DataGridViewRow row in dgvDepartments.Rows)
            {
                if (row.IsNewRow)
                    continue;

                var depCell = row.Cells[colDepartmentName.Index];
                var posCell = row.Cells[colDepartmentPosition.Index];
                depCell.ErrorText = string.Empty;
                posCell.ErrorText = string.Empty;
                if (!int.TryParse(depCell.Value?.ToString(), out int depIdInt))
                {
                    depCell.ErrorText = "Required";
                    isInvalid = true;
                }
                if (departments.Any(x => x.DepartmentId == depIdInt))
                {
                    depCell.ErrorText = "Duplicate";
                    isInvalid = true;
                }
                var employees = new List<ManufactureDepartmentUserModel>();
                if (_employees.ContainsKey(depIdInt))
                    employees = _employees[depIdInt].Where(x => x.Check).ToList();
                if (employees.Count == 0)
                {
                    isInvalid = true;
                    message.Add("At least one employee/vendor required in each department");
                }
                if (employees.Any(x => x.BuildRate == null || x.BuildRate == 0))
                {
                    isInvalid = true;
                    message.Add("Rates of some employees/vendors are not defined. Please enter rates.");
                }
                if (!int.TryParse(posCell.Value?.ToString(), out int position))
                {
                    isInvalid = true;
                    posCell.ErrorText = "Required";
                }
                var dep = new ManufactureDepartmentModel()
                {
                    Position = position,
                    DepartmentId = depIdInt,
                    ManufactureDepartmentUsers = employees
                };
                departments.Add(dep);
                i++;
            }

            if (departments.Count == 0)
            {
                isInvalid = true;
                errorProvider1.SetError(dgvDepartments, "At least one required");
                message.Add("At least one department is required");
            }
            // products
            var productIdObj = cbFinalProduct.SelectedValue?.ToString();
            if (!int.TryParse(productIdObj, out int productId) || productId <= 0)
            {
                isInvalid = true;
                errorProvider1.SetError(cbFinalProduct, "Required");
            }

            if (!int.TryParse(cbFinalPackage.SelectedValue?.ToString(), out int packageId))
            {
                isInvalid = true;
                errorProvider1.SetError(cbFinalPackage, "Required");
            }
            if (txtFinalQuantity.Value <= 0)
            {
                isInvalid = true;
                errorProvider1.SetError(txtFinalQuantity, "Should be greater than zero");
            }

            if (isInvalid)
            {
                if (message.Count > 0)
                    PopupMessage.ShowInfoMessage(string.Join("\r\n", message.Distinct()));
                this.Focus();
                return;
            }
            var products = new List<ManufactureProductModel>
            {
                new ManufactureProductModel
                {
                    InOut = false, // in = 1, out = 0
                    ProductId = productId,
                    PackageId = packageId,
                    Quantity = txtFinalQuantity.Value,
                    ProposedOrProduction = false // proposed = 0, production = 1
                }
            };
            var model = new ManufactureModel()
            {
                Id = _id,
                LotNo = (int)txtLotNo.Value,
                Name = txtName.Text,
                Remarks = txtRemarks.Text,
                ManufactureDepartments = departments,
                ManufactureProducts = products
            };
            var success = _manufactureService.SaveManufacture(model);
            PopupMessage.ShowMessage(success.Success, success.Message);
            if (success.Success)
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
            var departments = _manufactureService.GetDepartmentListForManufacture();
            var departmentColumn = dgvDepartments.Columns[colDepartmentName.Index] as DataGridViewComboBoxColumn;
            if (departmentColumn != null)
            {
                departmentColumn.DataSource = departments;
                departmentColumn.ValueMember = "DepartmentId";
                departmentColumn.DisplayMember = "Name";
            }
        }
        private int? GetSelectedDepartmentId(int? rowIndex = null)
        {
            DataGridViewRow selectedRow = null;
            if (rowIndex == null)
            {
                selectedRow = dgvDepartments.CurrentRow;
            }
            else
            {
                selectedRow = dgvDepartments.Rows[rowIndex ?? 0];
            }
            if (selectedRow != null)
            {
                var cell = dgvDepartments.Rows[selectedRow.Index].Cells[colDepartmentName.Index] as DataGridViewComboBoxCell;
                if (cell != null)
                {
                    var depId = cell.Value as int?;
                    return depId;
                }
            }
            return null;
        }

        private void PopulateEmployeesDataAndGridview(int? depId = null)
        {
            if (depId == null)
                depId = GetSelectedDepartmentId();

            if (depId != null)
            {
                var depIdInt = (int)depId;
                var department = _manufactureService.GetDepartment(depIdInt);
                if (department != null)
                {
                    if (department.IsVendor)
                        lblEmployees.Text = $"Vendors of {department.Name}";
                    else
                        lblEmployees.Text = $"Employees of {department.Name}";
                    PopulateEmployeesGridview(depIdInt);
                }
            }

        }
        private void PopulateEmployeesGridview(int depId)
        {
            try
            {
                List<ManufactureDepartmentUserModel> users = _userService.GetUserListForComboByDepartmentId(_id, depId, new int[0]);
                // at initial point set Check = true for all
                // uncheck those that were already unchecked earlier
                foreach (var user in users)
                {
                    if (_employees.ContainsKey(depId))
                    {
                        var userInList = _employees[depId].FirstOrDefault(x => x.UserId == user.UserId);
                        if (userInList != null)
                        {
                            user.Check = userInList.Check;
                            user.BuildRate = userInList.BuildRate;
                        }
                        else
                        {
                            user.Check = false;
                        }

                    }
                    //else
                    //{
                    //    user.Check = true;
                    //}
                }
                if (_employees.ContainsKey(depId))
                {
                    foreach (var u in _employees[depId])
                    {
                        if (!u.Check)
                        {
                            var user = users.FirstOrDefault(x => x.UserId == u.UserId);
                            if (user != null)
                            {
                                user.Check = u.Check;
                                user.BuildRate = u.BuildRate;
                            }
                        }
                    }
                }
                dgvEmployees.DataSource = users;
            }
            catch (Exception ex)
            {

                PopupMessage.ShowInfoMessage("Couldn't populate data! Error: " + ex.Message);
                this.Focus();
            }
        }


        private void ReorderDepartmentList(int v)
        {
            try
            {
                var rowIndex = dgvDepartments.CurrentCell.RowIndex;
                if (v == 1 && rowIndex == 0)
                    return;
                if (v == -1 && rowIndex == dgvDepartments.Rows.Count - 2) // new row is always present which shouldn't be counted hence done -2 instead of -1
                    return;
                if (dgvDepartments.Rows[dgvDepartments.CurrentCell.RowIndex].IsNewRow)
                    return;
                var cell = dgvDepartments.Rows[rowIndex].Cells[colDepartmentPosition.Index];
                var value = cell.Value?.ToString();
                int.TryParse(value, out int valueInt);
                // lowest on top. so when btnDown is clicked v=-1 but we need to increment the index hence, it's done => minus v
                cell.Value = valueInt - v;
                if (v == -1)
                {
                    if (dgvDepartments.RowCount > (rowIndex + 1))
                    {
                        var belowCell = dgvDepartments.Rows[rowIndex + 1].Cells[colDepartmentPosition.Index];
                        if (belowCell.Value != null)
                        {
                            belowCell.Value = valueInt;
                        }
                    }
                }
                else if (v == 1)
                {
                    if (dgvDepartments.RowCount > (rowIndex + 1))
                    {
                        var belowCell = dgvDepartments.Rows[rowIndex - 1].Cells[colDepartmentPosition.Index];
                        if (belowCell.Value != null)
                        {
                            belowCell.Value = valueInt;
                        }
                    }
                }
                dgvDepartments.NotifyCurrentCellDirty(true);
                dgvDepartments.Sort(colDepartmentPosition, ListSortDirection.Ascending);
            }
            catch (Exception ex) { }
        }

        #endregion


        #region Events


        private void DgvDepartments_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!dgvDepartments.Rows[e.RowIndex].IsNewRow)
            {
                if (dgvDepartments.Rows[e.RowIndex].Cells[colDepartmentPosition.Index].Value == null)
                    dgvDepartments.Rows[e.RowIndex].Cells[colDepartmentPosition.Index].Value = dgvDepartments.RowCount - 1;
            }
            else
            {
                if (e.RowIndex - 1 >= 0)
                    dgvDepartments.Rows[e.RowIndex - 1].Cells[colDepartmentPosition.Index].Value = dgvDepartments.RowCount - 1;
            }
        }

        private void BtnMoveUp_Click(object sender, EventArgs e)
        {
            ReorderDepartmentList(1);
        }

        private void BtnMoveDown_Click(object sender, EventArgs e)
        {
            ReorderDepartmentList(-1);
        }
        private void DgvDepartments_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvDepartments.CurrentCell.ColumnIndex == colDepartmentName.Index && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged -= DepartmentColumnComboSelectionChanged;
                comboBox.SelectedIndexChanged += DepartmentColumnComboSelectionChanged;
            }
        }

        private void DepartmentColumnComboSelectionChanged(object sender, EventArgs e)
        {
            if (dgvDepartments.CurrentCell.ColumnIndex != colDepartmentName.Index)
                return;
            var combo = sender as ComboBox;
            if (combo != null)
            {
                var selectedItem = combo.SelectedItem as ManufactureDepartmentModel;
                if (selectedItem != null)
                {
                    var depId = int.Parse(selectedItem.DepartmentId.ToString());
                    PopulateEmployeesDataAndGridview(depId);
                }

            }
        }

        private void DgvEmployees_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var depId = GetSelectedDepartmentId();
            if (depId != null)
            {
                var depIdInt = (int)depId;
                if (!_employees.ContainsKey(depIdInt))
                    _employees.Add(depIdInt, new List<ManufactureDepartmentUserModel>());
                _employees[depIdInt].Clear();
                foreach (DataGridViewRow row in dgvEmployees.Rows)
                {
                    if (row.IsNewRow)
                        continue;
                    var check = row.Cells[colEmployeesCheck.Index].FormattedValue?.ToString();
                    var userId = row.Cells[colEmployeesId.Index].Value?.ToString();
                    decimal.TryParse(row.Cells[colEmployeesRate.Index].FormattedValue?.ToString(), out decimal buildRate);

                    if (int.TryParse(userId, out int userIdInt))
                        _employees[depIdInt].Add(new ManufactureDepartmentUserModel { Check = check == "True", UserId = userIdInt, BuildRate = buildRate });
                }
            }
        }

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
            PopulateEmployeesDataAndGridview();
            var selectedRowIndex = dgvDepartments.SelectedCells.Count > 0 ? dgvDepartments.SelectedCells[0].RowIndex : 0;
            foreach (DataGridViewRow row in dgvDepartments.Rows)
            {
                if (row.Index == selectedRowIndex)
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                else
                    row.DefaultCellStyle.BackColor = Color.White;
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

        private void DgvEmployees_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //foreach (DataGridViewRow row in dgvEmployees.Rows)
            //{
            //    var cell = row.Cells[colEmployeesName.Index] as DataGridViewComboBoxCell;
            //    if (cell != null)
            //    {
            //        cell.Value = null;
            //    }
            //}
        }

        #endregion


    }
}
