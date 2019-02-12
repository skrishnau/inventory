using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Core.Customers;
using ViewModel.Core.Customers;

namespace IMS.Forms.Customer.Create
{
    public partial class CustomerCreate : Form
    {
        private readonly ICustomerService customerService;
        public CustomerCreate(ICustomerService customerService)
        {
            this.customerService = customerService;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var model = new CustomerModel
            {
                Address = tbAddress.Text,
                Email = tbEmail.Text,
                DOB = dpDob.Value,
                Name = tbName.Text,
                Phone = tbPhone.Text,
                Gender = cbGender.Text,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeliveryAddress = tbDeliveryAddress.Text,
                IsMarried = bool.Parse(cbIsMarried.Text)
            };

            customerService.AddOrUpdateCustomer(model);
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
