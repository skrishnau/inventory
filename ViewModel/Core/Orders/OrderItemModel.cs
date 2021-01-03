using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Orders
{
   public class OrderItemModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string Product { get; set; }
        public string SKU { get; set; }

        public decimal InStockQuantity { get; set; }
        public decimal OnHoldQuantity { get; set; }
        public decimal OnOrderQuantity { get; set; }
        public decimal OnComittedQuantity { get; set; }
        
        public decimal UnitQuantity { get; set; }
        public decimal PackageQuantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Total { get; set; }

        public decimal NetWeight { get; set; }
        public decimal GrossWeight { get; set; }

        public bool IsReceived { get; set; }
        public bool IsHold { get; set; }

        public int PackageId { get; set; }
        public string Package { get; set; }
        public int? WarehouseId { get; set; }
        public string Warehouse { get; set; }

        public string ExpirationDate { get; set; }
        public string ProductionDate { get; set; }

        public int LotNumber { get; set; }
        public string Reference { get; set; }
        public string Adjustment { get; set; }

        public int UomId { get; set; }
        public string Uom { get; set; }
        public int? SupplierId { get; set; }
        public string Supplier { get; set; }

    }

    //public class PurchaseItemModelForListing
    //{
    //    public int Id { get; set; }
    //    public string SKU { get; set; }
    //    public string Product { get; set; }
    //    public decimal Quantity { get; set; }
    //    public decimal Rate { get; set; }
    //    public decimal TotalAmount { get; set; }
    //}
}
