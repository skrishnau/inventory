﻿using Infrastructure.Context;
using Infrastructure.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModel.Core.Inventory;
using System.Data.Entity;
using DTO.Core.Inventory;
using Service.Listeners;
using Service.Listeners.Inventory;
using Newtonsoft.Json;
using Service.DbEventArgs;
using ViewModel.Core.Common;
using Service.Utility;
using ViewModel.Enums.Inventory;
using ViewModel.Core.Business;
using Infrastructure.Entities.Business;
using DTO.Core.Business;
using ViewModel.Enums;
using ViewModel.Core.Orders;
using Service.Interfaces;
using System.Threading.Tasks;
using Infrastructure.Entities.Orders;

namespace Service.Core
{
    public class ProductService : IProductService
    {
        private readonly IDatabaseChangeListener _listener;
        private readonly IUomService _uomService;

        public ProductService(IDatabaseChangeListener listener, IUomService uomService)
        {
            _listener = listener;
            _uomService = uomService;
        }
        public void AddUpdateCategory(CategoryModel category)
        {
            using (var _context = new DatabaseContext())
            {
                var dbEntity = _context.Category.FirstOrDefault(x => x.Id == category.Id);
                var catEventArgs = CategoryEventArgs.Instance;
                if (dbEntity == null)
                {
                    dbEntity = category.ToEntity();
                    _context.Category.Add(dbEntity);
                    catEventArgs.Mode = Utility.UpdateMode.ADD;
                }
                else
                {
                    dbEntity.Name = category.Name;
                    dbEntity.UpdatedAt = DateTime.Now; // category.UpdatedAt;
                    catEventArgs.Mode = Utility.UpdateMode.EDIT;
                }
                _context.SaveChanges();
                catEventArgs.Category = CategoryMapper.MapToCategoryModel(dbEntity);
                _listener.TriggerCategoryUpdateEvent(null, catEventArgs);

            }

        }
        public string AddUpdateProduct(ProductModel model)
        {
            using (var _context = new DatabaseContext())
            {
                using (var txn = _context.Database.BeginTransaction())
                {

                    var now = DateTime.Now;

                    var entity = _context.Product
                        .Include(x => x.ProductAttributes)
                        .FirstOrDefault(x => x.Id == model.Id);

                    // check and get if base package has been changed
                    int? earlierBasePackageId = null;
                    var isBasePackageSame = true;
                    if (entity != null)
                    {
                        var basePackage = entity.ProductPackages.FirstOrDefault(x => x.IsBasePackage);
                        earlierBasePackageId = basePackage?.PackageId;
                        isBasePackageSame = basePackage?.PackageId == model.BasePackageId;
                    }
                    ProductEventArgs eventArgs = ProductEventArgs.Instance;
                    entity = ProductMapper.MapToEntity(model, entity);

                    var uomEntities = entity.Uoms.ToList();
                    if (uomEntities.Count > 0)
                    {
                        for (var i = 0; i < uomEntities.Count; i++)
                        {
                            // if it's not in the model then remove it
                            if (!model.Uoms.Any(x => x.Id == uomEntities[i].Id))
                            {
                                _context.Uom.Remove(uomEntities[i]);
                            }
                        }
                    }
                    for (var i = 0; i < entity.ProductPackages.Count; i++)
                    {
                        // need to set the base package to false before deleting from _context cause it's still available in entity.ProductPackages
                        entity.ProductPackages.ElementAt(i).IsBasePackage = false;
                        _context.ProductPackage.Remove(entity.ProductPackages.ElementAt(i));
                    }
                    List<ProductPackage> packageList = new List<ProductPackage>();
                    foreach (var uom in model.Uoms)
                    {
                        var uomEntity = uomEntities.FirstOrDefault(x => x.Id == uom.Id);
                        uomEntity = uom.MapToEntity(uomEntity);
                        if (uom.Id == 0)
                        {
                            entity.Uoms.Add(uomEntity);
                        }
                        if (!packageList.Any(x => x.PackageId == uom.PackageId))
                            entity.ProductPackages.Add(new ProductPackage
                            {
                                IsBasePackage = model.BasePackageId == uom.PackageId,
                                PackageId = uom.PackageId
                            });
                        if (!packageList.Any(x => x.PackageId == uom.RelatedPackageId))
                            entity.ProductPackages.Add(new ProductPackage
                            {
                                IsBasePackage = model.BasePackageId == uom.RelatedPackageId,
                                PackageId = uom.RelatedPackageId
                            });
                    }


                    if (entity.Id == 0)
                    {
                        // add
                        entity.CreatedAt = DateTime.Now;
                        entity.UpdatedAt = DateTime.Now;
                        entity.ProductAttributes = new List<ProductAttribute>();
                        //entity.Variants = new List<Variant>();
                        // entity.Brands = new List<Brand>();
                        _context.Product.Add(entity);
                        eventArgs.Mode = Utility.UpdateMode.ADD;
                    }
                    else
                    {
                        // udpate
                        entity.UpdatedAt = DateTime.Now;

                        if (!isBasePackageSame)
                        {
                            // convert the instock and onhold quantity based on current package
                            var conversion = _uomService.ConvertUom(_context, earlierBasePackageId ?? 0, model.BasePackageId ?? 0, entity.Id);
                            if (conversion == 0)
                            {
                                txn.Rollback();
                                return "The conversion from earlier base-package to current base-pacakge is not possible. Please update product's UOM";
                            }
                            entity.InStockQuantity = entity.InStockQuantity * conversion;
                            entity.OnHoldQuantity = entity.OnHoldQuantity * conversion;
                        }

                        eventArgs.Mode = Utility.UpdateMode.EDIT;

                    }
                    //  AssignBrandForSave(entity, model, now);
                    AssignProductAttributesForSave(entity, model, now);
                    //  AssignVariantsForSave(entity, model, now);
                    /*AddPriceHistoryWithoutCommit(_context, )
                    if (!isSellingPriceSame)
                    {
                        var priceHistory = new PriceHistory
                        {
                            Date = DateTime.Now,
                            Price = entity.RetailPrice,
                            PriceType = PriceTypeEnum.SellingPrice.ToString(),
                            PackageId = entity.PackageId == 0 ? null : entity.PackageId,
                        };
                        entity.PriceHistory.Add(priceHistory);
                    }
                    if (!isCostPriceSame)
                    {
                        var priceHistory = new PriceHistory
                        {
                            Date = DateTime.Now,
                            Price = entity.SupplyPrice,
                            PriceType = PriceTypeEnum.CostPrice.ToString(),
                            PackageId = entity.PackageId == 0 ? null : entity.PackageId,
                        };
                        entity.PriceHistory.Add(priceHistory);
                    }*/



                    _context.SaveChanges();
                    txn.Commit();
                    eventArgs.ProductModel = ProductMapper.MapToProductModel(entity);
                    _listener.TriggerProductUpdateEvent(null, eventArgs);
                    return string.Empty;
                }
            }
        }

