using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using DTO.Core.Inventory;
using Infrastructure.Context;
using Service.DbEventArgs;
using Service.Listeners;
using ViewModel.Core;
using ViewModel.Core.Common;
using ViewModel.Core.Settings;
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

        public ResponseModel<bool> AddOrUpdateUser(UserModel supplierModel)
        {
            using (var _context = DatabaseContext.Context)
            {

                var now = DateTime.Now;
                var dbEntity = _context.Users
                    .FirstOrDefault(x => x.Id == supplierModel.Id);
                BaseEventArgs<UserModel> eventArgs = BaseEventArgs<UserModel>.Instance;
                if (_context.Users.Any(x => x.Username == supplierModel.Username && x.Id != supplierModel.Id))
                    return ResponseModel<bool>.GetError("Username already exists. Couldn't save.");
                if (supplierModel.Id == 0 && !string.IsNullOrEmpty(supplierModel.Password))
                    supplierModel.Password = GeneratePasswordHash(supplierModel.Password);
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
                return ResponseModel<bool>.GetSaveSuccess(true);
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

        public int GetAllUsersCount(List<UserTypeEnum> userType, string searchName = "")
        {
            using (var _context = DatabaseContext.Context)
            {
                var query = GetUserQueryable(_context, userType, searchName);
                return query.Count();
            }
        }

        public UserListModel GetAllUsers(List<UserTypeEnum> userType, int pageSize, int offset, string searchName = "")
        {
            using (var _context = DatabaseContext.Context)
            {
                var query = GetUserQueryable(_context, userType, searchName);
                var totalCount = query.Count();
                if (pageSize > 0 && offset >= 0)
                {
                    query = query.Skip(offset).Take(pageSize);
                }
                var list = query.MapToUserModel(_context);// UserMapper.MapToUserModel(query);
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
        public List<IdNamePair> GetUserListForCombo(List<UserTypeEnum> userTypes, int[] includeUserList)
        {
            if (includeUserList == null)
                includeUserList = new int[0];
            using (var _context = DatabaseContext.Context)
            {
                var query = GetUserQueryable(_context, userTypes, string.Empty);

                return query
                    .Where(x => ( x.Use || (!x.Use && includeUserList.Contains(x.Id))))
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
                                               where u.Username != Constants.ADMIN_USERNAME && md.ManufactureId == manufactureId && md.DepartmentId == departmentId
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
                    foreach (var depUser in departmentUsers)
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


        public List<IdNamePair> GetUserListWithCompanyForCombo(List<UserTypeEnum> userType, int[] includeUserList)
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

        private IQueryable<User> GetUserQueryable(DatabaseContext _context, List<UserTypeEnum> userTypes, string searchName)
        {
            var split = string.IsNullOrEmpty(searchName) ? new string[0] : searchName.Split(new char[] { '-' });
            var name = split.Length > 0 ? split[0].Trim() : "";
            var company = split.Length > 1 ? split[1].Trim() : "";

            var query = _context.Users.Where(x => x.Username != Constants.ADMIN_USERNAME && x.DeletedAt == null);
            var customer = UserTypeEnum.Customer.ToString();
            var supplier = UserTypeEnum.Supplier.ToString();
            var vendor = UserTypeEnum.Vendor.ToString();
            var employee = UserTypeEnum.Employee.ToString();
            var allTypes = string.Join(",", userTypes.Select(x => x.ToString()));
            query = query.Where(x =>
                (allTypes.Contains(customer) && x.UserType.Contains(customer))
                || (allTypes.Contains(supplier) && x.UserType.Contains(supplier))
                || (allTypes.Contains(vendor) && x.UserType.Contains(vendor))
                || (allTypes.Contains(employee) && x.UserType.Contains(employee))
            );
            //if (userTypes.Contains(UserTypeEnum.All)) // client means both Customer and Supplier
            //{
            //    query = query.Where(x => x.UserType == customer || x.UserType == supplier);
            //}
            //else
            //{
            //if (userTypes.Count > 0)
            //{
            //    foreach (var userTypeStr in userTypes.Select(u => u.ToString()))
            //    {
            //        query = query.Where(x => x.UserType.Contains(userTypeStr));
            //    }
            //}
            //}
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
                    var adminUser = _context.Users.FirstOrDefault(x => x.Username == username);
                    if (adminUser == null)
                    {
                        adminUser = new User
                        {
                            Username = username,
                            Password = GeneratePasswordHash(password),//StringCipher.Encrypt(password),
                            CanLogin = true,
                            CreatedAt = DateTime.Now,
                            IsCompany = false,
                            UpdatedAt = DateTime.Now,
                            Use = true,
                            Name = Constants.ADMIN_NAME,
                            UserType = UserTypeEnum.Employee.ToString(),
                        };
                        _context.Users.Add(adminUser);
                        _context.SaveChanges();
                    }
                    else if (string.IsNullOrEmpty(adminUser.Password))
                    {
                        adminUser.Password = GeneratePasswordHash(password);
                        _context.SaveChanges();
                    }
                }
                //var passwordEncrypt = StringCipher.Encrypt(password);
                var user = _context.Users.FirstOrDefault(x =>
                    x.Username == username
                    && x.CanLogin
                    && x.DeletedAt == null
                    && x.Use == true);
                if (user != null  && VerifyPassword(user.Password, password))//password == StringCipher.Decrypt(user?.Password))
                {
                    return UserMapper.MapToUserModel(user);
                }
                return null;
            }
        }
        private string GeneratePasswordHash(string password)
        {
            //STEP 1 Create the salt value with a cryptographic PRNG:
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            //STEP 2 Create the Rfc2898DeriveBytes and get the hash value:
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            //STEP 3 Combine the salt and password bytes for later use:
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            //STEP 4 Turn the combined salt+hash into a string for storage
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;

        }
        private bool VerifyPassword(string savedPasswordHash, string password)
        {
            //* Fetch the stored value */
            //string savedPasswordHash = DBContext.GetUser(u => u.UserName == user).Password;
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    return false; //throw new UnauthorizedAccessException();
            return true;
        }

        public bool IsAnyUser()
        {
            using (var _context = DatabaseContext.Context)
            {
                return _context.Users.Any(x =>  x.Password != null && x.Password != "" && 
                ((x.Username == Constants.ADMIN_USERNAME)
                    || 
                    (x.CanLogin
                        && x.DeletedAt == null
                        && x.Use == true))
                );
            }

        }

        public bool SavePassword(PasswordModel model)
        {
            using (var _context = DatabaseContext.Context)
            {
                var user = _context.Users.FirstOrDefault(x => x.Username == model.Username);
                if (user != null)
                {
                    user.Password = GeneratePasswordHash(model.Password);//StringCipher.Encrypt(model.Password);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }

        }

        public bool SaveLedgerPrintDate(int userId)
        {
            using (var _context = DatabaseContext.Context)
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == userId);
                if (user != null)
                {
                    user.LastLedgerPrintDate = DateTime.Now;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }

}

