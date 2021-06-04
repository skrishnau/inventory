using IMS.Forms.Inventory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Common
{
    public class BaseUserControl : UserControl
    {
        public string MyTabTitle { get; set; }
        public string MySubTabTitle { get; set; }
        Dictionary<Action, EventArgs> _listenerActions = new Dictionary<Action, EventArgs>();

        public BaseUserControl()
        {
            
        }

        protected void AddListenerAction(Action action, EventArgs e)
        {
            if (InventoryUC.CurrentTabTitle.Trim() == MyTabTitle.Trim() 
                && (string.IsNullOrEmpty(InventoryUC.CurrentSubTabTitle) || string.IsNullOrEmpty(MySubTabTitle) || MySubTabTitle.Trim() == InventoryUC.CurrentSubTabTitle.Trim()))
            {
                action?.Invoke();
                return;
            }
            if (!_listenerActions.ContainsKey(action))
                _listenerActions.Add(action, e);
        }

        // override if the main page has child views as in ProductUC
        public virtual void ExecuteActions()
        {
            foreach (var action in _listenerActions.Keys)
            {
                action?.Invoke();
            }
            _listenerActions.Clear();
        }
        
    }
}
