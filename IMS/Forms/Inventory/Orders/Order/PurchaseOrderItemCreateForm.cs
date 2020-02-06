using IMS.Forms.Common;
using Service.Core.Inventory;
using Service.Core.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ViewModel.Core.Orders;
using ViewModel.Enums;

namespace IMS.Forms.Inventory.Purchases.Order
{
    public partial class PurchaseOrderItemCreateForm : Form
    {
        private readonly IInventoryService _inventoryService;
        private readonly IOrderService _purchaseService;

        private OrderModel _purchaseOrder;
        private int _purchaseOrderId;
        private bool _isCellDirty;
        private OrderTypeEnum _orderType;

        public PurchaseOrderItemCreateForm(IInventoryService inventoryService, IOrderService purchaseService)
        {
            _inventoryService = inventoryService;
            _purchaseService = purchaseService;

            InitializeComponent();

            this.Load += PurchaseOrderItemCreateForm_Load;
        }

        private void PurchaseOrderItemCreateForm_Load(object sender, EventArgs e)
        {
            var model = _purchaseService.GetOrder(_orderType, _purchaseOrderId);
            SetData(model);

            InitializeEvents();

        }


        #region Initialize Functions

        private void InitializeEvents()
        {
            btnSaveItems.Click += btnSaveItems_Click;
            dgvItems.CellValidating += DgvItems_CellValidating;
            dgvItems.CurrentCellDirtyStateChanged += DgvItems_CurrentCellDirtyStateChanged;

        }

        #endregion

        #region Set Data

        public void SetData(OrderTypeEnum orderType, int purchaseOrderId)
        {
            _orderType = orderType;
            _purchaseOrderId = purchaseOrderId;

        }

        private void SetData(OrderModel model)
        {
            _purchaseOrderId = model == null ? 0 : model.Id;
            _purchaseOrder = model;
            if (model != null)
            {
                // populate
                lblName.Text = model.Name;
                lblStatus.Text = "( Open )";

                PopulateItems(model.OrderItems);
                // logic to show buttons
                var enableSave = !(model.IsCancelled || model.IsVerified || model.IsExecuted);
                pnlItemsSaveFooter.Enabled = enableSave;

                switch (_orderType)
                {
                    case OrderTypeEnum.Move:
                        colRate.ReadOnly = true;
                        break;
                }
            }
        }

        private void PopulateItems(ICollection<OrderItemModel> purchaseOrderItems)
        {
            foreach (var item in purchaseOrderItems)
            {
                var row = (DataGridViewRow)dgvItems.Rows[dgvItems.RowCount - 1].Clone();
                row.Cells[colId.Index].Value = item.Id;
                row.Cells[this.colInStock.Index].Value = item.InStock;
                row.Cells[this.colOnOrder.Index].Value = item.OnOrder;
                row.Cells[this.colProduct.Index].Value = item.Product;
                row.Cells[this.colQuantity.Index].Value = item.UnitQuantity;
                row.Cells[this.colRate.Index].Value = item.Rate;
                row.Cells[this.colSKU.Index].Value = item.SKU;
                row.Cells[this.colTotal.Index].Value = item.TotalAmount;
                row.Cells[this.colIsHold.Index].Value = item.IsHold;
                dgvItems.Rows.Add(row);
            }
        }

        #endregion


        #region Event Handlers

        private void btnSaveItems_Click(object sender, EventArgs e)
        {
            SaveItems();
        }

        private void DgvItems_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (_isCellDirty)
            {
                _isCellDirty = false;
                // ignore the last row
                if (e.RowIndex < dgvItems.RowCount - 1)
                {
                    var row = dgvItems.Rows[e.RowIndex];
                    if (e.ColumnIndex == colSKU.Index)
                    {
                        // check if the sku is valid
                        var product = _inventoryService.GetProductBySKU(e.FormattedValue.ToString());
                        if (product == null)
                        {
                            row.Cells[e.ColumnIndex].ErrorText = "Invalid SKU";
                        }
                        else
                        {
                            row.Cells[e.ColumnIndex].ErrorText = string.Empty;
                            // populate
                            row.Cells[this.colProduct.Index].Value = product.Name;
                            row.Cells[this.colRate.Index].Value = product.SupplyPrice;
                            row.Cells[this.colPackageId.Index].Value = product.PackageId;
                            row.Cells[this.colUomId.Index].Value = product.BaseUomId;
                            UpdateTotalColumn(e);
                            if (_orderType == OrderTypeEnum.Move)
                            {
                                var warehouseProduct = _inventoryService.GetWarehouseProductList(_purchaseOrder.ToWarehouseId ?? 0, product.Id);
                                if (warehouseProduct.Any())
                                {
                                    row.Cells[this.colInStock.Index].Value = warehouseProduct[0].InStockQuantity;
                                    row.Cells[this.colOnOrder.Index].Value = warehouseProduct[0].OnOrderQuantity;
                                }
                                else
                                {
                                    row.Cells[this.colInStock.Index].Value = 0M;
                                    row.Cells[this.colOnOrder.Index].Value = 0M;
                                }
                            }
                            else
                            {
                                row.Cells[this.colInStock.Index].Value = product.InStockQuantity;
                                row.Cells[this.colOnOrder.Index].Value = product.OnOrderQuantity;
                            }
                           
                        }
                    }
                    // handle rate and quantity change to update Total
                    else if (e.ColumnIndex == colQuantity.Index || e.ColumnIndex == colRate.Index)
                    {
                        UpdateTotalColumn(e);
                    }
                }
            }
        }

