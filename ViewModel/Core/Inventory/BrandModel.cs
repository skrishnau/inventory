﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities.Inventory;

namespace ViewModel.Core.Inventory
{
    //[Obsolete("Extra table for Brand is not to be done now", true)]
    public class BrandModel
    {
        public int Id { get; set; }
        // brand name
        public string Name { get; set; }
        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public bool Use { get; set; }
    }


}
