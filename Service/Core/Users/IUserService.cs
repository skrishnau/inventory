using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Common;
using ViewModel.Core.Users;

namespace Service.Core.Users
{
    public interface IUserService
    {
        void AddOrUpdateUser(UserModel userModel);

        List<UserModel> GetUserList();
        
        void DeleteUser(UserModel user);

        void AddOrUpdateSupplier(UserModel supplierModel);

        UserModel GetSupplier(int supplierId);

        List<UserModel> GetSupplierList();

        List<IdNamePair> GetSupplierListForCombo();
    }
}
