using Infrastructure.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Inventory
{
    public class ProductModelForSave
    {

        public ProductModelForSave()
        {
            Category = new CategoryModel();
            Brands = new List<BrandModel>();
            ProductAttributes = new List<ProductAttributeModel>();
            Variants = new List<ProductVariantModel>();

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        // public int BrandId { get; set; }

        //public decimal QuantityInStock { get; set; }
        //public decimal LatestUnitCostPrice { get; set; }
        //public decimal LatestUnitSellPrice { get; set; }

        public bool ShowStockAlerts { get; set; }

        public int MinStockCountForAlert { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual CategoryModel Category { get; set; }
        public virtual List<BrandModel> Brands { get; set; }

        //public virtual List<AttributeModel> OptionValues { get; set; }

        // used for dynamic attributes adding and for adding SKU directly in Product Create
        public virtual List<ProductAttributeModel> ProductAttributes { get; set; }
        public List<ProductVariantModel> Variants { get; set; }

        public Product ToEntity()
        {
            var brandEntities = new List<Brand>();
            foreach (var b in Brands)
            {
                brandEntities.Add(b.ToEntity());
            }

            //var optionEntities = new List<Infrastructure.Entities.Inventory.ProductAttribute>();
            //foreach (var val in ProductAttributes)
            //{
            //    optionEntities.Add(val.ToEntity());
            //}


            return new Product()
            {
                Name = Name,
                CategoryId = CategoryId,
                Id = Id,
                AlertThreshold = MinStockCountForAlert,
                Alert = ShowStockAlerts,
                CreatedAt = CreatedAt,
                UpdatedAt = UpdatedAt,
                Brands = brandEntities,
               // ProductAttributes = optionEntities,

            };
        }
    }


    public class ProductVariantModel
    {
        public ProductVariantModel()
        {
            Attributes = new Dictionary<string, string>();
        }
        public int Id { get; set; }
        public string SKU { get; set; }

        public bool Alert { get; set; }
        public int AlertThreshold { get; set; }

        public Dictionary<string, string> Attributes { get; set; }

    }

    public class ProductModelForGridView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brands { get; set; }
        public string OptionValues { get; set; }
        public bool ShowStockAlerts { get; set; }
        public decimal QuantityInStocks { get; set; }
        public int MinStockCountForAlert { get; set; }

        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public int VariantCount { get; set; }

    }
}
