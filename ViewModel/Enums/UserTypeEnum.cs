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
        Employee,
        Vendor,
        //Client = 4, // Customer and Suppliers are Clients but User isn't
        //All,

    }

    public enum UserTypeCategoryEnum
    {
        All,
        CustomerAndSupplier,
        UserAndVendor,
    }

    //public enum ClientTypeEnum
    //{
    //    All,
    //    Customer,
    //    Supplier,
    //}

    public static class UserTypeEnumHelper
    {
        public static List<UserTypeEnum> All = Enum.GetValues(typeof(UserTypeEnum)).Cast<UserTypeEnum>().ToList();

        public static List<UserTypeEnum> Vendor = new List<UserTypeEnum>
        {
            UserTypeEnum.Vendor
        };
        public static List<UserTypeEnum> CustomerSupplier = new List<UserTypeEnum>
        {
            UserTypeEnum.Customer,
            UserTypeEnum.Supplier,
        };
        public static List<UserTypeEnum> UserAndVendor = new List<UserTypeEnum>
        {
            UserTypeEnum.Employee,
            UserTypeEnum.Vendor
        };
        public static List<UserTypeEnum> ConvertToUserTypeEnum(this UserTypeCategoryEnum userCategory)
        {
            switch (userCategory)
            {
                case UserTypeCategoryEnum.All:
                    return Enum.GetValues(typeof(UserTypeEnum)).Cast<UserTypeEnum>().ToList();
                case UserTypeCategoryEnum.CustomerAndSupplier:
                    return CustomerSupplier;
                case UserTypeCategoryEnum.UserAndVendor:
                    return UserAndVendor;
            }
            return new List<UserTypeEnum>();
        }
    }
}
