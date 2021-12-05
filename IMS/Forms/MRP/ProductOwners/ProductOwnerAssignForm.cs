using DTO.Core;
using IMS.Forms.Common;
using IMS.Forms.Common.Base;
using IMS.Forms.Common.Validations;
using Service.Core.Business;
using Service.Core.Inventory;
using Service.Core.Orders;
using Service.Core.Settings;
using Service.Core.Users;
using Service.DbEventArgs;
using Service.Interfaces;
using Service.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ViewModel.Core;
using ViewModel.Core.Common;
using ViewModel.Core.Inventory;
using ViewModel.Core.Orders;
using ViewModel.Enums;

namespace IMS.Forms.MRP.ProductOwners
{
    public partial class ProductOwnerAssignForm : BaseDialogForm
    {
        private readonly IUserService _userService;
        private readonly IDatabaseChangeListener _listener;
        private readonly IBusinessService _businessService;
        private readonly IOrderService _orderService;
        private readonly IInventoryService _inventoryService;
        private readonly IProductService _productService;
        private readonly IAppSettingService _appSettingService;
        private readonly IUomService _uomService;
        private readonly IManufactureService _manufactureService;
        private readonly IProductOwnerService _productOwnerService;

        List<IdNamePair> fromDatasource = new List<IdNamePair>();
        List<IdNamePair> toDatasource = new List<IdNamePair>();

        private AssignReleaseViewModel _assignRelease;

        public ProductOwnerAssignForm(IUserService userService,
            IBusinessService businessService,
            IInventoryService inventoryService,
            IProductService productService,
            IOrderService purchaseService,
            IDatabaseChangeListener listener,
            IAppSettingService appSettingService,
            IUomService uomService,
            IManufactureService manufactureService,
            IProductOwnerService productOwnerService)
        {
            _listener = listener;
            this._businessService = businessService;
            this._userService = userService;
            this._orderService = purchaseService;
            this._inventoryService = inventoryService;
            this._productService = productService;
            this._appSettingService = appSettingService;
            this._uomService = uomService;
            this._manufactureService = manufactureService;
            _productOwnerService = productOwnerService;

            InitializeComponent();
            this.Load += TransactionCreateForm_Load;
        }


        private void TransactionCreateForm_Load(object sender, EventArgs e)
        {
            dgvItems.InitializeGridViewControls(_inventoryService, _productService, _uomService, _productOwnerService, assignRelease: _assignRelease);
            InitializeValidation();
            InitializeEvents();
            InitializeDataGridView();
            PopulateModel();

        }

        #region Functions

        public void SetDataForEdit(AssignReleaseViewModel assignRelease)
        {
            _assignRelease = assignRelease;

        }

        private void InitializeDataGridView()
        {
            dgvItems.DesignForAssignRelease();
        }


        private void InitializeEvents()
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;

            dgvItems.AmountChanged += DgvItems_AmountChnanged;
            dgvItems.RowsRemoved += DgvItems_RowsRemoved;

            cbFrom.SelectedIndexChanged += CbFrom_SelectedIndexChanged;
            cbTo.SelectedIndexChanged += CbTo_SelectedIndexChanged;
        }



