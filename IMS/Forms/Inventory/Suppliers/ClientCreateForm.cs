using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IMS.Forms.Common;
using IMS.Forms.Common.Validations;
using Service.Core.Users;
using Service.Listeners;
using ViewModel.Core;
using ViewModel.Core.Common;
using ViewModel.Enums;
using ViewModel.Utility;

namespace IMS.Forms.Inventory.Suppliers
{
    public partial class ClientCreateForm : Form
    {
        private readonly IUserService _supplierService;
        private readonly IDatabaseChangeListener _listener;

        private List<UserTypeEnum> _userType;

        private int _supplierId;
        private int _userId;

        public ClientCreateForm(IUserService supplierService, IDatabaseChangeListener listener)
        {
            this._supplierService = supplierService;
            _listener = listener;
            InitializeComponent();



            this.Load += SupplierCreate_Load;
        }

        private void SupplierCreate_Load(object sender, EventArgs e)
        {
            this.Text = (_userType.Count == 1 ? _userType.Contains(UserTypeEnum.Employee) ? "Employee" : _userType.Count == 1 ? _userType[0].ToString() : "" : "") + " Create";
            this.ActiveControl = tbName;
            PopulateUserType();

            var supplier = _supplierService.GetUser(_userId);
            SetDataForEdit(supplier);

            InitializeEvents();
        }

        private void InitializeEvents()
        {
            btnSave.Click += btnSave_Click;
            cbUserType.SelectedValueChanged += CbUserType_SelectedValueChanged;
            chkLoginEnabled.CheckedChanged += ChkLoginEnabled_CheckedChanged;
        }

        private void ChkLoginEnabled_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideUserNamePassword(chkLoginEnabled.Checked);
        }

        private void ShowHideUserNamePassword(bool show)
        {
            var showLoginRelated = cbUserType.SelectedValue?.ToString() == UserTypeEnum.Employee.ToString();
            //var isChecked = chkLoginEnabled.Checked;
            //var isChkLoginShown = showLoginRelated;//tbIsLoginEnabled.Visible;
            tblUsernamePassword.Visible = show;//showLoginRelated && chkLoginEnabled.Checked;
        }

        private void PopulateUserType()
        {
            var list = new List<NameValuePair>();
            if (_userType.Contains(UserTypeEnum.Customer) || _userType.Contains(UserTypeEnum.Supplier))
            {
                var customer = UserTypeEnum.Customer.ToString();
                var supplier = UserTypeEnum.Supplier.ToString();
                list.Add(new NameValuePair("--- Select ---", ""));
                list.Add(new NameValuePair(customer, customer));
                list.Add(new NameValuePair(supplier, supplier));
            }
            if (_userType.Contains(UserTypeEnum.Vendor))
            {
                var vendor = UserTypeEnum.Vendor.ToString();
                //list.Add(new NameValuePair("--- Select ---", ""));
                list.Add(new NameValuePair(vendor, vendor));
            }
            if (_userType.Contains(UserTypeEnum.Employee))
            {
                var user = UserTypeEnum.Employee.ToString();
                //list.Add(new NameValuePair("--- Select ---", ""));
                list.Add(new NameValuePair("Employee", user));

            }
            cbUserType.DataSource = list;
            cbUserType.ValueMember = "Value";
            cbUserType.DisplayMember = "name";
            try
            {
                if (_userType.Count == 1)
                {
                    cbUserType.SelectedValue = _userType.First().ToString();
                    //cbUserType.Enabled = false;
                }

            }
            catch (Exception) { }
            //UpdateViewAsPerUserType();// (_userType);

        }




        private void CbUserType_SelectedValueChanged(object sender, EventArgs e)
        {
            var value = cbUserType.SelectedValue as string;
            if (value != null)
            {
                if (Enum.TryParse<UserTypeEnum>(value, out UserTypeEnum userType))
                {
                    UpdateViewAsPerUserType();//(new List<UserTypeEnum> { userType });
                    ShowHideUserNamePassword(chkLoginEnabled.Checked);
                }
            }
        }

        private void UpdateViewAsPerUserType()//(List<UserTypeEnum> _userType)
        {
            Enum.TryParse(cbUserType.SelectedValue as string, out UserTypeEnum userType);
            if (userType == UserTypeEnum.Customer || userType == UserTypeEnum.Supplier)
            {
                lblName.Text = "Name";
                tbCompany.Visible = true;
                lblCompany.Visible = true;
                tbIsLoginEnabled.Visible = false;
                chkLoginEnabled.Checked = false;
            }
            if (userType == UserTypeEnum.Vendor)
            {
                lblName.Text = "Contact Person Name";
                tbCompany.Visible = true;
                lblCompany.Visible = true;
                tbIsLoginEnabled.Visible = false;
                chkLoginEnabled.Checked = false;
            }
            if (userType == UserTypeEnum.Employee)
            {
                lblName.Text = "Name";
                tbCompany.Visible = false;
                lblCompany.Visible = false;
                tbIsLoginEnabled.Visible = true;
            }
        }
        public void SetDataForEdit(int userId, List<UserTypeEnum> userType)
        {
            _userType = userType;//new List<UserTypeEnum> { userType.Any() ? userType.First() :  UserTypeEnum.Customer };
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

                chkLoginEnabled.Checked = model.CanLogin;
                tbIsLoginEnabled.Visible = model.UserType == UserTypeEnum.Employee.ToString();
                tblUsernamePassword.Visible = model.CanLogin && model.UserType == UserTypeEnum.Employee.ToString();
                tbUsername.Text = model.Username;
                //tbPassword.Text = model.Password;
                // dont' show password in edit mode
                lblPassword.Visible = false;
                tbPassword.Visible = false;
            }
            UpdateViewAsPerUserType();
            ShowHideUserNamePassword(model?.CanLogin??false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            var msg = ValidateControls();
            if (!string.IsNullOrEmpty(msg))
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
                CanLogin = tbIsLoginEnabled.Visible && chkLoginEnabled.Checked,
            };
            if (model.CanLogin)
            {
                model.Username = tbUsername.Text;
                model.Password = tbPassword.Text;
            }
            var response = _supplierService.AddOrUpdateUser(model);
            if (response.Success)
            {
                this.Close();
            }
            else
            {
                PopupMessage.ShowErrorMessage(response.Message);
                this.Focus();
            }
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
            if (tbIsLoginEnabled.Visible && chkLoginEnabled.Checked)
            {
                if (string.IsNullOrEmpty(tbUsername.Text.Trim()))
                {
                    errorProvider1.SetError(tbUsername, RequiredFieldValidator.REQUIRED);
                    msg += "Username is required.\n";
                }
                else
                {
                    errorProvider1.SetError(tbUsername, string.Empty);
                }
                if (_supplierId == 0 && string.IsNullOrEmpty(tbPassword.Text.Trim()))
                {
                    errorProvider1.SetError(tbPassword, RequiredFieldValidator.REQUIRED);
                    msg += "Password is required.\n";
                }
                else
                {
                    errorProvider1.SetError(tbPassword, string.Empty);
                }
            }
            return msg;
        }

        internal void SetType(OrderTypeEnum orderType)
        {
            switch (orderType)
            {
                case OrderTypeEnum.Sale:
                    _userType = new List<UserTypeEnum> { UserTypeEnum.Customer };
                    break;
                case OrderTypeEnum.Purchase:
                    _userType = new List<UserTypeEnum> { UserTypeEnum.Supplier };
                    break;
                    //case OrderTypeEnum.All:
                    //    _userType = 
                    //    break;
            }
        }
    }
}
