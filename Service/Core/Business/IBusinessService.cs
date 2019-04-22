using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Business;
using ViewModel.Core.Common;

namespace Service.Core.Business
{
    public interface IBusinessService
    {

        List<CounterModel> GetCounterList();
        void AddOrUpdateCounter(CounterModel counter);


        int AddOrUpdateBranch(BranchModel branch);
        List<BranchModel> GetBranchList();
       // void DeleteBranch(int branchId);

    }
}
