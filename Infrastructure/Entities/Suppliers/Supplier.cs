using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Suppliers
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneA { get; set; }
        public string PhoneB { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }


        public string ContactPersonName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }


        //business size
        //client type
        //client status {good, bad, black_listed}

    }
}
