using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Core.POS
{
    public class Store
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }


        public bool Use { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
