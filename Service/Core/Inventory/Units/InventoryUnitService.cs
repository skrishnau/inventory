using DTO.Core.Inventory;
using Infrastructure.Context;
using Service.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModel.Core.Inventory;
using System.Data.Entity;
using Infrastructure.Entities.Inventory;
using Service.Utility;
using Service.DbEventArgs;
using Infrastructure.Entities.Orders;
using Service.Core.Orders;
using ViewModel.Core.Orders;
using Infrastructure.Entities;
using Service.Interfaces;

namespace Service.Core.Inventory.Units
{
    public class InventoryUnitService : IInventoryUnitService
    {
        // private readonly DatabaseContext _context;

        private readonly IDatabaseChangeListener _listener;
        private readonly IUomService _uomService;

        public InventoryUnitService(IDatabaseChangeListener listener, IUomService uomService)//DatabaseContext context,
        {
            //_context = context;
            _listener = listener;
            _uomService = uomService;
        }


        public int GetInventoryUnitCount(int warehouseId, int productId)
        {
            using (var _context = new DatabaseContext())
            {
                var query = GetInventoryUnitQueryable(_context, warehouseId, productId);
                return query.Count();
            }
        }

        public InventoryUnitListModel GetInventoryUnitList(int warehouseId, int productId, int pageSize, int offset)
        {
            using (var _context = new DatabaseContext())
            {
                var query = GetInventoryUnitQueryable(_context, warehouseId, productId);
                var totalCount = query.Count();
                if (pageSize > 0 && offset >= 0)
                {
                    query = query.Skip(offset).Take(pageSize);
                }
                var list = InventoryUnitMapper.MapToModel(query);
                return new InventoryUnitListModel
                {
                    DataList = list,
                    TotalCount = totalCount,
                    Offset = offset,
                    PageSize = pageSize,
                };
            }
        }
        public IQueryable<InventoryUnit> GetInventoryUnitQueryable(DatabaseContext _context, int warehouseId, int productId)
        {
            return _context.InventoryUnit
                    .Include(x => x.Product)
                    .Include(x => x.Package)
                    .Include(x => x.Supplier)
                   // .Include(x => x.Uom)
                    .Include(x => x.Warehouse)
                    .Where(x => (warehouseId == 0 || x.WarehouseId == warehouseId)
                            && (productId == 0 || x.ProductId == productId))
                    .OrderBy(x => x.ReceiveDate)
                    //.ThenBy(x => x.Warehouse.Name)
                    //.ThenBy(x => x.Product.Name)
                    .AsQueryable();
        }

        public void MergeInventoryUnits(List<InventoryUnitModel> list)
        {
            using (var _context = new DatabaseContext())
            {
                DateTime now = DateTime.Now;
                foreach (var productWiseGroup in list.GroupBy(x => x.ProductId))
                {
                    var product = _context.Product.Find(productWiseGroup.Key);

                    if (product != null)
                    {
                        foreach (var invUnitGroup in productWiseGroup.GroupBy(x => x.WarehouseId))
                        {
                            var zeroRateOrderItemIdGroup = invUnitGroup.Where(x => x.Rate == 0).GroupBy(x => x.PurchaseOrderItemId); ;
                            foreach (var zwhg in zeroRateOrderItemIdGroup)
                            {
                                var withZeroRate = zwhg.ToList();
                                // if 2 or more items for this product
                                if (withZeroRate.Count >= 2)
                                {
                                    UpdateMerging(_context, withZeroRate, product, now);
                                }
                            }

                            var withRate = invUnitGroup.Where(x => x.Rate > 0).ToList();
                            // if 2 or more items for this product
                            if (withRate.Count >= 2)
                                UpdateMerging(_context, withRate, product, now);
                        }
                    }
                }
                _context.SaveChanges();
                var args = new BaseEventArgs<List<InventoryUnitModel>>(list, UpdateMode.EDIT);
                _listener.TriggerInventoryUnitUpdateEvent(null, args);
            }
        }

