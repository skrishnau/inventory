using System;
using System.Windows.Forms;
using Service.Core.Users;
using Service.Listeners;
using ViewModel.Core.Users;
using ViewModel.Enums;

namespace IMS.Forms.Inventory.Suppliers
{
    public partial class SupplierCreate : Form
    {
        private readonly IUserService _supplierService;
        private readonly IDatabaseChangeListener _listener;

        private UserTypeEnum _userType;

        private int _supplierId;

        public SupplierCreate(IUserService supplierService, IDatabaseChangeListener listener)
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
        }

        private void InitializeEvents()
        {
            btnSave.Click += btnSave_Click;
        }

        public void SetDataForEdit(int supplierId, UserTypeEnum userType)
        {
            _userType = userType;

            var supplier = _supplierService.GetSupplier(supplierId);
            SetDataForEdit(supplier);
        }

        
        public void SetDataForEdit(UserModel model)
        {

            if (model != null)
            {
                this.Text = _userType + " Edit (" + model.Name + ")";
                tbAddress.Text = model.Address;
                tbEmail.Text = model.Email;
                tbFax.Text = model.Fax;
                tbName.Text = model.Name;
                tbNotes.Text = model.Notes;
                tbPhone.Text = model.Phone;
                //tbSalesperson.Text = model.SalesPerson;
                tbWebsite.Text = model.Website;
                chkUse.Checked = model.Use;
                _supplierId = model.Id;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var model = new UserModel
            {
                Address = tbAddress.Text,
                Name = tbName.Text,
                Email = tbEmail.Text,
                Phone = tbPhone.Text,
                Fax = tbFax.Text,
                IsCompany = true,
                Id = _supplierId,
                Notes = tbNotes.Text,
                //RegisteredAt = cbtbRegisteredDate.Value,
               // SalesPerson = tbSalesperson.Text,
                Website = tbWebsite.Text,
                Use = chkUse.Checked,
                UserType = _userType.ToString(),
            };
            _supplierService.AddOrUpdateSupplier(model);
            this.Close();
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
