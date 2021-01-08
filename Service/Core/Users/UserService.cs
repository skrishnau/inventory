using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Core.Inventory;
using Infrastructure.Context;
using Service.DbEventArgs;
using Service.Listeners;
using ViewModel.Core.Common;
using ViewModel.Core.Users;

namespace Service.Core.Users
{
    public class UserService : IUserService
    {
        // private readonly DatabaseContext _context;
        private readonly IDatabaseChangeListener _listener;

        public UserService(IDatabaseChangeListener listener)//DatabaseContext context
        {
            _listener = listener;
            // _context = context;
        }
        

        public void AddOrUpdateUser(UserModel userModel)
        {
            using (var _context = new DatabaseContext())
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
                    dbEntity.Address = userModel.Address;
                    dbEntity.UpdatedAt = DateTime.Now;
                    dbEntity.DOB = userModel.DOB;
                    dbEntity.Email = userModel.Email;
                    dbEntity.Gender = userModel.Gender;
                    dbEntity.IsCompany = userModel.IsCompany;
                    dbEntity.IsMarried = userModel.IsMarried;
                    dbEntity.Name = userModel.Name;
                    dbEntity.Phone = userModel.Phone;
                    dbEntity.Website = userModel.Website;

                    // dbEntityId = userModelId;
                    dbEntity.CanLogin = userModel.CanLogin;
                    //dbEntity.Id = userModel.Id;
                }
                _context.SaveChanges();
            }
        }

        public void DeleteUser(UserModel user)
        {
            using (var _context = new DatabaseContext())
            {

                var dbEntity = _context.User.FirstOrDefault(x => x.Id == user.Id);
                if (dbEntity != null)
                {
                    //var basicInfoId = dbEntity.Id;
                    dbEntity.DeletedAt = DateTime.Now;
                    //dbEntity.DeletedAt = DateTime.Now;
                    dbEntity.CanLogin = false;
                    //var basicInfoEntity = _context.FirstOrDefault(y => y.Id == basicInfoId);
                    //if(basicInfoEntity != null)
                    //{
                    //    basicInfoEntity.DeletedAt = DateTime.Now;
                    //}
                    _context.SaveChanges();
                }
            }
        }
        

        public List<UserModel> GetUserList()
        {
            using (var _context = new DatabaseContext())
            {

                var user = _context.User
                    .Where(x => x.DeletedAt == null)
                    .Select(x => new UserModel()
                    {
                        CanLogin = x.CanLogin,
                        Password = x.Password,
                        Username = x.Username,
                        UserType = x.UserType,
                        Id = x.Id,
                        Name = x.Name,
                        Email = x.Email,
                        DOB = x.DOB,
                        IsCompany = x.IsCompany,
                        IsMarried = x.IsMarried,
                        Phone = x.Phone,
                        Website = x.Website,
                        Gender = x.Gender,
                        Address = x.Address,


                    })
                    .ToList();
                return user;
            }
        }

        /* public List<BasicInfoModel> GetBasicInfoList()
         {
             return null;
         }
         */

        public void AddOrUpdateSupplier(UserModel supplierModel)
        {
            using (var _context = new DatabaseContext())
            {

                var now = DateTime.Now;
                var dbEntity = _context.User
                    .FirstOrDefault(x => x.Id == supplierModel.Id);
                BaseEventArgs<UserModel> eventArgs = BaseEventArgs<UserModel>.Instance;
                dbEntity = UserMapper.MapToEntity(supplierModel, dbEntity);
                if (dbEntity.Id == 0)
                {
                    // add
                    dbEntity.CreatedAt = now;
                    dbEntity.UpdatedAt = now;
                    _context.User.Add(dbEntity);
                    eventArgs.Mode = Utility.UpdateMode.ADD;
                }
                else
                {
                    dbEntity.UpdatedAt = now;
                    // update; not needed to assign cause Mapper has already assigned; just set the mode of eventArgs
                    eventArgs.Mode = Utility.UpdateMode.EDIT;
                }
                _context.SaveChanges();
                eventArgs.Model = UserMapper.MapToSupplierModel(dbEntity);
                _listener.TriggerUserUpdateEvent(null, eventArgs);
            }
        }

        //public void DeleteSupplier(int supplierId)
        //{
        //    var entity = _context.Supplier.Find(supplierId);
        //    if(entity != null)
        //    {
        //        entity.DeletedAt = DateTime.Now;
        //        _context.SaveChanges();
        //        var args = new BaseEventArgs<SupplierModel>(SupplierMapper.MapToSupplierModel(entity), Utility.UpdateMode.DELETE);
        //        _listener.TriggerSupplierUpdateEvent(null, args);
        //    }
        //}

        public UserModel GetSupplier(int supplierId)
        {
            using (var _context = new DatabaseContext())
            {

                var supplier = _context.User.Find(supplierId);
                if (supplier == null)
                    return null;
                return UserMapper.MapToSupplierModel(supplier);
            }
        }

        public List<UserModel> GetSupplierList()
        {
            using (var _context = new DatabaseContext())
            {

                var query = _context.User
                    .Where(x => x.DeletedAt == null)
                    .OrderBy(x => x.Name);
                return UserMapper.MapToSupplierModel(query);
            }
        }

        public List<IdNamePair> GetSupplierListForCombo()
        {
            using (var _context = new DatabaseContext())
            {

                return _context.User
                    .Where(x => x.Use && x.DeletedAt == null)
                    .OrderBy(x => x.Name)
                    .Select(x => new IdNamePair()
                    {
                        Name = x.Name,
                        Id = x.Id
                    }).ToList();
            }
        }
    }

}

