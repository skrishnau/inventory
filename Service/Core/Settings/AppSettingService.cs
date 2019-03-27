using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Core.Settings;
using Infrastructure.Context;
using ViewModel.Core.Settings;

namespace Service.Core.Settings
{
    

    public class AppSettingService : IAppSettingService
    {
        private readonly DatabaseContext _context;
        public AppSettingService(DatabaseContext context)
        {
            _context = context;
        }
        #region AppSettings Core

        public AppSettingModel GetAppSetting(string name)
        {
            var appsetting = _context.AppSetting.FirstOrDefault(x => x.Name == name);
            if(appsetting != null)
            {
                return AppSettingMapper.MapToAppSettingModel(appsetting);
            }
            return null;
        }


        public bool SaveAppSetting(AppSettingModel model)
        {

            var dbEntity = _context.AppSetting.FirstOrDefault(x => x.Id == model.Id);
            if(dbEntity == null)
            {
                var settingEntity = AppSettingMapper.MapToAppSettingEntity(model);
                _context.AppSetting.Add(settingEntity);
            }
            else
            {
                dbEntity.Name = model.Name;
                dbEntity.DisplayName = model.DisplayName;
                dbEntity.Id = model.Id;
            }
            _context.SaveChanges();
            return true;
        }


        #endregion


        public BillSettingsModel GetBillSettings()
        {
            return null;
        }

        public void AddOrUpdateAppSetting()
        {
            throw new NotImplementedException();
        }
    }
}
