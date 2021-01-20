using IMS.Forms.Common;
using IMS.Forms.Common.Validations;
using Service.Core.Payment;
using Service.Core.Settings;
using Service.Core.Users;
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
using ViewModel.Core.Common;
using ViewModel.Core.Orders;
using ViewModel.Core.Users;
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
        private GreaterThanZeroFieldValidator _greaterThanZeroFieldValidator;

        private decimal totalAmount;
        private decimal _dueAmount;



        public PaymentCreateForm(IPaymentService paymentService, IUserService userService, IAppSettingService appSettingService)
        {
            _paymentService = paymentService;
            _userService = userService;
            _appSettingService = appSettingService;

            InitializeComponent();

            txtAmount.Maximum = Int32.MaxValue;
            txtAmount.Minimum = Int32.MinValue;

            InitializeEvents();
            InitializeValidation();
            PopulatePaymentMethodCombo();
        }

        public void SetData(OrderModel orderModel, UserModel userModel)
        {
            var company = _appSettingService.GetCompanyInfoSetting();
            var byFrom = "-";
            if (orderModel != null)
            {
                byFrom = orderModel.OrderType == OrderTypeEnum.Sale.ToString() ? "By Customer" : "To Supplier";
                this.Text = $"New {orderModel.OrderType} Payment {byFrom}";
                this.headerTemplate1.Text = orderModel.Name;
                lblRemainingAmount.Text = orderModel.DueAmount.ToString();
                lblTotalAmount.Text = orderModel.TotalAmount.ToString();
                txtAmount.Value = 0;//orderModel.RemainingAmount;
                //_orderModel = orderModel;
                totalAmount = orderModel.TotalAmount;
            }
            else if (userModel != null)
            {
                byFrom = userModel.UserType == UserTypeEnum.Customer.ToString() ? "By Customer" : "To Supplier";
                btnPrint.Visible = userModel.UserType == UserTypeEnum.Customer.ToString();
                this.Text = $"New Payment {byFrom}";
                this.headerTemplate1.Text = userModel.Name;
                var transactionSum = _userService.GetTransactionSumOfUser(userModel.Id);
                lblRemainingAmount.Text = transactionSum?.DueAmount.ToString();//userModel.DueAmount.ToString();
                lblTotalAmount.Text = transactionSum?.TotalAmount.ToString();//userModel.TotalAmount.ToString();
                txtAmount.Value = 0;// userModel.DueAmount;
                _userModel = userModel;
                totalAmount = transactionSum?.TotalAmount ?? 0;
                _dueAmount = transactionSum?.DueAmount??0;
                txtBy.Text = userModel.UserType == UserTypeEnum.Customer.ToString() ? userModel.Name : company.CompanyName;
            }
            lblByFrom.Text = byFrom;
        }


        private void InitializeValidation()
        {
            List<Control> greaterThanZeroControls = new List<Control> { txtAmount };
            var requiredControls = new List<Control> { cbPaymentMethod };
            _requiredFieldValidator = new RequiredFieldValidator(errorProvider1, requiredControls.ToArray());
            _greaterThanZeroFieldValidator = new GreaterThanZeroFieldValidator(errorProvider1, greaterThanZeroControls.ToArray());
        }

        private void PopulatePaymentMethodCombo()
        {
            var paymentMethods = Enum.GetValues(typeof(PaymentMethodEnum)).Cast<PaymentMethodEnum>();
            var dataList = paymentMethods.Select(x => new NameValuePair(x.ToString(), x.ToString())).ToList();
            cbPaymentMethod.DataSource = dataList;
            cbPaymentMethod.DisplayMember = "Name";
            cbPaymentMethod.ValueMember = "Value";
        }

        private void InitializeEvents()
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            btnPrint.Click += BtnPrint_Click;
            chkAllPaid.CheckedChanged += ChkAllPaid_CheckedChanged;
            cbPaymentMethod.SelectedValueChanged += CbPaymentMethod_SelectedValueChanged;

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
                txtAmount.Value = _userModel != null ? _userModel.DueAmount :  0;
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
                DialogResult dialogResult = MessageBox.Show(this, "Are you sure to save the payment?", "Save", MessageBoxButtons.OKCancel);
                if (dialogResult.Equals(DialogResult.OK))
                {
                    if (!showPrint)
                        this.Close();
                    return _paymentService.Save(payment);
                }
            }
            return null;
        }

        private void Print()
        {
            var saved = Save(true);
            if (saved != null)
            {
                saved.Data.DueAmount = _dueAmount;//_orderModel.TotalAmount;
                this.Text = "Print Receipt";
                this.Controls.Clear();

                var transactionPrintBillUc = new PaymentPrintUC(_appSettingService, saved.Data);
                this.Controls.Add(transactionPrintBillUc);
            }
        }

        public PaymentModel GetData()
        {
            var isValid = true;
            isValid = _requiredFieldValidator.IsValid();
            isValid = isValid && _greaterThanZeroFieldValidator.IsValid();
            if (cbPaymentMethod.SelectedValue?.ToString() == PaymentMethodEnum.Cheque.ToString())
            {
                if(string.IsNullOrEmpty(txtBank.Text))
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
            }else
            {
                errorProvider1.SetError(txtReferenceNumber, string.Empty);
            }
            if (!isValid)
            {
                PopupMessage.ShowMissingInputsMessage();
                this.Focus();
                return null;
            }

            var model = new PaymentModel
            {
                Amount = txtAmount.Value,
                ChequeNo = txtChequeNo.Text.ToString(),
                Date = DateTime.Now,
                PaidBy = txtBy.Text.ToString(),
                PaymentType = cbPaymentMethod.SelectedValue.ToString(),
               // OrderId = _orderModel?.Id,
                UserId = _userModel?.Id,
                TotalAmount = totalAmount,
                Bank = txtBank.Text,
                ReferenceNumber = txtReferenceNumber.Text,

            };
            return model;
        }

    }
}
