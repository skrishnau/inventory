﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Orders
{
    public class OrderListModel
    {
        public List<OrderModel> OrderList{ get; set; }

        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int Offset { get; set; }
    }
}
