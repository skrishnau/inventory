using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Common
{
    /// <summary>
    ///  This table should be seeded at startup; 
    ///  Contains all the actions of the system.
    ///  This table conveys control's action e.g. Purchase edit, Purchase Order Create, User create
    ///         , User Edit etc.
    /// </summary>
    public class SystemAction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // name of the control; e.g. Purchase, Sale, User, Product, Warehouse.
        public string Controller { get; set; }
        // action; e.g. Add, Edit, Delete, Update, View, etc.
        public string Action { get; set; }
        
    }
}
