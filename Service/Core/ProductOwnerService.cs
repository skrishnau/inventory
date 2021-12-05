using DTO.Core;
using DTO.Core.Inventory;
using Infrastructure.Context;
using Service.Core.Inventory.Units;
using Service.Interfaces;
using Service.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModel.Core;
using ViewModel.Core.Common;
using ViewModel.Enums;
using ViewModel.Utility;

namespace Service.Core
{
    public class ProductOwnerService : IProductOwnerService
    {
        private readonly IInventoryUnitService _inventoryUnitService;
        private readonly IUomService _uomService;
        private readonly IDatabaseChangeListener _databaseChangeListener;
        public ProductOwnerService(IInventoryUnitService inventoryUnitService, IUomService uomService, IDatabaseChangeListener databaseChangeListener)
        {
            _inventoryUnitService = inventoryUnitService;
            _uomService = uomService;
            _databaseChangeListener = databaseChangeListener;
        }

        public List<IdNamePair> GetCurrentProductsOfOwner(int departmentId, int userId)
        {
            using (var _context = DatabaseContext.Context)
            {
                var query = _context.ProductOwners.Where(x => x.Quantity > 0);
                if (departmentId > 0)
                    query = query.Where(x => x.DepartmentId == departmentId);
                else if (userId > 0)
                    query = query.Where(x => x.UserId == userId);
                return query
                    .OrderBy(x => x.Product.Name)
                    .Select(x => new IdNamePair
                    {
                        Id = x.ProductId,
                        Name = x.Product.Name
                    }).Distinct().ToList();
            }
        }

        public decimal GetOnHoldProductQuantityOfOwner(int departmentId, int userId, int productId, int packageId)
        {
            using (var _context = DatabaseContext.Context)
            {
                ProductOwner product = null;
                if (departmentId > 0)
                    product = _context.ProductOwners.FirstOrDefault(x => x.DepartmentId == departmentId && x.ProductId == productId);
                else if (userId > 0)
                    product = _context.ProductOwners.FirstOrDefault(x => x.UserId == userId && x.ProductId == productId);

                if (product != null)
                {
                    return _uomService.ConvertUom(product.PackageId, packageId, productId, product.Quantity);
                }
                return 0;
            }
        }


        public ResponseModel<bool> SaveAssignRelease(AssignReleaseViewModel assignReleaseModel)
        {
            using (var _context = DatabaseContext.Context)
            {
                var msg = string.Empty;
                if (assignReleaseModel.FromType == FromToType.Warehouse)
                {
                    _inventoryUnitService.SaveDirectIssueAnyListWithoutCommit(_context, assignReleaseModel.inventoryUnitList, "Assign to " + assignReleaseModel.ToType.ToString(), "Department Assign", ref msg, assignReleaseModel);
                    if (assignReleaseModel.ToType == FromToType.Department)
                    {
                        foreach (var item in assignReleaseModel.inventoryUnitList)
                        {
                            AssignProductOwnerWithoutCommit(_context, assignReleaseModel.ToId, assignReleaseModel.ToName, 0, string.Empty, item.ProductId, item.PackageId ?? 0, item.UnitQuantity, true, string.Empty);
                        }
                    }
                }

                else if (assignReleaseModel.FromType == FromToType.Department)
                {
                    // release
                    foreach (var item in assignReleaseModel.inventoryUnitList)
                    {
                        AssignProductOwnerWithoutCommit(_context, assignReleaseModel.FromId, assignReleaseModel.FromName, 0, string.Empty, item.ProductId, item.PackageId ?? 0, item.UnitQuantity, false, string.Empty);
                    }
                    // assign
                    if (assignReleaseModel.ToType == FromToType.Warehouse)
                    {
                        _inventoryUnitService.SaveDirectReceiveListWithoutCommit(_context, assignReleaseModel.inventoryUnitList, DateTime.Now, "Department Release");
                    }
                    else if (assignReleaseModel.ToType == FromToType.Department)
                    {
                        foreach (var item in assignReleaseModel.inventoryUnitList)
                        {
                            AssignProductOwnerWithoutCommit(_context, assignReleaseModel.ToId, assignReleaseModel.ToName, 0, string.Empty, item.ProductId, item.PackageId ?? 0, item.UnitQuantity, true, string.Empty);
                        }
                    }
                    else if (assignReleaseModel.ToType == FromToType.Employee)
                    {
                        foreach (var item in assignReleaseModel.inventoryUnitList)
                        {
                            AssignProductOwnerWithoutCommit(_context, 0, string.Empty, assignReleaseModel.ToId, assignReleaseModel.ToName, item.ProductId, item.PackageId ?? 0, item.UnitQuantity, true, string.Empty);
                        }
                    }
                }
                else if (assignReleaseModel.FromType == FromToType.Employee)
                {
                    // release
                    foreach (var item in assignReleaseModel.inventoryUnitList)
                    {
                        AssignProductOwnerWithoutCommit(_context, 0, string.Empty, assignReleaseModel.FromId, assignReleaseModel.FromName, item.ProductId, item.PackageId ?? 0, item.UnitQuantity, false, string.Empty);
                    }
                    // assign
                    if (assignReleaseModel.ToType == FromToType.Department)
                    {
                        foreach (var item in assignReleaseModel.inventoryUnitList)
                        {
                            AssignProductOwnerWithoutCommit(_context, assignReleaseModel.ToId, assignReleaseModel.ToName, 0, string.Empty, item.ProductId, item.PackageId ?? 0, item.UnitQuantity, true, string.Empty);
                        }
                    }
                }
                _context.SaveChanges();

                if (assignReleaseModel.FromType == FromToType.Department || assignReleaseModel.ToType == FromToType.Department)
                {
                    Department department;
                    if (assignReleaseModel.FromType == FromToType.Department)
                    {
                        department = _context.Departments.FirstOrDefault(x => x.Id == assignReleaseModel.FromId);
                    }
                    else
                    {
                        department = _context.Departments.FirstOrDefault(x => x.Id == assignReleaseModel.ToId);
                    }
                    _databaseChangeListener.TriggerDepartmentUpdateEvent(null, new DbEventArgs.BaseEventArgs<DepartmentModel>(department.MapToModel(), Utility.UpdateMode.EDIT));
                }
                else if(assignReleaseModel.FromType == FromToType.Employee || assignReleaseModel.ToType == FromToType.Employee)
                {
                    User user;
                    if (assignReleaseModel.FromType == FromToType.Employee)
                    {
                        user = _context.Users.FirstOrDefault(x => x.Id == assignReleaseModel.FromId);
                    }
                    else
                    {
                        user = _context.Users.FirstOrDefault(x => x.Id == assignReleaseModel.ToId);
                    }
                    _databaseChangeListener.TriggerUserUpdateEvent(null, new DbEventArgs.BaseEventArgs<UserModel>(user.MapToUserModel(), Utility.UpdateMode.EDIT));
                }
                else if (assignReleaseModel.FromType == FromToType.Warehouse || assignReleaseModel.ToType == FromToType.Warehouse)
                {
                    User user;
                    if (assignReleaseModel.FromType == FromToType.Employee)
                    {
                        user = _context.Users.FirstOrDefault(x => x.Id == assignReleaseModel.FromId);
                    }
                    else
                    {
                        user = _context.Users.FirstOrDefault(x => x.Id == assignReleaseModel.ToId);
                    }
                    _databaseChangeListener.TriggerUserUpdateEvent(null, new DbEventArgs.BaseEventArgs<UserModel>(user.MapToUserModel(), Utility.UpdateMode.EDIT));
                    _databaseChangeListener.TriggerProductUpdateEvent(null, null);
                    _databaseChangeListener.TriggerInventoryUnitUpdateEvent(null, new DbEventArgs.BaseEventArgs<List<ViewModel.Core.Inventory.InventoryUnitModel>>(assignReleaseModel.inventoryUnitList, Utility.UpdateMode.EDIT));
                }

                return new ResponseModel<bool>(true, Constants.SAVED_SUCCESSFULLY);
            }

        }

