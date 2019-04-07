﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Inventory
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Use { get; set; }
    }
}
