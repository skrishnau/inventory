using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Settings
{
    public class AppSettingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }
        public string Group { get; set; }
        
    }
}
