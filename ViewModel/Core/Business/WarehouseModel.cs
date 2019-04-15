using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities.Business;

namespace ViewModel.Core.Business
{
    public class WarehouseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Hold { get; set; }
        public bool MixedProduct { get; set; }
        public bool Staging { get; set; }

        public bool Use { get; set; }


        //public Warehouse ToEntity()
        //{
        //    return new Warehouse
        //    {
        //        Id = Id,
        //        Hold = Hold,
        //        MixedProduct = MixedProduct,
        //        Name = Name,
        //        Staging = Staging,
        //    };

        //}
    }
}
