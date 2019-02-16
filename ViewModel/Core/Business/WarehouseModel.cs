using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities.Business;

namespace ViewModel.Core.Business
{
    public class WarehouseModel
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Code { get; set; }
        public int BranchId { get; set; }
        public bool CanMoveStocksToBranch { get; set; }

        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }


        public Warehouse ToEntity()
        {
            return new Warehouse
            {
                Id = Id,
                CreatedAt = CreatedAt,
                UpdatedAt = UpdatedAt,
                Location = Location,
                Code = Code,
                CanMoveStocksToBranch = CanMoveStocksToBranch,
                BranchId = BranchId,
            };

        }
    }
}
