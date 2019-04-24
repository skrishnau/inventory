using DTO.Core.Inventory;
using DTO.Core.Purchases;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Inventory;
using ViewModel.Core.Purchases;
using System.Data.Entity;
using Service.DbEventArgs;
using Service.Listeners;
using Infrastructure.Entities.Purchases;
using Infrastructure.Entities.Inventory;
using Service.Core.Inventory.Units;

namespace Service.Core.Purchases.PurchaseOrders
{
    public class PurchaseService : IPurchaseService
    {

        private DatabaseContext _context;
        private readonly IDatabaseChangeListener _listener;
        private readonly IInventoryUnitService _inventoryUnitService;
        public PurchaseService(DatabaseContext context,
            IDatabaseChangeListener listener,
            IInventoryUnitService inventoryUnitService
            )
        {
            _context = context;
            _listener = listener;
            _inventoryUnitService = inventoryUnitService;
        }

        public List<PurchaseOrderModel> GetAllPurchaseOrders()
        {
            var purchases = _context.PurchaseOrder
                .Include(x => x.Supplier.BasicInfo)
                .Include(x => x.PurchaseOrderItems);
            // return new List<PurchaseOrderModelForGridView>();
            return PurchaseOrderMapper.MapToPurchaseOrderModel(purchases);
        }

        public int GetNextLotNumber()
        {
            int lotNo = _context.PurchaseOrder.Any() ? _context.PurchaseOrder.Max(x => x.LotNo) : 1;
            return ++lotNo;
        }

        public List<PurchaseOrderItemModel> GetPurchaseOrderItems(int purchaseOrderId)
        {
            var query = _context.PurchaseOrderItem
                .Include(x => x.Product)
                .Where(x => x.PurchaseOrderId == purchaseOrderId);
            return PurchaseOrderItemMapper.MapToPurhaseOrderItemModel(query);
        }

        public void SavePurchaseOrder(PurchaseOrderModel purchaseOrderModel)
        {
            var now = DateTime.Now;
            var args = BaseEventArgs<PurchaseOrderModel>.Instance;
            var entity = _context.PurchaseOrder.Find(purchaseOrderModel.Id);
            entity = PurchaseOrderMapper.MapToPurchaseOrderEntityForAdd(purchaseOrderModel, entity);

            if (entity.Id == 0)
            {
                entity.CreatedAt = now;
                entity.UpdatedAt = now;
                _context.PurchaseOrder.Add(entity);
                args.Mode = Utility.UpdateMode.ADD;
            }
            else
            {
                entity.UpdatedAt = now;
                args.Mode = Utility.UpdateMode.EDIT;
            }
            _context.SaveChanges();
            args.Model = PurchaseOrderMapper.MapToPurchaseOrderModel(entity);
            _listener.TriggerPurchaseOrderUpdateEvent(null, args);
        }

        public PurchaseOrderModel GetPurchaseOrder(int purchaseOrderId)
        {
            var entity = _context.PurchaseOrder
                 .Include(x => x.Warehouse)
                 .Include(x => x.Supplier)
                 .Include(x => x.ParentPurchaseOrder)
                 .Include(x => x.PurchaseOrderItems)
                 .Include(x => x.PurchaseOrderItems.Select(y => y.Product))
                 .Include(x => x.PurchaseOrderItems.Select(y => y.Warehouse))
                 .FirstOrDefault(x => x.Id == purchaseOrderId);
            return PurchaseOrderMapper.MapToPurchaseOrderModel(entity);
        }

        public List<InventoryUnitModel> GetInventoryUnitsOfPurchaseOrdeItems(ICollection<PurchaseOrderItemModel> models)
        {
            return PurchaseOrderItemMapper.MapToInventoryUnitModel(models);
        }

