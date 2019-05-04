using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Core.Settings;
using Infrastructure.Context;
using Infrastructure.Entities.AppSettings;
using ViewModel.Core.Settings;
using ViewModel.Enums.Settings;

namespace Service.Core.Settings
{


    public class AppSettingService : IAppSettingService
    {
        // private readonly DatabaseContext _context;

        public AppSettingService()//DatabaseContext context
        {
            // _context = context;
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

                var dbEntity = _context.AppSetting.FirstOrDefault(x => x.Id == model.Id);
                if (dbEntity == null)
                {

                    var settingEntity = AppSettingMapper.MapToAppSettingEntity(model);
                    settingEntity.CreatedAt = DateTime.Now;
                    settingEntity.UpdatedAt = DateTime.Now;
                    // settingEntity.Group = "Themes";
                    _context.AppSetting.Add(settingEntity);
                }
                else
                {
                    dbEntity.Name = model.Name;
                    dbEntity.DisplayName = model.DisplayName;
                    dbEntity.Id = model.Id;
                    //dbEntity.Group = "Themes";
                    dbEntity.UpdatedAt = DateTime.Now;
                }
                _context.SaveChanges();
                return true;
            }
        }


        #endregion


        // get bill settings
        public BillSettingsModel GetBillSettings()
        {
            using (var _context = new DatabaseContext())
            {
                //return BillSettingsModel.GetNewInstance();
                var model = new BillSettingsModel();

                var prefixKey = BillSettingsEnum.BILL_PREFIX.ToString();
                var prefixEntity = _context.AppSetting.FirstOrDefault(x => x.Name == prefixKey);
                if (prefixEntity != null)
                {
                    model.Prefix = prefixEntity.Value;
                }
                // suffix
                var suffixKey = BillSettingsEnum.BILL_SUFFIX.ToString();
                var suffixEntity = _context.AppSetting.FirstOrDefault(x => x.Name == suffixKey);
                if (suffixEntity != null)
                {
                    model.Suffix = suffixEntity.Value;
                }
                // start
                var startKey = BillSettingsEnum.BILL_START_NUMBER.ToString();
                var startEntity = _context.AppSetting.FirstOrDefault(x => x.Name == startKey);
                if (startEntity != null)
                {
                    model.StartNumber = int.Parse(startEntity.Value);
                }
                // end
                var endKey = BillSettingsEnum.BILL_END_NUMBER.ToString();
                var endEntity = _context.AppSetting.FirstOrDefault(x => x.Name == endKey);
                if (endEntity != null)
                {
                    model.EndNumber = int.Parse(endEntity.Value);
                }

                return model;

            }
        }

        // same as saveappsetting() - not implemented
        public void AddOrUpdateAppSetting()
        {
            // throw new NotImplementedException();
        }

        public bool SaveBillSetting(BillSettingsModel model)
        {
            using (var _context = new DatabaseContext())
            {

                // property : StartNum, EndNum, Prefix, Suffix
                var prefixKey = BillSettingsEnum.BILL_PREFIX.ToString();
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
                var suffixKey = BillSettingsEnum.BILL_SUFFIX.ToString();
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

                //for startNum
                var startKey = BillSettingsEnum.BILL_START_NUMBER.ToString();
                var startEntity = _context.AppSetting.FirstOrDefault(x => x.Name == startKey);
                if (startEntity == null)
                {
                    var start = new AppSetting()
                    {
                        Name = startKey,
                        CreatedAt = DateTime.Now,
                        DisplayName = startKey,
                        Group = "Bill",
                        UpdatedAt = DateTime.Now,
                        Value = model.StartNumber.ToString()

                    };
                    _context.AppSetting.Add(start);
                }
                else
                {
                    startEntity.UpdatedAt = DateTime.Now;
                    startEntity.Value = model.StartNumber.ToString();
                }

                //for endNum
                var endKey = BillSettingsEnum.BILL_END_NUMBER.ToString();
                var endEntity = _context.AppSetting.FirstOrDefault(x => x.Name == endKey);
                if (endEntity == null)
                {
                    var end = new AppSetting()
                    {
                        Value = model.EndNumber.ToString(),
                        CreatedAt = DateTime.Now,
                        DisplayName = endKey,
                        Group = "Bill",
                        Name = endKey,
                        UpdatedAt = DateTime.Now
                    };
                    _context.AppSetting.Add(end);
                }
                else
                {
                    endEntity.Value = model.EndNumber.ToString();
                    endEntity.UpdatedAt = DateTime.Now;
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
    }
}
