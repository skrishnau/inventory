using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DTO.Core.Settings;
using Infrastructure.Context;
using Service.DbEventArgs;
using Service.Listeners;
using ViewModel.Core.Settings;
using ViewModel.Enums;
using ViewModel.Utility;

namespace Service.Core.Settings
{
    public class AppSettingService : IAppSettingService
    {
        // private readonly DatabaseContext _context;
        private readonly IDatabaseChangeListener _listener;

        public AppSettingService(IDatabaseChangeListener listener)//DatabaseContext context
        {
            // _context = context;
            _listener = listener;
        }
        #region AppSettings Core

        //get app settings
        public async Task<AppSettingModel> GetAppSetting(string name)
        {
            using (var _context = new DatabaseContext())
            {
                var appsetting = await _context.AppSettings.FirstOrDefaultAsync(x => x.Name == name);
                if (appsetting != null)
                {
                    return AppSettingMapper.MapToAppSettingModel(appsetting);
                }
                return null;
            }

        }


        //save app settings
        public bool SaveAppSetting(AppSettingModel model)
        {
            using (var _context = new DatabaseContext())
            {

                var dbEntity = _context.AppSettings.FirstOrDefault(x => x.Id == model.Id || x.Name == model.Name);
                if (dbEntity == null)
                {

                    var settingEntity = AppSettingMapper.MapToAppSettingEntity(model);
                    settingEntity.CreatedAt = DateTime.Now;
                    settingEntity.UpdatedAt = DateTime.Now;
                    _context.AppSettings.Add(settingEntity);
                }
                else
                {
                    //dbEntity.Name = model.Name;
                    dbEntity.DisplayName = model.DisplayName;
                    //dbEntity.Id = model.Id;
                    //dbEntity.Group = "Themes";
                    dbEntity.Value = model.Value;
                    dbEntity.UpdatedAt = DateTime.Now;
                }
                _context.SaveChanges();
                return true;
            }
        }

        public AppSetting SaveAppSettingWithoutCommit(DatabaseContext _context, AppSetting model)
        {
            var dbEntity = _context.AppSettings.FirstOrDefault(x => x.Name == model.Name);
            if (dbEntity == null)
            {
                dbEntity = model;
                //var settingEntity = AppSettingMapper.MapToAppSettingEntity(model);
                dbEntity.CreatedAt = DateTime.Now;
                dbEntity.UpdatedAt = DateTime.Now;
                _context.AppSettings.Add(model);
            }
            else
            {
                // dbEntity.DisplayName = model.DisplayName;
                dbEntity.Value = model.Value;
                dbEntity.UpdatedAt = DateTime.Now;
            }
            return dbEntity;
        }


        #endregion
        public BillSettingsModel GetBillSettings(ReferencesTypeEnum orderType)
        {
            using (var _context = new DatabaseContext())
            {
                return GetBillSettings(_context, orderType);
            }
        }
        // get bill settings
        public BillSettingsModel GetBillSettings(DatabaseContext _context, ReferencesTypeEnum orderType)
        {

            //return BillSettingsModel.GetNewInstance();
            var model = new BillSettingsModel();

            var prefixKey = orderType.ToString() + "_" + BillSettingsEnum.BILL_PREFIX.ToString();
            var prefixEntity = _context.AppSettings.FirstOrDefault(x => x.Name == prefixKey);
            if (prefixEntity != null)
            {
                model.Prefix = prefixEntity.Value;
            }
            // suffix
            var suffixKey = orderType.ToString() + "_" + BillSettingsEnum.BILL_SUFFIX.ToString();
            var suffixEntity = _context.AppSettings.FirstOrDefault(x => x.Name == suffixKey);
            if (suffixEntity != null)
            {
                model.Suffix = suffixEntity.Value;
            }
            // Body
            var bodyKey = orderType.ToString() + "_" + BillSettingsEnum.BILL_BODY.ToString();
            var bodyEntity = _context.AppSettings.FirstOrDefault(x => x.Name == bodyKey);
            if (bodyEntity != null)
            {
                model.Body = bodyEntity.Value;
            }
            // CurrentIndex
            var currentIndexKey = orderType.ToString() + "_" + BillSettingsEnum.BillCurrentIndex.ToString();
            var currentIndexEntity = _context.AppSettings.FirstOrDefault(x => x.Name == currentIndexKey);
            if (currentIndexEntity != null)
            {
                long currentIndex;
                if (long.TryParse(currentIndexEntity.Value, out currentIndex))
                    model.CurrentIndex = currentIndex;
            }
            model.ReceiptNo = GetReceiptNumber(model, model.CurrentIndex + 1);

            return model;

        }

