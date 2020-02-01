using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Business
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Telephone { get; set; }
        public string MobileNumber { get; set; }

        public string CurrencySymbol { get; set; }

        public DateTime FinancialYearFrom { get; set; }
        public DateTime BooksBeginingFrom { get; set; }


        //public string Password { get; set; }
        //
        // maintain 1. Accounts Only 2. Accounts With Inventory


        // base currency symbol
        // currency name
        // No. of decimal place
        // is symbol suffixed to amounts
        // symbol for decimal portion
        // show amounts in millions
        // put a space between amount and symbol
        // decimal places for printing amount in words

    }
}
