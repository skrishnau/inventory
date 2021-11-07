using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Common
{
    public class IdNamePair
    {
        public IdNamePair()
        {
        }


        public IdNamePair(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public IdNamePair(int id, string name, string extraValue)
        {
            Id = id;
            Name = name;
            ExtraValue = extraValue;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        // extra value if needed
        public string ExtraValue { get; set; }

        public bool Check { get; set; }

        public static IdNamePair Instance { get { return new IdNamePair(); } }
    }
}