        // same as saveappsetting() - not implemented
        public void AddOrUpdateAppSetting()
        {
            // throw new NotImplementedException();
        }

        public bool SaveBillSetting(List<BillSettingsModel> modelList)
        {
            using (var _context = new DatabaseContext())
            {
                foreach (var model in modelList)
                {
                    var orderType = model.Type;

                    // property : StartNum, EndNum, Prefix, Suffix
                    var prefixKey = orderType.ToString() + "_" + BillSettingsEnum.BILL_PREFIX.ToString();
                    var prefixEntity = _context.AppSettings.FirstOrDefault(x => x.Name == prefixKey);
                    if (prefixEntity == null)
                    {
                        var prefix = new AppSetting()
                        {
                            Name = prefixKey,
                            CreatedAt = DateTime.Now,
                            DisplayName = prefixKey,
                            Group = "Bill",
                            UpdatedAt = DateTime.Now,
                            Value = model.Prefix
                        };
                        _context.AppSettings.Add(prefix);
                    }
                    else
                    {
                        prefixEntity.UpdatedAt = DateTime.Now;
                        prefixEntity.Value = model.Prefix;
                    }

                    // for suffix
                    var suffixKey = orderType.ToString() + "_" + BillSettingsEnum.BILL_SUFFIX.ToString();
                    var suffixEntity = _context.AppSettings.FirstOrDefault(x => x.Name == suffixKey);
                    if (suffixEntity == null)
                    {
                        var suffix = new AppSetting()
                        {
                            Name = suffixKey,
                            CreatedAt = DateTime.Now,
                            DisplayName = suffixKey,
                            Group = "Bill",
                            UpdatedAt = DateTime.Now,
                            Value = model.Suffix,
                        };
                        _context.AppSettings.Add(suffix);
                    }
                    else
                    {
                        suffixEntity.UpdatedAt = DateTime.Now;
                        suffixEntity.Value = model.Suffix;

                    }

                    //for Body
                    var bodyKey = orderType.ToString() + "_" + BillSettingsEnum.BILL_BODY.ToString();
                    var startEntity = _context.AppSettings.FirstOrDefault(x => x.Name == bodyKey);
                    if (startEntity == null)
                    {
                        var start = new AppSetting()
                        {
                            Name = bodyKey,
                            CreatedAt = DateTime.Now,
                            DisplayName = bodyKey,
                            Group = "Bill",
                            UpdatedAt = DateTime.Now,
                            Value = model.Body,

                        };
                        _context.AppSettings.Add(start);
                    }
                    else
                    {
                        startEntity.UpdatedAt = DateTime.Now;
                        startEntity.Value = model.Body;
                    }

                    // counter
                    var counterKey = orderType.ToString() + "_" + BillSettingsEnum.BillCurrentIndex.ToString();
                    var counterEntity = _context.AppSettings.FirstOrDefault(x => x.Name == counterKey);
                    if (counterEntity == null)
                    {
                        var start = new AppSetting()
                        {
                            Name = counterKey,
                            CreatedAt = DateTime.Now,
                            DisplayName = counterKey,
                            Group = "Bill",
                            UpdatedAt = DateTime.Now,
                            Value = "0",
                        };
                        _context.AppSettings.Add(start);
                    }
                    else
                    {
                        counterEntity.UpdatedAt = DateTime.Now;
                        counterEntity.Value = "0";
                    }

                }
                _context.SaveChanges();
                var args = BaseEventArgs<List<BillSettingsModel>>.Instance;
                args.Model = modelList;

                _listener.TriggerBillSettingUpdateEvent(null, args);
                return true;
            }
        }

        public bool IncrementBillIndex(ReferencesTypeEnum orderType)
        {
            var sett = GetBillSettings(orderType);
            return SaveCurrentIndex(sett.CurrentIndex + 1, orderType);
        }

        public bool IncrementBillIndexWithoutCommit(DatabaseContext _context, ReferencesTypeEnum orderType)
        {
            var sett = GetBillSettings(_context, orderType);
            return SaveCurrentIndexWithoutCommit(_context, sett.CurrentIndex + 1, orderType);
        }

        public bool SaveCurrentIndex(long currentIndex, ReferencesTypeEnum orderType)
        {
            using (var _context = new DatabaseContext())
            {
                var result = SaveCurrentIndexWithoutCommit(_context, currentIndex, orderType);
                _context.SaveChanges();
                return result;
            }
        }

