using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Inventory
{
    /// <summary>
    /// Generally warehouse is used as hub between import and supply 
    ///             or to store stocks in chunks. 
    /// Warehouse is independent of Branch but we could relate 
    ///     these as "Warehouse nearest to the branches". 
    ///     This concept will help to move stocks from a warehouse to nearest branch only
    /// </summary>
    public class Warehouse
    {
        public int Id { get; set; }

        // location of the warehouse
        public string Name { get; set; }

        // Can hold the stocks
        public bool Hold { get; set; }
        // if this warehouse can hold Mixed Products. the first inbound product can only be added until all removed
        public bool MixedProduct { get; set; }
        //StagingLocation: An area reserved for inventory that is ready for final assembly or transport.
        //Read more: http://www.businessdictionary.com/definition/staging-location.html
        public bool Staging { get; set; }
        public bool Use { get; set; }
        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
       // public DateTime? DeletedAt { get; set; }

        // ============== Table Objects ==============//
        //  public virtual Branch Branch { get; set; }

    }
}
