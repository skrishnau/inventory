using Infrastructure.Entities.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Purchases;

namespace DTO.Core.Purchases
{
    public static class PurchaseMapper
    {
        public static Purchase MapToPurchaseEntity(PurchaseModel model)
        {
            return new Purchase()
            {
                 CreatedAt = model.CreatedAt,
                 DeletedAt = model.DeletedAt,
                 Id = model.Id,
                 PurchaseItems = PurchaseItemMapper.MapToPurchaseItemEntity(model.PurchaseItems),
                 ReceiptNo = model.ReceiptNo,
                 SupplierId = model.SupplierId,
                 TotalAmount = model.TotalAmount,
            };
        }

        public static List<PurchaseOrderModelForGridView> MapToPurchaseModelForGridView(IEnumerable<Purchase> entities)
        {
            var list = new List<PurchaseOrderModelForGridView>();
            foreach(var entity in entities)
            {
                list.Add(new PurchaseOrderModelForGridView()
                {
                    Id = entity.Id,
                    ReceiptNo = entity.ReceiptNo,
                    Supplier = entity.Supplier == null ? "----------": entity.Supplier.BasicInfo.Name,
                    ItemsCount = entity.PurchaseItems.Count,
                    TotalAmount = entity.TotalAmount.ToString("##0.00"),
                    
                });
            }

            return list;
        }

    }
}
