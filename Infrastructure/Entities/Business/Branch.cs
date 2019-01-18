using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Business
{
    /// <summary>
    /// Branch is not an office, rather it's Point of Sale 
    ///         or a remote location of office management
    /// </summary>
    public class Branch
    {
        public int Id { get; set; }
        // Branch name is the location name... e.g. Baneshowr, Kalanki, RadheRadhe, Tangal, etc.
        public string Name { get; set; }

        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
