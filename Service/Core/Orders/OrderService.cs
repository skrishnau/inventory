using DTO.Core.Inventory;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModel.Core.Inventory;
using ViewModel.Core.Orders;
using System.Data.Entity;
using Service.DbEventArgs;
using Service.Listeners;
using Infrastructure.Entities.Orders;
using Infrastructure.Entities.Inventory;
using Service.Core.Inventory.Units;
using ViewModel.Enums;

namespace Service.Core.Orders
{
    public class OrderService : IOrderService
    {

        //   private DatabaseContext _context;
        private readonly IDatabaseChangeListener _listener;
        private readonly IInventoryUnitService _inventoryUnitService;

        public OrderService(
            IDatabaseChangeListener listener,
            IInventoryUnitService inventoryUnitService
            )//DatabaseContext context,
        {
            //_context = context;
            _listener = listener;
            _inventoryUnitService = inventoryUnitService;
        }

        public List<OrderModel> GetAllOrders(OrderTypeEnum orderType)
        {
            using (var _context = new DatabaseContext())
            {

                var type = orderType.ToString();
                var purchases = _context.Order
                    .Include(x => x.Supplier.BasicInfo)
                    .Include(x => x.OrderItems)
                    //.Include(x=>x.Warehouse)
                    //.Include(x=>x.ToWarehouse)
                    .Where(x => x.OrderType == type)
                    .AsEnumerable();
                // return new List<PurchaseOrderModelForGridView>();
                return purchases.MapToModel();// OrderMapper.MapToOrderModel(purchases);
            }
        }

        public int GetNextLotNumber()
        {
            using (var _context = new DatabaseContext())
            {
                int lotNo = _context.Order.Any() ? _context.Order.Max(x => x.LotNumber) : 1;
                return ++lotNo;
            }
        }

        public List<OrderItemModel> GetPurchaseOrderItems(int purchaseOrderId)
        {
            using (var _context = new DatabaseContext())
            {
                var query = _context.OrderItem
                    .Include(x => x.Product)
                    .Where(x => x.PurchaseOrderId == purchaseOrderId);
                return OrderItemMapper.MapToPurhaseOrderItemModel(query);
            }
        }

        public void SaveOrder(OrderModel orderModel)
        {
            using (var _context = new DatabaseContext())
            {

                var now = DateTime.Now;
                var args = BaseEventArgs<OrderModel>.Instance;
                var entity = _context.Order.Find(orderModel.Id);
                entity = orderModel.MapToEntity(entity);// OrderMapper.MapToOrderEntityForAdd(purchaseOrderModel, entity);

                if (entity.Id == 0)
                {
                    entity.CreatedAt = now;
                    entity.UpdatedAt = now;
                    _context.Order.Add(entity);
                    args.Mode = Utility.UpdateMode.ADD;
                }
                else
                {
                    entity.UpdatedAt = now;
                    args.Mode = Utility.UpdateMode.EDIT;

                    // update the order items' warehouse
                    foreach (var item in _context.OrderItem.Where(x=>x.PurchaseOrderId == entity.Id))
                    {
                        item.WarehouseId = entity.WarehouseId;
                    }
                }
                _context.SaveChanges();
                args.Model = entity.MapToModel();// OrderMapper.MapToOrderModel(entity);
                _listener.TriggerPurchaseOrderUpdateEvent(null, args);
            }
        }

        public OrderModel GetOrder(OrderTypeEnum orderType, int orderId)
        {
            using (var _context = new DatabaseContext())
            {

                // don't use enum directly
                var type = orderType.ToString();
                var entity = _context.Order
                     .Include(x => x.Warehouse)
                     .Include(x=> x.ToWarehouse)
                     .Include(x => x.Supplier)
                     .Include(x => x.ParentOrder)
                     .Include(x => x.OrderItems)
                     .Include(x => x.Customer)
                     .Include(x => x.OrderItems.Select(y => y.Product))
                     .Include(x => x.OrderItems.Select(y => y.Warehouse))
                     .FirstOrDefault(x => x.Id == orderId && x.OrderType == type);
                return entity.MapToModel();// OrderMapper.MapToOrderModel(entity);
            }
        }

