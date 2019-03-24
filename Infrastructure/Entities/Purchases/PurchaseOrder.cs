using Infrastructure.Entities.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Purchases
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        // the corresponding purchase in which all the purchase detail of this purchaseOrder is stored
        public int PurchaseId { get; set; }
        // supplier from which the purchse is to be made
        public int SupplierId { get; set; }
        // lot# ; incrementing...
        public int LotNo { get; set; }

        public int? WarehouseId { get; set; }

        // ===== Dates ====== //
        public DateTime OrderDate { get; set; }
        public DateTime RequestedDate { get; set; }
        // promised date is entered either by supplier or by user upon consulting supplier
        public DateTime? PromisedDate { get; set; }
        // the date in which the purchse order was fulfilled. i.e. the products arrive at our location
        public DateTime? ReceivedDate { get; set; }
        // the date in which this order was closed
        public DateTime? ClosedOn{ get; set; }

        // ========= User information ======== //
        public int? CreatedById { get; set; }
        public int? RequestedById { get; set; }
        public int? ApprovedById { get; set; }


        public string Note { get; set; }
        // ====== Table objects ====== //
        public virtual Purchases.Purchase Purchase { get; set; }
        public virtual Suppliers.Supplier Supplier { get; set; }
        public virtual Users.User CreatedBy { get; set; }
        public virtual Users.User RequestedBy { get; set; }
        public virtual Users.User ApprovedBy { get; set; }

        public virtual Warehouse Warehouse{ get; set; }


    }
}
