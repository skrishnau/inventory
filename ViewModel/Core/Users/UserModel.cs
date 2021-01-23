using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities.Users;

namespace ViewModel.Core.Users
{

    public class UserListModel
    {
        public List<UserModel> DataList { get; set; }

        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int Offset { get; set; }
    }

    public class UserModel
    {
        public int Id { get; set; }

        // user specific
        public string Username { get; set; }
        // hashed password
        public string Password { get; set; }

        public bool IsCompany { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool Use { get; set; }

        // supplier specific informations
        public string SalesPerson { get; set; }
        // customer specific
        public string DeliveryAddress { get; set; }


        // UserType is one of (Supplier, Customer or User(own)); will be used in future versions when we implement Web
        // This concept is needed if we allow Suppliers and Customers access into our system, for
        //       sale orders and purchase orders (orders require their's involvement)
        public string UserType { get; set; }
        // to indicate if the user can login i.e. if has access to the system (based on permissions)
        public bool CanLogin { get; set; }
        // role; user has only one role
        //public int RoleId { get; set; }
        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get { return TotalAmount - PaidAmount; } }

        // 
        // extra
        //
        public string Fax { get; set; }
        // email address of the user to which the system sends mails to mail subscribers
        public string Email { get; set; }
        public string Website { get; set; }
        public string Company { get; set; }
        // Gender will be empty in case of companies
        public string Gender { get; set; }
        // null if user doesn't want to provide or if its company
        public string IsMarried { get; set; }
        // Registration Date in case of company; or birth date in case of person
        public DateTime? DOB { get; set; }
        public string Notes { get; set; }

        public DateTime? PaymentDueDate { get; set; }
        public DateTime? AllDuesClearDate { get; set; }

        // ============= Table objects ===============//
        //public virtual Role Role { get; set; }




        public User ToEntity()
        {
            return new User
            {
                
                Address = Address,
                CreatedAt = CreatedAt,
                DOB = DOB,
                Email = Email,
                IsCompany = IsCompany,
                IsMarried = IsMarried,
                Id = Id,
                Gender = Gender,
                Name = Name,
                Phone = Phone,
                UpdatedAt = UpdatedAt,
                Website = Website,

                CanLogin = CanLogin,
                Password = Password,
                Username = Username,
                UserType = UserType,
            };
        }
    }
}
