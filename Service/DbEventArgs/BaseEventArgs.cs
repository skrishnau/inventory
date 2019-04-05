using Service.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DbEventArgs
{
    public class BaseEventArgs<MODEL>:EventArgs
    {
        // model in this event args
        public MODEL Model { get; set; }
        // mode
        public UpdateMode Mode { get; set; }

        // private empty constructor
        private BaseEventArgs() { }
        // public parameterized constructor
        public BaseEventArgs(MODEL model, UpdateMode mode)
        {
            Model = model;
            Mode = mode;
        }
        // static Instance generator
        public static BaseEventArgs<MODEL> Instance { get { return new BaseEventArgs<MODEL>(); } }
    }
}
