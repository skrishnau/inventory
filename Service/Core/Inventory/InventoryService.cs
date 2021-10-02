using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModel.Core.Inventory;
using System.Data.Entity;
using DTO.Core.Inventory;
using Service.Listeners;
using Service.DbEventArgs;
using ViewModel.Core.Common;
using ViewModel.Enums.Inventory;
using ViewModel.Core.Business;
using ViewModel.Enums;
using ViewModel.Core.Orders;
using ViewModel.Core;

namespace Service.Core.Inventory
{
    public class InventoryService : IInventoryService
    {

        // private readonly DatabaseContext _context;
        private readonly IDatabaseChangeListener _listener;

        public InventoryService(IDatabaseChangeListener listener)//DatabaseContext context,
        {
            //_context = context;
            _listener = listener;
        }

        #region Warehouse

        public void AddOrUpdateWarehouse(WarehouseModel model)
        {
            using (var _context = DatabaseContext.Context)
            {
                var entity = _context.Warehouses.FirstOrDefault(x => x.Id == model.Id);
                BaseEventArgs<WarehouseModel> args = BaseEventArgs<WarehouseModel>.Instance;
                entity = model.MapToEntity(entity);

                if (entity.Id == 0)
                {
                    entity.CreatedAt = DateTime.Now;
                    entity.UpdatedAt = DateTime.Now;
                    _context.Warehouses.Add(entity);
                    args.Mode = Utility.UpdateMode.ADD;
                }
                else
                {
                    entity.UpdatedAt = DateTime.Now;
                    args.Mode = Utility.UpdateMode.EDIT;
                }
                _context.SaveChanges();
                args.Model = entity.MapToModel();// WarehouseMapper.MapToModel(entity);
                _listener.TriggerWarehouseUpdateEvent(null, args);
            }

        }

        //public void DeleteWarehouse(int id)
        //{
        //    var warehouse = _context.Warehouses.Find(id);
        //    if (warehouse != null)
        //    {
        //        warehouse.DeletedAt = DateTime.Now;
        //        _context.SaveChanges();
        //        var args = new BaseEventArgs<WarehouseModel>(warehouse.MapToModel(), Utility.UpdateMode.DELETE);
        //        _listener.TriggerWarehouseUpdateEvent(null, args);
        //    }
        //}

        public WarehouseModel GetWarehouse(int warehouseId)
        {
            using (var _context = DatabaseContext.Context)
            {
                var warehouse = _context.Warehouses.Find(warehouseId);
                if (warehouse != null)
                {
                    return warehouse.MapToModel();// WarehouseMapper.MapToModel(warehouse);
                }
                return null;
            }

        }


        public List<WarehouseModel> GetWarehouseList()
        {
            using (var _context = DatabaseContext.Context)
            {
                //var warehouses = 
                return _context.Warehouses
                    .OrderBy(x => x.Name)
                    .MapToModel();
            }

        }

        /// <summary>
        /// Returns list of "Use" able Warehouses only
        /// </summary>
        /// <returns>List of IdNamePair </returns>
        public List<IdNamePair> GetWarehouseListForCombo()
        {
            using (var _context = DatabaseContext.Context)
            {
                return _context.Warehouses
                              .Where(x => x.Use)
                                 .Select(x => new IdNamePair()
                                 {
                                     Id = x.Id,
                                     Name = x.Name,
                                 })
                                 .ToList();
            }

        }

        #endregion


        #region Package

        public List<IdNamePair> GetPackageListForCombo()
        {
            using (var _context = DatabaseContext.Context)
            {
                return _context.Packages
                                .Where(x => x.Use)
                                .Select(x => new IdNamePair()
                                {
                                    Id = x.Id,
                                    Name = x.Name
                                }).ToList();
            }

        }

        #endregion

        #region Product



        #endregion


        private IQueryable<Product> GetProductEntityList()
        {
            using (var _context = DatabaseContext.Context)
            {
                return _context.Products.AsQueryable();
                //.Where(x => x.DeletedAt == null);
            }

        }



        #region Adjustment Code

