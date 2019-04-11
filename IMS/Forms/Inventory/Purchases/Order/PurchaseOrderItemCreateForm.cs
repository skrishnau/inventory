using IMS.Forms.Common;
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
using ViewModel.Core.Purchases;

namespace IMS.Forms.Inventory.Purchases.Order
{
    public partial class PurchaseOrderItemCreateForm : Form
    {
        private readonly IInventoryService _inventoryService;
        private readonly IPurchaseService _purchaseService;

        private int _purchaseOrderId;
        private bool _isCellDirty;

        public PurchaseOrderItemCreateForm(IInventoryService inventoryService, IPurchaseService purchaseService)
        {
            _inventoryService = inventoryService;
            _purchaseService = purchaseService;

            InitializeComponent();

            this.Load += PurchaseOrderItemCreateForm_Load;
        }

        private void PurchaseOrderItemCreateForm_Load(object sender, EventArgs e)
        {
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

        public void SetData(int purchaseOrderId)
        {
            var model = _purchaseService.GetPurchaseOrder(purchaseOrderId);
            SetData(model);
        }

        public void SetData(PurchaseOrderModel model)
        {
            _purchaseOrderId = model == null ? 0 : model.Id;
            if (model != null)
            {
                // populate
                lblName.Text = model.Name;
                lblStatus.Text = "( Open )";

                PopulateItems(model.PurchaseOrderItems);
                // logic to show buttons
                var enableSave = !(model.IsCancelled || model.IsOrderSent || model.IsReceived);
                pnlItemsSaveFooter.Enabled = enableSave;
            }
        }

        private void PopulateItems(ICollection<PurchaseOrderItemModel> purchaseOrderItems)
        {
            foreach (var item in purchaseOrderItems)
            {
                var row = (DataGridViewRow)dgvItems.Rows[dgvItems.RowCount - 1].Clone();
                row.Cells[colId.Index].Value = item.Id;
                row.Cells[this.colInStock.Index].Value = item.InStock;
                row.Cells[this.colOnOrder.Index].Value = item.OnOrder;
                row.Cells[this.colProduct.Index].Value = item.Product;
                row.Cells[this.colQuantity.Index].Value = item.Quantity;
                row.Cells[this.colRate.Index].Value = item.Rate;
                row.Cells[this.colSKU.Index].Value = item.SKU;
                row.Cells[this.colTotal.Index].Value = item.TotalAmount;
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
                            row.Cells[this.colInStock.Index].Value = product.AvailableQuantity;
                            row.Cells[this.colOnOrder.Index].Value = product.OnOrderQuantity;
                            row.Cells[this.colRate.Index].Value = product.SupplyPrice;
                            UpdateTotalColumn(e);
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

        private List<PurchaseOrderItemModel> GetItems()
        {
            var isValid = true;
            var items = new List<PurchaseOrderItemModel>();

            // extra row is added automatically; so get upto second last row only
            for (int r = 0; r < dgvItems.Rows.Count - 1; r++)
            {
                DataGridViewRow row = dgvItems.Rows[r];
                var sku = row.Cells[colSKU.Name].Value as string;
                var variant = _inventoryService.GetProductBySKU(sku);
                if (variant == null)
                {
                    row.ErrorText = "SKU not found!";
                    isValid = false;
                }
                else
                {
                    decimal quantity = 0;
                    var qtyVal = row.Cells[colQuantity.Name].Value;
                    decimal.TryParse(qtyVal == null ? "0" : qtyVal.ToString(), out quantity);
                    if (quantity <= 0)
                    {
                        row.ErrorText = "Quantity can't be zero or less";
                        isValid = false;
                    }
                    decimal rate = 0;
                    var rateVal = row.Cells[colRate.Name].Value;
                    decimal.TryParse(rateVal == null ? "0" : rateVal.ToString(), out rate);
                    if (rate <= 0)
                    {
                        row.ErrorText = "Rate can't be zero or less";
                        isValid = false;
                    }
                    items.Add(new PurchaseOrderItemModel
                    {
                        Id = 0,
                        PurchaseOrderId = _purchaseOrderId,
                        Quantity = quantity,
                        TotalAmount = rate * quantity,
                        ProductId = variant.Id,
                        Rate = rate, //variant.LatestUnitSellPrice,
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
