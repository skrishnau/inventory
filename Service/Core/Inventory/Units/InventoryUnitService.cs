using DTO.Core.Inventory;
using Infrastructure.Context;
using Service.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModel.Core.Inventory;
using System.Data.Entity;
using Service.Utility;
using Service.DbEventArgs;
using Service.Interfaces;
using ViewModel.Enums;
using DTO.Core;

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
            using (var _context = DatabaseContext.Context)
            {
                var query = GetInventoryUnitQueryable(_context, warehouseId, productId);
                return query.Count();
            }
        }

        public InventoryUnitListModel GetInventoryUnitList(int warehouseId, int productId, int pageSize, int offset)
        {
            using (var _context = DatabaseContext.Context)
            {
                var query = GetInventoryUnitQueryable(_context, warehouseId, productId);
                var totalCount = query.Count();
                if (pageSize > 0 && offset >= 0)
                {
                    query = query.Skip(offset).Take(pageSize);
                }
                var list = InventoryUnitMapper.MapToModel(query, _context);
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
            return _context.InventoryUnits
                    .Include(x => x.Product)
                    .Include(x => x.Package)
                    //.Include(x => x.User)
                    // .Include(x => x.Uom)
                    .Include(x => x.Warehouse)
                    .Where(x => (warehouseId == 0 || x.WarehouseId == warehouseId)
                            && (productId == 0 || x.ProductId == productId))
                    .OrderBy(x => x.ReceiveDate)
                    //.ThenBy(x => x.Warehouse.Name)
                    //.ThenBy(x => x.Product.Name)
                    .AsQueryable();
        }

        public string MergeInventoryUnits(List<InventoryUnitModel> list)
        {
            var message = string.Empty;
            using (var _context = DatabaseContext.Context)
            {
                using (var txn = _context.Database.BeginTransaction())
                {
                    DateTime now = DateTime.Now;
                    foreach (var productWiseGroup in list.GroupBy(x => new { x.ProductId, x.IsHold, x.AssignedToDepartmentId, x.AssignedToUserId }))
                    {
                        var product = _context.Products.Find(productWiseGroup.Key.ProductId);

                        if (product != null)
                        {
                            var productPackage = product.ProductPackages.FirstOrDefault(x => x.IsBasePackage)?.Package;
                            foreach (var invUnitGroup in productWiseGroup.GroupBy(x => x.WarehouseId))
                            {
                                var zeroRateOrderItemIdGroup = invUnitGroup.Where(x => x.Rate == 0).GroupBy(x => x.PurchaseOrderItemId); ;
                                foreach (var zwhg in zeroRateOrderItemIdGroup)
                                {
                                    var withZeroRate = zwhg.ToList();
                                    // if 2 or more items for this product
                                    if (withZeroRate.Count >= 2)
                                    {
                                        UpdateMerging(_context, withZeroRate, product, productPackage, now, ref message);
                                    }
                                }

                                var withRate = invUnitGroup.Where(x => x.Rate > 0).ToList();
                                // if 2 or more items for this product
                                if (withRate.Count >= 2)
                                    UpdateMerging(_context, withRate, product, productPackage, now, ref message);
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(message))
                    {
                        txn.Rollback();
                    }
                    else
                    {
                        _context.SaveChanges();
                        txn.Commit();
                    }
                    var args = new BaseEventArgs<List<InventoryUnitModel>>(list, UpdateMode.EDIT);
                    _listener.TriggerInventoryUnitUpdateEvent(null, args);
                }
                return message;
            }
        }

        private void UpdateMerging(DatabaseContext _context, List<InventoryUnitModel> invList, Product product, Package productPackage, DateTime now, ref string message)
        {
            var unitQuantity = 0M;
            var totalAmount = 0M;
            // var packageQuantity = 0M;
            InventoryUnit editingRecord = null;
            string splitString = "";
            for (var i = 0; i < invList.Count(); i++)
            {
                var invId = invList.ElementAt(i).Id;
                var dbEntity = _context.InventoryUnits.Include(x => x.Package).FirstOrDefault(x => x.Id == invId);
                if (dbEntity != null)
                {

                    var conversion = _uomService.ConvertUom(_context, dbEntity.PackageId ?? 0, productPackage?.Id ?? 0, product.Id, 1);
                    if (conversion == 0)
                    {
                        message += "Some items cannot be converted to base unit. Please update product's uom.";
                        return;
                    }
                    var rate = dbEntity.Rate;
                    unitQuantity += (dbEntity.UnitQuantity * conversion);
                    totalAmount += dbEntity.Rate * dbEntity.UnitQuantity;
                    var invUnitQuantity = dbEntity.UnitQuantity;
                    var invPackgeName = dbEntity.Package?.Name ?? string.Empty;
                    //packageQuantity += dbEntity.PackageQuantity;
                    if (i < invList.Count() - 1)
                    {
                        // remove
                        _context.InventoryUnits.Remove(dbEntity);
                        invList.ElementAt(i).UpdateAction = UpdateMode.DELETE.ToString();
                    }
                    else
                    {
                        // get the last entity ; 
                        // TODO:: assign the value from multiple entities to the newly created 
                        editingRecord = dbEntity;
                        invList.ElementAt(i).UpdateAction = UpdateMode.EDIT.ToString();
                    }
                    splitString += $"{invUnitQuantity} {invPackgeName} @ {Math.Round(rate, 2)} + ";
                }

            }
            editingRecord.UnitQuantity = unitQuantity;
            editingRecord.Rate = decimal.Round(totalAmount / unitQuantity, 3);
            editingRecord.PackageId = productPackage.Id;
            //var unitsInPackage = product.UnitsInPackage == 0 ? 1 : product.UnitsInPackage;
            //editingRecord.PackageQuantity = GetPackageQuantity(unitQuantity, product.UnitsInPackage);
            // Math.Ceiling(unitQuantity / unitsInPackage) + (unitQuantity % unitsInPackage == 0 ? 0 : 1);
            //editingRecord.PackageQuantity = packageQuantity;
            //
            // Movement
            //
            splitString = splitString.Trim();
            splitString = splitString.TrimEnd(new char[] { '+' });
            var description = $"Merged {splitString} of '{product.Name}' into {Math.Round(editingRecord.UnitQuantity, 3)} {productPackage.Name} with rate {Math.Round(editingRecord.Rate, 2)}";
            AddMovementWithoutCoomit(_context, description, "-------------", "Merge", editingRecord.UnitQuantity, now, editingRecord.ProductId);

        }

        public void SplitInventoryUnit(List<decimal> quantitySplitList, InventoryUnitModel model)
        {
            using (var _context = DatabaseContext.Context)
            {

                var now = DateTime.Now;
                //find
                if (quantitySplitList.Count > 1)
                {
                    var entity = _context.InventoryUnits
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
                            var description = $"Splitted {entity.UnitQuantity} {entity.Package.Name} of ' {entity.Product.Name}' @{Math.Round(entity.Rate, 2)} into {splitString}.";
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
                                        //entity.PackageQuantity = GetPackageQuantity(quantity, entity.Product.UnitsInPackage);//Math.Ceiling(quantity / unitsInPackage) + (quantity % unitsInPackage == 0 ? 0 : 1);
                                    }
                                    else
                                    {
                                        // create new entry for the rest of the splits
                                        var newEntity = InventoryUnitMapper.CloneEntity(entity);
                                        newEntity.Id = 0;
                                        newEntity.UnitQuantity = quantity;
                                        //newEntity.PackageQuantity = GetPackageQuantity(quantity, entity.Product.UnitsInPackage); //Math.Ceiling(quantity / unitsInPackage) + (quantity % unitsInPackage == 0 ? 0 : 1);
                                        _context.InventoryUnits.Add(newEntity);
                                    }

                                }
                            }
                            _context.SaveChanges();
                            var list = InventoryUnitMapper.MapToModel(updatedEntryList, _context);
                            var args = new BaseEventArgs<List<InventoryUnitModel>>(list, UpdateMode.EDIT);
                            _listener.TriggerInventoryUnitUpdateEvent(null, args);
                        }
                    }
                }
            }
        }

        // TODO: Transfer isn't handled property/with care .. so look deep into the logic while adding transfer logic
        public void UpdateWarehouseProductWithoutCommit(DatabaseContext _context, InventoryMovementModel moveModel, Product product, AssignReleaseViewModel assignRelease)
        {
            var productPackageId = product.ProductPackages.FirstOrDefault(x => x.IsBasePackage)?.PackageId ?? 0;
            var modelToBase = _uomService.ConvertUom(_context, moveModel.InventoryUnit.PackageId ?? 0, productPackageId, product.Id);
            var entityToBase = moveModel.PackageId == moveModel.InventoryUnit.PackageId
                ? modelToBase
                : _uomService.ConvertUom(_context, moveModel.PackageId, productPackageId, product.Id);

            // var product = _context.Products.Find(moveModel.InventoryUnit.ProductId);
            if (product != null)
            {
                var entityQty = moveModel.UnitQuantity * entityToBase;
                var modelQty = moveModel.InventoryUnit.UnitQuantity * modelToBase;

                if (assignRelease != null)
                {
                    // NOTE: if it's 'from' warehouse or 'to' warehouse then we need to add subtract InStock quantity
                    //      but if it's other than warehouse then we need not update Instock quantity or on hold quanitity
                    switch (assignRelease.TransferType)
                    {
                        case TransferTypeEnum.WarehouseToDepartment:
                            product.OnHoldQuantity += entityQty;
                            product.InStockQuantity -= entityQty;
                            break;
                        case TransferTypeEnum.DepartmentToWarehouse:
                            product.OnHoldQuantity -= entityQty;
                            product.InStockQuantity += entityQty;
                            break;
                        case TransferTypeEnum.DepartmentToDepartment:
                        case TransferTypeEnum.DepartmentToUser:
                        case TransferTypeEnum.UserToDepartment:
                            return;
                        case TransferTypeEnum.UserManufactureConsumed:
                            // note: in case of UserManufactureConsumed with ToId = 0, it means consumed product during manufacture
                            product.OnHoldQuantity -= entityQty;
                            return;
                    }
                }

                // subtract from source warehouse (fromWarehouse)
                if (moveModel.SourceWarehouseId != null)
                {
                    var fromWp = product.WarehouseProducts.FirstOrDefault(x => x.WarehouseId == moveModel.SourceWarehouseId);
                    if (fromWp != null)
                    {
                        //var convertedQty = _uomService.ConvertUom(moveModel.InventoryUnit.PackageId, fromWp.pack)
                        // update FromWarehouse
                        fromWp.InStockQuantity -= moveModel.InventoryUnit.IsHold ? 0 : entityQty;//iuModel.UnitQuantity;
                        fromWp.OnHoldQuantity -= moveModel.InventoryUnit.IsHold ? entityQty : 0; //iuModel.OnHoldQuantity : 0;
                        fromWp.UpdatedAt = moveModel.Date;
                        // NOte: update product only if assign release is not given cause we already updated product above when assignrelease is not null
                        if (assignRelease == null)
                        {
                            product.InStockQuantity -= moveModel.InventoryUnit.IsHold ? 0 : entityQty;// iuModel.UnitQuantity;
                            product.OnHoldQuantity -= moveModel.InventoryUnit.IsHold ? entityQty : 0;// iuModel.OnHoldQuantity : 0;
                        }
                    }
                }

                if (moveModel.TargetWarehouseId != null)
                {

                    var toWp = product.WarehouseProducts.FirstOrDefault(x => x.WarehouseId == moveModel.TargetWarehouseId);
                    // add to the target warehouse (toWarehouse)
                    if (toWp == null)
                    {
                        //throw new NotImplementedException("please consider model and entity quantity in this");
                        // don't do txn
                        //using (var txn = _context.Database.BeginTransaction())
                        //{
                        // add
                        toWp = new WarehouseProduct()
                        {
                            WarehouseId = moveModel.TargetWarehouseId ?? 0,
                            ProductId = moveModel.InventoryUnit.ProductId,
                        };
                        // update
                        //toWp.InStockQuantity += modelQty; // iuModel.UnitQuantity;
                        //toWp.OnHoldQuantity += moveModel.InventoryUnit.IsHold ? modelQty : 0;//moveModel.InventoryUnit.OnHoldQuantity : 0;
                        //toWp.UpdatedAt = moveModel.Date;
                        product.WarehouseProducts.Add(toWp);
                        //}
                    }
                    toWp.InStockQuantity += moveModel.InventoryUnit.IsHold ? 0 : modelQty;
                    toWp.OnHoldQuantity += moveModel.InventoryUnit.IsHold ? modelQty : 0;//moveModel.InventoryUnit.OnHoldQuantity : 0;
                    toWp.UpdatedAt = moveModel.Date;
                    // NOte: update product only if assign release is not given cause we already updated product above when assignrelease is not null
                    if (assignRelease == null)
                    {
                        product.InStockQuantity += moveModel.InventoryUnit.IsHold ? 0 : modelQty;
                        product.OnHoldQuantity += moveModel.InventoryUnit.IsHold ? modelQty : 0;//moveModel.InventoryUnit.OnHoldQuantity* conversion : 0;
                    }
                }
            }

        }

        /*
        private decimal GetPackageQuantity(decimal unitQuantity, decimal unitsInPackage)
        {
            unitsInPackage = unitsInPackage == 0 ? 1 : unitsInPackage;
            return Math.Ceiling(unitQuantity / unitsInPackage) + (unitQuantity % unitsInPackage == 0 ? 0 : 1);
        }
        */

        public int GetMovementListCount(int productId, DateTime? date)
        {
            using (var _context = DatabaseContext.Context)
            {
                var query = GetMovementListQuery(_context, productId, date);
                return query.Count();
            }
        }

        public MovementListModel GetMovementList(int productId, DateTime? date, int pageSize, int offset)
        {
            using (var _context = DatabaseContext.Context)
            {
                var query = GetMovementListQuery(_context, productId, date);
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

        public IQueryable<Movement> GetMovementListQuery(DatabaseContext _context, int productId, DateTime? date)
        {

            if (date.HasValue)
            {
                var dt = date.Value.Date;
                return _context.Movements
                     .Where(x => (productId == 0 || x.ProductId == productId) && (DbFunctions.TruncateTime(x.Date) == dt))
                     .OrderByDescending(x => x.Date)
                     .AsQueryable();
            }
            else
            {
                return _context.Movements
                        .Where(x => productId == 0 || x.ProductId == productId)
                        .OrderByDescending(x => x.Date)
                        .AsQueryable();
            }
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
            _context.Movements.Add(movement);
        }
        public Warehouse FindWarehouseOrReturnMainWarehouse(DatabaseContext _context, int? warehouseId)
        {
            var warehouse = _context.Warehouses.Find(warehouseId);
            if (warehouse == null)
            {
                // get main warehouse
                warehouse = _context.Warehouses.FirstOrDefault();
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
                    using (var tempContext = DatabaseContext.Context)
                    {
                        tempContext.Warehouses.Add(warehouse);
                        tempContext.SaveChanges();
                    }
                }
            }
            return warehouse;
        }

        #region Adjustments

        public string SaveDirectReceive(List<InventoryUnitModel> list, DateTime receivedDate, string adjustmentCode)
        {
            using (var _context = DatabaseContext.Context)
            {
                var msg = SaveDirectReceiveListWithoutCommit(_context, list, receivedDate, adjustmentCode);
                _context.SaveChanges();
                // var list = InventoryUnitMapper.MapToModel(updatedEntryList);
                var args = new BaseEventArgs<List<InventoryUnitModel>>(list, UpdateMode.EDIT);
                _listener.TriggerInventoryUnitUpdateEvent(null, args);
                return msg;
            }
        }
        public InventoryUnit SaveDirectReceiveItemWithoutCommit(DatabaseContext _context, InventoryUnitModel unit, DateTime movementDate, string adjustmentCode, ref string msg, Product product, string reference, OrderItem orderItem)
        {
            var warehouse = FindWarehouseOrReturnMainWarehouse(_context, unit.WarehouseId);
            unit.WarehouseId = warehouse.Id;
            Package package;
            if (!string.IsNullOrEmpty(unit.Package) && (unit.PackageId ?? 0) == 0)
            {
                package = _context.Packages.FirstOrDefault(x => x.Name == unit.Package);
                unit.PackageId = package?.Id;
            }
            else
            {
                package = _context.Packages.Find(unit.PackageId);
            }
            InventoryUnit unitEntity = null;

            unitEntity = unit.MapToEntity();
            unitEntity.ReceiveDate = unit.ReceiveDateDate;//receivedDate;
            unitEntity.ReceiveAdjustment = adjustmentCode;
            if (orderItem != null)
            {
                unitEntity.SupplierId = orderItem.User?.Id;
                unitEntity.SupplierId = orderItem.SupplierId;
            }
            unitEntity.ReceiveReceipt = unit.ReceiveReceipt;//reference;
            _context.InventoryUnits.Add(unitEntity);

            if (product == null)
            {
                if (unit.ProductId > 0)
                    product = _context.Products.Find(unit.ProductId);
                else
                    product = _context.Products.FirstOrDefault(x => x.Name == unit.Product.Trim() || x.SKU == unit.Product.Trim());
                unit.ProductId = product?.Id ?? 0;
            }
            var actionType = "Received";
            if (adjustmentCode == MovementTypeEnum.Manufacture.ToString())
            {
                actionType = "Manufactured";
            }
            var description = $"{actionType} {Math.Round(unit.UnitQuantity, 2)} {package?.Name ?? ""} of {product.Name} @ {Math.Round(unit.Rate, 2)}";
            AddMovementWithoutCoomit(_context, description, reference, adjustmentCode, unit.UnitQuantity, movementDate, unit.ProductId);//"Direct Receive"
            var invMovement = new InventoryMovementModel
            {
                Date = movementDate,
                UnitQuantity = unit.UnitQuantity,
                SourceWarehouseId = null,
                TargetWarehouseId = unit.WarehouseId,
                InventoryUnit = unit,
            };

            UpdateWarehouseProductWithoutCommit(_context, invMovement, product, null);
            if (orderItem != null && orderItem.Id > 0)
                unitEntity.OrderItem = orderItem;
            return unitEntity;
        }
        public string SaveDirectReceiveListWithoutCommit(DatabaseContext _context, List<InventoryUnitModel> list, DateTime receivedDate, string adjustmentCode)
        {
            var now = DateTime.Now;
            var msg = string.Empty;

            //var entityList = InventoryUnitMapper.MapToEntity(list);
            //_context.InventoryUnits.AddRange(entityList);
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
                unit.ReceiveDateDate = receivedDate;
                SaveDirectReceiveItemWithoutCommit(_context, unit, receivedDate, adjustmentCode, ref msg, null, "----------------", null);
            }
            return msg;
        }

        public string SaveDirectIssueInventoryUnit(List<InventoryUnitModel> list, string adjustmentCode)
        {
            using (var _context = DatabaseContext.Context)
            {
                List<TransactionItem> transactionItems = new List<TransactionItem>();
                var now = DateTime.Now;

                var msg = string.Empty;
                foreach (var model in list)
                {
                    var dbEntity = _context.InventoryUnits
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
                            // dbEntity.PackageQuantity = GetPackageQuantity(dbEntity.UnitQuantity, dbEntity.Product.UnitsInPackage);
                        }
                        else
                        {
                            issuedQuantity = dbEntity.UnitQuantity;
                            // case is : model.UnitQuantity >= entity.UnitQuantity
                            // remove the InventoryUnit
                            _context.InventoryUnits.Remove(dbEntity);
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
                        UpdateWarehouseProductWithoutCommit(_context, invMovement, product, null);
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

        public string SaveDirectIssueAny(List<InventoryUnitModel> list, string adjustmentCode, string referenceNo)
        {
            using (var _context = DatabaseContext.Context)
            {
                var msg = string.Empty;
                SaveDirectIssueAndAssignAnyListWithoutCommit(_context, list, adjustmentCode, referenceNo, ref msg);
                _context.SaveChanges();
                var args = new BaseEventArgs<List<InventoryUnitModel>>(list, UpdateMode.DELETE);
                _listener.TriggerInventoryUnitUpdateEvent(null, args);
                return msg;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_context"></param>
        /// <param name="list"></param>
        /// <param name="adjustmentCode"></param>
        /// <param name="referenceNo"></param>
        /// <param name="msg"></param>
        /// <param name="dontRemoveButHold">Either to completely remove from inv. unit list or to seprate it as another unit and set it as hold</param>
        /// <returns></returns>
        public List<InventoryUnit> SaveDirectIssueAndAssignAnyListWithoutCommit(DatabaseContext _context, List<InventoryUnitModel> list, string adjustmentCode, string referenceNo, ref string msg, AssignReleaseViewModel assignRelease = null)
        {
            var now = DateTime.Now;
            var returnList = new List<InventoryUnit>();
            foreach (var model in list)
            {
                var invUnits = SaveDirectIssueAndAssignAnyItemWithoutCommit(_context, model, adjustmentCode, ref msg, referenceNo, assignRelease);
                returnList.AddRange(invUnits);
            }
            return returnList;
        }

        // Handles Sale/Issue/Assign/Release
        public List<InventoryUnit> SaveDirectIssueAndAssignAnyItemWithoutCommit(DatabaseContext _context, InventoryUnitModel model, string adjustmentCode, ref string msg, string referenceNo, AssignReleaseViewModel assignRelease)
        {
            var now = DateTime.Now;
            var list = new List<InventoryUnit>();

            var warehouse = FindWarehouseOrReturnMainWarehouse(_context, model.WarehouseId);
            if (model.ProductId == 0)
                model.ProductId = _context.Products.FirstOrDefault(x => x.Name == model.Product || x.SKU == model.Product)?.Id ?? 0;
            model.WarehouseId = warehouse.Id;

            var query = _context.InventoryUnits
                .Include(x => x.Product)
                .Include(x => x.Warehouse)
                .Where(x => x.ProductId == model.ProductId
                                && x.PackageId != null
                                );

            if (assignRelease == null)
            {
                // if no assign-release then warehouseId should be checked against model's warehouseId
                query = query.Where(x => x.WarehouseId == model.WarehouseId && x.IsHold == model.IsHold);
            }
            if (assignRelease != null)
            {
                switch (assignRelease.TransferType)
                {
                    case TransferTypeEnum.WarehouseToWarehouse:
                    case TransferTypeEnum.WarehouseToDepartment:
                        query = query.Where(x => x.WarehouseId == assignRelease.FromId && x.AssignedToDepartmentId == null && x.AssignedToUserId == null);
                        break;
                    case TransferTypeEnum.DepartmentToWarehouse:
                    case TransferTypeEnum.DepartmentToDepartment:
                    case TransferTypeEnum.DepartmentToUser:
                        query = query.Where(x => x.IsHold == true && x.AssignedToDepartmentId == assignRelease.FromId && x.AssignedToUserId == null);
                        break;
                    case TransferTypeEnum.UserToDepartment:
                    case TransferTypeEnum.UserManufactureConsumed:
                        query = query.Where(x => x.IsHold == true && x.AssignedToUserId == assignRelease.FromId);
                        break;
                }
            }

            var invUnit = query
                .OrderBy(x => x.ReceiveDate)
                .ToList();
            decimal qtySum = 0;
            var fulfilledIndex = -1;
            if (model.PurchaseOrderItemId > 0)
            {
                // in case of cancelling purchase txn we need to prioritize the one inv units of the given purchase order item.
                invUnit = invUnit.OrderBy(x => x.OrderItemId != model.PurchaseOrderItemId).ToList();
            }

            for (var i = 0; i < invUnit.Count(); i++)
            {
                var conversion = _uomService.ConvertUom(invUnit[i].PackageId ?? 0, model.PackageId ?? 0, model.ProductId);
                if (conversion == 0)
                {
                    msg += $"Conversion failed for Unit : {invUnit[i].UnitQuantity} {invUnit[i].Package?.Name ?? ""} of {invUnit[i].Product?.Name ?? ""}\n";
                    continue;
                }
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
                msg += "Some of the products are insufficient to issue. Please verify again.\n";
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
                // we shouldn't use dbEntity once it's removed from _context.InventoryUnits so assign the values here before removing
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
                if (remainInvunitQty < dbEntity.UnitQuantity)
                {
                    // don't remove; just decrement
                    //earlier: issuedQuantity = remainingQty;
                    issuedQuantity = remainInvunitQty;
                    if (assignRelease != null)
                    {
                        var cloned = dbEntity.CloneEntity();
                        cloned.UnitQuantity = remainInvunitQty;
                        if (assignRelease.ToId > 0)
                        {
                            SetAssignTo(ref cloned, assignRelease.ToType, assignRelease.ToId);
                            _context.InventoryUnits.Add(cloned);
                        }
                    }
                    // subtract unit quantity from remaining quantity and leave the unit as it is
                    dbEntity.UnitQuantity = dbEntity.UnitQuantity - remainInvunitQty;
                    //dbEntity.PackageQuantity = GetPackageQuantity(dbEntity.UnitQuantity, dbEntity.Product.UnitsInPackage);

                }
                else
                {
                    issuedQuantity = dbEntity.UnitQuantity;
                    //dbEntity.UnitQuantity = 0;
                    // case is : model.UnitQuantity >= entity.UnitQuantity
                    // remove the InventoryUnit
                    remainingQty -= dbEntity.UnitQuantity / conversion;

                    if (assignRelease != null)
                    {
                        if (assignRelease.ToId > 0)
                        {
                            SetAssignTo(ref dbEntity, assignRelease.ToType, assignRelease.ToId);
                        }
                        else
                        {
                            // if there's no one to assign the remove the entity
                            _context.InventoryUnits.Remove(dbEntity);
                        }
                    }
                    else
                    {
                        _context.InventoryUnits.Remove(dbEntity);
                    }
                }

                // note : don't use dbEntity below this comment line. if you want to use the dbentity then assign it's value to another var before remove() func.
                list.Add(new InventoryUnit { Rate = rate * conversion, UnitQuantity = issuedQuantity / conversion, PackageId = model.PackageId, OrderItemId = orderItemId });
                //
                // Movement
                //
                var description = string.Empty;
                if (assignRelease != null)
                {
                    if(assignRelease.ToId > 0)
                        description = $"Assigned from {assignRelease.FromName} ({assignRelease.FromType.ToString()}) to {assignRelease.ToName} ({assignRelease.ToType.ToString()}) {Math.Round(issuedQuantity, 2)} {packagename} of '{productName}' @ {Math.Round(rate * conversion, 2)}";// from {warehouseName} warehouse.";
                    else 
                        description = $"Issued from {assignRelease.FromName} ({assignRelease.FromType.ToString()}) {Math.Round(issuedQuantity, 2)} {packagename} of '{productName}' @ {Math.Round(rate * conversion, 2)}";// from {warehouseName} warehouse.";
                }
                else
                    description = $"Issued {Math.Round(issuedQuantity, 2)} {packagename} of '{productName}' @ {Math.Round(rate * conversion, 2)}";// from {warehouseName} warehouse.";
                AddMovementWithoutCoomit(_context, description, referenceNo, adjustmentCode, issuedQuantity, now, productId);//"Direct Issue"
                var invMovement = new InventoryMovementModel
                {
                    Date = now,
                    UnitQuantity = issuedQuantity,
                    PackageId = packageId ?? 0, //dbEntity.PackageId ?? 0,
                    SourceWarehouseId = null,//dbEntity.WarehouseId,
                    TargetWarehouseId = null,
                    InventoryUnit = model
                };
                if(assignRelease != null)
                {
                    if (assignRelease.FromType == FromToType.Warehouse)
                        invMovement.SourceWarehouseId = warehouseId;
                    if (assignRelease.ToType == FromToType.Warehouse)
                        invMovement.TargetWarehouseId = warehouseId;
                }
                else
                {
                    invMovement.SourceWarehouseId = warehouseId;
                }

                UpdateWarehouseProductWithoutCommit(_context, invMovement, product, assignRelease);
            }
            return list;
        }
        private void SetAssignTo(ref InventoryUnit dbEntity, FromToType to, int toId)
        {
            switch (to)
            {
                case FromToType.Department:
                    dbEntity.IsHold = true;
                    dbEntity.AssignedToDepartmentId = toId;
                    break;
                case FromToType.Employee:
                    dbEntity.IsHold = true;
                    dbEntity.AssignedToDepartmentId = null;
                    dbEntity.AssignedToUserId = toId;
                    break;
                case FromToType.Warehouse:
                    dbEntity.IsHold = false;
                    dbEntity.AssignedToUserId = null;
                    dbEntity.AssignedToDepartmentId = null;
                    break;
            }
        }
        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_context"></param>
        /// <param name="model"></param>
        /// <param name="adjustmentCode"></param>
        /// <param name="msg"></param>
        /// <param name="referenceNo"></param>
        /// <param name="dontRemoveButHold">Either to completely remove from inv. unit list or to seprate it as another unit and set it as hold</param>
        /// <returns></returns>
        public List<InventoryUnit> SaveDirectIssueAnyItemWithoutCommit(DatabaseContext _context, InventoryUnitModel model, string adjustmentCode, ref string msg, string referenceNo, AssignReleaseViewModel assignRelease)
        {
            var now = DateTime.Now;
            var list = new List<InventoryUnit>();

            var warehouse = FindWarehouseOrReturnMainWarehouse(_context, model.WarehouseId);
            if (model.ProductId == 0)
                model.ProductId = _context.Products.FirstOrDefault(x => x.Name == model.Product || x.SKU == model.Product)?.Id ?? 0;
            model.WarehouseId = warehouse.Id;
            var query = _context.InventoryUnits
                .Include(x => x.Product)
                .Include(x => x.Warehouse)
                .Where(x => x.WarehouseId == model.WarehouseId
                                && x.ProductId == model.ProductId
                                && x.PackageId != null
                                && x.IsHold == model.IsHold);

            var invUnit = query
                .OrderBy(x => x.ReceiveDate)
                .ToList();
            decimal qtySum = 0;
            var fulfilledIndex = -1;
            if (model.PurchaseOrderItemId > 0)
            {
                // in case of cancelling purchase txn we need to prioritize the one inv units of the given purchase order item.
                invUnit = invUnit.OrderBy(x => x.OrderItemId != model.PurchaseOrderItemId).ToList();
            }
            for (var i = 0; i < invUnit.Count(); i++)
            {
                var conversion = _uomService.ConvertUom(invUnit[i].PackageId ?? 0, model.PackageId ?? 0, model.ProductId);
                if (conversion == 0)
                {
                    msg += $"Conversion failed for Unit : {invUnit[i].UnitQuantity} {invUnit[i].Package?.Name ?? ""} of {invUnit[i].Product?.Name ?? ""}\n";
                    continue;
                }
                var invunitqty = invUnit[i].UnitQuantity * conversion;
                qtySum += invunitqty;

                
                //// earlier 
                //qtySum += invUnit[i].UnitQuantity;
                
                if (qtySum >= model.UnitQuantity)
                {
                    fulfilledIndex = i;
                    break;
                }
            }
            if (fulfilledIndex < 0)
            {
                msg += "Some of the products are insufficient to issue. Please verify again.\n";
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
                // we shouldn't use dbEntity once it's removed from _context.InventoryUnits so assign the values here before removing
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
                if (remainInvunitQty < dbEntity.UnitQuantity)
                {
                    // don't remove; just decrement
                    //earlier: issuedQuantity = remainingQty;
                    issuedQuantity = remainInvunitQty;
                    if (assignRelease != null)
                    {
                        var cloned = dbEntity.CloneEntity();
                        cloned.UnitQuantity = remainInvunitQty;
                        cloned.IsHold = true;

                        _context.InventoryUnits.Add(cloned);
                    }
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
                    remainingQty -= dbEntity.UnitQuantity / conversion;

                    if (assignRelease != null)
                        dbEntity.IsHold = true;
                    else
                        _context.InventoryUnits.Remove(dbEntity);
                }
                // note : don't use dbEntity below this comment line. if you want to use the dbentity then assign it's value to another var before remove() func.
                list.Add(new InventoryUnit { Rate = rate * conversion, UnitQuantity = issuedQuantity / conversion, PackageId = model.PackageId, OrderItemId = orderItemId });
                //
                // Movement
                //
                var description = string.Empty;
                if (assignRelease != null)
                    description = $"Assigned to {assignRelease.FromName} ({assignRelease.ToType.ToString()}) {Math.Round(issuedQuantity, 2)} {packagename} of '{productName}' @ {Math.Round(rate * conversion, 2)}";// from {warehouseName} warehouse.";
                else
                    description = $"Issued {Math.Round(issuedQuantity, 2)} {packagename} of '{productName}' @ {Math.Round(rate * conversion, 2)}";// from {warehouseName} warehouse.";
                AddMovementWithoutCoomit(_context, description, referenceNo, adjustmentCode, issuedQuantity, now, productId);//"Direct Issue"
                var invMovement = new InventoryMovementModel
                {
                    Date = now,
                    UnitQuantity = issuedQuantity,
                    PackageId = packageId ?? 0, //dbEntity.PackageId ?? 0,
                    SourceWarehouseId = warehouseId,//dbEntity.WarehouseId,
                    TargetWarehouseId = null,
                    InventoryUnit = model
                };
                UpdateWarehouseProductWithoutCommit(_context, invMovement, product, assignRelease);
            }
            return list;
        }
        */
        public string MoveInventoryUnits(int warehouseId, List<InventoryUnitModel> list)
        {
            using (var _context = DatabaseContext.Context)
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
                        var dbEntity = _context.InventoryUnits
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
                            UpdateWarehouseProductWithoutCommit(_context, invMovement, dbEntity.Product, null);
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
            return _context.PriceHistories.FirstOrDefault(x => x.ProductId == productId && x.Date.Date == date);
        }
    }
}
