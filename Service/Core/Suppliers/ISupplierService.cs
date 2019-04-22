using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Common;
using ViewModel.Core.Suppliers;

namespace Service.Core.Suppliers
{
    public interface ISupplierService
    {
        void AddOrUpdateSupplier(SupplierModel supplierModel);

        SupplierModel GetSupplier(int supplierId);

        List<SupplierModel> GetSupplierList();

        List<IdNamePair> GetSupplierListForCombo();
        // void DeleteSupplier(int supplierId);
    }
}