        private void UpdateMerging(DatabaseContext _context, List<InventoryUnitModel> invList, Product product, DateTime now)
        {
            var unitQuantity = 0M;
            var packageQuantity = 0M;
            InventoryUnit editingRecord = null;
            for (var i = 0; i < invList.Count(); i++)
            {
                var dbEntity = _context.InventoryUnit
                    .Find(invList.ElementAt(i).Id);
                if (dbEntity != null)
                {
                    unitQuantity += dbEntity.UnitQuantity;
                    packageQuantity += dbEntity.PackageQuantity;
                    if (i < invList.Count() - 1)
                    {
                        // remove
                        _context.InventoryUnit.Remove(dbEntity);
                        invList.ElementAt(i).UpdateAction = UpdateMode.DELETE.ToString();
                    }
                    else
                    {
                        // get the last entity ; 
                        // TODO:: assign the value from multiple entities to the newly created 
                        editingRecord = dbEntity;
                        invList.ElementAt(i).UpdateAction = UpdateMode.EDIT.ToString();
                    }
                }
            }
            editingRecord.UnitQuantity = unitQuantity;
            //var unitsInPackage = product.UnitsInPackage == 0 ? 1 : product.UnitsInPackage;
            editingRecord.PackageQuantity = GetPackageQuantity(unitQuantity, product.UnitsInPackage);
            // Math.Ceiling(unitQuantity / unitsInPackage) + (unitQuantity % unitsInPackage == 0 ? 0 : 1);
            //editingRecord.PackageQuantity = packageQuantity;
            //
            // Movement
            //
            string splitString = "";
            invList.ForEach(x => { splitString += x.UnitQuantity + " + "; });
            splitString = splitString.Trim();
            splitString = splitString.TrimEnd(new char[] { '+' });
            var description = "Merged " + splitString + " of '" + product.Name + "' into " + editingRecord.UnitQuantity + " qty.";
            AddMovementWithoutCoomit(_context, description, "-------------", "Merge", editingRecord.UnitQuantity, now, editingRecord.ProductId);

        }

        public void SplitInventoryUnit(List<decimal> quantitySplitList, InventoryUnitModel model)
        {
            using (var _context = new DatabaseContext())
            {

                var now = DateTime.Now;
                //find
                if (quantitySplitList.Count > 1)
                {
                    var entity = _context.InventoryUnit
                        .Include(x => x.Product)
                        .Include(x => x.Warehouse)
                        .FirstOrDefault(x => x.Id == model.Id);
                    if (entity != null)
                    {
                        // split 
                        if (entity.UnitQuantity == quantitySplitList.Sum())
                        {
                            var updatedEntryList = new List<InventoryUnit>();
                            //
                            // Movement
                            //
                            string splitString = "";
                            quantitySplitList.ForEach(x => { splitString += x + " + "; });
                            splitString = splitString.Trim();
                            splitString = splitString.TrimEnd(new char[] { '+' });
                            var description = "Splitted " + entity.UnitQuantity + " qty. of '" + entity.Product.Name + "' into " + splitString + ".";
                            AddMovementWithoutCoomit(_context, description, "----------------", "Split", entity.UnitQuantity, now, entity.ProductId);

                            for (var q = 0; q < quantitySplitList.Count; q++)
                            {
                                var quantity = quantitySplitList[q];
                                if (quantity > 0)
                                {
                                    if (q == 0)
                                    {
                                        // update the first entry 
                                        entity.UnitQuantity = quantity;
                                        entity.PackageQuantity = GetPackageQuantity(quantity, entity.Product.UnitsInPackage);//Math.Ceiling(quantity / unitsInPackage) + (quantity % unitsInPackage == 0 ? 0 : 1);
                                    }
                                    else
                                    {
                                        // create new entry for the rest of the splits
                                        var newEntity = InventoryUnitMapper.CloneEntity(entity);
                                        newEntity.Id = 0;
                                        newEntity.UnitQuantity = quantity;
                                        newEntity.PackageQuantity = GetPackageQuantity(quantity, entity.Product.UnitsInPackage); //Math.Ceiling(quantity / unitsInPackage) + (quantity % unitsInPackage == 0 ? 0 : 1);
                                        _context.InventoryUnit.Add(newEntity);
                                    }

                                }
                            }
                            _context.SaveChanges();
                            var list = InventoryUnitMapper.MapToModel(updatedEntryList);
                            var args = new BaseEventArgs<List<InventoryUnitModel>>(list, UpdateMode.EDIT);
                            _listener.TriggerInventoryUnitUpdateEvent(null, args);
                        }
                    }
                }
            }
        }

