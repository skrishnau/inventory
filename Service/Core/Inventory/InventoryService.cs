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
                .Include(x=>x.ProductAttributes)
                .Include(x=>x.ProductAttributes.Select(y=>y.Option))
                .Include(x=>x.Brands)
                .Where(x => x.DeletedAt == null);
            var list = new List<ProductModelForGridView>();
            foreach (var x in cats)
            {
                list.Add(new ProductModelForGridView
                {
                    Name = x.Name,
                    Id = x.Id,
                    CreatedAt = GetDateShortString(x.CreatedAt),
                    UpdatedAt = GetDateShortString(x.UpdatedAt),
                    Brands = GetBrandListCommaSeparatedString(x.Brands.ToList()),
                    OptionValues = GetOptionValuesCommaSeparatedString(x.ProductAttributes.ToList()),
                    Category = x.Category.Name,
                    MinStockCountForAlert = x.MinStockCountForAlert,
                    QuantityInStocks = x.QuantityInStock,
                    ShowStockAlerts = x.ShowStockAlerts
                });
            }
            return list;
        }

        private string GetOptionValuesCommaSeparatedString(List<Infrastructure.Entities.Inventory.ProductOption> list)
        {
            var builder = new StringBuilder();
            
            foreach(var option in list.OrderBy(x=>x.Option.Name).GroupBy(x=>x.Option.Name))
            {
                builder.Append(option.Key);
                builder.Append(": ");

                for(var v=0; v<option.Count();v++)
                {
                    builder.Append(option.ElementAt(v).Option.Value);
                    if (v <= option.Count() - 2)
                        builder.Append(", ");
                }
                builder.Append(" ; ");
            }

            return builder.ToString();
        }

        private string GetDateShortString(DateTime date)
        {
            return date.ToShortDateString();
        }

        public string GetBrandListCommaSeparatedString(List<Brand> brands)
        {
            var builder = new StringBuilder();
            for (var b = 0; b < brands.Count; b++)
            {

                builder.Append(brands[b].Name);
                if (b < brands.Count - 2)
                    builder.Append(", ");
                if (b == brands.Count - 2)
                    builder.Append(" , ");// &

            }
            return builder.ToString();
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
            var dbEntity = _context.Attribute.FirstOrDefault(x => x.Id == attributeModel.Id);
            var list = GetAttributeList();
            if (dbEntity == null)
            {
                // add
                var attributeEntity = attributeModel.ToEntity();
                var existingData = _context.Attribute.FirstOrDefault(l => l.Name == attributeEntity.Name && attributeEntity.Value == l.Value);
                if (existingData == null)
                {
                    // then add
                    attributeEntity.CreatedAt = DateTime.Now;
                    attributeEntity.UpdatedAt = DateTime.Now;

                    _context.Attribute.Add(attributeEntity);
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
                var existingData = _context.Attribute.FirstOrDefault(l => l.Name == attributeModel.Name && l.Value == attributeModel.Value && l.Id != attributeModel.Id );
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

        public List<AttributeModel> GetDistinctAttributes()
        {
            var list = new List<AttributeModel>();
            var attributesGroup = _context.Attribute
             .Where(x => x.DeletedAt == null)
             .GroupBy(x => x.Name);
            // attributeGroup is a dictionary of <string, Attribute>; {(Color, {obj, obj}), (CC, {obj, obj, obj})}
            foreach (var grp in attributesGroup)
            {
                var name = grp.Key;
                list.Add(new AttributeModel
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
            var attributes = _context.Attribute
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
            var attributes = _context.Attribute
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
            var dbEntity = _context.Attribute.FirstOrDefault(x => x.Id == attributeModel.Id);
            
            if (dbEntity != null)
            {
                dbEntity.DeletedAt = DateTime.Now;
            }
            
            _context.SaveChanges();
            
        }

        public List<AttributeModel> GetAttributeList(int productId)
        {
            var attributes = _context.ProductAttribute.Where(x => x.ProductId == productId && x.DeletedAt == null).Select(x =>
                new AttributeModel
                {
                    Id = x.OptionId,
                    Name = x.Option.Name,
                    Value = x.Option.Value
                    
                }).ToList();
            return attributes;
        }
    }
    }



