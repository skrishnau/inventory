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

namespace Service.Core.Inventory.Units
{
    public class InventoryUnitService : IInventoryUnitService
    {
        // private readonly DatabaseContext _context;

        private readonly IDatabaseChangeListener _listener;

        public InventoryUnitService(IDatabaseChangeListener listener)//DatabaseContext context,
        {
            //_context = context;
            _listener = listener;
        }

        public List<InventoryUnitModel> GetInventoryUnitList(int warehouseId, int productId)
        {
            using (var _context = new DatabaseContext())
            {

                var query = _context.InventoryUnit
                    .Include(x => x.Product)
                    .Include(x => x.Package)
                    .Include(x => x.Supplier)
                    .Include(x => x.Uom)
                    .Include(x => x.Warehouse)
                    .Where(x => (warehouseId == 0 || x.WarehouseId == warehouseId)
                            && (productId == 0 || x.ProductId == productId))
                    .OrderBy(x => x.ReceiveDate)
                    //.ThenBy(x => x.Warehouse.Name)
                    //.ThenBy(x => x.Product.Name)
                    .AsQueryable();
                return InventoryUnitMapper.MapToModel(query);
            }
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
                            if (invUnitGroup.Count() >= 2)
                            {
                                // means there are 2 or more items for this product
                                var unitQuantity = 0M;
                                var packageQuantity = 0M;
                                InventoryUnit editingRecord = null;
                                for (var i = 0; i < invUnitGroup.Count(); i++)
                                {
                                    var dbEntity = _context.InventoryUnit
                                        .Find(invUnitGroup.ElementAt(i).Id);
                                    if (dbEntity != null)
                                    {
                                        unitQuantity += dbEntity.UnitQuantity;
                                        packageQuantity += dbEntity.PackageQuantity;
                                        if (i < invUnitGroup.Count() - 1)
                                        {
                                            // remove
                                            _context.InventoryUnit.Remove(dbEntity);
                                            invUnitGroup.ElementAt(i).UpdateAction = UpdateMode.DELETE.ToString();
                                        }
                                        else
                                        {
                                            // get the last entity ; 
                                            // TODO:: assign the value from multiple entities to the newly created 
                                            editingRecord = dbEntity;
                                            invUnitGroup.ElementAt(i).UpdateAction = UpdateMode.EDIT.ToString();
                                        }
                                    }
                                }
                                editingRecord.UnitQuantity = unitQuantity;
                                //var unitsInPackage = product.UnitsInPackage == 0 ? 1 : product.UnitsInPackage;
                                editingRecord.PackageQuantity = GetPackageQuantity(unitQuantity, product.UnitsInPackage);// Math.Ceiling(unitQuantity / unitsInPackage) + (unitQuantity % unitsInPackage == 0 ? 0 : 1);
                                                                                                                         //editingRecord.PackageQuantity = packageQuantity;
                                                                                                                         //
                                                                                                                         // Movement
                                                                                                                         //
                                string splitString = "";
                                list.ForEach(x => { splitString += x.UnitQuantity + " + "; });
                                splitString = splitString.Trim();
                                splitString = splitString.TrimEnd(new char[] { '+' });
                                var description = "Merged " + splitString + " of '" + product.Name + "' into " + editingRecord.UnitQuantity + " qty.";
                                AddMovement(_context, description, "-------------", "Merge", editingRecord.UnitQuantity, now);

                            }

                        }
                    }
                }


                _context.SaveChanges();
                var args = new BaseEventArgs<List<InventoryUnitModel>>(list, UpdateMode.EDIT);
                _listener.TriggerInventoryUnitUpdateEvent(null, args);
            }
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
                            AddMovement(_context, description, "----------------", "Split", entity.UnitQuantity, now);

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
                var warehouseEntity = _context.Warehouse.Find(warehouseId);
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
                            UpdateWarehouseProduct(iuModel, iuModel.UnitQuantity, dbEntity.Warehouse.Id, warehouseEntity.Id, now);
                            AddMovement(_context, description, "--------------", "Move", dbEntity.UnitQuantity, now);
                        }
                    }
                }
                _context.SaveChanges();
                var args = new BaseEventArgs<List<InventoryUnitModel>>(list, UpdateMode.EDIT);
                _listener.TriggerInventoryUnitUpdateEvent(null, args);
                return msg;
            }
        }

        public string SaveDirectReceive(List<InventoryUnitModel> list, string adjustmentCode)
        {
            using (var _context = new DatabaseContext())
            {

                var now = DateTime.Now;
                var msg = string.Empty;
                var entityList = InventoryUnitMapper.MapToEntity(list);
                _context.InventoryUnit.AddRange(entityList);
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
                    var product = _context.Product.Find(unit.ProductId);
                    var warehouse = _context.Warehouse.Find(unit.WarehouseId);
                    var description = "Received " + unit.UnitQuantity + " quantities of " +
                        product.Name + " into " + warehouse.Name + " warehouse.";
                    //var quantity = list.Sum(x => x.UnitQuantity);
                    AddMovement(_context, description, "----------------", adjustmentCode, unit.UnitQuantity, now);//"Direct Receive"
                    UpdateWarehouseProduct(unit, unit.UnitQuantity, null, unit.WarehouseId, now);
                }

                _context.SaveChanges();
                // var list = InventoryUnitMapper.MapToModel(updatedEntryList);
                var args = new BaseEventArgs<List<InventoryUnitModel>>(list, UpdateMode.EDIT);
                _listener.TriggerInventoryUnitUpdateEvent(null, args);
                return msg;
            }
        }

        //
        // Direct Issue of whole Inventory-Unit
        //
        public string SaveDirectIssueInventoryUnit(List<InventoryUnitModel> list, string adjustmentCode)
        {
            using (var _context = new DatabaseContext())
            {

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
                        AddMovement(_context, description, "----------------", adjustmentCode, dbEntity.UnitQuantity, now);//"Direct Issue"
                        UpdateWarehouseProduct(model, issuedQuantity, dbEntity.WarehouseId, null, now);
                    }
                }

                _context.SaveChanges();
                var args = new BaseEventArgs<List<InventoryUnitModel>>(list, UpdateMode.DELETE);
                _listener.TriggerInventoryUnitUpdateEvent(null, args);
                return msg;
            }
        }

        //
        // Direct Issue of any product
        //
        public string SaveDirectIssueAny(List<InventoryUnitModel> list, string adjustmentCode)
        {
            using (var _context = new DatabaseContext())
            {

                var now = DateTime.Now;

                var msg = string.Empty;
                foreach (var model in list)
                {
                    var invUnit = _context.InventoryUnit
                        .Include(x => x.Product)
                        .Include(x => x.Warehouse)
                        .Where(x => x.WarehouseId == model.WarehouseId
                                        && x.ProductId == model.ProductId
                                        && x.IsHold == model.IsHold)
                        .OrderBy(x=>x.LotNumber)
                        .ToList();
                    decimal qtySum = 0;
                    var fulfilledIndex = -1;
                    for(var i =0; i < invUnit.Count(); i++)
                    {
                        qtySum += invUnit[0].UnitQuantity;
                        if(qtySum >= model.UnitQuantity)
                        {
                            fulfilledIndex = i;
                            break;
                        }
                    }
                    if (fulfilledIndex < 0)
                    {
                        return "Some of the products are insufficient to issue. Please verify again.";
                    }

                    // start issue 
                    decimal remainingQty = model.UnitQuantity;
                    for(var i=0; i<=fulfilledIndex; i++)
                    {
                        var dbEntity = invUnit[i];
                        var productName = dbEntity.Product.Name;
                        var warehouseName = dbEntity.Warehouse.Name;
                        var issuedQuantity = 0M;
                        
                        if (remainingQty < dbEntity.UnitQuantity)
                        {
                            // don't remove; just decrement
                            issuedQuantity = remainingQty;
                            dbEntity.UnitQuantity = dbEntity.UnitQuantity - remainingQty;
                            dbEntity.PackageQuantity = GetPackageQuantity(dbEntity.UnitQuantity, dbEntity.Product.UnitsInPackage);
                        }
                        else
                        {
                            issuedQuantity = dbEntity.UnitQuantity;
                            // case is : model.UnitQuantity >= entity.UnitQuantity
                            // remove the InventoryUnit
                            _context.InventoryUnit.Remove(dbEntity);
                            remainingQty -= dbEntity.UnitQuantity;
                        }
                        //
                        // Movement
                        //
                        var description = "Issued " + issuedQuantity + " qty. of '" + productName + "' from " + warehouseName + " warehouse.";
                        AddMovement(_context, description, "----------------", adjustmentCode, dbEntity.UnitQuantity, now);//"Direct Issue"
                        UpdateWarehouseProduct(model, issuedQuantity, dbEntity.WarehouseId, null, now);
                    }
                }

                _context.SaveChanges();
                var args = new BaseEventArgs<List<InventoryUnitModel>>(list, UpdateMode.DELETE);
                _listener.TriggerInventoryUnitUpdateEvent(null, args);
                return msg;
            }
        }

        private decimal GetPackageQuantity(decimal unitQuantity, decimal unitsInPackage)
        {
            unitsInPackage = unitsInPackage == 0 ? 1 : unitsInPackage;
            return Math.Ceiling(unitQuantity / unitsInPackage) + (unitQuantity % unitsInPackage == 0 ? 0 : 1);
        }

        public List<MovementModel> GetMovementList()
        {
            using (var _context = new DatabaseContext())
            {

                var query = _context.Movement
                    .OrderByDescending(x => x.Date)
                    .AsQueryable();
                return MovementMapper.MapToModel(query);
            }
        }


        /// <summary>
        /// Updates WarehouseProduct table
        /// </summary>
        /// <param name="iuModel">Inventory Unit</param>
        /// <param name="sourceWarehouseId">The warehouse from which to subtract the unit's UnitQuantity</param>
        /// <param name="targetWarehouseId">The warehouse to which to add the unit's UnitQuantity</param>
        /// <param name="now"></param>
        public void UpdateWarehouseProduct(InventoryUnitModel iuModel, decimal unitQuantity, int? sourceWarehouseId, int? targetWarehouseId, DateTime now)
        {
            using (var _context = new DatabaseContext())
            {
                var product = _context.Product.Find(iuModel.ProductId);
                if (product != null)
                {
                    // subtract from source warehouse (fromWarehouse)
                    if (sourceWarehouseId != null)
                    {
                        var fromWp = _context.WarehouseProduct
                            .Include(x => x.Warehouse)
                            .Include(x => x.Product)
                            .FirstOrDefault(x => x.ProductId == iuModel.ProductId
                                    && x.WarehouseId == sourceWarehouseId);
                        if (fromWp != null)
                        {
                            // update FromWarehouse
                            fromWp.InStockQuantity -= unitQuantity;//iuModel.UnitQuantity;
                            fromWp.OnHoldQuantity -= iuModel.IsHold ? unitQuantity : 0; //iuModel.OnHoldQuantity : 0;
                            fromWp.UpdatedAt = now;
                            fromWp.Product.InStockQuantity -= unitQuantity;// iuModel.UnitQuantity;
                            fromWp.Product.OnHoldQuantity -= iuModel.IsHold ? unitQuantity : 0;// iuModel.OnHoldQuantity : 0;
                        }
                    }
                    if (targetWarehouseId != null)
                    {

                        // var toId = target == null ? 0 : target.Id;
                        var toWp = _context.WarehouseProduct
                            .Include(x => x.Warehouse)
                            .Include(x => x.Product)
                            .FirstOrDefault(x => x.ProductId == iuModel.ProductId
                                    && x.WarehouseId == targetWarehouseId);
                        // add to the target warehouse (toWarehouse)
                        if (toWp == null)
                        {
                            using (var txn = _context.Database.BeginTransaction())
                            {
                                // add
                                toWp = new WarehouseProduct()
                                {
                                    WarehouseId = targetWarehouseId ?? 0,
                                    ProductId = iuModel.ProductId,
                                };
                                // update
                                toWp.InStockQuantity += unitQuantity; // iuModel.UnitQuantity;
                                toWp.OnHoldQuantity += iuModel.IsHold ? unitQuantity : 0;//iuModel.OnHoldQuantity : 0;
                                toWp.UpdatedAt = now;
                                _context.WarehouseProduct.Add(toWp);
                                // need to do _context.SaveChanges(); Reason: in case of multiple add; the context won't still have the
                                // added warehouseProduct. and searching in context in next loop won't give the previously added 
                                // warehouseProduct. Hence multiple rows for same (product,warehouse) is created.  so first save it.
                                _context.SaveChanges();
                                txn.Commit();
                            }

                        }
                        else
                        {
                            // update
                            toWp.InStockQuantity += iuModel.UnitQuantity;
                            toWp.OnHoldQuantity += iuModel.IsHold ? iuModel.OnHoldQuantity : 0;
                            toWp.UpdatedAt = now;
                        }
                        product.InStockQuantity += iuModel.UnitQuantity;
                        product.OnHoldQuantity += iuModel.IsHold ? iuModel.OnHoldQuantity : 0;
                    }
                }
                _context.SaveChanges();
            }
        }


        public void AddMovement(DatabaseContext _context, string description, string reference, string adjustmentCode, decimal quantity, DateTime now)
        {
            var movement = new Movement()
            {
                AdjustmentCode = adjustmentCode,
                Date = now,
                Description = description,
                Quantity = quantity,
                Reference = reference,
            };
            _context.Movement.Add(movement);
        }


    }
}
