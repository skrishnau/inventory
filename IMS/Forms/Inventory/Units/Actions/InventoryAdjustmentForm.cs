using IMS.Forms.Common;
using IMS.Forms.Common.GridView;
using Service.Core.Business;
using Service.Core.Inventory;
using Service.Core.Purchases.PurchaseOrders;
using Service.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Core.Common;
using ViewModel.Core.Inventory;
using ViewModel.Core.Purchases;

namespace IMS.Forms.Inventory.Units.Actions
{
    public partial class InventoryAdjustmentForm : Form
    {
        private readonly IInventoryService _inventoryService;
        private readonly IBusinessService _businessService;
        private readonly IPurchaseService _purchaseService;

        //private bool _isCellDirty;

        // ---- Purchase Order ---- //
        private int _purchaseOrderId;
        private PurchaseOrderModel _purchaseOrderModel;

        private AdjustmentTypeEnum _adjustmentType;
        private List<InventoryUnitModel> _selectedInventoryUnits;

        public InventoryAdjustmentForm(IInventoryService inventoryService, IBusinessService businessService, IPurchaseService purchaseService)
        {
            _inventoryService = inventoryService;
            _businessService = businessService;
            _purchaseService = purchaseService;

            InitializeComponent();

            dgvReceiveList.InitializeGridViewControls(_inventoryService);

            this.Load += InventoryReceiveForm_Load;
        }


        private void InventoryReceiveForm_Load(object sender, EventArgs e)
        {
            PopulateAdjustmentCodeCombo();
        }


        #region Populating Functions

        private void PopulateAdjustmentCodeCombo()
        {
            List<IdNamePair> adjustmentList;
            switch (_adjustmentType)
            {
                case AdjustmentTypeEnum.DirectIssue:
                    adjustmentList = _inventoryService.GetNegativeAdjustmentCodeListForCombo();
                    break;
                case AdjustmentTypeEnum.DirectReceive:
                    adjustmentList = _inventoryService.GetPositiveAdjustmentCodeListForCombo();
                    break;
                case AdjustmentTypeEnum.POReceive:
                    adjustmentList = _inventoryService.GetPositiveAdjustmentCodeListForCombo();
                    cbAdjustmentCode.Enabled = false;
                    break;
                default:
                    adjustmentList = new List<IdNamePair>();
                    break;
            }
            cbAdjustmentCode.DataSource = adjustmentList;
            cbAdjustmentCode.ValueMember = "Id";
            cbAdjustmentCode.DisplayMember = "Name";
        }

        #endregion


        public void SetData(AdjustmentTypeEnum adjType, int purchaseOrderId = 0, List<InventoryUnitModel> selectedInventoryUnits = null)
        {
            _adjustmentType = adjType;
            switch (adjType)
            {
                case AdjustmentTypeEnum.DirectIssue:
                    _selectedInventoryUnits = selectedInventoryUnits;
                    this.Text = "Direct Issue";
                    btnSave.Text = "Issue";
                    dgvReceiveList.DesignForDirectIssue();
                    if (selectedInventoryUnits != null)
                    {
                        dgvReceiveList.DataSource = selectedInventoryUnits;
                    }
                    break;
                case AdjustmentTypeEnum.DirectReceive:
                    dgvReceiveList.DesignForDirectReceive();
                    break;
                case AdjustmentTypeEnum.POReceive:
                    _purchaseOrderId = purchaseOrderId;
                    dgvReceiveList.DesignForPurchaseOrderReceive();
                    if (purchaseOrderId > 0)
                    {
                        var model = _purchaseService.GetPurchaseOrder(purchaseOrderId);
                        SetDataForPurchaseOrder(model);
                    }
                    break;
            }
        }

        // private cause we need to handle 3 cases and shouldn't expose for PurchaseOrder only
        private void SetDataForPurchaseOrder(PurchaseOrderModel model)
        {
            _purchaseOrderModel = model;
            if (model != null)
            {
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            List<InventoryUnitModel> list;
            var msg = string.Empty;
            var actionForMsg = string.Empty;
            switch (_adjustmentType)
            {
                case AdjustmentTypeEnum.DirectIssue:
                    actionForMsg = "Issued";
                    
                    list = dgvReceiveList.GetItems();
                    
                    if (list != null)
                    {
                        if (list.Count == 0)
                        {
                            PopupMessage.ShowErrorMessage("At least one item expected to receive");
                            this.Focus();
                        }
                        else
                        {
                            msg = _inventoryService.SaveDirectIssue(list);
                        }
                    }
                    break;
                case AdjustmentTypeEnum.DirectReceive:
                    actionForMsg = "Received";
                    list = dgvReceiveList.GetItems();
                    if (list != null)
                    {
                        if (list.Count == 0)
                        {
                            PopupMessage.ShowErrorMessage("At least one item expected to receive");
                            this.Focus();
                        }
                        else
                        {
                            msg = _inventoryService.SaveDirectReceive(list);
                        }
                    }
                    break;
                case AdjustmentTypeEnum.POReceive:
                    // PO Receive
                    actionForMsg = "Received";
                    var dialogResult = MessageBox.Show(this, "Are you sure to receive items against this purchase order?", "Receive?", MessageBoxButtons.YesNo);
                    if (dialogResult.Equals(DialogResult.Yes))
                    {
                        msg = _purchaseService.SetReceived(_purchaseOrderId);
                        
                    }
                    break;
            }
            if (string.IsNullOrEmpty(msg))
            {
                PopupMessage.ShowSuccessMessage("Successfully "+actionForMsg+"!");
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