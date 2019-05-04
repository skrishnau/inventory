using System;
using System.Windows.Forms;
using IMS.Forms.Common.Display;
using Service.Core.Customers;
using SimpleInjector.Lifestyles;

namespace IMS.Forms.POS.Customers
{
    public partial class CustomerListUC : UserControl
    {
        private readonly ICustomerService customerService;

        public CustomerListUC(ICustomerService customerService)
        {
            this.customerService = customerService;

            InitializeComponent();

            this.Load += CustomerListUC_Load;



        }

        private void CustomerListUC_Load(object sender, EventArgs e)
        {
            InitializeHeader();

            Populate();
        }

        private void InitializeHeader()
        {
            var _header = HeaderTemplate.Instance;
            _header.lblHeading.Text = "Customers";
            _header.btnNew.Visible = true;
            _header.btnNew.Click += btnAddCustomer_Click;
            _header.btnEdit.Visible = true;
            _header.btnEdit.Click += BtnEdit_Click;
            _header.btnDelete.Visible = true;
            _header.btnDelete.Click += BtnDelete_Click; ;

            this.Controls.Add(_header);
            _header.SendToBack();
        }


        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            ShowAddEditDialog(false);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            ShowAddEditDialog(true);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void ShowAddEditDialog(bool isEditMode)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var customerCreate = Program.container.GetInstance<CustomerCreateForm>();
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
