using Infrastructure.Context;
using Infrastructure.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Inventory;
//using System.Windows.
using System.Data.Entity;
using DTO.Core.Inventory;

namespace Service.Core.Inventory
{
    public class InventoryService : IInventoryService
    {

        private readonly DatabaseContext _context;

        public InventoryService(DatabaseContext context)
        {
            _context = context;
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
            if (dbEntity == null)
            {
                var categoryEntity = category.ToEntity();
                _context.Category.Add(categoryEntity);
            }
            else
            {
                dbEntity.Name = category.Name;
                dbEntity.UpdatedAt = DateTime.Now; // category.UpdatedAt;
            }
            _context.SaveChanges();
        }

        public void AddProduct(ProductModel product)
        {
            var productEntity = product.ToEntity();
            _context.Product.Add(productEntity);
            _context.SaveChanges();
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

        //public List<CategoryModel> GetSubCategoryList(int parentCategoryId)
        //{

        //}

        public List<ProductModel> GetProductList()
        {
            var cats = _context.Product
                .Where(x => x.DeletedAt == null)
                .Select(x => new ProductModel()
                {
                    Name = x.Name,
                    Id = x.Id,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt
                })
                .ToList();

            return cats;
        }

        public List<ProductModelForGridView> GetProductListForGridView()
        {
            var cats = _context.Product
                .Include(x => x.ProductAttributes)
                .Include(x => x.ProductAttributes.Select(y => y.Option))
                .Include(x => x.Brands)
                .Where(x => x.DeletedAt == null);
            var list = new List<ProductModelForGridView>();
            foreach (var x in cats)
            {
                list.Add(ProductMapper.MapToProductModelForGridView(x)
                //    new ProductModelForGridView
                //{
                //    Name = x.Name,
                //    Id = x.Id,
                //    CreatedAt = GetDateShortString(x.CreatedAt),
                //    UpdatedAt = GetDateShortString(x.UpdatedAt),
                //    Brands = GetBrandListCommaSeparatedString(x.Brands.ToList()),
                //    OptionValues = GetOptionValuesCommaSeparatedString(x.ProductAttributes.ToList()),
                //    Category = x.Category.Name,
                //    MinStockCountForAlert = x.MinStockCountForAlert,
                //    QuantityInStocks = x.QuantityInStock,
                //    ShowStockAlerts = x.ShowStockAlerts
                //}
                    );
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

        public bool AddOrUpdateAttribute(AttributeModel attributeModel)
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
                /*
                else if(existingData.DeletedAt != null)
                {
                    dbEntity.DeletedAt = null;
                }*/
                else
                {
                    return false;
                }
            }
            _context.SaveChanges();
            return true;
        }

        public List<OptionModel> GetDistinctAttributes()
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
        }

        public List<AttributeModel> GetAttributeList()
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
        public List<OptionModel> GetOptionList()
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

        public void DeleteAttribute(AttributeModel attributeModel)
        {
            var dbEntity = _context.Option.FirstOrDefault(x => x.Id == attributeModel.Id);

            if (dbEntity != null)
            {
                dbEntity.DeletedAt = DateTime.Now;
            }

            _context.SaveChanges();

        }

        public List<AttributeModel> GetOptionList(int productId)
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
        public ProductModelForGridView GetProduct(int productId)
        {
            var product = _context.Product.Find(productId);
            if (product == null)
                return null;
            return ProductMapper.MapToProductModelForGridView(product);
        }

        public void SaveVariant(VariantModel variantModel)
        {
            _context.Variant.Add(VariantMapper.MapToEntityForAdd(variantModel));
            _context.SaveChanges();
        }

        public List<VariantModel> GetVariantList()
        {
            var variants = _context.Variant.
                Select(x => new VariantModel()
                {
                    Id = x.Id,
                    LatestUnitCostPrice = x.LatestUnitCostPrice,
                    LatestUnitSellPrice = x.LatestUnitSellPrice,
                    MinStockCountForAlert = x.MinStockCountForAlert,
                    ProductId = x.ProductId,
                    QuantityInStock = x.QuantityInStock,
                    ShowStockAlerts = x.ShowStockAlerts,
                    SKU = x.SKU

                }).ToList();
            return variants;
        }

        public VariantModel GetVariantBySKU(string sku)
        {
            var sss = _context.Variant.FirstOrDefault(x => x.SKU == sku);
            if (sss == null)
                return null;
            return DTO.Core.Inventory.VariantMapper.MapToVariatModel(sss);
        }


        public VariantModel GetVariantById(string sku)
        {
            var variant = _context.Variant.FirstOrDefault(x => x.SKU == sku);
            if (variant == null)
                return null;
            return VariantMapper.MapToVariantModel(variant);
        }


    }
}



