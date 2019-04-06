using Infrastructure.Entities.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Suppliers;

namespace DTO.Core.Inventory
{
    public static class SupplierMapper
    {
        public static Supplier MapToEntity(SupplierModel model, Supplier entity)
        {
            if (entity == null)
                entity = new Supplier() { BasicInfo = new Infrastructure.Entities.Users.BasicInfo() };

            // supplier
           // entity.Id = model.Id;
            //entity.BasicInfoId = model.BasicInfoId;
            entity.MyCustomerAccount = model.MyCustomerAccount;
            entity.SalesPerson = model.SalesPerson;
            // basci Info
            entity.BasicInfo.Address = model.Address;
            entity.BasicInfo.DOB = model.RegisteredAt;
            entity.BasicInfo.Email = model.Email;
            entity.BasicInfo.Fax = model.Fax;
           // entity.BasicInfo.Id = model.BasicInfoId;
            entity.BasicInfo.IsCompany = model.IsCompany;
            entity.BasicInfo.Name = model.Name;
            entity.BasicInfo.Notes = model.Notes;
            entity.BasicInfo.Phone = model.Phone;
            // don't assign the dates
            //entity.BasicInfo.CreatedAt = model.CreatedAt;
            //entity.BasicInfo.UpdatedAt = model.UpdatedAt;
            entity.BasicInfo.Website = model.Website;

            return entity;
        }

        public static List<SupplierModel> MapToSupplierModel(IQueryable<Supplier> suppliers)
        {
            var list = new List<SupplierModel>();
            foreach (var supplier in suppliers)
            {
                list.Add(MapToSupplierModel(supplier));
            }
            return list;
        }

        public static SupplierModel MapToSupplierModel(Supplier supplier)
        {
            return new SupplierModel()
            {
                Address = supplier.BasicInfo.Address,
                BasicInfoId = supplier.BasicInfoId,
                CreatedAt = supplier.BasicInfo.CreatedAt,
                Email = supplier.BasicInfo.Email,
                Fax = supplier.BasicInfo.Fax,
                Id = supplier.Id,
                IsCompany = supplier.BasicInfo.IsCompany,
                MyCustomerAccount = supplier.MyCustomerAccount,
                Name = supplier.BasicInfo.Name,
                Notes = supplier.BasicInfo.Notes,
                Phone = supplier.BasicInfo.Phone,
                RegisteredAt = supplier.BasicInfo.DOB,
                SalesPerson = supplier.SalesPerson,
                UpdatedAt = supplier.BasicInfo.UpdatedAt,
                Website = supplier.BasicInfo.Website
            };
        }

    }
}
