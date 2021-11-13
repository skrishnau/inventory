using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core
{
    public class ManufactureDepartmentUserModel
    {
        public int ManufactureDepartmentId { get; set; }
        public int UserId { get; set; }
        public Nullable<decimal> BuildRate { get; set; }
        public string Name { get; set; } // user's name
        public bool Check { get; set; }
    }
}
