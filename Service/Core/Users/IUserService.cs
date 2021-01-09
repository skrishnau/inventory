﻿using System;
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

        UserModel GetUser(int supplierId);
        void DeleteUser(UserModel user);
        List<UserModel> GetUserList(UserTypeEnum userType);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userType"></param>
        /// <param name="includeUserList">Includes the given users even if Use property is false</param>
        /// <returns></returns>
        List<IdNamePair> GetUserListForCombo(UserTypeEnum userType, int[] includeUserList);
    }
}
