using Infrastructure.Entities.Business;
using Infrastructure.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Inventory
{
    public class InventoryUnit
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }

        public int LotNumber { get; set; }
        public string ReceiveReceipt { get; set; }
        public string ReceiveAdjustment { get; set; } // adjustment code
        public DateTime? ReceiveDate { get; set; }
        public string IssueReceipt { get; set; }
        public string IssueAdjustment { get; set; }// adjustment code
        public DateTime? IssueDate { get; set; }

        public decimal UnitQuantity { get; set; }
        public decimal PackageQuantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Total{ get; set; }
        public decimal NetWeight { get; set; }
        public decimal GrossWeight { get; set; }

        public int UomId { get; set; }
        public virtual Uom Uom { get; set; }
        public int PackageId { get; set; }
        public virtual Package Package { get; set; }
        public int? SupplierId { get; set; }
        public virtual User Supplier { get; set; }

        public DateTime? ProductionDate { get; set; }
        public DateTime? ExpirationDate { get; set; }

        // include Shipped-To status also
        public bool IsHold { get; set; }


        public string Remark { get; set; }
        public string Notes { get; set; }


    }
}
