using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Core.Suppliers;
using Service.Listeners;
using ViewModel.Core.Suppliers;

namespace IMS.Forms.Inventory.Suppliers
{
    public partial class SupplierCreate : Form
    {
        private readonly ISupplierService _supplierService;
        private readonly IDatabaseChangeListener _listener;

        private int _supplierId;

        public SupplierCreate(ISupplierService supplierService, IDatabaseChangeListener listener)
        {
            this._supplierService = supplierService;
            _listener = listener;
            InitializeComponent();
            InitializeEvents();

            this.ActiveControl = tbName;
        }

        private void InitializeEvents()
        {
            btnSave.Click += btnSave_Click;
        }

        public void SetDataForEdit(int supplierId)
        {
            var supplier = _supplierService.GetSupplier(supplierId);
            SetDataForEdit(supplier);
        }

        public void SetDataForEdit(SupplierModel model)
        {
            if (model != null)
            {
                this.Text = "Supplier Edit (" + model.Name + ")";
                tbAddress.Text = model.Address;
                tbEmail.Text = model.Email;
                tbFax.Text = model.Fax;
                tbName.Text = model.Name;
                tbNotes.Text = model.Notes;
                tbPhone.Text = model.Phone;
                tbMyAccountNo.Text = model.MyCustomerAccount;
                tbSalesperson.Text = model.SalesPerson;
                tbWebsite.Text = model.Website;
                chkUse.Checked = model.Use;
                _supplierId = model.Id;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var model = new SupplierModel
            {
                Address = tbAddress.Text,
                Name = tbName.Text,
                Email = tbEmail.Text,
                Phone = tbPhone.Text,
                Fax = tbFax.Text,
                IsCompany = true,
                Id = _supplierId,
                MyCustomerAccount = tbMyAccountNo.Text,
                Notes = tbNotes.Text,
                //RegisteredAt = cbtbRegisteredDate.Value,
                SalesPerson = tbSalesperson.Text,
                Website = tbWebsite.Text,
                Use = chkUse.Checked,
            };
            _supplierService.AddOrUpdateSupplier(model);
            this.Close();
        }

    }
}
