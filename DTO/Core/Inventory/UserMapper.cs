using Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;
using ViewModel.Core;
using ViewModel.Enums;
using ViewModel.Utility;

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
            entity.Company = model.Company;
            return entity;
        }

        public static List<UserModel> MapToUserModel(this IQueryable<User> users, DatabaseContext _context)
        {
            var list = new List<UserModel>();
            foreach (var user in users)
            {
                var transactions = user.Transactions.Where(x => !x.IsVoid).ToList();
                decimal debit = 0, credit = 0;
                debit = transactions.Sum(x => x.Debit);
                credit = transactions.Sum(x => x.Credit);

                var manufacturedAmount = 0M;
                if (user.UserType.Contains(UserTypeEnum.Vendor.ToString()) || user.UserType.Contains(UserTypeEnum.Employee.ToString()))
                {
                    manufacturedAmount = _context.UserManufactures
                        .Where(x => x.ManufactureDepartmentUser.UserId == user.Id && x.InOut == false)
                        .Sum(x => x.BuildRate == null ? 0 : x.BuildRate * x.Quantity) ?? 0;
                }
                else
                {
                    manufacturedAmount = 0;
                }
                //if(user.UserType == UserTypeEnum.Customer.ToString())
                //{
                //    debit = transactions.Sum(x => x.Debit);
                //    credit = transactions.Sum(x => x.Credit);
                //}
                //else if(user.UserType == UserTypeEnum.Supplier.ToString())
                //{
                //    debit = transactions.Sum(x => x.Debit); // incomming stock amount
                //    credit = transactions.Sum(x => x.Credit); // outgoing paid amount
                //}
                list.Add(MapToUserModel(user, debit, credit, manufacturedAmount));
            }
            return list;
        }

        public static UserModel MapToUserModel(this User x, decimal debit=0, decimal credit =0, decimal manufacturedAmount = 0)
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
                TotalAmount = debit,
                PaidAmount = credit,
                ManufacturedAmount = manufacturedAmount,
                Company = x.Company,
                PaymentDueDate = x.PaymentDueDate,
                PaymentDueDateBS = x.PaymentDueDate.HasValue ? DateConverter.Instance.ToBS(x.PaymentDueDate.Value).ToString(): "",
                AllDuesClearDate = x.AllDuesClearDate,
                AllDuesClearDateBS = x.AllDuesClearDate.HasValue ? DateConverter.Instance.ToBS(x.AllDuesClearDate.Value).ToString(): "",
                LastLedgerPrintDate = x.LastLedgerPrintDate,
                
            };
        }

    }
}
