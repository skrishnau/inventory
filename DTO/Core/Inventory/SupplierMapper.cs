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
            entity.UserType = model.UserType;
                
            return entity;
        }

        public static List<UserModel> MapToUserModel(IQueryable<User> suppliers)
        {
            var list = new List<UserModel>();
            foreach (var supplier in suppliers)
            {
                list.Add(MapToSupplierModel(supplier));
            }
            return list;
        }

        public static UserModel MapToSupplierModel(User x)
        {
            return new UserModel()
            {
                Address = x.Address,
                CreatedAt = x.CreatedAt,
                Email = x.Email,
                Fax = x.Fax,
                Id = x.Id,
                IsCompany = x.IsCompany,
                Name = x.Name,
                Notes = x.Notes,
                Phone = x.Phone,
                DOB = x.DOB,
                SalesPerson = x.SalesPerson,
                UpdatedAt = x.UpdatedAt,
                Website = x.Website,
                Use = x.Use,

                CanLogin = x.CanLogin,
                Password = x.Password,
                Username = x.Username,
                UserType = x.UserType,
                
                IsMarried = x.IsMarried,
                Gender = x.Gender,
            };
        }

    }
}
