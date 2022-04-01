using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Core.Inventory;
using SimpleInjector.Lifestyles;
using IMS.Forms.Inventory.Create;
using IMS.Forms.Inventory.Variants;
using ViewModel.Core.Inventory;
using IMS.Forms.Common.Display;
using Service.Listeners;
using Service.DbEventArgs;
using Service.Interfaces;
using IMS.Forms.Common.Pagination;
using ViewModel.Core.Common;
using IMS.Forms.Common;
using ViewModel.Core;
using IMS.Forms.MRP.ProductOwners;
using ViewModel.Utility;
using DTO.Core;

namespace IMS.Forms.MRP.Departments
{
    public partial class DepartmentListUC : BaseUserControl
    {
        public event EventHandler<BaseEventArgs<DepartmentModel>> RowSelected;

        private readonly IManufactureService _manufactureService;
        private readonly IDatabaseChangeListener _listener;
        private readonly IProductOwnerService _productOwnerService;

        //private DepartmentModel _selectedDepartment;
        // private HeaderTemplate _header;

        BindingSource _bindingSource = new BindingSource();
        private DepartmentListPaginationHelper helper;
        //int _previousSelectedIndex = -1;

        private List<DepartmentModel> _departmentList;

        public DepartmentListUC(IManufactureService manufactureService, IDatabaseChangeListener listener, IProductOwnerService productOwnerService)
        {
            this._manufactureService = manufactureService;
            _productOwnerService = productOwnerService;
            this._listener = listener;

            InitializeComponent();
            // use Header template to display header.
            // InitializeHeader();

            this.dgvDepartmentList.AutoGenerateColumns = false;
            this.Load += DepartmentListUC_Load;
        }

        private void DepartmentListUC_Load(object sender, EventArgs e)
        {
            dgvEmployees.AutoGenerateColumns = false;
            // this.heading.Text = "Department List";
            this.Dock = DockStyle.Fill;
            InitializeGridView();
            InitializeEvents();
            InitializeListeners();
            //PopulateCategoryCombo();
            PopulateDepartmentData();

        }

        #region Initialize Functions


        private void InitializeGridView()
        {
            dgvDepartmentList.AutoGenerateColumns = false;
            dgvDepartmentProducts.AutoGenerateColumns = false;
            helper = new DepartmentListPaginationHelper(_bindingSource, dgvDepartmentList, bindingNavigator1, _manufactureService);

        }


        private void InitializeEvents()
        {
            dgvDepartmentList.SelectionChanged += DgvDepartmentList_SelectionChanged;
            dgvDepartmentList.CellDoubleClick += DgvDepartmentList_CellDoubleClick;
            // dgvDepartmentList.CellFormatting += DgvDepartmentList_CellFormatting;
            btnNew.Click += BtnNew_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            // btnDelete.Click += BtnDelete_Click;
            //cbCategory.SelectedIndexChanged += CbCategory_SelectedIndexChanged;
            txtName.TextChanged += TxtName_TextChanged;
            dgvDepartmentList.DataSourceChanged += DgvDepartmentList_DataSourceChanged;

            btnAssignProducts.Click += BtnAssignProducts_Click;
            btnReleaseProducts.Click += BtnReleaseProducts_Click;
            dgvEmployees.CellClick += DgvEmployees_CellClick;
        }