        public void AddPriceHistoryWithoutCommit(Product product, decimal rate, string orderType, DateTime? completedDate, Package package, int? packageId)
        {
            var dt = (completedDate ?? DateTime.Now).Date;
            var rateHistory = product.PriceHistory.Where(x => x.Date == dt && x.PriceType == orderType).ToList();
            var rateFromHistory = (rateHistory.LastOrDefault()?.Price ?? 0) != rate;
            if (rate > 0 && rateFromHistory)
            {
                var priceHistory = new PriceHistory
                {
                    Date = dt,
                    Price = rate,
                    PriceType = orderType,
                };
                if (package != null)
                    priceHistory.Package = package;
                else if (packageId > 0)
                    priceHistory.PackageId = packageId;
                product.PriceHistory.Add(priceHistory);
            }
        }

        private void AssignProductAttributesForSave(Product productEntity, ProductModel product, DateTime now)
        {
            // dbEntity.ProductAttributes
            for (var p = 0; p < productEntity.ProductAttributes.Count; p++)
            {
                var paEntity = productEntity.ProductAttributes.ElementAt(p);
                var stillExists = product.ProductAttributes.FirstOrDefault(x => x.Id == paEntity.Id);
                if (stillExists == null)
                {
                    // means its deleted by user
                    productEntity.ProductAttributes.Remove(paEntity);
                    // decrement cause one entity is removed hence another is in that index
                    p--;
                }
            }
            foreach (var pa in product.ProductAttributes)
            {
                ProductAttribute paEntity;
                if (pa.Id == 0)
                {
                    // add
                    paEntity = pa.ToEntity();
                    productEntity.ProductAttributes.Add(paEntity);
                }
                else
                {
                    // update
                    paEntity = productEntity.ProductAttributes.FirstOrDefault(x => x.Id == pa.Id);
                    paEntity.Attribute = pa.Attribute;
                }
            }
        }
        public List<IdNamePair> GetProductListForCombo()
        {
            using (var _context = new DatabaseContext())
            {
                var products = _context.Product//.AsQueryable()// GetProductEntityList()
                .Where(x => x.Use)
                .Select(x => new IdNamePair()
                {
                    Id = x.Id,
                    Name = x.Name,// + " (" + x.SKU + ")",
                    ExtraValue = x.SKU
                })
                .ToList();
                return products;
                //.Where(x => x.DeletedAt == null);
            }
        }

