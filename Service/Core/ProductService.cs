using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModel.Core.Inventory;
using System.Data.Entity;
using DTO.Core.Inventory;
using Service.Listeners;
using Service.Listeners.Inventory;
using Service.DbEventArgs;
using ViewModel.Core.Common;
using Service.Utility;
using ViewModel.Enums;
using Service.Interfaces;
using System.Threading.Tasks;
using ViewModel.Core;
using ViewModel.Utility;

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
                var dbEntity = _context.Categories.FirstOrDefault(x => x.Id == category.Id);
                var catEventArgs = CategoryEventArgs.Instance;
                if (dbEntity == null)
                {
                    dbEntity = category.ToEntity();
                    _context.Categories.Add(dbEntity);
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

                    var entity = _context.Products
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
                                _context.Uoms.Remove(uomEntities[i]);
                            }
                        }
                    }
                    var ppackages = entity.ProductPackages.ToList();
                    for (var i = 0; i < ppackages.Count; i++)
                    {
                        // need to set the base package to false before deleting from _context cause it's still available in entity.ProductPackages
                        ppackages.ElementAt(i).IsBasePackage = false;
                        //_context.ProductPackages.Remove(entity.ProductPackages.ElementAt(i));
                    }
                    _context.ProductPackages.RemoveRange(entity.ProductPackages);
                    List<ProductPackage> packageList = new List<ProductPackage>();
                    var uomListForConversionUse = new List<Uom>();
                    foreach (var uom in model.Uoms)
                    {
                        var uomEntity = uomEntities.FirstOrDefault(x => x.Id == uom.Id);
                        uomEntity = uom.MapToEntity(uomEntity);
                        if (uom.Id == 0)
                        {
                            entity.Uoms.Add(uomEntity);
                        }
                        uomListForConversionUse.Add(new Uom
                        {
                            PackageId = uomEntity.PackageId,
                            RelatedPackageId = uomEntity.RelatedPackageId,
                            ProductId = entity.Id,
                            Package = _context.Packages.Find(uomEntity.PackageId),
                            Package1 = _context.Packages.Find(uomEntity.RelatedPackageId),
                            Use = true,
                            Quantity = uomEntity.Quantity,
                        });
                        if (!packageList.Any(x => x.PackageId == uom.PackageId))
                        {
                            var pp = new ProductPackage
                            {
                                IsBasePackage = model.BasePackageId == uom.PackageId,
                                PackageId = uom.PackageId
                            };
                            entity.ProductPackages.Add(pp);
                            packageList.Add(pp);
                        }
                        if (!packageList.Any(x => x.PackageId == uom.RelatedPackageId))
                        {
                            var pp = new ProductPackage
                            {
                                IsBasePackage = model.BasePackageId == uom.RelatedPackageId,
                                PackageId = uom.RelatedPackageId
                            };
                            entity.ProductPackages.Add(pp);
                            packageList.Add(pp);
                        }
                    }


                    if (entity.Id == 0)
                    {
                        // add
                        entity.CreatedAt = DateTime.Now;
                        entity.UpdatedAt = DateTime.Now;
                        entity.ProductAttributes = new List<ProductAttribute>();
                        //entity.Variants = new List<Variant>();
                        // entity.Brands = new List<Brand>();
                        _context.Products.Add(entity);
                        eventArgs.Mode = Utility.UpdateMode.ADD;
                    }
                    else
                    {
                        // udpate
                        entity.UpdatedAt = DateTime.Now;

                        if (!isBasePackageSame)
                        {

                            // convert the instock and onhold quantity based on current package
                            var conversion = _uomService.ConvertUom(_context, earlierBasePackageId ?? 0, model.BasePackageId ?? 0, entity.Id, 1, uomListForConversionUse);
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
            var rateHistory = product.PriceHistories.Where(x => x.Date == dt && x.PriceType == orderType).ToList();
            var rateFromHistory = (rateHistory.LastOrDefault()?.Rate ?? 0) != rate;
            if (rate > 0 && rateFromHistory)
            {
                var priceHistory = new PriceHistory
                {
                    Date = dt,
                    Rate = rate,
                    PriceType = orderType,
                };
                if (package != null)
                    priceHistory.Package = package;
                else if (packageId > 0)
                    priceHistory.PackageId = packageId;
                product.PriceHistories.Add(priceHistory);
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
        public List<IdNamePair> GetProductListForCombo(int categoryId = 0)
        {
            using (var _context = new DatabaseContext())
            {
                var query = _context.Products
                    .Where(x => x.Use && !x.IsDiscontinued);
                if (categoryId > 0)
                    query = query.Where(x => x.CategoryId == categoryId);
                var products = query.Select(x => new IdNamePair()
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
            var products = _context.Products
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
                var entity = _context.Products.FirstOrDefault(x => !x.IsDiscontinued && x.SKU == sku);
                return entity == null ? null : ProductMapper.MapToProductModel(entity);
            }
        }
        // here orderId is the order that we are editing. This order's items will be added/subtracted from the in-stock quantity of this product
        // when editing a completed sale transaction, we need to show Instock quty as the totalInstock + product's qty in the order
        // when editing a completed purchase transactio, we need to show Instock qty as the totalInstock - product's qty in the order
        public ProductModel GetProductByNameOrSKU(string nameOrSku)//, int orderId
        {
            using (var _context = new DatabaseContext())
            {
                var entity = _context.Products.FirstOrDefault(x => !x.IsDiscontinued && (x.Name == nameOrSku || x.SKU == nameOrSku));

                var model = entity == null ? null : ProductMapper.MapToProductModel(entity);
                //model.InStockQuantity = AssignInStockQuantityBasedOnOrderForTxnEdit(_context, model, orderId, null);
                return model;
            }
        }
        /*
        public decimal AssignInStockQuantityBasedOnOrderForTxnEdit(DatabaseContext _context, ProductModel product, int orderId, Order order)
        {
            var total = product.InStockQuantity;
            if (orderId > 0 && order == null)
            {
                order = _context.Orders.Find(orderId);
            }
            if (order != null)
            {
                var inStockAddition = order.OrderItems.Where(x => x.ProductId == product.Id).ToList();
                if (inStockAddition.Any())
                {
                    foreach (var item in inStockAddition)
                    {
                        var conversion = _uomService.ConvertUom(_context, item.PackageId ?? 0, product.BasePackageId ?? 0, product.Id, 1, null);
                        if (order.OrderType == OrderTypeEnum.Sale.ToString())
                        {
                            total += conversion * item.UnitQuantity;
                        }
                        else
                        {
                            total -= conversion * item.UnitQuantity;
                        }
                    }
                }
            }

            return Math.Round(total, 2);
        }
        */
        // here orderId is the order that we are editing. This order's items will be added/subtracted from the in-stock quantity of this product
        public ProductModel GetProductById(int id)//, int orderId
        {
            using (var _context = new DatabaseContext())
            {
                var entity = _context.Products.Find(id);
                var model = entity == null ? null : ProductMapper.MapToProductModel(entity);
               // model.InStockQuantity = AssignInStockQuantityBasedOnOrderForTxnEdit(_context, model, orderId, null);
                return model;
            }
        }
        public ResponseModel<CategoryModel> DeleteCategory(CategoryModel categoryModel)
        {
            using (var _context = new DatabaseContext())
            {
                // check if category is being used by any product

                var dbEntity = _context.Categories.Include(x => x.Products).FirstOrDefault(x => x.Id == categoryModel.Id);
                if (dbEntity != null)
                {
                    var isUsed = dbEntity.Products.Any(x => !x.IsDiscontinued);
                    if (isUsed)
                    {
                        return ResponseModel<CategoryModel>.GetError("This category is referenced by active products. Please delete the products or change those product's category first.");
                    }
                    dbEntity.DeletedAt = DateTime.Now;
                    _context.SaveChanges();
                }
            }
            _listener.TriggerCategoryUpdateEvent(null, new CategoryEventArgs(null, UpdateMode.DELETE));
            return ResponseModel<CategoryModel>.GetSuccess();
        }

        public List<CategoryModel> GetCategoryList(int? parentCateogryId)
        {
            using (var _context = new DatabaseContext())
            {
                var cats = _context.Categories
                                .Where(x => x.DeletedAt == null && x.ParentCategoryId == parentCateogryId)
                                .Select(x => new CategoryModel()
                                {
                                    Name = x.Name,
                                    ParentCategoryId = x.ParentCategoryId,
                                    Id = x.Id,
                                    CreatedAt = x.CreatedAt,
                                    UpdatedAt = x.UpdatedAt,
                                    ParentCategory = (x.Category1 == null ? "" : x.Category1.Name)

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
                var query = _context.Categories.Where(x => x.DeletedAt == null).ToList();
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
                var products = _context.Products
                               .Include(x => x.ProductAttributes)
                               .Where(x => x.Use && !x.IsDiscontinued)
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
                var cat = _context.Categories.FirstOrDefault(x => x.DeletedAt == null && x.Name == name);

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
                var product = _context.Products.Find(productId);
                if (product == null)
                    return null;
                return ProductMapper.MapToProductModel(product);
            }

        }

        public ProductModel GetProductForEdit(int productId)
        {
            using (var _context = new DatabaseContext())
            {
                var product = _context.Products
                               //.Include(x => x.Variants)
                               .Include(x => x.Uoms)
                               .Include(x => x.Category)
                               //.Include(x => x.Package)
                               .Include(x => x.Product1)
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

                var entity = _context.Products
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
                return _context.PriceHistories.Where(x => x.ProductId == productId && x.PriceType == priceType && x.Date > thiryDays).OrderByDescending(x => x.Date).MapToPriceHistoryModel();
            }
        }

        // TODO: optimize
        public List<PriceHistoryModel> GetPriceHistory(int productId, DateTime? date, OrderTypeEnum? type)
        {
            using (var _context = new DatabaseContext())
            {

                //var thiryDays = DateTime.Now.AddDays(-31);
                //var priceType = OrderTypeEnum.Sale.ToString();
                //return _context.PriceHistories.Where(x => x.ProductId == productId && x.PriceType == priceType && x.Date > thiryDays).OrderByDescending(x => x.Date).MapToPriceHistoryModel();
                var sale = OrderTypeEnum.Sale.ToString();
                var purchase = OrderTypeEnum.Purchase.ToString();
                var list = new List<PriceHistoryModel>();
                IQueryable<PriceHistory> query = _context.PriceHistories.AsQueryable();
                IQueryable<IGrouping<dynamic, PriceHistory>> a;
                if (productId > 0)
                {
                    query = query.Where(x => x.ProductId == productId);
                }
                if (date.HasValue)
                {
                    var dt = date.Value.Date;
                    query = query.Where(x => x.Date == dt);
                }
                if (type != null)
                {
                    var typeStr = type.ToString();
                    query = query.Where(x => x.PriceType == typeStr);
                }
                query = query.OrderBy(x => x.Date);

                if ((productId > 0 && date.HasValue))
                {
                    var grp = query.GroupBy(x => new { x.Date, x.Product });
                    foreach (var g in grp)
                    {
                        // list.Add(GetRateModel(g.Key.Product, g.Key.Date, g.ToList(), sale, purchase));
                        list.Add(GetRateModel(g.Key.Product, g.Key.Date, g.FirstOrDefault(), type.ToString(), sale, purchase));
                    }
                }
                else if (productId > 0)
                {
                    var product = _context.Products.Find(productId);
                    if (product != null)
                    {
                        var grp = query.GroupBy(x => new { x.Date });
                        foreach (var g in grp)
                        {
                            //list.Add(GetRateModel(product, g.Key.Date, g.ToList(), sale, purchase));
                            list.Add(GetRateModel(product, g.Key.Date, g.FirstOrDefault(), type.ToString(), sale, purchase));
                        }
                    }
                }
                else if (date.HasValue)
                {
                    var products = _context.Products.Where(x => !x.IsDiscontinued && x.Use);
                    var grp = query.GroupBy(x => new { x.Product });
                    foreach (var prod in products)
                    {
                        //list.Add(GetRateModel(prod, date.Value, grp.Where(x => x.Key.Product.Id == prod.Id).SelectMany(x => x).ToList(), sale, purchase));
                        list.Add(GetRateModel(prod, date.Value, grp.Where(x => x.Key.Product.Id == prod.Id).SelectMany(x => x).FirstOrDefault(), type.ToString(), sale, purchase));
                    }
                    foreach (var g in grp)
                    {
                        if (!list.Any(x => x.ProductId == g.Key.Product.Id))
                        {
                            //list.Add(GetRateModel(g.Key.Product, date.Value, g.ToList(), sale, purchase));
                            var rm = GetRateModel(g.Key.Product, date.Value, g.FirstOrDefault(), type.ToString(), sale, purchase);
                            if (rm != null)
                                list.Add(rm);
                        }
                    }
                }
                return list.OrderBy(x => x.Product).ToList();
            }
        }
        // private PriceHistoryModel GetRateModel(Product product, DateTime date, List<PriceHistory> priceHistories, string saleType, string purchaseType)
        private PriceHistoryModel GetRateModel(Product product, DateTime date, PriceHistory priceHistories, string type, string saleType, string purchaseType)
        {
            /*
            var sellingPrice = priceHistories.FirstOrDefault(x => x.PriceType == saleType);
            var costPrice = priceHistories.FirstOrDefault(x => x.PriceType == purchaseType);

            var rateModel = new RateModel
            {
                CostPrice = costPrice?.Price.ToString("#.00") ?? "",
                SellingPrice = sellingPrice?.Price.ToString("#.00") ?? "",
                CostPricePackage = costPrice?.Package.Name ?? "",
                SellingPricePackage = sellingPrice?.Package.Name ?? "",
                DateString = DateConverter.Instance.ToBS(date).ToString(),
                Product = product.Name,
                ProductId = product.Id,
            };
            return rateModel;*/
            //if (priceHistories != null)
            //{
            var package = priceHistories?.Package != null ? priceHistories.Package : product.ProductPackages.FirstOrDefault(x => x.IsBasePackage)?.Package;
            var rateModel = new PriceHistoryModel
            {
                Date = date,
                Package = package?.Name ?? "",
                PackageId = package?.Id ?? 0,
                Rate = (priceHistories?.Rate ?? 0) == 0 ? null : priceHistories?.Rate,
                PriceType = type, // priceHistories?.PriceType,
                DateString = DateConverter.Instance.ToBS(date).ToString(),
                Product = product.Name,
                ProductId = product.Id,
                Id = priceHistories?.Id ?? 0
            };
            return rateModel;
            //}
            // return null;
        }

        public ResponseModel<bool> SavePriceHistory(List<InventoryUnitModel> data, DateTime date, OrderTypeEnum type)
        {
            using (var _context = new DatabaseContext())
            {
                date = date.Date;
                var typeStr = type.ToString();
                foreach (var model in data)
                {

                    var packageId = model.PackageId;
                    if (packageId == 0)
                        packageId = _context.Packages.FirstOrDefault(x => x.Name == model.Package)?.Id ?? 0;
                    var productId = model.ProductId;
                    if (productId == 0)
                        productId = _context.Products.FirstOrDefault(x => x.Name == model.Product || x.SKU == model.Product)?.Id ?? 0;
                    var entity = _context.PriceHistories.FirstOrDefault(x => x.ProductId == productId && x.Date == date && x.PriceType == typeStr); //&& x.PackageId == packageId
                    if (entity == null)
                    {
                        if (model.Rate > 0)
                        {
                            entity = new PriceHistory
                            {
                                Date = date,
                                PackageId = packageId,
                                Rate = model.Rate,
                                PriceType = type.ToString(),
                                ProductId = productId,
                            };
                            _context.PriceHistories.Add(entity);
                        }
                    }
                    else
                    {
                        if (model.Rate > 0)
                        {
                            entity.PackageId = model.PackageId;
                            entity.Rate = model.Rate;
                        }
                        else
                        {
                            _context.PriceHistories.Remove(entity);
                        }
                    }
                }
                _context.SaveChanges();
                var args = new BaseEventArgs<PriceHistoryModel>(null, UpdateMode.EDIT);
                var priceModel = new PriceHistoryModel
                {
                    Date = date,
                };
                _listener.TriggerPriceHistoryUpdateEvent(priceModel, args);
                return ResponseModel<bool>.GetSuccess();
            }
        }

        public PriceHistoryModel GetPrice(int productId, DateTime date, MovementTypeEnum movementType, int packageId, string package)
        {
            date = date.Date;
            var type = "";
            using (var _context = new DatabaseContext())
            {
                package = package?.Trim();
                if (!string.IsNullOrEmpty(package))
                {
                    var pkg = _context.Packages.FirstOrDefault(x => x.Name == package);
                    if (pkg != null)
                        packageId = pkg.Id;
                }
                else
                {
                    var pkg = _context.Packages.Find(packageId);
                    if (pkg != null)
                        package = pkg.Name;
                }
                switch (movementType)
                {
                    case MovementTypeEnum.DirectIssueAny:
                    case MovementTypeEnum.DirectIssueInventoryUnit:
                    case MovementTypeEnum.SOIssue:
                    case MovementTypeEnum.SOIssueEditItems:
                        type = OrderTypeEnum.Sale.ToString().ToLower();
                        break;
                    case MovementTypeEnum.DirectReceive:
                    case MovementTypeEnum.POReceive:
                    case MovementTypeEnum.POReceiveEditItems:
                        type = OrderTypeEnum.Purchase.ToString().ToLower();
                        break;
                }

                //var st = _context.PriceHistories
                //            .Where(x => x.Date <= date && x.ProductId == productId && x.PriceType.ToLower() == purchase && x.PackageId == packageId)
                //            .OrderByDescending(x => x.Date).ToList();
                //return st.FirstOrDefault()
                //        ?.MapToPriceHistoryModel();//?.Rate;

                var sellHistory = _context.PriceHistories.Where(x => x.Date <= date
                                                && x.ProductId == productId
                                                && x.PriceType.ToLower() == type)
                                                .ToList();

                if (sellHistory.Any())
                {
                    var dt = sellHistory.Max(x => x.Date).Date;
                    var lastPrices = sellHistory.Where(x => x.Date.Date == dt);
                    var chosenPrice = lastPrices.FirstOrDefault(x => x.PackageId == packageId);
                    if (chosenPrice != null)
                    {
                        return chosenPrice.MapToPriceHistoryModel();
                    }
                    chosenPrice = lastPrices.FirstOrDefault();
                    var conversion = _uomService.ConvertUom(_context, chosenPrice.PackageId ?? 0, packageId, productId, 1, null);
                    if (conversion > 0)
                    {
                        var model = chosenPrice.MapToPriceHistoryModel();
                        model.Package = package;
                        model.PackageId = packageId;
                        model.Rate = model.Rate / conversion;
                        return model;
                    }
                }
            }
            return null;
        }
    }
}
