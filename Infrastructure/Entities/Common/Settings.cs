using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Common
{
    /// <summary>
    ///  This won't be implemented directly as 'Settings' table. 
    ///  Will be implemented as Name-Value pair in database.
    ///  Remove this class after you implement key value pair in database.
    /// </summary>
    public class Settings
    {
        public int Id { get; set; }
        // tracks the invoice number; to which value it has reached
        public int CurrentInvoiceNo { get; set; }
        
    }
}
