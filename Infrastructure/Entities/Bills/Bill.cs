using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Bills
{
    public class Bill
    {
        public int Id { get; set; }
        public int BillNo { get; set; }
        public DateTime BIllDate { get; set; }
        public decimal BillTotal { get; set; }
    } 
}
