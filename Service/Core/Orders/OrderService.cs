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
using Service.Core.Settings;
using Infrastructure.Entities.Users;
using Service.Core.Users;
using Infrastructure.Entities;
using ViewModel.Core;
using System.Data.Entity.Core.Objects;
using Service.Interfaces;

namespace Service.Core.Orders
{
    public class OrderService : IOrderService
    {

        //   private DatabaseContext _context;
        private readonly IDatabaseChangeListener _listener;
        private readonly IInventoryUnitService _inventoryUnitService;
        private readonly IUserService _customerService;
        private readonly IAppSettingService _appSettingService;
        private readonly IProductService _productService;

        public OrderService(
            IDatabaseChangeListener listener,
            IInventoryUnitService inventoryUnitService,
            IUserService customerService,
            IAppSettingService appSettingSerivce,
            IProductService productService
            )//DatabaseContext context,
        {
            //_context = context;
            _listener = listener;
            _inventoryUnitService = inventoryUnitService;
            _customerService = customerService;
            _appSettingService = appSettingSerivce;
            _productService = productService;
        }

        #region Get Functions

        public int GetAllOrdersCount(OrderTypeEnum orderType, OrderListTypeEnum orderListType, string userSearchText, string receiptNoSearchText)
        {
            using (var _context = new DatabaseContext())
            {
                var orders = GetAllOrdersQuery(_context, orderType, orderListType, userSearchText, receiptNoSearchText);
                return orders.Count();
            }
        }

        // page size: no.of items per page; offset: current page number..
        public OrderListModel GetAllOrders(OrderTypeEnum orderType, OrderListTypeEnum orderListType, string userSearchText, string receiptNoSearchText, int pageSize, int offset)
        {
            using (var _context = new DatabaseContext())
            {
                var orders = GetAllOrdersQuery(_context, orderType, orderListType, userSearchText, receiptNoSearchText);
                var totalCount = orders.Count();
                if (pageSize > 0 && offset >= 0)
                {
                    orders = orders.Skip(offset).Take(pageSize);
                }
                var list = orders
                .AsEnumerable()
                .MapToModel();
                return new OrderListModel
                {
                    OrderList = list,
                    TotalCount = totalCount
                };
            }
        }
        private IQueryable<Order> GetAllOrdersQuery(DatabaseContext _context, OrderTypeEnum orderType, OrderListTypeEnum orderListType, string userSearchText, string receiptNoSearchText)
        {
            var split = string.IsNullOrEmpty(userSearchText) ? new string[0] : userSearchText.Split(new char[] { '-' });
            var name = split.Length > 0 ? split[0].Trim() : "";
            var company = split.Length > 1 ? split[1].Trim() : "";
            var type = orderType.ToString();
            var orders = _context.Order
                .Include(x => x.User)
                .Include(x => x.OrderItems);
            if (orderListType == OrderListTypeEnum.Transaction)
            {
                orders = orders.Where(x => x.IsCompleted).OrderByDescending(x => x.CompletedDate); ;
            }
            else
            {
                orders = orders.Where(x => !x.IsCompleted).OrderByDescending(x => x.UpdatedAt);
            }
            if (orderType != OrderTypeEnum.All)
                orders = orders.Where(x => x.OrderType == type);

            if (!string.IsNullOrEmpty(userSearchText))
                orders = orders.Where(x => x.User.Name.Contains(name) || x.User.Company.Contains(name));
            if (!string.IsNullOrEmpty(receiptNoSearchText))
                orders = orders.Where(x => x.ReferenceNumber == receiptNoSearchText);
            return orders;
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
                    .Where(x => x.OrderId == purchaseOrderId);
                return OrderItemMapper.MapToOrderItemModel(query);
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
                     .Include(x => x.ToWarehouse)
                     .Include(x => x.User)
                     .Include(x => x.ParentOrder)
                     .Include(x => x.OrderItems)
                     .Include(x => x.User)
                     .Include(x => x.OrderItems.Select(y => y.Product))
                     .Include(x => x.OrderItems.Select(y => y.Warehouse))
                     .FirstOrDefault(x => x.Id == orderId && x.OrderType == type);
                return entity.MapToModel();// OrderMapper.MapToOrderModel(entity);
            }
        }

        public OrderModel GetOrderForDetailView(int orderId) //OrderTypeEnum orderType,
        {
            using (var _context = new DatabaseContext())
            {
                // don't use enum directly
                // var type = orderType.ToString();
                var entity = _context.Order
                     .Include(x => x.Warehouse)
                     .Include(x => x.ToWarehouse)
                     .Include(x => x.User)
                     .Include(x => x.ParentOrder)
                     .Include(x => x.OrderItems)
                     .Include(x => x.User)
                     .Include(x => x.OrderItems.Select(y => y.Product))
                     .Include(x => x.OrderItems.Select(y => y.Warehouse))
                     .FirstOrDefault(x => x.Id == orderId); //&& x.OrderType == type
                return entity.MapToModel(true);// OrderMapper.MapToOrderModel(entity);
            }
        }

