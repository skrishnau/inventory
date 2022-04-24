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
using System.Windows.Forms;
using ViewModel.Core.Inventory;
using ViewModel.Core.Orders;
using ViewModel.Enums;

namespace IMS.Forms.MRP
{
    public partial class ManufactureProductCreateForm : Form
    {
        public event EventHandler<BaseEventArgs<OrderModel>> SavedOrderImmediatelyAfterLoading;
        private readonly IUserService _userService;
        private readonly IDatabaseChangeListener _listener;
        private readonly IBusinessService _businessService;
        private readonly IOrderService _orderService;
        private readonly IInventoryService _inventoryService;
        private readonly IProductService _productService;
        private readonly IAppSettingService _appSettingService;
        private readonly IUomService _uomService;
        private readonly IProductOwnerService _productOwnerService;
        private RequiredFieldValidator _requiredFieldValidator;
        private GreaterThanZeroFieldValidator _greaterThanZeroFieldValidator;

        private List<InventoryUnitModel> _unitList;
        private string _heading;
        bool _isManufacture;
        bool _isDepartment;
        bool _inOut; // in = true, out = false

        public ManufactureProductCreateForm(IUserService userService,
            IBusinessService businessService,
            IInventoryService inventoryService,
            IProductService productService,
            IOrderService purchaseService,
            IDatabaseChangeListener listener,
            IAppSettingService appSettingService,
            IUomService uomService, 
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
            _productOwnerService = productOwnerService;
            InitializeComponent();
            this.Load += TransactionCreateForm_Load;
        }


        private void TransactionCreateForm_Load(object sender, EventArgs e)
        {
            var productTypes = new List<ProductTypeEnum>();

            if (!_inOut)
            {
                productTypes.Add(ProductTypeEnum.Build);
            }

            dgvItems.InitializeGridViewControls(_inventoryService, _productService, _uomService, _productOwnerService, productTypes);
            InitializeValidation();
            InitializeDataGridView();
            PopulateModel();

            InitializeEvents();
        }

        #region Functions

        public void SetDataForEdit(List<InventoryUnitModel> inventoryUnits, string heading, bool isManufacture, bool isDepartment, bool inOut)
        {
            _unitList = inventoryUnits;
            _heading = heading;
            _isManufacture = isManufacture;
            _isDepartment = isDepartment;
            _inOut = inOut;
        }

        private void InitializeDataGridView()
        {
            dgvItems.DesignForManufactureProposedProducts();
        }


        private void InitializeEvents()
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;

            dgvItems.AmountChanged += DgvItems_AmountChnanged;
            dgvItems.RowsRemoved += DgvItems_RowsRemoved;
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
            if (_unitList != null)
            {
                dgvItems.AddRows(_unitList);
            }

            lblHeading.Text = _heading;
        }

        private void Save(bool checkout = false, bool closeFormAftherSave = true)
        {
            //ResponseModel<InventoryUnitModel> msg = new ResponseModel<InventoryUnitModel>();
            var ignoreList = new List<DataGridViewColumn> { dgvItems.colWarehouseId };
            ignoreList.Add(dgvItems.colRate);

            var items = dgvItems.GetItems(ignoreList, false, false);//Constants.HAS_STOCK_MANAGEMENT
            if (items == null)
                return;
            _unitList.Clear();
            _unitList.AddRange(items);
            this.Close();
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
