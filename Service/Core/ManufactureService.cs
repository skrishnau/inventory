using DTO.Core;
using DTO.Core.Inventory;
using Infrastructure.Context;
using Service.Core.Inventory.Units;
using Service.Core.Settings;
using Service.DbEventArgs;
using Service.Interfaces;
using Service.Listeners;
using Service.Listeners.Inventory;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core;
using ViewModel.Core.Common;
using ViewModel.Core.Inventory;
using ViewModel.Enums;
using ViewModel.Utility;

namespace Service.Core
{
    public class ManufactureService : IManufactureService
    {
        private readonly IDatabaseChangeListener _listener;
        private readonly IAppSettingService _appSettingService;
        private readonly IUomService _uomService;
        private readonly IInventoryUnitService _inventoryUnitService;
        private readonly IProductOwnerService _productOwnerService;

        public ManufactureService(IDatabaseChangeListener listener, IAppSettingService appSettingService, IUomService uomService, IInventoryUnitService inventoryUnitService, IProductOwnerService productOwnerService)
        {
            _listener = listener;
            _appSettingService = appSettingService;
            _uomService = uomService;
            _inventoryUnitService = inventoryUnitService;
            _productOwnerService = productOwnerService;
        }


        #region Manufacture


        public ManufactureModel GetManufacture(int id)
        {
            using (var _context = DatabaseContext.Context)
            {
                var entity = _context.Manufactures.FirstOrDefault(x => x.Id == id);
                if (entity == null) return null;
                var model = entity.MapToModel();
                model.ManufactureDepartments = new List<ManufactureDepartmentModel>();
                //model.ManufactureDepartments = entity.ManufactureDepartments.MapToModel();
                foreach (var dep in entity.ManufactureDepartments.OrderBy(x => x.Position).ToList())
                {
                    var depModel = dep.MapToModel();
                    depModel.ManufactureDepartmentUsers = new List<ManufactureDepartmentUserModel>();
                    foreach (var user in dep.ManufactureDepartmentUsers)
                    {
                        var userModel = user.MapToModel();
                        userModel.Name = _context.Users.Find(user.UserId)?.Name;
                        depModel.ManufactureDepartmentUsers.Add(userModel);
                    }
                    model.ManufactureDepartments.Add(depModel);
                    depModel.ManufactureDepartmentProducts = new List<ManufactureDepartmentProductModel>();
                    foreach (var prod in dep.ManufactureDepartmentProducts)
                    {
                        var prodModel = prod.MapToModel();
                        depModel.ManufactureDepartmentProducts.Add(prodModel);
                    }
                }
                model.ManufactureProducts = entity.ManufactureProducts.MapToModel();
                return model;
            }
        }

