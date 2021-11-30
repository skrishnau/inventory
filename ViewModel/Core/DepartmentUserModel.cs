using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core
{
    public class DepartmentUserModel
    {
        public int DepartmentId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string User { get; set; }
        public Nullable<decimal> BuildRate { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
    }
}
