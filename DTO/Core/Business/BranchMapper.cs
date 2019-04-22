using Infrastructure.Entities.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Business;

namespace DTO.Core.Business
{
    public static class BranchMapper
    {
        public static Branch MapToEntity(BranchModel branch)
        {
            var branchEntity  = new Branch
            {
                CreatedAt = branch.CreatedAt,
               // DeletedAt = branch.DeletedAt,
                Id = branch.Id,
                Name = branch.Name,
                UpdatedAt = branch.UpdatedAt
            };
            //branchEntity.Warehouses = WarehouseMapper.MapToEntity(branch.Warehouses);
            branchEntity.Counters = CounterMapper.MapToEntity(branch.Counters);
            return branchEntity;
        }

        public static BranchModel MapToBranchModel(Branch branch)
        {
            var branchModel = new BranchModel
            {
                CreatedAt = branch.CreatedAt,
               // DeletedAt = branch.DeletedAt,
                Id = branch.Id,
                Name = branch.Name,
                UpdatedAt = branch.UpdatedAt
            };
            //branchEntity.Warehouses = WarehouseMapper.MapToEntity(branch.Warehouses);
            //branchEntity.Counters = CounterMapper.MapToEntity(branch.Counters);
            return branchModel;
        }

    }
}