        public bool SaveCurrentIndexWithoutCommit(DatabaseContext _context, long currentIndex, ReferencesTypeEnum orderType)
        {
            //for CurrentIndex
            var currentIndexKey = orderType.ToString() + "_" + BillSettingsEnum.BillCurrentIndex.ToString();
            var currentIndexEntity = _context.AppSettings.FirstOrDefault(x => x.Name == currentIndexKey);
            if (currentIndexEntity == null)
            {
                var currentIndexSetting = new AppSetting()
                {
                    Name = currentIndexKey,
                    CreatedAt = DateTime.Now,
                    DisplayName = currentIndexKey,
                    Group = "Bill",
                    UpdatedAt = DateTime.Now,
                    Value = currentIndex.ToString(),//model.CurrentIndex.ToString(),

                };
                _context.AppSettings.Add(currentIndexSetting);
            }
            else
            {
                currentIndexEntity.UpdatedAt = DateTime.Now;
                currentIndexEntity.Value = currentIndex.ToString();// model.CurrentIndex.ToString();
            }
            return true;
        }


        //SaveCompanyInfoSetting
        public bool SaveCompanyInfoSetting(CompanyInfoSettingModel model)
        {
            using (var _context = new DatabaseContext())
            {
                //for CompanyName
                var companyNameEntity = _context.AppSettings.FirstOrDefault(x => x.Name == "CompanyName");
                if (companyNameEntity == null)
                {
                    var company = new AppSetting()
                    {
                        Name = "CompanyName",
                        CreatedAt = DateTime.Now,
                        DisplayName = "CompanyName",
                        Group = "Company",
                        UpdatedAt = DateTime.Now,
                        Value = model.CompanyName,
                    };
                    _context.AppSettings.Add(company);
                }
                else
                {
                    companyNameEntity.UpdatedAt = DateTime.Now;
                    companyNameEntity.Value = model.CompanyName;
                }

                //for Address
                var addressEntity = _context.AppSettings.FirstOrDefault(x => x.Name == "Address");
                if (addressEntity == null)
                {
                    var address = new AppSetting()
                    {
                        Name = "Address",
                        CreatedAt = DateTime.Now,
                        DisplayName = "Address",
                        Group = "Company",
                        UpdatedAt = DateTime.Now,
                        Value = model.Address,
                    };
                    _context.AppSettings.Add(address);
                }
                else
                {
                    addressEntity.UpdatedAt = DateTime.Now;
                    addressEntity.Value = model.Address;
                }

                //for OwnerName
                var ownerNameEntity = _context.AppSettings.FirstOrDefault(x => x.Name == "OwnerName");
                if (ownerNameEntity == null)
                {
                    var owner = new AppSetting()
                    {
                        Name = "OwnerName",
                        CreatedAt = DateTime.Now,
                        DisplayName = "OwnerName",
                        Group = "Company",
                        UpdatedAt = DateTime.Now,
                        Value = model.OwnerName,
                    };
                    _context.AppSettings.Add(owner);
                }
                else
                {
                    ownerNameEntity.UpdatedAt = DateTime.Now;
                    ownerNameEntity.Value = model.OwnerName;
                }

                //for VATNo
                var vatEntity = _context.AppSettings.FirstOrDefault(x => x.Name == "VATNo");
                if (vatEntity == null)
                {
                    var vat = new AppSetting()
                    {
                        Name = "VATNo",
                        CreatedAt = DateTime.Now,
                        DisplayName = "VATNo",
                        Group = "Company",
                        UpdatedAt = DateTime.Now,
                        Value = model.VATNo,
                    };
                    _context.AppSettings.Add(vat);
                }
                else
                {
                    vatEntity.UpdatedAt = DateTime.Now;
                    vatEntity.Value = model.VATNo;
                }

                //for PANNo
                var panEntity = _context.AppSettings.FirstOrDefault(x => x.Name == "PANNo");
                if (panEntity == null)
                {
                    var pan = new AppSetting()
                    {
                        Name = "PANNo",
                        CreatedAt = DateTime.Now,
                        DisplayName = "PANNo",
                        Group = "Company",
                        UpdatedAt = DateTime.Now,
                        Value = model.PANNo,
                    };
                    _context.AppSettings.Add(pan);
                }
                else
                {
                    panEntity.UpdatedAt = DateTime.Now;
                    panEntity.Value = model.PANNo;
                }

                //for Phone
                var phoneEntity = _context.AppSettings.FirstOrDefault(x => x.Name == "Phone");
                if (phoneEntity == null)
                {
                    var phone = new AppSetting()
                    {
                        Name = "Phone",
                        CreatedAt = DateTime.Now,
                        DisplayName = "Phone",
                        Group = "Company",
                        UpdatedAt = DateTime.Now,
                        Value = model.Phone,
                    };
                    _context.AppSettings.Add(phone);
                }
                else
                {
                    phoneEntity.UpdatedAt = DateTime.Now;
                    phoneEntity.Value = model.Phone;
                }

                //for Email
                var emailEntity = _context.AppSettings.FirstOrDefault(x => x.Name == "Email");
                if (emailEntity == null)
                {
                    var email = new AppSetting()
                    {
                        Name = "Email",
                        CreatedAt = DateTime.Now,
                        DisplayName = "Email",
                        Group = "Company",
                        UpdatedAt = DateTime.Now,
                        Value = model.Email,
                    };
                    _context.AppSettings.Add(email);
                }
                else
                {
                    emailEntity.UpdatedAt = DateTime.Now;
                    emailEntity.Value = model.Email;
                }

                //for Website
                var websiteEntity = _context.AppSettings.FirstOrDefault(x => x.Name == "Website");
                if (websiteEntity == null)
                {
                    var website = new AppSetting()
                    {
                        Name = "Website",
                        CreatedAt = DateTime.Now,
                        DisplayName = "Website",
                        Group = "Company",
                        UpdatedAt = DateTime.Now,
                        Value = model.Website,
                    };
                    _context.AppSettings.Add(website);
                }
                else
                {
                    websiteEntity.UpdatedAt = DateTime.Now;
                    websiteEntity.Value = model.Website;
                }

                _context.SaveChanges();
                BaseEventArgs<CompanyInfoSettingModel> eventArgs = BaseEventArgs<CompanyInfoSettingModel>.Instance;
                eventArgs.Model = model;
                _listener.TriggerCompanyUpdateEvent(null, eventArgs);

                return true;

            }
        }