        public void UpdateWarehouseProductWithoutCommit(InventoryMovementModel moveModel, Product product)
        {
            // var product = _context.Product.Find(moveModel.InventoryUnit.ProductId);
            if (product != null)
            {
                // subtract from source warehouse (fromWarehouse)
                if (moveModel.SourceWarehouseId != null)
                {
                    var fromWp = product.WarehouseProducts.FirstOrDefault(x => x.WarehouseId == moveModel.SourceWarehouseId);
                    if (fromWp != null)
                    {
                        // update FromWarehouse
                        fromWp.InStockQuantity -= moveModel.UnitQuantity;//iuModel.UnitQuantity;
                        fromWp.OnHoldQuantity -= moveModel.InventoryUnit.IsHold ? moveModel.UnitQuantity : 0; //iuModel.OnHoldQuantity : 0;
                        fromWp.UpdatedAt = moveModel.Date;
                        product.InStockQuantity -= moveModel.UnitQuantity;// iuModel.UnitQuantity;
                        product.OnHoldQuantity -= moveModel.InventoryUnit.IsHold ? moveModel.UnitQuantity : 0;// iuModel.OnHoldQuantity : 0;
                    }
                }
                if (moveModel.TargetWarehouseId != null)
                {

                    var toWp = product.WarehouseProducts.FirstOrDefault(x => x.WarehouseId == moveModel.TargetWarehouseId);

                    // add to the target warehouse (toWarehouse)
                    if (toWp == null)
                    {
                        // don't do txn
                        //using (var txn = _context.Database.BeginTransaction())
                        {
                            // add
                            toWp = new WarehouseProduct()
                            {
                                WarehouseId = moveModel.TargetWarehouseId ?? 0,
                                ProductId = moveModel.InventoryUnit.ProductId,
                            };
                            // update
                            toWp.InStockQuantity += moveModel.UnitQuantity; // iuModel.UnitQuantity;
                            toWp.OnHoldQuantity += moveModel.InventoryUnit.IsHold ? moveModel.UnitQuantity : 0;//moveModel.InventoryUnit.OnHoldQuantity : 0;
                            toWp.UpdatedAt = moveModel.Date;
                            product.WarehouseProducts.Add(toWp);
                        }
                    }
                    else
                    {
                        // update
                        toWp.InStockQuantity += moveModel.InventoryUnit.UnitQuantity;
                        toWp.OnHoldQuantity += moveModel.InventoryUnit.IsHold ? moveModel.InventoryUnit.OnHoldQuantity : 0;
                        toWp.UpdatedAt = moveModel.Date;
                    }
                    product.InStockQuantity += moveModel.InventoryUnit.UnitQuantity;
                    product.OnHoldQuantity += moveModel.InventoryUnit.IsHold ? moveModel.InventoryUnit.OnHoldQuantity : 0;
                }
            }

        }


        private decimal GetPackageQuantity(decimal unitQuantity, decimal unitsInPackage)
        {
            unitsInPackage = unitsInPackage == 0 ? 1 : unitsInPackage;
            return Math.Ceiling(unitQuantity / unitsInPackage) + (unitQuantity % unitsInPackage == 0 ? 0 : 1);
        }

        public int GetMovementListCount(int productId)
        {
            using (var _context = new DatabaseContext())
            {
                var query = GetMovementListQuery(_context, productId);
                return query.Count();
            }
        }

