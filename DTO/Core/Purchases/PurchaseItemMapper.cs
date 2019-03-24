using Infrastructure.Entities.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Purchases;

namespace DTO.Core.Purchases
{
    public static class PurchaseItemMapper
    {
        public static PurchaseItem MapToPurchaseItemEntity(PurchaseItemModel model)
        {
            return new PurchaseItem()
            {
                DeletedAt = model.DeletedAt,
                Id = model.Id,
                PurchaseId = model.PurchaseId,
                Quantity = model.Quantity,
                Rate = model.Rate,
                TotalAmount = model.TotalAmount,
                VariantId = model.VariantId,
            };
        }

        public static List<PurchaseItem> MapToPurchaseItemEntity(ICollection<PurchaseItemModel> models)
        {
            var list = new List<PurchaseItem>();
            foreach(var model in models)
            {
                list.Add(new PurchaseItem()
                {
                    DeletedAt = model.DeletedAt,
                    Id = model.Id,
                    PurchaseId = model.PurchaseId,
                    Quantity = model.Quantity,
                    Rate = model.Rate,
                    TotalAmount = model.TotalAmount,
                    VariantId = model.VariantId,
                });
            }
            return list;
        }

        public static List<PurchaseItemModelForListing> MapToPurhaseItemModelForListing(IQueryable<PurchaseItem> query)
        {
            var list = new List<PurchaseItemModelForListing>();
            foreach(var model in query)
            {
                list.Add(new PurchaseItemModelForListing()
                {
                    Id = model.Id,
                    Quantity = model.Quantity,
                    Rate = model.Rate,
                    TotalAmount = model.TotalAmount,
                    Product = model.Variant.Product.Name,
                    SKU = model.Variant.SKU
                });
            }
            return list;
        }
    }
}
