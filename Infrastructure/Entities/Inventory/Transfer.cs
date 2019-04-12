using Infrastructure.Entities.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Inventory
{
    public class Transfer
    {
        public int Id { get; set; }

        public string TransferNumber { get; set; }

        public int FromWarehouseId { get; set; }
        public virtual Warehouse FromWarehouse { get; set; }

        public int ToWarehouseId { get; set; }
        public virtual Warehouse ToWarehouse { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; }


    }
}
