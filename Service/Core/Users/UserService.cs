using System;
using System.Collections.Generic;
using System.Linq;
using DTO.Core.Inventory;
using Infrastructure.Context;
using Service.DbEventArgs;
using Service.Listeners;
using ViewModel.Core;
using ViewModel.Core.Common;
using ViewModel.Core.Settings;
using ViewModel.Core.Users;
using ViewModel.Enums;
using ViewModel.Utility;

namespace Service.Core.Users
{
    public class UserService : IUserService
    {
        private readonly IDatabaseChangeListener _listener;

        public UserService(IDatabaseChangeListener listener)
        {
            _listener = listener;
        }

        public void DeleteUser(UserModel user)
        {
            using (var _context = DatabaseContext.Context)
            {

                var dbEntity = _context.Users.FirstOrDefault(x => x.Id == user.Id);
                if (dbEntity != null)
                {
                    dbEntity.DeletedAt = DateTime.Now;
                    dbEntity.CanLogin = false;
                    _context.SaveChanges();
                }
            }
        }

        public void AddOrUpdateUser(UserModel supplierModel)
        {
            using (var _context = DatabaseContext.Context)
            {

                var now = DateTime.Now;
                var dbEntity = _context.Users
                    .FirstOrDefault(x => x.Id == supplierModel.Id);
                BaseEventArgs<UserModel> eventArgs = BaseEventArgs<UserModel>.Instance;
                dbEntity = UserMapper.MapToEntity(supplierModel, dbEntity);
                if (dbEntity.Id == 0)
                {
                    // add
                    dbEntity.CreatedAt = now;
                    dbEntity.UpdatedAt = now;
                    _context.Users.Add(dbEntity);
                    eventArgs.Mode = Utility.UpdateMode.ADD;
                }
                else
                {
                    dbEntity.UpdatedAt = now;
                    // update; not needed to assign cause Mapper has already assigned; just set the mode of eventArgs
                    eventArgs.Mode = Utility.UpdateMode.EDIT;
                }
                _context.SaveChanges();
                eventArgs.Model = UserMapper.MapToUserModel(dbEntity);
                _listener.TriggerUserUpdateEvent(null, eventArgs);
            }
        }

        public UserModel GetUser(int userId)
        {
            using (var _context = DatabaseContext.Context)
            {
                var user = _context.Users.Find(userId);
                if (user == null)
                    return null;
                return UserMapper.MapToUserModel(user);
            }
        }

        public UserModel GetUserWithTotalAndPaidAmounts(int userId)
        {
            using (var _context = DatabaseContext.Context)
            {
                var user = _context.Users.Find(userId);
                if (user == null)
                    return null;
                var transactions = user.Transactions.Where(x => !x.IsVoid).ToList();
                decimal total = 0, paid = 0;
                if (user.UserType == UserTypeEnum.Customer.ToString())
                {
                    total = transactions.Sum(x => x.Debit);
                    paid = transactions.Sum(x => x.Credit);
                }
                else if (user.UserType == UserTypeEnum.Supplier.ToString())
                {
                    total = transactions.Sum(x => x.Debit); // incomming stock amount
                    paid = transactions.Sum(x => x.Credit); // outgoing paid amount
                }
                return UserMapper.MapToUserModel(user, total, paid);
            }
        }

        public int GetAllUsersCount(UserTypeEnum userType, string searchName = "")
        {
            using (var _context = DatabaseContext.Context)
            {
                var query = GetUserQueryable(_context, userType, searchName);
                return query.Count();
            }
        }

        public UserListModel GetAllUsers(UserTypeEnum userType, int pageSize, int offset, string searchName = "")
        {
            using (var _context = DatabaseContext.Context)
            {
                var query = GetUserQueryable(_context, userType, searchName);
                var totalCount = query.Count();
                if (pageSize > 0 && offset >= 0)
                {
                    query = query.Skip(offset).Take(pageSize);
                }
                var list = query.MapToUserModel();// UserMapper.MapToUserModel(query);
                return new UserListModel
                {
                    DataList = list,
                    TotalCount = totalCount,
                    Offset = offset,
                    PageSize = pageSize,
                };
            }
        }

