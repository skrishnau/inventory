using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Core.Business;
using Infrastructure.Context;
using Infrastructure.Entities.Business;
using ViewModel.Core.Business;

namespace Service.Core.Business
{
    public class BusinessService : IBusinessService
    {
        private readonly DatabaseContext _context;

        public BusinessService(DatabaseContext context)
        {
            _context = context;
        }

        public int AddOrUpdateBranch(BranchModel branch)
        {
            var dbEntity = _context.Branch.FirstOrDefault(x => x.Id == branch.Id);
            if (dbEntity == null)
            {
                var entity = _context.Branch.FirstOrDefault(x => x.Name == branch.Name);
                if (entity != null)
                    return 0;
                // branch save
                var branchEntity = branch.ToEntity();
                branchEntity.CreatedAt = DateTime.Now;
                branchEntity.UpdatedAt = DateTime.Now;
                _context.Branch.Add(branchEntity);
                if (branchEntity.Warehouses == null)
                    branchEntity.Warehouses = new List<Warehouse>();
                var warehouseEntity = branch.Warehouses.ElementAt(0).ToEntity();
                warehouseEntity.CreatedAt = DateTime.Now;
                warehouseEntity.UpdatedAt = DateTime.Now;
                branchEntity.Warehouses.Add(warehouseEntity);

                _context.SaveChanges();
                // warehouse save
               /* warehouseEntity.BranchId = branchEntity.Id;
                warehouseEntity.CreatedAt = DateTime.Now;
                warehouseEntity.UpdatedAt = DateTime.Now;
                _context.Warehouse.Add(warehouseEntity);
                _context.SaveChanges();*/
                //entity = _context.Branch.FirstOrDefault(x => x.Name == branch.Name);
                return branchEntity.Id;
            }
            else
            {
                dbEntity.Name = branch.Name;
                dbEntity.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return dbEntity.Id;
            }


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
            if (dbEntity == null)
            {
                var warehouseEntity = warehouse.ToEntity();
                warehouseEntity.CreatedAt = DateTime.Now;
                warehouseEntity.UpdatedAt = DateTime.Now;
                _context.Warehouse.Add(warehouseEntity);
                //_context.SaveChanges();
            }
            else
            {
                dbEntity.Location = warehouse.Location;
                dbEntity.BranchId = warehouse.BranchId;
                dbEntity.Code = warehouse.Code;
                dbEntity.CanMoveStocksToBranch = warehouse.CanMoveStocksToBranch;
                dbEntity.UpdatedAt = DateTime.Now;
            }
            _context.SaveChanges();

        }

        public void DeleteBranch(BranchModel model)
        {
            var dbEntity = _context.Branch.FirstOrDefault(x => x.Id == model.Id);
            if (dbEntity != null)
            {
                dbEntity.DeletedAt = DateTime.Now;
                _context.SaveChanges();
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

        public List<WarehouseModel> GetWarehouseList()
        {
            var warehouses = _context.Warehouse
                   .Where(x => x.DeletedAt == null)
                   .Select(x => new WarehouseModel()
                   {
                       Location = x.Location,
                       CanMoveStocksToBranch = x.CanMoveStocksToBranch,
                       Code = x.Code,
                       Id = x.Id,
                       BranchId = x.BranchId,
                       CreatedAt = x.CreatedAt,
                       UpdatedAt = x.UpdatedAt
                   })
                   .ToList();

            return warehouses;

        }
    }
}
