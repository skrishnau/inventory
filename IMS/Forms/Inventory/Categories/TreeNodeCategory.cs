using IMS.Forms.Inventory.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Inventory.Categories
{
    class TreeNodeCategory:TreeNode
    {
        private CategoryEditControlPanel categoryEditUC;

        public TreeNodeCategory()
        {
            categoryEditUC = new CategoryEditControlPanel();
        }

        public CategoryEditControlPanel CategoryEditUC {
            get { return categoryEditUC; }
            set { this.categoryEditUC = value; }
        }

      
    }
}
