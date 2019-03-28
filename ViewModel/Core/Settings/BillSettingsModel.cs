using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Settings
{
    public class BillSettingsModel
    {
        public int StartNumber { get; set; }
        public int EndNumber { get; set; }

        public string Prefix { get; set; }
        public string Suffix { get; set; }


        public static BillSettingsModel GetNewInstance()
        {
            return new BillSettingsModel()
            {
                EndNumber = 0,
                Prefix = "",
                StartNumber = 0, 
                Suffix = "",
            };
        }

        
    }
}