        public List<IdNamePair> GetAdjustmentCodeListForCombo()
        {
            using (var _context = DatabaseContext.Context)
            {
                if (_context.AdjustmentCodes.Count() == 0)
                    SeedAdjustmentCodes(_context);
                return _context.AdjustmentCodes
                                .Where(x => x.Use)
                                .Select(x => new IdNamePair()
                                {
                                    Id = x.Id,
                                    Name = x.Name
                                })
                                .ToList();
            }

        }

        public List<IdNamePair> GetPositiveAdjustmentCodeListForCombo()
        {
            using (var _context = DatabaseContext.Context)
            {
                var positive = AdjustmentType.Positive.ToString();
                if (_context.AdjustmentCodes.Count() == 0)
                    SeedAdjustmentCodes(_context);
                return _context.AdjustmentCodes
                   .Where(x => x.Use && x.Type == positive)
                   .Select(x => new IdNamePair()
                   {
                       Id = x.Id,
                       Name = x.Name
                   })
                   .ToList();
            }

        }

        public List<IdNamePair> GetNegativeAdjustmentCodeListForCombo()
        {
            using (var _context = DatabaseContext.Context)
            {
                var negative = AdjustmentType.Negative.ToString();
                if (_context.AdjustmentCodes.Count() == 0)
                    SeedAdjustmentCodes(_context);
                return _context.AdjustmentCodes
                   .Where(x => x.Use && x.Type == negative)
                   .Select(x => new IdNamePair()
                   {
                       Id = x.Id,
                       Name = x.Name
                   })
                   .ToList();
            }

        }

        public ResponseModel<AdjustmentCodeModel> SaveAdjustmentCode(AdjustmentCodeModel model)
        {
            using (var _context = DatabaseContext.Context)
            {
                var msg = "";
                var args = BaseEventArgs<AdjustmentCodeModel>.Instance;
                var duplicate = _context.AdjustmentCodes.FirstOrDefault(x => x.Id != model.Id && x.Name == model.Name);
                if (duplicate != null)
                {
                    return ResponseModel<AdjustmentCodeModel>.GetError("Same 'Adjustment Code' already exists");
                }

                // get the package
                var entity = _context.AdjustmentCodes.FirstOrDefault(x => x.Id == model.Id);
                entity = model.MapToEntity(entity);//AdjustmentCodeMapper.MapToEntity
                if (model.Id == 0)
                {
                    // add
                    _context.AdjustmentCodes.Add(entity);
                    args.Mode = Utility.UpdateMode.ADD;
                }
                else
                {
                    args.Mode = Utility.UpdateMode.EDIT;
                }
                _context.SaveChanges();
                args.Model = entity.MapToModel();//AdjustmentCodeMapper.MapToModel(entity)
                _listener.TriggerAdjustmentCodeUpdateEvent(null, args);
                return ResponseModel<AdjustmentCodeModel>.GetSaveSuccess(args.Model);
            }

        }

        public List<AdjustmentCodeModel> GetAdjustmentCodeList()
        {
            using (var _context = DatabaseContext.Context)
            {
                var query = _context.AdjustmentCodes.AsEnumerable();
                if (!query.Any())
                {
                    // add system defined adj codes
                    SeedAdjustmentCodes(_context);
                }
                return query.MapToModel();// AdjustmentCodeMapper.MapToModel(query);

            }
        }

        public List<AdjustmentCodeModel> GetAdjustmentCodeListUsableOnly()
        {
            return GetAdjustmentCodeList().Where(x => x.Use).ToList();
        }

