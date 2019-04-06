using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities.Suppliers;

namespace ViewModel.Core.Suppliers
{
    public class SupplierModel
    {
        public int Id { get; set; }
        // supplier specific informations
        public string SalesPerson { get; set; }
        public string MyCustomerAccount { get; set; }

        // basic Info
        public int BasicInfoId { get; set; }
        public bool IsCompany { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public DateTime? RegisteredAt { get; set; }
        public string Notes { get; set; }
        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

       

    }
}
