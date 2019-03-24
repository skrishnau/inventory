using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Sales;

namespace Service.Core.Sales
{
    public interface ISaleService
    {
        void AddOrUpdateSale(SaleModel saleModel);

        void AddOrUpdateSaleItem(SaleItemModel saleItemModel);

        List<SaleModel> GetSaleList();

        List<SaleItemModel> GetSaleItemList(int saleId);

    }
}
