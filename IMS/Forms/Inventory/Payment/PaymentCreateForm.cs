using IMS.Forms.Common;
using IMS.Forms.Common.Validations;
using Service.Core.Payment;
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
using ViewModel.Core.Common;
using ViewModel.Core.Orders;
using ViewModel.Core.Users;
using ViewModel.Enums;

namespace IMS.Forms.Inventory.Payment
{
    public partial class PaymentCreateForm : Form
    {
        private OrderModel _orderModel;
        private UserModel _userModel;
        private readonly IPaymentService _paymentService;
        private readonly IUserService _userService;
        private RequiredFieldValidator _requiredFieldValidator;
        private GreaterThanZeroFieldValidator _greaterThanZeroFieldValidator;

        private decimal totalAmount;
        

        public PaymentCreateForm(IPaymentService paymentService, IUserService userService)
        {
            _paymentService = paymentService;
            _userService = userService;
            InitializeComponent();

            txtAmount.Maximum = Int32.MaxValue;
            txtAmount.Minimum = Int32.MinValue;

            InitializeEvents();
            InitializeValidation();
            PopulatePaymentMethodCombo();
        }

        public void SetData(OrderModel orderModel, UserModel userModel)
        {
            var byFrom = "-";
            if(orderModel != null)
            {
                 byFrom = orderModel.OrderType == OrderTypeEnum.Sale.ToString() ? "By Customer" : "To Supplier";
                this.Text = $"New {orderModel.OrderType} Payment {byFrom}";
                this.headerTemplate1.Text = orderModel.Name;
                lblRemainingAmount.Text = orderModel.DueAmount.ToString();
                lblTotalAmount.Text = orderModel.TotalAmount.ToString();
                txtAmount.Value = 0;//orderModel.RemainingAmount;
                _orderModel = orderModel;
                totalAmount = orderModel.TotalAmount;
            }
            else if(userModel != null)
            {
                byFrom = userModel.UserType== UserTypeEnum.Customer.ToString()? "By Customer" : "To Supplier";
                this.Text = $"New Payment {byFrom}";
                this.headerTemplate1.Text = userModel.Name;
                var transactionSum = _userService.GetTransactionSumOfUser(userModel.Id);
                lblRemainingAmount.Text = transactionSum?.DueAmount.ToString();//userModel.DueAmount.ToString();
                lblTotalAmount.Text = transactionSum?.TotalAmount.ToString();//userModel.TotalAmount.ToString();
                txtAmount.Value = 0;// userModel.DueAmount;
                _userModel = userModel;
                totalAmount = transactionSum?.TotalAmount??0;
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
            txtChequeNo.Enabled = cbPaymentMethod.SelectedValue?.ToString() == PaymentMethodEnum.Cheque.ToString();
        }

        private void ChkAllPaid_CheckedChanged(object sender, EventArgs e)
        {
            txtAmount.Enabled = !chkAllPaid.Checked;
            if (chkAllPaid.Checked)
            {
                txtAmount.Value = _userModel!=null ? _userModel.DueAmount: _orderModel != null? _orderModel.DueAmount : 0;
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


        private void Save()
        {
            var payment = GetData();
            if (payment != null)
            {
                DialogResult dialogResult = MessageBox.Show(this, "Are you sure to save the payment?", "Save", MessageBoxButtons.OKCancel);
                if (dialogResult.Equals(DialogResult.OK))
                {
                    _paymentService.Save(payment);
                    this.Close();
                }
            }
        }

        private void Print()
        {
            this.Text = "Print Receipt";
            this.Controls.Clear();
            var transactionPrintBillUc = new PaymentPrintUC();
            this.Controls.Add(transactionPrintBillUc);
        }

        public PaymentModel GetData()
        {
            var isValid = true;
            isValid = _requiredFieldValidator.IsValid();
            isValid = isValid && _greaterThanZeroFieldValidator.IsValid();
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
                PaymentMethod = cbPaymentMethod.SelectedValue.ToString(),
                OrderId = _orderModel?.Id,
                UserId = _userModel?.Id,
                TotalAmount = totalAmount,
            };
            return model;
        }

    }
}
