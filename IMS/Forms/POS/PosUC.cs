using System;
using System.Windows.Forms;
using IMS.Forms.Common.Display;
using IMS.Forms.Sales;
using SimpleInjector.Lifestyles;
using IMS.Forms.POS.Customers;
using IMS.Forms.POS.Counters;
using IMS.Forms.Business.Create;

namespace IMS.Forms.POS
{
    public partial class PosUC : UserControl
    {
        public static readonly string MODULE_NAME = "POS";
        private BodyTemplate _bodyTemplate;
        private PosMenuBar _menubar;

        public PosUC(PosMenuBar menubar)
        {
            _menubar = menubar;

            InitializeComponent();

            InitializeRootTemplate();

            InitializeMenuBarButtonEvents();
        }

        private void InitializeRootTemplate()
        {
            // body
            _bodyTemplate = new BodyTemplate();
            _bodyTemplate.Dock = DockStyle.Fill;
            this.Controls.Add(_bodyTemplate);
            // heading
            _bodyTemplate.lblHeading.Text = MODULE_NAME;
            // menubar template
            _bodyTemplate.pnlMenuBar.Controls.Add(_menubar);
        }

        private void InitializeMenuBarButtonEvents()
        {
            // order
            _menubar.btnOrderList.Click += BtnOrderList_Click;
            _menubar.btnNewOrder.Click += BtnNewOrder_Click;
            // direct
            _menubar.btnDirectSell.Click += BtnDirectSell_Click;
            // customer
            _menubar.btnCustomerList.Click += BtnCustomerList_Click;
            _menubar.btnNewCustomer.Click += BtnNewCustomer_Click;
            // counter
            _menubar.btnCounterList.Click += BtnCounterList_Click;
            _menubar.btnNewCounter.Click += BtnNewCounter_Click;
        }

      



        #region Orders

        private void BtnOrderList_Click(object sender, EventArgs e)
        {
            _bodyTemplate.pnlBody.Controls.Clear();
            var saleUc = Program.container.GetInstance<SaleUC>();
            saleUc.Dock = DockStyle.Fill;
            _bodyTemplate.pnlBody.Controls.Add(saleUc);
            // set selection
            _menubar.ClearSelection();
            _menubar.btnOrderList.FlatStyle = FlatStyle.Flat;

        }

        private void BtnNewOrder_Click(object sender, EventArgs e)
        {

        }

        #endregion


        private void BtnDirectSell_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var directSaleForm = Program.container.GetInstance<DirectSaleForm>();
                directSaleForm.ShowDialog();
            }
        }


        #region Customers

        private void BtnCustomerList_Click(object sender, EventArgs e)
        {
            _bodyTemplate.pnlBody.Controls.Clear();
            var customerUC = Program.container.GetInstance<CustomerListUC>();
            customerUC.Dock = DockStyle.Fill;
            _bodyTemplate.pnlBody.Controls.Add(customerUC);
            // set selection
            _menubar.ClearSelection();
            _menubar.btnCustomerList.FlatStyle = FlatStyle.Flat;
        }

        private void BtnNewCustomer_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var customerCreate = Program.container.GetInstance<CustomerCreate>();
                customerCreate.ShowDialog();
                //Populate();
            }
        }

        #endregion


        #region Counters

        private void BtnCounterList_Click(object sender, EventArgs e)
        {
            _bodyTemplate.pnlBody.Controls.Clear();
            var counterListUC = Program.container.GetInstance<CounterListUC>();
            counterListUC.Dock = DockStyle.Fill;
            _bodyTemplate.pnlBody.Controls.Add(counterListUC);
            // set selection
            _menubar.ClearSelection();
            _menubar.btnCounterList.FlatStyle = FlatStyle.Flat;

        }

        private void BtnNewCounter_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var counterCreate = Program.container.GetInstance<CounterCreate>();
                counterCreate.ShowInTaskbar = false;
                counterCreate.ShowDialog();
                // PopulateCounterData();
            }
        }

        #endregion
    }
}
