using System;
using System.Collections.Generic;
using System.Linq;
using DTO.Core.Settings;
using Infrastructure.Context;
using Infrastructure.Entities.AppSettings;
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
        public AppSettingModel GetAppSetting(string name)
        {
            using (var _context = new DatabaseContext())
            {
                var appsetting = _context.AppSetting.FirstOrDefault(x => x.Name == name);
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

                var dbEntity = _context.AppSetting.FirstOrDefault(x => x.Id == model.Id || x.Name == model.Name);
                if (dbEntity == null)
                {

                    var settingEntity = AppSettingMapper.MapToAppSettingEntity(model);
                    settingEntity.CreatedAt = DateTime.Now;
                    settingEntity.UpdatedAt = DateTime.Now;
                    _context.AppSetting.Add(settingEntity);
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
            var dbEntity = _context.AppSetting.FirstOrDefault(x => x.Name == model.Name);
            if (dbEntity == null)
            {
                dbEntity = model;
                //var settingEntity = AppSettingMapper.MapToAppSettingEntity(model);
                dbEntity.CreatedAt = DateTime.Now;
                dbEntity.UpdatedAt = DateTime.Now;
                _context.AppSetting.Add(model);
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


        // get bill settings
        public BillSettingsModel GetBillSettings(ReferencesTypeEnum orderType)
        {
            using (var _context = new DatabaseContext())
            {
                //return BillSettingsModel.GetNewInstance();
                var model = new BillSettingsModel();

                var prefixKey = orderType.ToString() + "_" + BillSettingsEnum.BILL_PREFIX.ToString();
                var prefixEntity = _context.AppSetting.FirstOrDefault(x => x.Name == prefixKey);
                if (prefixEntity != null)
                {
                    model.Prefix = prefixEntity.Value;
                }
                // suffix
                var suffixKey = orderType.ToString() + "_" + BillSettingsEnum.BILL_SUFFIX.ToString();
                var suffixEntity = _context.AppSetting.FirstOrDefault(x => x.Name == suffixKey);
                if (suffixEntity != null)
                {
                    model.Suffix = suffixEntity.Value;
                }
                // Body
                var bodyKey = orderType.ToString() + "_" + BillSettingsEnum.BILL_BODY.ToString();
                var bodyEntity = _context.AppSetting.FirstOrDefault(x => x.Name == bodyKey);
                if (bodyEntity != null)
                {
                    model.Body = bodyEntity.Value;
                }
                // CurrentIndex
                var currentIndexKey = orderType.ToString() + "_" + BillSettingsEnum.BillCurrentIndex.ToString();
                var currentIndexEntity = _context.AppSetting.FirstOrDefault(x => x.Name == currentIndexKey);
                if (currentIndexEntity != null)
                {
                    long currentIndex;
                    if (long.TryParse(currentIndexEntity.Value, out currentIndex))
                        model.CurrentIndex = currentIndex;
                }
                model.ReceiptNo = GetReceiptNumber(model, model.CurrentIndex + 1);

                return model;

            }
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
                    var prefixEntity = _context.AppSetting.FirstOrDefault(x => x.Name == prefixKey);
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
                        _context.AppSetting.Add(prefix);
                    }
                    else
                    {
                        prefixEntity.UpdatedAt = DateTime.Now;
                        prefixEntity.Value = model.Prefix;
                    }

                    // for suffix
                    var suffixKey = orderType.ToString() + "_" + BillSettingsEnum.BILL_SUFFIX.ToString();
                    var suffixEntity = _context.AppSetting.FirstOrDefault(x => x.Name == suffixKey);
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
                        _context.AppSetting.Add(suffix);
                    }
                    else
                    {
                        suffixEntity.UpdatedAt = DateTime.Now;
                        suffixEntity.Value = model.Suffix;

                    }

                    //for Body
                    var bodyKey = orderType.ToString() + "_" + BillSettingsEnum.BILL_BODY.ToString();
                    var startEntity = _context.AppSetting.FirstOrDefault(x => x.Name == bodyKey);
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
                        _context.AppSetting.Add(start);
                    }
                    else
                    {
                        startEntity.UpdatedAt = DateTime.Now;
                        startEntity.Value = model.Body;
                    }

                    // counter
                    var counterKey = orderType.ToString() + "_" + BillSettingsEnum.BillCurrentIndex.ToString();
                    var counterEntity = _context.AppSetting.FirstOrDefault(x => x.Name == counterKey);
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
                        _context.AppSetting.Add(start);
                    }
                    else
                    {
                        counterEntity.UpdatedAt = DateTime.Now;
                        counterEntity.Value = "0";
                    }

                }
                _context.SaveChanges();
                return true;
            }
        }

        public bool IncrementBillIndex(ReferencesTypeEnum orderType)
        {
            var sett = GetBillSettings(orderType);
            return SaveCurrentIndex(sett.CurrentIndex + 1, orderType);
        }



        public bool SaveCurrentIndex(long currentIndex, ReferencesTypeEnum orderType)
        {
            using (var _context = new DatabaseContext())
            {
                //for CurrentIndex
                var currentIndexKey = orderType.ToString() + "_" + BillSettingsEnum.BillCurrentIndex.ToString();
                var currentIndexEntity = _context.AppSetting.FirstOrDefault(x => x.Name == currentIndexKey);
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
                    _context.AppSetting.Add(currentIndexSetting);
                }
                else
                {
                    currentIndexEntity.UpdatedAt = DateTime.Now;
                    currentIndexEntity.Value = currentIndex.ToString();// model.CurrentIndex.ToString();
                }
                _context.SaveChanges();
                return true;
            }
        }


        //SaveCompanyInfoSetting
        public bool SaveCompanyInfoSetting(CompanyInfoSettingModel model)
        {
            using (var _context = new DatabaseContext())
            {
                //for CompanyName
                var companyNameEntity = _context.AppSetting.FirstOrDefault(x => x.Name == "CompanyName");
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
                    _context.AppSetting.Add(company);
                }
                else
                {
                    companyNameEntity.UpdatedAt = DateTime.Now;
                    companyNameEntity.Value = model.CompanyName;
                }

                //for Address
                var addressEntity = _context.AppSetting.FirstOrDefault(x => x.Name == "Address");
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
                    _context.AppSetting.Add(address);
                }
                else
                {
                    addressEntity.UpdatedAt = DateTime.Now;
                    addressEntity.Value = model.Address;
                }

                //for OwnerName
                var ownerNameEntity = _context.AppSetting.FirstOrDefault(x => x.Name == "OwnerName");
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
                    _context.AppSetting.Add(owner);
                }
                else
                {
                    ownerNameEntity.UpdatedAt = DateTime.Now;
                    ownerNameEntity.Value = model.OwnerName;
                }

                //for VATNo
                var vatEntity = _context.AppSetting.FirstOrDefault(x => x.Name == "VATNo");
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
                    _context.AppSetting.Add(vat);
                }
                else
                {
                    vatEntity.UpdatedAt = DateTime.Now;
                    vatEntity.Value = model.VATNo;
                }

                //for PANNo
                var panEntity = _context.AppSetting.FirstOrDefault(x => x.Name == "PANNo");
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
                    _context.AppSetting.Add(pan);
                }
                else
                {
                    panEntity.UpdatedAt = DateTime.Now;
                    panEntity.Value = model.PANNo;
                }

                //for Phone
                var phoneEntity = _context.AppSetting.FirstOrDefault(x => x.Name == "Phone");
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
                    _context.AppSetting.Add(phone);
                }
                else
                {
                    phoneEntity.UpdatedAt = DateTime.Now;
                    phoneEntity.Value = model.Phone;
                }

                //for Email
                var emailEntity = _context.AppSetting.FirstOrDefault(x => x.Name == "Email");
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
                    _context.AppSetting.Add(email);
                }
                else
                {
                    emailEntity.UpdatedAt = DateTime.Now;
                    emailEntity.Value = model.Email;
                }

                //for Website
                var websiteEntity = _context.AppSetting.FirstOrDefault(x => x.Name == "Website");
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
                    _context.AppSetting.Add(website);
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
                var dbEntity = _context.AppSetting.FirstOrDefault(x => x.Name == "CompanyName");
                if (dbEntity != null)
                    model.CompanyName = dbEntity.Value;

                dbEntity = _context.AppSetting.FirstOrDefault(x => x.Name == "Address");
                if (dbEntity != null)
                    model.Address = dbEntity.Value;

                dbEntity = _context.AppSetting.FirstOrDefault(x => x.Name == "OwnerName");
                if (dbEntity != null)
                    model.OwnerName = dbEntity.Value;

                dbEntity = _context.AppSetting.FirstOrDefault(x => x.Name == "VATNo");
                if (dbEntity != null)
                    model.VATNo = dbEntity.Value;

                dbEntity = _context.AppSetting.FirstOrDefault(x => x.Name == "PANNo");
                if (dbEntity != null)
                    model.PANNo = dbEntity.Value;

                dbEntity = _context.AppSetting.FirstOrDefault(x => x.Name == "Phone");
                if (dbEntity != null)
                    model.Phone = dbEntity.Value;

                dbEntity = _context.AppSetting.FirstOrDefault(x => x.Name == "Email");
                if (dbEntity != null)
                    model.Email = dbEntity.Value;

                dbEntity = _context.AppSetting.FirstOrDefault(x => x.Name == "Website");
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

        public bool SavePassword(PasswordModel password)
        {
            using (var _context = new DatabaseContext())
            {
                var pass = new AppSetting()
                {
                    Name = "Password",
                    DisplayName = "Password",
                    Group = "Authorization",
                    Value = password.Password,
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

        public PasswordModel GetPassword()
        {
            var password = GetAppSetting("Password")?.Value;
            var username = GetAppSetting("Username")?.Value;
            return new PasswordModel { Password = password, Username = username };
        }

        public void SaveLicenseExpireDate(DateTime date)
        {
            var encrypted = StringCipher.Encrypt(date.ToString("yyyy/MM/dd"), "PASS@WORD1");
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
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("win_security_001783462");
            if (key != null)
            {
                key.SetValue("win_security_001783462_update2", encrypted);
                key.Close();
            }
        }

        public DateTime?[] GetLicenseExpireDate()
        {
            var array = new DateTime?[2] { null, null};
            DateTime expireAtDb;
            bool expireAtDbParsed = false;
            var validity = GetAppSetting("valid_till1");
            if (validity != null && validity.Value != null)
            {
                try
                {
                    var decrypt = StringCipher.Decrypt(validity.Value, "PASS@WORD1");
                    expireAtDbParsed = DateTime.TryParse(decrypt, out expireAtDb);
                    if (expireAtDbParsed)
                        array[0] = expireAtDb;
                }
                catch (Exception) { }
            }

            DateTime expireAtReg;
            bool expireAtRegParsed;
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("win_security_001783462", false);
            string regValue = null;
            if (key != null)
            {
                regValue = key.GetValue("win_security_001783462_update2") as string;
                key.Close();
            }
            if (regValue != null)
            {
                try
                {
                    var decrypt = StringCipher.Decrypt(regValue, "PASS@WORD1");
                    expireAtRegParsed = DateTime.TryParse(decrypt, out expireAtReg);
                    if (expireAtRegParsed)
                        array[1] = expireAtReg;
                }
                catch (Exception) { }
            }
            return array;
        }

        public bool IsLicenseExpired()
        {
            var expired = false;
            var dates = GetLicenseExpireDate(); // 0: Db , 1: Reg
            // if both persistence are null then create new entry
            if (dates[0] == null && dates[1] == null)
            {
                // save the expire date
                SaveLicenseExpireDate(DateTime.Now.AddDays(10).Date);
            }
            var newDates = GetLicenseExpireDate(); // 0: Db , 1: Reg
            if (newDates[0] == null || newDates[1] == null || newDates[0] != newDates[1])
            {
                expired = true;
            }
            else if (newDates[0].Value < DateTime.Now)
            {
                expired = true;
            }
            return expired;
        }
    }
}