        public OrderModel GetOrderForDetailView( int orderId) //OrderTypeEnum orderType,
        {
            using (var _context = new DatabaseContext())
            {

                // don't use enum directly
               // var type = orderType.ToString();
                var entity = _context.Order
                     .Include(x => x.Warehouse)
                     .Include(x => x.ToWarehouse)
                     .Include(x => x.Supplier)
                     .Include(x => x.ParentOrder)
                     .Include(x => x.OrderItems)
                     .Include(x => x.Customer)
                     .Include(x => x.OrderItems.Select(y => y.Product))
                     .Include(x => x.OrderItems.Select(y => y.Warehouse))
                     .FirstOrDefault(x => x.Id == orderId ); //&& x.OrderType == type
                return entity.MapToModel(true);// OrderMapper.MapToOrderModel(entity);
            }
        }

        public List<InventoryUnitModel> GetInventoryUnitsOfPurchaseOrdeItems(ICollection<OrderItemModel> models)
        {
            return OrderItemMapper.MapToInventoryUnitModel(models);
        }

        public string SetSent(int orderId)
        {
            using (var _context = new DatabaseContext())
            {

                var entity = _context.Order.Find(orderId);
                if (entity != null)
                {
                    var orderType = Enum.Parse(typeof(OrderTypeEnum), entity.OrderType);
                    var verifiedAction = "";
                    var verifiyAction = "";
                    var executedAction = "";
                    switch (orderType)
                    {
                        case OrderTypeEnum.Purchase:
                            verifiedAction = "sent";
                            verifiyAction = "send";
                            executedAction = "received";
                            break;
                        case OrderTypeEnum.Sale:
                            verifiedAction = "packaged";
                            verifiyAction = "package";
                            executedAction = "issued";
                            break;
                        case OrderTypeEnum.Move:
                            verifiedAction = "sent";
                            verifiyAction = "send";
                            executedAction = "moved";
                            break;
                    }
                    
                    if (entity.IsVerified)
                        return "The Order is already " + verifiedAction;
                    else if (entity.IsExecuted)
                        return "This order has already been "+executedAction+". No need to send!";
                    else if (entity.IsCancelled)
                        return "This order is aleady cancelled. You can't "+verifiyAction+" a cancelled order";
                    entity.IsVerified = true;
                    entity.VerifiedDate = DateTime.Now;
                    _context.SaveChanges();
                    var args = new BaseEventArgs<OrderModel>(entity.MapToModel(), Utility.UpdateMode.EDIT);
                    _listener.TriggerPurchaseOrderUpdateEvent(null, args);
                    return string.Empty;
                }
                return "The Order doesn't exist";
            }
        }

        public string SetReceived(int orderId)
        {
            using (var _context = new DatabaseContext())
            {

                var now = DateTime.Now;
                var entity = _context.Order.Find(orderId);
                if (entity != null)
                {
                    if (!entity.IsVerified)
                        return "This order hasn't been sent yet. First send the order, then only you can receive against it.";
                    if (entity.IsCancelled)
                        return "You can't receive a cancelled order. This order is cancelled.";
                    if (entity.IsExecuted)
                        return "Already received!";
                    entity.IsExecuted = true;
                    entity.ExecutedDate = now;

                    AddReceivedItemsToWarehouse(entity.OrderItems, now);

                    _context.SaveChanges();
                    var args = new BaseEventArgs<OrderModel>(entity.MapToModel(), Utility.UpdateMode.EDIT);
                    _listener.TriggerPurchaseOrderUpdateEvent(null, args);
                    _listener.TriggerInventoryUnitUpdateEvent(null, null);
                    return string.Empty;
                }
                return "The Purchase Order doesn't exist";
            }
        }

