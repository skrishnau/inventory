using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Context;
using Infrastructure.Entities.Sales;
using ViewModel.Core.Sales;

namespace Service.Core.Sales
{
    public class SaleService : ISaleService
    {
        private readonly DatabaseContext _contex;

        public SaleService(DatabaseContext context)
        {
            _contex = context;
        }

        public void AddOrUpdateSale(SaleModel saleModel)
        {
            var dbEntity = _contex.Sales.FirstOrDefault(x => x.Id == saleModel.Id);
            if(dbEntity == null)
            {
                var saleEntity = saleModel.ToEntity();
                foreach(var si in saleModel.SaleItems)
                {
                    // check sku; if variant not found then return false; if variant found then create entity object

                }
                saleEntity.CreatedAt = DateTime.Now;
                _contex.Sales.Add(saleEntity);
            }
            else
            {
                dbEntity.Address = saleModel.Address;
                dbEntity.CustomerName = saleModel.CustomerName;
                dbEntity.Date = saleModel.Date;
                dbEntity.InvoiceNo = saleModel.BillNo;
                dbEntity.MobileNo = saleModel.MobileNo;
                dbEntity.Total = saleModel.TotalAmount;
                
            }
            _contex.SaveChanges();

        }

        public void AddOrUpdateSaleItem(SaleItemModel saleItemModel)
        {
            var dbEntity = _contex.SaleItems.FirstOrDefault(x => x.Id == saleItemModel.Id);
            if(dbEntity == null)
            {
                var saleItemEntity = saleItemModel.ToEntity();
                
                _contex.SaleItems.Add(saleItemEntity);
            }
            else
            {
                dbEntity.Quantity = saleItemModel.Quantity;
                dbEntity.Rate = saleItemModel.Rate;
                dbEntity.SKU = saleItemModel.SKU;
                dbEntity.TotalAmount = saleItemModel.Total;
            }
            _contex.SaveChanges();
        }

        public List<SaleItemModel> GetSaleItemList(int saleId)
        {
            var saleItems = _contex.SaleItems
                .Where(x =>x.SaleId == saleId)
               . Select(x => new SaleItemModel()
                {
                    Id = x.Id,
                    ItemDescription = x.ItemDescription,
                    Quantity = x.Quantity,
                    Rate = x.Rate,
                    SKU = x.SKU,
                    Total = x.TotalAmount

                })
                
                .ToList();
            return saleItems;
        }

        public List<SaleModel> GetSaleList()
        {
            var sales = _contex.Sales.
                Where(x => x.DeletedAt == null).
                Select(x => new SaleModel()
                {
                    BillNo = x.InvoiceNo,
                    Address = x.Address,
                    CustomerName = x.CustomerName,
                    Date = x.Date,
                    Id = x.Id,
                    MobileNo = x.MobileNo,
                    TotalAmount = x.Total,
                    VatNo = x.VatNo

                }).
                ToList();
            return sales;
        }
    }
}
