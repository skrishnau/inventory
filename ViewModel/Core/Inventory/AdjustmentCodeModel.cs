using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Inventory
{
    public class AdjustmentCodeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool AffectsDemand { get; set; }
        public bool Use { get; set; }

        public bool IsSystem { get; set; }
    }
}
