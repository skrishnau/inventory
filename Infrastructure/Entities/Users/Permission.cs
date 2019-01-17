using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Users
{
    /// <summary>
    /// Still confused... needs analysis...
    ///  This table is seeded at startup; 
    ///  Contains all the actions of the system.
    /// </summary>
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
