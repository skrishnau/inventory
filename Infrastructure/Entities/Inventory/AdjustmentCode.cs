using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Inventory
{
    public class AdjustmentCode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool AffectsDemand { get; set; }
        public bool Use { get; set; }
    }
}
