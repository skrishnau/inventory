using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core
{
    public class ManufactureModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LotNo { get; set; }
        public string Remarks { get; set; }

        public string Status { get; set; }

        public System.DateTime CreatedAt { get; set; }
        public int CreatedByUserId { get; set; }
        public Nullable<System.DateTime> StartedAt { get; set; }
        public Nullable<int> StartedByUserId { get; set; }
        public Nullable<System.DateTime> CompletedAt { get; set; }
        public Nullable<int> CompletedByUserId { get; set; }
        public Nullable<System.DateTime> CancelledAt { get; set; }
        public Nullable<int> CancelledByUserId { get; set; }

        public List<ManufactureDepartmentModel> ManufactureDepartments { get; set; }
    }
}
