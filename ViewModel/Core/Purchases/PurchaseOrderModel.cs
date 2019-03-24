using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Purchases
{
    public class PurchaseOrderModel
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public int SupplierId { get; set; }
        public int LotNo { get; set; }
        public int? WarehouseId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime? PromisedDate { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public DateTime? ClosedOn { get; set; }

        // ========= User information ======== //
        public int? CreatedById { get; set; }
        public int? RequestedById { get; set; }
        public int? ApprovedById { get; set; }


        public string Note { get; set; }

        public virtual PurchaseModel Purchase { get; set; }
    }
}