        //CompanyInfoSettingModel
        public CompanyInfoSettingModel GetCompanyInfoSetting()
        {
            using (var _context = new DatabaseContext())
            {

                var model = new CompanyInfoSettingModel();
                var dbEntity = _context.AppSettings.FirstOrDefault(x => x.Name == "CompanyName");
                if (dbEntity != null)
                    model.CompanyName = dbEntity.Value;

                dbEntity = _context.AppSettings.FirstOrDefault(x => x.Name == "Address");
                if (dbEntity != null)
                    model.Address = dbEntity.Value;

                dbEntity = _context.AppSettings.FirstOrDefault(x => x.Name == "OwnerName");
                if (dbEntity != null)
                    model.OwnerName = dbEntity.Value;

                dbEntity = _context.AppSettings.FirstOrDefault(x => x.Name == "VATNo");
                if (dbEntity != null)
                    model.VATNo = dbEntity.Value;

                dbEntity = _context.AppSettings.FirstOrDefault(x => x.Name == "PANNo");
                if (dbEntity != null)
                    model.PANNo = dbEntity.Value;

                dbEntity = _context.AppSettings.FirstOrDefault(x => x.Name == "Phone");
                if (dbEntity != null)
                    model.Phone = dbEntity.Value;

                dbEntity = _context.AppSettings.FirstOrDefault(x => x.Name == "Email");
                if (dbEntity != null)
                    model.Email = dbEntity.Value;

                dbEntity = _context.AppSettings.FirstOrDefault(x => x.Name == "Website");
                if (dbEntity != null)
                    model.Website = dbEntity.Value;
                return model;
            }
        }

        public string GetReceiptNumber(BillSettingsModel setting, long currentIndex)
        {
            long number;
            var body = "";
            if (long.TryParse(setting.Body, out number))
            {
                number += currentIndex;
                var leadingZeros = setting.Body.Length - number.ToString().Length;
                for (var i = 0; i < leadingZeros; i++)
                    body += "0";
                body += number;
            }
            return setting.Prefix + body + setting.Suffix;
        }

        public string GetReceiptNumber(ReferencesTypeEnum orderType)
        {
            var billSettings = GetBillSettings(orderType);
            return billSettings.ReceiptNo;
        }
        /*
        public bool SavePassword(PasswordModel password)
        {
            using (var _context = new DatabaseContext())
            {
                var pass = new AppSetting()
                {
                    Name = "Password",
                    DisplayName = "Password",
                    Group = "Authorization",
                    Value = StringCipher.Encrypt(password.Password),
                };
                SaveAppSettingWithoutCommit(_context, pass);
                var username = new AppSetting()
                {
                    Name = "Username",
                    DisplayName = "Username",
                    Group = "Authorization",
                    Value = password.Username,
                };
                SaveAppSettingWithoutCommit(_context, username);
                _context.SaveChanges();
                return true;
            }
        }

        public async  Task<PasswordModel> GetPassword()
        {
            var pass = await GetAppSetting("Password");
            var password = StringCipher.Decrypt(pass?.Value);
            var username = await GetAppSetting("Username");
            return new PasswordModel { Password = password, Username = username?.Value };
        }
        */
        public void SaveLicenseStartDate(DateTime date)
        {
            var encrypted = StringCipher.Encrypt(date.ToString("yyyy/MM/dd"));
            var expireModel = new AppSettingModel()
            {
                DisplayName = "Valid Till",
                Group = "security",
                Name = "valid_till1",
                Value = encrypted,
            };
            SaveAppSetting(expireModel);

            // save in registry
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("win_security_001783463");
            if (key != null)
            {
                key.SetValue("win_security_001783463_update3", encrypted);
                key.Close();
            }
        }

