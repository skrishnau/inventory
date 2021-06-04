using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IMS.Forms.Common;
using IMS.Forms.Common.Validations;
using Service.Core.Users;
using Service.Listeners;
using ViewModel.Core.Common;
using ViewModel.Core.Users;
using ViewModel.Enums;

namespace IMS.Forms.Inventory.Suppliers
{
    public partial class ClientCreateUC : Form
    {
        private readonly IUserService _supplierService;
        private readonly IDatabaseChangeListener _listener;

        private UserTypeEnum _userType;

        private int _supplierId;
        private int _userId;

        public ClientCreateUC(IUserService supplierService, IDatabaseChangeListener listener)
        {
            this._supplierService = supplierService;
            _listener = listener;
            InitializeComponent();

           

            this.Load += SupplierCreate_Load;
        }

        private void SupplierCreate_Load(object sender, EventArgs e)
        {
            this.Text = _userType + " Create";
            InitializeEvents();
            this.ActiveControl = tbName;
            PopulateUserType();

            var supplier = _supplierService.GetUser(_userId);
            SetDataForEdit(supplier);
        }

        private void PopulateUserType()
        {
            var list = new List<NameValuePair>();
            var customer = UserTypeEnum.Customer.ToString();
            var supplier = UserTypeEnum.Supplier.ToString();
            list.Add(new NameValuePair ("--- Select ---", "" ));
            list.Add(new NameValuePair (customer, customer));
            list.Add(new NameValuePair (supplier, supplier));

            cbUserType.DataSource = list;
            cbUserType.ValueMember = "Value";
            cbUserType.DisplayMember = "name";
            if(_userType != UserTypeEnum.All && _userType != UserTypeEnum.Client)
                cbUserType.SelectedValue = _userType.ToString();
        }

        private void InitializeEvents()
        {
            btnSave.Click += btnSave_Click;
        }

        public void SetDataForEdit(int userId, UserTypeEnum userType)
        {
            _userType = userType;
            _userId = userId;
        }

        
        public void SetDataForEdit(UserModel model)
        {
            if (model != null)
            {
                cbUserType.Enabled = false;
                cbUserType.SelectedValue = model.UserType;
                this.Text = model.UserType + " Edit (" + model.Name + ")";
                tbAddress.Text = model.Address;
                tbEmail.Text = model.Email;
                tbCompany.Text = model.Fax;
                tbName.Text = model.Name;
                tbNotes.Text = model.Notes;
                tbPhone.Text = model.Phone;
                //tbSalesperson.Text = model.SalesPerson;
               // tbWebsite.Text = model.Website;
                tbCompany.Text = model.Company;
                chkUse.Checked = model.Use;
                _supplierId = model.Id;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var msg = ValidateControls();
            if(!string.IsNullOrEmpty(msg))
            {
                PopupMessage.ShowInfoMessage(msg);
                this.Focus();
                return;
            }
            var model = new UserModel
            {
                Address = tbAddress.Text,
                Name = tbName.Text,
                Email = tbEmail.Text,
                Phone = tbPhone.Text,
                Fax = tbCompany.Text,
                IsCompany = true,
                Id = _supplierId,
                Notes = tbNotes.Text,
                //RegisteredAt = cbtbRegisteredDate.Value,
               // SalesPerson = tbSalesperson.Text,
                //Website = tbWebsite.Text,
                Company = tbCompany.Text,
                Use = chkUse.Checked,
                UserType = cbUserType.SelectedValue.ToString(),
            };
            _supplierService.AddOrUpdateUser(model);
            this.Close();
        }

        private string ValidateControls()
        {
            var msg = string.Empty;
            if (string.IsNullOrEmpty(tbName.Text.Trim()))
            {
                errorProvider1.SetError(tbName, RequiredFieldValidator.REQUIRED);
                msg += "Name is required.\n";
            }
            else
            {
                errorProvider1.SetError(tbName, string.Empty);
            }
            if (string.IsNullOrEmpty(cbUserType.SelectedValue?.ToString()))
            {
                errorProvider1.SetError(cbUserType, RequiredFieldValidator.REQUIRED);
                msg += "Type is required.\n";
            }
            else
            {
                errorProvider1.SetError(cbUserType, string.Empty);
            }
            return msg;
        }

        internal void SetType(OrderTypeEnum orderType)
        {
            switch (orderType)
            {
                case OrderTypeEnum.Sale:
                    _userType = UserTypeEnum.Customer;
                    break;
                case OrderTypeEnum.Purchase:
                    _userType = UserTypeEnum.Supplier;
                    break;
                case OrderTypeEnum.All:
                    _userType = UserTypeEnum.All;
                    break;
            }
        }
    }
}
