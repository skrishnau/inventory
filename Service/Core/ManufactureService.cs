using DTO.Core;
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
                var model = entity.MapToModel();
                model.ManufactureDepartments = entity.ManufactureDepartments.MapToModel();
                model.ManufactureProducts = entity.ManufactureProducts.MapToModel();
                return model;
            }
        }

        public ResponseModel<ManufactureModel> SaveManufacture(ManufactureModel model)
        {
            using (var _context = DatabaseContext.Context)
            {
                try
                {

                    var entity = _context.Manufactures.Find(model.Id);
                    var isEdit = entity != null;

                    entity = model.MapToEntity(entity);
                    if (!isEdit)
                    {
                        // add
                        entity.CreatedAt = DateTime.Now;
                        //entity.CreatedByUserId = GetAdminId(_context);
                        _context.Manufactures.Add(entity);
                    }
                    // remove those that are removed from view
                    var removeList = new List<ManufactureDepartment>();
                    foreach (var dep in entity.ManufactureDepartments)
                    {
                        if (!model.ManufactureDepartments.Any(x => x.DepartmentId == dep.DepartmentId))
                            removeList.Add(dep);
                    }
                    if (removeList.Any(x => x.ManufactureDepartmentUsers.Any(y => y.UserManufactures.Any())))
                        return new ResponseModel<ManufactureModel> { Success = false, Message = "Manufacture already in process. Can't update the departments" };
                    _context.ManufactureDepartmentUsers.RemoveRange(removeList.SelectMany(x => x.ManufactureDepartmentUsers));
                    _context.ManufactureDepartments.RemoveRange(removeList);
                    // add or update the departments
                    foreach (var dep in model.ManufactureDepartments)
                    {
                        var depEntity = entity.ManufactureDepartments.FirstOrDefault(x => x.DepartmentId == dep.DepartmentId);
                        if (depEntity == null)
                        {
                            depEntity = new ManufactureDepartment { DepartmentId = dep.DepartmentId };
                            entity.ManufactureDepartments.Add(depEntity);
                        }
                        depEntity.Position = dep.Position;
                        depEntity.Name = dep.Name ?? string.Empty;
                        depEntity.HeadUserId = dep.HeadUserId;
                        if (depEntity.ManufactureDepartmentUsers.Any())
                            _context.ManufactureDepartmentUsers.RemoveRange(depEntity.ManufactureDepartmentUsers);
                        foreach (var manuDepUser in dep.ManufactureDepartmentUsers)
                        {
                            var manuDepUserEntity = new ManufactureDepartmentUser { BuildRate = manuDepUser.BuildRate, UserId = manuDepUser.UserId };
                            depEntity.ManufactureDepartmentUsers.Add(manuDepUserEntity);
                        }
                    }
                    if (entity.ManufactureProducts.Any())
                        _context.ManufactureProducts.RemoveRange(entity.ManufactureProducts);
                    foreach (var prod in model.ManufactureProducts)
                    {
                        //var manuProd = new ManufactureProduct
                        //{
                        //    BuildRate = prod.BuildRate,
                        //    CostRate = prod.CostRate,
                        //    InOut = prod.InOut,
                        //    PackageId = prod.PackageId,
                        //    ProductId = prod.ProductId,
                        //    ProposedOrProduction = prod.ProposedOrProduction,
                        //    Quantity = prod.Quantity,
                        //};
                        entity.ManufactureProducts.Add(prod.MapToEntity());
                    }

                    _context.SaveChanges();
                    model.Id = entity.Id;
                    var updateMode = isEdit ? Utility.UpdateMode.EDIT : Utility.UpdateMode.ADD;
                    _listener.TriggerManufactureUpdateEvent(null, new DbEventArgs.BaseEventArgs<ManufactureModel>(model, updateMode));

                    return new ResponseModel<ManufactureModel> { Data = model, Success = true, Message = Constants.SAVED_SUCCESSFULLY };

                }
                catch (Exception ex)
                {
                    return new ResponseModel<ManufactureModel> { Success = false, Message = Constants.COULDNT_SAVE_CONTACT_ADMIN };
                }
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

        public List<ManufactureDepartmentModel> GetDepartmentListForManufacture()
        {
            using (var _context = DatabaseContext.Context)
            {
                return _context.Departments.Where(x => x.DeletedAt == null)
                    .Select(s => new ManufactureDepartmentModel
                    {
                        IsVendor = s.IsVendor,
                        Name = s.Name,
                        DepartmentId = s.Id,
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
                        Id = x.UserId,
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
                    return new ResponseModel<DepartmentModel> { Message = "Another department with same name already exists. Please enter unique name", Success = false };
                if (model.DepartmentUsers != null && model.DepartmentUsers.Any())
                {

                }
                if (!isEdit)
                {
                    // add
                    foreach (var us in model.DepartmentUsers)
                    {
                        // add
                        var du = new DepartmentUser
                        {
                            UserId = us.Id,
                        };
                        entity.DepartmentUsers.Add(du);
                    }
                    _context.Departments.Add(entity);
                }
                else
                {
                    // edit
                    var allUserIds = model.DepartmentUsers?.Select(x => x.Id).ToList();
                    foreach (var us in entity.DepartmentUsers)
                    {
                        if (!(model.DepartmentUsers?.Any(x => x.Id == us.UserId) ?? false))
                        {
                            // delete
                            us.DeletedAt = DateTime.Now;
                        }
                    }

                    foreach (var us in model.DepartmentUsers)
                    {
                        if (!entity.DepartmentUsers.Any(x => x.UserId == us.Id))
                        {
                            // add
                            var du = new DepartmentUser
                            {
                                UserId = us.Id,
                            };
                            entity.DepartmentUsers.Add(du);
                        }
                    }
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

        public ResponseModel<bool> SetManufactureComplete(int id)
        {
            using(var _context = DatabaseContext.Context)
            {
                var entity = _context.Manufactures.Find(id);
                if(entity != null)
                {
                    entity.CompletedAt = DateTime.Now;
                    _context.SaveChanges();
                    _listener.TriggerManufactureUpdateEvent(null, new DbEventArgs.BaseEventArgs<ManufactureModel>(entity.MapToModel(), Utility.UpdateMode.EDIT));
                    return new ResponseModel<bool> {  Message = "Manufacture Plan completed successfully!", Success = true };
                }
                return new ResponseModel<bool> { Message = "Couldn't find the Manufacture Plan", Success = false };
            }
        }

        public ResponseModel<bool> SetManufactureCancel(int id)
        {
            using (var _context = DatabaseContext.Context)
            {
                var entity = _context.Manufactures.Find(id);
                if (entity != null)
                {
                    entity.CancelledAt = DateTime.Now;
                    _context.SaveChanges();
                    _listener.TriggerManufactureUpdateEvent(null, new DbEventArgs.BaseEventArgs<ManufactureModel>(entity.MapToModel(), Utility.UpdateMode.EDIT));
                    return new ResponseModel<bool> { Message = "Manufacture Plan cancelled successfully!", Success = true };
                }
                return new ResponseModel<bool> { Message = "Couldn't find the Manufacture Plan", Success = false };
            }
        }

        public ResponseModel<bool> SetManufactureStart(int id)
        {
            using (var _context = DatabaseContext.Context)
            {
                var entity = _context.Manufactures.Find(id);
                if (entity != null)
                {
                    entity.StartedAt = DateTime.Now;
                    _context.SaveChanges();
                    _listener.TriggerManufactureUpdateEvent(null, new DbEventArgs.BaseEventArgs<ManufactureModel>(entity.MapToModel(), Utility.UpdateMode.EDIT));
                    return new ResponseModel<bool> { Message = "Manufacture Plan started successfully!", Success = true };
                }
                return new ResponseModel<bool> { Message = "Couldn't find the Manufacture Plan", Success = false };
            }
        }

        public List<ManufactureDepartmentUserModel> GetEmployeesOfManufactureDepartment(int manufactureId, int depId)
        {
            using (var _context = DatabaseContext.Context)
            {
                return _context.ManufactureDepartmentUsers
                    .Where(x => x.ManufactureDepartment.ManufactureId == manufactureId && x.ManufactureDepartment.DepartmentId == depId)
                    .Select(s => new ManufactureDepartmentUserModel
                    {
                        BuildRate = s.BuildRate,
                        Check = true,
                        ManufactureDepartmentId = s.ManufactureDepartmentId,
                        Name = s.User.Name,
                        UserId = s.UserId
                    }).ToList();

            }
        }

        public List<UserManufactureProductModel> GetEmployeesHistoryOfManufactureDepartment(int manufactureId, int departmentId, int userId)
        {
            using (var _context = DatabaseContext.Context)
            {
                return _context.UserManufactureProducts
                    .Where(x => x.UserManufacture.ManufactureDepartmentUser.ManufactureDepartment.ManufactureId == manufactureId 
                                && x.UserManufacture.ManufactureDepartmentUser.ManufactureDepartment.DepartmentId == departmentId
                                && x.InOut == false /*only out*/)
                    .Select(s => new UserManufactureProductModel
                    {
                        InOut = s.InOut,
                        PackageId = s.PackageId,
                        PackageName = s.Package.Name,
                        ProductId = s.ProductId,
                        ProductName = s.Product.Name,
                        Quantity = s.Quantity,
                        UserId = s.UserManufacture.ManufactureDepartmentUser.UserId,
                        UserManufactureId = s.UserManufactureId
                    }).ToList();

            }
        }

        #endregion
    }
}
