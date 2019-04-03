using Infrastructure.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Inventory
{
    public class ProductAttributeModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Attribute { get; set; }

        public ProductAttribute ToEntity()
        {
            return new ProductAttribute()
            {
                Attribute = Attribute,
                ProductId = ProductId,
                Id = Id
            };
        }
    }
}
