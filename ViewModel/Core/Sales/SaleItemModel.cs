using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities.Sales;

namespace ViewModel.Core.Sales
{
    public class SaleItemModel
    {
        public int Id { get; set; }

        public string SKU { get; set; }

        public string ItemDescription { get; set; }

        public decimal Quantity { get; set; }

        public decimal Rate { get; set; }
        
        public decimal Total { get; set; }

        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public SaleItem ToEntity()
        {
            return new SaleItem
            {
                //CreatedAt = CreatedAt,
                DeletedAt = DeletedAt,
                Id = Id,
                ItemDescription = ItemDescription,
                Quantity = Quantity,
                Rate = Rate,
                SKU = SKU,
                TotalAmount = Total,
                //UpdatedAt = UpdatedAt
            };
        }

    }
}