        public int GetAllProductsCount(int categoryId, string searchText)
        {
            using (var _context = new DatabaseContext())
            {
                var query = GetProductListQuery(_context, categoryId, searchText);
                return query.Count();
            }
        }

        public async Task<ProductListModel> GetAllProducts(int categoryId, string searchText, int pageSize, int offset)
        {
            using (var _context = new DatabaseContext())
            {
                var products = GetProductListQuery(_context, categoryId, searchText);
                var totalCount = products.Count();
                if (pageSize > 0 && offset >= 0)
                {
                    products = products.Skip(offset).Take(pageSize);
                }
                var list = await products.ToListAsync();

                return new ProductListModel
                {
                    DataList = list.MapToModel(),
                    Offset = offset,
                    PageSize = pageSize,
                    TotalCount = totalCount,
                };
            }
        }

        public async Task<ProductListModel> GetAllProducts()
        {
            using (var _context = new DatabaseContext())
            {
                var products = GetProductListQuery(_context, 0, string.Empty);
                var totalCount = products.Count();
                var list = await products.ToListAsync();
                return new ProductListModel
                {
                    DataList = list.MapToModel(),
                    Offset = -1,
                    PageSize = -1,
                    TotalCount = totalCount,
                };
            }
        }

        private IQueryable<Product> GetProductListQuery(DatabaseContext _context, int categoryId, string searchText)
        {
            var products = _context.Product
                                .Include(x => x.ProductAttributes)
                                .Where(x => !x.IsDiscontinued)
                               //.Include(x => x.ProductAttributes.Select(y => y.Option))
                               // .Include(x => x.Brands)
                               // .Where(x => x.Use == null)
                               ;
            if (!string.IsNullOrEmpty(searchText))
                products = products.Where(x => x.Name.Contains(searchText));
            if (categoryId > 0)
                products = products.Where(x => x.CategoryId == categoryId);
            return products.OrderBy(o => o.Name);
        }

        public ProductModel GetProductBySKU(string sku)
        {
            using (var _context = new DatabaseContext())
            {
                var entity = _context.Product.FirstOrDefault(x => !x.IsDiscontinued && x.SKU == sku);
                return entity == null ? null : ProductMapper.MapToProductModel(entity);
            }
        }
        public ProductModel GetProductByNameOrSKU(string nameOrSku)
        {
            using (var _context = new DatabaseContext())
            {
                var entity = _context.Product.FirstOrDefault(x => !x.IsDiscontinued && (x.Name == nameOrSku || x.SKU == nameOrSku));
                return entity == null ? null : ProductMapper.MapToProductModel(entity);
            }
        }

        public ProductModel GetProductById(int id)
        {
            using (var _context = new DatabaseContext())
            {
                var entity = _context.Product.Find(id);
                return entity == null ? null : ProductMapper.MapToProductModel(entity);
            }
        }
        public void DeleteCategory(CategoryModel categoryModel)
        {
            using (var _context = new DatabaseContext())
            {
                var dbEntity = _context.Category.FirstOrDefault(x => x.Id == categoryModel.Id);
                if (dbEntity != null)
                {
                    dbEntity.DeletedAt = DateTime.Now;
                    _context.SaveChanges();
                }
            }
            _listener.TriggerCategoryUpdateEvent(null, new CategoryEventArgs(null, UpdateMode.DELETE));
        }

        public List<CategoryModel> GetCategoryList(int? parentCateogryId)
        {
            using (var _context = new DatabaseContext())
            {
                var cats = _context.Category
                                .Where(x => x.DeletedAt == null && x.ParentCategoryId == parentCateogryId)
                                .Select(x => new CategoryModel()
                                {
                                    Name = x.Name,
                                    ParentCategoryId = x.ParentCategoryId,
                                    Id = x.Id,
                                    CreatedAt = x.CreatedAt,
                                    UpdatedAt = x.UpdatedAt,
                                    ParentCategory = (x.ParentCategory == null ? "" : x.ParentCategory.Name)

                                }).ToList();

                foreach (var cat in cats)
                {
                    cat.SuCategories = GetCategoryList(cat.Id);  // TODO:: use property "SubCategories" of the entity instead of recursive call
                }
                return cats;
            }

        }

