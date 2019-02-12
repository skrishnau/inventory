using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Forms.Suppliers.Create;
using Service.Core.Sales.SalesOrders;
using Service.Core.LDAP;
using Service.Core.Suppliers;
using SimpleInjector.Lifestyles;

namespace IMS.Forms.Suppliers
{
    public partial class SupplierUC : UserControl
    {

        // ISalesOrderService salesOrderService;
        //ILDapService ldapService;
        private readonly ISupplierService supplierService;

        public SupplierUC(ISupplierService supplierService)
        {

            this.supplierService = supplierService;
            //ldapService = new OpenLDap();

            InitializeComponent();
            Populate();

            // salesOrderService = new SalesOrderService();
        }

       /* public void InitializeEvents()
        {
            btnAddSupplier.Click += BtnAddSupplier_Click;
            ldapService.AddUser();
        }
        */


        private void BtnAddSupplier_Click(object sender, EventArgs e)
        {

            using(AsyncScopedLifestyle.BeginScope(Program.container))
            {

                var supplierCreate = Program.container.GetInstance<SupplierCreate>();// (supplier);
                supplierCreate.ShowDialog();
                Populate();

                
            }
            
        }

        private void Populate()
        {
            dataGridView1.AutoGenerateColumns = false;
            var supplier = supplierService.GetSupplierList();
            dataGridView1.DataSource = supplier;
        }
    }
}