        // includeUserList : includes the given users even if Use property is false
        public List<IdNamePair> GetUserListForCombo(UserTypeEnum userType, int[] includeUserList)
        {
            if (includeUserList == null)
                includeUserList = new int[0];
            using (var _context = DatabaseContext.Context)
            {
                var query = GetUserQueryable(_context, userType, string.Empty);

                return query
                    .Where(x => x.Use || (!x.Use && includeUserList.Contains(x.Id)))
                    .Select(x => new IdNamePair()
                    {
                        Name = x.Name + (string.IsNullOrEmpty(x.Company) ? "" : " - " + x.Company),
                        Id = x.Id
                    }).ToList();
            }
        }

        // includeUserList : includes the given users even if Use property is false
        public List<ManufactureDepartmentUserModel> GetUserListForComboByDepartmentId(int manufactureId, int departmentId, int[] includeUserList)
        {
            if (includeUserList == null)
                includeUserList = new int[0];
            using (var _context = DatabaseContext.Context)
            {
                var departmentUsers = _context.DepartmentUsers
                        .Where(x => x.DepartmentId == departmentId && x.DeletedAt == null)
                        .Select(x => new ManufactureDepartmentUserModel()
                        {
                            Check = true,
                            Name = x.User.Name + (string.IsNullOrEmpty(x.User.Company) ? "" : " - " + x.User.Company),
                            UserId = (int)x.UserId,
                            BuildRate = x.BuildRate,
                        }).ToList();
                if (manufactureId > 0)
                {
                    var manufactureDepUsers = (from mdu in _context.ManufactureDepartmentUsers
                               join md in _context.ManufactureDepartments on mdu.ManufactureDepartmentId equals md.Id
                               join u in _context.Users on mdu.UserId equals u.Id
                               where md.ManufactureId == manufactureId && md.DepartmentId == departmentId
                               select new ManufactureDepartmentUserModel
                               {
                                   Check = true,
                                   UserId = mdu.UserId,
                                   Name = u.Name + (string.IsNullOrEmpty(u.Company) ? "" : " - " + u.Company),
                                   BuildRate = mdu.BuildRate,
                                   ManufactureDepartmentId = mdu.ManufactureDepartmentId,
                                   
                               }).ToList();

                    //var manufactureDepUsers =  _context.ManufactureDepartmentUsers
                    //    .Where(x => x.ManufactureDepartment.ManufactureId == manufactureId && x.ManufactureDepartment.DepartmentId == departmentId)
                    //    .Select(x => new ManufactureDepartmentUserModel
                    //    {
                    //        Check = true,
                    //        UserId = x.UserId,
                    //        Name = x.User.Name + (string.IsNullOrEmpty(x.User.Company) ? "" : " - " + x.User.Company),
                    //        BuildRate = x.BuildRate,
                    //        //ManufactureDepartmentId = x.ManufactureDepartmentId
                    //    })
                    //    .ToList();
                    foreach(var depUser in departmentUsers)
                    {
                        depUser.Check = false; // uncheck the unselected cause we are in edit mode
                        if (!manufactureDepUsers.Any(x => x.UserId == depUser.UserId))
                            manufactureDepUsers.Add(depUser);
                    }
                    return manufactureDepUsers;
                }
                return departmentUsers;
            }
        }


        public List<IdNamePair> GetUserListWithCompanyForCombo(UserTypeEnum userType, int[] includeUserList)
        {
            if (includeUserList == null)
                includeUserList = new int[0];
            using (var _context = DatabaseContext.Context)
            {
                var query = GetUserQueryable(_context, userType, string.Empty);

                return query
                    .Where(x => x.Use || (!x.Use && includeUserList.Contains(x.Id)))
                    .Select(x => new IdNamePair()
                    {
                        Name = x.Name + (string.IsNullOrEmpty(x.Company) ? "" : " - " + x.Company),
                        Id = x.Id
                    }).ToList();
            }
        }

