using DTO.Core;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core;
using ViewModel.Core.Common;

namespace Service.Interfaces
{
    public interface IProductOwnerService
    {
        List<IdNamePair> GetCurrentProductsOfOwner(int departmentId, int userId);
        decimal GetOnHoldProductQuantityOfOwner(int departmentId, int userId, int productId, int packageId);

        ResponseModel<bool> SaveAssignRelease(AssignReleaseViewModel assignReleaseModel);
        ProductOwner AssignProductOwnerWithoutCommit(DatabaseContext _context, int departmentId, string departmentName, int userId, string userName, int productId, int packageId, decimal quantity, bool inOut, string remarks);
        List<ProductOwnerModel> GetProductOnwerList(int departmentId, int userId);
    }
}
