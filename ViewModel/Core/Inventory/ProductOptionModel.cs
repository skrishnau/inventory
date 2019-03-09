using Infrastructure.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Inventory
{
    public class ProductOptionModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int OptionId { get; set; }

        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }


        public ProductOption ToEntity()
        {
            return new ProductOption()
            {
                OptionId = OptionId,
                CreatedAt = CreatedAt,
                DeletedAt = DeletedAt,
                ProductId = ProductId,
                UpdatedAt = UpdatedAt,
                Id = Id
            };
        }
    }
}
