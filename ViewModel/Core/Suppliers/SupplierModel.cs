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
        public bool IsCompany { get; set; }

        // ====== Basic Informations ====== //
        public string Name { get; set; }
        // email address of the user to which the system sends mails to mail subscribers
        public string Email { get; set; }
        // Registration Date in case of company; or birth date in case of person
        public DateTime? DOB { get; set; }
        // Address of User; in case of company its Business Location
        public string Address { get; set; }
        // primary phone number
        public string Phone { get; set; }
        // Gender will be empty in case of companies
        public string Gender { get; set; }
        // null if user doesn't want to provide or if its company
        public string IsMarried { get; set; }
        // Basic info of every Customer and Supplier are entered in User table 
        public int BasicInfoId { get; set; }

        // supplier specific informations
        public string Fax { get; set; }
        public string Website { get; set; }
        public string PhoneSecond { get; set; }
        public string ContactPersonName { get; set; }

        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Supplier ToEntity()
        {
            return new Supplier
            {
                //CreatedAt = CreatedAt, 
                Fax = "",
                Id = Id,
                BasicInfo =
                    new Infrastructure.Entities.Users.BasicInfo()
                    {
                        Phone = Phone,
                        Address = Address,
                        Email = Email,
                        IsCompany = true,
                        Name = Name,
                        CreatedAt = CreatedAt,
                        UpdatedAt = UpdatedAt
                        
                        

                    },
                PhoneSecond = ""


            };
        }

    }
}
