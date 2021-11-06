﻿using DTO.Core;
using Infrastructure.Context;
using Service.Core.Settings;
using Service.Interfaces;
using Service.Listeners;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        #region Manufacture



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

                entity = model.MapToEntity(entity);
                if (!isEdit)
                {
                    entity.CreatedAt = DateTime.Now;
                    //entity.CreatedByUserId = GetAdminId(_context);
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


        public IQueryable<Manufacture> GetAllManufacutureQuery(DatabaseContext _context)
        {
            return _context.Manufactures.Where(x => x.DeletedAt == null).OrderBy(x => x.CreatedAt);
        }
        public int GetAllManufacturesCount(int categoryId, string searchText)
        {
            using (var _context = DatabaseContext.Context)
            {
                var query = GetAllManufacutureQuery(_context);
                return query.Count();
            }
        }
        public async Task<ViewListModel<ManufactureModel>> GetAllManufactures(int categoryId, string searchText, int pageSize, int offset)
        {
            using (var _context = DatabaseContext.Context)
            {
                var query = GetAllManufacutureQuery(_context);
                var totalCount = query.Count();
                if (pageSize > 0 && offset >= 0)
                {
                    query = query.Skip(offset).Take(pageSize);
                }
                var list = await query.ToListAsync();
                return new ViewModel.Core.ViewListModel<ManufactureModel>
                {
                    DataList = list.MapToModel(),
                    Offset = offset,
                    PageSize = pageSize,
                    TotalCount = totalCount,
                };
            }
        }

        public ResponseModel<bool> DeleteManufacture(int id)
        {
            using (var _context = DatabaseContext.Context)
            {
                var manufacture = _context.Manufactures.Find(id);
                if (manufacture == null)
                    return new ResponseModel<bool> { Message = "Manufacture not found", Success = false };
                if (manufacture.StartedAt != null)
                    return new ResponseModel<bool> { Message = "Manufacture already started. You can't delete but you may cancel it.", Success = false };
                _context.Manufactures.Remove(manufacture);
                _context.SaveChanges();
                return new ResponseModel<bool> { Message = "Delete Sucess!", Success = true };
            }
        }
        #endregion

        #region Department

        public List<DepartmentModel> GetDepartmentList()
        {
            using (var _context = DatabaseContext.Context)
            {
                return _context.Departments.Where(x => x.DeletedAt == null)
                    .Select(s => new DepartmentModel
                    {
                        IsVendor = s.IsVendor,
                        Name = s.Name,
                        Id = s.Id,
                        HeadUserId = s.HeadUserId,
                    }).ToList();
            }
        }

        public DepartmentModel GetDepartment(int departmentId)
        {
            using (var _context = DatabaseContext.Context)
            {
                var department = _context.Departments.Find(departmentId);
                if (department == null) return null;
                var model = department.MapToModel();
                model.DepartmentUsers = department.DepartmentUsers.ToList()
                    .Select(x => new ViewModel.Core.Users.UserModel
                    {
                        Id = x.UserId ?? 0,
                        Name = _context.Users.Where(y => y.Id == x.UserId).Select(y => y.Name).FirstOrDefault()
                    }).ToList();
                return model;
            }
        }

        public ResponseModel<DepartmentModel> SaveDepartment(DepartmentModel model)
        {
            var isEdit = model.Id > 0;
            using (var _context = DatabaseContext.Context)
            {
                Department entity = null;
                if (isEdit)
                {
                    entity = _context.Departments.Find(model.Id);
                }
                entity = model.MapToEntity(entity);
                if (_context.Departments.Any(x => x.Id != model.Id && x.Name == model.Name))
                    return new ResponseModel<DepartmentModel> { Message = "Another department with same name already exists. Please enter unique name", Success = false};
                if (!isEdit)
                {
                    _context.Departments.Add(entity);
                }
                _context.SaveChanges();
                model.Id = entity.Id;
                return new ResponseModel<DepartmentModel>
                {
                    Message = Constants.SAVED_SUCCESSFULLY,
                    Success = true,
                    Data = model
                };
            }
        }

        #endregion
    }
}
