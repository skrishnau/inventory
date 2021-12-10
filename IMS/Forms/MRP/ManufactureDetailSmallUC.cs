using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Core;
using ViewModel.Enums;
using Service.Interfaces;
using IMS.Forms.Common;
using SimpleInjector.Lifestyles;
using IMS.Forms.MRP.ProductOwners;
using DTO.Core;

namespace IMS.Forms.MRP
{
    public partial class ManufactureDetailSmallUC : UserControl
    {

        private readonly IManufactureService _manufactureService;

        ManufactureModel _model;

        public ManufactureDetailSmallUC(IManufactureService manufactureService)
        {
            _manufactureService = manufactureService;

            InitializeComponent();
            this.Load += ManufactureDetailSmallUC_Load;
        }

        private void ManufactureDetailSmallUC_Load(object sender, EventArgs e)
        {
            dgvDepartments.AutoGenerateColumns = false;
            dgvEmployees.AutoGenerateColumns = false;
            dgvEmployeeHistory.AutoGenerateColumns = false;

            btnStart.Click += BtnStart_Click;
            btnCancel.Click += BtnCancel_Click;
            btnComplete.Click += BtnComplete_Click;
            dgvDepartments.SelectionChanged += DgvDepartments_SelectionChanged;
            dgvEmployees.SelectionChanged += DgvEmployees_SelectionChanged;
            btnAddManufacture.Click += BtnAddManufacture_Click;
            btnAssignProduct.Click += BtnAssignProduct_Click;
        }

        private void BtnAssignProduct_Click(object sender, EventArgs e)
        {
            //var departmentId = GetSelectedDepartmentId();
            var userId = GetSelectedEmployee();
            bool inOut = true;
            if(userId != null)
                ShowAssignDialog( 0, userId ?? 0, inOut);
        }

        private void ShowAssignDialog(int departmentId, int userId, bool inOut)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var manufactureId = 0;
                var productOwnerForm = Program.container.GetInstance<ProductOwnerAssignForm>();
                var assignReleaseModel = new AssignReleaseViewModel
                {
                    ManufactureId = manufactureId,
                    AssignReleaseText = inOut ? "Assign " : "Release",

                };


