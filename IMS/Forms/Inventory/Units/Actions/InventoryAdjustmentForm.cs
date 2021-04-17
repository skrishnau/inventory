using IMS.Forms.Common;
using IMS.Forms.Common.GridView;
using Service.Core.Business;
using Service.Core.Inventory;
using Service.Core.Inventory.Units;
using Service.Core.Orders;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        private readonly IProductService _productService;
        private readonly IInventoryUnitService _inventoryUnitService;
        private readonly IBusinessService _businessService;
        private readonly IOrderService _orderService;

        //private bool _isCellDirty;

        // ---- Purchase Order ---- //
        private int _orderId;
        private OrderModel _orderModel;
        private MovementTypeEnum _adjustmentType;
        private List<InventoryUnitModel> _selectedInventoryUnits;

        public InventoryAdjustmentForm(IInventoryService inventoryService,
            IProductService productService,
            IBusinessService businessService,
            IOrderService purchaseService,
            IInventoryUnitService inventoryUnitService)
        {
            _inventoryService = inventoryService;
            _productService = productService;
            _businessService = businessService;
            _orderService = purchaseService;
            _inventoryUnitService = inventoryUnitService;

            InitializeComponent();

            dgvInventoryUnit.InitializeGridViewControls(_inventoryService, _productService);

            this.Load += InventoryReceiveForm_Load;
        }


        private void InventoryReceiveForm_Load(object sender, EventArgs e)
        {
            dtReceivedDate.SetValue(DateTime.Now);

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
                    cbAdjustmentCode.SelectedItem = adjustmentList.FirstOrDefault(x => x.Name == "Direct Receive");
                    break;
                case MovementTypeEnum.SOIssue:
                case MovementTypeEnum.SOIssueEditItems:
                    adjustmentList = _inventoryService.GetNegativeAdjustmentCodeListForCombo();
                    cbAdjustmentCode.Enabled = false;
                    break;
                case MovementTypeEnum.POReceive:
                case MovementTypeEnum.POReceiveEditItems:
                    adjustmentList = _inventoryService.GetPositiveAdjustmentCodeListForCombo();
                    cbAdjustmentCode.Enabled = false;
                    break;
                default:
                    adjustmentList = new List<IdNamePair>();
                    break;
            }

        }

        #endregion


        public void SetData(MovementTypeEnum movementType, int orderId = 0, List<InventoryUnitModel> selectedInventoryUnits = null)
        {
            _adjustmentType = movementType;
            dgvInventoryUnit.MovementType = movementType;
            switch (movementType)
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
                    _orderId = orderId;
                    dgvInventoryUnit.DesignForOrder(false);
                    if (orderId > 0)
                    {
                        var model = _orderService.GetOrderForDetailView(orderId); //OrderTypeEnum.Purchase, 
                        SetDataForOrder(model, false);
                    }
                    btnSave.Text = "Issue";
                    break;
                case MovementTypeEnum.SOIssueEditItems:
                    _orderId = orderId;
                    dgvInventoryUnit.DesignForOrder(true);
                    if (orderId > 0)
                    {
                        var model = _orderService.GetOrderForDetailView(orderId); //OrderTypeEnum.Purchase, 
                        SetDataForOrder(model, true);
                    }
                    btnSave.Text = "Save Items";
                    break;
                case MovementTypeEnum.DirectReceive:
                    dgvInventoryUnit.DesignForDirectReceive();
                    break;
                case MovementTypeEnum.POReceive:
                    _orderId = orderId;
                    dgvInventoryUnit.DesignForOrder(false);
                    if (orderId > 0)
                    {
                        var model = _orderService.GetOrderForDetailView(orderId); //OrderTypeEnum.Purchase, 
                        SetDataForOrder(model, false);
                    }
                    break;
                case MovementTypeEnum.POReceiveEditItems:
                    _orderId = orderId;
                    dgvInventoryUnit.DesignForOrder(true);
                    if (orderId > 0)
                    {
                        var model = _orderService.GetOrderForDetailView(orderId); //OrderTypeEnum.Purchase, 
                        SetDataForOrder(model, true);
                    }
                    btnSave.Text = "Save Items";
                    break;
                case MovementTypeEnum.DirectMoveInventoryUnit:
                    pnlWarehouse.Visible = true;
                    pnlAdjustmentCode.Visible = false;
                    PopulateWarehouseCombo();
                    _selectedInventoryUnits = selectedInventoryUnits;
                    this.Text = "Direct Move";
                    btnSave.Text = "Move";
                    dgvInventoryUnit.DesignForDirectMoveInventoryUnit();
                    if (selectedInventoryUnits != null)
                    {
                        dgvInventoryUnit.DataSource = selectedInventoryUnits;
                    }
                    break;
                case MovementTypeEnum.DirectMoveAny:
                    pnlWarehouse.Visible = true;
                    pnlAdjustmentCode.Visible = true;
                    PopulateWarehouseCombo();
                    // _selectedInventoryUnits = selectedInventoryUnits;
                    this.Text = "Direct Move";
                    btnSave.Text = "Move";
                    dgvInventoryUnit.DesignForDirectMoveAny();
                    //if (selectedInventoryUnits != null)
                    //{
                    //    dgvInventoryUnit.DataSource = selectedInventoryUnits;
                    //}
                    break;
            }
            
        }

        // private cause we need to handle 3 cases and shouldn't expose for PurchaseOrder only
        private void SetDataForOrder(OrderModel model, bool forEditView)
        {
            _orderModel = model;
            if (model != null)
            {
                var orderType = Enum.Parse(typeof(OrderTypeEnum), model.OrderType);
                switch (orderType)
                {
                    case OrderTypeEnum.Purchase:
                        if (forEditView)
                        {
                            this.Text = "Edit Items for PO " + model.ReferenceNumber;
                        }
                        else
                        {
                            this.Text = "Receive Against PO " + model.ReferenceNumber;
                            cbAdjustmentCode.SelectedText = "PO Receive";
                        }
                        break;
                    case OrderTypeEnum.Sale:
                        if (forEditView)
                        {
                            this.Text = "Edit Items for SO " + model.ReferenceNumber;
                        }
                        else
                        {
                            this.Text = "Issue Against SO " + model.ReferenceNumber;
                            cbAdjustmentCode.Text = "SO Issue";
                        }
                        break;
                    case OrderTypeEnum.Move:
                        this.Text = "Move Against TO " + model.ReferenceNumber;
                        cbAdjustmentCode.Text = "TO Move";
                        break;
                }
                if (!forEditView)
                {
                    dgvInventoryUnit.SetSelectable(false);

                    foreach (DataGridViewColumn column in dgvInventoryUnit.Columns)
                    {
                        column.ReadOnly = true;
                    }
                }
                dgvInventoryUnit.AutoGenerateColumns = false;
                // populate
                //BindingSource src = new BindingSource();
                // src.DataSource = _orderService.GetInventoryUnitsOfPurchaseOrdeItems(model.OrderItems);
                //dgvInventoryUnit.DataSource = src;

                var list = _orderService.GetInventoryUnitsOfPurchaseOrdeItems(model.OrderItems);
                //var data = new BindingList<InventoryUnitModel>(list);
                //dgvInventoryUnit.DataSource = data;
                dgvInventoryUnit.AddRows(list);
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

            List<DataGridViewColumn> ignoreList;
            switch (_adjustmentType)
            {
                case MovementTypeEnum.DirectIssueInventoryUnit:
                    actionForMsg = "Issued";
                    ignoreList = new List<DataGridViewColumn>
                    {
                       dgvInventoryUnit.colRate,
                       dgvInventoryUnit.colWarehouseId,
                        dgvInventoryUnit.colUomId,
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
                                msg = _inventoryUnitService.SaveDirectIssueInventoryUnit(list, adjustmentCode);
                            }
                        }
                    }
                    break;
                case MovementTypeEnum.DirectIssueAny:
                    actionForMsg = "Issued";
                    ignoreList = new List<DataGridViewColumn>
                    {
                        dgvInventoryUnit.colLotNumber,
                        dgvInventoryUnit.colRate,
                        dgvInventoryUnit.colWarehouseId,
                        dgvInventoryUnit.colUomId,
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
                    ignoreList = new List<DataGridViewColumn>
                    {
                        //dgvInventoryUnit.colRate,
                        dgvInventoryUnit.colWarehouseId,
                        dgvInventoryUnit.colUomId,
                        dgvInventoryUnit.colPackageId,
                    };
                    list = dgvInventoryUnit.GetItems(ignoreList);
                    if (list != null)
                    {
                        list.ForEach(x => x.ReceiveDate = dtReceivedDate.GetValue().ToShortDateString());
                        if (list.Count == 0)
                        {
                            msg = "At least one item expected to receive";
                        }
                        else
                        {
                            msg = _inventoryUnitService.SaveDirectReceive(list, dtReceivedDate.GetValue(), adjustmentCode);
                        }
                    }
                    break;
                // no need to go in hierarchy for now
                /*case MovementTypeEnum.POReceive:
                    // PO Receive
                    actionForMsg = "Received";
                    dialogResult = MessageBox.Show(this, "Are you sure to receive items against this purchase order?", "Receive?", MessageBoxButtons.YesNoCancel);
                    if (dialogResult.Equals(DialogResult.Yes))
                    {
                        msg = _orderService.SetReceived(_orderId);
                        this.Close();
                    }
                    break;
                    */
                case MovementTypeEnum.POReceiveEditItems:
                    // PO Receive
                    ignoreList = new List<DataGridViewColumn>
                    {
                        dgvInventoryUnit.colLotNumber,
                        dgvInventoryUnit.colWarehouseId,
                        dgvInventoryUnit.colUomId,
                    };
                    actionForMsg = "Saved";
                    var poItems = dgvInventoryUnit.GetItems(ignoreList);
                    if (poItems != null)
                    {
                        dialogResult = MessageBox.Show(this, "Are you sure to save items for this purchase order?", "Save?", MessageBoxButtons.YesNoCancel);
                        if (dialogResult.Equals(DialogResult.Yes))
                        {
                            msg = _orderService.SavePurchaseOrderItems(_orderId, poItems);
                            DoActionAfterSave(msg);
                        }
                    }
                    break;
                // we don't need hierarchy for now
                /*case MovementTypeEnum.SOIssue:
                    // PO Receive
                    actionForMsg = "Issued";
                    dialogResult = MessageBox.Show(this, "Are you sure to issue items against this sales order?", "Issue?", MessageBoxButtons.YesNoCancel);
                    if (dialogResult.Equals(DialogResult.Yes))
                    {
                        msg = _orderService.SetIssued(_orderId);
                        if (string.IsNullOrEmpty(msg))
                            this.Close();
                    }
                    break;*/
                case MovementTypeEnum.SOIssueEditItems:
                    // PO Receive
                    actionForMsg = "Saved";
                    ignoreList = new List<DataGridViewColumn>
                    {
                        dgvInventoryUnit.colLotNumber,
                        dgvInventoryUnit.colWarehouseId,
                        dgvInventoryUnit.colUomId,
                    };
                    var soItems = dgvInventoryUnit.GetItems(ignoreList);
                    if (soItems != null)
                    {
                        dialogResult = MessageBox.Show(this, "Are you sure to save items for this sale order?", "Save?", MessageBoxButtons.YesNoCancel);
                        if (dialogResult.Equals(DialogResult.Yes))
                        {

                            msg = _orderService.SavePurchaseOrderItems(_orderId, soItems);
                            DoActionAfterSave(msg);
                        }
                    }
                    break;
                case MovementTypeEnum.DirectMoveInventoryUnit:
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
                        ignoreList = new List<DataGridViewColumn>
                        {
                            dgvInventoryUnit.colRate,
                            dgvInventoryUnit.colWarehouseId,
                            dgvInventoryUnit.colUomId,
                        };
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

        private void DoActionAfterSave(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
            {
                PopupMessage.ShowErrorMessage(msg);
                this.Focus();
            }
            else
            {
                PopupMessage.ShowSaveSuccessMessage();
                this.Close();
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