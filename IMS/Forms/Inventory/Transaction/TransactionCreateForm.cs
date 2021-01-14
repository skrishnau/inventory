using DTO.Core.Inventory;
using IMS.Forms.Common;
using IMS.Forms.Common.Validations;
using IMS.Forms.Inventory.Payment;
using IMS.Forms.Inventory.Suppliers;
using Service.Core.Business;
using Service.Core.Inventory;
using Service.Core.Orders;
using Service.Core.Settings;
using Service.Core.Users;
using Service.Interfaces;
using Service.Listeners;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ViewModel.Core.Common;
using ViewModel.Core.Orders;
using ViewModel.Core.Users;
using ViewModel.Enums;

namespace IMS.Forms.Inventory.Transaction
{
    public partial class TransactionCreateForm : Form
    {
        private readonly IUserService _userService;
        private readonly IDatabaseChangeListener _listener;
        private readonly IBusinessService _businessService;
        private readonly IOrderService _orderService;
        private readonly IInventoryService _inventoryService;
        private readonly IProductService _productService;
        private readonly IAppSettingService _appSettingService;
        private RequiredFieldValidator _requiredFieldValidator;
        private GreaterThanZeroFieldValidator _greaterThanZeroFieldValidator;

        private OrderModel _orderModel;
        private int _orderId;
        private OrderTypeEnum _orderType;


        public TransactionCreateForm(IUserService userService,
            IBusinessService businessService,
            IInventoryService inventoryService,
            IProductService productService,
            IOrderService purchaseService,
            IDatabaseChangeListener listener,
            IAppSettingService appSettingService)
        {
            _listener = listener;
            this._businessService = businessService;
            this._userService = userService;
            this._orderService = purchaseService;
            this._inventoryService = inventoryService;
            this._productService = productService;
            this._appSettingService = appSettingService;

            InitializeComponent();
            this.Load += TransactionCreateForm_Load;
        }


        private void TransactionCreateForm_Load(object sender, EventArgs e)
        {
            this.txtTotal.Maximum = Int32.MaxValue;
            this.txtTotal.Minimum = 0;
            this.txtPaidAmount.Maximum = Int32.MaxValue;
            this.txtPaidAmount.Minimum = 0;

            var order = _orderService.GetOrder(_orderType, _orderId);

            dgvItems.InitializeGridViewControls(_inventoryService, _productService);
            InitializeValidation();
            InitializeEvents();
            InitializeDataGridView();
            InitializeSaveFooter();

            PopulateModel(order);
            PopulateClientCombo();
            PopulateReceiptNumber();
        }

        #region Functions

        public void SetDataForEdit(OrderTypeEnum orderType, int orderId)
        {
            _orderType = orderType;
            _orderId = orderId;
        }

        private void InitializeDataGridView()
        {
            if (_orderType == OrderTypeEnum.Sale)
                dgvItems.MovementType = MovementTypeEnum.SOIssueEditItems;
            else if (_orderType == OrderTypeEnum.Purchase)
                dgvItems.MovementType = MovementTypeEnum.POReceiveEditItems;
            dgvItems.DesignForTransaction(true);
        }

        private void InitializeSaveFooter()
        {
            saveFooterUC1.pnlCheckout.Visible = true;
            saveFooterUC1.pnlCheckoutAndPrint.Visible = true;
        }

        private void InitializeEvents()
        {
            saveFooterUC1.btnSave.Click += BtnSave_Click;
            saveFooterUC1.btnCancel.Click += BtnCancel_Click;
            saveFooterUC1.btnCheckoutAndPrint.Click += BtnCheckoutAndPrint_Click;
            saveFooterUC1.btnCheckout.Click += BtnCheckout_Click;
            rbCredit.CheckedChanged += RbCredit_CheckedChanged;

            _listener.UserUpdated += _listener_CustomerUpdated;
            lblClient.DoubleClick += LblClient_DoubleClick;

            dgvItems.AmountChanged += DgvItems_AmountChnanged;
            btnPayment.Click += btnPayment_Click;
            cbClient.SelectedValueChanged += CbClient_SelectedValueChanged;
        }


        private void CbClient_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cbClient.SelectedValue != null)
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

        private void InitializeValidation()
        {
            // required field validator
            List<Control> requiredControls = new List<Control>()
            {
                 txtReceiptNo,
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
                 txtTotal,
            };
            _greaterThanZeroFieldValidator = new GreaterThanZeroFieldValidator(errorProvider, controls.ToArray());


        }

        private void PopulateClientCombo()
        {
            List<IdNamePair> list = null;
            var userType = UserTypeEnum.Client;
            switch (_orderType)
            {
                case OrderTypeEnum.Purchase:
                    userType = UserTypeEnum.Supplier;
                    break;
                case OrderTypeEnum.Sale:
                    userType = UserTypeEnum.Customer;
                    break;
            }
            var includeUserList = new int[] { _orderModel?.UserId ?? 0 };
            list = _userService.GetUserListForCombo(userType, includeUserList);
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
        }

