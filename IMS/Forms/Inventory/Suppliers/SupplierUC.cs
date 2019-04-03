using System;
using System.Windows.Forms;
using Service.Core.Suppliers;
using SimpleInjector.Lifestyles;
using IMS.Forms.Common.Display;

namespace IMS.Forms.Inventory.Suppliers
{
    public partial class SupplierUC : UserControl
    {
        private readonly ISupplierService supplierService;

        public SupplierUC(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
            InitializeComponent();
            InitializeHeader();

            Populate();
        }

        private void InitializeHeader()
        {
            var _header = SubHeadingTemplate.Instance;
            _header.btnNew.Visible = true;
            _header.btnNew.Click += BtnAddSupplier_Click;
            this.Controls.Add(_header);
            _header.SendToBack();

            _header.lblHeading.Text = "Suppliers";
        }

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
