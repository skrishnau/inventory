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

        public void AddOrUpdateBasicInfo(BasicInfoModel basicInfoModel)
        {
            var dbEntity = _context.BasicInfo.FirstOrDefault(x => x.Id == basicInfoModel.Id);
            if (dbEntity == null)
            {
                var userEntitiy = basicInfoModel.ToEntity();
                userEntitiy.CreatedAt = DateTime.Now;
                userEntitiy.UpdatedAt = DateTime.Now;
                _context.BasicInfo.Add(userEntitiy);

            }
            else
            {
                dbEntity.UpdatedAt = DateTime.Now;
                dbEntity.Address = basicInfoModel.Address;
                dbEntity.DOB = basicInfoModel.DOB;
                dbEntity.Email = basicInfoModel.Email;
                dbEntity.Gender = basicInfoModel.Gender;
                dbEntity.IsCompany = basicInfoModel.IsCompany;
                dbEntity.IsMarried = basicInfoModel.IsMarried;
                dbEntity.Name = basicInfoModel.Name;
                dbEntity.Phone = basicInfoModel.Phone;
                
            }
            _context.SaveChanges();
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

        public List<BasicInfoModel> GetBasicInfoList()
        {
            var basicInfo = _context.BasicInfo
               .Where(x => x.DeletedAt == null)
               .Select(x => new BasicInfoModel()
               {
                   Id = x.Id,
                   Address = x.Address,
                   Phone = x.Phone,
                   Name = x.Name,
                   IsMarried = x.IsMarried, 
                   DOB = x.DOB,
                   Email = x.Email,
                   Gender = x.Gender,
                   IsCompany = x.IsCompany,
                   


               })
               .ToList();
            return basicInfo;
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

       /* public List<BasicInfoModel> GetBasicInfoList()
        {
            return null;
        }
        */
        

    }

}

