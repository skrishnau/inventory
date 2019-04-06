using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Users
{
   public  class BasicInfo
    {

        public int Id { get; set; }
        public bool IsCompany { get; set; }

        // ====== Basic Informations ====== //
        public string Name { get; set; }
        
        // Address of User; in case of company its Business Location
        public string Address { get; set; }
        // primary phone number
        public string Phone { get; set; }
        public string Fax { get; set; }
        // email address of the user to which the system sends mails to mail subscribers
        public string Email { get; set; }
        public string Website { get; set; }

        // Gender will be empty in case of companies
        public string Gender { get; set; }
        // null if user doesn't want to provide or if its company
        public string IsMarried { get; set; }
        // Registration Date in case of company; or birth date in case of person
        public DateTime? DOB { get; set; }

        public string Notes { get; set; }

        // time stamps; since Supplier, Customer and Users all have time stamps; 
        //      hence this is in basic info
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Suppliers.Supplier> Suppliers { get; set; }
        public virtual ICollection<Customers.Customer> Customers { get; set; }


    }
}