        public MovementListModel GetMovementList(int productId, int pageSize, int offset)
        {
            using (var _context = new DatabaseContext())
            {
                var query = GetMovementListQuery(_context, productId);
                var totalCount = query.Count();
                if (pageSize > 0 && offset >= 0)
                {
                    query = query.Skip(offset).Take(pageSize);
                }
                var list = MovementMapper.MapToModel(query);
                return new MovementListModel
                {
                    DataList = list,
                    TotalCount = totalCount,
                    Offset = offset,
                    PageSize = pageSize,
                };
            }
        }

        public IQueryable<Movement> GetMovementListQuery(DatabaseContext _context, int productId)
        {
            return _context.Movement
                    .Where(x => productId == 0 || x.ProductId == productId)
                    .OrderByDescending(x => x.Date)
                    .AsQueryable();
        }


        /// <summary>
        /// Updates WarehouseProduct table
        /// </summary>
        /// <param name="iuModel">Inventory Unit</param>
        /// <param name="sourceWarehouseId">The warehouse from which to subtract the unit's UnitQuantity</param>
        /// <param name="targetWarehouseId">The warehouse to which to add the unit's UnitQuantity</param>
        /// <param name="receiveDate"></param>


        public void AddMovementWithoutCoomit(DatabaseContext _context, string description, string reference, string adjustmentCode, decimal quantity, DateTime receiveDate, int productId)
        {
            var movement = new Movement()
            {
                AdjustmentCode = adjustmentCode,
                Date = receiveDate,
                Description = description,
                Quantity = quantity,
                Reference = reference,
                ProductId = productId,
            };
            _context.Movement.Add(movement);
        }
        public Warehouse FindWarehouseOrReturnMainWarehouse(DatabaseContext _context, int? warehouseId)
        {
            var warehouse = _context.Warehouse.Find(warehouseId);
            if (warehouse == null)
            {
                // get main warehouse
                warehouse = _context.Warehouse.FirstOrDefault();
                if (warehouse == null)
                {
                    warehouse = new Warehouse
                    {
                        CreatedAt = DateTime.Now,
                        Hold = true,
                        MixedProduct = true,
                        Name = "Main",
                        Staging = true,
                        UpdatedAt = DateTime.Now,
                        Use = true,
                    };
                    using (var tempContext = new DatabaseContext())
                    {
                        tempContext.Warehouse.Add(warehouse);
                        tempContext.SaveChanges();
                    }
                }
            }
            return warehouse;
        }

        #region Adjustments

