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
        public BranchModel()
        {
            Warehouses = new List<WarehouseModel>();
            Counters = new List<CounterModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<WarehouseModel> Warehouses { get; set; }
        public ICollection<CounterModel> Counters { get; set; }


        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        
    }
}
