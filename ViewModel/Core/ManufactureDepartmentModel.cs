using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core
{
    public class ManufactureDepartmentModel
    {
        public int Id { get; set; }
        public int ManufactureId { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public bool IsVendor { get; set; }
        public Nullable<int> HeadUserId { get; set; }
        public int Position { get; set; }

        public decimal Quantity { get; set; }

        public List<ManufactureDepartmentUserModel> ManufactureDepartmentUsers { get; set; }
        public List<ManufactureDepartmentProductModel> ManufactureDepartmentProducts { get; set; }
    }
}
