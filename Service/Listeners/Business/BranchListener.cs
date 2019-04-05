using Service.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Business;

namespace Service.Listeners.Business
{
    public class BranchEventArgs : EventArgs
    {
        // model in this event args
        public BranchModel BranchModel { get; set; }
        // mode
        public UpdateMode Mode { get; set; }

        // private empty constructor
        private BranchEventArgs() { }
        // public parameterized constructor
        public BranchEventArgs(BranchModel branch, UpdateMode mode)
        {
            BranchModel = branch;
            Mode = mode;
        }
        // static Instance generator
        public static BranchEventArgs Instance { get { return new BranchEventArgs(); } }
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
