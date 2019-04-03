using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities.Business;

namespace ViewModel.Core.Business
{
    public class BranchModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }


        public List<WarehouseModel> Warehouses { get; set; }

        public Branch ToEntity()
        {
            return new Branch
            {
                CreatedAt = CreatedAt,
                DeletedAt = DeletedAt,
                Id = Id,
                Name = Name,
                UpdatedAt = UpdatedAt
            };
        }
    }
}