        public string SaveDirectReceive(List<InventoryUnitModel> list, DateTime receivedDate, string adjustmentCode)
        {
            using (var _context = new DatabaseContext())
            {
                var msg = SaveDirectReceiveListWithoutCommit(_context, list, receivedDate, adjustmentCode);
                _context.SaveChanges();
                // var list = InventoryUnitMapper.MapToModel(updatedEntryList);
                var args = new BaseEventArgs<List<InventoryUnitModel>>(list, UpdateMode.EDIT);
                _listener.TriggerInventoryUnitUpdateEvent(null, args);
                return msg;
            }
        }
        public InventoryUnit SaveDirectReceiveItemWithoutCommit(DatabaseContext _context, InventoryUnitModel unit, DateTime receivedDate, string adjustmentCode, ref string msg, Product product, string reference, OrderItem orderItem)
        {
            var warehouse = FindWarehouseOrReturnMainWarehouse(_context, unit.WarehouseId);
            unit.WarehouseId = warehouse.Id;
            if (!string.IsNullOrEmpty(unit.Package) && (unit.PackageId ?? 0) == 0)
            {
                unit.PackageId = _context.Package.FirstOrDefault(x => x.Name == unit.Package)?.Id;
            }
            var unitEntity = unit.MapToEntity();
            unitEntity.ReceiveDate = receivedDate;
            unitEntity.ReceiveAdjustment = adjustmentCode;
            unitEntity.Supplier = orderItem.Supplier;
            unitEntity.SupplierId = orderItem.SupplierId;
            unitEntity.ReceiveReceipt = reference;
            _context.InventoryUnit.Add(unitEntity);

            if (product == null)
                product = _context.Product.Find(unit.ProductId);

            var description = "Received " + unit.UnitQuantity + " quantities of " +
                product.Name;// + " into " + warehouse.Name + " warehouse.";
                             //var quantity = list.Sum(x => x.UnitQuantity);
                             //"----------------"
            AddMovementWithoutCoomit(_context, description, reference, adjustmentCode, unit.UnitQuantity, receivedDate, unit.ProductId);//"Direct Receive"
            var invMovement = new InventoryMovementModel
            {
                Date = receivedDate,
                UnitQuantity = unit.UnitQuantity,
                SourceWarehouseId = null,
                TargetWarehouseId = unit.WarehouseId,
                InventoryUnit = unit
            };
            UpdateWarehouseProductWithoutCommit(invMovement, product);
            unitEntity.OrderItem = orderItem;
            return unitEntity;
        }
        public string SaveDirectReceiveListWithoutCommit(DatabaseContext _context, List<InventoryUnitModel> list, DateTime receivedDate, string adjustmentCode)
        {
            var now = DateTime.Now;
            var msg = string.Empty;

            //var entityList = InventoryUnitMapper.MapToEntity(list);
            //_context.InventoryUnit.AddRange(entityList);
            if (!list.Any())
            {
                msg = "There aren't any items to receive";
                return msg;
            }
            //
            // Movement
            //
            foreach (var unit in list)
            {
                SaveDirectReceiveItemWithoutCommit(_context, unit, receivedDate, adjustmentCode, ref msg, null, "----------------", null);
            }
            return msg;
        }

        public string SaveDirectIssueInventoryUnit(List<InventoryUnitModel> list, string adjustmentCode)
        {
            using (var _context = new DatabaseContext())
            {
                List<TransactionItem> transactionItems = new List<TransactionItem>();
                var now = DateTime.Now;

                var msg = string.Empty;
                foreach (var model in list)
                {
                    var dbEntity = _context.InventoryUnit
                        .Include(x => x.Product)
                        .Include(x => x.Warehouse)
                        .FirstOrDefault(x => x.Id == model.Id);
                    if (dbEntity != null)
                    {
                        var productName = dbEntity.Product.Name;
                        var warehouseName = dbEntity.Warehouse.Name;
                        var issuedQuantity = 0M;
                        var unitQuantity = dbEntity.UnitQuantity;
                        var productId = dbEntity.ProductId;
                        var warehouseId = dbEntity.WarehouseId;
                        var product = dbEntity.Product;
                        
                        if (model.UnitQuantity < dbEntity.UnitQuantity)
                        {
                            // don't remove; just decrement
                            issuedQuantity = model.UnitQuantity;
                            dbEntity.UnitQuantity = dbEntity.UnitQuantity - model.UnitQuantity;
                            dbEntity.PackageQuantity = GetPackageQuantity(dbEntity.UnitQuantity, dbEntity.Product.UnitsInPackage);
                        }
                        else
                        {
                            issuedQuantity = dbEntity.UnitQuantity;
                            // case is : model.UnitQuantity >= entity.UnitQuantity
                            // remove the InventoryUnit
                            _context.InventoryUnit.Remove(dbEntity);
                        }
                        //
                        // Movement
                        //
                        var description = "Issued " + issuedQuantity + " qty. of '" + productName + "' from " + warehouseName + " warehouse.";
                        AddMovementWithoutCoomit(_context, description, "----------------", adjustmentCode, unitQuantity, now, productId);//"Direct Issue"
                        var invMovement = new InventoryMovementModel
                        {
                            Date = now,
                            UnitQuantity = issuedQuantity,
                            SourceWarehouseId = warehouseId,
                            TargetWarehouseId = null,
                            InventoryUnit = model
                        };
                        UpdateWarehouseProductWithoutCommit(invMovement, product);
                        //var ti = new TransactionItem()
                        //{
                        //    CostPriceRate = 
                        //};
                        //transactionItems.Add(ti);
                    }
                }
                //var orderModel = new OrderModel();
                //OrderService.GetTransactionWithoutCommit(_context, orderModel);

                _context.SaveChanges();
                var args = new BaseEventArgs<List<InventoryUnitModel>>(list, UpdateMode.DELETE);
                _listener.TriggerInventoryUnitUpdateEvent(null, args);
                return msg;
            }
        }

