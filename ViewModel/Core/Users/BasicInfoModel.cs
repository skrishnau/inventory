using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities.Users;

namespace ViewModel.Core.Users
{
    public class BasicInfoModel
    {
        public int Id { get; set; }
        public bool IsCompany { get; set; }

        //basic informations
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? DOB { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public bool? IsMarried { get; set; }

        // time stamps 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }


        public BasicInfo ToEntity()
        {
            return new BasicInfo
            {
                Address = Address,
                CreatedAt = CreatedAt,
                DOB = DOB,
                Email = Email,
                Gender = Gender,
                Id = Id,
                IsCompany = IsCompany,
                IsMarried = IsMarried,
                Name = Name,
                Phone = Phone,
                UpdatedAt = UpdatedAt
            };
        }

    }
}