        public ProductOwner AssignProductOwnerWithoutCommit(DatabaseContext _context, int departmentId, string departmentName, int userId, string userName, int productId, int packageId, decimal quantity, bool inOut, string remarks)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == productId);
            ProductOwner owner = null;
            if (departmentId > 0)
                owner = _context.ProductOwners.FirstOrDefault(x => x.ProductId == productId && x.DepartmentId == departmentId);
            else if (userId > 0)
                owner = _context.ProductOwners.FirstOrDefault(x => x.ProductId == productId && x.UserId == userId);

            if (owner == null)
            {
                var basePackage = product.ProductPackages.FirstOrDefault(x => x.IsBasePackage);
                owner = new ProductOwner
                {
                    PackageId = basePackage.PackageId,
                    ProductId = productId,
                };
                if (departmentId > 0)
                    owner.DepartmentId = departmentId;
                else if (userId > 0)
                    owner.UserId = userId;
                _context.ProductOwners.Add(owner);
            }
            if (inOut)
                owner.Quantity += _uomService.ConvertUom(packageId, owner.PackageId, productId, quantity);
            else
                owner.Quantity -= _uomService.ConvertUom(packageId, owner.PackageId, productId, quantity);

            owner.UpdatedAt = DateTime.Now;
            // add to next department
            var history = new ProductOwnerHistory()
            {
                InOut = inOut,
                Quantity = quantity,
                UpdatedAt = DateTime.Now,
                ProductId = productId, //ownerModel.ProductId,
                PackageId = packageId,
                Remarks = string.IsNullOrEmpty(remarks) ? $"Assigned to {(string.IsNullOrEmpty(departmentName) ? userName : departmentName)}" : remarks,
            };
            if (departmentId > 0)
                history.DepartmentId = departmentId;
            else if (userId > 0)
                history.UserId = userId;
            _context.ProductOwnerHistories.Add(history);
            return owner;
        }

        public List<ProductOwnerModel> GetProductOnwerList(int departmentId, int userId)
        {
            using (var _context = DatabaseContext.Context)
            {
                var query = _context.ProductOwners.Where(x => x.Quantity > 0);
                if (departmentId > 0)
                    query = query.Where(x => x.DepartmentId == departmentId);
                else if (userId > 0)
                    query = query.Where(x => x.UserId == userId);
                return query.Select(s => new ProductOwnerModel
                {
                    PackageId = s.PackageId,
                    PackageName = s.Package.Name,
                    ProductName = s.Product.Name,
                    ProductId = s.ProductId,
                    Quantity = s.Quantity,
                    UpdatedAt = s.UpdatedAt,
                    DepartmentId = s.DepartmentId,
                    UserId = s.UserId,
                    Id = s.Id
                })
                .OrderBy(x => x.ProductId)
                .ToList();
            }
        }
    }
}
