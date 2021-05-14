using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Enums
{
    public enum OrderTypeEnum
    {
        Purchase =1,
        Sale=2,
        Move=3,
        All=4,
    }

    public enum OrderListTypeEnum
    {
        Transaction,
        Order
    }

    public enum OrderOrDirectEnum
    {
        /// <summary>
        /// For Purchase Order , Sale Order
        /// </summary>
        Order,
        /// <summary>
        /// For Direct Receive, Direct Issue
        /// </summary>
        Direct
    }

}
