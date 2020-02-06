using IMS.Forms.Common;
using Service.Core.Business;
using Service.Core.Inventory;
using Service.Core.Inventory.Units;
using Service.Core.Orders;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ViewModel.Core.Common;
using ViewModel.Core.Inventory;
using ViewModel.Core.Orders;
using ViewModel.Enums;

namespace IMS.Forms.Inventory.Units.Actions
{
    public partial class InventoryAdjustmentForm : Form
    {
        private readonly IInventoryService _inventoryService;
        private readonly IInventoryUnitService _inventoryUnitService;
        private readonly IBusinessService _businessService;
        private readonly IOrderService _orderService;

        //private bool _isCellDirty;

        // ---- Purchase Order ---- //
        private int _purchaseOrderId;
        private OrderModel _purchaseOrderModel;
        private MovementTypeEnum _adjustmentType;
        private List<InventoryUnitModel> _selectedInventoryUnits;

        public InventoryAdjustmentForm(IInventoryService inventoryService,
            IBusinessService businessService,
            IOrderService purchaseService,
            IInventoryUnitService inventoryUnitService)
        {
            _inventoryService = inventoryService;
            _businessService = businessService;
            _orderService = purchaseService;
            _inventoryUnitService = inventoryUnitService;

            InitializeComponent();

            dgvInventoryUnit.InitializeGridViewControls(_inventoryService);

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
                case MovementTypeEnum.DirectIssueInventoryUnit:
                case MovementTypeEnum.DirectIssueAny:
                    adjustmentList = _inventoryService.GetNegativeAdjustmentCodeListForCombo();
                    cbAdjustmentCode.DataSource = adjustmentList;
                    cbAdjustmentCode.ValueMember = "Id";
                    cbAdjustmentCode.DisplayMember = "Name";
                    break;
                case MovementTypeEnum.DirectReceive:
                    adjustmentList = _inventoryService.GetPositiveAdjustmentCodeListForCombo();
                    cbAdjustmentCode.DataSource = adjustmentList;
                    cbAdjustmentCode.ValueMember = "Id";
                    cbAdjustmentCode.DisplayMember = "Name";
                    break;
                case MovementTypeEnum.SOIssue:
                    adjustmentList = _inventoryService.GetNegativeAdjustmentCodeListForCombo();
                    cbAdjustmentCode.Enabled = false;
                    break;
                case MovementTypeEnum.POReceive:
                    adjustmentList = _inventoryService.GetPositiveAdjustmentCodeListForCombo();
                    cbAdjustmentCode.Enabled = false;
                    break;
                default:
                    adjustmentList = new List<IdNamePair>();
                    break;
            }
            
        }

        #endregion


        public void SetData(MovementTypeEnum adjType, int orderId = 0, List<InventoryUnitModel> selectedInventoryUnits = null)
        {
            _adjustmentType = adjType;
            switch (adjType)
            {
                case MovementTypeEnum.DirectIssueInventoryUnit:
                    _selectedInventoryUnits = selectedInventoryUnits;
                    this.Text = "Direct Issue";
                    btnSave.Text = "Issue";
                    dgvInventoryUnit.DesignForDirectIssueInventoryUnit();
                    if (selectedInventoryUnits != null)
                    {
                        dgvInventoryUnit.DataSource = selectedInventoryUnits;
                    }
                    break;
                case MovementTypeEnum.DirectIssueAny:
                    this.Text = "Direct Issue";
                    btnSave.Text = "Issue";
                    dgvInventoryUnit.DesignForDirectIssueAny();
                    break;
                case MovementTypeEnum.SOIssue:
                    _purchaseOrderId = orderId;
                    dgvInventoryUnit.DesignForPurchaseOrderReceive();
                    if (orderId > 0)
                    {
                        var model = _orderService.GetOrderForDetailView(orderId); //OrderTypeEnum.Purchase, 
                        SetDataForOrder(model);
                    }
                    btnSave.Text = "Issue";
                    break;
                case MovementTypeEnum.DirectReceive:
                    dgvInventoryUnit.DesignForDirectReceive();
                    break;
                case MovementTypeEnum.POReceive:
                    _purchaseOrderId = orderId;
                    dgvInventoryUnit.DesignForPurchaseOrderReceive();
                    if (orderId > 0)
                    {
                        var model = _orderService.GetOrderForDetailView(orderId); //OrderTypeEnum.Purchase, 
                        SetDataForOrder(model);
                    }
                    break;
                case MovementTypeEnum.DirectMove:
                    pnlWarehouse.Visible = true;
                    pnlAdjustmentCode.Visible = false;
                    PopulateWarehouseCombo();
                    _selectedInventoryUnits = selectedInventoryUnits;
                    this.Text = "Direct Transfer";
                    btnSave.Text = "Transfer";
                    dgvInventoryUnit.DesignForDirectMove();
                    if (selectedInventoryUnits != null)
                    {
                        dgvInventoryUnit.DataSource = selectedInventoryUnits;
                    }
                    break;
            }
        }

