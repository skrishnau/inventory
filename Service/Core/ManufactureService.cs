using DTO.Core;
using Infrastructure.Context;
using Service.Core.Settings;
using Service.Interfaces;
using Service.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core;
using ViewModel.Enums;
using ViewModel.Utility;

namespace Service.Core
{
    public class ManufactureService : IManufactureService
    {
        private readonly IDatabaseChangeListener _listener;
        private readonly IAppSettingService _appSettingService;

        public ManufactureService(IDatabaseChangeListener listener, IAppSettingService appSettingService)
        {
            _listener = listener;
            _appSettingService = appSettingService;
        }

        public ManufactureModel GetManufacture(int id)
        {
            using (var _context = DatabaseContext.Context)
            {
                var entity = _context.Manufactures.FirstOrDefault(x => x.Id == id);
                if (entity == null) return null;
                return entity.MapToModel();
            }
        }

        public bool SaveManufacture(ManufactureModel model)
        {
            using (var _context = DatabaseContext.Context)
            {
                var entity = _context.Manufactures.Find(model.Id);
                var isEdit = entity != null;

                model.MapToEntity(entity);
                if (!isEdit)
                {
                    entity.CreatedAt = DateTime.Now;
                    entity.CreatedByUserId = GetAdminId(_context);
                    _context.Manufactures.Add(entity);
                }
                _context.SaveChanges();
                model.Id = entity.Id;
                var updateMode = isEdit ? Utility.UpdateMode.EDIT : Utility.UpdateMode.ADD;
                _listener.TriggerManufactureUpdateEvent(null, new DbEventArgs.BaseEventArgs<ManufactureModel>(model, updateMode));
                return true;
            }
        }
        private int GetAdminId(DatabaseContext _context)
        {
            var userTypeEnum = UserTypeEnum.User.ToString();
            return _context.Users.Where(x => x.Username == "admin" && x.UserType == userTypeEnum).Select(x => x.Id).FirstOrDefault();
        }

        public IQueryable<Manufacture> GetAllManufacutureQuery(DatabaseContext _context)
        {
            //_context.Manufactures.Where(x=>x.)
            return null;
        }
        public int GetAllManufacturesCount(int categoryId, string searchText)
        {
            using(var _context = DatabaseContext.Context)
            {
                //var query = 
                return 0;
            }
        }

        public int GetLastLotNo()
        {
            using (var _context = DatabaseContext.Context)
            {
                try
                {
                    var lotNo = _context.Manufactures.Max(x => x.LotNo);
                    if (lotNo == 0)
                    {
                        throw new Exception("No Manufactures yet");
                    }
                    return lotNo;
                }
                catch (Exception)
                {
                    var appSetting = _appSettingService.GetAppSetting(Constants.KEY_MANUFACTURE_LOT_NO_START_FROM);
                    if (appSetting != null)
                    {
                        int.TryParse(appSetting.Value, out int val);
                        return val;
                    }
                    return 0;
                }
            }
        }

        public Task GetAllManufactures(int categoryId, string searchText, int pageSize, int offset)
        {
            using(var _context = DatabaseContext.Context)
            {
                var query = GetAllManufacutureQuery(_context);
                return null;
                //return query.ToList().
            }
        }
    }
}
