using IMS.Forms.Common;
using Service.Core.Inventory;
using Service.Core.Inventory.Units;
using Service.Interfaces;
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
using ViewModel.Enums;

namespace IMS.Forms.Inventory.Units.Actions
{
    public partial class InventoryMergeForm : Form
    {

        private readonly IInventoryService _inventoryService;
        private readonly IInventoryUnitService _inventoryUnitService;
        private readonly IProductService _productService;
        private readonly IUomService _uomService;
        private readonly IProductOwnerService _productOwnerService;

        private List<InventoryUnitModel> _dataList;

        public InventoryMergeForm(IInventoryService inventoryService, IInventoryUnitService inventoryUnitService, IProductService productService, IUomService uomService, IProductOwnerService productOwnerService)
        {
            _inventoryService = inventoryService;
            _inventoryUnitService = inventoryUnitService;
            _productService = productService;
            _uomService = uomService;
            _productOwnerService = productOwnerService;

            InitializeComponent();

            this.Load += InventoryMergeForm_Load;
        }

        private void InventoryMergeForm_Load(object sender, EventArgs e)
        {
            dgvItems.InitializeGridViewControls(_inventoryService, _productService, _uomService, _productOwnerService);
            dgvItems.MovementType = MovementTypeEnum.Merge;
            dgvItems.DesignForMerging();
            PopulateData();

        }

        public void SetData(List<InventoryUnitModel> list)
        {
            _dataList = list;
        }

        private void PopulateData()
        {
            string message = "";
            var displayList = new List<InventoryUnitModel>();
            foreach (var productWiseGroup in _dataList.GroupBy(x => new { x.ProductId , x.IsHold}))
            {
                var product = _productService.GetProduct(productWiseGroup.Key.ProductId);
                foreach (var warehouseWiseGroup1 in productWiseGroup.GroupBy(x => x.WarehouseId))
                {
                    var zeroRateOrderItemIdGroup = warehouseWiseGroup1.Where(x => x.Rate == 0).GroupBy(x => x.PurchaseOrderItemId);
                    foreach (var zwhg in zeroRateOrderItemIdGroup)
                    {
                        if (zwhg.Count() > 0)
                        {
                            var mergedModel = GetMergedModel(zwhg.ToList(), product, ref message);
                            displayList.Add(mergedModel);
                        }
                    }

                    var withoutZeroRate = warehouseWiseGroup1.Where(x => x.Rate > 0).ToList();
                    if (withoutZeroRate.Count() > 0)
                    {
                        var mergedModel = GetMergedModel(withoutZeroRate, product, ref message);
                        displayList.Add(mergedModel);
                    }
                }

            }
            //dgvInventoryUnit.AutoGenerateColumns = false;
            //dgvInventoryUnit.DataSource = displayList;
            dgvItems.DataSource = displayList;

            if (!string.IsNullOrEmpty(message))
            {
                PopupMessage.ShowInfoMessage(message);
                //btnSave.Enabled = false;
            }

        }

        private InventoryUnitModel GetMergedModel(List<InventoryUnitModel> withoutZeroRate, ProductModel product, ref string message)
        {
            //var first = invUnitGroup.First();
            var last = withoutZeroRate.Last();

            var unitQuantity = 0M; //var unitQuantity = withoutZeroRate.Sum(x => x.UnitQuantity);
            var totalAmount = 0M;
            foreach (var inv in withoutZeroRate)
            {
                var conversion = _uomService.ConvertUom(inv.PackageId ?? 0, product.BasePackageId ?? 0, inv.ProductId);
                if (conversion == 0)
                {
                    message += "Some items cannot be converted to base unit. Please update product's uom.\n";
                    return null;
                }
                unitQuantity += inv.UnitQuantity * conversion;
                totalAmount += inv.UnitQuantity * inv.Rate;//rateList.Add(inv.Rate / conversion);
            }
            var rate = decimal.Round(totalAmount / unitQuantity, 3);//var rate = withoutZeroRate.Sum(x => x.UnitQuantity * x.Rate) / withoutZeroRate.Sum(x => x.UnitQuantity);
            //var packageQuantity = withoutZeroRate.Sum(x => x.PackageQuantity);
            var model = GetMergedModel(last, product, decimal.Round(unitQuantity, 3), rate);
            return model;
        }

        private InventoryUnitModel GetMergedModel(InventoryUnitModel last, ProductModel product, decimal unitQuantity, decimal rate)
        {
            var model = new InventoryUnitModel()
            {
                Product = last.Product,
                ProductId = last.ProductId,
                SKU = last.SKU,
                LotNumber = last.LotNumber,
                //PackageQuantity = packageQuantity,
                UnitQuantity = unitQuantity,
                Warehouse = last.Warehouse,
                WarehouseId = last.WarehouseId,
                IsHold = last.IsHold,
                ExpirationDate = last.ExpirationDate,
                ProductionDate = last.ProductionDate,
                //GrossWeight = last.GrossWeight,
                Id = 0,
                Package = product.BasePackage,//last.Package,
                PackageId = product.BasePackageId, //last.PackageId,
                //Uom = last.Uom,
                //UomId = last.UomId,
                Rate = rate,
                Total = rate * unitQuantity,
            };
            return model;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            var msg = _inventoryUnitService.MergeInventoryUnits(_dataList);
            if (!string.IsNullOrEmpty(msg))
            {
                PopupMessage.ShowInfoMessage(msg);
                this.Focus();
            }
            else
            {
                PopupMessage.ShowSuccessMessage("Merged successfully.");
                this.Close();
            }
        }

    }
}
