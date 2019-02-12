using Infrastructure.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Customers
{
    public class Customer
    {
        public int Id { get; set; }
        // Basic info of every Customer and Supplier are entered in User table 
        public int BasicInfoId { get; set; }

        
        // Customer Specific Information

        public string DeliveryAddress { get; set; }
        // location will be implemented in future version (pin-point location -- coordinates etc.)
        // for delivery purposes; many locations could be entered and one of them set as current
        //  location... Customer is in one-to-many relation with location


        // ====== Table objects ====== //
        //public virtual User User { get; set; }
        public virtual BasicInfo BasicInfo { get; set; }

    }
}
