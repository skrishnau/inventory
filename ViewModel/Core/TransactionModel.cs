using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core
{
    public class TransactionModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int? UserId { get; set; }
        public string User { get; set; }

        public int? OrderId { get; set; }
        public string Order { get; set; }

        public string Particulars { get; set; }

        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Balance { get; set; }
        public int DrCr { get; set; } 

        public string Type { get; set; }
        public bool IsVoid { get; set; }
    }
}
