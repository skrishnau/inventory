using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Settings;

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

        /// <summary>
        /// Settings related to Bills
        /// </summary>
        BillSettingsModel GetBillSettings();

        CompanyInfoSettingModel GetCompanyInfoSetting();

        void AddOrUpdateAppSetting();

        bool SaveBillSetting(BillSettingsModel model);

        bool SaveCompanyInfoSetting(CompanyInfoSettingModel model);

        
    }
}
