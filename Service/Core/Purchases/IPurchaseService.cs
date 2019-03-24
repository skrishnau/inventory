using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Inventory;
using ViewModel.Core.Purchases;

namespace Service.Core.Purchases.PurchaseOrders
{
    public interface IPurchaseService
    {
        int GetNextLotNumber();

        bool SavePurchaseOrder(PurchaseOrderModel purchaseOrderModel);

        List<PurchaseOrderModelForGridView> GetAllPurchaseOrders();

        List<PurchaseItemModelForListing> GetPurchaseItems(int purchaseId);

    }
}
