using IMS.Forms.Common;
using IMS.Forms.Common.Validations;
using Service.Core.Payment;
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
        private readonly PaymentService _paymentService;
        private RequiredFieldValidator _requiredFieldValidator;
        private GreaterThanZeroFieldValidator _greaterThanZeroFieldValidator;
        

        public PaymentCreateForm(PaymentService paymentService)
        {
            _paymentService = paymentService;
            InitializeComponent();

            txtAmount.Maximum = Int32.MaxValue;
            txtAmount.Minimum = Int32.MinValue;

            InitializeEvents();
            InitializeValidation();
            PopulatePaymentMethodCombo();
        }

        public void SetData(OrderModel orderModel, UserModel userModel)
        {
            if(orderModel != null)
            {
                this.headerTemplate1.Text = orderModel.Name;
                lblRemainingAmount.Text = orderModel.RemainingAmount.ToString();
                lblTotalAmount.Text = orderModel.TotalAmount.ToString();
                txtAmount.Value = 0;//orderModel.RemainingAmount;
                _orderModel = orderModel;
            }
            else if(userModel == null)
            {
                this.headerTemplate1.Text = userModel.Name;
                lblRemainingAmount.Text = userModel.DueAmount.ToString();
                lblTotalAmount.Text = userModel.TotalAmount.ToString();
                txtAmount.Value = 0;// userModel.DueAmount;
                _userModel = userModel;
            }
            
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
                txtAmount.Value = _orderModel.RemainingAmount;
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
            };
            return model;
        }

    }
}