        private void UpdateTotalColumn(DataGridViewCellValidatingEventArgs e)
        {
            var row = dgvItems.Rows[e.RowIndex];
            object qtyVal = row.Cells[colQuantity.Name].Value;
            object rateVal = row.Cells[colRate.Name].Value;
            decimal quantity = 0, rate = 0;

            if (e.ColumnIndex == colQuantity.Index)
            {
                qtyVal = e.FormattedValue; // row.Cells[colQuantity.Name].Value;
            }
            else if (e.ColumnIndex == colRate.Index)
            {
                rateVal = e.FormattedValue;
            }
            decimal.TryParse(qtyVal == null ? "0" : qtyVal.ToString(), out quantity);
            decimal.TryParse(rateVal == null ? "0" : rateVal.ToString(), out rate);
            row.Cells[colTotal.Index].Value = quantity * rate;
        }

        private void DgvItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            _isCellDirty = true;
        }


        #endregion



        #region Save Functions

        private void SaveItems()
        {
            var items = GetItems();
            if (items != null)
            {
                var msg = _purchaseService.SavePurchaseOrderItems(_purchaseOrderId, items);
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
        }

        private List<OrderItemModel> GetItems()
        {
            var isValid = true;
            var items = new List<OrderItemModel>();

            // extra row is added automatically; so get upto second last row only
            for (int r = 0; r < dgvItems.Rows.Count - 1; r++)
            {
                DataGridViewRow row = dgvItems.Rows[r];
                row.Cells[colQuantity.Name].ErrorText = string.Empty;
                row.Cells[colRate.Name].ErrorText = string.Empty;
                row.ErrorText = string.Empty;

                var sku = row.Cells[colSKU.Name].Value as string;
                var variant = _inventoryService.GetProductBySKU(sku);
                if (variant == null)
                {
                    row.ErrorText = "SKU not found!";
                    isValid = false;
                }
                else
                {
                    

                    decimal inStock = decimal.Parse(row.Cells[colInStock.Name].Value.ToString());
                    decimal quantity = 0;
                    var qtyVal = row.Cells[colQuantity.Name].Value;
                    decimal.TryParse(qtyVal == null ? "0" : qtyVal.ToString(), out quantity);
                    if (quantity <= 0)
                    {
                        row.ErrorText = "Quantity can't be zero or less";
                        row.Cells[colQuantity.Name].ErrorText = "Quantity can't be zero or less";
                        isValid = false;
                    }
                    if(_orderType == OrderTypeEnum.Move || _orderType == OrderTypeEnum.Sale)
                    {
                        if(quantity > inStock)
                        {
                            row.ErrorText = "Quantity can't be greater than " + inStock.ToString();
                            row.Cells[colQuantity.Name].ErrorText = "Quantity can't be zero or less";
                            isValid = false;
                        }
                    }
                    decimal rate = 0;
                    var rateVal = row.Cells[colRate.Name].Value;
                    decimal.TryParse(rateVal == null ? "0" : rateVal.ToString(), out rate);
                    if (rate <= 0)
                    {
                        row.ErrorText = "Rate can't be zero or less";
                        row.Cells[colRate.Name].ErrorText = "Rate can't be zero or less";
                        isValid = false;
                    }
                    var isHold = row.Cells[colIsHold.Index].Value;
                    var packageId = row.Cells[colPackageId.Index].Value;
                    var uomId = row.Cells[colUomId.Index].Value;
                    items.Add(new OrderItemModel
                    {
                        Id = 0,
                        PurchaseOrderId = _purchaseOrderId,
                        UnitQuantity = quantity,
                        TotalAmount = rate * quantity,
                        ProductId = variant.Id,
                        Rate = rate, //variant.LatestUnitSellPrice,
                        IsHold = isHold == null ? false: bool.Parse(isHold.ToString()),
                        WarehouseId = _purchaseOrder.WarehouseId,
                        Adjustment = "PO Receive",//_purchaseOrder.Status
                        ExpirationDate = null,
                        LotNumber = _purchaseOrder.LotNumber,
                        ProductionDate = null,
                        SupplierId = _purchaseOrder.SupplierId,
                        Reference = _purchaseOrder.ReferenceNumber,
                        PackageId = int.Parse(packageId.ToString()),
                        UomId = int.Parse(uomId.ToString()),
                        //PackageQuantity = 
                        
                    });
                    
                }
            }
            if (!isValid)
            {
                PopupMessage.ShowPopupMessage("Invalid Items!", "The items you provided aar not valid. Verify again!.", PopupMessageType.ERROR);
                return null;
            }
            return items;
        }

        #endregion




    }
}