        public List<InventoryUnitModel> GetInventoryUnitsOfPurchaseOrdeItems(ICollection<OrderItemModel> models)
        {
            return OrderItemMapper.MapToInventoryUnitModel(models);
        }



        #endregion


        #region Set Functions

        //public ResponseModel<OrderModel> SaveVerifiedTransaction(OrderModel orderModel, bool checkout)
        //{
        //    var message = "";
        //    var isVerified = false;
        //    var isCompleted = false;
        //    using (var _context = new DatabaseContext())
        //    {
        //        var dbEntity = _context.Order.Find(orderModel.Id);
        //        isVerified = dbEntity?.IsVerified ?? false;
        //        isCompleted = dbEntity?.IsCompleted ?? false;
        //        var entity = orderModel.MapToEntity(dbEntity);
        //        entity.IsVerified = isVerified;
        //        entity.IsCompleted = isCompleted;

        //        // below line
        //        SaveOrderItemsWithoutCommit(_context, entity, orderModel.OrderItems.ToList(), checkout, ref message);
        //        if (!string.IsNullOrEmpty(message))
        //            return new ResponseModel<OrderModel> { Message = message, Success = false };

        //    }
        //}

        public ResponseModel<OrderModel> SaveOrderForRateUpdate(OrderModel orderModel, bool checkout)
        {
            // NOTE: in case of zerorateupdate of a purchase txn, we need to update all the sell transaction and txnItem haveing orderItemId as this orderItem Id
            // AND in csse of zero rate update, we should NOT update any inventory Unit, we will update only transactions
            using (var _context = new DatabaseContext())
            {
                var entity = _context.Order.Find(orderModel.Id);
                if (entity != null)
                {
                    List<Transaction> sellTxns = new List<Transaction>();
                    List<TransactionItem> allTxnItems = new List<TransactionItem>();
                    List<InventoryUnit> allInventoryUnits = new List<InventoryUnit>();
                    foreach (var item in orderModel.OrderItems)
                    {
                        var orderItem = entity.OrderItems.FirstOrDefault(x => x.Id == item.Id);
                        if (orderItem != null)
                        {
                            foreach(var inv in orderItem.InventoryUnits)
                            {
                                inv.Rate = item.Rate;
                            }
                            orderItem.Rate = item.Rate;
                            orderItem.Total = item.Rate * orderItem.UnitQuantity;
                            UpdateProductForOrderItemSaveWithoutCommit(_context, entity, orderItem);
                            // 1. update transaction Items
                            var txnItems = _context.TransactionItem.Where(x => x.PurchaseOrderItemId == orderItem.Id).ToList();
                            foreach (var inv in txnItems)
                            {
                                inv.CostPriceRate = orderItem.Rate;
                                inv.CostPriceTotal = inv.CostPriceRate * inv.UnitQuantity;
                                sellTxns.Add(inv.Transaction);
                                allTxnItems.Add(inv);
                            }
                        }
                    }
                    foreach (var txn in sellTxns.Distinct())
                    {
                        txn.CostPriceTotal = txn.TransactionItems.Sum(x => x.CostPriceTotal);
                        txn.Order.CostPriceTotal = txn.CostPriceTotal;
                        foreach (var oi in txn.Order.OrderItems)
                        {
                            var ti = allTxnItems.Where(x => x.SaleOrderItemId == oi.Id);
                            oi.CostPriceRate = ti.Sum(x => x.CostPriceRate * x.UnitQuantity) / ti.Sum(x => x.UnitQuantity);
                            oi.CostPriceTotal = oi.UnitQuantity * oi.CostPriceRate;
                        }
                    }
                    // order 
                    entity.TotalAmount = entity.OrderItems.Sum(x => x.Total);
                    entity.IsCompleted = true;
                    // transactions
                    var user = CheckAndAssignCustomer(_context, ref orderModel, ref entity, checkout);
                    if (!orderModel.OrderItems.Any(x => x.Rate <= 0))
                    {
                        var transaction = GetTransactionWithoutCommit(_context, orderModel);
                        transaction.CostPriceTotal = entity.CostPriceTotal;
                        if (user != null)
                        {
                            user.Transactions.Add(transaction);
                        }
                        entity.Transactions.Add(transaction);
                    }
                }
                _context.SaveChanges();
                var args = BaseEventArgs<OrderModel>.Instance;
                args.Mode = Utility.UpdateMode.EDIT;
                args.Model = entity.MapToModel();// OrderMapper.MapToOrderModel(entity);

                _listener.TriggerOrderUpdateEvent(null, args);
                _listener.TriggerProductUpdateEvent(null, null);
                _listener.TriggerUserUpdateEvent(null, null);
                _listener.TriggerInventoryUnitUpdateEvent(null, null);
                var newOrder = _context.Order.Find(entity.Id)?.MapToModel(true);
                return new ResponseModel<OrderModel> { Data = newOrder, Message = string.Empty, Success = true };
            }
        }