        public string SetIssued(int orderId)
        {
            using (var _context = new DatabaseContext())
            {

                var now = DateTime.Now;
                var entity = _context.Order.Find(orderId);
                if (entity != null)
                {
                    if (!entity.IsVerified)
                        return "This order hasn't been packaged yet. First package the order, then only you can issue against it.";
                    if (entity.IsCancelled)
                        return "You can't issue a cancelled order. This order is cancelled.";
                    if (entity.IsExecuted)
                        return "Already issued!";
                    

                    var msg = SubtractIssuedItemsFromWarehouse(entity.OrderItems, now);
                    if (!string.IsNullOrEmpty(msg))
                        return msg;

                    entity.IsExecuted = true;
                    entity.ExecutedDate = now;

                    _context.SaveChanges();
                    var args = new BaseEventArgs<OrderModel>(entity.MapToModel(), Utility.UpdateMode.EDIT);
                    _listener.TriggerPurchaseOrderUpdateEvent(null, args);
                    _listener.TriggerInventoryUnitUpdateEvent(null, null);
                    return string.Empty;
                }
                return "The Order doesn't exist";
            }
        }

        public string SetCancelled(int orderId)
        {
            using (var _context = new DatabaseContext())
            {

                var entity = _context.Order.Find(orderId);
                if (entity != null)
                {
                    if (entity.IsExecuted)
                        return "You have already received against this order. You can't cancel it now.";
                    if (entity.IsCancelled)
                        return "Already cancelled!";
                    entity.IsCancelled = true;
                    entity.CancelledDate = DateTime.Now;
                    _context.SaveChanges();
                    var args = new BaseEventArgs<OrderModel>(entity.MapToModel(), Utility.UpdateMode.EDIT);
                    _listener.TriggerPurchaseOrderUpdateEvent(null, args);
                    return string.Empty;
                }
                return "The Order doesn't exist";
            }
        }

        public string SavePurchaseOrderItems(int purchaseOrderId, List<OrderItemModel> items)
        {
            using (var _context = new DatabaseContext())
            {

                var poEntity = _context.Order.Find(purchaseOrderId);
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

                var dbItems = _context.OrderItem.Where(x => x.PurchaseOrderId == purchaseOrderId).ToList();
                // first remove those that are not in the model list
                for (var i = 0; i < dbItems.Count(); i++)
                {
                    var entity = dbItems.ElementAt(i);
                    var stillExists = items.FirstOrDefault(x => x.Id == entity.Id);
                    if (stillExists == null)
                    {
                        _context.OrderItem.Remove(entity);
                    }
                }
                // second add/update
                foreach (var item in items)
                {
                    var entity = dbItems.FirstOrDefault(x => x.Id == item.Id);
                    entity = item.MapToEntity(entity);//OrderItemMapper.MapToEntity(item, entity);
                    if (entity.Id == 0)
                    {
                        // add
                        _context.OrderItem.Add(entity);
                    }
                    // No need to handle update cause entity is already assigned above { ....MapToEntity(..)}
                }
                _context.SaveChanges();
                var model = poEntity.MapToModel();// OrderMapper.MapToOrderModel(poEntity);
                var eventArgs = new BaseEventArgs<OrderModel>(model, Utility.UpdateMode.EDIT);
                _listener.TriggerPurchaseOrderUpdateEvent(null, eventArgs);
                return string.Empty;
            }
        }


        #region Inventory Units

        private void AddReceivedItemsToWarehouse(ICollection<OrderItem> items, DateTime now)
        {
            using (var _context = new DatabaseContext())
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
        }


        public void AddPOReceiveToInventoryUnit(OrderItem poItem, Product product, DateTime now)
        {
            using (var _context = new DatabaseContext())
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
                    WarehouseId = poItem.WarehouseId??0,
                };
                _inventoryUnitService.UpdateWarehouseProduct(invUnit.MapToModel(), invUnit.UnitQuantity, null, poItem.WarehouseId, now);
                _context.InventoryUnit.Add(invUnit);
            }
        }

        private string SubtractIssuedItemsFromWarehouse(ICollection<OrderItem> items, DateTime now)
        {
            var msg = _inventoryUnitService.SaveDirectIssueAny(items.MapToInventoryUnitModel(), "Issue");
            if (!string.IsNullOrEmpty(msg))
                return msg;
            // save was successful
            using (var _context = new DatabaseContext())
            {

                foreach (var item in items)
                {
                    var product = _context.Product.Find(item.ProductId);
                    if (product != null)
                    {
                        item.IsReceived = true;
                        //AddPOReceiveToInventoryUnit(item, product, now);
                    }
                }
                _context.SaveChanges();
            }
            return string.Empty;
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