        public ManufactureModel GetManufactureOnly(int id)
        {
            using (var _context = DatabaseContext.Context)
            {
                var entity = _context.Manufactures.FirstOrDefault(x => x.Id == id);
                if (entity == null) return null;
                var model = entity.MapToModel();
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

                        if (depEntity.ManufactureDepartmentProducts.Any())
                            _context.ManufactureDepartmentProducts.RemoveRange(depEntity.ManufactureDepartmentProducts);
                        foreach (var depProd in dep.ManufactureDepartmentProducts)
                        {
                            var depProdEntity = new ManufactureDepartmentProduct
                            {
                                BuildRate = null,
                                InOut = depProd.InOut,
                                PackageId = depProd.PackageId,
                                ProductId = depProd.ProductId,
                                Quantity = depProd.Quantity,
                            };
                            depEntity.ManufactureDepartmentProducts.Add(depProdEntity);
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
            return _context.Manufactures.Where(x => x.DeletedAt == null).OrderByDescending(x => x.LotNo);
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


        public ResponseModel<bool> SetManufactureComplete(int id)
        {
            using (var _context = DatabaseContext.Context)
            {
                var entity = _context.Manufactures.Find(id);
                if (entity != null)
                {
                    entity.CompletedAt = DateTime.Now;
                    _context.SaveChanges();
                    _listener.TriggerManufactureUpdateEvent(null, new DbEventArgs.BaseEventArgs<ManufactureModel>(entity.MapToModel(), Utility.UpdateMode.EDIT));
                    return new ResponseModel<bool> { Message = "Manufacture Plan completed successfully!", Success = true };
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


        #endregion

        #region Department

        // give userId if user's department list is required
        public List<IdNamePair> GetDepartmentListForCombo(int? manufactureId = null, int? userId = null)
        {
            using (var _context = DatabaseContext.Context)
            {
                if (manufactureId > 0)
                {
                    var query = _context.ManufactureDepartments.Where(x => x.ManufactureId == manufactureId && x.Department.DeletedAt == null);
                    if (userId > 0)
                        query = query.Where(w => w.ManufactureDepartmentUsers.Any(x => x.UserId == userId));
                    return query
                        .Select(s => new IdNamePair
                        {
                            Id = s.DepartmentId,
                            Name = s.Department.Name + (s.IsVendor ? " (External)" : " (Internal)"),
                            ExtraValue = s.IsVendor.ToString(),
                        }).Distinct().ToList();
                }
                if (userId > 0)
                {
                    return _context.DepartmentUsers.Where(x => x.Department.DeletedAt == null && x.DeletedAt == null && x.UserId == userId)
                         .Select(s => new IdNamePair
                         {
                             Id = s.DepartmentId,
                             Name = s.Department.Name + (s.Department.IsVendor ? " (External)" : " (Internal)"),
                         }).Distinct().ToList();
                }
                return _context.Departments.Where(x => x.DeletedAt == null)
                    .Select(s => new IdNamePair
                    {
                        Id = s.Id,
                        Name = s.Name + (s.IsVendor ? " (External)" : " (Internal)"),
                        ExtraValue = s.IsVendor.ToString(),
                    }).ToList();
            }
        }

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
                    .Select(x => new DepartmentUserModel
                    {
                        UserId = x.UserId,
                        User = _context.Users.Where(y => y.Id == x.UserId).Select(y => y.Name).FirstOrDefault(),
                        BuildRate = x.BuildRate,
                        DepartmentId = x.DepartmentId,
                        DeletedAt = x.DeletedAt
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
                //if (model.DepartmentUsers != null && model.DepartmentUsers.Any())
                //{

                //}
                if (!isEdit)
                {
                    // add
                    foreach (var us in model.DepartmentUsers)
                    {
                        // add
                        var du = new DepartmentUser
                        {
                            UserId = us.UserId ?? 0,
                        };
                        entity.DepartmentUsers.Add(du);
                    }
                    _context.Departments.Add(entity);
                }
                else
                {
                    // edit
                    var allUserIds = model.DepartmentUsers?.Select(x => x.UserId).ToList();
                    foreach (var us in entity.DepartmentUsers)
                    {
                        if (!(model.DepartmentUsers?.Any(x => x.UserId == us.UserId) ?? false))
                        {
                            // delete
                            us.DeletedAt = DateTime.Now;
                        }
                    }

                    foreach (var us in model.DepartmentUsers)
                    {
                        var du = entity.DepartmentUsers.FirstOrDefault(x => x.UserId == us.UserId);
                        if (du == null)
                        {
                            // add
                            du = new DepartmentUser
                            {
                                UserId = us.UserId ?? 0,
                            };
                            entity.DepartmentUsers.Add(du);
                        }
                        else
                        {
                            du.BuildRate = us.BuildRate;
                        }
                    }
                }
                _context.SaveChanges();
                model.Id = entity.Id;
                _listener.TriggerDepartmentUpdateEvent(null, new BaseEventArgs<DepartmentModel>(model));
                return new ResponseModel<DepartmentModel>
                {
                    Message = Constants.SAVED_SUCCESSFULLY,
                    Success = true,
                    Data = model
                };
            }
        }


        private IQueryable<Department> GetDepartmentListQuery(DatabaseContext _context, string searchText)
        {
            var departments = _context.Departments
                                //.Include(x => x.ProductAttributes)
                                .Where(x => x.DeletedAt == null)
                               ;
            if (!string.IsNullOrEmpty(searchText))
                departments = departments.Where(x => x.Name.Contains(searchText));
            return departments.OrderBy(o => o.Name);
        }

        public int GetAllDepartmentsCount(string searchText)
        {
            using (var _context = DatabaseContext.Context)
            {
                var query = GetDepartmentListQuery(_context, searchText);
                return query.Count();
            }
        }

        public async Task<ViewListModel<DepartmentModel>> GetAllDepartments(string searchText, int pageSize, int offset)
        {
            using (var _context = DatabaseContext.Context)
            {
                var departments = GetDepartmentListQuery(_context, searchText);
                var totalCount = departments.Count();
                if (pageSize > 0 && offset >= 0)
                {
                    departments = departments.Skip(offset).Take(pageSize);
                }
                var list = await departments.ToListAsync();

                return new ViewListModel<DepartmentModel>
                {
                    DataList = list.MapToModel(),
                    Offset = offset,
                    PageSize = pageSize,
                    TotalCount = totalCount,
                };
            }
        }
        public ResponseModel<bool> DeleteDepartment(int departmentId)
        {
            using (var _context = DatabaseContext.Context)
            {
                var entity = _context.Departments.Find(departmentId);
                if (entity == null)
                    return new ResponseModel<bool>(false, "Department not found");
                _context.Departments.Remove(entity);
                _context.SaveChanges();
                return new ResponseModel<bool>(true, Constants.DELETED_SUCCESSFULLY);
            }
        }
        public List<DepartmentUserModel> GetEmployeesOfDepartment(int departmentId)
        {
            using (var _context = DatabaseContext.Context)
            {
                return _context.DepartmentUsers.Where(x => x.DeletedAt == null && x.DepartmentId == departmentId)
                    .Select(x => new DepartmentUserModel
                    {
                        UserId = x.UserId,
                        //Department = x.Department.Name,
                        User = x.User.Name,
                        BuildRate = x.BuildRate,
                    }).ToList();
            }
        }

        public List<ManufactureDepartmentUserModel> GetEmployeesOfManufactureDepartment(int manufactureId, int departmentId)
        {
            using (var _context = DatabaseContext.Context)
            {
                return (from mdu in _context.ManufactureDepartmentUsers
                        join md in _context.ManufactureDepartments on mdu.ManufactureDepartmentId equals md.Id
                        join u in _context.Users on mdu.UserId equals u.Id
                        where md.ManufactureId == manufactureId && md.DepartmentId == departmentId
                        select new ManufactureDepartmentUserModel
                        {
                            Check = true,
                            UserId = mdu.UserId,
                            Name = u.Name + (string.IsNullOrEmpty(u.Company) ? "" : " - " + u.Company),
                            BuildRate = mdu.BuildRate,
                            ManufactureDepartmentId = mdu.ManufactureDepartmentId,

                        }).ToList();
                //return _context.ManufactureDepartmentUsers
                //    .Where(x => x.ManufactureDepartment.ManufactureId == manufactureId && x.ManufactureDepartment.DepartmentId == departmentId)
                //    .Select(s => new ManufactureDepartmentUserModel
                //    {
                //        BuildRate = s.BuildRate,
                //        Check = true,
                //        ManufactureDepartmentId = s.ManufactureDepartmentId,
                //        Name = s.User.Name,
                //        UserId = s.UserId,

                //    }).ToList();

            }
        }

        public List<UserManufactureModel> GetEmployeesHistoryOfManufactureDepartment(int manufactureId, int departmentId, int userId)
        {
            using (var _context = DatabaseContext.Context)
            {
                var manu = _context.UserManufactures
                    .Where(x => x.ManufactureDepartmentUser.ManufactureDepartment.ManufactureId == manufactureId
                                && x.ManufactureDepartmentUser.ManufactureDepartment.DepartmentId == departmentId
                                && x.InOut == false /*only out*/)
                    .Select(s => new UserManufactureModel
                    {
                        InOut = s.InOut,
                        PackageId = s.ManufactureDepartmentUser.ManufactureDepartment.Manufacture.ManufactureProducts.FirstOrDefault().PackageId,
                        PackageName = s.ManufactureDepartmentUser.ManufactureDepartment.Manufacture.ManufactureProducts.FirstOrDefault().Package.Name,
                        ProductId = s.ProductId,
                        ProductName = s.Product.Name,
                        Quantity = s.Quantity,
                        UserId = s.ManufactureDepartmentUser.UserId,
                        Date = s.Date
                    }).ToList();
                manu.ForEach(x => x.DateString = DateConverter.Instance.ToBS(x.Date).ToString());
                return manu;
            }
        }

        public ManufactureDepartmentUserModel GetManufactureDepartmentUser(int manufactureId, int departmentId, int userId)
        {
            using (var _context = DatabaseContext.Context)
            {
                var entity = _context.ManufactureDepartmentUsers
                    .FirstOrDefault(x => x.ManufactureDepartment.ManufactureId == manufactureId && x.ManufactureDepartment.DepartmentId == departmentId && x.UserId == userId);
                return entity.MapToModel();
            }
        }

        public ResponseModel<UserManufactureModel> AddUserManufacture(UserManufactureModel model)
        {
            using (var _context = DatabaseContext.Context)
            {
                var manufactureDepartmentUser = _context.ManufactureDepartmentUsers.FirstOrDefault(x => x.Id == model.ManufactureDepartmentUserId);
                if (manufactureDepartmentUser == null)
                {
                    return new ResponseModel<UserManufactureModel> { Success = false, Message = "User not found!" };
                }
                if (manufactureDepartmentUser.StartedAt == null)
                    manufactureDepartmentUser.StartedAt = DateTime.Now;

                // manufactured product data
                var manufacturedProduct = _context.Products.FirstOrDefault(x => x.Id == model.ProductId);
                var manufacturedBasePackageId = manufacturedProduct.ProductPackages.FirstOrDefault(x => x.IsBasePackage).PackageId;

                // -- USER MANUFACTURE -- //
                var userManufactureEntity = new UserManufacture
                {
                    BuildRate = model.BuildRate,
                    Date = model.Date,
                    // ManufactureDepartmentUserId = model.ManufactureDepartmentUserId,
                    InOut = model.InOut,
                    ProductId = model.ProductId,
                    Quantity = model.Quantity,

                };
                manufactureDepartmentUser.UserManufactures.Add(userManufactureEntity);



                /*
                // NOTE: since we do not add/subtract from InStockQuantity, we need not do any of the below calculation
                //      Also all these produced items and consumed items are within department and these will be regarded as OnHold
                // ---- INVENTORY UNIT -- DIRECT ISSUE FOR CONSUMED AND DIRECT RECEIVE FOR MANUFACTURED ---- //
                var adjustment = MovementTypeEnum.Manufacture.ToString();
                var message = string.Empty;
                var orderItem = new OrderItem
                {
                    User = _context.Users.Find(manufactureDepartmentUser.UserId)
                };

                var referenceForInventory = "MANU-" + manufactureDepartmentUser.ManufactureDepartment.Manufacture.LotNo;
                _inventoryUnitService.SaveDirectReceiveItemWithoutCommit(_context, model.MapToInventoryUnitModel(), DateTime.Now, adjustment, ref message, null, referenceForInventory, orderItem);
                var consumedInventoryUnits = _inventoryUnitService.SaveDirectIssueAnyListWithoutCommit(_context, model.ConsumedProducts, "Manufacture Consume", referenceForInventory, ref message);
                if (!string.IsNullOrEmpty(message))
                {
                    return new ResponseModel<UserManufactureModel> { Success = false, Message = message };
                }
                
                // INCREASE IN STOCK QUANTITY
                var convertedQuantityManufactured = _uomService.ConvertUom(model.PackageId, manufacturedBasePackageId, model.ProductId, model.Quantity);
                if (convertedQuantityManufactured == 0)
                    return new ResponseModel<UserManufactureModel> { Success = false, Message = "Couldn't convert the manufactured Unit to Base Unit of the product!" };
                manufacturedProduct.InStockQuantity += convertedQuantityManufactured;
                 */




                // -- USER CONSUMED PRODUCTS -- //
                foreach (var consumedProduct in model.ConsumedProducts)
                {
                    var userManufactureConsumeEntity = new UserManufacture
                    {
                        //BuildRate = consumedProduct.BuildRate,
                        Date = model.Date,
                        InOut = true,
                        ProductId = consumedProduct.ProductId,
                        Quantity = consumedProduct.UnitQuantity,
                    };
                    manufactureDepartmentUser.UserManufactures.Add(userManufactureConsumeEntity);
                    var basePackage = _context.Products.Find(consumedProduct.ProductId).ProductPackages.FirstOrDefault(x => x.IsBasePackage);
                    // subtract from user product CONSUMED

                    var consumeRemarks = "Consumed during Manufacture";
                    var user = _context.Users.Find(manufactureDepartmentUser.UserId);
                    var productOwner = _productOwnerService.AssignProductOwnerWithoutCommit(_context, 0, string.Empty, manufactureDepartmentUser.UserId, user.Name, consumedProduct.ProductId, consumedProduct.PackageId ?? 0, consumedProduct.UnitQuantity, false, consumeRemarks);
                    /*
                    var productOwner = user.ProductOwners.FirstOrDefault(x => x.ProductId == consumedProduct.ProductId);
                    if (productOwner == null)
                    {
                        productOwner = new ProductOwner
                        {
                            PackageId = basePackage.PackageId,
                            ProductId = consumedProduct.ProductId,
                        };
                        user.ProductOwners.Add(productOwner);
                    }
                    var conversion = _uomService.ConvertUom(consumedProduct.PackageId ?? 0, productOwner.PackageId, consumedProduct.ProductId);
                    productOwner.Quantity -= consumedProduct.UnitQuantity * conversion;
                    productOwner.UpdatedAt = DateTime.Now;

                    // HISOTRY OF user product CONSUMED 
                    var ownerHisotry = new ProductOwnerHistory
                    {
                        UserId = manufactureDepartmentUser.UserId,
                        InOut = false,
                        PackageId = consumedProduct.PackageId ?? 0,
                        ProductId = consumedProduct.ProductId,
                        Quantity = consumedProduct.UnitQuantity,
                        UpdatedAt = DateTime.Now,
                        Remarks = "Consumed during Manufacture",
                    };
                    _context.ProductOwnerHistories.Add(ownerHisotry);
                    */
                }
                // -- END OF USER CONSUMED PRODUCTS -- //



                // -- ASSIGN TO SELF DEPARTMENT -- //
                // assign the maufactured quantity to the SELF department 
                var selfDepartmentName = _context.Departments.Where(x => x.Id == model.DepartmentId).Select(x => x.Name).FirstOrDefault();
                var qty = model.Quantity;
                var selfRemarks = "Assigned directly to Self Department after manufacture by Employee/Vendor";
                var sameDepartmentOwner = _productOwnerService.AssignProductOwnerWithoutCommit(_context, model.DepartmentId, selfDepartmentName, 0, string.Empty, model.ProductId, model.PackageId, qty, true, selfRemarks);

                /*
                var sameDepartmentOwner = manufactureDepartmentUser.ManufactureDepartment.Department.ProductOwners.FirstOrDefault(x => x.ProductId == model.ProductId);
                if (sameDepartmentOwner == null)
                {
                    sameDepartmentOwner = new ProductOwner
                    {
                        DepartmentId = model.DepartmentId,
                        PackageId = manufacturedBasePackageId,
                        ProductId = model.ProductId,
                        UserId = null,
                    };
                    manufactureDepartmentUser.ManufactureDepartment.Department.ProductOwners.Add(sameDepartmentOwner);
                }
                sameDepartmentOwner.Quantity += _uomService.ConvertUom(model.PackageId, manufacturedBasePackageId, model.ProductId, qty);
                sameDepartmentOwner.UpdatedAt = DateTime.Now;
                // DEPARTMENT product history
                var sameDepartmentOwnerHisotry = new ProductOwnerHistory
                {
                    DepartmentId = manufactureDepartmentUser.ManufactureDepartment.DepartmentId,//model.DepartmentId,
                    PackageId = model.PackageId,
                    ProductId = model.ProductId,
                    UserId = null,
                    InOut = true,
                    Quantity = qty,
                    UpdatedAt = DateTime.Now,
                    Remarks = "Assigned directly to Self Department after manufacture by Employee/Vendor",
                };
                _context.ProductOwnerHistories.Add(sameDepartmentOwnerHisotry);
                */

                // --- END OF ASSIGN TO SELF DEPARTMENT -- //


                // -- ASSIGN TO NEXT DEPARTMENT (coming after the current sequence)-- //
                var nextAssignSumQty = model.NextProductOwners?.Sum(x => x.Quantity) ?? 0;
                if (model.NextProductOwners != null && model.NextProductOwners.Count > 0)
                {
                    foreach (var ownerModel in model.NextProductOwners)
                    {
                        if (ownerModel.Quantity > 0)
                        {

                            var productId = model.ProductId;
                            var packageId = model.PackageId;
                            var departmentId = ownerModel.DepartmentId;
                            var quantity = ownerModel.Quantity;
                            var departmentName = _context.Departments.Where(x => x.Id == departmentId).Select(x => x.Name).FirstOrDefault();
                            var remarks = "Direct Transfer to another department after manufacture";
                            var nextDepartmentOwner = _productOwnerService.AssignProductOwnerWithoutCommit(_context, departmentId ?? 0, departmentName, 0, string.Empty, productId, packageId, quantity, true, remarks);

                            /*
                            var nextDepartmentOwner = _context.ProductOwners.FirstOrDefault(x => x.ProductId == model.ProductId && x.DepartmentId == ownerModel.DepartmentId);
                            if (nextDepartmentOwner == null)
                            {
                                nextDepartmentOwner = new ProductOwner
                                {
                                    DepartmentId = ownerModel.DepartmentId,
                                    PackageId = manufacturedBasePackageId,
                                    ProductId = model.ProductId,
                                    UserId = null,
                                };
                                _context.ProductOwners.Add(nextDepartmentOwner);
                            }
                            nextDepartmentOwner.Quantity += _uomService.ConvertUom(model.PackageId, nextDepartmentOwner.PackageId, model.ProductId, ownerModel.Quantity);
                            nextDepartmentOwner.UpdatedAt = DateTime.Now;
                            // add to next department
                            var nextDepartmentOwnerHistory = new ProductOwnerHistory()
                            {
                                DepartmentId = ownerModel.DepartmentId,
                                InOut = true,
                                Quantity = ownerModel.Quantity,
                                UpdatedAt = DateTime.Now,
                                Remarks = "Direct Transfer to another department after manufacture",
                                UserId = null,
                                ProductId = model.ProductId, //ownerModel.ProductId,
                                PackageId = model.PackageId,
                            };
                            _context.ProductOwnerHistories.Add(nextDepartmentOwnerHistory);
                            */


                            // subtract from SELF department
                            sameDepartmentOwner.Quantity -= _uomService.ConvertUom(nextDepartmentOwner.PackageId, sameDepartmentOwner.PackageId, model.ProductId, nextDepartmentOwner.Quantity);
                            var poHistorySubtractSameDep = new ProductOwnerHistory()
                            {
                                DepartmentId = model.DepartmentId,
                                InOut = false,
                                Quantity = ownerModel.Quantity,
                                UpdatedAt = DateTime.Now,
                                Remarks = "Direct Transfer to another department after manufacture",
                                UserId = null,
                                ProductId = model.ProductId,
                                PackageId = model.PackageId,
                            };
                            _context.ProductOwnerHistories.Add(poHistorySubtractSameDep);
                        }
                    }
                }
                _context.SaveChanges();
                var manufacture = _context.ManufactureDepartmentUsers.FirstOrDefault(x => x.Id == model.ManufactureDepartmentUserId)
                    .ManufactureDepartment.Manufacture.MapToModel();
                _listener.TriggerManufactureUpdateEvent(null, new DbEventArgs.BaseEventArgs<ManufactureModel>(manufacture, Utility.UpdateMode.ADD));
                _listener.TriggerProductUpdateEvent(null, new BaseEventArgs<ProductModel>(null));
                return new ResponseModel<UserManufactureModel> { Message = Constants.SAVED_SUCCESSFULLY, Data = model, Success = true };
            }
        }

        public List<ManufactureDepartmentProductModel> GetManufactureDepartmentInProducts(int manufactureId, int departmentId, bool inOut)
        {
            using (var _context = DatabaseContext.Context)
            {
                return _context.ManufactureDepartmentProducts
                    .Where(x => x.InOut == inOut && x.ManufactureDepartment.ManufactureId == manufactureId && x.ManufactureDepartment.DepartmentId == departmentId)
                    .Select(s => new ManufactureDepartmentProductModel
                    {
                        BuildRate = s.BuildRate,
                        DepartmentId = departmentId,
                        PackageId = s.PackageId,
                        PackageName = s.Package.Name,
                        InOut = inOut,
                        ProductId = s.ProductId,
                        ProductName = s.Product.Name,
                        Quantity = s.Quantity,
                        Id = s.Id
                    })
                    .ToList();
            }
        }

        public List<InventoryUnitModel> GetManufactureDepartmentProductsInventoryUnit(int manufactureId, int departmentId)
        {
            using (var _context = DatabaseContext.Context)
            {
                return _context.ManufactureDepartmentProducts
                    .Where(x => x.InOut == true && x.ManufactureDepartment.ManufactureId == manufactureId && x.ManufactureDepartment.DepartmentId == departmentId)
                    .Select(s => new
                    {
                        Product = s.Product,
                        Package = s.Package,
                        ProductId = s.ProductId,
                    })
                    .ToList()
                    .Select(s => new InventoryUnitModel
                    {
                        //BuildRate = s.BuildRate,
                        //DepartmentId = departmentId,
                        PackageId = s.Package.Id,
                        //PackageName = s.Package.Name,
                        //InOut = s.InOut,
                        ProductId = s.ProductId,
                        //ProductName = s.Product.Name,
                        //Quantity = s.Quantity,
                        ProductModel = s.Product.MapToProductModel(),
                        InStockQuantity = s.Product.InStockQuantity,
                        Product = s.Product.Name,
                        Package = s.Package.Name,

                    })
                    .ToList();
            }
        }

        #endregion

        


    }
}
