using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities.Customers;

namespace ViewModel.Core.Customers
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? DOB { get; set; }
        public string Address { get; set; }   
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string IsMarried { get; set; }
        public int BasicInfoId { get; set; }

        // customer specific information 
        public string DeliveryAddress { get; set; }

        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Customer ToEntity()
        {
            return new Customer
            {
                Id = Id,
                DeliveryAddress = DeliveryAddress,
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
                }
            };
        }

    }
}
