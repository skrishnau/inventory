using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Common;
using ViewModel.Core.Users;
using ViewModel.Enums;

namespace Service.Core.Users
{
    public interface IUserService
    {
        void AddOrUpdateUser(UserModel userModel);

        List<UserModel> GetUserList(UserTypeEnum userType);

        void DeleteUser(UserModel user);

        void AddOrUpdateSupplier(UserModel supplierModel);

        UserModel GetSupplier(int supplierId);


        List<IdNamePair> GetSupplierListForCombo();
    }
}
