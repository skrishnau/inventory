using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Business
{
    /// <summary>
    /// The point of sale Counter (Booth).
    /// </summary>
    public class Counter
    {
        public int Id { get; set; }
        // code word e.g. 1, 2, 3 ... or any other format
        public string Name { get; set; }
        // branch which controls this counter; i.e. this counter is under a branch (POS)
        public int BranchId { get; set; }

        // to indicate if this counter is out of order... 
        // this status should be logged in history table...
        public bool OutOfOrder { get; set; }

        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        // ====== Table objects ====== //
        public virtual Branch Branch { get; set; }

    }
}
