﻿using System;
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
        public int Id { get; set; }
        // username
        public string Username { get; set; }
        // hashed password
        public string Password { get; set; }

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
        public bool? IsMarried { get; set; }

        // UserType is one of (Supplier, Customer or User(own)); will be used in future versions when we implement Web
        // This concept is needed if we allow Suppliers and Customers access into our system,
        // for sale orders and purchase orders (orders require their's involvement)
        public string UserType { get; set; }
        // to indicate if the user can login i.e. if has access to the system (based on permissions)
        public bool CanLogin { get; set; }
        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}
