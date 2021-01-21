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


        BillSettingsModel GetBillSettings(OrderTypeEnum orderType);
        bool SaveBillSetting(List<BillSettingsModel> modelList);
        string GetReceiptNumber(OrderTypeEnum orderType);
        string GetReceiptNumber(BillSettingsModel setting, long currentIndex);
        bool SaveCurrentIndex(long index, OrderTypeEnum orderType);
        bool IncrementBillIndex(OrderTypeEnum orderType);

        PasswordModel GetPassword();
        bool SavePassword(PasswordModel password);
    }
}
