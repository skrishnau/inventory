using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Suppliers;

namespace Service.Core.Suppliers
{
    public interface ISupplierService
    {
        void AddOrUpdateSupplier(SupplierModel supplierModel);
        List<SupplierModel> GetSupplierList();
        SupplierModel GetSupplier(int supplierId);
        void DeleteSupplier(int supplierId);
    }
}
