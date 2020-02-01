using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Accounts
{
    public class Transaction
    {
        public int Id { get; set; }

        // e.g. Receipt , Journal , Payment, Purchase , Sales, etc.
        public string Caption { get; set; }

        public DateTime Date { get; set; }

        public bool IsVoid { get; set; }

        public string Detail { get; set; }
    }
}
