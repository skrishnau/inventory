using Infrastructure.Context;
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
            using (var _context = new DatabaseContext())
            {
                var entity = _context.Warehouse.FirstOrDefault(x => x.Id == model.Id);
                BaseEventArgs<WarehouseModel> args = BaseEventArgs<WarehouseModel>.Instance;
                entity = model.MapToEntity(entity);

                if (entity.Id == 0)
                {
                    entity.CreatedAt = DateTime.Now;
                    entity.UpdatedAt = DateTime.Now;
                    _context.Warehouse.Add(entity);
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
        //    var warehouse = _context.Warehouse.Find(id);
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
            using (var _context = new DatabaseContext())
            {
                var warehouse = _context.Warehouse.Find(warehouseId);
                if (warehouse != null)
                {
                    return warehouse.MapToModel();// WarehouseMapper.MapToModel(warehouse);
                }
                return null;
            }

        }


        public List<WarehouseModel> GetWarehouseList()
        {
            using (var _context = new DatabaseContext())
            {
                //var warehouses = 
                return _context.Warehouse
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
            using (var _context = new DatabaseContext())
            {
                return _context.Warehouse
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
            using (var _context = new DatabaseContext())
            {
                return _context.Package
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

      

        private IQueryable<Product> GetProductEntityList()
        {
            using (var _context = new DatabaseContext())
            {
                return _context.Product.AsQueryable();
                //.Where(x => x.DeletedAt == null);
            }

        }



       
       


        //public void DeleteProduct(int id)
        //{
        //    var product = _context.Product.Find(id);
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
        //    var dbEntity = _context.Product.FirstOrDefault(x => x.Id == produtModel.Id);
        //    if (dbEntity != null)
        //    {
        //        dbEntity.DeletedAt = DateTime.Now;
        //        _context.SaveChanges();
        //    }
        //}


        #region Settings

        public void SaveUom(UomModel model)
        {
            using (var _context = new DatabaseContext())
            {
                var entity = _context.Uom.Find(model.Id);
                entity = model.MapToEntity(entity); //UomMapper.MapToEntity(model, entity);
                var args = BaseEventArgs<UomModel>.Instance;
                // add
                if (model.Name == model.BaseUom)
                {
                    // root uom
                    entity.BaseUomId = null;// entity;
                }
                else
                {
                    // find the unit 
                    var baseUomEntity = _context.Uom.FirstOrDefault(x => x.Name == model.BaseUom);
                    if (baseUomEntity != null)
                    {
                        entity.BaseUomId = baseUomEntity.Id;
                        entity.BaseUom = null;
                    }
                }

                if (model.Id == 0)
                {
                    _context.Uom.Add(entity);
                    args.Mode = Utility.UpdateMode.ADD;
                }
                else
                {
                    args.Mode = Utility.UpdateMode.EDIT;
                }

                _context.SaveChanges();
                args.Model = entity.MapToUomModel(); //UomMapper.MapToUomModel(entity);
                _listener.TriggerUomUpdateEvent(null, args);
            }

        }

        public List<UomModel> GetUomList()
        {
            using (var _context = new DatabaseContext())
            {
                var uoms = _context.Uom.AsQueryable();
                return uoms.MapToUomModel();//UomMapper.MapToUomModel(uoms);
            }

        }

        public ResponseModel<PackageModel> SavePackage(PackageModel package)
        {
            using (var _context = new DatabaseContext())
            {
                var response = new ResponseModel<PackageModel>();
                var msg = "";
                var args = BaseEventArgs<PackageModel>.Instance;
                var duplicate = _context.Package.FirstOrDefault(x => x.Id != package.Id && x.Name == package.Name);
                if (duplicate != null)
                {
                    response.Message = "Same 'Package' Name already exists";
                    response.Success = false;
                    return response;
                }

                // get the package
                var entity = _context.Package.FirstOrDefault(x => x.Id == package.Id);
                entity = PackageMapper.MapToEntity(package, entity);
                if (package.Id == 0)
                {
                    // add
                    _context.Package.Add(entity);
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
            using (var _context = new DatabaseContext())
            {
                var query = _context.Package.AsQueryable();
                return PackageMapper.MapToModel(query);
            }
        }

        public PackageModel GetPackage(int packageId)
        {
            using (var _context = new DatabaseContext())
            {
                return _context.Package.Find(packageId).MapToModel();
            }
        }

        public List<AdjustmentCodeModel> GetAdjustmentCodeList()
        {
            using (var _context = new DatabaseContext())
            {
                var query = _context.AdjustmentCode.AsEnumerable();
                if (!query.Any())
                {
                    // add system defined adj codes
                    SeedAdjustmentCodes(_context);
                }
                return query.MapToModel();// AdjustmentCodeMapper.MapToModel(query);

            }
        }

        private void SeedAdjustmentCodes(DatabaseContext _context)
        {
            //
            // Positive
            //
            _context.AdjustmentCode.Add(new AdjustmentCode()
            {
                AffectsDemand = false,
                IsSystem = true,
                Name = "Assembled",
                Type = AdjustmentTypeEnum.Positive.ToString(),
                Use = true,
            });
            _context.AdjustmentCode.Add(new AdjustmentCode()
            {
                AffectsDemand = false,
                IsSystem = true,
                Name = "Imported",
                Type = AdjustmentTypeEnum.Positive.ToString(),
                Use = true,
            });
            _context.AdjustmentCode.Add(new AdjustmentCode()
            {
                AffectsDemand = false,
                IsSystem = true,
                Name = "PO receive",
                Type = AdjustmentTypeEnum.Positive.ToString(),
                Use = true,
            });
            _context.AdjustmentCode.Add(new AdjustmentCode()
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
            _context.AdjustmentCode.Add(new AdjustmentCode()
            {
                AffectsDemand = false,
                IsSystem = true,
                Name = "Damaged/Broken",
                Type = AdjustmentTypeEnum.Negative.ToString(),
                Use = true,
            });
            _context.AdjustmentCode.Add(new AdjustmentCode()
            {
                AffectsDemand = false,
                IsSystem = true,
                Name = "Direct Issue",
                Type = AdjustmentTypeEnum.Negative.ToString(),
                Use = true,
            });
            _context.AdjustmentCode.Add(new AdjustmentCode()
            {
                AffectsDemand = false,
                IsSystem = true,
                Name = "Disassembled",
                Type = AdjustmentTypeEnum.Negative.ToString(),
                Use = true,
            });
            _context.AdjustmentCode.Add(new AdjustmentCode()
            {
                AffectsDemand = false,
                IsSystem = true,
                Name = "Used in Repairs",
                Type = AdjustmentTypeEnum.Negative.ToString(),
                Use = true,
            });
            _context.AdjustmentCode.Add(new AdjustmentCode()
            {
                AffectsDemand = false,
                IsSystem = true,
                Name = "SO issue",
                Type = AdjustmentTypeEnum.Negative.ToString(),
                Use = true,
            });

            _context.SaveChanges();
        }

        public string SaveAdjustmentCode(AdjustmentCodeModel model)
        {
            using (var _context = new DatabaseContext())
            {
                var msg = "";
                var args = BaseEventArgs<AdjustmentCodeModel>.Instance;
                var duplicate = _context.AdjustmentCode.FirstOrDefault(x => x.Id != model.Id && x.Name == model.Name);
                if (duplicate != null)
                {
                    return "Same 'Adjustment Code' already exists";
                }

                // get the package
                var entity = _context.AdjustmentCode.FirstOrDefault(x => x.Id == model.Id);
                entity = model.MapToEntity(entity);//AdjustmentCodeMapper.MapToEntity
                if (model.Id == 0)
                {
                    // add
                    _context.AdjustmentCode.Add(entity);
                    args.Mode = Utility.UpdateMode.ADD;
                }
                else
                {
                    args.Mode = Utility.UpdateMode.EDIT;
                }
                _context.SaveChanges();
                args.Model = entity.MapToModel();//AdjustmentCodeMapper.MapToModel(entity)
                _listener.TriggerAdjustmentCodeUpdateEvent(null, args);
                return msg;
            }

        }

        public List<IdNamePair> GetUomListForCombo()
        {
            return GetUomList().Where(x => x.Use)
                .Select(x => new IdNamePair()
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList();
        }

        public List<AdjustmentCodeModel> GetAdjustmentCodeListUsableOnly()
        {
            return GetAdjustmentCodeList().Where(x => x.Use).ToList();
        }

       

        public List<WarehouseProductModel> GetWarehouseProductList(int warehouseId, int productId)
        {
            using (var _context = new DatabaseContext())
            {
                var wpList = _context.WarehouseProduct
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

        public List<IdNamePair> GetAdjustmentCodeListForCombo()
        {
            using (var _context = new DatabaseContext())
            {
                return _context.AdjustmentCode
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
            using (var _context = new DatabaseContext())
            {
                var positive = AdjustmentType.Positive.ToString();
                return _context.AdjustmentCode
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
            using (var _context = new DatabaseContext())
            {
                var negative = AdjustmentType.Negative.ToString();
                return _context.AdjustmentCode
                   .Where(x => x.Use && x.Type == negative)
                   .Select(x => new IdNamePair()
                   {
                       Id = x.Id,
                       Name = x.Name
                   })
                   .ToList();
            }

        }

        public List<IdNamePair> GetSupplierListForCombo()
        {
            using (var _context = new DatabaseContext())
            {
                return _context.User
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
            using (var _context = new DatabaseContext())
            {
                var totalOrders = _context.Order.Where(x => x.IsCompleted && x.CompletedDate >= start && x.CompletedDate <= end)
                    .GroupBy(x=>x.OrderType)
                    .Select(x => new TransactionSummaryModel
                    {
                        Key = x.Key,
                        Value = x.Count()
                    })
                    .ToList();
                list.AddRange(totalOrders);
            }
            return list;
        }


        public List<TransactionSummaryModel> GetInventorySummary()
        {
            var list = new List<TransactionSummaryModel>();
            using (var _context = new DatabaseContext())
            {
                var totalProducts = _context.Product.Count();
                list.Add(new TransactionSummaryModel { Key = TransactionSummaryKeys.Product.ToString(), Value = totalProducts });
                var totalInventoryQty = _context.Product.Select(x => (decimal?)x.InStockQuantity).Sum()??0;
                list.Add(new TransactionSummaryModel { Key = TransactionSummaryKeys.InventoryQuantity.ToString(), Value = totalInventoryQty });
                var customer = UserTypeEnum.Customer.ToString();
                var totalCustomers = _context.User.Where(x => x.UserType == customer).Count();
                list.Add(new TransactionSummaryModel { Key = TransactionSummaryKeys.Customer.ToString(), Value = totalCustomers });
            }
            return list;
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
     _context.Product.Add(productEntity);
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