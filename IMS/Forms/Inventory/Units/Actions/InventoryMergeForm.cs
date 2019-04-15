using Service.Core.Inventory;
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

        private readonly IInventoryService _inventoryService;

        private List<InventoryUnitModel> _dataList;

        public InventoryMergeForm(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;

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
            foreach (var invUnitGroup in _dataList.GroupBy(x => x.ProductId))
            {
                //var first = invUnitGroup.First();
                var last = invUnitGroup.Last();
                var unitQuantity = invUnitGroup.Sum(x => x.UnitQuantity);
                var packageQuantity = invUnitGroup.Sum(x => x.PackageQuantity);
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
                };
                displayList.Add(model);
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
            _inventoryService.MergeInventoryUnits(_dataList);
            this.Close();
        }

    }
}
