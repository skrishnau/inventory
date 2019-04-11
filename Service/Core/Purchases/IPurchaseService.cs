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

        void SavePurchaseOrder(PurchaseOrderModel purchaseOrderModel);

        List<PurchaseOrderModel> GetAllPurchaseOrders();

        List<PurchaseOrderItemModel> GetPurchaseOrderItems(int purchaseId);

        PurchaseOrderModel GetPurchaseOrder(int purchaseOrderId);


        string SavePurchaseOrderItems(int purchaseOrderId, List<PurchaseOrderItemModel> items);

        string SetSent(int purchaseOrderId);
        string SetReceived(int purchaseOrderId);
        string SetCancelled(int purchaseOrderId);
    }
}