        private void SeedAdjustmentCodes(DatabaseContext _context)
        {
            //
            // Positive
            //
            _context.AdjustmentCodes.Add(new AdjustmentCode()
            {
                AffectsDemand = false,
                IsSystem = true,
                Name = "Assembled",
                Type = AdjustmentTypeEnum.Positive.ToString(),
                Use = true,
            });
            _context.AdjustmentCodes.Add(new AdjustmentCode()
            {
                AffectsDemand = false,
                IsSystem = true,
                Name = "Imported",
                Type = AdjustmentTypeEnum.Positive.ToString(),
                Use = true,
            });
            _context.AdjustmentCodes.Add(new AdjustmentCode()
            {
                AffectsDemand = false,
                IsSystem = true,
                Name = "PO receive",
                Type = AdjustmentTypeEnum.Positive.ToString(),
                Use = true,
            });
            _context.AdjustmentCodes.Add(new AdjustmentCode()
            {
                AffectsDemand = false,
                IsSystem = true,
                Name = "Direct Receive",
                Type = AdjustmentTypeEnum.Positive.ToString(),
                Use = true,
            });

            //
            // Negative
            //
            _context.AdjustmentCodes.Add(new AdjustmentCode()
            {
                AffectsDemand = false,
                IsSystem = true,
                Name = "Damaged/Broken",
                Type = AdjustmentTypeEnum.Negative.ToString(),
                Use = true,
            });
            _context.AdjustmentCodes.Add(new AdjustmentCode()
            {
                AffectsDemand = false,
                IsSystem = true,
                Name = "Direct Issue",
                Type = AdjustmentTypeEnum.Negative.ToString(),
                Use = true,
            });
            _context.AdjustmentCodes.Add(new AdjustmentCode()
            {
                AffectsDemand = false,
                IsSystem = true,
                Name = "Disassembled",
                Type = AdjustmentTypeEnum.Negative.ToString(),
                Use = true,
            });
            _context.AdjustmentCodes.Add(new AdjustmentCode()
            {
                AffectsDemand = false,
                IsSystem = true,
                Name = "Used in Repairs",
                Type = AdjustmentTypeEnum.Negative.ToString(),
                Use = true,
            });
            _context.AdjustmentCodes.Add(new AdjustmentCode()
            {
                AffectsDemand = false,
                IsSystem = true,
                Name = "SO issue",
                Type = AdjustmentTypeEnum.Negative.ToString(),
                Use = true,
            });

            _context.SaveChanges();
        }

        #endregion



        #region Settings

        public ResponseModel<PackageModel> SavePackage(PackageModel package)
        {
            using (var _context = DatabaseContext.Context)
            {
                var response = new ResponseModel<PackageModel>();
                var msg = "";
                var args = BaseEventArgs<PackageModel>.Instance;
                var duplicate = _context.Packages.FirstOrDefault(x => x.Id != package.Id && x.Name == package.Name);
                if (duplicate != null)
                {
                    response.Message = "Same 'Package' Name already exists";
                    response.Success = false;
                    return response;
                }

                // get the package
                var entity = _context.Packages.FirstOrDefault(x => x.Id == package.Id);
                entity = PackageMapper.MapToEntity(package, entity);
                if (package.Id == 0)
                {
                    // add
                    _context.Packages.Add(entity);
                    args.Mode = Utility.UpdateMode.ADD;
                }
                else
                {
                    args.Mode = Utility.UpdateMode.EDIT;
                }
                _context.SaveChanges();
                args.Model = PackageMapper.MapToModel(entity);
                _listener.TriggerPackageUpdateEvent(null, args);
                response.Data = args.Model;
                response.Success = true;
                response.Message = "Save Successful";
                return response;
            }
        }

        public List<PackageModel> GetPackageList()
        {
            using (var _context = DatabaseContext.Context)
            {
                var query = _context.Packages.OrderBy(x => x.Name).AsQueryable();
                return PackageMapper.MapToModel(query);
            }
        }

        public PackageModel GetPackage(int packageId)
        {
            using (var _context = DatabaseContext.Context)
            {
                return _context.Packages.Find(packageId).MapToModel();
            }
        }

        public PackageModel GetPackageByName(string packagename)
        {
            using (var _context = DatabaseContext.Context)
            {
                return _context.Packages.FirstOrDefault(x => x.Name == packagename).MapToModel();
            }
        }

