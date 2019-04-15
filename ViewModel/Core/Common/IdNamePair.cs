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

        public int Id { get; set; }
        public string Name { get; set; }

        public static IdNamePair Instance { get { return new IdNamePair(); } }
    }
}
