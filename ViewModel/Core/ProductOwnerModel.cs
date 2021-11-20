using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core
{
    public class ProductOwnerModel
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public int ProductId { get; set; }
        public int PackageId { get; set; }
        public decimal Quantity { get; set; }
        public System.DateTime UpdatedAt { get; set; }

    }
}
