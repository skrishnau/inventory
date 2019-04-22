using Infrastructure.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Inventory;

namespace DTO.Core.Inventory
{
    [Obsolete("Extra table for Brand is not to be done now", true)]
    public static class BrandMapper
    {
        public static List<BrandModel> MapToBrandModel(ICollection<Brand> brands)
        {
            var list = new List<BrandModel>();
            foreach(var brand in brands)
            {
                list.Add(new BrandModel()
                {
                    Name = brand.Name,
                    CreatedAt = brand.CreatedAt,
                    DeletedAt = brand.DeletedAt,
                    ProductId = brand.ProductId,
                    UpdatedAt = brand.UpdatedAt,
                    Id = brand.Id
                });
            }
            return list;
        }
    }
}
