using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Inventory
{
    public class WarehouseProductModel
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public string Warehouse { get; set; }
        public int ProductId { get; set; }
        public string Product { get; set; }
        public string SKU { get; set; }

        public decimal InStockQuantity { get; set; }
        public decimal OnOrderQuantity { get; set; }
        public decimal OnHoldQuantity { get; set; }

        public string UpdatedAt { get; set; }
    }
}
