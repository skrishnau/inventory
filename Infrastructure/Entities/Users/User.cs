using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Users
{
    /// <summary>
    /// User is the person who has access to the system (based on permissions)
    /// For now Supplier and Customers have NO or Limited access.
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        // username
        public string Username { get; set; }
        // hashed password
        public string Password { get; set; }

        public int BasicInfoId { get; set; }
       
        // UserType is one of (Supplier, Customer or User(own)); will be used in future versions when we implement Web
        // This concept is needed if we allow Suppliers and Customers access into our system, for
        //       sale orders and purchase orders (orders require their's involvement)
        public string UserType { get; set; }
        // to indicate if the user can login i.e. if has access to the system (based on permissions)
        public bool CanLogin { get; set; }
        // role; user has only one role
        //public int RoleId { get; set; }
        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        // ============= Table objects ===============//
        //public virtual Role Role { get; set; }

        public virtual BasicInfo BasicInfo { get; set; }


    }
}
