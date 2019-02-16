using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Core.Business;
using Service.Core.Suppliers;

namespace IMS.Forms.Purchases
{
    public partial class PurchaseOrderForm : Form
    {
        private readonly ISupplierService supplierService;
        private readonly IBusinessService businessService;
        public PurchaseOrderForm(ISupplierService supplierService, IBusinessService  businessService) /* It's a only way I know :D */
        {
            this.businessService = businessService;
            this.supplierService = supplierService;
            InitializeComponent();
            PopulateSupplierCombo();
            PopulateWarehouseCombo();
        }

        public void PopulateSupplierCombo()
        {
            var suppliers = supplierService.GetSupplierList();
            cbSupplier.DataSource = suppliers;
            cbSupplier.DisplayMember = "Name";
            cbSupplier.ValueMember = "Id";
        }

        public void PopulateWarehouseCombo()
        {
            var warehouses = businessService.GetWarehouseList();
            cbWarehouse.DataSource = warehouses;
            cbWarehouse.DisplayMember = "Code";
            cbWarehouse.ValueMember = "Id";

        }
    }
}
