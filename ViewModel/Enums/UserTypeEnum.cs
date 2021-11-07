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

    public class UserTypeEnumHelper
    {
        public static List<UserTypeEnum> Vendor = new List<UserTypeEnum>
        {
            UserTypeEnum.Vendor
        };
        public static List<UserTypeEnum> CustomerSupplier = new List<UserTypeEnum>
        {
            UserTypeEnum.Customer,
            UserTypeEnum.Supplier,
        };
    }
}