        public List<WarehouseProductModel> GetWarehouseProductList(int warehouseId, int productId)
        {
            using (var _context = DatabaseContext.Context)
            {
                var wpList = _context.WarehouseProducts
                                .Include(x => x.Product)
                                .Include(x => x.Warehouse)
                                .Where(x => x.InStockQuantity > 0
                                    && (warehouseId == 0 || x.WarehouseId == warehouseId)
                                    && (productId == 0 || x.ProductId == productId))
                                .OrderBy(x => x.Warehouse.Name)
                                .ThenBy(x => x.Product.Name);
                return WarehouseProductMapper.MapToModel(wpList);
            }

        }

        public List<IdNamePair> GetSupplierListForCombo()
        {
            using (var _context = DatabaseContext.Context)
            {
                return _context.Users
                                //.Where(x=>x.Use)
                                .Select(x => new IdNamePair()
                                {
                                    Id = x.Id,
                                    Name = x.Name,
                                }).ToList();
            }
        }

        public List<TransactionSummaryModel> GetTransactionSummary(DateTime start, DateTime end)
        {
            var list = new List<TransactionSummaryModel>();
            using (var _context = DatabaseContext.Context)
            {
                var totalOrders = _context.Orders.Where(x => x.IsCompleted && x.CompletedDate >= start && x.CompletedDate <= end)
                    .GroupBy(x => x.OrderType)
                    .Select(x => new TransactionSummaryModel
                    {
                        Key = x.Key,
                        Value = x.Count()
                    })
                    .ToList();
                list.AddRange(totalOrders);
                var sss = _context.Orders.ToList();
            }
            return list;
        }

        public List<TransactionSummaryModel> GetInventorySummary()
        {
            var list = new List<TransactionSummaryModel>();
            using (var _context = DatabaseContext.Context)
            {
                var totalProducts = _context.Products.Count();
                list.Add(new TransactionSummaryModel { Key = TransactionSummaryKeys.Product.ToString(), Value = totalProducts });
                var totalInventoryQty = _context.Products.Select(x => (decimal?)x.InStockQuantity).Sum() ?? 0;
                list.Add(new TransactionSummaryModel { Key = TransactionSummaryKeys.InventoryQuantity.ToString(), Value = totalInventoryQty });
                var customer = UserTypeEnum.Customer.ToString();
                var totalCustomers = _context.Users.Where(x => x.UserType == customer).Count();
                list.Add(new TransactionSummaryModel { Key = TransactionSummaryKeys.Customer.ToString(), Value = totalCustomers });
            }
            return list;
        }

        #endregion



        #region UOM

        public ResponseModel<UomModel> SaveUom(UomModel model)
        {
            using (var _context = DatabaseContext.Context)
            {
                var alreadyExists = _context.Uoms.Any(x => x.Id != model.Id && x.ProductId == null && ((x.Package.Name == model.Package && x.Package1.Name == model.RelatedPackage)
                                       || (x.Package.Name == model.RelatedPackage && x.Package1.Name == model.Package)));
                if (alreadyExists)
                    return ResponseModel<UomModel>.GetError($"Uom for relation of {model.Package} and {model.RelatedPackage} already exists. Please enter another or update the existing.");

                var entity = _context.Uoms.Find(model.Id);
                entity = model.MapToEntity(entity); //UomMapper.MapToEntity(model, entity);
                var args = BaseEventArgs<UomModel>.Instance;
                // add
                var package = _context.Packages.FirstOrDefault(x => x.Name.ToLower() == model.Package.ToLower());
                if (package == null)
                {
                    package = new Package
                    {
                        Name = model.Package,
                        Use = true,
                    };
                    entity.Package = package;
                }
                else
                {
                    entity.PackageId = package.Id;
                }
                var relatedPackage = _context.Packages.FirstOrDefault(x => x.Name.ToLower() == model.RelatedPackage.ToLower());
                if (relatedPackage == null)
                {
                    relatedPackage = new Package
                    {
                        Name = model.RelatedPackage,
                        Use = true,
                    };
                    entity.Package1 = relatedPackage;
                }
                else
                {
                    entity.RelatedPackageId = relatedPackage.Id;
                }

                if (model.Id == 0)
                {
                    _context.Uoms.Add(entity);
                    args.Mode = Utility.UpdateMode.ADD;
                }
                else
                {
                    args.Mode = Utility.UpdateMode.EDIT;
                }

                _context.SaveChanges();
                args.Model = entity.MapToUomModel(); //UomMapper.MapToUomModel(entity);
                _listener.TriggerUomUpdateEvent(null, args);
                _listener.TriggerPackageUpdateEvent(null, BaseEventArgs<PackageModel>.Instance);
                return ResponseModel<UomModel>.GetSaveSuccess(args.Model);

            }

        }