        private void PopulateModel(OrderModel model)
        {
            _orderModel = model;
            if (model != null)
            {
                btnPayment.Visible = model.RemainingAmount > 0;
                // change button
                _orderId = model.Id;
                txtReceiptNo.Text = model.ReferenceNumber;//tbOrderNumber.Text 
                dtExpectedDate.Value = model.DeliveryDate;
                txtAddress.Text = model.Address;
                txtPhone.Text = model.Phone;
                switch (_orderType)
                {
                    case OrderTypeEnum.Purchase:
                    case OrderTypeEnum.Sale:
                        cbClient.SelectedValue = model.UserId;
                        break;
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
                    this.Text = (model == null ? "Create" : "Edit") + " Transaction";
                    if (model?.PaymentDueDate.HasValue ?? false)
                        dtPaymentDueDate.Value = model.PaymentDueDate.Value;
                    break;
                case OrderTypeEnum.Sale:
                    lblClient.Text = "Customer";
                    this.Text = (model == null ? "Create" : "Edit") + " Transaction";
                    if (model?.PaymentDueDate.HasValue ?? false)
                        dtPaymentDueDate.Value = model.PaymentDueDate.Value;
                    break;
                    //case OrderTypeEnum.Move:
                    //    lblClient.Visible = false;
                    //    cbClient.Visible = false;
                    //    this.Text = (model == null ? "Create" : "Edit") + " Transfer Order";
                    //    break;
            }
        }

        private void PopulateReceiptNumber()
        {
            if (_orderModel == null)
            {
                txtReceiptNo.Text = _appSettingService.GetReceiptNumber(_orderType);
            }
        }
        private OrderModel Save(bool checkout = false, bool closeFormAftherSave = true)
        {
            var msg = string.Empty;
            if (!_requiredFieldValidator.IsValid())
                msg += "Some required Fields are empty\n";
            if (!_greaterThanZeroFieldValidator.IsValid())
                msg += "Some Fields are less than zero\n";
            if (txtPaidAmount.Value > txtTotal.Value)
                msg += "Paid amount cannot be greater than total amount";
            if (!string.IsNullOrEmpty(msg))
            {
                PopupMessage.ShowInfoMessage(msg);
                this.Focus();
                return null;
            }
            var model = GetData();
            if (model == null)
                return null;
            msg = _orderService.SaveOrder(model, checkout);
            if (string.IsNullOrEmpty(msg))
            {
                PopupMessage.ShowSaveSuccessMessage();
                if(closeFormAftherSave)
                    this.Close();
                return model;
            }
            else
            {
                PopupMessage.ShowErrorMessage("Couln't save! Please contact admin.");

            }
            this.Focus();
            return null;
        }

        private OrderModel GetData()
        {
            var client = "";
            var clientId = 0;
            int.TryParse(cbClient.SelectedValue?.ToString() ?? "", out clientId);
            if (clientId == 0)
            {
                client = cbClient.Text;
            }
            var ignoreList = new List<DataGridViewColumn> { dgvItems.colWarehouseId, dgvItems.colUomId };
            var items = dgvItems.GetItems(ignoreList, false);
            if (items != null)
            {
                var orderModel = new OrderModel
                {
                    Id = _orderId,
                    OrderType = _orderType.ToString(),
                    Name = (string.IsNullOrEmpty(cbClient.Text) ? "" : $"{cbClient.Text}, ") + txtReceiptNo.Text,
                    DeliveryDate = dtExpectedDate.Value,
                    PaidAmount = txtPaidAmount.Value,
                    CreatedAt = DateTime.Now,
                    OrderItems = InventoryUnitMapper.MapToOrderItemModel(items, _orderId),
                    ReferenceNumber = txtReceiptNo.Text,
                    Phone = txtPhone.Text,
                    Address = txtAddress.Text,
                    PaymentDueDate = rbCredit.Checked ? dtPaymentDueDate.Value : (DateTime?)null,
                    PaymentType = rbCredit.Checked ? PaymentType.Credit.ToString() : PaymentType.Cash.ToString(),
                    TotalAmount = items.Select(x=>x.Total).Sum()
                };
                orderModel.User = client;
                orderModel.UserId = clientId;

                return orderModel;
            }
            return null;
        }

        #endregion




        #region Event Handlers

        private void _listener_CustomerUpdated(object sender, Service.DbEventArgs.BaseEventArgs<UserModel> e)
        {
            PopulateClientCombo();
            cbClient.SelectedValue = e.Model == null ? 0 : e.Model.Id;
        }


        private void RbCredit_CheckedChanged(object sender, EventArgs e)
        {
            pnlPaymentDueDate.Visible = rbCredit.Checked;
            txtPaidAmount.Value = rbCredit.Checked ? 0 : txtTotal.Value;
            txtPaidAmount.Enabled = rbCredit.Checked;

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            Save(true);
        }

        private void BtnCheckoutAndPrint_Click(object sender, EventArgs e)
        {
             CheckOutAndPrint();
            //var printBillTest = new PrintBillTest();
            //printBillTest.ShowDialog();
        }

        private void CheckOutAndPrint()
        {
            var model = Save(true, false);
            if (model != null)
            {
                this.Controls.Clear();
                //var orders = _orderService.GetAllOrders(OrderTypeEnum.Sale);
                //var order = _orderService.GetOrderForDetailView(orders.FirstOrDefault()?.Id ?? 0);
                var transactionPrintBillUc = new TransactionPrintReceiptUC(model);
                this.Controls.Add(transactionPrintBillUc);
            }
        }
        

        private void LblClient_DoubleClick(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var supplierCreate = Program.container.GetInstance<SupplierCreate>();
                supplierCreate.SetType(_orderType);
                supplierCreate.ShowDialog();
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var po = Program.container.GetInstance<PaymentCreateForm>();
                po.SetData(_orderModel, null);
                po.ShowDialog();
            }
        }

        private void DgvItems_AmountChnanged(decimal totals)
        {
            try
            {
                txtTotal.Value = totals;
                if (rbCash.Checked)
                    txtPaidAmount.Value = totals;
            }
            catch (Exception ex)
            {
                txtTotal.Value = 0;
                PopupMessage.ShowInfoMessage(ex.Message);
            }
        }

        #endregion
    }
}
