using Infrastructure.Entities.Inventory;
using Infrastructure.Entities.Users;
using System;

namespace Infrastructure.Entities.Orders
{
    public class OrderItem
    {
        public int Id { get; set; }
        // to which purchase transaction does this item belongs 
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        /// <summary>
        /// in case of sales, warehouse is not given(available) at first but we need to save the record, hence it's nullable
        /// </summary>
        public int? WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }

        public decimal UnitQuantity { get; set; }
        public decimal PackageQuantity { get; set; }
        // implement discount in rate in version 2
        public decimal Rate { get; set; }
        // totalAmount = quantity * rate 
        public decimal Total { get; set; }
        public decimal NetWeight { get; set; }
        public decimal GrossWeight { get; set; }

        public bool IsReceived { get; set; }
        public bool IsHold { get; set; }

        // in next version
        //public decimal Discount { get; set; }
        //public decimal Tax { get; set; }
        public int LotNumber { get; set; }
        public string Reference { get; set; }
        public string Adjustment { get; set; }

        public int? UomId { get; set; }
        public virtual Uom Uom { get; set; }
        public int? PackageId { get; set; }
        public virtual Package Package { get; set; }
        public int? SupplierId { get; set; }
        public virtual User Supplier { get; set; }

        public DateTime? ProductionDate { get; set; }
        public DateTime? ExpirationDate { get; set; }


        // items will be hard deleted; if the items need to be removed after "Sent" then cancel the whole order
        // an item can be cancelled by customer at any point during transaction
        // public DateTime? DeletedAt { get; set; }

        // ================= Table Objects ==================== //

    }
}
