using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Common
{
    public class IdValuePair
    {
        private IdValuePair()
        {
        }

        public IdValuePair(int id, string value)
        {
            Id = id;
            Value = value;
        }

        public int Id { get; set; }
        public string Value { get; set; }

        public static IdValuePair Instance { get { return new IdValuePair(); } }
    }
}
