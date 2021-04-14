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
                foreach (var warehouseWiseGroup in productWiseGroup.GroupBy(x => x.WarehouseId))
                {
                    //var first = invUnitGroup.First();
                    var last = warehouseWiseGroup.Last();
                    var unitQuantity = warehouseWiseGroup.Sum(x => x.UnitQuantity);
                    var rate = warehouseWiseGroup.Average(x => x.Rate);
                    var packageQuantity = warehouseWiseGroup.Sum(x => x.PackageQuantity);
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
                    };
                    displayList.Add(model);
                }
               
            }
            dgvInventoryUnit.AutoGenerateColumns = false;
            dgvInventoryUnit.DataSource = displayList;
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
