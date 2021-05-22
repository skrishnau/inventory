using Infrastructure.Context;

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