        public string SaveDirectIssueAny(List<InventoryUnitModel> list, string adjustmentCode)
        {
            using (var _context = new DatabaseContext())
            {

                var msg = SaveDirectIssueAnyListWithoutCommit(_context, list, adjustmentCode);
                _context.SaveChanges();
                var args = new BaseEventArgs<List<InventoryUnitModel>>(list, UpdateMode.DELETE);
                _listener.TriggerInventoryUnitUpdateEvent(null, args);
                return msg;
            }
        }

        public string SaveDirectIssueAnyListWithoutCommit(DatabaseContext _context, List<InventoryUnitModel> list, string adjustmentCode)
        {
            var now = DateTime.Now;

            var msg = string.Empty;
            foreach (var model in list)
            {
                var invUnits = SaveDirectIssueAnyItemWithoutCommit(_context, model, adjustmentCode, ref msg);
            }
            return msg;
        }

        public List<InventoryUnit> SaveDirectIssueAnyItemWithoutCommit(DatabaseContext _context, InventoryUnitModel model, string adjustmentCode, ref string msg)
        {
            var now = DateTime.Now;
            var list = new List<InventoryUnit>();

            var warehouse = FindWarehouseOrReturnMainWarehouse(_context, model.WarehouseId);
            model.WarehouseId = warehouse.Id;
            var invUnit = _context.InventoryUnit
                .Include(x => x.Product)
                .Include(x => x.Warehouse)
                .Where(x => x.WarehouseId == model.WarehouseId
                                && x.ProductId == model.ProductId
                                && x.PackageId != null
                                && x.IsHold == model.IsHold)
                .OrderBy(x => x.LotNumber)
                .ToList();
            decimal qtySum = 0;
            var fulfilledIndex = -1;
            
            for (var i = 0; i < invUnit.Count(); i++)
            {
                var conversion = _uomService.ConvertUom(invUnit[i].PackageId??0, model.PackageId??0, model.ProductId);
                var invunitqty = invUnit[i].UnitQuantity * conversion;
                qtySum += invunitqty;

                /*
                // earlier 
                qtySum += invUnit[i].UnitQuantity;
                */
                if (qtySum >= model.UnitQuantity)
                {
                    fulfilledIndex = i;
                    break;
                }
            }
            if (fulfilledIndex < 0)
            {
                msg += "Some of the products are insufficient to issue. Please verify again.";
                return list;
            }

            // start issue 
            decimal remainingQty = model.UnitQuantity;
            for (var i = 0; i <= fulfilledIndex; i++)
            {
                var dbEntity = invUnit[i];
                var productName = dbEntity.Product.Name;
                var warehouseName = dbEntity.Warehouse.Name;
                var issuedQuantity = 0M;
                // we shouldn't use dbEntity once it's removed from _context.InventoryUnit so assign the values here before removing
                var warehouseId = dbEntity.WarehouseId;
                var product = dbEntity.Product;
                var productId = dbEntity.ProductId;
                var rate = dbEntity.Rate;
                var orderItemId = dbEntity.OrderItemId;
                var packageId = dbEntity.PackageId;
                var packagename = dbEntity.Package.Name;

                var conversion = _uomService.ConvertUom(model.PackageId ?? 0, dbEntity.PackageId ?? 0, model.ProductId);
                var remainInvunitQty = remainingQty * conversion;

                //earlier : if (remainingQty < dbEntity.UnitQuantity)
                if(remainInvunitQty < dbEntity.UnitQuantity)
                {
                    // don't remove; just decrement
                    //earlier: issuedQuantity = remainingQty;
                    issuedQuantity = remainInvunitQty;
                    //earlier : dbEntity.UnitQuantity = dbEntity.UnitQuantity - remainingQty;
                    dbEntity.UnitQuantity = dbEntity.UnitQuantity - remainInvunitQty;
                    //dbEntity.PackageQuantity = GetPackageQuantity(dbEntity.UnitQuantity, dbEntity.Product.UnitsInPackage);
                }
                else
                {
                    issuedQuantity = dbEntity.UnitQuantity;
                    //dbEntity.UnitQuantity = 0;
                    // case is : model.UnitQuantity >= entity.UnitQuantity
                    // remove the InventoryUnit
                    remainingQty -= dbEntity.UnitQuantity/conversion;
                    _context.InventoryUnit.Remove(dbEntity);
                }
                // note : don't use dbEntity below this comment line. if you want to use the dbentity then assign it's value to another var before remove() func.
                list.Add(new InventoryUnit { Rate = rate * conversion, UnitQuantity = issuedQuantity / conversion, PackageId = model.PackageId, OrderItemId = orderItemId });
                //
                // Movement
                //
                var description = $"Issued {issuedQuantity} {packagename} of '{productName}' from {warehouseName} warehouse.";
                AddMovementWithoutCoomit(_context, description, "----------------", adjustmentCode, issuedQuantity, now, productId);//"Direct Issue"
                var invMovement = new InventoryMovementModel
                {
                    Date = now,
                    UnitQuantity = issuedQuantity,
                    SourceWarehouseId = warehouseId,//dbEntity.WarehouseId,
                    TargetWarehouseId = null,
                    InventoryUnit = model
                };
                UpdateWarehouseProductWithoutCommit(invMovement, product);
            }
            return list;
        }

