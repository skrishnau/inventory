using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Core.Customers;
using SimpleInjector.Lifestyles;
using IMS.Forms.Customer.Create;

namespace IMS.Forms.Customer
{
    public partial class CustomerUC : UserControl
    {
        private readonly ICustomerService customerService;

        public CustomerUC(ICustomerService customerService)
        {
            this.customerService = customerService;
            InitializeComponent();
            Populate();

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var customerCreate = Program.container.GetInstance<CustomerCreate>();
                customerCreate.ShowDialog();
                Populate();
            }
        }

        private void Populate()
        {
            dataGridView1.AutoGenerateColumns = false;
            var customers = customerService.GetCustomerList();
            dataGridView1.DataSource = customers;
        }
    }
}
