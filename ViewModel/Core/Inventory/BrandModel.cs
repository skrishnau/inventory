﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities.Inventory;

namespace ViewModel.Core.Inventory
{
    [Obsolete("Brand table is not used anymore.", true)]
    public class BrandModel
    {
        public int Id { get; set; }
        // brand name
        public string Name { get; set; }

        public int ProductId { get; set; }

        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
       // public DateTime? DeletedAt { get; set; }

        //public  Brand ToEntity()
        //{
        //    return new Brand
        //    {
        //        ProductId = ProductId,
        //        CreatedAt = CreatedAt,
        //        DeletedAt = DeletedAt,
        //        Id = Id,
        //        Name = Name,
        //        UpdatedAt = UpdatedAt
        //    };
        //}
    }

  
}
