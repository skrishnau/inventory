using DTO.Core.Inventory;
using IMS.Forms.Common;
using IMS.Forms.Common.Validations;
using IMS.Forms.Inventory.Suppliers;
using Service.Core.Business;
using Service.Core.Inventory;
using Service.Core.Orders;
using Service.Core.Settings;
using Service.Core.Users;
using Service.DbEventArgs;
using Service.Interfaces;
using Service.Listeners;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ViewModel.Core;
using ViewModel.Core.Common;
using ViewModel.Core.Inventory;
using ViewModel.Core.Orders;
using ViewModel.Enums;
using ViewModel.Utility;

namespace IMS.Forms.Inventory.Transaction
{
    public partial class TransactionCreateLargeUC : BaseUserControl
    {
        public event EventHandler<BaseEventArgs<OrderModel>> SavedOrderImmediatelyAfterLoading;
        public event EventHandler<IdEventArgs> CloseParentForm;
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

        private OrderModel _orderModel;
        private int _orderId;
        private OrderTypeEnum _orderType;
        private OrderOrDirectEnum _orderOrDirect;


        // to show Print View at first load
        private bool _showPrintView;
        private bool _isTransactionCreatePageLocked;
        private bool _showTransactionCreateInFullPage;

        private bool _saveOrderImmediatelyAfterLoading;

