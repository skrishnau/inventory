using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities.Sales;

namespace ViewModel.Core.Sales
{
    public class SaleModel
    {
        public int Id { get; set; }
        public string BillNo { get; set; }
        public string VatNo { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string Date { get; set; }

        // List of each items
        public List<SaleItemModel> SaleItems { get; set; }

        public decimal TotalAmount { get; set; }

        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Sale ToEntity()
        {
            var se = new Sale
            {
                Address = Address,
                CreatedAt = CreatedAt,
                CustomerName = CustomerName,
                Date = Date,
                DeletedAt = DeletedAt,
                Id = Id,
                InvoiceNo = BillNo,
                MobileNo = MobileNo,
                VatNo = VatNo,
                Total = TotalAmount,
                SaleItems = new List<SaleItem>()
            };
            foreach(var item in SaleItems)
            {
                se.SaleItems.Add(item.ToEntity());
            }
            return se;
        }
    }
}