        public string SetSent(int purchaseOrderId)
        {
            var entity = _context.PurchaseOrder.Find(purchaseOrderId);
            if (entity != null)
            {
                if (entity.IsOrderSent)
                    return "The Order is already sent";
                else if (entity.IsReceived)
                    return "This order has already been received. No need to send!";
                else if (entity.IsCancelled)
                    return "This order is aleady cancelled. You can't send a cancelled order";
                entity.IsOrderSent = true;
                entity.OrderSentDate = DateTime.Now;
                _context.SaveChanges();
                var args = new BaseEventArgs<PurchaseOrderModel>(PurchaseOrderMapper.MapToPurchaseOrderModel(entity), Utility.UpdateMode.EDIT);
                _listener.TriggerPurchaseOrderUpdateEvent(null, args);
                return string.Empty;
            }
            return "The Purchase Order doesn't exist";
        }

        public string SetReceived(int purchaseOrderId)
        {
            var now = DateTime.Now;
            var entity = _context.PurchaseOrder.Find(purchaseOrderId);
            if (entity != null)
            {
                if (!entity.IsOrderSent)
                    return "This order hasn't been sent yet. First send the order, then only you can receive against it.";
                if (entity.IsCancelled)
                    return "You can't receive a cancelled order. This order is cancelled.";
                if (entity.IsReceived)
                    return "Already received!";
                entity.IsReceived = true;
                entity.ReceivedDate = now;

                AddReceivedItemsToWarehouse(entity.PurchaseOrderItems, now);

                _context.SaveChanges();
                var args = new BaseEventArgs<PurchaseOrderModel>(PurchaseOrderMapper.MapToPurchaseOrderModel(entity), Utility.UpdateMode.EDIT);
                _listener.TriggerPurchaseOrderUpdateEvent(null, args);
                _listener.TriggerInventoryUnitUpdateEvent(null, null);
                return string.Empty;
            }
            return "The Purchase Order doesn't exist";
        }


        public string SetCancelled(int purchaseOrderId)
        {
            var entity = _context.PurchaseOrder.Find(purchaseOrderId);
            if (entity != null)
            {
                if (entity.IsReceived)
                    return "You have already received against this order. You can't cancel it now.";
                if (entity.IsCancelled)
                    return "Already cancelled!";
                entity.IsCancelled = true;
                entity.CancelledDate = DateTime.Now;
                _context.SaveChanges();
                var args = new BaseEventArgs<PurchaseOrderModel>(PurchaseOrderMapper.MapToPurchaseOrderModel(entity), Utility.UpdateMode.EDIT);
                _listener.TriggerPurchaseOrderUpdateEvent(null, args);
                return string.Empty;
            }
            return "The Purchase Order doesn't exist";
        }

        public string SavePurchaseOrderItems(int purchaseOrderId, List<PurchaseOrderItemModel> items)
        {
            var poEntity = _context.PurchaseOrder.Find(purchaseOrderId);
            if (poEntity == null)
            {
                return "The Purchase Order doesn't exist.";
            }

            // validate & assign productId in the items; check if the sku exists
            foreach (var item in items)
            {
                if (item.UnitQuantity <= 0)
                {
                    return "Some of the items have zero quantity. Quantity must be greater than zero";
                }
                if (item.Rate <= 0)
                {
                    return "Some of the items have zero rate. Rates must be greater than zero";
                }
                if (item.ProductId == 0)
                {
                    var productEntity = _context.Product.FirstOrDefault(x => x.SKU == item.SKU);
                    if (productEntity == null)
                    {
                        return "Some of the items you provided are invalid!";
                    }
                    else
                    {
                        item.ProductId = productEntity.Id;
                        item.TotalAmount = item.Rate * item.UnitQuantity;
                    }
                }
            }

            var dbItems = _context.PurchaseOrderItem.Where(x => x.PurchaseOrderId == purchaseOrderId).ToList();
            // first remove those that are not in the model list
            for (var i = 0; i < dbItems.Count(); i++)
            {
                var entity = dbItems.ElementAt(i);
                var stillExists = items.FirstOrDefault(x => x.Id == entity.Id);
                if (stillExists == null)
                {
                    _context.PurchaseOrderItem.Remove(entity);
                }
            }
            // second add/update
            foreach (var item in items)
            {
                var entity = dbItems.FirstOrDefault(x => x.Id == item.Id);
                entity = PurchaseOrderItemMapper.MapToEntity(item, entity);
                if (entity.Id == 0)
                {
                    // add
                    _context.PurchaseOrderItem.Add(entity);
                }
                // need not handle update cause entity is already assigned above (entity = Pur...; line)
            }
            _context.SaveChanges();
            var model = PurchaseOrderMapper.MapToPurchaseOrderModel(poEntity);
            var eventArgs = new BaseEventArgs<PurchaseOrderModel>(model, Utility.UpdateMode.EDIT);
            _listener.TriggerPurchaseOrderUpdateEvent(null, eventArgs);
            return string.Empty;
        }