        // private cause we need to handle 3 cases and shouldn't expose for PurchaseOrder only
        private void SetDataForOrder(OrderModel model)
        {
           
            _purchaseOrderModel = model;
            if (model != null)
            {
                var orderType = Enum.Parse(typeof(OrderTypeEnum), model.OrderType);
                switch (orderType)
                {
                    case OrderTypeEnum.Purchase:
                        this.Text = "Receive Against PO " + model.ReferenceNumber;
                        cbAdjustmentCode.SelectedText = "PO Receive";
                        break;
                    case OrderTypeEnum.Sale:
                        this.Text = "Issue Against SO " + model.ReferenceNumber;
                        cbAdjustmentCode.Text = "SO Issue";
                        break;
                    case OrderTypeEnum.Move:
                        this.Text = "Move Against TO " + model.ReferenceNumber;
                        cbAdjustmentCode.Text = "TO Move";
                        break;
                }
                // populate
                dgvInventoryUnit.SetSelectable(false);
                dgvInventoryUnit.AutoGenerateColumns = false;
                dgvInventoryUnit.DataSource = _orderService.GetInventoryUnitsOfPurchaseOrdeItems(model.OrderItems);

                foreach (DataGridViewColumn column in dgvInventoryUnit.Columns)
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
            List<InventoryUnitModel> list = null;
            var msg = string.Empty;
            var actionForMsg = string.Empty;
            DialogResult dialogResult = DialogResult.None;
            var adjustmentCode = "";
            if (cbAdjustmentCode.SelectedItem == null)
                adjustmentCode = cbAdjustmentCode.Text;
            else
                adjustmentCode = ((IdNamePair)cbAdjustmentCode.SelectedItem).Name;

            switch (_adjustmentType)
            {
                case MovementTypeEnum.DirectIssueInventoryUnit:
                    actionForMsg = "Issued";

                    list = dgvInventoryUnit.GetItems();

                    if (list != null)
                    {
                        if (list.Count == 0)
                        {
                            msg = "At least one item expected to issue";
                        }
                        else
                        {
                            dialogResult = MessageBox.Show(this, "Are you sure to issue the selected items?", "Issue?", MessageBoxButtons.YesNoCancel);
                            if (dialogResult.Equals(DialogResult.Yes))
                            {
                                msg = _inventoryUnitService.SaveDirectIssueInventoryUnit(list, adjustmentCode);
                            }
                        }
                    }
                    break;
                case MovementTypeEnum.DirectIssueAny:
                    actionForMsg = "Issued";
                    var ignoreList = new List<DataGridViewColumn>
                    {
                        dgvInventoryUnit.colLotNumber
                    };
                    list = dgvInventoryUnit.GetItems(ignoreList);

                    if (list != null)
                    {
                        if (list.Count == 0)
                        {
                            msg = "At least one item expected to issue";
                        }
                        else
                        {
                            dialogResult = MessageBox.Show(this, "Are you sure to issue the selected items?", "Issue?", MessageBoxButtons.YesNoCancel);
                            if (dialogResult.Equals(DialogResult.Yes))
                            {
                                msg = _inventoryUnitService.SaveDirectIssueAny(list, adjustmentCode);
                            }
                        }
                    }
                    break;
                case MovementTypeEnum.DirectReceive:
                    actionForMsg = "Received";
                    list = dgvInventoryUnit.GetItems();
                    if (list != null)
                    {
                        if (list.Count == 0)
                        {
                            msg = "At least one item expected to receive";
                        }
                        else
                        {
                            msg = _inventoryUnitService.SaveDirectReceive(list, adjustmentCode);
                        }
                    }
                    break;
                case MovementTypeEnum.POReceive:
                    // PO Receive
                    actionForMsg = "Received";
                    dialogResult = MessageBox.Show(this, "Are you sure to receive items against this purchase order?", "Receive?", MessageBoxButtons.YesNoCancel);
                    if (dialogResult.Equals(DialogResult.Yes))
                    {
                        msg = _orderService.SetReceived(_purchaseOrderId);
                        this.Close();
                    }
                    break;
                case MovementTypeEnum.SOIssue:
                    // PO Receive
                    actionForMsg = "Issued";
                    dialogResult = MessageBox.Show(this, "Are you sure to issue items against this sales order?", "Issue?", MessageBoxButtons.YesNoCancel);
                    if (dialogResult.Equals(DialogResult.Yes))
                    {
                        msg = _orderService.SetIssued(_purchaseOrderId);
                        if(string.IsNullOrEmpty(msg))
                            this.Close();
                    }
                    break;
                case MovementTypeEnum.DirectMove:
                    actionForMsg = "Transferred";
                    var wIdVal = cbWarehouse.SelectedValue == null ? "" : cbWarehouse.SelectedValue.ToString();
                    var warehouseId = string.IsNullOrEmpty(wIdVal) ? 0 : int.Parse(wIdVal);
                    var warehouse = cbWarehouse.Text;

                    if (warehouseId == 0)
                    {
                        msg = "Please Select Warehouse first!";
                    }
                    else
                    {
                        list = dgvInventoryUnit.GetItems();
                        dialogResult = MessageBox.Show(this, "Are you sure to transfer selected items to the '" + warehouse + "' warehouse?", "Transfer?", MessageBoxButtons.YesNoCancel);
                        if (dialogResult.Equals(DialogResult.Yes))
                        {
                            msg = _inventoryUnitService.MoveInventoryUnits(warehouseId, list);
                        }
                    }

                    break;
            }
            if (dialogResult == DialogResult.Cancel || dialogResult == DialogResult.No)
            {
                return;
            }
            if (list == null)
                return;
            if (string.IsNullOrEmpty(msg))
            {
                PopupMessage.ShowSuccessMessage("Successfully " + actionForMsg + "!");
                this.Close();
            }
            else
            {
                PopupMessage.ShowErrorMessage(msg);
                this.Focus();
            }
        }

        private void PopulateWarehouseCombo()
        {
            var warehouses = _inventoryService.GetWarehouseListForCombo();
            warehouses.Insert(0, new IdNamePair(0, "--- Select ---"));
            cbWarehouse.DataSource = warehouses;
            cbWarehouse.ValueMember = "Id";
            cbWarehouse.DisplayMember = "Name";
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