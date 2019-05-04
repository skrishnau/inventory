﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Common;
using ViewModel.Core.Customers;

namespace Service.Core.Customers
{
    public interface ICustomerService
    {
        List<IdNamePair> GetCustomerListForCombo();
        void AddOrUpdateCustomer(CustomerModel customerModel);
        List<CustomerModel> GetCustomerList();
    }
}