        public List<UomModel> GetRootUomList()
        {
            using (var _context = DatabaseContext.Context)
            {
                var uoms = _context.Uoms.Where(x => x.ProductId == null).AsQueryable();
                return uoms.MapToUomModel();//UomMapper.MapToUomModel(uoms);
            }

        }



        public UomModel GetUom(int uomId)
        {
            using (var _context = DatabaseContext.Context)
            {
                var uom = _context.Uoms.Find(uomId);
                return uom.MapToUomModel();//UomMapper.MapToUomModel(uoms);
            }

        }

        public List<IdNamePair> GetUomListForCombo()
        {
            return GetRootUomList().Where(x => x.Use)
                .Select(x => new IdNamePair()
                {
                    Id = x.Id,
                    Name = x.Package,
                }).ToList();
        }


        #endregion

    }


}



/*public List<OptionModel> GetDistinctAttributes()
{
    var list = new List<OptionModel>();
    var attributesGroup = _context.Option
     .Where(x => x.DeletedAt == null)
     .GroupBy(x => x.Name);
    // attributeGroup is a dictionary of <string, Attribute>; {(Color, {obj, obj}), (CC, {obj, obj, obj})}
    foreach (var grp in attributesGroup)
    {
        var name = grp.Key;
        list.Add(new OptionModel
        {
            Name = name,
        });
        //foreach(var att in grp)
        //{
        //}
    }
    return list;
}*/

/* public List<AttributeModel> GetAttributeList()
 {
     var attributes = _context.Option
        .Where(x => x.DeletedAt == null)
        .OrderBy(x => x.Name)
        .Select(x => new AttributeModel()
        {
            Name = x.Name,
            Id = x.Id,
            Value = x.Value,
            CreatedAt = x.CreatedAt,
            UpdatedAt = x.UpdatedAt
        })
        .ToList();

     return attributes;
 }
 */
/* public List<OptionModel> GetOptionList()
 {
     var attributes = _context.Option
         .Where(x => x.DeletedAt == null)
         .OrderBy(x => x.Name)
         .GroupBy(x => x.Name);
     var list = new List<OptionModel>();
     foreach (var att in attributes)
     {
         list.Add(new OptionModel()
         {
             Name = att.Key,
             OptionValues = att.Select(x => new OptionValueModel()
             {
                 Id = x.Id,
                 OptionName = x.Name,
                 Value = x.Value
             }).ToList(),
         });
     }
     return list;
 }
 */

/*  public void DeleteAttribute(AttributeModel attributeModel)
  {
      var dbEntity = _context.Option.FirstOrDefault(x => x.Id == attributeModel.Id);

      if (dbEntity != null)
      {
          dbEntity.DeletedAt = DateTime.Now;
      }

      _context.SaveChanges();

  }*/

/* public List<AttributeModel> GetOptionList(int productId)
 {
     var attributes = _context.ProductOption
         .Where(x => x.ProductId == productId && x.DeletedAt == null)
         .Select(x => new AttributeModel
         {
             Id = x.OptionId,
             Name = x.Option.Name,
             Value = x.Option.Value

         }).ToList();
     return attributes;
 }
 */