        public TransactionCreateLargeUC(IUserService userService,
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


        private async void TransactionCreateForm_Load(object sender, EventArgs e)
        {
            this.cbDiscountType.SelectedItem = "%";
            this.dtExpectedDate.SetValue(DateTime.Now);
            this.dtPaymentDueDate.SetValue(DateTime.Now);
            this.dtCompletedDate.SetValue(DateTime.Now);
            this.txtTotal.Maximum = Int32.MaxValue;
            this.txtTotal.Minimum = 0;
            this.txtPaidAmount.Maximum = Int32.MaxValue;
            this.txtPaidAmount.Minimum = 0;
            this.txtSum.Minimum = 0;
            this.txtSum.Maximum = Int32.MaxValue;

            this.txtRateAdd.Maximum = Int32.MaxValue;
            this.txtTotalAdd.Maximum = Int32.MaxValue;
            this.txtQuantityAdd.Maximum = Int32.MaxValue;

            _orderModel = _orderService.GetOrderForDetailView(_orderId, withProductModel: true);

            dgvItems.InitializeGridViewControls(_inventoryService, _productService, _uomService, _productOwnerService);
            InitializeValidation();
            InitializeDataGridView();
            InitializeSaveFooter();

            PopulateClientCombo();
            PopulateProductCombo();
            PopulateReceiptNumber();
            PopulateAdjustmentCodeCombo();

            PopulateModel(_orderModel);
            
            // Note: when editing a txn we cancel the txn and populate its' data in create view then save the data and close the form
            if (_saveOrderImmediatelyAfterLoading)
            {
                var savedOrder = Save(false, true);
                SavedOrderImmediatelyAfterLoading?.Invoke(this, new BaseEventArgs<OrderModel>(savedOrder, Service.Utility.UpdateMode.ADD));
            }

            MakeColumnsAutoSize();
            _showTransactionCreateInFullPage = await _appSettingService.GetShowTransactionCreateInFullPage();
            UpdateLock(null);

            InitializeEvents();
        }

        #region Functions

        private async void UpdateLock(bool? locked = null)
        {
            var tooltipText = string.Empty;
            if (_showTransactionCreateInFullPage)
            {
                _isTransactionCreatePageLocked = locked == null ? (await _appSettingService.GetIsTransactionCreatePageLocked()): locked??false;
                //saveFooterUC1.btnLock.BackColor = _isTransactionCreatePageLocked ? Color.LightGreen : SystemColors.ControlLightLight;
                saveFooterUC1.btnLock.Image = _isTransactionCreatePageLocked ? Properties.Resources.icons8_lock_16: Properties.Resources.icons8_unlock_16;
                saveFooterUC1.btnLock.Visible = true;
                tooltipText = _isTransactionCreatePageLocked ? 
                    "(Locked). UnLock tranasction create page"
                    : "Lock tranasction create page to open it automatically on startup";
            }
            else
            {
                saveFooterUC1.btnLock.Visible = false;
            }
            toolTip1.SetToolTip(saveFooterUC1.btnLock, tooltipText);

        }

        private void MakeColumnsAutoSize()
        {
            dgvItems.colProduct.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvItems.colInStockQuantityWithPackage.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvItems.colUnitQuantity.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvItems.colPackage.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvItems.colRate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvItems.colTotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvItems.colProduct.FillWeight = 6;
            dgvItems.colInStockQuantityWithPackage.FillWeight = 4;
            dgvItems.colUnitQuantity.FillWeight = 3;
            dgvItems.colPackage.FillWeight = 3;
            dgvItems.colRate.FillWeight = 3;
            dgvItems.colTotal.FillWeight = 3;

        }

        public void SetDataForEdit(OrderEditModel editModel, bool saveOrderImmediatelyAfterLoading = false)//(OrderTypeEnum orderType, int orderId, bool showPrintView = false)
        {
            _orderType = editModel.OrderType;
            _orderId = editModel.OrderId;
            _showPrintView = editModel.ShowPrintView;
            _orderOrDirect = editModel.OrderOrDirect;
            _saveOrderImmediatelyAfterLoading = saveOrderImmediatelyAfterLoading;
        }

        private void InitializeDataGridView()
        {
            if (_orderType == OrderTypeEnum.Sale)
                dgvItems.MovementType = MovementTypeEnum.SOIssueEditItems;
            else if (_orderType == OrderTypeEnum.Purchase)
            {
                dgvItems.MovementType = MovementTypeEnum.POReceiveEditItems;
            }
            dgvItems.DesignForTransactionCreate(true);

        }
        private void PopulateAdjustmentCodeCombo()
        {
            if (_orderOrDirect == OrderOrDirectEnum.Direct)
            {
                List<IdNamePair> adjustmentList;
                switch (_orderType)
                {
                    case OrderTypeEnum.Sale:
                        //case MovementTypeEnum.DirectIssueAny:
                        adjustmentList = _inventoryService.GetNegativeAdjustmentCodeListForCombo();
                        cbAdjustmentCode.DataSource = adjustmentList;
                        cbAdjustmentCode.ValueMember = "Id";
                        cbAdjustmentCode.DisplayMember = "Name";
                        cbAdjustmentCode.SelectedItem = adjustmentList.FirstOrDefault(x => x.Name == "Direct Issue");
                        break;
                    case OrderTypeEnum.Purchase:
                        adjustmentList = _inventoryService.GetPositiveAdjustmentCodeListForCombo();
                        cbAdjustmentCode.DataSource = adjustmentList;
                        cbAdjustmentCode.ValueMember = "Id";
                        cbAdjustmentCode.DisplayMember = "Name";
                        cbAdjustmentCode.SelectedItem = adjustmentList.FirstOrDefault(x => x.Name == "Direct Receive");
                        break;
                    default:
                        adjustmentList = new List<IdNamePair>();
                        break;
                }
            }
        }

        private void InitializeSaveFooter()
        {
            saveFooterUC1.pnlCheckout.Visible = true;
            saveFooterUC1.pnlCheckoutAndPrint.Visible = true;
        }

        private void InitializeEvents()
        {
            dtCompletedDate.TextChanged -= DtCompletedDate_TextChanged;
            dtCompletedDate.TextChanged += DtCompletedDate_TextChanged;

            saveFooterUC1.btnSave.Click += BtnSave_Click;
            saveFooterUC1.btnCancel.Click += BtnCancel_Click;
            saveFooterUC1.btnCheckoutAndPrint.Click += BtnCheckoutAndPrint_Click;
            saveFooterUC1.btnCheckout.Click += BtnCheckout_Click;
            rbCredit.CheckedChanged += RbCredit_CheckedChanged;
            rbCash.CheckedChanged += RbCredit_CheckedChanged;

            _listener.UserUpdated += _listener_CustomerUpdated;
            lblClient.DoubleClick += LblClient_DoubleClick;

            dgvItems.AmountChanged += DgvItems_AmountChnanged;
            //btnPayment.Click += btnPayment_Click;
            cbClient.SelectedValueChanged += CbClient_SelectedValueChanged;
            dgvItems.RowsRemoved += DgvItems_RowsRemoved;
            txtTotal.ValueChanged += TxtTotal_ValueChanged;
            txtDiscount.ValueChanged += TxtDiscount_ValueChanged;
            cbDiscountType.SelectedValueChanged += CbDiscountType_SelectedValueChanged;
            dtCompletedDate.TextChanged += DtCompletedDate_TextChanged;

            // Add controls
            saveFooterUC1.btnLock.Click += BtnLock_Click;
            cbProductAdd.SelectedValueChanged += CbProductAdd_SelectedValueChanged;
            cbPackageAdd.SelectedValueChanged += CbPackageAdd_SelectedValueChanged;
            txtRateAdd.ValueChanged += TxtRateAdd_ValueChanged;
            txtQuantityAdd.ValueChanged += TxtQuantityAdd_ValueChanged;
            btnAddAdd.Click += BtnAddAdd_Click;
            btnResetAdd.Click += BtnResetAdd_Click;
        }

        private void BtnLock_Click(object sender, EventArgs e)
        {
            var isLocked = _isTransactionCreatePageLocked;
            isLocked = !isLocked;
            _appSettingService.SaveIsTransactionCreatePageLocked(isLocked);
            PopupMessage.ShowSuccessMessage("Successfully " + (isLocked? "Locked" : "Unlocked"));
            UpdateLock(isLocked);
        }

        private void DtCompletedDate_TextChanged(object sender, EventArgs e)
        {
            dgvItems.SetDate(dtCompletedDate.GetValue());
        }

        private void CbDiscountType_SelectedValueChanged(object sender, EventArgs e)
        {

            if (cbDiscountType.SelectedItem?.ToString() == "%")
            {
                txtDiscount.Maximum = 100;
            }
            else if (cbDiscountType.SelectedItem?.ToString() == "Rs.")
            {
                txtDiscount.Maximum = Int32.MaxValue;
            }
            txtDiscount.Value = 0;
        }

        private void DgvItems_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (e.RowCount > 0)
            {
                txtTotal.Value = dgvItems.GetTotalSumAmount();
            }
        }

