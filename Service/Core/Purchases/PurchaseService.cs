using DTO.Core.Inventory;
using DTO.Core.Purchases;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Inventory;
using ViewModel.Core.Purchases;
using System.Data.Entity;

namespace Service.Core.Purchases.PurchaseOrders
{
    public class PurchaseService : IPurchaseService
    {

        private DatabaseContext _context;

        public PurchaseService(DatabaseContext context)
        {
            _context = context;
        }

        public List<PurchaseOrderModelForGridView> GetAllPurchaseOrders()
        {
            var purchases = _context.Purchase
                .Include(x => x.Supplier.BasicInfo)
                .Include(x => x.PurchaseItems)
                .Where(x => x.DeletedAt == null);
           return PurchaseMapper.MapToPurchaseModelForGridView(purchases);
        }

        public int GetNextLotNumber()
        {
            int lotNo = _context.PurchaseOrder.Any() ? _context.PurchaseOrder.Max(x => x.LotNo) : 1;
            return lotNo++;
        }

        public List<PurchaseItemModelForListing> GetPurchaseItems(int purchaseId)
        {
            var query = _context.PurchaseItem
                .Include(x=>x.Variant.Product)
                .Where(x => x.PurchaseId == purchaseId && x.DeletedAt == null);
            return PurchaseItemMapper.MapToPurhaseItemModelForListing(query);
            
        }

        public bool SavePurchaseOrder(PurchaseOrderModel purchaseOrderModel)
        {
            _context.PurchaseOrder.Add(PurchaseOrderMapper.MapToPurchaseOrderEntityForAdd(purchaseOrderModel));
            _context.SaveChanges();
            return true;
        }

    }
}
