using ViewModel.Core.Settings;
using Infrastructure.Context;

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
                Value = model.Value,
                Group = model.Group
            };

        }

        public static AppSettingModel MapToAppSettingModel(AppSetting setting)
        {
            return new AppSettingModel()
            {
                DisplayName = setting.DisplayName,
                Id = setting.Id,
                Name = setting.Name,
                Value = setting.Value,
                Group = setting.Group
            };
        }
    }
}
