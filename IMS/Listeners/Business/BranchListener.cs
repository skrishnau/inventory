using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Business;

namespace IMS.Listeners.Business
{
    public class BranchEventArgs : EventArgs
    {
        public BranchModel BranchModel { get; set; }
    }

    public class BranchListener
    {
       
    }

    // should be in DatabaseChangeListener
    // initialize all the listeners in the constructor
    //public DatabaseChangeListener()
    //{
    //    Branch = new BranchListener();
    //}
    //public BranchListener Branch { get; set; }
}
