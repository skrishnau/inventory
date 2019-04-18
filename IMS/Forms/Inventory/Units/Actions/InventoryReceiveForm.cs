using IMS.Forms.Common;
using IMS.Forms.Common.GridView;
using Service.Core.Business;
using Service.Core.Inventory;
using Service.Core.Purchases.PurchaseOrders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Core.Inventory;
using ViewModel.Core.Purchases;

namespace IMS.Forms.Inventory.Units.Actions
{
    public partial class InventoryReceiveForm : Form
    {
        private readonly IInventoryService _inventoryService;
        private readonly IBusinessService _businessService;
        private readonly IPurchaseService _purchaseService;

        //private bool _isCellDirty;

        // ---- Purchase Order ---- //
        private int _purchaseOrderId;
        private PurchaseOrderModel _purchaseOrderModel;


        public InventoryReceiveForm(IInventoryService inventoryService, IBusinessService businessService, IPurchaseService purchaseService)
        {
            _inventoryService = inventoryService;
            _businessService = businessService;
            _purchaseService = purchaseService;

            InitializeComponent();
            InitializeGridView();


            this.Load += InventoryReceiveForm_Load;
        }


        private void InventoryReceiveForm_Load(object sender, EventArgs e)
        {
            PopulateAdjustmentCodeCombo();
        }

        #region Initialization Functions

        private void InitializeGridView()
        {
            dgvReceiveList.InitializeGridViewControls(_inventoryService);
        }

        #endregion



        #region Populating Functions

        private void PopulateAdjustmentCodeCombo()
        {
            var adjustmentList = _inventoryService.GetPositiveAdjustmentCodeListForCombo();
            cbAdjustmentCode.DataSource = adjustmentList;
            cbAdjustmentCode.ValueMember = "Id";
            cbAdjustmentCode.DisplayMember = "Name";
        }

        #endregion


        public void SetData(int purchaseOrderId)
        {
            var model = _purchaseService.GetPurchaseOrder(purchaseOrderId);
            SetData(model);
        }

        public void SetData(PurchaseOrderModel model)
        {
            _purchaseOrderId = model == null ? 0 : model.Id;
            _purchaseOrderModel = model;
            if (model != null)
            {
                dgvReceiveList.DesignForPurchaseOrderReceive();
                // populate
                this.Text = "Receive Against PO " + model.OrderNumber;
                cbAdjustmentCode.Text = "PO Receive";
                dgvReceiveList.AutoGenerateColumns = false;
                dgvReceiveList.DataSource = _purchaseService.GetInventoryUnitsOfPurchaseOrdeItems(model.PurchaseOrderItems);

                foreach (DataGridViewColumn column in dgvReceiveList.Columns)
                {
                    column.ReadOnly = true;
                }
            }
            else
            {
                dgvReceiveList.DesignForDirectReceive();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (_purchaseOrderId == 0)
            {
                var list = dgvReceiveList.GetItems();

                _inventoryService.SaveDirectReceive(list);

            }
            else
            {
                // PO Receive
                var dialogResult = MessageBox.Show(this, "Are you sure to receive items against this purchase order?", "Receive?", MessageBoxButtons.YesNo);
                if (dialogResult.Equals(DialogResult.Yes))
                {
                    var msg = _purchaseService.SetReceived(_purchaseOrderId);
                    if (string.IsNullOrEmpty(msg))
                    {
                        PopupMessage.ShowSuccessMessage("Successfully Received!");
                        this.Close();
                    }
                    else
                    {
                        PopupMessage.ShowErrorMessage(msg);
                        this.Focus();
                    }
                }
            }


        }

        
    }
}




//private List<InventoryUnitModel> GetItems()
//{
//    var isValid = true;
//    var items = new List<InventoryUnitModel>();

//    // extra row is added automatically; so get upto second last row only
//    for (int r = 0; r < dgvReceiveList.Rows.Count - 1; r++)
//    {
//        DataGridViewRow row = dgvReceiveList.Rows[r];
//        var sku = row.Cells[dgvReceiveList.colSKU.Name].Value as string;
//        var variant = _inventoryService.GetProductBySKU(sku);
//        if (variant == null)
//        {
//            row.ErrorText = "SKU not found!";
//            isValid = false;
//        }
//        else
//        {
//            decimal quantity = 0;
//            var qtyVal = row.Cells[dgvReceiveList.colUnitQuantity.Name].Value;
//            decimal.TryParse(qtyVal == null ? "0" : qtyVal.ToString(), out quantity);
//            if (quantity <= 0)
//            {
//                row.ErrorText = "Quantity can't be zero or less";
//                isValid = false;
//            }
//            decimal rate = 0;
//            var rateVal = row.Cells[dgvReceiveList.colSupplyPrice.Name].Value;
//            decimal.TryParse(rateVal == null ? "0" : rateVal.ToString(), out rate);
//            if (rate <= 0)
//            {
//                row.ErrorText = "Rate can't be zero or less";
//                isValid = false;
//            }
//            var isHold = row.Cells[dgvReceiveList.colIsHold.Index].Value;
//            var packageId = row.Cells[dgvReceiveList.colPackageId.Index].Value;
//            var uomId = row.Cells[dgvReceiveList.colUomId.Index].Value;
//            var warehouseId = row.Cells[dgvReceiveList.colWarehouse.Index].Value;
//            if(warehouseId == null)
//            {
//                isValid = false;
//            }
//            var lotNumber = row.Cells[dgvReceiveList.colLotNumber.Index].Value;
//            if(lotNumber == null)
//            {
//                isValid = false;
//            }
//            var reference = row.Cells[dgvReceiveList.colReceiveReference.Index].Value;
//            if (reference == null)
//                isValid = false;
//            if (isValid)
//            {
//                items.Add(new InventoryUnitModel
//                {
//                    Id = 0,
//                    //PurchaseOrderId = _purchaseOrderId,
//                    UnitQuantity = quantity,
//                    TotalSupplyAmount = rate * quantity,
//                    ProductId = variant.Id,
//                    SupplyPrice = rate, //variant.LatestUnitSellPrice,
//                    IsHold = isHold == null ? false : bool.Parse(isHold.ToString()),
//                    WarehouseId = int.Parse(warehouseId.ToString()),//_purchaseOrder.WarehouseId,
//                    ReceiveAdjustment = cbAdjustmentCode.SelectedText,//"PO Receive", //_purchaseOrder.Status
//                    ExpirationDate = null,
//                    LotNumber = int.Parse(lotNumber.ToString()),//_purchaseOrder.LotNumber,
//                    ProductionDate = null,
//                    SupplierId = null,//_purchaseOrder.SupplierId,
//                    ReceiveReceipt = reference.ToString(),//_purchaseOrder.OrderNumber,
//                    PackageId = int.Parse(packageId.ToString()),
//                    UomId = int.Parse(uomId.ToString()),
//                    ReceiveDate = dtReceiveDate.Value.ToShortDateString(),
//                    //PackageQuantity = 
//                });
//            }
//        }
//    }
//    if (!isValid)
//    {
//        PopupMessage.ShowPopupMessage("Invalid Items!", "The items you provided aar not valid. Verify again!.", PopupMessageType.ERROR);
//        return null;
//    }
//    return items;
//}