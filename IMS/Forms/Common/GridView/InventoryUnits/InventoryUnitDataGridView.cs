﻿using Service.Core.Inventory;
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
        private string REQUIRED = "Required";
        private string GREATER_THAN_ZERO = "Greater than zero";

        private bool _isCellDirty;
        private int _checkCount;
        private bool _isUnSelectable;

        private bool isValid = true;

        private IInventoryService _inventoryService;

        public InventoryUnitDataGridView()
        {
            // Initialize columns
            InitializeComponent();

            this.Controls.Add(_dtPicker);
            _dtPicker.Visible = false;
            _dtPicker.Format = DateTimePickerFormat.Custom;
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



        #region Variables Expose

        public void SetSelectable(bool isSelectable)
        {
            _isUnSelectable = !isSelectable;
            if (!isSelectable)
                this.ClearSelection();
        }

        public void ResetCheckCount()
        {
            _checkCount = 0;
        }

        public void ShowCheckColumn(bool show)
        {
            colCheck.Visible = show;
            // when check box is shown, don't allow row selection
            SetSelectable(!show);
        }

        #endregion




        #region Get Cell Values

        public List<InventoryUnitModel> GetItems()
        {
            isValid = true;
            var items = new List<InventoryUnitModel>();

            // extra row is added automatically; so get upto second last row only
            for (int r = 0; r < this.Rows.Count; r++)
            {
                DataGridViewRow row = this.Rows[r];
                if (row.IsNewRow)
                    continue;
                var id = GetId(row);
                var productId = GetProductId(row);
                var unitQuantity = GetUnitQuantity(row, null);
                var supplyPrice = GetSupplyPrice(row);
                var warehouseId = GetWarehouseId(row);
                var lotNumber = GetLotNumber(row, null);
                var reference = GetReference(row);
                var adjCode = GetAdjustmentCode(row);
                var packageId = GetPackageId(row);
                var uomId = GetUomId(row);
                var isHold = row.Cells[colIsHold.Index].Value;

                if (isValid)
                {
                    items.Add(new InventoryUnitModel
                    {
                        Id = id,
                        //PurchaseOrderId = _purchaseOrderId,
                        UnitQuantity = unitQuantity,
                        TotalSupplyAmount = supplyPrice * unitQuantity,
                        ProductId = productId,
                        SupplyPrice = supplyPrice,
                        WarehouseId = warehouseId,
                        ReceiveAdjustment = adjCode,
                        LotNumber = lotNumber,
                        ExpirationDate = null,
                        ProductionDate = null,
                        SupplierId = null,
                        ReceiveReceipt = reference,
                        PackageId = packageId,
                        UomId = uomId,
                        IsHold = isHold == null ? false : bool.Parse(isHold.ToString()),
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

        // Gets
        private int GetId(DataGridViewRow row)
        {
            var cell = row.Cells[colId.Index];
            var value = cell.Value == null ? 0 : int.Parse(cell.Value.ToString());
            return value;
        }
        private int GetProductId(DataGridViewRow row)
        {
            var cell = row.Cells[colProductId.Index];
            var productId = 0;
            int.TryParse(cell.Value == null ? "0" : cell.Value.ToString(), out productId);
            if (productId == 0)
            {
                var sku = row.Cells[this.colSKU.Index].Value as string;
                var product = _inventoryService.GetProductBySKU(sku);
                productId = product == null ? 0 : product.Id;
            }
            if (productId == 0)
            {
                cell.ErrorText = "Invalid Product";
                isValid = false;
            }
            else
            {
                cell.ErrorText = string.Empty;
            }
            return productId;
        }

        private decimal GetUnitQuantity(DataGridViewRow row, object formattedValue)
        {
            decimal unitQuantity = 0;
            var cell = row.Cells[this.colUnitQuantity.Index];
            var value = formattedValue == null ? cell.Value : formattedValue;
            decimal.TryParse(value == null ? "0" : value.ToString(), out unitQuantity);
            if (unitQuantity <= 0)
            {
                cell.ErrorText = "Quantity can't be zero or less";
                isValid = false;
            }
            else
            {
                cell.ErrorText = string.Empty;
            }
            return unitQuantity;
        }

        private decimal GetSupplyPrice(DataGridViewRow row)
        {
            decimal rate = 0;
            var cell = row.Cells[this.colSupplyPrice.Index];
            decimal.TryParse(cell.Value == null ? "0" : cell.Value.ToString(), out rate);
            if (rate <= 0)
            {
                cell.ErrorText = GREATER_THAN_ZERO;//"Rate can't be zero or less";
                isValid = false;
            }
            else
            {
                cell.ErrorText = string.Empty;
            }
            return rate;
        }

        private int GetWarehouseId(DataGridViewRow row)
        {
            var cell = row.Cells[colWarehouseId.Index];
            var warehouseId = cell.Value == null ? 0 : int.Parse(cell.Value.ToString());
            if (warehouseId == 0)
            {
                isValid = false;
                cell.ErrorText = REQUIRED;
            }
            else
            {
                cell.ErrorText = string.Empty;
            }
            return warehouseId;
        }

        private int GetLotNumber(DataGridViewRow row, object formattedValue)
        {
            var cell = row.Cells[colLotNumber.Index];
            var value = formattedValue == null ? cell.Value : formattedValue;
            var lotNumber = value == null ? 0 : int.Parse(value.ToString());
            if (lotNumber == 0)
            {
                isValid = false;
                cell.ErrorText = "Should be greater than zero";// GREATER_THAN_ZERO;
            }
            else
            {
                cell.ErrorText = string.Empty;

            }
            return lotNumber;
        }

        private string GetReference(DataGridViewRow row)
        {
            var cell = row.Cells[colReceiveReference.Index];
            return cell.Value == null ? "" : cell.Value.ToString();
            //if (cell.Value == null || string.IsNullOrEmpty(cell.Value.ToString()))
            //{
            //    isValid = false;
            //    cell.ErrorText = REQUIRED;
            //}
            //cell.ErrorText = string.Empty;
            //return cell.Value.ToString();
        }

        private string GetAdjustmentCode(DataGridViewRow row)
        {
            var adjCode = row.Cells[this.colReceiveAdjustment.Index].Value;
            return adjCode == null ? "" : adjCode.ToString();
        }

        private int GetPackageId(DataGridViewRow row)
        {
            var cell = row.Cells[colPackageId.Index];
            var valueValue = cell.Value;// formattedValue == null ? cell.Value : formattedValue;
            var value = valueValue == null ? 0 : int.Parse(valueValue.ToString());
            if (value == 0)
            {
                isValid = false;
                cell.ErrorText = REQUIRED;
            }
            else
            {
                cell.ErrorText = string.Empty;
            }
            return value;
        }

        private int GetUomId(DataGridViewRow row)
        {
            var cell = row.Cells[colUomId.Index];
            var value = cell.Value == null ? 0 : int.Parse(cell.Value.ToString());
            if (value == 0)
            {
                isValid = false;
                cell.ErrorText = REQUIRED;
            }
            else
            {
                cell.ErrorText = string.Empty;
            }
            return value;
        }

        #endregion

    }
}