        public List<IdNamePair> GetAllCategoriesForCombo()
        {
            using (var _context = new DatabaseContext())
            {
                var query = _context.Category.Where(x => x.DeletedAt == null).ToList();
                var list = new List<IdNamePair>();
                GetChildCategories(query, null, string.Empty, ref list);
                return list;
            }
        }

        private string GetSpaces()
        {
            return "     ";
        }
        private void GetChildCategories(List<Category> query, int? parentCategoryId, string spaces, ref List<IdNamePair> list)
        {
            foreach (var x in query.Where(x => x.ParentCategoryId == parentCategoryId))
            {
                list.Add(new IdNamePair
                {
                    Id = x.Id,
                    Name = spaces + x.Name
                });
                GetChildCategories(query, x.Id, spaces + GetSpaces(), ref list);
            }
        }
        public List<IdNamePair> GetUnderStockProducts()
        {
            using (var _context = new DatabaseContext())
            {
                var products = _context.Product
                               .Include(x => x.ProductAttributes)
                               .Where(x => x.Use)
                               .Where(x => x.InStockQuantity <= x.ReorderPoint)
                               .OrderByDescending(x => x.ReorderPoint - x.InStockQuantity)
                               .Select(x => new IdNamePair
                               {
                                   Id = x.Id,
                                   Name = x.SKU + "  (" + x.Name + ")   -   " + ((int)x.InStockQuantity) + " qty.",
                               })
                               .ToList();
                return products;
            }
        }
        public CategoryModel GetCategory(string name)
        {
            using (var _context = new DatabaseContext())
            {
                name = name.Trim();
                var cat = _context.Category.FirstOrDefault(x => x.DeletedAt == null && x.Name == name);

                return new CategoryModel
                {
                    Name = cat.Name,
                    ParentCategoryId = cat.ParentCategoryId,
                    UpdatedAt = cat.UpdatedAt,
                    CreatedAt = cat.CreatedAt,
                    DeletedAt = cat.DeletedAt,
                    Id = cat.Id
                };
            }

        }

        public ProductModel GetProduct(int productId)
        {
            using (var _context = new DatabaseContext())
            {
                var product = _context.Product.Find(productId);
                if (product == null)
                    return null;
                return ProductMapper.MapToProductModel(product);
            }

        }

        public ProductModel GetProductForEdit(int productId)
        {
            using (var _context = new DatabaseContext())
            {
                var product = _context.Product
                               //.Include(x => x.Variants)
                               .Include(x => x.Uoms)
                               .Include(x => x.Category)
                               //.Include(x => x.Package)
                               .Include(x => x.ParentProduct)
                               .Include(x => x.Warehouse)
                               .FirstOrDefault(x => x.Id == productId);
                if (product == null)
                    return null;

                var productModel = ProductMapper.MapToProductModel(product);
                productModel.Uoms = UomMapper.MapToUomModel(product.Uoms.AsQueryable());
                return productModel;
            }

        }

        public bool DeleteProduct(int productId)
        {
            using (var _context = new DatabaseContext())
            {
                var now = DateTime.Now;

                var entity = _context.Product
                    .FirstOrDefault(x => x.Id == productId);

                if (entity != null)
                {
                    entity.IsDiscontinued = true;
                    entity.Use = false;
                }
                _context.SaveChanges();

                ProductEventArgs eventArgs = ProductEventArgs.Instance;
                eventArgs.Mode = UpdateMode.DELETE;
                eventArgs.ProductModel = ProductMapper.MapToProductModel(entity);
                _listener.TriggerProductUpdateEvent(null, eventArgs);
                return true;
            }
        }

        public List<PriceHistoryModel> GetPriceHistory(int productId)
        {
            using (var _context = new DatabaseContext())
            {
                var thiryDays = DateTime.Now.AddDays(-31);
                var priceType = OrderTypeEnum.Sale.ToString();
                return _context.PriceHistory.Where(x => x.ProductId == productId && x.PriceType == priceType && x.Date > thiryDays).OrderByDescending(x => x.Date).MapToPriceHistoryModel();
            }
        }
    }
}
