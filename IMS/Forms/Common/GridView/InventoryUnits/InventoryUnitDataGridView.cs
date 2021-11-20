using Service.Core.Inventory;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Core.Common;
using ViewModel.Core.Inventory;
using ViewModel.Enums;
using ViewModel.Utility;

namespace IMS.Forms.Common.GridView.InventoryUnits
{
    //
    // Main : DataGridView
    // 
    public partial class InventoryUnitDataGridView : DataGridViewCustom
    {
       

        //private List<ViewModel.Core.Inventory.InventoryUnitModel> _dataList;
        private bool _isCellDirty;
        private int _checkCount;


        private bool _isUnSelectable;
        private bool _isEditable = true; // by default editable
        private bool isValid = true;
        private MovementTypeEnum _movementType;

        private IInventoryService _inventoryService;
        private IProductService _productService;
        private IUomService _uomService;
        private List<DataGridViewColumn> IgnoreColumnsForErrorList = new List<DataGridViewColumn>();

        public MovementTypeEnum MovementType { get { return _movementType; } internal set { _movementType = value; } }

        private List<string> InvalidColumns = new List<string>();

        private List<IdNamePair> _productList;
        private List<IdNamePair> _packageList;

        public InventoryUnitDataGridView()
        {
            // Initialize columns
            InitializeComponent();

            this.Controls.Add(_dtPicker);
            _dtPicker.Visible = false;
            _dtPicker.Format = DateTimePickerFormat.Custom;

            this.AutoGenerateColumns = false;


        }



