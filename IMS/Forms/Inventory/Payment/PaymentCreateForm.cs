using IMS.Forms.Common;
using IMS.Forms.Common.Validations;
using Service.Core.Payment;
using Service.Core.Settings;
using Service.Core.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ViewModel.Core;
using ViewModel.Core.Common;
using ViewModel.Core.Orders;
using ViewModel.Enums;

namespace IMS.Forms.Inventory.Payment
{
    public partial class PaymentCreateForm : Form
    {
        //private OrderModel _orderModel;
        private UserModel _userModel;
        private readonly IPaymentService _paymentService;
        private readonly IUserService _userService;
        private readonly IAppSettingService _appSettingService;
        private RequiredFieldValidator _requiredFieldValidator;
        //private GreaterThanZeroFieldValidator _greaterThanZeroFieldValidator;

        private decimal totalAmount;
        private decimal _dueAmount;

        private bool _showPrint;
        private PaymentModel _paymentModel;



        public PaymentCreateForm(IPaymentService paymentService, IUserService userService, IAppSettingService appSettingService)
        {
            _paymentService = paymentService;
            _userService = userService;
            _appSettingService = appSettingService;

            InitializeComponent();


            this.Load += PaymentCreateForm_Load;
        }

        private void PaymentCreateForm_Load(object sender, EventArgs e)
        {
            txtAmount.Maximum = Int32.MaxValue;
            txtAmount.Minimum = Int32.MinValue;

            InitializeEvents();
            InitializeValidation();
            PopulatePaymentTypeCombo();
            PopulatePaymentMethodCombo();
            PopulatePaymentData();
            PopulateReceiptNumber();

        }

        private void PopulateReceiptNumber()
        {
            txtReferenceNumber.Text = _appSettingService.GetReceiptNumber(ReferencesTypeEnum.Payment);
        }

        public void SetData(int userId, int paymentId, bool showPrint)
        {
            if (showPrint && paymentId > 0)
            {
                _showPrint = showPrint;
                _paymentModel = _paymentService.GetPayment(paymentId);
            }
            _userModel = _userService.GetUserWithTotalAndPaidAmounts(userId);
        }

        public void SetData(UserModel userModel)//OrderModel orderModel,
        {
            _userModel = userModel;
            //if (orderModel != null)
            //{
            //    byFrom = orderModel.OrderType == OrderTypeEnum.Sale.ToString() ? "By Customer" : "To Supplier";
            //    this.Text = $"New {orderModel.OrderType} Payment {byFrom}";
            //    this.headerTemplate1.Text = orderModel.Name;
            //    lblRemainingAmount.Text = orderModel.DueAmount.ToString();
            //    lblTotalAmount.Text = orderModel.TotalAmount.ToString();
            //    txtAmount.Value = 0;//orderModel.RemainingAmount;
            //    //_orderModel = orderModel;
            //    totalAmount = orderModel.TotalAmount;
            //}
            //else 
        }

        private void PopulatePaymentData()
        {

            if(_paymentModel!=null && _showPrint)
            {
                ShowPrint(_paymentModel);
            }
            else
            {
                var company = _appSettingService.GetCompanyInfoSetting();
                var byFrom = "";
                var byFromCustomerSupplier = "-";
                if (_userModel != null)
                {
                    byFrom = _userModel.UserType == UserTypeEnum.Customer.ToString() ? "By" : "To";
                    byFromCustomerSupplier = byFrom + " " + _userModel.UserType;//_userModel.UserType == UserTypeEnum.Customer.ToString() ? "By Customer" : "To Supplier";
                    this.Text = $"New Payment {byFromCustomerSupplier}";
                    this.headerTemplate1.Text = _userModel.Name;
                    var transactionSum = _userService.GetTransactionSumOfUser(_userModel.Id);
                    lblRemainingAmount.Text = transactionSum?.DueAmount.ToString();//userModel.DueAmount.ToString();
                    lblTotalAmount.Text = transactionSum?.TotalAmount.ToString();//userModel.TotalAmount.ToString();
                    txtAmount.Value = 0;// userModel.DueAmount;
                    totalAmount = transactionSum?.TotalAmount ?? 0;
                    _dueAmount = transactionSum?.DueAmount ?? 0;
                    txtBy.Text = (_userModel.UserType == UserTypeEnum.Customer.ToString() ? "Paid " + byFrom + " " + _userModel.Name : company.CompanyName);
                    if (_userModel.UserType == UserTypeEnum.Customer.ToString())
                    {
                        cbPaymentType.SelectedValue = PaymentTypeEnum.Credit.ToString();
                    }
                    else
                    {
                        cbPaymentType.SelectedValue = PaymentTypeEnum.Debit.ToString();
                    }
                    btnPrint.Visible = (cbPaymentType.SelectedValue as string) == PaymentTypeEnum.Credit.ToString(); //_userModel.UserType == UserTypeEnum.Customer.ToString();
                }
                lblByFrom.Text = byFromCustomerSupplier;
            }
          
        }


