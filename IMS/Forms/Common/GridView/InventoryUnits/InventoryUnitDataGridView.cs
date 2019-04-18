using Service.Core.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Core.Inventory;

namespace IMS.Forms.Common.GridView.InventoryUnits
{
    //
    // Main : DataGridView
    // 
    public partial class InventoryUnitDataGridView : DataGridViewCustom
    {
        private IInventoryService _inventoryService;

        public InventoryUnitDataGridView()
        {
            // Initialize columns
            InitializeComponent();
        }

        public void InitializeGridViewControls(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
            //
            // Columns
            //
            InitializeColumns();
            // 
            // Events
            //
            InitializeEvents();
            //
            // Data Populate
            //
            InitializeComboBoxData();
            //
            // Validations
            //
            InitializeValidations();
        }


        public List<InventoryUnitModel> GetItems()
        {
            var isValid = true;
            var items = new List<InventoryUnitModel>();

            // extra row is added automatically; so get upto second last row only
            for (int r = 0; r < this.Rows.Count - 1; r++)
            {
                DataGridViewRow row = this.Rows[r];
                var sku = row.Cells[this.colSKU.Name].Value as string;
                var variant = _inventoryService.GetProductBySKU(sku);
                if (variant == null)
                {
                    row.ErrorText = "SKU not found!";
                    isValid = false;
                }
                else
                {
                    decimal quantity = 0;
                    var qtyVal = row.Cells[this.colUnitQuantity.Name].Value;
                    decimal.TryParse(qtyVal == null ? "0" : qtyVal.ToString(), out quantity);
                    if (quantity <= 0)
                    {
                        row.ErrorText = "Quantity can't be zero or less";
                        isValid = false;
                    }
                    decimal rate = 0;
                    var rateVal = row.Cells[this.colSupplyPrice.Name].Value;
                    decimal.TryParse(rateVal == null ? "0" : rateVal.ToString(), out rate);
                    if (rate <= 0)
                    {
                        row.ErrorText = "Rate can't be zero or less";
                        isValid = false;
                    }
                    var isHold = row.Cells[this.colIsHold.Index].Value;
                    var packageId = row.Cells[this.colPackageId.Index].Value;
                    var uomId = row.Cells[this.colUomId.Index].Value;
                    var warehouseId = row.Cells[this.colWarehouseId.Index].Value;
                    if (warehouseId == null)
                    {
                        isValid = false;
                    }
                    var lotNumber = row.Cells[this.colLotNumber.Index].Value;
                    if (lotNumber == null)
                    {
                        isValid = false;
                    }
                    var reference = row.Cells[this.colReceiveReference.Index].Value;
                    if (reference == null)
                        isValid = false;
                    var adjCode = row.Cells[this.colReceiveAdjustment.Index].Value;
                    if (adjCode == null)
                    {
                        isValid = false;
                    }
                    if (isValid)
                    {
                        items.Add(new InventoryUnitModel
                        {
                            Id = 0,
                            //PurchaseOrderId = _purchaseOrderId,
                            UnitQuantity = quantity,
                            TotalSupplyAmount = rate * quantity,
                            ProductId = variant.Id,
                            SupplyPrice = rate, //variant.LatestUnitSellPrice,
                            IsHold = isHold == null ? false : bool.Parse(isHold.ToString()),
                            WarehouseId = int.Parse(warehouseId.ToString()),//_purchaseOrder.WarehouseId,
                            ReceiveAdjustment = adjCode.ToString(),//"PO Receive", //_purchaseOrder.Status
                            ExpirationDate = null,
                            LotNumber = int.Parse(lotNumber.ToString()),//_purchaseOrder.LotNumber,
                            ProductionDate = null,
                            SupplierId = null,//_purchaseOrder.SupplierId,
                            ReceiveReceipt = reference.ToString(),//_purchaseOrder.OrderNumber,
                            PackageId = int.Parse(packageId.ToString()),
                            UomId = int.Parse(uomId.ToString()),
                            //ReceiveDate = dtReceiveDate.Value.ToShortDateString(),
                            //PackageQuantity = 
                        });
                    }
                }
            }
            if (!isValid)
            {
                PopupMessage.ShowPopupMessage("Invalid Items!", "The items you provided aar not valid. Verify again!.", PopupMessageType.ERROR);
                return null;
            }
            return items;
        }


    }
}
