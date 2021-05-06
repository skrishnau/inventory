using Service.Core.Inventory;
using Service.Core.Inventory.Units;
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

namespace IMS.Forms.Inventory.Units.Actions
{
    public partial class InventoryMergeForm : Form
    {

        private readonly IInventoryUnitService _inventoryUnitService;

        private List<InventoryUnitModel> _dataList;

        public InventoryMergeForm(IInventoryUnitService inventoryUnitService)
        {
            _inventoryUnitService = inventoryUnitService;

            InitializeComponent();
        }

        public void SetData(List<InventoryUnitModel> list)
        {
            _dataList = list;

            PopulateData();

        }

        private void PopulateData()
        {
            var displayList = new List<InventoryUnitModel>();
            foreach (var productWiseGroup in _dataList.GroupBy(x => x.ProductId))
            {
                foreach (var warehouseWiseGroup1 in productWiseGroup.GroupBy(x => x.WarehouseId))
                {
                    var zeroRateOrderItemIdGroup = warehouseWiseGroup1.Where(x => x.Rate == 0).GroupBy(x => x.PurchaseOrderItemId); ;
                    foreach (var zwhg in zeroRateOrderItemIdGroup)
                    {
                        if (zwhg.Count() > 0)
                        {
                            var mergedModel = GetMergedModel(zwhg.ToList());
                            displayList.Add(mergedModel);
                        }
                    }

                    var withoutZeroRate = warehouseWiseGroup1.Where(x => x.Rate > 0).ToList();
                    if (withoutZeroRate.Count() > 0)
                    {
                        var mergedModel = GetMergedModel(withoutZeroRate);
                        displayList.Add(mergedModel);
                    }
                }

            }
            dgvInventoryUnit.AutoGenerateColumns = false;
            dgvInventoryUnit.DataSource = displayList;
        }

        private InventoryUnitModel GetMergedModel(List<InventoryUnitModel> withoutZeroRate)
        {
            //var first = invUnitGroup.First();
            var last = withoutZeroRate.Last();
            var unitQuantity = withoutZeroRate.Sum(x => x.UnitQuantity);
            var rate = withoutZeroRate.Sum(x => x.UnitQuantity * x.Rate) / withoutZeroRate.Sum(x => x.UnitQuantity);
            var packageQuantity = withoutZeroRate.Sum(x => x.PackageQuantity);
            var model = GetMergedModel(last, packageQuantity, unitQuantity, rate);
            return model;
        }

        private InventoryUnitModel GetMergedModel(InventoryUnitModel last, decimal packageQuantity, decimal unitQuantity, decimal rate)
        {
            var model = new InventoryUnitModel()
            {
                Product = last.Product,
                ProductId = last.ProductId,
                SKU = last.SKU,
                LotNumber = last.LotNumber,
                PackageQuantity = packageQuantity,
                UnitQuantity = unitQuantity,
                Warehouse = last.Warehouse,
                WarehouseId = last.WarehouseId,
                IsHold = last.IsHold,
                ExpirationDate = last.ExpirationDate,
                ProductionDate = last.ProductionDate,
                GrossWeight = last.GrossWeight,
                Id = 0,
                Package = last.Package,
                PackageId = last.PackageId,
                Uom = last.Uom,
                UomId = last.UomId,
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
            _inventoryUnitService.MergeInventoryUnits(_dataList);
            this.Close();
        }

    }
}