        private void InitializeValidation()
        {
            //List<Control> greaterThanZeroControls = new List<Control> { txtAmount };
            var requiredControls = new List<Control> { cbPaymentMethod };
            _requiredFieldValidator = new RequiredFieldValidator(errorProvider1, requiredControls.ToArray());
            // _greaterThanZeroFieldValidator = new GreaterThanZeroFieldValidator(errorProvider1, greaterThanZeroControls.ToArray());
        }

        private void PopulatePaymentMethodCombo()
        {
            var paymentMethods = Enum.GetValues(typeof(PaymentMethodEnum)).Cast<PaymentMethodEnum>();
            var dataList = paymentMethods.Select(x => new NameValuePair(x.ToString(), x.ToString())).ToList();
            cbPaymentMethod.DataSource = dataList;
            cbPaymentMethod.DisplayMember = "Name";
            cbPaymentMethod.ValueMember = "Value";
        }


        private void PopulatePaymentTypeCombo()
        {
            var dataList = new List<NameValuePair>();
            dataList.Add(new NameValuePair(PaymentTypeEnum.Credit.ToString() + " (लिएको)", PaymentTypeEnum.Credit.ToString()));
            dataList.Add(new NameValuePair(PaymentTypeEnum.Debit.ToString() + " (दिएको)", PaymentTypeEnum.Debit.ToString()));
            //var paymentMethods = Enum.GetValues(typeof(PaymentTypeEnum)).Cast<PaymentTypeEnum>();
            //var dataList = paymentMethods.Select(x => new NameValuePair(x.ToString(), x.ToString())).ToList();
            cbPaymentType.DataSource = dataList;
            cbPaymentType.DisplayMember = "Name";
            cbPaymentType.ValueMember = "Value";
        }
        private void InitializeEvents()
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            btnPrint.Click += BtnPrint_Click;
            chkAllPaid.CheckedChanged += ChkAllPaid_CheckedChanged;
            cbPaymentMethod.SelectedValueChanged += CbPaymentMethod_SelectedValueChanged;
            cbPaymentType.SelectedValueChanged += CbPaymentType_SelectedValueChanged;
        }

        private void CbPaymentType_SelectedValueChanged(object sender, EventArgs e)
        {
            btnPrint.Visible = (cbPaymentType.SelectedValue as string) == PaymentTypeEnum.Credit.ToString();
            txtBy.Text = "";
        }


        #region Event Handlers

        private void CbPaymentMethod_SelectedValueChanged(object sender, EventArgs e)
        {
            var enabled = cbPaymentMethod.SelectedValue?.ToString() == PaymentMethodEnum.Cheque.ToString();
            txtBank.Enabled = enabled;
            txtChequeNo.Enabled = enabled;
        }

