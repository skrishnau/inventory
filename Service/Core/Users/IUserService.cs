using System.Collections.Generic;
using ViewModel.Core;
using ViewModel.Core.Common;
using ViewModel.Core.Settings;
using ViewModel.Enums;

namespace Service.Core.Users
{
    public interface IUserService
    {
        ResponseModel<bool> AddOrUpdateUser(UserModel userModel);

        UserModel GetUser(int supplierId);
        UserModel GetUserWithTotalAndPaidAmounts(int userId);
        void DeleteUser(UserModel user);

        int GetAllUsersCount(List<UserTypeEnum> userType, string searchName = "");
        UserListModel GetAllUsers(List<UserTypeEnum> userType, int pageSize, int offset, string searchName = "");
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userType"></param>
        /// <param name="includeUserList">Includes the given users even if Use property is false</param>
        /// <returns></returns>
        List<IdNamePair> GetUserListForCombo(List<UserTypeEnum> userTypes, int[] includeUserList);
        bool IsAnyUser();
        List<IdNamePair> GetUserListWithCompanyForCombo(List<UserTypeEnum> userTypes, int[] includeUserList);

        UserModel GetTransactionSumOfUser(int userId);
        UserModel Authenticate(string username, string password);
        bool SavePassword(PasswordModel model);
        List<ManufactureDepartmentUserModel> GetUserListForComboByDepartmentId(int manufactureId, int departmentId, int[] includeUserList);
        bool SaveLedgerPrintDate(int userId);
    }
}
