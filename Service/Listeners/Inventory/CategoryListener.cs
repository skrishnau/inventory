using Service.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Inventory;

namespace Service.Listeners.Inventory
{
    public class CategoryEventArgs:EventArgs
    {
        public CategoryModel Category { get; set; }
        public UpdateMode Mode { get; set; }


        private CategoryEventArgs()
        {
        }
        public CategoryEventArgs(CategoryModel model)
        {
            Category = model;
        }
        public CategoryEventArgs(CategoryModel model, UpdateMode mode)
        {
            Category = model;
            Mode = mode;
        }
        public static CategoryEventArgs Instance { get { return new CategoryEventArgs(); } }

    }
}
