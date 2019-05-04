using IMS.Forms.POS.Customers;
using Service.Core.Customers;
using Service.Core.Orders;
using Service.Listeners;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Inventory.Sales
{
    public partial class SaleOrderCreateForm : Form
    {
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;
        private readonly IDatabaseChangeListener _listener;

        private int _id;

        public SaleOrderCreateForm(
            ICustomerService customerService,
            IOrderService saleOrderService, 
            IDatabaseChangeListener listener)
        {
            _orderService = saleOrderService;
            _customerService = customerService;
            _listener = listener;

            InitializeComponent();

            this.Load += SaleOrderCreateForm_Load;
        }

        private void SaleOrderCreateForm_Load(object sender, EventArgs e)
        {
            PopulateCustomer();

            _listener.CustomerUpdated += _listener_CustomerUpdated;
        }

        private void _listener_CustomerUpdated(object sender, Service.DbEventArgs.BaseEventArgs<ViewModel.Core.Customers.CustomerModel> e)
        {
            PopulateCustomer();
            cbCustomer.SelectedValue = e.Model == null ? 0 : e.Model.Id;
        }

        private void PopulateCustomer()
        {
            var list = _customerService.GetCustomerListForCombo();
            list.Insert(0, new ViewModel.Core.Common.IdNamePair
            {
                Id = 0,
                Name = "----- Select -----"
            });
            cbCustomer.DataSource = list;
            cbCustomer.DisplayMember = "Name";
            cbCustomer.ValueMember = "Id";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            //var now = DateTime.Now;

            //var saleModel = new SaleModel
            //{
            //    Id = _id,
            //    Address = tbAddress.Text,
            //    BillNo = tbInvoiceNo.Text,
            //    CustomerName = cbCustomer.Text,//tbBillTo.Text,
            //    DateDate = now,
            //    MobileNo = tbMobileNo.Text,
            //    VatNo = tbVatNo.Text,
            //};

            ////saleModel.SaleItem.Add(new SaleItemModel)

            //_saleOrderService.AddUpdateSaleOrder(saleModel);
        }

        private void lblCustomer_DoubleClick(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var form = Program.container.GetInstance<CustomerCreateForm>();
                form.ShowDialog();
            }
        }
    }
}
