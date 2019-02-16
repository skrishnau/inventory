using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities.Business;

namespace ViewModel.Core.Business
{
    public class CounterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BranchId { get; set; }
        public bool OutOfOrder { get; set; }

        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }


        public Counter ToEntity()
        {
            return new Counter
            {
                Id = Id,
                CreatedAt = CreatedAt,
                UpdatedAt = UpdatedAt,
                Name = Name,
                OutOfOrder = OutOfOrder,
                BranchId = BranchId,
            };

        }
    }
}
