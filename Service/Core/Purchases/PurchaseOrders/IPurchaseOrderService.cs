﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Purchases.PurchaseOrders
{
    public interface IPurchaseOrderService
    {
        int GetNextLotNumber();
        
    }
}
