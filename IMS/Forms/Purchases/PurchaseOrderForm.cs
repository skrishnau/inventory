using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Forms.Purchases.Order;
using Service.Core.Business;
using Service.Core.Purchases.PurchaseOrders;
using Service.Core.Suppliers;

namespace IMS.Forms.Purchases
{
    public partial class PurchaseOrderForm : Form
    {
        private readonly ISupplierService _supplierService;
        private readonly IBusinessService _businessService;
        private readonly IPurchaseOrderService _purchaseOrderService;
        public PurchaseOrderForm(ISupplierService supplierService, 
            IBusinessService  businessService,
            IPurchaseOrderService purchaseOrderService) /* It's a only way I know :D */
        {
            this._businessService = businessService;
            this._supplierService = supplierService;
            this._purchaseOrderService = purchaseOrderService;

            InitializeComponent();
            PopulateSupplierCombo();
            PopulateWarehouseCombo();
            PopulateLotNumber();
        }

        private void PopulateSupplierCombo()
        {
            var suppliers = _supplierService.GetSupplierList();
            cbSupplier.DataSource = suppliers;
            cbSupplier.DisplayMember = "Name";
            cbSupplier.ValueMember = "Id";
        }

        private void PopulateWarehouseCombo()
        {
            var warehouses = _businessService.GetWarehouseList();
            cbWarehouse.DataSource = warehouses;
            cbWarehouse.DisplayMember = "Code";
            cbWarehouse.ValueMember = "Id";

        }

        private void PopulateLotNumber()
        {
            numLotNumber.Value= _purchaseOrderService.GetNextLotNumber();

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            var addItemForm = new PurchaseOrderAddItemForm();
            addItemForm.ShowDialog();
        }

        private void btnAddFromDemand_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

       
    }
}