        public void InitializeGridViewControls(IInventoryService inventoryService, IProductService productService, IUomService uomService, List<ProductTypeEnum> productTypes = null)
        {
            _inventoryService = inventoryService;
            _productService = productService;
            _uomService = uomService;
            _productList = _productService.GetProductListForCombo(productTypes: productTypes);
            _packageList = _inventoryService.GetPackageListForCombo();
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



        #region Setters & Variables Expose

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

        //public void SetData(List<ViewModel.Core.Inventory.InventoryUnitModel> modelList)
        //{
        //    this._dataList = modelList;
        //}
        #endregion




        #region Get Cell Values

        public List<InventoryUnitModel> GetItems(List<DataGridViewColumn> ignoreColumnsForError = null, bool checkWithInStockQuantity = true, bool ignoreAllColumnsForError = false)
        {
            var isValidAll = true; // store for all items (global indicator)
            this.IgnoreColumnsForErrorList = ignoreColumnsForError ?? new List<DataGridViewColumn>();
            if (ignoreAllColumnsForError)
            {
                IgnoreColumnsForErrorList.Clear();
                for (var i = 0; i < this.ColumnCount; i++)
                    IgnoreColumnsForErrorList.Add(this.Columns[i]);
            }
            isValid = true;
            var items = new List<InventoryUnitModel>();
            // clear the invalid column list initially
            InvalidColumns.Clear();
            var extraMsg = new StringBuilder();
            // extra row is added automatically; so get upto second last row only
            for (int r = 0; r < this.Rows.Count; r++)
            {
                DataGridViewRow row = this.Rows[r];
                if (row.IsNewRow)
                    continue;
                var id = GetId(row);
                var product = GetProduct(row);

                checkWithInStockQuantity = checkWithInStockQuantity && !Constants.CAN_NEW_PACKAGE_BE_ADDED_FROM_TRANSACTION && (_movementType == MovementTypeEnum.DirectIssueAny
                    || _movementType == MovementTypeEnum.DirectIssueInventoryUnit
                    || _movementType == MovementTypeEnum.SOIssue
                    || _movementType == MovementTypeEnum.SOIssueEditItems);

                var productModel = row.Cells[colProduct.Index].Tag as ProductModel;
                if(productModel == null)
                {
                    if (product.Id > 0)
                        productModel = _productService.GetProduct(product.Id);
                    else if (!string.IsNullOrWhiteSpace(product.Name))
                        productModel = _productService.GetProductByNameOrSKU(product.Name.Trim());
                    if (productModel != null)
                        row.Cells[colProduct.Index].Tag = productModel;
                }

                var package = GetPackage(row, productModel);
                var packageFromDB = _inventoryService.GetPackageByName(package.Name);
                package.Id = packageFromDB?.Id ?? 0;
                var unitQuantity = GetUnitQuantity(row, null, checkWithInStockQuantity, productModel, package);
                var rate = GetRate(row);
                var warehouseId = GetWarehouseId(row);
                var lotNumber = GetLotNumber(row, null);
                var reference = GetReference(row);
                var adjCode = GetAdjustmentCode(row);
                //var uomId = GetUomId(row);
                var isHold = row.Cells[colIsHold.Index].Value;
                var expirationDate = GetDateCellValue(row, colExpirationDate);
                var productionDate = GetDateCellValue(row, colProductionDate);
                if (isValid)
                {
                    if (product.Id == 0 && string.IsNullOrEmpty(product.Name))
                        continue;
                    items.Add(new InventoryUnitModel
                    {
                        Id = id,
                        //PurchaseOrderId = _purchaseOrderId,
                        UnitQuantity = unitQuantity,
                        Total = rate * unitQuantity,
                        ProductId = product.Id,
                        Product = product.Name,
                        Rate = rate,
                        WarehouseId = warehouseId,
                        ReceiveAdjustmentCode = adjCode,
                        LotNumber = lotNumber,
                        ExpirationDate = expirationDate,
                        ProductionDate = productionDate,
                        SupplierId = null,
                        ReceiveReceipt = reference,
                        PackageId = package.Id == 0 ? null : (int?)package.Id,
                        Package = package.Name,
                        //  UomId = uomId,
                        IsHold = isHold == null ? false : bool.Parse(isHold.ToString()),
                        ProductModel = productModel
                    });
                }
                else
                {
                    extraMsg.Append("Row: ").Append(r + 1).Append("; Columns: ");
                    InvalidColumns.Distinct().ToList().ForEach(x =>
                    {
                        extraMsg.Append(x + ", ");
                    });
                    extraMsg.Append("\n");
                }

            }
            if (!isValid)
            {
                PopupMessage.ShowPopupMessage("Invalid Items!", "The items you provided are not valid. Verify again!." + extraMsg,
                    PopupMessageType.ERROR);
                this.FindForm()?.Focus();
                return null;
            }
            return items;
        }

        /// <summary>
        /// Returns sum of all the rows of total column
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalSumAmount()
        {
            decimal total = 0M;
            for (int r = 0; r < this.Rows.Count; r++)
            {
                DataGridViewRow row = this.Rows[r];
                if (row.IsNewRow)
                    continue;
                total += GetTotal(row);// (GetRate(row) * GetUnitQuantity(row, null));
            }
            return total;
        }

        private decimal GetTotal(DataGridViewRow row)
        {
            decimal total = 0;
            var cell = row.Cells[this.colTotal.Index];
            decimal.TryParse(cell.Value == null ? "0" : cell.Value.ToString(), out total);
            return total;
        }

        // Gets
        private int GetId(DataGridViewRow row)
        {
            var cell = row.Cells[colId.Index];
            var value = cell.Value == null ? 0 : int.Parse(cell.Value.ToString());
            return value;
        }


        private ProductModel GetProduct(DataGridViewRow row)
        {
            var model = new ProductModel();
            var productIdCell = row.Cells[colProductId.Index];
            var productNameCell = row.Cells[colProduct.Index];
            productIdCell.ErrorText = string.Empty;
            productNameCell.ErrorText = string.Empty;
            if (colProductId.Visible)
            {
                var productId = 0;

                int.TryParse(productIdCell.Value == null ? "0" : productIdCell.Value.ToString(), out productId);
                model.Id = productId;
                model.Name = _productList.FirstOrDefault(x => x.Id == productId)?.Name;
            }
            else
            {
                string productNameOrSku = productNameCell.Value as string;
                model.Name = productNameOrSku;
                if (string.IsNullOrEmpty(productNameOrSku))
                {
                    InvalidColumns.Add("Product");
                    productIdCell.ErrorText = "Required";
                    productNameCell.ErrorText = "Required";
                    isValid = false;
                    return model;
                }
                if (!Constants.CAN_NEW_PRODUCT_BE_ADDED_FROM_TRANSACTION)
                {
                    // send zero in order id cause we don't need to know the total instock qty below
                    var prd = _productService.GetProductByNameOrSKU(model?.Name?.Trim());
                    if (prd == null)
                    {
                        InvalidColumns.Add("Product");
                        productIdCell.ErrorText = "Invalid Product";
                        productNameCell.ErrorText = "Invalid Product";
                        isValid = false;
                        return model;
                    }
                }
            }



            if (IgnoreColumnsForErrorList.Contains(colProductId))
            {
                return model;
            }
            // else set error and set invalid flag
            if (model.Id == 0 && string.IsNullOrEmpty(model.Name))
            {
                InvalidColumns.Add("Product");
                productIdCell.ErrorText = "Invalid Product";
                productNameCell.ErrorText = "Invalid Product";
                isValid = false;
            }
            else
            {
                productIdCell.ErrorText = string.Empty;
                productNameCell.ErrorText = string.Empty;
            }
            return model;//productId;
        }

        private PackageModel GetPackage(DataGridViewRow row, ProductModel product)
        {
            var model = new PackageModel();
            var idCell = row.Cells[colPackageId.Index];
            var nameCell = row.Cells[colPackage.Index];

            if (colPackageId.Visible)
            {
                var packageId = 0;
                int.TryParse(idCell.Value == null ? "0" : idCell.Value.ToString(), out packageId);
                model.Id = packageId;
            }
            else
            {
                model.Name = nameCell.Value as string;
            }

            if (IgnoreColumnsForErrorList.Contains(colPackageId))
            {
                return model;
            }

            if (model.Id == 0 && string.IsNullOrEmpty(model.Name))
            {
                InvalidColumns.Add("Package");
                isValid = false;
                idCell.ErrorText = Constants.REQUIRED;
                nameCell.ErrorText = Constants.REQUIRED;
            }
            else
            {
                if (model.Id == 0 && !Constants.CAN_NEW_PACKAGE_BE_ADDED_FROM_TRANSACTION)
                {
                    if (product != null)
                    {
                        var nameLower = model.Name.ToLower();
                        if (!product.Packages.Any(x => x.Name.ToLower() == nameLower))
                        {
                            InvalidColumns.Add("Package");
                            isValid = false;
                            idCell.ErrorText = Constants.NOT_AVAILABLE_IN_PRODUCT_UOM;
                            nameCell.ErrorText = Constants.NOT_AVAILABLE_IN_PRODUCT_UOM;
                            return model;
                        }
                    }
                }
                idCell.ErrorText = string.Empty;
                nameCell.ErrorText = string.Empty;
            }
            return model;
        }

        private decimal GetUnitQuantity(DataGridViewRow row, object formattedValue, bool checkWithInStockQuanity, ProductModel product, PackageModel currentPackage)
        {
            decimal unitQuantity = 0;
            var cell = row?.Cells[this.colUnitQuantity.Index];
            var value = formattedValue == null ? cell?.Value : formattedValue;
            decimal.TryParse(value == null ? "0" : value?.ToString(), out unitQuantity);
            if (IgnoreColumnsForErrorList.Contains(colUnitQuantity))
            {
                return unitQuantity;
            }
            if (unitQuantity <= 0)
            {
                InvalidColumns.Add("Quantity");
                cell.ErrorText = "Quantity can't be zero or less";
                isValid = false;
            }
            else if (checkWithInStockQuanity)
            {
                decimal inStockQuantity = 0;
                var inStockcell = row?.Cells[this.colInStockQuantity.Index];
                decimal.TryParse(inStockcell?.Value == null ? "0" : inStockcell?.Value.ToString(), out inStockQuantity);

                if(currentPackage.Id > 0)
                {
                    var conversion = _uomService.ConvertUom(product.BasePackageId ?? 0, currentPackage.Id, product.Id);
                    var inStockQuantityConverted = inStockQuantity * conversion;
                    if (unitQuantity > inStockQuantityConverted)
                    {
                        InvalidColumns.Add("Quantity");
                        cell.ErrorText = $"Quantity can't be greater than stock quantity. Stock Quanitity is '{decimal.Round(inStockQuantityConverted, 2)} {currentPackage.Name}'"; //+ //inStockQuantity.ToString("0") + "'";
                        isValid = false;
                    }
                }
                
            }
            else
            {
                cell.ErrorText = string.Empty;
            }
            return unitQuantity;
        }

        private decimal GetRate(DataGridViewRow row)
        {
            decimal rate = 0;
            var cell = row.Cells[this.colRate.Index];
            decimal.TryParse(cell.Value == null ? "0" : cell.Value.ToString(), out rate);
            if (IgnoreColumnsForErrorList.Contains(colRate) && rate >= 0)
            {
                return rate;
            }
            if (rate <= 0)
            {
                InvalidColumns.Add("Rate");
                cell.ErrorText = Constants.GREATER_THAN_ZERO;//"Rate can't be zero or less";
                isValid = false;
            }
            else
            {
                cell.ErrorText = string.Empty;
            }
            return rate;
        }

        private int? GetWarehouseId(DataGridViewRow row)
        {
            var cell = row.Cells[colWarehouseId.Index];
            var warehouseId = cell.Value == null ? null : (int?)int.Parse(cell.Value.ToString());
            if (IgnoreColumnsForErrorList.Contains(colWarehouseId))
            {
                return warehouseId;
            }
            if (warehouseId == 0)
            {
                InvalidColumns.Add("Warehouse");
                isValid = false;
                cell.ErrorText = Constants.REQUIRED;
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
            if (IgnoreColumnsForErrorList.Contains(colLotNumber) || !_decimalValidator.HasColumn(colLotNumber))
            {
                return lotNumber;
            }
            if (lotNumber == 0)
            {
                InvalidColumns.Add("Lot No.");
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
        /*
        private int? GetUomId(DataGridViewRow row)
        {
            var cell = row.Cells[colUomId.Index];
            var value = cell.Value == null ? null : (int?)int.Parse(cell.Value.ToString());
            if (IgnoreColumnsForErrorList.Contains(colUomId))
            {
                return value;
            }
            if (value == 0)
            {
                InvalidColumns.Add("UoM");
                isValid = false;
                cell.ErrorText = REQUIRED;
            }
            else
            {
                cell.ErrorText = string.Empty;
            }
            return value;
        }
        */

        private string GetDateCellValue(DataGridViewRow row, DataGridViewColumn column)
        {
            var value = row.Cells[column.Index].Value;
            if (value == null)
                return "";
            var valueString = value.ToString();
            var cell = row.Cells[column.Index];
            if (string.IsNullOrEmpty(valueString) || string.IsNullOrWhiteSpace(valueString))
                return "";
            DateTime date;
            if (IgnoreColumnsForErrorList.Contains(column))
            {
                return valueString;
            }
            if (DateTime.TryParse(valueString, out date))
            {
                cell.ErrorText = string.Empty;
                return valueString;
            }
            else
            {
                InvalidColumns.Add(column.HeaderText);
                isValid = false;
                cell.ErrorText = Constants.INVALID;
                return "";
            }
        }

        #endregion

    }
}