        public ResponseModel<OrderModel> SaveOrder(OrderModel orderModel, bool checkout)
        {
            // Zero-Rate Update case 
            // in case of zerorateupdate of a purchase txn, we need to update all the sell transaction and txnItem haveing orderItemId as this orderItem Id
            // AND in csse of zero rate update, we should NOT update any inventory Unit, we will update only transactions
            if (orderModel.IsVerified)
                return SaveOrderForRateUpdate(orderModel, checkout);

            var message = "";
            var isEditMode = orderModel.Id > 0;
            var now = DateTime.Now;
            var args = BaseEventArgs<OrderModel>.Instance;
            var voiding = false; // flag to indicate if we are voiding one txn and creating another
            var isVerified = false;
            var isCompleted = false;
            using (var _context = new DatabaseContext())
            {
                var dbEntity = _context.Order.Find(orderModel.Id);
                isVerified = dbEntity?.IsVerified ?? false;
                isCompleted = dbEntity?.IsCompleted ?? false;
                var entity = orderModel.MapToEntity(dbEntity);
                entity.IsVerified = isVerified;
                entity.IsCompleted = isCompleted;
                // first update void case if any
                if (entity.Id == 0 && entity.ParentOrderId > 0)
                {
                    voiding = true;
                    // means that a completed order has been edited 
                    // the completed / previous order is to be made void and new order has to be created
                    UndoOrderTransactionsWithoutCommit(_context, entity.ParentOrderId);
                    UndoInventoryItemsWithoutCommit(_context, entity.ParentOrderId);
                }
                var user = CheckAndAssignCustomer(_context, ref orderModel, ref entity, checkout);

                var txnItemsList = new List<TransactionItem>();
                SaveOrderItemsWithoutCommit(_context, entity, orderModel.OrderItems.ToList(), checkout, ref message, ref txnItemsList);
                // items summary in order
                entity.TotalAmount = entity.OrderItems.Sum(x => x.Total);
                if (entity.OrderItems.Any(x => (x.CostPriceTotal ?? 0) == 0))
                    entity.CostPriceTotal = 0;
                else
                    entity.CostPriceTotal = entity.OrderItems.Sum(x => x.CostPriceTotal);

                if (!string.IsNullOrEmpty(message))
                    return new ResponseModel<OrderModel> { Message = message, Success = false };

                if (checkout)
                {
                    // makecheckout
                    MakeCheckout(_context, ref entity, ref orderModel);
                    // add transaction for new checkout ; don't add txn for zero rate case
                    if (!orderModel.OrderItems.Any(x => x.Rate <= 0))
                    {
                        var transaction = GetTransactionWithoutCommit(_context, orderModel);
                        transaction.CostPriceTotal = entity.CostPriceTotal;
                        if (user != null)
                        {
                            user.Transactions.Add(transaction);
                        }
                        if (entity.OrderType == OrderTypeEnum.Sale.ToString())
                        {
                            foreach (var txnItem in txnItemsList.Where(x => x.PurchaseOrderItem != null || x.PurchaseOrderItemId > 0 || x.CostPriceRate > 0).ToList())
                                transaction.TransactionItems.Add(txnItem);
                        }
                        entity.Transactions.Add(transaction);
                    }
                }
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
                    foreach (var item in _context.OrderItem.Where(x => x.OrderId == entity.Id))
                    {
                        item.WarehouseId = entity.WarehouseId;
                    }
                }
                if (checkout && !isVerified)
                {
                    _appSettingService.IncrementBillIndexWithoutCommit(_context, (ReferencesTypeEnum)Enum.Parse(typeof(ReferencesTypeEnum), orderModel.OrderType));
                }
                else
                {
                    entity.ReferenceNumber = null;
                }
                _context.SaveChanges();
                args.Model = entity.MapToModel();// OrderMapper.MapToOrderModel(entity);

                _listener.TriggerOrderUpdateEvent(null, args);
                _listener.TriggerProductUpdateEvent(null, null);
                _listener.TriggerPackageUpdateEvent(null, null);
                _listener.TriggerUserUpdateEvent(null, null);
                _listener.TriggerInventoryUnitUpdateEvent(null, null);
                var newOrder = _context.Order.Find(entity.Id)?.MapToModel(true);
                return new ResponseModel<OrderModel> { Data = newOrder, Message = string.Empty, Success = true };
            }
        }

        private void UndoOrderTransactionsWithoutCommit(DatabaseContext _context, int? parentOrderId)
        {
            var parent = _context.Order.Find(parentOrderId);
            if (parent != null)
            {
                parent.IsVoid = true;
                // transaction void
                foreach (var txn in parent.Transactions)
                {
                    txn.IsVoid = true;
                }
                // user due date
                if (parent.User != null)
                {
                    parent.User.PaymentDueDate = null;
                }

                // product count restore
                foreach (var item in parent.OrderItems)
                {
                    if (parent.OrderType == OrderTypeEnum.Sale.ToString())
                        item.Product.InStockQuantity += item.UnitQuantity;
                    else
                        item.Product.InStockQuantity -= item.UnitQuantity;
                }
            }
        }

        private void UndoInventoryItemsWithoutCommit(DatabaseContext _context, int? parentOrderId)
        {
            var order = _context.Order.FirstOrDefault(x => x.Id == parentOrderId);
            if (order != null)
            {
                var items = _context.OrderItem.Where(x => x.OrderId == parentOrderId);
                foreach (var oitem in items)
                {
                    if (order.OrderType == OrderTypeEnum.Sale.ToString())
                    {
                        var msg = _inventoryUnitService.SaveDirectReceiveListWithoutCommit(_context, order.OrderItems.MapToInventoryUnitModel(OrderTypeEnum.Sale), DateTime.Now, "Order Cancelled");
                    }
                    else if (order.OrderType == OrderTypeEnum.Purchase.ToString())
                    {
                        var msg = _inventoryUnitService.SaveDirectIssueAnyListWithoutCommit(_context, order.OrderItems.MapToInventoryUnitModel(OrderTypeEnum.Purchase), "Order Cancelled");
                    }
                }
            }
        }

        private void MakeCheckout(DatabaseContext _context, ref Order entity, ref OrderModel orderModel)
        {
            if (!orderModel.OrderItems.Any(x => x.Rate == 0))
            {
                entity.IsCompleted = true;
                //entity.CompletedDate = DateTime.Now; // completed date already set by user from UI
            }
            entity.IsVerified = true;
            entity.VerifiedDate = DateTime.Now;
            //if (orderModel.OrderType == OrderTypeEnum.Sale.ToString())
            //    SubtractIssuedItemsFromWarehouse(entity.OrderItems);
            //else if (orderModel.OrderType == OrderTypeEnum.Purchase.ToString())
            //    AddReceivedItemsToWarehouse(entity.OrderItems, DateTime.Now);
        }

        public static Transaction GetTransactionWithoutCommit(DatabaseContext _context, OrderModel orderModel)
        {
            var debit = 0M;
            var credit = 0M;
            var totalAmt = orderModel.SumAmount;//orderModel.TotalAmount - orderModel.DiscountAmount;
            var balance = totalAmt - orderModel.PaidAmount;
            if (orderModel.OrderType == OrderTypeEnum.Purchase.ToString() || orderModel.OrderType == PaymentTypeEnum.Debit.ToString())
            {
                debit = orderModel.PaidAmount;
                credit = totalAmt;//orderModel.TotalAmount;
            }
            else if (orderModel.OrderType == OrderTypeEnum.Sale.ToString() || orderModel.OrderType == PaymentTypeEnum.Credit.ToString())
            {
                debit = totalAmt;//orderModel.TotalAmount;
                credit = orderModel.PaidAmount;
            }
            balance = credit - debit;

            var transaction = new Transaction
            {
                Balance = Math.Abs(balance),
                Credit = credit,//orderModel.PaidAmount,
                Date = orderModel.CompletedDate ?? DateTime.Now,
                Debit = debit, //orderModel.TotalAmount,
                DrCr = Math.Sign(balance),
                IsVoid = false,
                //OrderId = orderModel.Id > 0 ? (int?)orderModel.Id : null, // don't add orderid
                Particulars = orderModel.ReferenceNumber,
                //UserId = orderModel.UserId > 0 ? (int?)orderModel.UserId : null, // don't add userid
                Type = orderModel.OrderType,
            };
            //_context.Transaction.Add(transaction);
            return transaction;
        }

        private User CheckAndAssignCustomer(DatabaseContext _context, ref OrderModel orderModel, ref Order entity, bool checkout)
        {
            User user = null;
            if (orderModel.UserId > 0)
            {
                user = _context.User.Find(orderModel.UserId);
                if (user != null)
                {
                    user.Address = orderModel.Address;
                    user.Phone = orderModel.Phone;
                }
            }
            else if (string.IsNullOrEmpty(orderModel.User))
            {
                orderModel.UserId = null;
            }
            else
            {
                // below code executes if userId is null but manual input of user-name is present 
                user = new User
                {
                    CreatedAt = DateTime.Now,
                    Phone = orderModel.Phone,
                    Address = orderModel.Address,
                    Name = orderModel.User,
                    UpdatedAt = DateTime.Now,
                    DeletedAt = null,
                    DOB = null,
                    DeliveryAddress = orderModel.Address,
                    Use = true,
                    //PaidAmount = checkout ? orderModel.PaidAmount : 0,
                    //TotalAmount = checkout ? orderModel.TotalAmount : 0,
                    UserType = orderModel.OrderType == OrderTypeEnum.Sale.ToString() ? UserTypeEnum.Customer.ToString() : UserTypeEnum.Supplier.ToString(),
                };

                entity.User = user;
            }
            if (user != null && checkout && orderModel.PaidAmount < orderModel.SumAmount)
            {
                // credit ; store payment due date in the customer
                user.PaymentDueDate = orderModel.PaymentDueDate;
            }

            return user;
        }

        public string SetCancelled(int orderId)
        {
            using (var _context = new DatabaseContext())
            {

                var entity = _context.Order.Find(orderId);
                if (entity != null)
                {
                    if (entity.IsCompleted)
                        return "You have already received against this order. You can't cancel it now.";
                    if (entity.IsCancelled)
                        return "Already cancelled!";
                    entity.IsCancelled = true;
                    entity.CancelledDate = DateTime.Now;
                    _context.SaveChanges();
                    var args = new BaseEventArgs<OrderModel>(entity.MapToModel(), Utility.UpdateMode.EDIT);
                    _listener.TriggerOrderUpdateEvent(null, args);
                    return string.Empty;
                }
                return "The Order doesn't exist";
            }
        }

        private void SaveOrderItemsWithoutCommit(DatabaseContext _context, Order order, List<OrderItemModel> items, bool checkout, ref string message, ref List<TransactionItem> txnItemsList)
        {
            // var transactionItems = new List<TransactionItem>();
            var newProductList = new List<Product>();
            var newPackageList = new List<Package>();
            if (order == null)
            {
                message += "The Order doesn't exist.\n";
                return;
            }

            // validate & assign productId in the items; check if the sku exists
            foreach (var item in items)
            {
                if (item.UnitQuantity <= 0 && checkout)
                {
                    message += "Some of the items have zero quantity. Quantity must be greater than zero\n";
                    return;
                }
                if (item.Rate <= 0 && checkout && order.OrderType == OrderTypeEnum.Sale.ToString())
                {
                    message += "Some of the items have zero rate. Rates must be greater than zero\n";
                    return;
                }
                if (item.ProductId == 0)
                {
                    item.Product = item.Product.Trim();
                    var productEntity = _context.Product.FirstOrDefault(x => !x.IsDiscontinued && (x.Name == item.Product || x.SKU == item.Product));
                    if (productEntity != null)
                    {
                        item.ProductId = productEntity.Id;
                    }
                }
                item.Total = item.Rate * item.UnitQuantity;
                if ((item.PackageId ?? 0) == 0)
                {
                    var packageEntity = _context.Package.FirstOrDefault(x => x.Name == item.Package);
                    if (packageEntity != null)
                    {
                        item.PackageId = packageEntity.Id;
                    }
                }
            }

            var dbItems = order.OrderItems.Where(x => x.OrderId == order.Id).ToList();
            // first remove those that are not in the model list
            for (var i = 0; i < dbItems.Count(); i++)
            {
                var entity = dbItems.ElementAt(i);
                var stillExists = items.FirstOrDefault(x => x.Id == entity.Id);
                if (stillExists == null)
                {
                    _context.OrderItem.Remove(entity);
                    //order.OrderItems.Remove(entity);
                }
            }
            // second add/update
            foreach (var item in items)
            {
                //var rate = _inventoryUnitService.GetRate(item.ProductId, order.CompletedDate);
                Product product = null;
                var warehouse = _inventoryUnitService.FindWarehouseOrReturnMainWarehouse(_context, item.WarehouseId);
                item.WarehouseId = warehouse.Id;
                if (item.ProductId == 0 && string.IsNullOrEmpty(item.Product))
                    continue;
                var entity = dbItems.FirstOrDefault(x => x.Id == item.Id);
                //var entity = item.MapToEntity(null);//OrderItemMapper.MapToEntity(item, entity);
                entity = item.MapToEntity(entity);
                if ((entity.PackageId ?? 0) == 0)
                {
                    if (!string.IsNullOrEmpty(item.Package))
                    {
                        var packageInNewList = newPackageList.FirstOrDefault(x => x.Name.Equals(item.Package, StringComparison.OrdinalIgnoreCase));
                        if (packageInNewList == null)
                        {
                            var package = new Package
                            {
                                Use = true,
                                Name = item.Package,
                            };
                            entity.Package = package;
                            newPackageList.Add(package);
                        }
                        else
                        {
                            entity.Package = packageInNewList;
                        }
                    }
                    else
                    {
                        entity.PackageId = null;
                    }
                }
                if (entity.ProductId == 0)
                {
                    product = newProductList.FirstOrDefault(x => x.Name.Equals(item.Product, StringComparison.OrdinalIgnoreCase));
                    if (product == null)
                    {
                        // create prouct 
                        product = new Product
                        {
                            Use = true,
                            Name = item.Product,
                            SKU = item.Product,
                            CategoryId = null,
                           // BaseUomId = null,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            //PackageId = entity.PackageId > 0 ? entity.PackageId: 0//item.PackageId,
                            WarehouseId = null,
                            SupplyPrice = order.OrderType == OrderTypeEnum.Purchase.ToString() ? item.Rate : 0,
                            RetailPrice = order.OrderType == OrderTypeEnum.Sale.ToString() ? item.Rate : 0,
                        };
                        //if (entity.PackageId > 0)
                        //    product.PackageId = entity.PackageId;
                        //else
                        //    product.Package = entity.Package;
                        entity.Product = product;
                        newProductList.Add(product);
                    }
                    else
                    {
                        entity.Product = product;
                    }
                }
                if (entity.Id == 0)
                {
                    // add
                    order.OrderItems.Add(entity);
                }
                // No need to handle update cause entity is already assigned above { ....MapToEntity(..)}

                // modify product inStock & OnHold quantity
                if (checkout)
                {
                    List<InventoryUnit> invUnits = null;
                    UpdateProductForOrderItemSaveWithoutCommit(_context, order, entity);

                    if (order.OrderType == OrderTypeEnum.Purchase.ToString())
                    {
                        entity.Supplier = order.User;
                        entity.SupplierId = order.UserId;
                        var invUnit = _inventoryUnitService.SaveDirectReceiveItemWithoutCommit(_context, entity.MapToInventoryUnitModel((OrderTypeEnum)Enum.Parse(typeof(OrderTypeEnum), order.OrderType)), order.CompletedDate ?? DateTime.Now, "PO Receive", ref message, product, order.ReferenceNumber, entity);
                    }
                    else if (order.OrderType == OrderTypeEnum.Sale.ToString())
                    {
                        invUnits = _inventoryUnitService.SaveDirectIssueAnyItemWithoutCommit(_context, entity.MapToInventoryUnitModel((OrderTypeEnum)Enum.Parse(typeof(OrderTypeEnum), order.OrderType)), "SO Issue", ref message);
                        var invUnitsQty = invUnits.Sum(x => x.UnitQuantity);
                        if (invUnits.Count > 0 && invUnitsQty > 0 && !invUnits.Any(x => x.Rate == 0))
                        {
                            entity.CostPriceRate = invUnits.Sum(x => x.UnitQuantity * x.Rate) / invUnitsQty;
                            entity.CostPriceTotal = entity.UnitQuantity * entity.CostPriceRate;
                        }
                        foreach (var inv in invUnits)
                        {
                            txnItemsList.Add(new TransactionItem
                            {
                                PurchaseOrderItemId = inv.OrderItemId,
                                SaleOrderItem = entity,
                                CostPriceRate = inv.Rate,
                                UnitQuantity = inv.UnitQuantity,
                                CostPriceTotal = inv.Rate * inv.UnitQuantity,
                            });
                        }

                    }


                }
            }


        }

        private void UpdateProductForOrderItemSaveWithoutCommit(DatabaseContext _context, Order order, OrderItem entity)
        {
            var product = entity.Product;
            if (product == null)
                product = _context.Product.Find(entity.ProductId);
            if (product != null)
            {
                _productService.AddPriceHistoryWithoutCommit(product, entity.Rate, order.OrderType, order.CompletedDate, entity.Package, entity.PackageId);
                product.UpdatedAt = DateTime.Now;
            }
        }

        public string SavePurchaseOrderItems(int orderId, List<InventoryUnitModel> items)
        {
            return SavePurchaseOrderItems(orderId, InventoryUnitMapper.MapToOrderItemModel(items, orderId));
        }
        public string SavePurchaseOrderItems(int purchaseOrderId, List<OrderItemModel> items)
        {
            using (var _context = new DatabaseContext())
            {
                var message = "";
                var poEntity = _context.Order.Find(purchaseOrderId);
                var txnItemList = new List<TransactionItem>();
                SaveOrderItemsWithoutCommit(_context, poEntity, items, false, ref message, ref txnItemList);

                _context.SaveChanges();
                var model = poEntity.MapToModel();// OrderMapper.MapToOrderModel(poEntity);
                var eventArgs = new BaseEventArgs<OrderModel>(model, Utility.UpdateMode.EDIT);
                _listener.TriggerOrderUpdateEvent(null, eventArgs);
                return string.Empty;
            }
        }

        #region Unused Functions for now
        /*
       // will never be used
        private void UndoInventoryItemsWithoutCommit(DatabaseContext _context, int? parentOrderId)
        {
            var order = _context.Order.FirstOrDefault(x => x.Id == parentOrderId);
            if (order != null)
            {
                var items = _context.OrderItem.Where(x => x.OrderId == parentOrderId);
                foreach (var oitem in items)
                {
                    if (order.OrderType == OrderTypeEnum.Sale.ToString())
                    {
                        var unitFound = false;
                        var viaQty = _context.InventoryUnit.FirstOrDefault(x => x.ProductId == oitem.ProductId && x.UnitQuantity == oitem.UnitQuantity);
                        if (viaQty != null)
                        {
                            _context.InventoryUnit.Remove(viaQty);
                            unitFound = true;
                        }
                        if (!unitFound)
                        {
                            var units = _context.InventoryUnit.Where(x => x.ProductId == oitem.ProductId)
                           .OrderBy(x => x.UnitQuantity);
                            decimal sum = 0;
                            foreach (var unit in units)
                            {
                                if ((sum + unit.UnitQuantity) <= oitem.UnitQuantity)
                                {
                                    _context.InventoryUnit.Remove(unit);
                                    sum += unit.UnitQuantity;
                                }
                                else
                                {
                                    var remainQty = unit.UnitQuantity - (oitem.UnitQuantity - sum);
                                    if (remainQty < 0)
                                    {
                                        _context.InventoryUnit.Remove(unit);
                                    }
                                    else
                                    {
                                        unit.UnitQuantity = remainQty;
                                        sum = oitem.UnitQuantity;
                                    }
                                }
                                if (sum >= oitem.UnitQuantity)
                                {
                                    break;
                                }
                            }
                        }
                        // todo for multiple warehouse case
                        var wp = _context.WarehouseProduct.FirstOrDefault(x => x.ProductId == oitem.ProductId);
                        if (wp != null)
                            wp.InStockQuantity -= oitem.UnitQuantity;
                        var product = _context.Product.FirstOrDefault(x => x.Id == oitem.ProductId);
                        if (product != null)
                            product.InStockQuantity -= oitem.UnitQuantity;
                    }
                    else if (order.OrderType == OrderTypeEnum.Purchase.ToString())
                    {
                        var invUnit = new InventoryUnit
                        {
                            ExpirationDate = oitem.ExpirationDate,
                            GrossWeight = oitem.GrossWeight,
                            IsHold = oitem.IsHold,
                            IssueAdjustment = null,//oitem.Adjustment,
                            IssueDate = null,
                            IssueReceipt = null,
                            LotNumber = oitem.LotNumber,
                            NetWeight = oitem.NetWeight,
                            Notes = null,
                            PackageId = oitem.PackageId,
                            PackageQuantity = oitem.PackageQuantity,
                            ProductId = oitem.ProductId,
                            ProductionDate = oitem.ProductionDate,
                            Rate = oitem.Rate,
                            ReceiveAdjustment = oitem.Adjustment,
                            ReceiveDate = DateTime.Now,
                            ReceiveReceipt = oitem.Reference,
                            Remark = "Order Cancelled",
                            Total = oitem.Total,
                            UomId = oitem.UomId,
                            WarehouseId = oitem.WarehouseId,
                            SupplierId = oitem.SupplierId,
                            UnitQuantity = oitem.UnitQuantity,
                        };
                        _context.InventoryUnit.Add(invUnit);
                        // todo for multiple warehouse case
                        var wp = _context.WarehouseProduct.FirstOrDefault(x => x.ProductId == oitem.ProductId);
                        if (wp != null)
                            wp.InStockQuantity += oitem.UnitQuantity;
                        var product = _context.Product.FirstOrDefault(x => x.Id == oitem.ProductId);
                        if (product != null)
                            product.InStockQuantity += oitem.UnitQuantity;
                    }
                }
            }
        }

        private string SubtractIssuedItemsFromWarehouse(ICollection<OrderItem> items)
        {
            var msg = _inventoryUnitService.SaveDirectIssueAny(items.MapToInventoryUnitModel(), "Issue");
            return msg ?? string.Empty;
        }
       private void AddReceivedItemsToWarehouseWithoutCommit(DatabaseContext _context, ICollection<OrderItem> items, DateTime now)
       {
           foreach (var poItem in items)
           {
               var product = _context.Product.Find(poItem.ProductId);
               if (product != null)
               {
                   poItem.IsReceived = true;
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
                       Rate = poItem.Rate,
                       UnitQuantity = poItem.UnitQuantity,
                       UomId = product.BaseUomId,
                       WarehouseId = poItem.WarehouseId ?? 0,
                   };
                   var invmodel = invUnit.MapToModel();
                   var invMovement = new InventoryMovementModel
                   {
                       Date = now,
                       UnitQuantity = invmodel.UnitQuantity,
                       SourceWarehouseId = null,
                       TargetWarehouseId = poItem.WarehouseId,
                       InventoryUnit = invmodel
                   };
                   _inventoryUnitService.UpdateWarehouseProductWithoutCommit(_context, invMovement, product);
                   _context.InventoryUnit.Add(invUnit);
               }
           }
       }
       */
        /*
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
                    if (entity.IsCompleted)
                        return "Already received!";
                    entity.IsCompleted = true;
                    entity.CompletedDate = now;

                    AddReceivedItemsToWarehouse(entity.OrderItems, now);

                    _context.SaveChanges();
                    var args = new BaseEventArgs<OrderModel>(entity.MapToModel(), Utility.UpdateMode.EDIT);
                    _listener.TriggerOrderUpdateEvent(null, args);
                    _listener.TriggerInventoryUnitUpdateEvent(null, null);
                    return string.Empty;
                }
                return "The Purchase Order doesn't exist";
            }
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
                    else if (entity.IsCompleted)
                        return "This order has already been " + executedAction + ". No need to send!";
                    else if (entity.IsCancelled)
                        return "This order is aleady cancelled. You can't " + verifiyAction + " a cancelled order";
                    entity.IsVerified = true;
                    entity.VerifiedDate = DateTime.Now;
                    _context.SaveChanges();
                    var args = new BaseEventArgs<OrderModel>(entity.MapToModel(), Utility.UpdateMode.EDIT);
                    _listener.TriggerOrderUpdateEvent(null, args);
                    return string.Empty;
                }
                return "The Order doesn't exist";
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
                    if (entity.IsCompleted)
                        return "Already issued!";


                    var msg = SubtractIssuedItemsFromWarehouse(entity.OrderItems);
                    if (!string.IsNullOrEmpty(msg))
                        return msg;

                    entity.IsCompleted = true;
                    entity.CompletedDate = now;

                    _context.SaveChanges();
                    var args = new BaseEventArgs<OrderModel>(entity.MapToModel(), Utility.UpdateMode.EDIT);
                    _listener.TriggerOrderUpdateEvent(null, args);
                    _listener.TriggerInventoryUnitUpdateEvent(null, null);
                    return string.Empty;
                }
                return "The Order doesn't exist";
            }
        }


    }
*/

        // amount in user table -- tooo much fradulent code.. can't make a robust amount entry in User table. due to changing 
        // nature of transaction (invoice void, re-save, etc.)
        //private void AddUpdateUserAmount(DatabaseContext _context, OrderModel orderModel, Order entity)
        //{
        //    var user = _context.User.Find(orderModel.UserId);
        //    if (user != null)
        //    {
        //        // new order
        //        if (orderModel.Id <= 0)
        //        {
        //            user.TotalAmount += orderModel.TotalAmount;
        //            user.PaidAmount += orderModel.PaidAmount;
        //        }
        //        else
        //        {
        //            user.TotalAmount = user.TotalAmount - (entity?.TotalAmount ?? 0) + orderModel.TotalAmount;
        //            user.PaidAmount = user.PaidAmount - (entity?.PaidAmount ?? 0) + orderModel.PaidAmount;
        //        }
        //    }
        //}
        #endregion

        public List<SalePurchaseAmountModel> GetSalePurchaseAmountForBarDiagram(DateTime from, DateTime to)
        {
            //var from = DateTime.Now.Date.AddDays(-30);
            using (var _context = new DatabaseContext())
            {
                var list = _context.Order
                    .Where(x => x.IsCompleted && x.CompletedDate >= from && x.CompletedDate <= to && !x.IsVoid)
                    .GroupBy(x => new { CompletedDate = DbFunctions.TruncateTime(x.CompletedDate), x.OrderType })
                    .Select(x => new
                    {
                        x.Key.CompletedDate,
                        x.Key.OrderType,
                        PurchaseAmount = x.Where(y => x.Key.OrderType == "Purchase").Sum(y => (decimal?)(y.TotalAmount - y.DiscountAmount)),
                        SaleAmount = x.Where(y => x.Key.OrderType == "Sale").Sum(y => (decimal?)(y.TotalAmount - y.DiscountAmount)),
                    })
                    .OrderBy(x => x.CompletedDate)
                    .ThenBy(x => x.OrderType)
                    .AsEnumerable()
                    .Select(x => new SalePurchaseAmountModel
                    {
                        Date = x.CompletedDate.HasValue ? x.CompletedDate.Value.ToString("M/dd") : "",
                        PurchaseAmount = x.PurchaseAmount.HasValue ? x.PurchaseAmount.Value : 0,
                        SaleAmount = x.SaleAmount.HasValue ? x.SaleAmount.Value : 0,
                    })

                    .ToList();
                return list;
            }
        }

        public List<DueAmountModel> GetDueReceivables()
        {
            //TODO;;; get the 
            using (var _context = new DatabaseContext())
            {
                var nowDate = DateTime.Now.Date;
                //var orders = _context.Order.Where(x => x.IsCompleted && x.PaidAmount < x.TotalAmount).ToList();
                var sell = OrderTypeEnum.Sale.ToString();
                var customer = UserTypeEnum.Customer.ToString();
                var list = _context.Transaction//.Where(x => x.Type == sell)
                    .Where(x => x.User != null && x.User.UserType == customer)
                    .GroupBy(x => x.User)
                    .Select(x => new
                    {
                        User = x.Key.Name,
                        Company = x.Key.Company,
                        TotalAmount = x.Sum(y => y.Debit),
                        PaidAmount = x.Sum(y => y.Credit),
                        DueAmount = x.Sum(y => y.Debit - y.Credit),
                        DueDate = x.Key.PaymentDueDate,
                        DueDays = DbFunctions.DiffDays(nowDate, x.Key.PaymentDueDate)
                    })
                    .Where(x => x.DueAmount > 0)
                    .OrderBy(x => x.DueDays)
                    .Take(20)
                    .AsEnumerable()
                    .Select(x => new DueAmountModel
                    {
                        User = x.User + (string.IsNullOrEmpty(x.Company) ? "" : " - " + x.Company),
                        DueAmount = x.DueAmount.ToString("##,##,##0.00"),
                        DueDate = x.DueDate.HasValue ? x.DueDate.Value.ToString("yyyy/MM/dd") : "",
                        DueDays = x.DueDays.HasValue ? x.DueDays.Value : 0,
                        TransactionAmount = x.TotalAmount.ToString("##,##,##0.00"),
                        PaidAmount = x.PaidAmount.ToString("##,##,##0.00")
                    })
                    .ToList();

                //_context.User.Where(x=>x.UserType == customer && x.Transactions.A)

                //var saleType = OrderTypeEnum.Sale.ToString();
                ////var invoice = TransactionTypeEnum
                //var transactions = _context.Transaction
                //    .Where(x=>x.Type == saleType)
                //    .GroupBy(x=>x.User)
                //    .Select(x=> new { x.Key.Name, Balance = x.Sum(y=>y.Balance * y.DrCr) })


                return list;//OrderMapper.MapToModel(new List<Order>());
            }

        }

        #endregion


    }
}

