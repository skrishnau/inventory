using Infrastructure.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Suppliers
{
    public class Supplier
    {
        public int Id { get; set; }
        // Basic info of every Customer and Supplier are entered in User table 
        public int BasicInfoId { get; set; }

        // supplier specific informations
        public string SalesPerson { get; set; }
        public string MyCustomerAccount { get; set; }

        public bool Use { get; set; }

        // ==== table objects ==== //
        public virtual BasicInfo BasicInfo { get; set; }

    }

    // TODO: analyze below concepts later::
    //business size
    //client type
    //client status {good, bad, black_listed}
}