        public string MoveInventoryUnits(int warehouseId, List<InventoryUnitModel> list)
        {
            using (var _context = new DatabaseContext())
            {

                var msg = string.Empty;
                if (!list.Any())
                {
                    msg = "There aren't any items to move";
                    return msg;
                }
                DateTime now = DateTime.Now;
                var warehouseEntity = FindWarehouseOrReturnMainWarehouse(_context, warehouseId);

                if (warehouseEntity != null)
                {
                    foreach (var iuModel in list)
                    {
                        // first find
                        var dbEntity = _context.InventoryUnit
                            .Include(x => x.Warehouse)
                            .Include(x => x.Product)
                            .FirstOrDefault(x => x.Id == iuModel.Id && x.WarehouseId != warehouseId);
                        if (dbEntity != null)
                        {
                            dbEntity.WarehouseId = warehouseId;
                            //
                            // Movement
                            //
                            var description = "Moved " + dbEntity.UnitQuantity + " qty. of '" + dbEntity.Product.Name + "' from " + dbEntity.Warehouse.Name + " to " + warehouseEntity.Name + ".";
                            var invMovement = new InventoryMovementModel
                            {
                                Date = now,
                                UnitQuantity = iuModel.UnitQuantity,
                                SourceWarehouseId = dbEntity.Warehouse.Id,
                                TargetWarehouseId = warehouseEntity.Id,
                                InventoryUnit = iuModel
                            };
                            UpdateWarehouseProductWithoutCommit(invMovement, dbEntity.Product);
                            AddMovementWithoutCoomit(_context, description, "--------------", "Move", dbEntity.UnitQuantity, now, dbEntity.ProductId);
                        }
                    }
                }
                _context.SaveChanges();
                var args = new BaseEventArgs<List<InventoryUnitModel>>(list, UpdateMode.EDIT);
                _listener.TriggerInventoryUnitUpdateEvent(null, args);
                return msg;
            }
        }



        #endregion


        public PriceHistory GetRate(DatabaseContext _context, int productId, DateTime completedDate)
        {
            var date = completedDate.Date;
            return _context.PriceHistory.FirstOrDefault(x => x.ProductId == productId && x.Date.Date == date);
        }
    }
}
