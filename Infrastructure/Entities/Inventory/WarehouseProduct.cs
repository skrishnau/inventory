using Infrastructure.Entities.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Inventory
{
    public class WarehouseProduct
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse{ get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public decimal InStockQuantity{ get; set; }
        public decimal OnHoldQuantity { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
