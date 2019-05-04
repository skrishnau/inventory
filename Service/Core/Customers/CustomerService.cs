using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Context;
using ViewModel.Core.Common;
using ViewModel.Core.Customers;

namespace Service.Core.Customers
{
    public class CustomerService : ICustomerService
    {
        // private readonly DatabaseContext _context;

        public CustomerService()//DatabaseContext context
        {
            //_context = context;
        }

        public void AddOrUpdateCustomer(CustomerModel customerModel)
        {
            using (var _context = new DatabaseContext())
            {

                var dbEntity = _context.Customer.FirstOrDefault(x => x.Id == customerModel.Id);
                if (dbEntity == null)
                {
                    var customerEntity = customerModel.ToEntity();
                    _context.Customer.Add(customerEntity);
                }
                else
                {
                    dbEntity.DeliveryAddress = customerModel.DeliveryAddress;
                    //   dbEntity.BasicInfo.UpdatedAt = DateTime.Now;
                }
                _context.SaveChanges();
            }
        }

        public List<IdNamePair> GetCustomerListForCombo()
        {
            using (var _context = new DatabaseContext())
            {
                return _context.Customer
                              .Where(x => x.BasicInfo.DeletedAt == null)
                              .Select(x => new IdNamePair()
                              {
                                  Id = x.Id,
                                  Name = x.BasicInfo.Name
                              }).ToList();
            }


        }

        public List<CustomerModel> GetCustomerList()
        {
            using (var _context = new DatabaseContext())
            {

                var customers = _context.Customer
                    .Where(x => x.BasicInfo.DeletedAt == null)
                    .Select(x => new CustomerModel()
                    {
                        DeliveryAddress = x.DeliveryAddress,
                        Id = x.Id,
                        CreatedAt = x.BasicInfo.CreatedAt,
                        Address = x.BasicInfo.Address,
                        DOB = x.BasicInfo.DOB,
                        DeletedAt = x.BasicInfo.DeletedAt,
                        Email = x.BasicInfo.Email,
                        Gender = x.BasicInfo.Gender,
                        IsMarried = x.BasicInfo.IsMarried,
                        Name = x.BasicInfo.Name,
                        Phone = x.BasicInfo.Phone,
                        UpdatedAt = x.BasicInfo.UpdatedAt
                    })
                    .ToList();

                return customers;
            }
        }
    }
}
