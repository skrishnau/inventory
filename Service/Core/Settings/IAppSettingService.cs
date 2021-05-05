using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Settings;
using ViewModel.Enums;

namespace Service.Core.Settings
{
    public interface IAppSettingService
    {
        /// <summary>
        /// Retrive
        /// </summary>
        /// <param name="name"></param>
        AppSettingModel GetAppSetting(string name);
        /// <summary>
        /// Add or Update
        /// </summary>
        /// <param name="model"></param>
        bool SaveAppSetting(AppSettingModel model);
        void AddOrUpdateAppSetting();
        
        CompanyInfoSettingModel GetCompanyInfoSetting();
        bool SaveCompanyInfoSetting(CompanyInfoSettingModel model);


        BillSettingsModel GetBillSettings(ReferencesTypeEnum orderType);
        bool SaveBillSetting(List<BillSettingsModel> modelList);
        string GetReceiptNumber(ReferencesTypeEnum orderType);
        string GetReceiptNumber(BillSettingsModel setting, long currentIndex);
        bool IsLicenseExpired();
        DateTime?[] GetLicenseStartDate();
        void SaveLicenseStartDate(DateTime date);
        bool SaveCurrentIndex(long index, ReferencesTypeEnum orderType);
        bool IncrementBillIndex(ReferencesTypeEnum orderType);
        bool IncrementBillIndexWithoutCommit(DatabaseContext _context, ReferencesTypeEnum orderType);

        PasswordModel GetPassword();
        bool SavePassword(PasswordModel password);
    }
}
