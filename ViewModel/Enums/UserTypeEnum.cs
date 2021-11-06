using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Enums
{
    public enum UserTypeEnum
    {
        Customer,
        Supplier,
        User,
        Vendor,
        //Client = 4, // Customer and Suppliers are Clients but User isn't
        All,

    }

    public enum ClientTypeEnum
    {
        All,
        Customer,
        Supplier,
    }
}
