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

namespace Service.Core.Inventory
{
    public class InventoryService : IInventoryService
    {

        private readonly DatabaseContext _context;
        private readonly IDatabaseChangeListener _listener;

        public InventoryService(DatabaseContext context, IDatabaseChangeListener listener)
        {
            _context = context;
            _listener = listener;
        }

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

        public void AddUpdateCategory(CategoryModel category)
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

        public void AddUpdateProduct(ProductModel model)
        {
            var now = DateTime.Now;

            var entity = _context.Product
                .Include(x => x.ProductAttributes)
                .FirstOrDefault(x => x.Id == model.Id);

            ProductEventArgs eventArgs = ProductEventArgs.Instance; ;
            entity = ProductMapper.MapToEntity(model, entity);

            if (entity.Id == 0)
            {
                // add
                entity.CreatedAt = DateTime.Now;
                entity.UpdatedAt = DateTime.Now;
                entity.ProductAttributes = new List<ProductAttribute>();
                //entity.Variants = new List<Variant>();
                entity.Brands = new List<Brand>();
                _context.Product.Add(entity);
                eventArgs.Mode = Utility.UpdateMode.ADD;
            }
            else
            {
                // udpate
                entity.UpdatedAt = DateTime.Now;
                eventArgs.Mode = Utility.UpdateMode.EDIT;
            }
            AssignBrandForSave(entity, model, now);
            AssignProductAttributesForSave(entity, model, now);
            //  AssignVariantsForSave(entity, model, now);

            _context.SaveChanges();

            eventArgs.ProductModel = ProductMapper.MapToProductModel(entity);
            _listener.TriggerProductUpdateEvent(null, eventArgs);
        }

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

        public List<CategoryModel> GetCategoryList(int? parentCateogryId)
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

        private IQueryable<Product> GetProductEntityList()
        {
            return _context.Product
                .Where(x => x.DeletedAt == null);
        }

        public List<IdNamePair> GetProductIdNameList()
        {
            var products = GetProductEntityList()
                .Select(x => new IdNamePair()
                {
                    Id = x.Id,
                    Name = x.Name + " (" + x.SKU + ")",
                })
                .ToList();
            return products;
        }

        public List<ProductModel> GetProductListForGridView()
        {
            var products = _context.Product
                .Include(x => x.ProductAttributes)
                //.Include(x => x.ProductAttributes.Select(y => y.Option))
                .Include(x => x.Brands)
                .Where(x => x.DeletedAt == null);
            var list = new List<ProductModel>();
            foreach (var x in products)
            {
                list.Add(ProductMapper.MapToProductModel(x));
            }
            return list;
        }

