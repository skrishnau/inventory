using Infrastructure.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Users
{
    /// <summary>
    /// Defines which role has which action permitted.. 
    /// </summary>
    public class Permission
    {
        public int Id { get; set; }
        // action 
        public int SystemActionId { get; set; }
        // role
        public int RoleId { get; set; }
        
        // =============== Table Objects ================ //
        public virtual SystemAction SystemAction { get; set; }
        public virtual Role Role { get; set; }
    }
}
