using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Purchases.PurchaseOrders
{
    public class PurchaseOrderService : IPurchaseOrderService
    {

        private DatabaseContext _context;

        public PurchaseOrderService(DatabaseContext context)
        {
            _context = context;
        }

        public int GetNextLotNumber()
        {
            int lotNo = _context.PurchaseOrder.Any() ? _context.PurchaseOrder.Max(x => x.LotNo) : 1;
            return lotNo++;
        }
    }
}
