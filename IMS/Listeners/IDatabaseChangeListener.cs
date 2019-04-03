using IMS.Listeners.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Listeners
{
    public interface IDatabaseChangeListener
    {
        // branch event and invoker
        event EventHandler<BranchEventArgs> BranchUpdated;
        void UpdateBranch(object sender, BranchEventArgs eventArgs);

    }
}
