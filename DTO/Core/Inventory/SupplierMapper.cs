using Infrastructure.Entities.Users;
using System.Collections.Generic;
using System.Linq;
using ViewModel.Core.Users;

namespace DTO.Core.Inventory
{
    public static class UserMapper
    {
        public static User MapToEntity(UserModel model, User entity)
        {
            if (entity == null)
                entity = new User() {};

            // supplier
           // entity.Id = model.Id;
            //entity.BasicInfoId = model.BasicInfoId;
            entity.SalesPerson = model.SalesPerson;
            // basci Info
            entity.Address = model.Address;
            entity.DOB = model.DOB;
            entity.Email = model.Email;
            entity.Fax = model.Fax;
           // entity.BasicInfo.Id = model.BasicInfoId;
            entity.IsCompany = model.IsCompany;
            entity.Name = model.Name;
            entity.Notes = model.Notes;
            entity.Phone = model.Phone;
            // don't assign the dates
            entity.Website = model.Website;
            entity.Use = model.Use;
            return entity;
        }

        public static List<UserModel> MapToSupplierModel(IQueryable<User> suppliers)
        {
            var list = new List<UserModel>();
            foreach (var supplier in suppliers)
            {
                list.Add(MapToSupplierModel(supplier));
            }
            return list;
        }

        public static UserModel MapToSupplierModel(User supplier)
        {
            return new UserModel()
            {
                Address = supplier.Address,
                CreatedAt = supplier.CreatedAt,
                Email = supplier.Email,
                Fax = supplier.Fax,
                Id = supplier.Id,
                IsCompany = supplier.IsCompany,
                Name = supplier.Name,
                Notes = supplier.Notes,
                Phone = supplier.Phone,
                DOB = supplier.DOB,
                SalesPerson = supplier.SalesPerson,
                UpdatedAt = supplier.UpdatedAt,
                Website = supplier.Website,
                Use = supplier.Use
            };
        }

    }
}
