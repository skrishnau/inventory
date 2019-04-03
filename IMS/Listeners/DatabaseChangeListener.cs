using IMS.Listeners.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Business;

namespace IMS.Listeners
{
    public class DatabaseChangeListener:IDatabaseChangeListener
    {
        // branch update event
        public event EventHandler<BranchEventArgs> BranchUpdated;
        // expose function to facilitate the event trigger from another class
        public void UpdateBranch(object sender, BranchEventArgs eventArgs)
        {
            // call the event
            BranchUpdated(sender, eventArgs);
        }
        // invoker
        protected virtual void OnBranchUpdated(BranchEventArgs args)
        {
            BranchUpdated?.Invoke(null, args);
        }



    }
}
