using Infrastructure.Entities.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Purchases;
using ViewModel.Enums.Inventory.Purchases;

namespace DTO.Core.Purchases
{
    public static class PurchaseOrderMapper
    {
        public static PurchaseOrder MapToPurchaseOrderEntityForAdd(PurchaseOrderModel model, PurchaseOrder entity)
        {
            if (entity == null)
            {
                entity = new PurchaseOrder();
            }

            entity.ExpectedDate = model.ExpectedDate;
            entity.LotNo = model.LotNumber;
            entity.Name = model.Name;
            entity.Note = model.Note;
            entity.ReferenceNumber = model.OrderNumber;
            entity.SupplierId = model.SupplierId;
            entity.SupplierInvoice = model.SupplierInvoice;
            entity.WarehouseId = model.WarehouseId;
            // don't add other properties which are set individually, e.g. receivedAt, etc.

            return entity;
        }

        public static List<PurchaseOrderModel> MapToPurchaseOrderModel(IQueryable<PurchaseOrder> query)
        {
            var list = new List<PurchaseOrderModel>();
            foreach (var entity in query)
            {
                list.Add(MapToPurchaseOrderModel(entity));
            }
            return list;
        }

        public static PurchaseOrderModel MapToPurchaseOrderModel(PurchaseOrder entity)
        {
            var model = new PurchaseOrderModel();
            if (entity == null)
                return model;

            model.Id = entity.Id;
            model.LotNumber = entity.LotNo;
            model.Note = entity.Note;
            model.SupplierId = entity.SupplierId;
            // entity.CreatedAt = model.CreatedAt;
            model.ExpectedDate = entity.ExpectedDate;
            model.IsCancelled = entity.IsCancelled;
            model.CancelledDate = entity.CancelledDate;
            model.IsReceived = entity.IsReceived;
            model.ReceivedDate = entity.ReceivedDate;
            model.IsOrderSent = entity.IsOrderSent;
            model.OrderSentDate = entity.OrderSentDate;
            model.Name = entity.Name;
            model.OrderNumber = entity.ReferenceNumber;
            // entity.ParentPurchaseOrder = model.ParentPurchaseOrder;
            model.ParentPurchaseOrderId = entity.ParentPurchaseOrderId;
            model.Supplier = entity.Supplier == null ? "" : entity.Supplier.BasicInfo.Name;
            model.TotalAmount = entity.TotalAmount;
            //entity.UpdatedAt = model.UpdatedAt;
            model.Warehouse = entity.Warehouse == null ? "" : entity.Warehouse.Name;
            model.WarehouseId = entity.WarehouseId;
            model.SupplierInvoice = entity.SupplierInvoice;

            model.PurchaseOrderItems = PurchaseOrderItemMapper.MapToPurhaseOrderItemModel(entity.PurchaseOrderItems.AsQueryable());

            model.Status = entity.IsCancelled ? PurchaseOrderStatusEnum.Cancelled.ToString()
                : entity.IsReceived ? PurchaseOrderStatusEnum.Received.ToString()
                : entity.IsOrderSent ? PurchaseOrderStatusEnum.Sent.ToString()
                : PurchaseOrderStatusEnum.Open.ToString();

            return model;
        }
    }
}
