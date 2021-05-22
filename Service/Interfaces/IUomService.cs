using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUomService
    {
        decimal ConvertUom(int fromPackageId, int toPackageId, int? productId, decimal multiplier = 1);
        decimal ConvertUom(DatabaseContext _context, int fromPackageId, int toPackageId, int? productId, decimal multiplier = 1, List<Uom> includeThisList = null);
    }
}