        #region Inventory Units

        private void AddReceivedItemsToWarehouse(ICollection<PurchaseOrderItem> items, DateTime now)
        {
            foreach (var item in items)
            {
                var product = _context.Product.Find(item.ProductId);
                if (product != null)
                {
                    item.IsReceived = true;
                    AddPOReceiveToInventoryUnit(item, product, now);
                }
            }
            _context.SaveChanges();
        }


        public void AddPOReceiveToInventoryUnit(PurchaseOrderItem poItem, Product product, DateTime now)
        {

            var invUnit = new InventoryUnit()
            {
                ExpirationDate = poItem.ExpirationDate,
                GrossWeight = poItem.UnitQuantity * product.UnitGrossWeight,
                IsHold = poItem.IsHold,
                IssueDate = null,
                IssueReceipt = null,
                IssueAdjustment = null,
                LotNumber = poItem.LotNumber,// == 0 ? "" : poItem.LotNumber.ToString(),
                NetWeight = poItem.UnitQuantity * product.UnitNetWeight,
                Notes = "",
                PackageId = product.PackageId,
                PackageQuantity = (Math.Ceiling(poItem.UnitQuantity / (product.UnitsInPackage == 0 ? 1 : product.UnitsInPackage))) + (product.UnitsInPackage == 0 ? 0 : (poItem.UnitQuantity % product.UnitsInPackage)),
                ProductId = poItem.ProductId,
                ProductionDate = poItem.ProductionDate,
                ReceiveDate = now,
                ReceiveReceipt = poItem.Reference,
                ReceiveAdjustment = poItem.Adjustment,
                Remark = null,
                SupplierId = poItem.SupplierId,
                SupplyPrice = poItem.Rate,
                UnitQuantity = poItem.UnitQuantity,
                UomId = product.BaseUomId,
                WarehouseId = poItem.WarehouseId,
            };
            _inventoryUnitService.UpdateWarehouseProduct(invUnit.MapToModel(), null, poItem.WarehouseId, now);
            _context.InventoryUnit.Add(invUnit);
        }

        #endregion

    }
}


/*
    var wp = _context.WarehouseProduct.FirstOrDefault(x => x.ProductId == item.ProductId && x.WarehouseId == item.WarehouseId);
    if (wp == null)
    {
        wp = new Infrastructure.Entities.Inventory.WarehouseProduct()
        {
            ProductId = item.ProductId,
            InStockQuantity = item.UnitQuantity,
            OnHoldQuantity = item.IsHold ? item.UnitQuantity : 0,
            UpdatedAt = DateTime.Now,
            WarehouseId = item.WarehouseId,
        };
        _context.WarehouseProduct.Add(wp);
    }
    else
    {
        wp.UpdatedAt = DateTime.Now;
        wp.InStockQuantity += item.UnitQuantity;
        wp.OnHoldQuantity += item.IsHold ? item.UnitQuantity : 0;
    }
    // update the product 
    product.OnHoldQuantity += item.IsHold ? item.UnitQuantity : 0;
    product.InStockQuantity += item.UnitQuantity;
 */
