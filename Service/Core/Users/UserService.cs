using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Context;
using ViewModel.Core.Users;

namespace Service.Core.Users
{
    public class UserService : IUserService 
    {
        private readonly DatabaseContext _context;
        public UserService(DatabaseContext context)
        {
            _context = context;
        }

        public void AddOrUpdateUser(UserModel userModel)
        {
            var dbEntity = _context.User.FirstOrDefault(x => x.Id == userModel.Id);
            if (dbEntity == null)
            {
                var userEntitiy = userModel.ToEntity();
                userEntitiy.CreatedAt = DateTime.Now;
                userEntitiy.UpdatedAt = DateTime.Now;
                _context.User.Add(userEntitiy);

            }
            else
            {
                dbEntity.UpdatedAt = DateTime.Now;
                dbEntity.Password = userModel.Password;
                dbEntity.Username = userModel.Username;
                dbEntity.UserType = userModel.UserType;
                dbEntity.BasicInfoId = userModel.BasicInfoId;
                dbEntity.CanLogin = userModel.CanLogin;
            }
            _context.SaveChanges();
        }

        public List<UserModel> GetUserList()
        {
            var user = _context.User
                .Where(x => x.DeletedAt == null)
                .Select(x => new UserModel()
                {
                    BasicInfoId = x.BasicInfoId,
                    CanLogin = x.CanLogin,
                    Password = x.Password,
                    Username = x.Username,
                    UserType = x.UserType,
                    Id = x.Id


                })
                .ToList();
            return user;
        }

        /*public List<BasicInfo> GetBasicInfoList()
        {
            return null;
        }
        */

    }

}