        private IQueryable<User> GetUserQueryable(DatabaseContext _context, UserTypeEnum userType, string searchName)
        {
            var split = string.IsNullOrEmpty(searchName) ? new string[0] : searchName.Split(new char[] { '-' });
            var name = split.Length > 0 ? split[0].Trim() : "";
            var company = split.Length > 1 ? split[1].Trim() : "";

            var query = _context.Users
                    .Where(x => x.DeletedAt == null);
            var customer = UserTypeEnum.Customer.ToString();
            var supplier = UserTypeEnum.Supplier.ToString();
            if (userType == UserTypeEnum.All) // client means both Customer and Supplier
            {
                query = query.Where(x => x.UserType == customer || x.UserType == supplier);
            }
            else //if (userType != UserTypeEnum.All)
            {
                var userTypeStr = userType.ToString();
                query = query.Where(x => x.UserType == userTypeStr);
            }
            if (!string.IsNullOrEmpty(searchName))
                query = query.Where(x => x.Name.Contains(name) || x.Company.Contains(name));
            return query.OrderBy(x => x.Name);
        }

        public UserModel GetTransactionSumOfUser(int userId)
        {
            using (var _context = DatabaseContext.Context)
            {
                var user = _context.Users.Find(userId);
                if (user != null)
                {
                    var query = _context.Transactions.Where(x => !x.IsVoid && x.UserId == userId)
                    .GroupBy(x => x.UserId);
                    if (user.UserType == UserTypeEnum.Customer.ToString())
                    {
                        return query.Select(x => new UserModel
                        {
                            TotalAmount = x.Sum(y => y.Debit),
                            PaidAmount = x.Sum(y => y.Credit)
                        }).FirstOrDefault();
                    }
                    else
                    {
                        return query.Select(x => new UserModel
                        {
                            TotalAmount = x.Sum(y => y.Credit),
                            PaidAmount = x.Sum(y => y.Debit)
                        }).FirstOrDefault();
                    }
                }
                return null;
            }
        }

        public UserModel Authenticate(string username, string password)
        {
            using (var _context = DatabaseContext.Context)
            {
                if (username == Constants.ADMIN_USERNAME)
                {
                    var adminExists = _context.Users.Any(x => x.Username == username);
                    if (!adminExists)
                    {
                        var adminUser = new User
                        {
                            Username = username,
                            Password = StringCipher.Encrypt(password),
                            CanLogin = true,
                            CreatedAt = DateTime.Now,
                            IsCompany = false,
                            UpdatedAt = DateTime.Now,
                            Use = true,
                            Name = Constants.ADMIN_NAME,
                            UserType = UserTypeEnum.User.ToString(),
                        };
                        _context.Users.Add(adminUser);
                        _context.SaveChanges();
                    }
                }
                var passwordEncrypt = StringCipher.Encrypt(password);
                var user = _context.Users.FirstOrDefault(x =>
                    x.Username == username
                    && x.CanLogin
                    && x.DeletedAt == null
                    && x.Use == true
                    );
                if (password == StringCipher.Decrypt(user?.Password))
                {
                    return UserMapper.MapToUserModel(user);
                }
                return null;
            }
        }

        public bool IsAnyUser()
        {
            using (var _context = DatabaseContext.Context)
            {
                return _context.Users.Any(x => (x.Username == Constants.ADMIN_USERNAME)
                    || (x.CanLogin
                        && x.DeletedAt == null
                        && x.Use == true
                    ));
            }

        }

        public bool SavePassword(PasswordModel model)
        {
            using (var _context = DatabaseContext.Context)
            {
                var user = _context.Users.FirstOrDefault(x => x.Username == model.Username);
                if (user != null)
                {
                    user.Password = StringCipher.Encrypt(model.Password);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }

        }
    }

}

