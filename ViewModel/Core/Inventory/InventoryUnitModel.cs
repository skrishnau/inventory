using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Inventory
{
    public class InventoryUnitModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Product { get; set; }
        public string SKU { get; set; }

        public int WarehouseId { get; set; }
        public string Warehouse { get; set; }

        public string ReceiveReceipt { get; set; }
        public string ReceiveDate { get; set; }
        public string ReceiveAdjustment { get; set; } // adjustment code

        public string IssueReceipt { get; set; }
        public string IssueDate { get; set; }
        public string IssueAdjustment { get; set; }// adjustment code

        public string  ProductionDate { get; set; }
        public string  ExpirationDate { get; set; }
        public string LotNumber { get; set; }
        public decimal NetWeight { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal UnitQuantity { get; set; }
        public int UomId { get; set; }
        public string Uom { get; set; }
        public decimal PackageQuantity { get; set; }
        public int PackageId { get; set; }
        public string Package { get; set; }

        public int? SupplierId { get; set; }
        public string Supplier { get; set; }

        // include shipped To status also
        public bool IsHold { get; set; }
        public decimal SupplyPrice { get; set; }


        public string Remark { get; set; }
        public string Notes { get; set; }

    }
}
