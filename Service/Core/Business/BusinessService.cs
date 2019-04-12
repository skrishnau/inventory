﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Core.Business;
using Infrastructure.Context;
using Infrastructure.Entities.Business;
using Service.DbEventArgs;
using Service.Listeners;
using Service.Listeners.Business;
using ViewModel.Core.Business;
using ViewModel.Core.Common;

namespace Service.Core.Business
{
    public class BusinessService : IBusinessService
    {
        private readonly DatabaseContext _context;
        private readonly IDatabaseChangeListener _listener;

        public BusinessService(DatabaseContext context, IDatabaseChangeListener listener)
        {
            _context = context;
            _listener = listener;
        }

        public int AddOrUpdateBranch(BranchModel branch)
        {
            var dbEntity = _context.Branch.FirstOrDefault(x => x.Id == branch.Id);
            BranchEventArgs args = BranchEventArgs.Instance;
            if (dbEntity == null)
            {
                var entity = _context.Branch.FirstOrDefault(x => x.Name == branch.Name);
                if (entity != null)
                    return 0;
                // branch save
                dbEntity = BranchMapper.MapToEntity(branch);// branch.ToEntity();
                dbEntity.CreatedAt = DateTime.Now;
                dbEntity.UpdatedAt = DateTime.Now;
                _context.Branch.Add(dbEntity);
                args.Mode = Utility.UpdateMode.ADD;
            }
            else
            {
                dbEntity.Name = branch.Name;
                dbEntity.UpdatedAt = DateTime.Now;
                args.Mode = Utility.UpdateMode.EDIT;
            }
            _context.SaveChanges();
            args.BranchModel = BranchMapper.MapToBranchModel(dbEntity);
            _listener.TriggerBranchUpdateEvent(this, args);
            return dbEntity.Id;
        }

        public void AddOrUpdateCounter(CounterModel counter)
        {
            var dbEntity = _context.Counter.FirstOrDefault(x => x.Id == counter.Id);
            if (dbEntity == null)
            {
                var counterEntity = counter.ToEntity();
                counterEntity.CreatedAt = DateTime.Now;
                counterEntity.UpdatedAt = DateTime.Now;
                _context.Counter.Add(counterEntity);
            }
            else
            {
                dbEntity.Name = counter.Name;
                dbEntity.BranchId = counter.BranchId;
                dbEntity.OutOfOrder = counter.OutOfOrder;
                dbEntity.UpdatedAt = DateTime.Now;
            }
            _context.SaveChanges();
            //throw new NotImplementedException();
        }

        public void AddOrUpdateWarehouse(WarehouseModel warehouse)
        {
            var dbEntity = _context.Warehouse.FirstOrDefault(x => x.Id == warehouse.Id);
            BaseEventArgs<WarehouseModel> args = BaseEventArgs<WarehouseModel>.Instance;
            if (dbEntity == null)
            {
                dbEntity = warehouse.ToEntity();
                dbEntity.CreatedAt = DateTime.Now;
                dbEntity.UpdatedAt = DateTime.Now;
                _context.Warehouse.Add(dbEntity);
                args.Mode = Utility.UpdateMode.ADD;
            }
            else
            {
                dbEntity.Name = warehouse.Name;
                dbEntity.Hold = warehouse.Hold;
                dbEntity.MixedProduct = warehouse.MixedProduct;
                dbEntity.Staging = warehouse.Staging;
                dbEntity.UpdatedAt = DateTime.Now;
                args.Mode = Utility.UpdateMode.EDIT;
            }
            _context.SaveChanges();
            args.Model = WarehouseMapper.MapToWarehouseModel(dbEntity);
            _listener.TriggerWarehouseUpdateEvent(null, args);
        }

        public void DeleteBranch(int branchId)
        {
            var dbEntity = _context.Branch.FirstOrDefault(x => x.Id == branchId);
            if (dbEntity != null)
            {
                dbEntity.DeletedAt = DateTime.Now;
                _context.SaveChanges();
                var args = new BranchEventArgs(BranchMapper.MapToBranchModel(dbEntity), Utility.UpdateMode.DELETE);
                _listener.TriggerBranchUpdateEvent(null, args);
            }
        }

        public void DeleteWarehouse(int id)
        {
            var warehouse = _context.Warehouse.Find(id);
            if (warehouse != null)
            {
                warehouse.DeletedAt = DateTime.Now;
                _context.SaveChanges();
                var args = new BaseEventArgs<WarehouseModel>(WarehouseMapper.MapToWarehouseModel(warehouse), Utility.UpdateMode.DELETE);
                _listener.TriggerWarehouseUpdateEvent(null, args);
            }
        }

        public List<BranchModel> GetBranchList()
        {
            var branches = _context.Branch
                   .Where(x => x.DeletedAt == null)
                   .Select(x => new BranchModel()
                   {
                       Name = x.Name,
                       Id = x.Id,
                       CreatedAt = x.CreatedAt,
                       UpdatedAt = x.UpdatedAt
                   })
                   .ToList();

            return branches;
        }

        public List<CounterModel> GetCounterList()
        {
            var counters = _context.Counter
                   .Where(x => x.DeletedAt == null)
                   .Select(x => new CounterModel()
                   {
                       Name = x.Name,
                       Id = x.Id,
                       BranchId = x.BranchId,
                       OutOfOrder = x.OutOfOrder,
                       CreatedAt = x.CreatedAt,
                       UpdatedAt = x.UpdatedAt
                   })
                   .ToList();

            return counters;
        }

        public WarehouseModel GetWarehouse(int warehouseId)
        {
            var warehouse = _context.Warehouse.Find(warehouseId);
            if(warehouse != null)
            {
                return WarehouseMapper.MapToWarehouseModel(warehouse);
            }
            return null;
        }

        private IQueryable<Warehouse> GetWarehouseEntityList()
        {
            return _context.Warehouse
                  .Where(x => x.DeletedAt == null);
        }

        public List<WarehouseModel> GetWarehouseList()
        {
            var warehouses = GetWarehouseEntityList()
                   .Select(x => new WarehouseModel()
                   {
                       Name = x.Name,
                       Id = x.Id,
                       Hold = x.Hold,
                       MixedProduct = x.MixedProduct,
                       Staging = x.Staging
                   })
                   .ToList();

            return warehouses;

        }

        public List<IdNamePair> GetWarehouseIdNameList()
        {
            var warehouses = GetWarehouseEntityList()
                   .Select(x => new IdNamePair()
                   {
                       Id = x.Id,
                       Name = x.Name,
                   })
                   .ToList();

            return warehouses;

        }

        public List<WarehouseModel> GetWarehouseListUsableOnly()
        {
            return GetWarehouseList();//.Where(x=>x.Use)

        }
    }
}
