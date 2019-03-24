using Infrastructure.Entities.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Purchases;

namespace DTO.Core.Purchases
{
    public static class PurchaseOrderMapper
    {
        public static PurchaseOrder MapToPurchaseOrderEntityForAdd(PurchaseOrderModel model)
        {
            return new PurchaseOrder()
            {
                Id = model.Id,
                ApprovedById = model.ApprovedById,
                ClosedOn = model.ClosedOn,
                CreatedById = model.CreatedById,
                LotNo = model.LotNo,
                Note = model.Note,
                OrderDate = model.OrderDate,
                PromisedDate = model.PromisedDate,
                PurchaseId = model.PurchaseId,
                ReceivedDate = model.ReceivedDate,
                RequestedById = model.RequestedById,
                RequestedDate = model.RequestedDate,
                SupplierId = model.SupplierId,
                WarehouseId = model.WarehouseId,
                // need to map for Add
                Purchase = PurchaseMapper.MapToPurchaseEntity(model.Purchase),
                
            };
        }
    }
}
