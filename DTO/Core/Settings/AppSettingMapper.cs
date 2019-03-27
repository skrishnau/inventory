using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Settings;
using Infrastructure.Entities.AppSettings;


namespace DTO.Core.Settings
{
    public class AppSettingMapper
    {
        public static AppSetting MapToAppSettingEntity(AppSettingModel model)
        {
            return new AppSetting()
            {
                DisplayName = model.DisplayName,
                Id = model.Id,
                Name = model.Name,
                Value = model.Value
            };

        }

        public static AppSettingModel MapToAppSettingModel(AppSetting setting)
        {
            return new AppSettingModel()
            {
                DisplayName = setting.DisplayName,
                Id = setting.Id,
                Name = setting.Name,
                Value = setting.Value
            };
        }
    }
}
