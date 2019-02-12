using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Context;
using ViewModel.Core.Suppliers;

namespace Service.Core.Suppliers
{
    public class SupplierService : ISupplierService
    {
        private readonly DatabaseContext _context;
        public SupplierService( DatabaseContext context)
        {
            _context = context;
        }
        public void AddOrUpdateSupplier(SupplierModel supplierModel)
        {
            var dbEntity = _context.Supplier.FirstOrDefault(x => x.Id == supplierModel.Id);
            if(dbEntity == null)
            {
                var supplierEntitiy = supplierModel.ToEntity();
                _context.Supplier.Add(supplierEntitiy);
                
            }
            else
            {
                dbEntity.BasicInfo.Name = supplierModel.Name;
            }
            _context.SaveChanges();
        }

        public List<SupplierModel> GetSupplierList()
        {
            var supps = _context.Supplier
                .Where(x => x.BasicInfo.DeletedAt == null)
                .Select(x => new SupplierModel()
                {
                    Address = x.BasicInfo.Address,
                    CreatedAt = x.BasicInfo.CreatedAt,
                    ContactPersonName = x.ContactPersonName,
                    DeletedAt = x.BasicInfo.DeletedAt,
                    DOB = x.BasicInfo.DOB,
                    Email = x.BasicInfo.Email,
                    Fax = x.Fax,
                    Gender = x.BasicInfo.Gender,
                    IsCompany = x.BasicInfo.IsCompany,
                    IsMarried = x.BasicInfo.IsMarried,
                    Name = x.BasicInfo.Name,
                    Phone = x.BasicInfo.Phone,
                    PhoneSecond = x.PhoneSecond,
                    UpdatedAt = x.BasicInfo.UpdatedAt,
                    Website = x.Website,
                    Id = x.Id


                })
                .ToList();
            return supps;
        }

    }
}
