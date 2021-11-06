using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Users;

namespace ViewModel.Core
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsVendor { get; set; }
        public Nullable<int> HeadUserId { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }

        public List<UserModel> DepartmentUsers { get; set; }
    }
}
