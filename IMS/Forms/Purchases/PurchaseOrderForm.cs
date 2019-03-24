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
using IMS.Forms.Purchases.Order;
using Service.Core.Business;
using Service.Core.Inventory;
using Service.Core.Purchases.PurchaseOrders;
using Service.Core.Suppliers;
using ViewModel.Core.Purchases;

namespace IMS.Forms.Purchases
{
    public partial class PurchaseOrderForm : Form
    {
        private readonly ISupplierService _supplierService;
        private readonly IBusinessService _businessService;
        private readonly IPurchaseService _purchaseService;
        private readonly IInventoryService _inventoryService;
        public PurchaseOrderForm(ISupplierService supplierService,
            IBusinessService businessService,
            IInventoryService inventoryService,
            IPurchaseService purchaseService) /* It's a only way I know :D */
        {
            this._businessService = businessService;
            this._supplierService = supplierService;
            this._purchaseService = purchaseService;
            this._inventoryService = inventoryService;

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
            numLotNumber.Value = _purchaseService.GetNextLotNumber();

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            var addItemForm = new PurchaseOrderAddItemForm();
            addItemForm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // get the data
            var receiptNo = tbReceiptNo.Text;
            var lotNo = numLotNumber.Value;
            var orderDate = dtOrderDate.Value;
            var promisedDate = dtPromisedDate.Value;
            var note = tbNotes.Text;
            var items = new List<PurchaseItemModel>();
            var isValid = true;


            var supplierId = cbSupplier.SelectedValue;
            var warehouseId = cbWarehouse.SelectedValue;
            if (supplierId == null)
            {
                errorProvider.SetError(cbSupplier, "Required");
                isValid = false;
            }
            if (warehouseId == null)
            {
                errorProvider.SetError(cbWarehouse, "Required");
                isValid = false;
            }

            if (!isValid)
            {
                PopupMessage.ShowPopupMessage("Required fields missing", "Required fields are missing.", PopupMessageType.ERROR);
                return;
            }

            // extra row is added automatically; so get upto second last row only
            for (int r = 0; r < dgvItems.Rows.Count - 1; r++)
            {
                DataGridViewRow row = dgvItems.Rows[r];
                var sku = row.Cells[colSKU.Name].Value as string;
                var variant = _inventoryService.GetVariantById(sku);
                if (variant == null)
                {
                    row.ErrorText = "SKU not found!";
                    isValid = false;
                }
                else
                {
                    decimal quantity = 0;
                    decimal.TryParse(row.Cells[colQuantity.Name].Value as string, out quantity);
                    if (quantity <= 0)
                    {
                        row.ErrorText = "Quantity can't be zero or less";
                        isValid = false;
                    }
                    items.Add(new PurchaseItemModel
                    {
                        Id = 0,
                        Quantity = quantity,
                        TotalAmount = variant.LatestUnitSellPrice * quantity,
                        VariantId = variant.Id,
                        Rate = variant.LatestUnitSellPrice,
                    });
                }
            }
            if (!isValid)
            {
                PopupMessage.ShowPopupMessage("Invalid Items!", "The items you provided var not valid. Verify again!.", PopupMessageType.ERROR);
                return;
            }
            var supplierIdInt = int.Parse(supplierId.ToString());
            var purchase = new PurchaseModel()
            {
                Id = 0,
                CreatedAt = DateTime.Now,
                ReceiptNo = receiptNo,
                TotalAmount = 0,
                PurchaseItems = items,
                SupplierId = supplierIdInt,
            };
            var purchaseOrderModel = new PurchaseOrderModel()
            {
                Id = 0,
                SupplierId = supplierIdInt,
                WarehouseId = int.Parse(warehouseId.ToString()),
                ApprovedById = null,
                ClosedOn = null,
                CreatedById = null,
                LotNo = (int)lotNo,
                Note = note,
                OrderDate = orderDate,
                PromisedDate = promisedDate,
                RequestedDate = DateTime.Now,
                Purchase = purchase,

            };
            _purchaseService.SavePurchaseOrder(purchaseOrderModel);
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddFromDemand_Click(object sender, EventArgs e)
        {

        }



    }
}
