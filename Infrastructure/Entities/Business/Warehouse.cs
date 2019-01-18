using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Business
{
    /// <summary>
    /// Generally warehouse is used as hub between import and supply 
    ///         or to store stocks in chunks. 
    /// Warehouse is independent of Branch but we could relate 
    ///     these as "Warehouse nearest to the branches". 
    ///     This concept will help to move stocks from a warehouse to nearest branch only
    /// </summary>
    public class Warehouse
    {
        public int Id { get; set; }
        // location of the warehouse
        public string Location { get; set; }
        // warehouse code;
        public string Code { get; set; }

        // ========== Settings ============ //
        // whether this warehouse can directly transfer its stocks to branches
        // if false then this warehouse will only transfer its stocks to another warehouse only
        public bool CanMoveStocksToBranch { get; set; }
        // public bool ShouldMoveStocksToNearestBranchOnly { get; set;}


        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        // ============== Table Objects ==============//
        public virtual Branch Branch { get; set; }

    }
}
