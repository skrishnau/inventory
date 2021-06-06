using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Inventory
{
    public class InventoryUnitListModel
    {
        public List<InventoryUnitModel> DataList { get; set; }

        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int Offset { get; set; }
    }

    public class InventoryUnitModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public string Product { get; set; }
        public string SKU { get; set; }
        public int? WarehouseId { get; set; }
        public string Warehouse { get; set; }

        public int LotNumber { get; set; }
        public string ReceiveReceipt { get; set; } // RecieveReciept 
        public string ReceiveAdjustmentCode { get; set; } // adjustment code
        public string ReceiveDate { get; set; } // ReceiveDate 
        public DateTime? ReceiveDateDate { get; set; } // ReceiveDate 
        public string ReceiveDateBS { get; set; } // ReceiveDate 
        public string IssueReceipt { get; set; }
        public string IssueAdjustment { get; set; }// adjustment code
        public string IssueDate { get; set; }

        public decimal UnitQuantity { get; set; }
        public decimal PackageQuantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Total { get; set; }
        public decimal NetWeight { get; set; }
        public decimal GrossWeight { get; set; }
        
        //public int? UomId { get; set; }
        //public string Uom { get; set; }
        public int? PackageId { get; set; }
        public string Package { get; set; }
        public int? SupplierId { get; set; }
        public string Supplier { get; set; }

        public string ProductionDate { get; set; }
        public string ExpirationDate { get; set; }

        public decimal InStockQuantity { get; set; }
        public string InStockQuantityWithPackage { get; set; }
        public decimal OnHoldQuantity { get; set; }
        public decimal OnOrderQuantity { get; set; }
        public decimal OnComittedQuantity { get; set; }

        // include Shipped-To status also
        public bool IsHold { get; set; }
        public string Remark { get; set; }
        public string Notes { get; set; }

        /// <summary>
        /// Update Action: "UpdateMode" enum; one of : EDIT, ADD, DELETE
        /// </summary>
        public string UpdateAction{ get; set; } 

        public int? PurchaseOrderItemId { get; set; }
        
        public ProductModel ProductModel { get; set; }
    }
}