        private void ChkAllPaid_CheckedChanged(object sender, EventArgs e)
        {
            txtAmount.Enabled = !chkAllPaid.Checked;
            if (chkAllPaid.Checked)
            {
                if (_userModel.DueAmount > 0)
                    txtAmount.Value = _userModel != null ? _userModel.DueAmount : 0;
                else
                {
                    PopupMessage.ShowInfoMessage($"The {_userModel.UserType} doesn't have any dues to be paid");
                    this.Focus();
                }
            }
            else
            {
                txtAmount.Value = 0;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }


        private void BtnPrint_Click(object sender, EventArgs e)
        {
            //Save();
            Print();
        }
        #endregion


        private ResponseModel<PaymentModel> Save(bool showPrint = false)
        {
            var payment = GetData();
            if (payment != null)
            {
                var additionalMsg = "";
                if (payment.Amount < 0)
                {
                    var isCustomer = payment.UserType == UserTypeEnum.Customer.ToString();
                    var byTo = "";
                    if (isCustomer)
                    {
                        byTo = "to";
                    }
                    else
                    {
                        byTo = "by";
                    }
                    additionalMsg = $"Having negative in Amount means that it's a payment {byTo} {payment.UserType}";
                }
                DialogResult dialogResult = MessageBox.Show(this, additionalMsg + " Are you sure to save the payment?"
                    , "Save", MessageBoxButtons.OKCancel);
                if (dialogResult.Equals(DialogResult.OK))
                {
                    if (!showPrint)
                        this.Close();
                    var saved = _paymentService.Save(payment);
                    //saved.Data.DueAmount = _dueAmount;
                    //saved.Data.DueAmount -= saved.Data.Amount;
                    return saved;
                }
            }
            return null;
        }

        private void Print()
        {
            var saved = Save(true);
            if (saved != null)
            {
                ShowPrint(saved.Data);
            }
        }

        private void ShowPrint(PaymentModel model)
        {
            this.Text = "Print Receipt";
            this.Controls.Clear();

            var transactionPrintBillUc = new PaymentPrintUC(_appSettingService, model);
            this.Controls.Add(transactionPrintBillUc);
        }

        public PaymentModel GetData()
        {
            var isValid = true;
            isValid = _requiredFieldValidator.IsValid();
            //isValid = isValid && _greaterThanZeroFieldValidator.IsValid();
            if (string.IsNullOrEmpty(txtBy.Text))
            {
                errorProvider1.SetError(txtBy, "Required");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtBy, string.Empty);
            }
            if (txtAmount.Value <= 0)
            {
                errorProvider1.SetError(txtAmount, "Should be greater than zero");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtAmount, string.Empty);
            }
            if (cbPaymentMethod.SelectedValue?.ToString() == PaymentMethodEnum.Cheque.ToString())
            {
                if (string.IsNullOrEmpty(txtBank.Text))
                {
                    isValid = false;
                    errorProvider1.SetError(txtBank, "Required");
                }
                else
                    errorProvider1.SetError(txtBank, string.Empty);

                if (string.IsNullOrEmpty(txtChequeNo.Text))
                {
                    isValid = false;
                    errorProvider1.SetError(txtChequeNo, "Required");
                }
                else
                    errorProvider1.SetError(txtChequeNo, string.Empty);

            }
            if (string.IsNullOrEmpty(txtReferenceNumber.Text))
            {
                isValid = false;
                errorProvider1.SetError(txtReferenceNumber, "Required");
            }
            else
            {
                errorProvider1.SetError(txtReferenceNumber, string.Empty);
            }
            if (!isValid)
            {
                PopupMessage.ShowMissingInputsMessage();
                this.Focus();
                return null;
            }
            var dueAmountNow = 0M;
            if (_userModel.UserType == UserTypeEnum.Customer.ToString())
            {
                if ((string)cbPaymentType.SelectedValue == PaymentTypeEnum.Credit.ToString())
                {
                    // received from customer
                    dueAmountNow = _dueAmount - txtAmount.Value;
                }
                else
                {
                    // given to customer
                    dueAmountNow = _dueAmount + txtAmount.Value;
                }
            }
            else if (_userModel.UserType == UserTypeEnum.Supplier.ToString())
            {
                if ((string)cbPaymentType.SelectedValue == PaymentTypeEnum.Credit.ToString())
                {
                    // received from supplier
                    dueAmountNow = _dueAmount + txtAmount.Value;
                }
                else
                {
                    // paid to supplier
                    dueAmountNow = _dueAmount - txtAmount.Value;
                }
            }

            var model = new PaymentModel
            {
                Amount = txtAmount.Value,
                ChequeNo = txtChequeNo.Text.ToString(),
                Date = DateTime.Now,
                PaidBy = txtBy.Text.ToString(),
                PaymentMethod = cbPaymentMethod.SelectedValue.ToString(),
                DueAmount = dueAmountNow,
                UserId = _userModel?.Id,
                TotalAmount = totalAmount,
                Bank = txtBank.Text,
                ReferenceNumber = txtReferenceNumber.Text,
                UserType = _userModel.UserType,
                DueDate = dueAmountNow > 0 ? _userModel.PaymentDueDate : null,
                PaymentType = cbPaymentType.SelectedValue.ToString()
            };
            return model;
        }

    }
}
