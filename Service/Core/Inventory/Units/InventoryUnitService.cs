using DTO.Core.Inventory;
using Infrastructure.Context;
using Service.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Inventory;
using System.Data.Entity;
using Infrastructure.Entities.Inventory;
using Service.Utility;
using Service.DbEventArgs;
using Service.Enums;

namespace Service.Core.Inventory.Units
{
    public class InventoryUnitService : IInventoryUnitService
    {
        private readonly DatabaseContext _context;

        private readonly IDatabaseChangeListener _listener;

        public InventoryUnitService(DatabaseContext context, IDatabaseChangeListener listener)
        {
            _context = context;
            _listener = listener;
        }

        public List<InventoryUnitModel> GetInventoryUnitList()
        {
            var query = _context.InventoryUnit
                .Include(x => x.Product)
                .Include(x => x.Package)
                .Include(x => x.Supplier)
                .Include(x => x.Uom)
                .Include(x => x.Warehouse)
                .AsQueryable();
            return InventoryUnitMapper.MapToModel(query);
        }

        public void MergeInventoryUnits(List<InventoryUnitModel> list)
        {
            foreach (var invUnitGroup in list.GroupBy(x => x.ProductId))
            {
                DateTime now = DateTime.Now;
                var product = _context.Product.Find(invUnitGroup.Key);
                if (product != null)
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
                            }
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
                        editingRecord.UnitQuantity = unitQuantity;
                        //var unitsInPackage = product.UnitsInPackage == 0 ? 1 : product.UnitsInPackage;
                        //editingRecord.PackageQuantity = Math.Ceiling(unitQuantity / unitsInPackage) + (unitQuantity % unitsInPackage == 0 ? 0 : 1);
                        editingRecord.PackageQuantity = packageQuantity;
                        //
                        // Movement
                        //
                        var description = "Merged " + list.Count + " units of " + product.Name + " into one and placed in " + editingRecord.Warehouse.Name + " warehouse.";
                        SaveMovement(description, "-------------", "Merge", editingRecord.UnitQuantity, now);

                    }
                }
            }


            _context.SaveChanges();
            var args = new BaseEventArgs<List<InventoryUnitModel>>(list, UpdateMode.EDIT);
            _listener.TriggerInventoryUnitUpdateEvent(null, args);
        }

        public void MoveInventoryUnits(int warehouseId, List<InventoryUnitModel> list)
        {
            DateTime now = DateTime.Now;
            var warehouseEntity = _context.Warehouse.Find(warehouseId);
            if (warehouseEntity != null)
            {
                foreach (var iuModel in list)
                {
                    // first find
                    var dbEntity = _context.InventoryUnit
                        .Include(x => x.Warehouse)
                        .FirstOrDefault(x => x.Id == iuModel.Id && x.WarehouseId != warehouseId);
                    if (dbEntity != null)
                    {
                        dbEntity.WarehouseId = warehouseId;
                        //
                        // Movement
                        //
                        var description = "Moved " + list.Count + " units from " + dbEntity.Warehouse.Name + " to " + warehouseEntity.Name + ".";
                        SaveMovement(description, "", "Move", dbEntity.UnitQuantity, now);
                    }
                }

            }
            _context.SaveChanges();
            var args = new BaseEventArgs<List<InventoryUnitModel>>(list, UpdateMode.EDIT);
            _listener.TriggerInventoryUnitUpdateEvent(null, args);
        }

        public void SplitInventoryUnit(List<decimal> quantitySplitList, InventoryUnitModel model)
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
                        quantitySplitList.ForEach(x => { splitString += x + "+"; });
                        splitString.Trim(new char[] { '+' });
                        var description = "Splitted a unit with " + entity.UnitQuantity + " quantities of " + entity.Product.Name + " into " + splitString + ".";
                        SaveMovement(description, "----------------", "Split", entity.UnitQuantity, now);

                        for (var q = 0; q < quantitySplitList.Count; q++)
                        {
                            var quantity = quantitySplitList[q];
                            if (quantity > 0)
                            {
                                var unitsInPackage = entity.Product.UnitsInPackage == 0 ? 1 : entity.Product.UnitsInPackage;
                                if (q == 0)
                                {
                                    // update the first entry 
                                    entity.UnitQuantity = quantity;
                                    entity.PackageQuantity = Math.Ceiling(quantity / unitsInPackage) + (quantity % unitsInPackage == 0 ? 0 : 1);
                                }
                                else
                                {
                                    // create new entry for the rest of the splits
                                    var newEntity = InventoryUnitMapper.CloneEntity(entity);
                                    newEntity.Id = 0;
                                    newEntity.UnitQuantity = quantity;
                                    newEntity.PackageQuantity = Math.Ceiling(quantity / unitsInPackage) + (quantity % unitsInPackage == 0 ? 0 : 1);
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

        public string SaveDirectReceive(List<InventoryUnitModel> list)
        {
            var now = DateTime.Now;
            var msg = string.Empty;
            var entityList = InventoryUnitMapper.MapToEntity(list);
            _context.InventoryUnit.AddRange(entityList);

            //
            // Movement
            //
            foreach (var unit in list)
            {
                var description = "Received " + unit.UnitQuantity + " quantities of " + unit.Product + " into " + unit.Warehouse + " warehouse.";
                var quantity = list.Sum(x => x.UnitQuantity);
                SaveMovement(description, "----------------", "Direct Receive", quantity, now);
            }

            _context.SaveChanges();
            // var list = InventoryUnitMapper.MapToModel(updatedEntryList);
            var args = new BaseEventArgs<List<InventoryUnitModel>>(list, UpdateMode.EDIT);
            _listener.TriggerInventoryUnitUpdateEvent(null, args);
            return msg;
        }

        //
        // Direct Issue
        //
        public string SaveDirectIssue(List<InventoryUnitModel> list)
        {
            var now = DateTime.Now;

            var msg = string.Empty;
            foreach (var model in list)
            {
                var dbEntity = _context.InventoryUnit
                    .Include(x => x.Product)
                    .FirstOrDefault(x => x.Id == model.Id);
                if (dbEntity != null)
                {
                    if (model.UnitQuantity < dbEntity.UnitQuantity)
                    {
                        // don't remove; just decrement
                        dbEntity.UnitQuantity = dbEntity.UnitQuantity - model.UnitQuantity;
                        dbEntity.PackageQuantity = GetPackageQuantity(dbEntity.UnitQuantity, dbEntity.Product.UnitsInPackage);
                    }
                    else
                    {
                        // case is : model.UnitQuantity >= entity.UnitQuantity
                        // remove the InventoryUnit
                        _context.InventoryUnit.Remove(dbEntity);
                    }
                    //
                    // Movement
                    //
                    var description = "Direct Issue " + dbEntity.Product.Name + " from warehouse " + dbEntity.Warehouse.Name + ".";
                    SaveMovement(description, "----------------", "Direct Issue", dbEntity.UnitQuantity, now);
                }
            }




            _context.SaveChanges();
            var args = new BaseEventArgs<List<InventoryUnitModel>>(list, UpdateMode.DELETE);
            _listener.TriggerInventoryUnitUpdateEvent(null, args);
            return msg;
        }

        private decimal GetPackageQuantity(decimal unitQuantity, decimal unitsInPackage)
        {
            unitsInPackage = unitsInPackage == 0 ? 1 : unitsInPackage;
            return Math.Ceiling(unitQuantity / unitsInPackage) + (unitQuantity % unitsInPackage == 0 ? 0 : 1);
        }

        public List<MovementModel> GetMovementList()
        {
            var query = _context.Movement
                .OrderByDescending(x=>x.Date)
                .AsQueryable();
            return MovementMapper.MapToModel(query);
        }

        public void SaveMovement(string description, string reference, string adjustmentCode, decimal quantity, DateTime now)
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