        public void DeleteCategory(CategoryModel categoryModel)
        {
            var dbEntity = _context.Category.FirstOrDefault(x => x.Id == categoryModel.Id);
            if (dbEntity != null)
            {
                dbEntity.DeletedAt = DateTime.Now;
                _context.SaveChanges();
            }
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

        public void DeleteProduct(ProductModel produtModel)
        {
            var dbEntity = _context.Product.FirstOrDefault(x => x.Id == produtModel.Id);
            if (dbEntity != null)
            {
                dbEntity.DeletedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public CategoryModel GetCategory(string name)
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

        public ProductModel GetProduct(int productId)
        {
            var product = _context.Product.Find(productId);
            if (product == null)
                return null;
            return ProductMapper.MapToProductModel(product);
        }

        public ProductModel GetProductForEdit(int productId)
        {
            var product = _context.Product
                //.Include(x => x.Variants)
                .FirstOrDefault(x => x.Id == productId);
            if (product == null)
                return null;
            return ProductMapper.MapToProductModel(product);
        }


        public void DeleteProduct(int id)
        {
            var product = _context.Product.Find(id);
            if (product != null)
            {
                product.DeletedAt = DateTime.Now;
                _context.SaveChanges();
                var args = new ProductEventArgs(ProductMapper.MapToProductModel(product));
                _listener.TriggerProductUpdateEvent(null, args);
            }
        }


        #region Settings

        public void SaveUom(UomModel model)
        {
            var entity = _context.Uom.Find(model.Id);
            entity = UomMapper.MapToEntity(model, entity);
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
            args.Model = UomMapper.MapToUomModel(entity);
            _listener.TriggerUomUpdateEvent(null, args);
        }

        public List<UomModel> GetUomList()
        {
            var uoms = _context.Uom.AsQueryable();
            return UomMapper.MapToUomModel(uoms);
        }

        public string SavePackage(PackageModel package)
        {
            var msg = "";
            var args = BaseEventArgs<PackageModel>.Instance;
            var duplicate = _context.Package.FirstOrDefault(x => x.Id != package.Id && x.Name == package.Name);
            if (duplicate != null)
            {
                return "Same 'Package' Name already exists";
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
            return msg;
        }

        public List<PackageModel> GetPackageList()
        {
            var query = _context.Package.AsQueryable();
            return PackageMapper.MapToModel(query);
        }

        public List<AdjustmentCodeModel> GetAdjustmentCodeList()
        {
            var query = _context.AdjustmentCode.AsQueryable();
            return AdjustmentCodeMapper.MapToModel(query);
        }

        public string SaveAdjustmentCode(AdjustmentCodeModel model)
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
            entity = AdjustmentCodeMapper.MapToEntity(model, entity);
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
            args.Model = AdjustmentCodeMapper.MapToModel(entity);
            _listener.TriggerAdjustmentCodeUpdateEvent(null, args);
            return msg;
        }

        public List<UomModel> GetUomListUsableOnly()
        {
            return GetUomList().Where(x => x.Use).ToList();
        }

        public List<PackageModel> GetPackageListUsableOnly()
        {
            return GetPackageList().Where(x => x.Use).ToList();
        }

        public List<AdjustmentCodeModel> GetAdjustmentCodeListUsableOnly()
        {
            return GetAdjustmentCodeList().Where(x => x.Use).ToList();
        }

        public ProductModel GetProductBySKU(string sku)
        {
            var entity = _context.Product.FirstOrDefault(x => x.SKU == sku);
            return entity == null ? null : ProductMapper.MapToProductModel(entity);
        }

        public List<WarehouseProductModel> GetWarehouseProductList(int warehouseId, int productId)
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

        public List<InventoryUnitModel> GetInventoryUnitList()
        {
            var query = _context.InventoryUnit
                .Include(x => x.Product)
                .Include(x => x.Package)
                .Include(x => x.Supplier)
                .Include(x => x.Uom)
                .Include(x => x.Warehouse)
                .AsQueryable();
            return InventoryUnitMapper.MapToModel(query);
        }

        public void MergeInventoryUnits(List<InventoryUnitModel> list)
        {
            foreach (var invUnitGroup in list.GroupBy(x => x.ProductId))
            {
                var product = _context.Product.Find(invUnitGroup.Key);
                if (product != null)
                {
                    if (invUnitGroup.Count() >= 2)
                    {
                        // means there are 2 or more items for this product
                        var unitQuantity = 0M;
                        var packageQuantity = 0M;
                        InventoryUnit editingRecord = null;
                        for (var i = 0; i < invUnitGroup.Count(); i++)
                        {
                            var dbEntity = _context.InventoryUnit.Find(invUnitGroup.ElementAt(i).Id);
                            if (dbEntity != null)
                            {
                                unitQuantity += dbEntity.UnitQuantity;
                                packageQuantity += dbEntity.PackageQuantity;
                            }
                            if (i < invUnitGroup.Count() - 1)
                            {
                                // remove
                                _context.InventoryUnit.Remove(dbEntity);
                                invUnitGroup.ElementAt(i).UpdateAction = UpdateMode.DELETE.ToString();
                            }
                            else
                            {
                                // get the last entity ; 
                                // TODO:: assign the value from multiple entities to the newly created 
                                editingRecord = dbEntity;
                                invUnitGroup.ElementAt(i).UpdateAction = UpdateMode.EDIT.ToString();
                            }
                        }
                        editingRecord.UnitQuantity = unitQuantity;
                        //var unitsInPackage = product.UnitsInPackage == 0 ? 1 : product.UnitsInPackage;
                        //editingRecord.PackageQuantity = Math.Ceiling(unitQuantity / unitsInPackage) + (unitQuantity % unitsInPackage == 0 ? 0 : 1);
                        editingRecord.PackageQuantity = packageQuantity;
                    }
                }
            }
            _context.SaveChanges();
            var args = new BaseEventArgs<List<InventoryUnitModel>>(list, UpdateMode.EDIT);
            _listener.TriggerInventoryUnitUpdateEvent(null, args);
        }

        public void MoveInventoryUnits(int warehouseId, List<InventoryUnitModel> list)
        {
            var warehouseEntity = _context.Warehouse.Find(warehouseId);
            if (warehouseEntity != null)
            {
                foreach (var iuModel in list)
                {
                    // first find
                    var dbEntity = _context.InventoryUnit.Find(iuModel.Id);
                    if (dbEntity != null)
                    {
                        dbEntity.WarehouseId = warehouseId;
                    }
                }
            }
            _context.SaveChanges();
            var args = new BaseEventArgs<List<InventoryUnitModel>>(list, UpdateMode.EDIT);
            _listener.TriggerInventoryUnitUpdateEvent(null, args);
        }


        public void SplitInventoryUnit(List<decimal> quantitySplitList, InventoryUnitModel model)
        {
            //find
            if (quantitySplitList.Count > 1)
            {
                var entity = _context.InventoryUnit.Find(model.Id);
                if (entity != null)
                {
                    // split 
                    if (entity.UnitQuantity == quantitySplitList.Sum())
                    {
                        var updatedEntryList = new List<InventoryUnit>();
                        for (var q = 0; q < quantitySplitList.Count; q++)
                        {
                            var quantity = quantitySplitList[q];
                            if (quantity > 0)
                            {
                                var unitsInPackage = entity.Product.UnitsInPackage == 0 ? 1 : entity.Product.UnitsInPackage;
                                if (q == 0)
                                {
                                    // update the first entry 
                                    entity.UnitQuantity = quantity;
                                    entity.PackageQuantity = Math.Ceiling(quantity / unitsInPackage) + (quantity % unitsInPackage == 0 ? 0 : 1);
                                }
                                else
                                {
                                    // create new entry for the rest of the splits
                                    var newEntity = InventoryUnitMapper.CloneEntity(entity);
                                    newEntity.Id = 0;
                                    newEntity.UnitQuantity = quantity;
                                    newEntity.PackageQuantity = Math.Ceiling(quantity / unitsInPackage) + (quantity % unitsInPackage == 0 ? 0 : 1);
                                    _context.InventoryUnit.Add(newEntity);
                                }
                            }
                        }

                        _context.SaveChanges();
                        var list = InventoryUnitMapper.MapToModel(updatedEntryList);
                        var args = new BaseEventArgs<List<InventoryUnitModel>>(list, UpdateMode.EDIT);
                        _listener.TriggerInventoryUnitUpdateEvent(null, args);
                    }


                }
            }

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