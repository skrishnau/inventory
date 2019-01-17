using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Users
{
    /// <summary>
    /// Role is user definable; "Admin" role is the only role that's System defined and not editable
    /// Seed "Admin" role at system startup
    /// </summary>
    public class Role
    {
        public int Id { get; set; }
        // role name; e.g. Admin, Reception, POS Admin, POS reception, Warehouse Admin, Supplier, Customer, etc.
        public string Name { get; set; }
        // to indicate if this is defined by system and non-editable by users
        public bool isSystemDefined { get; set; }
        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
