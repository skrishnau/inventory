using IMS.Forms.Common;
using IMS.Forms.Common.Base;
using Service.Interfaces;
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

namespace IMS.Forms.MRP
{
    public partial class UserManufactureCreateForm : BaseDialogForm
    {
        private int _userManufacureId;
        private int _manufactureId;
        private int _departmentId;
        private int _userId;
        private bool _inOut;

        private readonly IManufactureService _manufactureService;

        private ManufactureModel _manufactureModel;
        private ManufactureDepartmentModel _manufactureDepartmentModel;
        private ManufactureDepartmentUserModel _manufactureDepartmentUserModel;
        private List<ManufactureDepartmentProductModel> _departmentProductModels;

        public UserManufactureCreateForm(IManufactureService manufactureService)
        {
            _manufactureService = manufactureService;

            InitializeComponent();
            this.Load += UserManufactureCreateForm_Load;
        }

        public void SetDataForEdit(int userManufacureId, int manufactureId, int departmentId, int userId, bool inOut)
        {
            _departmentId = departmentId;
            _userId = userId;
            _manufactureId = manufactureId;
            _userManufacureId = userManufacureId;
            _inOut = inOut;
        }

        private void UserManufactureCreateForm_Load(object sender, EventArgs e)
        {
            btnSave.Click += BtnSave_Click;
            chkAssignToNextDepartment.CheckedChanged += ChkAssignToNextDepartment_CheckedChanged;

            dgvDepartments.AutoGenerateColumns = false;

            txtQuantity.Maximum = Int16.MaxValue;

            _manufactureModel = _manufactureService.GetManufacture(_manufactureId);
            _manufactureDepartmentModel = _manufactureModel.ManufactureDepartments
                .FirstOrDefault(x => x.DepartmentId == _departmentId);
            _manufactureDepartmentUserModel = _manufactureDepartmentModel
                .ManufactureDepartmentUsers.FirstOrDefault(x => x.UserId == _userId);

            lblEmployeeName.Text = _manufactureDepartmentUserModel.Name + " (" + _manufactureDepartmentModel.Name + ")";

            //dgvDepartments.Enabled = false;

            _departmentProductModels = _manufactureDepartmentModel.ManufactureDepartmentProducts
                .Where(x => x.InOut == _inOut)
                .ToList();
            cbProduct.DataSource = _departmentProductModels;
            cbProduct.DisplayMember = "ProductName";
            cbProduct.ValueMember = "ProductId";
            var next = _manufactureModel.ManufactureDepartments.Where(x => x.Position > _manufactureDepartmentModel.Position).OrderBy(x => x.Position).FirstOrDefault();
            if (next != null)
                dgvDepartments.DataSource = _manufactureModel.ManufactureDepartments.Where(x => x.Position == next.Position).ToList();
            else
                chkAssignToNextDepartment.Checked = chkAssignToNextDepartment.Enabled = false;

        }

        private void ChkAssignToNextDepartment_CheckedChanged(object sender, EventArgs e)
        {
            dgvDepartments.Enabled = chkAssignToNextDepartment.Checked;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(cbProduct, string.Empty);
            errorProvider1.SetError(txtQuantity, string.Empty);
            var isValid = true;
            var message = string.Empty;
            var productId = cbProduct.SelectedValue as int?;
            if (!(productId > 0))
            {
                isValid = false;
                errorProvider1.SetError(cbProduct, "Required");
            }
            int packageId = 0;
            var depProduct = _departmentProductModels.FirstOrDefault(x => x.ProductId == productId);
            if (depProduct != null)
            {
                packageId = depProduct.PackageId;
            }
            //var packageId = cbPackage.SelectedValue as int?;
            //if (!(packageId > 0))
            //{
            //    isValid = false;
            //    errorProvider1.SetError(cbPackage, "Required");
            //}
            if (txtQuantity.Value <= 0)
            {
                isValid = false;
                errorProvider1.SetError(txtQuantity, "Required");
            }

            List<ProductOwnerModel> newOwners = new List<ProductOwnerModel>();
            if (chkAssignToNextDepartment.Checked)
            {
                foreach (DataGridViewRow row in dgvDepartments.Rows)
                {
                    row.Cells[colDepartmentQuantity.Index].ErrorText = string.Empty;
                    var manufactureDepartmentId = row.Cells[colManufactureDepartmentId.Index].Value as int?;
                    var departmentId = row.Cells[colDepartmentId.Index].Value as int?;
                    decimal.TryParse(row.Cells[colDepartmentQuantity.Index].Value.ToString(), out decimal quantity);

                    var departmentProduct = new ProductOwnerModel()
                    {
                        DepartmentId = departmentId,
                        PackageId = packageId,
                        ProductId = productId ?? 0,
                        Quantity = quantity,
                        UpdatedAt = DateTime.Now,
                    };
                    newOwners.Add(departmentProduct);
                }
                if (newOwners.Count == 0 || newOwners.Sum(x => x.Quantity) == 0)
                {
                    isValid = false;
                    message += "At least one department's assign quantity is required.";
                }
            }

            if (!isValid)
                return;
            if (!string.IsNullOrEmpty(message))
            {
                PopupMessage.ShowInfoMessage(message);
                this.Focus();
            }

            var userManufactureModel = new UserManufactureModel
            {
                BuildRate = _manufactureDepartmentUserModel.BuildRate,
                ManufactureDepartmentUserId = _manufactureDepartmentUserModel.Id,
                UserId = _userId,
                Date = DateTime.Now,
                InOut = false,
                ProductId = productId ?? 0,//_manufactureProductModel.ProductId,
                Quantity = txtQuantity.Value,
                NextProductOwners = newOwners,
                DepartmentId = _manufactureDepartmentModel.DepartmentId,
                PackageId = packageId,
            };
            var response = _manufactureService.AddUserManufacture(userManufactureModel);
            PopupMessage.ShowMessage(response.Success, response.Message);
            if (response.Success)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    }
}
