using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Forms.Common;
using IMS.Forms.Common.Validations;
using IMS.Forms.Purchases.Order;
using Service.Core.Business;
using Service.Core.Inventory;
using Service.Core.Purchases.PurchaseOrders;
using Service.Core.Suppliers;
using ViewModel.Core.Purchases;

namespace IMS.Forms.Purchases
{
    public partial class PurchaseOrderCreateForm : Form
    {
        private readonly ISupplierService _supplierService;
        private readonly IBusinessService _businessService;
        private readonly IPurchaseService _purchaseService;
        private readonly IInventoryService _inventoryService;

        private RequiredFieldValidator _requiredFieldValidator;

        private PurchaseOrderModel _purchaseOrderModel;
        private int _purchaseOrderId;

        public PurchaseOrderCreateForm(ISupplierService supplierService,
            IBusinessService businessService,
            IInventoryService inventoryService,
            IPurchaseService purchaseService) /* It's a only way I know :D */
        {
            this._businessService = businessService;
            this._supplierService = supplierService;
            this._purchaseService = purchaseService;
            this._inventoryService = inventoryService;

            InitializeComponent();

            this.Load += PurchaseOrderForm_Load;
        }

        private void PurchaseOrderForm_Load(object sender, EventArgs e)
        {
            // initial data
            tbName.Text = "Order - " + DateTime.Now.ToString("ddd, dd MMM yyyy");
            numLotNumber.Value = _purchaseService.GetNextLotNumber();


            PopulateSupplierCombo();
            PopulateWarehouseCombo();

            InitializeValidation();


        }

        private void InitializeValidation()
        {
            var controls = new Control[]
            {
                tbName, tbOrderNumber, cbSupplier, cbWarehouse
            };
            _requiredFieldValidator = new RequiredFieldValidator(errorProvider, controls);

        }

        #region Populate Functions

        private void PopulateSupplierCombo()
        {
            var suppliers = _supplierService.GetSupplierListForCombo();
            cbSupplier.DataSource = suppliers;
            cbSupplier.DisplayMember = "Name";
            cbSupplier.ValueMember = "Id";
        }

        private void PopulateWarehouseCombo()
        {
            var warehouses = _inventoryService.GetWarehouseList();
            cbWarehouse.DataSource = warehouses;
            cbWarehouse.DisplayMember = "Name";
            cbWarehouse.ValueMember = "Id";

        }

        public void SetDataForEdit(int purchaseOrderId)
        {
            var po = _purchaseService.GetPurchaseOrder(purchaseOrderId);
            SetDataForEdit(po);
        }

        public void SetDataForEdit(PurchaseOrderModel model)
        {
            _purchaseOrderModel = model;
            if (model != null)
            {
                // change button
                btnSave.Text = "Save";
                btnSave.Width = btnCancel.Width;
                this.Text = "Edit Purchase Order";

                _purchaseOrderId = model.Id;
                tbName.Text = model.Name;
                tbNotes.Text = model.Note;
                tbOrderNumber.Text = model.OrderNumber;
                tbSupplierInvoice.Text = model.SupplierInvoice;
                cbSupplier.SelectedValue = model.SupplierId;
                cbWarehouse.SelectedValue = model.WarehouseId;
                dtExpectedDate.Value = model.ExpectedDate;
                numLotNumber.Value = model.LotNumber;
            }
        }

        #endregion


        private void btnAddItem_Click(object sender, EventArgs e)
        {
            var addItemForm = new PurchaseOrderAddItemForm();
            addItemForm.ShowDialog();
        }

        private void btnSavePurchaseOrder_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (!_requiredFieldValidator.IsValid())
            {
                PopupMessage.ShowMissingInputsMessage();
                this.Focus();
                return;
            }
            var purchaseOrderModel = new PurchaseOrderModel()
            {
                Id = _purchaseOrderId, //_purchaseOrderModel == null ? 0 : _purchaseOrderModel.Id,
                LotNumber = (int)numLotNumber.Value,
                Name = tbName.Text,
                Note = tbNotes.Text,
                OrderNumber = tbOrderNumber.Text,
                SupplierId = int.Parse(cbSupplier.SelectedValue.ToString()),
                SupplierInvoice = tbSupplierInvoice.Text,
                WarehouseId = int.Parse(cbWarehouse.SelectedValue.ToString()),
                ExpectedDate = dtExpectedDate.Value,
                // don't add other properties which are set individually, e.g. receivedAt, etc.
            };
            _purchaseService.SavePurchaseOrder(purchaseOrderModel);
            // redirect to PO detail page
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
