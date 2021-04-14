using Infrastructure.Entities.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Inventory
{
    public class Movement
    {
        public int Id { get; set; }

        public string Description { get; set; }
        
        public string Reference { get; set; }
        public string AdjustmentCode { get; set; }

        public decimal Quantity { get; set; }

        public DateTime Date { get; set; }

        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }


    }
}