/*  public bool AddOrUpdateAttribute(AttributeModel attributeModel)
{
    var dbEntity = _context.Option.FirstOrDefault(x => x.Id == attributeModel.Id);
    var list = GetAttributeList();
    if (dbEntity == null)
    {
        // add
        var attributeEntity = attributeModel.ToEntity();
        var existingData = _context.Option.FirstOrDefault(l => l.Name == attributeEntity.Name && attributeEntity.Value == l.Value);
        if (existingData == null)
        {
            // then add
            attributeEntity.CreatedAt = DateTime.Now;
            attributeEntity.UpdatedAt = DateTime.Now;

            _context.Option.Add(attributeEntity);
        }
        else
        {
            existingData.DeletedAt = null;
            existingData.UpdatedAt = DateTime.Now;
            //_context.SaveChanges();
            // don't add
            // return true;
            // return false;

        }
    }
    else
    {
        //edit 
        var existingData = _context.Option.FirstOrDefault(l => l.Name == attributeModel.Name && l.Value == attributeModel.Value && l.Id != attributeModel.Id);
        if (existingData == null)
        {
            // edit
            dbEntity.Name = attributeModel.Name;
            dbEntity.Value = attributeModel.Value;
            dbEntity.UpdatedAt = DateTime.Now;
            // if data is already in a db but in deleted state undelete it
            //dbEntity.DeletedAt = null;
        }
        else
        {
            return false;
        }
    }
    _context.SaveChanges();
    return true;
}*/


//public List<CategoryModel> GetSubCategoryList(int parentCategoryId)
//{

//}

/* public void AddProduct(ProductModelForSave product)
 {
     // save the attributes
     var productEntity = product.ToEntity();

     productEntity.ProductAttributes = new List<ProductAttribute>();
     productEntity.Variants = new List<Variant>();
     productEntity.Brands = new List<Brand>();
     // brands
     foreach (var b in product.Brands)
     {
         productEntity.Brands.Add(b.ToEntity());
     }
     // attributes
     foreach (var pa in product.ProductAttributes)
     {
         var paEntity = new ProductAttribute()
         {
             Attribute = pa.Attribute,
         };
         productEntity.ProductAttributes.Add(paEntity);
     }
     // variants
     foreach (var variant in product.Variants)
     {
         // variant
         var variantEntity = variant.ToEntity();
         variantEntity.AttributesJSON = JsonConvert.SerializeObject(variant.Attributes);
         productEntity.Variants.Add(variantEntity);
     }
     _context.Products.Add(productEntity);
     _context.SaveChanges();
     _listener.TriggerProductUpdateEvent(null, null);
 }*/


//public void SaveVariant(VariantModel variantModel)
//{
//    _context.Variant.Add(VariantMapper.MapToEntityForAdd(variantModel));
//    _context.SaveChanges();
//}

//public List<VariantModel> GetVariantList()
//{
//    var variants = _context.Variant.
//        Select(x => new VariantModel()
//        {
//            Id = x.Id,
//            LatestUnitCostPrice = x.LatestUnitCostPrice,
//            LatestUnitSellPrice = x.LatestUnitSellPrice,
//            MinStockCountForAlert = x.MinStockCountForAlert,
//            ProductId = x.ProductId,
//            QuantityInStock = x.QuantityInStock,
//            ShowStockAlerts = x.Alert,
//            SKU = x.SKU

//        }).ToList();
//    return variants;
//}

//public VariantModel GetVariantBySKU(string sku)
//{
//    var sss = _context.Variant.FirstOrDefault(x => x.SKU == sku);
//    if (sss == null)
//        return null;
//    return DTO.Core.Inventory.VariantMapper.MapToVariantModel(sss);
//}

//public VariantModel GetVariantById(string sku)
//{
//    var variant = _context.Variant.FirstOrDefault(x => x.SKU == sku);
//    if (variant == null)
//        return null;
//    return VariantMapper.MapToVariantModel(variant);
//}