                if (inOut)
                {
                    if (departmentId > 0)
                    {
                        assignReleaseModel.ToId = departmentId;
                        assignReleaseModel.TransferType = ViewModel.Enums.TransferTypeEnum.WarehouseToDepartment;

                    }
                    else if (userId > 0)
                    {
                        var selectedDepartment = GetSelectedDepartmentId();
                        assignReleaseModel.ToId = userId;
                        assignReleaseModel.FromId = selectedDepartment ?? 0;
                        assignReleaseModel.TransferType = ViewModel.Enums.TransferTypeEnum.DepartmentToUser;
                    }
                }
                else
                {
                    if (departmentId > 0)
                    {
                        assignReleaseModel.FromId = departmentId;
                        assignReleaseModel.TransferType = ViewModel.Enums.TransferTypeEnum.DepartmentToWarehouse;
                    }
                    else if (userId > 0)
                    {
                        var selectedDepartment = GetSelectedDepartmentId();
                        assignReleaseModel.FromId = userId;
                        assignReleaseModel.ToId = selectedDepartment?? 0;
                        assignReleaseModel.TransferType = ViewModel.Enums.TransferTypeEnum.UserToDepartment;
                    }
                }
                productOwnerForm.SetDataForEdit(assignReleaseModel);
                productOwnerForm.ShowDialog();
                this.Focus();
            }
        }

        public void PopulateData(ManufactureModel model)
        {
            _model = model;

            btnCancel.Visible = false;
            btnComplete.Visible = false;
            btnStart.Visible = false;
            btnAssignProduct.Visible = false;
            btnAddManufacture.Visible = false;

            if (_model != null)
            {
                lblFinalProduct.Text = _model.ManufactureProducts[0].ProductName;
                lblFinalPackage.Text = _model.ManufactureProducts[0].PackageName;
                lblFinalQuantity.Text = _model.ManufactureProducts[0].Quantity.ToString("0.00");
                lblLotNo.Text = _model.LotNo.ToString();
                lblManufactureName.Text = _model.Name;
                lblStatus.Text = _model.Status;


                if (Enum.TryParse(_model.Status, out ManufactureStatusEnum statusEnum))
                {
                    switch (statusEnum)
                    {
                        case ManufactureStatusEnum.Cancelled:
                            break;
                        case ManufactureStatusEnum.Completed:
                            break;
                        case ManufactureStatusEnum.Deleted:
                            break;
                        case ManufactureStatusEnum.In_Process:
                            btnCancel.Visible = true;
                            btnComplete.Visible = true;
                            btnAssignProduct.Visible = true;
                            btnAddManufacture.Visible = true;
                            // if final product's quantity is equal to the proposed product's quantity then show complete button
                            break;
                        case ManufactureStatusEnum.New:
                            btnStart.Visible = true;
                            break;
                    }
                }
                dgvDepartments.DataSource = model.ManufactureDepartments;

            }
        }

        private void BtnAddManufacture_Click(object sender, EventArgs e)
        {
            var departmentId = GetSelectedDepartmentId();
            if(departmentId > 0)
            {
                var userId = GetSelectedEmployee();
                if(userId > 0)
                {
                    using (AsyncScopedLifestyle.BeginScope(Program.container))
                    {
                        var productCreate = Program.container.GetInstance<UserManufactureCreateForm>();
                        productCreate.SetDataForEdit(0, _model.Id, departmentId ?? 0, userId ?? 0, false);
                        var dialogResult = productCreate.ShowDialog();
                        if(dialogResult == DialogResult.OK)
                        {
                            PopulateEmployeesHistory();
                        }
                    }
                }
            }
        }

        private void DgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                PopulateEmployeesHistory();
            }
        }

        private void DgvDepartments_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDepartments.SelectedRows.Count > 0)
            {
                PopulateEmployeesDataAndGridview();
            }
        }

        private void PopulateEmployeesDataAndGridview(int? depId = null)
        {
            try
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
                        {
                            lblEmployees.Text = department.Name;
                            lblEmployeesVendor.Text = "Vendors";
                        }
                        else
                        {
                            lblEmployees.Text = department.Name;
                            lblEmployeesVendor.Text = "Employees";
                        }
                        // populate grid view
                        List<ManufactureDepartmentUserModel> users = _manufactureService.GetEmployeesOfManufactureDepartment(_model.Id, depId ?? 0);
                        dgvEmployees.DataSource = users;
                    }
                }
            }
            catch (Exception ex)
            {

                PopupMessage.ShowInfoMessage("Couldn't populate data! Error: " + ex.Message);
                this.Focus();
            }
        }
        private void PopulateEmployeesHistory()
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                var employee = dgvEmployees.SelectedRows[0].DataBoundItem as ManufactureDepartmentUserModel;
                if (employee != null)
                {
                    lblEmployeeName.Text = "Manufacture History of " + employee.Name;
                    var departmentId = GetSelectedDepartmentId();
                    if (departmentId > 0)
                    {
                        var userId = employee.UserId;
                        if (userId > 0)
                        {
                            var employeHistory = _manufactureService.GetEmployeesHistoryOfManufactureDepartment(_model.Id, departmentId ?? 0, userId);
                            dgvEmployeeHistory.DataSource = employeHistory;
                        }
                    }
                }
            }
        }
        private int? GetSelectedEmployee()
        {
            return dgvEmployees.SelectedRows.Count > 0 ? dgvEmployees.SelectedRows[0].Cells[colEmployeesUserId.Index].Value as int? : null;
        }

        private int? GetSelectedDepartmentId()
        {
            return dgvDepartments.SelectedRows.Count > 0 ? dgvDepartments.SelectedRows[0].Cells[colDepartmentId.Index].Value as int? : null;
        }




        private void BtnComplete_Click(object sender, EventArgs e)
        {
            // check for in/out products of manufacture and each department
            var allDefined = _manufactureService.AreAllProductsManufactured(_model.Id);
            if (!allDefined.Success)
            {
                PopupMessage.ShowMessage(allDefined);
                this.Focus();
                return;
            }
            DialogResult result = MessageBox.Show(this, "Are you sure to complete this Manufacture Plan?", "Complete?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ResponseModel<bool> response = _manufactureService.SetManufactureComplete(_model.Id);
                PopupMessage.ShowMessage(response);
                this.Focus();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Are you sure to cancel this Manufacture Plan?", "Cancel?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ResponseModel<bool> response = _manufactureService.SetManufactureCancel(_model.Id);
                PopupMessage.ShowMessage(response);
                this.Focus();
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            // check for in/out products of manufacture and each department
            var allDefined = _manufactureService.IsManufactureAndDepartmentsInOutProuductsDefined(_model.Id);
            if(!allDefined.Success)
            {
                PopupMessage.ShowMessage(allDefined);
                this.Focus();
                return;
            }
            DialogResult result = MessageBox.Show(this, "You won't be able to edit this plan after starting it. Are you sure to start this Manufacture Plan?", "Start?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ResponseModel<bool> response = _manufactureService.SetManufactureStart(_model.Id);
                PopupMessage.ShowMessage(response);
                this.Focus();
            }
        }


    }
}