        private void CbClient_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbClient.SelectedValue != null)
            {
                var selectedValue = cbClient.SelectedValue;
                var client = _userService.GetUser(int.Parse(cbClient.SelectedValue.ToString()));
                if (client != null)
                {
                    txtAddress.Text = client.Address;
                    txtPhone.Text = client.Phone;
                }
                else
                {
                    txtAddress.Text = "";
                    txtPhone.Text = "";
                }
            }
        }



        private void SetSumAmount()
        {
            try
            {
                errorProvider.SetError(txtSum, string.Empty);
                var discount = txtDiscount.Value;
                var total = txtTotal.Value;

                var sum = 0M;
                if (cbDiscountType.SelectedItem?.ToString() == "%")
                {
                    sum = total - (total * discount / 100);
                }
                else
                {
                    sum = total - discount;
                }
                if (sum < 0)
                {
                    errorProvider.SetError(txtSum, "Can't be less than zero");
                    sum = total;
                }
                txtSum.Value = sum;
                if (rbCash.Checked)
                {
                    txtPaidAmount.Value = sum;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void InitializeValidation()
        {
            // required field validator
            List<Control> requiredControls = new List<Control>()
            {
                //txtReceiptNo, // recipt no . is not required in case of Order-save
            };
            //switch (_orderType)
            //{
            //    case OrderTypeEnum.Purchase:
            //        requiredControls.Add(cbClient);
            //        break;
            //    case OrderTypeEnum.Sale:
            //        requiredControls.Add(cbClient);
            //        break;
            //}

            _requiredFieldValidator = new RequiredFieldValidator(errorProvider, requiredControls.ToArray());
            // greater than zero field validator
            List<Control> controls = new List<Control>()
            {
                    txtSum,
            };
            _greaterThanZeroFieldValidator = new GreaterThanZeroFieldValidator(errorProvider, controls.ToArray(), true);

        }

        private void PopulateClientCombo()
        {
            List<IdNamePair> list = null;
            var userType = UserTypeEnumHelper.CustomerSupplier;//.Client;
            switch (_orderType)
            {
                case OrderTypeEnum.Purchase:
                    userType = new List<UserTypeEnum> { UserTypeEnum.Supplier };
                    break;
                case OrderTypeEnum.Sale:
                    userType = new List<UserTypeEnum> { UserTypeEnum.Customer };
                    break;
            }
            var includeUserList = new int[] { _orderModel?.UserId ?? 0 };
            list = _userService.GetUserListWithCompanyForCombo(userType, includeUserList);
            if (list != null)
            {
                list.Insert(0, new IdNamePair
                {
                    Id = 0,
                    Name = ""
                });
                cbClient.DisplayMember = "Name";
                cbClient.ValueMember = "Id";
                cbClient.DataSource = list;
            }
            cbClient.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbClient.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbClient.AutoCompleteCustomSource.AddRange(list.Select(x => x.Name).ToArray());
        }

        private void PopulateProductCombo()
        {
            List<IdNamePair> list = null;
            list = _productService.GetProductListForCombo();
            if (list != null)
            {
                list.Insert(0, new IdNamePair
                {
                    Id = 0,
                    Name = ""
                });
                cbProductAdd.DisplayMember = "Name";
                cbProductAdd.ValueMember = "Id";
                cbProductAdd.DataSource = list;
            }
            cbProductAdd.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbProductAdd.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbProductAdd.AutoCompleteCustomSource.AddRange(list.Select(x => x.Name).ToArray());
        }


        private void PopulateModel(OrderModel model)
        {
            _orderModel = model;
            if (model != null)
            {
                dgvItems.OrderId = model.Id;
                if (_showPrintView)
                {
                    ShowPrintView(model);
                    return;
                }
                else
                {
                    txtDiscount.ValueChanged -= TxtDiscount_ValueChanged;
                    cbDiscountType.SelectedValueChanged -= CbDiscountType_SelectedValueChanged;
                    if (model.DiscountPercent > 0)
                    {
                        txtDiscount.Maximum = 100;
                        txtDiscount.Value = model.DiscountPercent;
                        cbDiscountType.SelectedItem = "%";
                    }
                    else if (model.DiscountAmount > 0)
                    {
                        txtDiscount.Maximum = Int32.MaxValue;
                        txtDiscount.Minimum = 0;
                        txtDiscount.Value = model.DiscountAmount;
                        cbDiscountType.SelectedItem = "Rs.";
                    }
                    txtDiscount.ValueChanged += TxtDiscount_ValueChanged;
                    cbDiscountType.SelectedValueChanged += CbDiscountType_SelectedValueChanged;

                    //btnPayment.Visible = model.RemainingAmount > 0;
                    // change button
                    _orderId = model.Id;
                    txtReceiptNo.Text = model.ReferenceNumber;//tbOrderNumber.Text 
                    dtExpectedDate.SetValue(model.DeliveryDate);
                    dtPaymentDueDate.SetValue(model.PaymentDueDate.HasValue ? model.PaymentDueDate.Value : DateTime.Now);
                    dtCompletedDate.SetValue(model.CompletedDate.HasValue ? model.CompletedDate.Value : DateTime.Now);
                    txtAddress.Text = model.Address;
                    txtPhone.Text = model.Phone;
                    txtTotal.Value = model.TotalAmount;
                    cbClient.Text = model.User;
                    if (model.UserId > 0)
                        cbClient.SelectedValue = model.UserId;
                    rbCash.Checked = model.PaymentType == OrderPaymentTypeEnum.Cash.ToString();//model.PaidAmount >= model.TotalAmount;
                    rbCredit.Checked = model.PaymentType == OrderPaymentTypeEnum.Credit.ToString(); // !rbCash.Checked;
                    ShowPaymentDueDateLayout(rbCredit.Checked);
                    txtPaidAmount.Value = model.PaidAmount;

                    var invModel = OrderItemMapper.MapToInventoryUnitModel(model.OrderItems);

                    dgvItems.AddRows(invModel);

                    if (model.IsVerified && !model.IsCompleted)
                    {
                        // zero rate update case
                        DisableAllInputsExceptRate();
                    }
                    //if (model.IsCompleted)
                    //{
                    //    cbClient.Enabled = false;
                    //}
                }
            }
            else
            {
                // initial data
                //var initials =
                //    _orderType == OrderTypeEnum.Purchase ? "PO-"
                //    : _orderType == OrderTypeEnum.Sale ? "SO-"
                //    : _orderType == OrderTypeEnum.Move ? "MO-"
                //    : "";
                // tbName.Text = initials + DateTime.Now.ToString("ddd, dd MMM yyyy");
                //tbName.Text = initials + DateTime.Now.Ticks.ToString();
            }

            switch (_orderType)
            {
                case OrderTypeEnum.Purchase:
                    lblClient.Text = "Supplier";
                    this.Text = (model == null ? "Create" : "Edit") + (_orderOrDirect == OrderOrDirectEnum.Order ? " Purchase Transaction" : " Direct Receive");
                    saveFooterUC1.btnCheckoutAndPrint.Visible = false;
                    break;
                case OrderTypeEnum.Sale:
                    lblClient.Text = "Customer";
                    this.Text = (model == null ? "Create" : "Edit") + (_orderOrDirect == OrderOrDirectEnum.Order ? " Sale Transaction" : " Direct Issue");
                    saveFooterUC1.btnCheckoutAndPrint.Visible = true;
                    break;
                    //case OrderTypeEnum.Move:
                    //    lblClient.Visible = false;
                    //    cbClient.Visible = false;
                    //    this.Text = (model == null ? "Create" : "Edit") + " Transfer Order";
                    //    break;
            }
            DesignViewForOrderOrDirect();
        }

        private void DesignViewForOrderOrDirect()
        {
            if (_orderOrDirect == OrderOrDirectEnum.Direct)
            {
                pnlBottomInputs.Visible = false;
                pnlCustomer.Visible = false;
                saveFooterUC1.btnCheckout.Text = _orderType == OrderTypeEnum.Purchase ? "Recevie" : "Issue";
                saveFooterUC1.btnSave.Visible = false;
                saveFooterUC1.btnCheckoutAndPrint.Visible = false;
                lblCheckoutDate.Text = "Date";
                rbCash.Checked = true;
                cbAdjustmentCode.Visible = true;
                lblAdjustmentCode.Visible = true;
            }
        }

        private void DisableAllInputsExceptRate()
        {
            var enabled = false;
            cbClient.Enabled = enabled;
            cbDiscountType.Enabled = enabled;
            txtAddress.Enabled = enabled;
            txtDiscount.Enabled = enabled;
            txtPaidAmount.Enabled = enabled;
            txtPhone.Enabled = enabled;
            txtReceiptNo.Enabled = enabled;
            txtSum.Enabled = enabled;
            txtTotal.Enabled = enabled;
            rbCash.Enabled = enabled;
            rbCredit.Enabled = enabled;
            saveFooterUC1.btnSave.Visible = enabled;
            dtCompletedDate.Enabled = enabled;
            dtExpectedDate.Enabled = enabled;
            dtPaymentDueDate.Enabled = enabled;
            lblClient.DoubleClick -= LblClient_DoubleClick;
            dgvItems.DisableAllExceptRate();
            // add controls
            cbProductAdd.Enabled = enabled;
            cbPackageAdd.Enabled = enabled;
            txtRateAdd.Enabled = enabled;
            txtQuantityAdd.Enabled = enabled;
            btnAddAdd.Enabled = enabled;
            btnResetAdd.Enabled = enabled;
        }

        private void PopulateReceiptNumber()
        {
            // orderModel.iscompleted is checked to knwo if it's editing a completed order ; if it is then generate new receipt
            if (!_showPrintView && ((_orderModel?.IsCompleted ?? false) || string.IsNullOrEmpty(_orderModel?.ReferenceNumber) || string.IsNullOrWhiteSpace(_orderModel?.ReferenceNumber)))
            {
                var nextReceipt = _appSettingService.GetReceiptNumber((ReferencesTypeEnum)Enum.Parse(typeof(ReferencesTypeEnum), _orderType.ToString()));
                txtReceiptNo.Text = nextReceipt;
                if (_orderModel != null)
                    _orderModel.ReferenceNumber = nextReceipt;
            }
        }
        private OrderModel Save(bool checkout = false, bool closeFormAftherSave = true)
        {

            ResponseModel<OrderModel> msg = new ResponseModel<OrderModel>();
            var userType = _orderType == OrderTypeEnum.Sale ? UserTypeEnum.Customer : UserTypeEnum.Supplier;
            var givenByTo = _orderType == OrderTypeEnum.Sale ? "given to" : "taken from";
            if (checkout && (string.IsNullOrWhiteSpace(txtReceiptNo.Text) || txtReceiptNo.Text == string.Empty))
            {
                msg.Message += Constants.RECEIPT_NO_IS_REQUIRED + "\n";
                errorProvider.SetError(txtReceiptNo, Constants.RECEIPT_NO_IS_REQUIRED);
            }
            else
                errorProvider.SetError(txtReceiptNo, string.Empty);
            // cash credit
            if (checkout && !rbCash.Checked && !rbCredit.Checked)
            {
                msg.Message += "Cash/Credit option must be selected";
                errorProvider.SetError(rbCredit, "Cash/Credit option must be selected");
            }
            else
                errorProvider.SetError(rbCredit, string.Empty);
            if (!checkout || _orderType == OrderTypeEnum.Purchase)
            {
                _greaterThanZeroFieldValidator.Remove(txtSum);
            }
            else
                _greaterThanZeroFieldValidator.AddIfNotExists(txtSum);
            if (!_requiredFieldValidator.IsValid())
                msg.Message += "Some required Fields are empty\n";
            if (!_greaterThanZeroFieldValidator.IsValid())
                msg.Message += "Some Fields are zero or less.\n";
            if (txtPaidAmount.Value > txtSum.Value)
                msg.Message += "Paid amount cannot be greater than total amount";

            if (rbCredit.Checked && string.IsNullOrEmpty(cbClient.Text))
            {
                var creditToAnonumousMsg = $"Credit can't be {givenByTo} anonymous {userType.ToString()}. Please enter {userType.ToString()} name";
                errorProvider.SetError(cbClient, creditToAnonumousMsg);
                msg.Message += creditToAnonumousMsg;
            }
            else
            {
                errorProvider.SetError(cbClient, string.Empty);
            }
            if (!dtCompletedDate.IsValid())
            {
                msg.Message += "Invalid Checkout Date \n";
            }
            if (!dtPaymentDueDate.IsValid())
            {
                msg.Message += "Invalid Payment Due Date \n";
            }
            if (!dtExpectedDate.IsValid())
            {
                msg.Message += "Invalid Delivery Date \n";
            }

            var model = GetData(checkout);

            if (_orderType == OrderTypeEnum.Purchase && (model?.OrderItems?.Any(x => x.Rate == 0) ?? false) && rbCash.Checked && _orderOrDirect == OrderOrDirectEnum.Order)
            {
                errorProvider.SetError(rbCredit, "Can't do full cash payment for zero rate items.");
                msg.Message += "You can't have full cash payment for transaction with zero rate items. Please change it to Partial payment.\n";
            }
            else
            {
                errorProvider.SetError(rbCredit, string.Empty);
            }

            if (!string.IsNullOrEmpty(msg.Message))
            {
                PopupMessage.ShowInfoMessage(msg.Message);
                this.Focus();
                return null;
            }



            if (model == null)
                return null;
            if (checkout && (model.OrderItems == null || model.OrderItems.Count == 0))
            {
                PopupMessage.ShowInfoMessage("At least one item is expected.");
                this.Focus();
                return null;
            }

            var isCanceledByUser = false;

            if (checkout)
            {
                var warning = string.Empty;
                if (_orderOrDirect == OrderOrDirectEnum.Direct)
                {
                    warning = $"Are you sure to directly {(_orderType == OrderTypeEnum.Sale ? "issue" : "receive")} the items?";
                }
                else
                {
                    if (model.OrderType == OrderTypeEnum.Purchase.ToString())
                    {
                        if (model.IsVerified && !model.IsCompleted)
                        {
                            warning = "This transaction previously had items with zero rate. Checking out this transaction will " +
                           "update it's related ledger and also updates cost prices in all of the corresponding sale transactions and their ledger too. " +
                           "Are you sure to checkout the transaction?";
                        }
                        else if (model.Id == 0 && model.OrderItems.Any(x => x.Rate == 0))
                        {
                            // new purchase with zero rate
                            warning = "This transaction has items with zero rate. Checking out this transaction will " +
                            "save it as 'Pending Order' and it's ledger won't be updated. You have to checkout this transaction once again with updated rates. " +
                            "Are you sure to checkout the transaction?";
                        }
                        else warning = "Are you sure to checkout the transaction?";
                    }
                    else warning = "Are you sure to checkout the transaction?";

                }

                DialogResult result = MessageBox.Show(this, warning, "Checkout?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    msg = _orderService.SaveOrder(model, checkout);
                }
                else
                {
                    isCanceledByUser = true;
                }
            }
            else
            {
                msg = _orderService.SaveOrder(model, checkout);
            }
            if (!isCanceledByUser)
            {
                if (string.IsNullOrEmpty(msg.Message))
                {
                    PopupMessage.ShowSaveSuccessMessage();
                    if (closeFormAftherSave)
                        CloseParentForm?.Invoke(this, new IdEventArgs(msg?.Data?.Id??0));//this.Close();
                    return msg.Data;
                }
                else
                {
                    PopupMessage.ShowErrorMessage(msg.Message);//"Couln't save! Please contact admin.");

                }
            }

            this.Focus();
            return null;
        }

        private OrderModel GetData(bool checkout)
        {
            var client = "";
            var clientId = 0;
            int.TryParse(cbClient.SelectedValue?.ToString() ?? "", out clientId);
            if (clientId == 0)
            {
                client = cbClient.Text;
            }

            var ignoreList = new List<DataGridViewColumn> { dgvItems.colWarehouseId };
            var isEditForZeroRateUpdate = _orderModel != null && (_orderModel?.IsVerified ?? false) && !(_orderModel?.IsCompleted ?? false);
            if (_orderType == OrderTypeEnum.Purchase && !isEditForZeroRateUpdate && _orderOrDirect == OrderOrDirectEnum.Order
                || (_orderOrDirect == OrderOrDirectEnum.Direct))
                ignoreList.Add(dgvItems.colRate); // in case of purchase the user may not enter the rate at first or in case or direct rate can be zero
            var items = dgvItems.GetItems(ignoreList, Constants.HAS_STOCK_MANAGEMENT, !checkout);

            if (items != null)
            {
                var completedDate = dtCompletedDate.GetValue();
                var now = DateTime.Now;
                TimeSpan ts = new TimeSpan(now.Hour, now.Minute, now.Second);
                completedDate = completedDate.Date + ts;
                var orderModel = new OrderModel
                {
                    Id = _orderId,
                    OrderType = _orderType.ToString(),
                    OrderOrDirect = _orderOrDirect,
                    Name = (string.IsNullOrEmpty(cbClient.Text) ? "" : $"{cbClient.Text}, ") + txtReceiptNo.Text,
                    DeliveryDate = dtExpectedDate.GetValue(),
                    CompletedDate = completedDate,//dtCompletedDate.GetValue(),
                    PaidAmount = txtPaidAmount.Value,
                    DiscountPercent = cbDiscountType.SelectedItem?.ToString() == "%" ? txtDiscount.Value : 0,
                    DiscountAmount = cbDiscountType.SelectedItem?.ToString() == "%" ? txtTotal.Value * txtDiscount.Value / 100 : txtDiscount.Value,
                    CreatedAt = DateTime.Now,
                    OrderItems = InventoryUnitMapper.MapToOrderItemModel(items, _orderId, true),
                    ReferenceNumber = txtReceiptNo.Text,
                    Phone = txtPhone.Text,
                    Address = txtAddress.Text,
                    PaymentDueDate = rbCredit.Checked ? dtPaymentDueDate.GetValue() : (DateTime?)null,
                    PaymentType = rbCredit.Checked ? OrderPaymentTypeEnum.Credit.ToString() : rbCash.Checked ? OrderPaymentTypeEnum.Cash.ToString() : null,
                    TotalAmount = items.Select(x => x.Total).Sum(),
                    IsVerified = (_orderModel?.IsCompleted ?? false) ? false : _orderModel?.IsVerified ?? false, // IsVerified will again be updated in Save(), this value indicates the earlier's Verified state
                };
                orderModel.User = client;
                orderModel.UserId = clientId;
                var adjustment = cbAdjustmentCode.SelectedItem as IdNamePair;
                if (adjustment != null)
                {
                    orderModel.AdjustmentCodeId = adjustment.Id;//(cbAdjustmentCode.SelectedValue as int?) ?? 0;
                    orderModel.AdjustmentCode = adjustment.Name;
                }
                // logic: if we are in edit mode and the order is already Completed, then it means that we need to create child 
                //          order and make the old order as void
                // else if we are in edit mode of incomplete order then just assign its parentOrderId to the saving model
                if (_orderModel != null)
                {
                    if (_orderModel.IsCompleted)
                    {
                        orderModel.ParentOrderId = _orderModel.Id;
                        orderModel.Id = 0;
                    }
                    else
                    {
                        orderModel.ParentOrderId = _orderModel.ParentOrderId;
                    }
                }
                return orderModel;
            }
            return null;
        }

        #endregion




        #region Event Handlers

        private void _listener_CustomerUpdated(object sender, Service.DbEventArgs.BaseEventArgs<UserModel> e)
        {
            PopulateClientCombo();
            cbClient.SelectedValue = e?.Model == null ? 0 : e.Model.Id;
        }


        private void RbCredit_CheckedChanged(object sender, EventArgs e)
        {
            ShowPaymentDueDateLayout(rbCredit.Checked);
        }

        private void ShowPaymentDueDateLayout(bool show)
        {
            pnlPaymentDueDate.Visible = show;
            txtPaidAmount.Value = show ? 0 : txtSum.Value;
            txtPaidAmount.Enabled = show;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            CloseParentForm?.Invoke(this, new IdEventArgs(0));//this.Close();
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            Save(true);
        }

        private void TxtDiscount_ValueChanged(object sender, EventArgs e)
        {
            SetSumAmount();
        }

        private void TxtTotal_ValueChanged(object sender, EventArgs e)
        {
            SetSumAmount();
        }

        private void BtnCheckoutAndPrint_Click(object sender, EventArgs e)
        {
            CheckOutAndPrint();
            //var printBillTest = new PrintBillTest();
            //printBillTest.ShowDialog();
        }

        private void CheckOutAndPrint()
        {
            if (_orderModel != null)
            {
                _orderModel.ReceiptGeneratedDate = DateTime.Now;
                _orderModel.IsReceiptGenerated = true;
            }
            var model = Save(true, false);
            //var orders = _orderService.GetAllOrders(OrderTypeEnum.Sale);
            //var model = _orderService.GetOrderForDetailView(orders.FirstOrDefault()?.Id ?? 0);
            if (model != null)
            {
                ShowPrintView(model);
            }
        }

        private void ShowPrintView(OrderModel model)
        {
            this.Text = "Print Receipt";
            this.Controls.Clear();
            var transactionPrintBillUc = new TransactionPrintReceiptUC(_appSettingService, model);
            this.Controls.Add(transactionPrintBillUc);
        }


        private void LblClient_DoubleClick(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var supplierCreate = Program.container.GetInstance<ClientCreateForm>();
                supplierCreate.SetType(_orderType);
                supplierCreate.ShowDialog();
            }
        }

        //private void btnPayment_Click(object sender, EventArgs e)
        //{
        //    using (AsyncScopedLifestyle.BeginScope(Program.container))
        //    {
        //        var po = Program.container.GetInstance<PaymentCreateForm>();
        //        po.SetData(_orderModel, null);
        //        po.ShowDialog();
        //    }
        //}

        private void DgvItems_AmountChnanged(decimal totals)
        {
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
        }

        //private void UpdateParticulars()
        //{
        //    if (rbAllItemsParticulars.Checked)
        //    {
        //        var items = dgvItems.GetItems(null, false, true);
        //        txtParticulars.Text = string.Join(",", items.Select(x => x.Product +"  " + x.UnitQuantity + " " + x.Package +" @ Rs. "+ x.Rate + "\n" ));
        //    }
        //}
        #endregion


        #region Add Controls

        private void CbProductAdd_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateProductAddInfo();
        }
        private void CbPackageAdd_SelectedValueChanged(object sender, EventArgs e)
        {
            SetRateAsPerDate();
        }

        private void PopulateProductAddInfo()
        {
            ClearPackageAdd();
            var productModel = _productService.GetProductByNameOrSKU(cbProductAdd.Text);
            if (productModel != null)
            {
                cbProductAdd.Tag = productModel;
                txtInStockQuantityAdd.Text = $"{productModel.InStockQuantity} {productModel.BasePackage}";
                PopulatePackageAdd(productModel);
                SetRateAsPerDate();
            }
        }

        private void SetRateAsPerDate()
        {
            var product = cbProductAdd.Tag as ProductModel;
            if (product != null)
            {
                var _date = dtCompletedDate.GetValue();
                var package = cbPackageAdd.Text;
                var price = _productService.GetPrice(product.Id, _date, dgvItems.MovementType, 0, package);
                txtRateAdd.Value = price?.Rate ?? 0;
                UpdateTotalAdd(price?.Rate ?? 0, txtQuantityAdd.Value);
            }
        }
        private void UpdateTotalAdd(decimal rate, decimal quantity)
        {
            txtTotalAdd.Value = rate * quantity;
        }
        private void PopulatePackageAdd(ProductModel productModel)
        {
            ClearPackageAdd();
            List<IdNamePair> list = productModel.Packages.Select(x => new IdNamePair { Id = x.Id, Name = x.Name }).ToList();
            if (list != null)
            {
                list.Insert(0, new IdNamePair
                {
                    Id = 0,
                    Name = ""
                });
                cbPackageAdd.DisplayMember = "Name";
                cbPackageAdd.ValueMember = "Id";
                cbPackageAdd.DataSource = list;
                cbPackageAdd.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbPackageAdd.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cbPackageAdd.AutoCompleteCustomSource.AddRange(list.Select(x => x.Name).ToArray());
                cbPackageAdd.SelectedText = productModel.BasePackage;
            }
        }
        private void ClearPackageAdd()
        {
            cbPackageAdd.DataSource = null;
            cbPackageAdd.AutoCompleteCustomSource?.Clear();
        }

        private void TxtRateAdd_ValueChanged(object sender, EventArgs e)
        {

            UpdateTotalAdd(txtRateAdd.Value, txtQuantityAdd.Value);
        }

        private void TxtQuantityAdd_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAdd(txtRateAdd.Value, txtQuantityAdd.Value);
        }
        private void BtnResetAdd_Click(object sender, EventArgs e)
        {
            cbProductAdd.Tag = null;
            cbProductAdd.SelectedIndex = 0;
            cbProductAdd.Text = string.Empty;
            txtRateAdd.Value = 0;
            txtQuantityAdd.Value = 0;
            txtInStockQuantityAdd.Text = string.Empty;
            ClearPackageAdd();
        }

        private void BtnAddAdd_Click(object sender, EventArgs e)
        {
            errorProvider.SetError(cbProductAdd, string.Empty);
            errorProvider.SetError(cbPackageAdd, string.Empty);
            errorProvider.SetError(txtQuantityAdd, string.Empty);
            var message = string.Empty;
            var productModel = cbProductAdd.Tag as ProductModel;
            if (productModel == null)
            {
                message += "Invalid Product. ";
                errorProvider.SetError(cbProductAdd, "Invalid");
            }
            var packageText = cbPackageAdd.Text;
            var package = _inventoryService.GetPackageByName(packageText);
            if (package == null)
            {
                message += "Invalid Package. ";
                errorProvider.SetError(cbPackageAdd, "Invalid");
            }
            if (txtQuantityAdd.Value <= 0)
            {
                message += "Quanitty should be greater than zero. ";
                errorProvider.SetError(txtQuantityAdd, "Quanitty should be greater than zero");
            }
            if (!string.IsNullOrEmpty(message))
            {
                PopupMessage.ShowInfoMessage(message);
                this.Focus();
                return;
            }
            var invUnitModel = new InventoryUnitModel()
            {
                Product = productModel.Name,
                ProductId = productModel.Id,
                InStockQuantity = productModel.InStockQuantity,
                InStockQuantityWithPackage = productModel.InStockQuantity + " " + productModel.BasePackage,
                UnitQuantity = txtQuantityAdd.Value,
                Package = package.Name,
                PackageId = package.Id,
                Rate = txtRateAdd.Value,
                Total = txtTotalAdd.Value,
                ProductModel = productModel,
            };
            dgvItems.AddRows(new List<InventoryUnitModel> { invUnitModel });
            BtnResetAdd_Click(btnResetAdd, EventArgs.Empty);
            cbProductAdd.Focus();
        }

        #endregion
    }
}
