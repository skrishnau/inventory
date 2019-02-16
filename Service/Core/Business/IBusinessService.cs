using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Business;

namespace Service.Core.Business
{
    public interface IBusinessService
    {
        void AddOrUpdateBranch(BranchModel branch);

        void AddOrUpdateCounter(CounterModel counter);

        void AddOrUpdateWarehouse(WarehouseModel warehouse);

        List<BranchModel> GetBranchList();

        List<CounterModel> GetCounterList();

        List<WarehouseModel> GetWarehouseList();

    }
}