        private void DgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colEmployeeAssign.Index || e.ColumnIndex == colEmployeeRelease.Index)
            {
                var userId = dgvEmployees.Rows[e.RowIndex].Cells[colEmployeeId.Index].Value as int?;
                if (userId > 0)
                {
                    ShowAssignDialog(0, userId ?? 0, e.ColumnIndex == colEmployeeAssign.Index);
                }
            }
        }

        private void BtnReleaseProducts_Click(object sender, EventArgs e)
        {
            var department = GetSelectedDepartment();
            if (department != null)
                ShowAssignDialog(department.Id, 0, Constants.OUT);
        }

        private void BtnAssignProducts_Click(object sender, EventArgs e)
        {
            var department = GetSelectedDepartment();
            if (department != null)
                ShowAssignDialog(department.Id, 0, Constants.IN);
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
                        var selectedDepartment = GetSelectedDepartment();
                        assignReleaseModel.ToId = userId;
                        assignReleaseModel.FromId = selectedDepartment.Id;
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
                        var selectedDepartment = GetSelectedDepartment();
                        assignReleaseModel.FromId = userId;
                        assignReleaseModel.ToId = selectedDepartment.Id;
                        assignReleaseModel.TransferType = ViewModel.Enums.TransferTypeEnum.UserToDepartment;
                    }
                }
                productOwnerForm.SetDataForEdit(assignReleaseModel);
                productOwnerForm.ShowDialog();
                this.Focus();
            }
        }

        private void DgvDepartmentList_DataSourceChanged(object sender, EventArgs e)
        {
            PaginationHelper.SetRowNumber(dgvDepartmentList, helper.offset);
        }

        private void InitializeListeners()
        {
            _listener.DepartmentUpdated += _listener_DepartmentUpdated;
        }


        #endregion

        #region Populate Functions


        private void PopulateDepartmentData()
        {
            dgvDepartmentList.SelectionChanged -= DgvDepartmentList_SelectionChanged;
            if (helper != null)
                helper.Reset(txtName.Text);
            dgvDepartmentList.SelectionChanged += DgvDepartmentList_SelectionChanged;

        }

        private void ShowDepartmentAddEditDialog(int departmentId)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var createUC = Program.container.GetInstance<DepartmentCreateForm>();
                createUC.SetDataForEdit(departmentId);
                createUC.ShowDialog();
            }
        }

        private void ShowDeleteDialog(DepartmentModel model)
        {
            var dialogResult = MessageBox.Show(this, "You won't be able to retrieve the department after you delete it."
                + " Are you sure to permanently delete the department '" +
                model.Name +
                "'?",
               "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                var deleted = _manufactureService.DeleteDepartment(model.Id);
                if (deleted.Data)
                    PopupMessage.ShowSuccessMessage("Deleted successfully!");
            }
            //else
            //    PopupMessage.ShowErrorMessage("Couldn't delete! Please contact administrator.");
            this.Focus();
        }


        #endregion

        #region Event Handlers

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            PopulateDepartmentData();
        }

        private void CbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDepartmentData();
        }

        private void _listener_DepartmentUpdated(object sender, BaseEventArgs<DepartmentModel> e)
        {
            AddListenerAction(PopulateDepartmentData, e);
        }

        private void DgvDepartmentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var model = dgvDepartmentList.Rows[e.RowIndex].DataBoundItem as DepartmentModel;
                if (model != null)
                {
                    var args = new BaseEventArgs<DepartmentModel>(model, Service.Utility.UpdateMode.NONE);
                    RowSelected?.Invoke(sender, args);
                }
            }
        }

        private void DgvDepartmentList_SelectionChanged(object sender, EventArgs e)
        {

            // populate detail 
            PopulateDepartmentDetail();


        }

        private void PopulateDepartmentDetail()
        {
            var visible = dgvDepartmentList.SelectedRows.Count > 0;
            // show edit and delete buttons
            btnEdit.Visible = visible;
            btnAssignProducts.Visible = visible;
            btnReleaseProducts.Visible = visible;
            btnDelete.Visible = visible;

            // btnDelete.Visible = true;
            var data = visible ? (DepartmentModel)dgvDepartmentList.SelectedRows[0].DataBoundItem : null;
            //_selectedDepartment = data;
            lblDepartmentName.Text = data?.Name ?? "";
            //var model = _inventoryService.GetDepartmentForEdit(data.Id);
            PopulateEmployeesData(data);
            if (data != null)
            {
                if (data.IsVendor)
                    lblEmployeesVendors.Text = "Vendors";
                else
                    lblEmployeesVendors.Text = "Employees";
            }
            else
            {
                lblEmployeesVendors.Text = "";
            }
            lblProductsOnHold.Text = "Products on Hold by " + (data?.Name ?? string.Empty);
            PopulateProductsOnHold(data);
        }

        private void PopulateProductsOnHold(DepartmentModel dep)
        {
            List<ProductOwnerModel> list;
            if (dep != null)
            {
                list = _productOwnerService.GetProductOnwerList(dep.Id, 0);
            }
            else
            {
                list = new List<ProductOwnerModel>();
            }
                dgvDepartmentProducts.DataSource = list;
        }

        private void PopulateEmployeesData(DepartmentModel data)
        {
            List<DepartmentUserModel> history;
            if (data != null)
            {
                history = _manufactureService.GetEmployeesOfDepartment(data.Id);
            }
            else
            {
                history = new List<DepartmentUserModel>();
            }
            dgvEmployees.DataSource = history;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ShowDepartmentAddEditDialog(0);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            // get the id from selected row
            var department = GetSelectedDepartment();
            if (department != null)
            {
                ShowDepartmentAddEditDialog(department.Id);
            }
        }

        private DepartmentModel GetSelectedDepartment()
        {
            if (dgvDepartmentList.SelectedRows.Count > 0)
                return ((DepartmentModel)dgvDepartmentList.SelectedRows[0].DataBoundItem);
            return null;
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var department = GetSelectedDepartment();
            if (department != null)
            {
                ShowDeleteDialog(department);
            }
        }


        #endregion






    }
}
