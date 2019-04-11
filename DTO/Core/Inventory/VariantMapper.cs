using Infrastructure.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Inventory;

namespace DTO.Core.Inventory
{
    public static class VariantMapper
    {
        //public static Variant MapToEntityForAdd(VariantModel model)
        //{
        //    return new Variant
        //    {
        //        Id = model.Id,
        //        //LatestUnitCostPrice = model.LatestUnitCostPrice,
        //        MinStockCountForAlert = model.MinStockCountForAlert,
        //        ProductId = model.ProductId,
        //        Alert = model.ShowStockAlerts,
        //        SKU = model.SKU,
        //        //VariantAttributes = model.OptionIds.Select(x=> new VariantAttribute
        //        //{
        //        //    OptionId = x,
        //        //}).ToList(),
                
        //    };
        //}

        //public static VariantModel MapToVariantModel(Variant variant)
        //{
        //    return new VariantModel()
        //    {
        //        Id = variant.Id,
        //        LatestUnitCostPrice = variant.LatestUnitCostPrice,
        //        LatestUnitSellPrice = variant.LatestUnitSellPrice,
        //        MinStockCountForAlert = variant.MinStockCountForAlert,
        //        //OptionIds = variant.VariantAttributes.Select(x=>x.OptionId).ToList(),
        //        ProductId = variant.ProductId,
        //        QuantityInStock = variant.QuantityInStock,
        //        ShowStockAlerts = variant.Alert,
        //        SKU = variant.SKU,
                
        //    };
        //}
    }
}
