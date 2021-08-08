﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Enums
{
    public enum UserTypeEnum
    {
        Customer = 1,
        Supplier = 2,
        User = 3,
        //Client = 4, // Customer and Suppliers are Clients but User isn't
        All = 5,

    }

    public enum ClientTypeEnum
    {
        All,
        Customer,
        Supplier,
    }
}
