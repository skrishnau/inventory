using Infrastructure.Entities.Accounts;
using Infrastructure.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Users
{
    /// <summary>
    /// User is the person who has access to the system (based on permissions)
    /// For now Supplier and Customers have NO or Limited access.
    /// </summary>
    public class User
    {
        public User()
        {
            Orders = new List<Order>();
            Transactions = new List<Transaction>();
        }
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

        /// <summary>
        /// The last stored due date for customer/supplier. it's updated everytime credit is taken
        /// </summary>
        public DateTime? PaymentDueDate { get; set; }

        //// payments
        //public decimal TotalAmount { get; set; }
        //public decimal PaidAmount { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
