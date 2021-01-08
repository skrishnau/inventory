﻿using DTO.Core.Inventory;
using IMS.Forms.Common;
using IMS.Forms.Common.Validations;
using IMS.Forms.Inventory.Suppliers;
using Service.Core.Business;
using Service.Core.Inventory;
using Service.Core.Orders;
using Service.Core.Settings;
using Service.Core.Users;
using Service.Listeners;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ViewModel.Core.Common;
using ViewModel.Core.Orders;
using ViewModel.Core.Users;
using ViewModel.Enums;

namespace IMS.Forms.Inventory.Transaction
{
    public partial class TransactionCreateForm : Form
    {
        private readonly IUserService _supplierService;
        private readonly IDatabaseChangeListener _listener;
        private readonly IBusinessService _businessService;
        private readonly IOrderService _orderService;
        private readonly IInventoryService _inventoryService;
        private readonly IAppSettingService _appSettingService;
        private RequiredFieldValidator _requiredFieldValidator;
        private GreaterThanZeroFieldValidator _greaterThanZeroFieldValidator;

        private OrderModel _orderModel;
        private int _orderId;
        private OrderTypeEnum _orderType;


        public TransactionCreateForm(IUserService supplierService,
            IBusinessService businessService,
            IInventoryService inventoryService,
            IOrderService purchaseService,
            IDatabaseChangeListener listener, 
            IAppSettingService appSettingService)
        {
            _listener = listener;
            this._businessService = businessService;
            this._supplierService = supplierService;
            this._orderService = purchaseService;
            this._inventoryService = inventoryService;
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

            dgvItems.InitializeGridViewControls(_inventoryService);
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
            dgvItems.DesignForTransaction(true);
        }

        private void InitializeSaveFooter()
        {
            saveFooterUC1.pnlCheckout.Visible = true;
        }

        private void InitializeEvents()
        {
            saveFooterUC1.btnSave.Click += BtnSave_Click;
            saveFooterUC1.btnCancel.Click += BtnCancel_Click;
            saveFooterUC1.btnCheckout.Click += BtnCheckout_Click;
            rbCredit.CheckedChanged += RbCredit_CheckedChanged;

            _listener.UserUpdated += _listener_CustomerUpdated;
            lblClient.DoubleClick += LblClient_DoubleClick;

            dgvItems.AmountChanged += DgvItems_AmountChnanged;
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
            switch (_orderType)
            {
                case OrderTypeEnum.Purchase:
                case OrderTypeEnum.Sale:
                    list = _supplierService.GetSupplierListForCombo();
                    break;
            }
            if (list != null)
            {
                list.Insert(0, new IdNamePair
                {
                    Id = 0,
                    Name = ""
                });
                cbClient.DataSource = list;
                cbClient.DisplayMember = "Name";
                cbClient.ValueMember = "Id";
            }
        }

        private void PopulateModel(OrderModel model)
        {
            _orderModel = model;
            if (model != null)
            {
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
            if(_orderModel == null)
            {
                txtReceiptNo.Text = _appSettingService.GetReceiptNumber(_orderType);
            }
        }
        private void Save(bool checkout = false)
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
                return;
            }
            var model = GetData();
            if (model == null)
                return;
            _orderService.SaveOrder(model, checkout);
            this.Close();
        }

        private OrderModel GetData()
        {
            var client = "";
            var clientId = 0;
            int.TryParse(cbClient.SelectedValue?.ToString()??"", out clientId);
            if (clientId == 0)
            {
                client = cbClient.Text;
            }
            var items = dgvItems.GetItems();
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
            txtPaidAmount.Value = txtTotal.Value;
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

        private void LblClient_DoubleClick(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var supplierCreate = Program.container.GetInstance<SupplierCreate>();
                supplierCreate.SetType(_orderType);
                supplierCreate.ShowDialog();
            }
        }

        private void DgvItems_AmountChnanged(decimal totals)
        {
            txtTotal.Value = totals;
            if (rbCash.Checked)
                txtPaidAmount.Value = totals;
        }
        #endregion
    }
}