        private void DgvItems_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (e.RowCount > 0)
            {
                //txtTotal.Value = dgvItems.GetTotalSumAmount();
            }
        }

        private void InitializeValidation()
        {
            /*
            // required field validator
            List<Control> requiredControls = new List<Control>()
            {
                //txtReceiptNo, // recipt no . is not required in case of Order-save
            };
           

            _requiredFieldValidator = new RequiredFieldValidator(errorProvider, requiredControls.ToArray());
            // greater than zero field validator
            List<Control> controls = new List<Control>()
            {
                    txtSum,
            };
            _greaterThanZeroFieldValidator = new GreaterThanZeroFieldValidator(errorProvider, controls.ToArray(), true);
            */
        }



        private void PopulateModel()
        {
            ManufactureModel manufacture = null;
            DepartmentModel department = null;
            UserModel user = null;
            if (_assignRelease.FromId > 0)
            {
                cbFrom.Enabled = false;
            }
            if (_assignRelease.ToId > 0)
            {
                cbTo.Enabled = false;
            }

            switch (_assignRelease.TransferType)
            {
                case TransferTypeEnum.WarehouseToWarehouse:
                    fromDatasource = _inventoryService.GetWarehouseListForCombo();
                    toDatasource = _inventoryService.GetWarehouseListForCombo();

                    break;
                case TransferTypeEnum.WarehouseToDepartment:
                    fromDatasource = _inventoryService.GetWarehouseListForCombo();
                    toDatasource = _manufactureService.GetDepartmentListForCombo(_assignRelease.ManufactureId);
                    break;
                case TransferTypeEnum.DepartmentToWarehouse:
                    fromDatasource = _manufactureService.GetDepartmentListForCombo(_assignRelease.ManufactureId);
                    toDatasource = _inventoryService.GetWarehouseListForCombo();
                    break;
                case TransferTypeEnum.DepartmentToDepartment:
                    fromDatasource = _manufactureService.GetDepartmentListForCombo(_assignRelease.ManufactureId);
                    toDatasource = _manufactureService.GetDepartmentListForCombo(_assignRelease.ManufactureId);
                    break;
                case TransferTypeEnum.DepartmentToUser:
                    fromDatasource = _manufactureService.GetDepartmentListForCombo(_assignRelease.ManufactureId);
                    toDatasource = _userService.GetUserListForComboByDepartmentId(_assignRelease.ManufactureId, _assignRelease.FromId, null)
                       .Select(x => new IdNamePair
                       {
                           Id = x.UserId,
                           Name = x.Name
                       })
                       .ToList();
                    break;
                case TransferTypeEnum.UserToDepartment:
                    fromDatasource = _userService.GetUserListForComboByDepartmentId(_assignRelease.ManufactureId, _assignRelease.ToId, null)
                        .Select(x => new IdNamePair
                        {
                            Id = x.UserId,
                            Name = x.Name
                        })
                        .ToList();
                    toDatasource = _manufactureService.GetDepartmentListForCombo(_assignRelease.ManufactureId, _assignRelease.FromId);
                    break;
            }

            if (_assignRelease.ManufactureId > 0)
            {
                manufacture = _manufactureService.GetManufacture(_assignRelease.ManufactureId);
            }
            cbFrom.ValueMember = "Id";
            cbFrom.DisplayMember = "Name";
            // always id name pair
            cbFrom.DataSource = fromDatasource;

            cbTo.ValueMember = "Id";
            cbTo.DisplayMember = "Name";
            cbTo.DataSource = toDatasource;
            


            lblFrom.Text = "From " + _assignRelease.FromType.ToString();
            lblTo.Text = "To " + _assignRelease.ToType.ToString();

            var heading = _assignRelease.AssignReleaseText;
            if (_assignRelease.FromId > 0)
            {
                var from = fromDatasource.FirstOrDefault(x => x.Id == _assignRelease.FromId);
                if (from != null)
                {
                    if (bool.TryParse(from.ExtraValue, out bool isVendor) && isVendor)
                        lblFrom.Text = "From Vendor";

                    cbFrom.SelectedValue = _assignRelease.FromId;
                    heading += " from " + from.Name;
                }
            }
            if (_assignRelease.ToId > 0)
            {
                var to = toDatasource.FirstOrDefault(x => x.Id == _assignRelease.ToId);
                if (to != null)
                {
                    if (bool.TryParse(to.ExtraValue, out bool isVendor) && isVendor)
                        lblFrom.Text = "To Vendor";

                    cbTo.SelectedValue = _assignRelease.ToId;
                    heading += " to " + to.Name;
                }
            }
            lblHeading.Text = heading;//(productOwner == ProductOwnerEnum.User ? user.Name + " (Employee)" : department.Name + " (Department)");
            this.Text = heading;//assignRelease + (productOwner == ProductOwnerEnum.User ? user.Name : department.Name);
            dtDate.SetValue(DateTime.Now);
            //CbFrom_SelectedIndexChanged(null, null);
        }
        private void CbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // available products and onhold quantity
            List<ProductModel> products = null;
            var fromId = cbFrom.SelectedValue as int?;
            if (fromId > 0)
            {
                switch (_assignRelease.TransferType)
                {
                    case TransferTypeEnum.DepartmentToDepartment:
                        //products = _manufactureService.GetManufactureDepartmentInProducts()
                        break;
                }
            }
        }

        private void CbFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fromId = cbFrom.SelectedValue as int?;
            if (fromId > 0)
            {
                switch (_assignRelease.FromType)
                {
                    case FromToType.Warehouse:
                        // TODO:
                        break;
                    case FromToType.Department:
                        var productList = _productOwnerService.GetCurrentProductsOfOwner(fromId ?? 0, 0);
                        dgvItems.SetProductList(productList);
                        break;
                    case FromToType.Employee:
                        var userProductList = _productOwnerService.GetCurrentProductsOfOwner(0, fromId ?? 0);
                        dgvItems.SetProductList(userProductList);
                        break;
                }
                switch (_assignRelease.TransferType)
                {
                    // TODO: implement others
                    case TransferTypeEnum.WarehouseToDepartment:
                        // TODO : in case of multiple warehouse (need to workout)
                        break;
                    case TransferTypeEnum.DepartmentToUser:
                        toDatasource = _manufactureService.GetEmployeesOfDepartment(fromId ?? 0)
                            .Select(x => new IdNamePair
                            {
                                Id = x.UserId ?? 0,
                                Name = x.User
                            })
                            .ToList();
                        cbTo.DataSource = toDatasource;
                        break;
                    case TransferTypeEnum.UserToDepartment:
                        toDatasource = _manufactureService.GetDepartmentListForCombo(manufactureId: _assignRelease.ManufactureId, userId: fromId);
                        cbTo.DataSource = toDatasource;
                        break;
                }
            }
        }


        private void Save(bool checkout = false, bool closeFormAftherSave = true)
        {
            var isValid = true;
            errorProvider.SetError(cbFrom, string.Empty);
            errorProvider.SetError(cbTo, string.Empty);

            //ResponseModel<InventoryUnitModel> msg = new ResponseModel<InventoryUnitModel>();
            var ignoreList = new List<DataGridViewColumn> { dgvItems.colWarehouseId };
            ignoreList.Add(dgvItems.colRate);

            var items = dgvItems.GetItems(ignoreList, true, false);//Constants.HAS_STOCK_MANAGEMENT
            if (items == null)
                return;
            if (cbFrom.SelectedValue == null)
            {
                isValid = false;
                errorProvider.SetError(cbFrom, "Required");
            }
            if (cbTo.SelectedValue == null)
            {
                isValid = false;
                errorProvider.SetError(cbTo, "Required");
            }
            var from = cbFrom.SelectedValue as int?;
            var to = cbTo.SelectedValue as int?;
            var assignReleaseModel = new AssignReleaseViewModel
            {
                FromId = from ?? 0,
                inventoryUnitList = items,
                ManufactureId = _assignRelease.ManufactureId,
                ToId = to ?? 0,
                TransferType = _assignRelease.TransferType,
                FromName = fromDatasource.FirstOrDefault(x => x.Id == (from ?? 0)).Name,
                ToName = toDatasource.FirstOrDefault(x => x.Id == (to ?? 0)).Name
            };
            ResponseModel<bool> response = _productOwnerService.SaveAssignRelease(assignReleaseModel);
            PopupMessage.ShowMessage(response.Success, response.Message);
            if (response.Success)
            {
                this.Close();
            }
        }


        #endregion




        #region Event Handlers




        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
            //this.Close();
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvItems_AmountChnanged(decimal totals)
        {
            /*
            try
            {
                txtTotal.Value = totals;

                if (rbCash.Checked)
                {
                    var paidAmount = totals - (totals * txtDiscount.Value / 100);
                    txtPaidAmount.Value = paidAmount;
                }
            }
            catch (Exception ex)
            {
                txtTotal.Value = 0;
                PopupMessage.ShowInfoMessage(ex.Message);
            }
            */
        }


        #endregion
    }


}
