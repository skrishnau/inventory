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
        public int UserId { get; set; }

        // supplier specific informations
        public string Fax { get; set; }
        public string Website { get; set; }
        public string PhoneSecond { get; set; }
        public string ContactPersonName { get; set; }

        // ==== table objects ==== //
        
        public virtual User User { get; set; }


    }

    // TODO: analyze below concepts later::
    //business size
    //client type
    //client status {good, bad, black_listed}
}
