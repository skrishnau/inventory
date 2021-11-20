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

        private readonly IManufactureService _manufactureService;

        private ManufactureDepartmentUserModel _manufactureDepartmentUserModel;
        private ManufactureModel _manufactureModel;
        private ManufactureProductModel _manufactureProductModel;

        public UserManufactureCreateForm(IManufactureService manufactureService)
        {
            _manufactureService = manufactureService;

            InitializeComponent();
            this.Load += UserManufactureCreateForm_Load;
        }


        private void UserManufactureCreateForm_Load(object sender, EventArgs e)
        {
            btnSave.Click += BtnSave_Click;

            txtQuantity.Maximum = Int16.MaxValue;
            _manufactureModel = _manufactureService.GetManufacture(_manufactureId);
            _manufactureDepartmentUserModel = _manufactureService.GetManufactureDepartmentUser(_manufactureId, _departmentId, _userId);
            _manufactureProductModel = _manufactureModel.ManufactureProducts.FirstOrDefault();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(cbProduct, string.Empty);
            errorProvider1.SetError(cbPackage, string.Empty);
            errorProvider1.SetError(txtQuantity, string.Empty);
            var isValid = true;
            var message = string.Empty;
            var productId = cbProduct.SelectedValue as int?;
            if (!(productId > 0))
            {
                isValid = false;
                errorProvider1.SetError(cbProduct, "Required");
            }

            var packageId = cbPackage.SelectedValue as int?;
            if (!(packageId > 0))
            {
                isValid = false;
                errorProvider1.SetError(cbPackage, "Required");
            }
            if (txtQuantity.Value <= 0)
            {
                isValid = false;
                errorProvider1.SetError(txtQuantity, "Required");
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
                ProductId = _manufactureProductModel.ProductId,
                Quantity = txtQuantity.Value,
            };
            var response = _manufactureService.AddUserManufacture(userManufactureModel);
        }

        public void SetDataForEdit(int userManufacureId, int manufactureId, int departmentId, int userId)
        {
            _departmentId = departmentId;
            _userId = userId;
        }
    }
}
