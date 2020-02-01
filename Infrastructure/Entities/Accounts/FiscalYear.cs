﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Accounts
{
    public class FiscalYear
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


    }
}