        public async Task<DateTime?[]> GetLicenseStartDate()
        {
            var array = new DateTime?[2] { null, null };
            DateTime expireAtDb;
            bool expireAtDbParsed = false;
            var validity = await GetAppSetting("valid_till1");
            if (validity != null && validity.Value != null)
            {
                try
                {
                    var decrypt = StringCipher.Decrypt(validity.Value);
                    expireAtDbParsed = DateTime.TryParse(decrypt, out expireAtDb);
                    if (expireAtDbParsed)
                        array[0] = expireAtDb;
                }
                catch (Exception) { }
            }

            DateTime expireAtReg;
            bool expireAtRegParsed;
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("win_security_001783463", false);
            string regValue = null;
            if (key != null)
            {
                regValue = key.GetValue("win_security_001783463_update3") as string;
                key.Close();
            }
            if (regValue != null)
            {
                try
                {
                    var decrypt = StringCipher.Decrypt(regValue);
                    expireAtRegParsed = DateTime.TryParse(decrypt, out expireAtReg);
                    if (expireAtRegParsed)
                        array[1] = expireAtReg;
                }
                catch (Exception) { }
            }
            return array;
        }

        public async Task<bool> IsLicenseExpired()
        {
            var expired = false;
            var dates = await GetLicenseStartDate(); // 0: Db , 1: Reg
            // if both persistence are null then create new entry
            if (dates[0] == null || dates[1] == null)
            {
                // save the expire date
                SaveLicenseStartDate(DateTime.Now.Date);
            }
            var newDates = await GetLicenseStartDate(); // 0: Db , 1: Reg
            //if (newDates[0] == null || newDates[1] == null || newDates[0] != newDates[1])
            //{
            //    expired = true;
            //}
            //else 
            if (newDates[0].Value.AddDays(50) < DateTime.Now)
            {
                expired = true;
            }
            return expired;
        }
        public bool SaveBackupFolderPath(string folderPath)
        {
            var appSetting = new AppSettingModel
            {
                DisplayName = "Backup Folder Path",
                Group = Constants.GROUP_BACKUP,
                Name = Constants.KEY_BACKUP_FOLDER_PATH,
                Value = folderPath,
            };
            return SaveAppSetting(appSetting);
        }

        public async Task<bool> GetShowTransactionCreateInFullPage()
        {
            var appSett = await GetAppSetting(Constants.KEY_SHOW_TRANSACTION_CREATE_IN_FULL_PAGE);
            bool.TryParse(appSett?.Value ?? "", out bool value);
            return value;
        }
        public void SaveShowTransactionCreateInFullPage(bool p)
        {
            var appSettingModel = new AppSettingModel
            {
                DisplayName = Constants.KEY_SHOW_TRANSACTION_CREATE_IN_FULL_PAGE,
                Group = Constants.GROUP_SYSTEM,
                Name = Constants.KEY_SHOW_TRANSACTION_CREATE_IN_FULL_PAGE,
                Value = p.ToString()
            };
            SaveAppSetting(appSettingModel);
            if (!p)
                SaveIsTransactionCreatePageLocked(false);
        }

        public async Task<bool> GetIsTransactionCreatePageLocked()
        {
            var appSett = await GetAppSetting(Constants.KEY_IS_TRANSACTION_CRETE_PAGE_LOCKED);
            bool.TryParse(appSett?.Value ?? "", out bool value);
            return value;
        }

        public void SaveIsTransactionCreatePageLocked(bool p)
        {
            var appSettingModel = new AppSettingModel
            {
                DisplayName = Constants.DISPLAY_IS_TRANSACTION_CRETE_PAGE_LOCKED,
                Group = Constants.GROUP_SYSTEM,
                Name = Constants.KEY_IS_TRANSACTION_CRETE_PAGE_LOCKED,
                Value = p.ToString()
            };
            SaveAppSetting(appSettingModel);
        }
    }
}