//private void AssignVariantsForSave(Product productEntity, ProductModelForSave product, DateTime now)
//{
//    // remove the deleted variants
//    for (int v = 0; v < productEntity.Variants.Count; v++)
//    {
//        var variEnity = productEntity.Variants.ElementAt(v);
//        if (!product.Variants.Any(x => x.Id == variEnity.Id))
//        {
//            variEnity.DeletedAt = now;
//        }
//    }
//    // add/update
//    foreach (var vari in product.Variants)
//    {
//        Variant variantEntity;
//        if (vari.Id == 0)
//        {
//            // add
//            variantEntity = vari.ToEntity();
//            variantEntity.AttributesJSON = JsonConvert.SerializeObject(vari.Attributes);
//            productEntity.Variants.Add(variantEntity);
//            variantEntity.CreatedAt = now;
//            variantEntity.UpdatedAt = now;
//        }

//        else
//        {
//            variantEntity = productEntity.Variants.FirstOrDefault(x => x.Id == vari.Id);
//            variantEntity.Alert = vari.Alert;
//            variantEntity.MinStockCountForAlert = vari.AlertThreshold;
//            variantEntity.SKU = vari.SKU;
//            variantEntity.AttributesJSON = JsonConvert.SerializeObject(vari.Attributes);
//            variantEntity.UpdatedAt = now;
//        }
//    }
//}

//public void DeleteProduct(int id)
//{
//    var product = _context.Products.Find(id);
//    if (product != null)
//    {
//        product.DeletedAt = DateTime.Now;
//        _context.SaveChanges();
//        var args = new ProductEventArgs(ProductMapper.MapToProductModel(product));
//        _listener.TriggerProductUpdateEvent(null, args);
//    }
//}

//public void DeleteProduct(ProductModel produtModel)
//{
//    var dbEntity = _context.Products.FirstOrDefault(x => x.Id == produtModel.Id);
//    if (dbEntity != null)
//    {
//        dbEntity.DeletedAt = DateTime.Now;
//        _context.SaveChanges();
//    }
//}


/*
public void AddUpdateBrand(BrandModel brand)
{
    var dbEntity = _context.Brand.FirstOrDefault(x => x.Id == brand.Id);
    if (dbEntity == null)
    {
        var brandEntity = brand.ToEntity();
        brandEntity.CreatedAt = DateTime.Now;
        brandEntity.UpdatedAt = DateTime.Now;
        _context.Brand.Add(brandEntity);
    }
    else
    {
        dbEntity.Name = brand.Name;
        dbEntity.UpdatedAt = DateTime.Now; // brand.UpdatedAt;
    }
    _context.SaveChanges();
}

private void AssignBrandForSave(Product productEntity, ProductModel product, DateTime now)
{
    //dbEntity.Brands
    foreach (var brand in product.Brands)
    {
        // since brand is directly entered in textbox separated by comma, we don't have ids
        // so lets differentiate names

        Brand brandEntity = productEntity.Brands.FirstOrDefault(x => x.Name == brand.Name);
        if (brandEntity == null)
        {
            // then add new; else no need to update
            brandEntity = brand.ToEntity();
            brandEntity.CreatedAt = now;
            brandEntity.UpdatedAt = now;
            productEntity.Brands.Add(brandEntity);
        }
        //else 
        //{
        //    if (brandEntity.Id == 0)
        //    {
        //        productEntity.Brands.Remove(brandEntity);
        //        // add
        //    } 
        //}
    }
    // remove all other brands which don't have same updatedAt date
    foreach (var brandEntity in productEntity.Brands)
    {
        if (!product.Brands.Any(x => x.Name == brandEntity.Name))
        {
            // remove
            brandEntity.DeletedAt = now;
        }
    }
}

public List<BrandModel> GetBrandList()
{
    var brands = _context.Brand
        .Where(x => x.DeletedAt == null)
        .Select(x => new BrandModel()
        {
            Name = x.Name,
            Id = x.Id,
            CreatedAt = x.CreatedAt,
            UpdatedAt = x.UpdatedAt
        })
        .ToList();

    return brands;
}

public void DeleteBrand(BrandModel brandModel)
{
    var dbEntity = _context.Brand.FirstOrDefault(x => x.Id == brandModel.Id);
    if (dbEntity != null)
    {
        dbEntity.DeletedAt = DateTime.Now;
        _context.SaveChanges();
    }
}
*/
