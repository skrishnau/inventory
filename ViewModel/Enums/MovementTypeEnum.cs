using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Enums
{
    public enum MovementTypeEnum
    {
        POReceive,
        /// <summary>
        /// The view is opened for editing items, hence shouldn't disable edit of existing rows and adding of new rows
        /// </summary>
        POReceiveEditItems,
        DirectReceive,

        SOIssue,
        /// <summary>
        /// The view is opened for editing items, hence shouldn't disable edit of existing rows and adding of new rows
        /// </summary>
        SOIssueEditItems,
        /// <summary>
        /// Direct Issue all units in an Inventory Unit. Only the selected inventory unit is issued. 
        /// </summary>
        DirectIssueInventoryUnit,
        /// <summary>
        /// Direct Issue which allows user to select any product
        /// </summary>
        DirectIssueAny,

        TOMove,
        /// <summary>
        /// The view is opened for editing items, hence shouldn't disable edit of existing rows and adding of new rows
        /// </summary>
        TOMoveEditItems,
        DirectMoveInventoryUnit,
        DirectMoveAny,
        Merge,
        Manufacture
    }
}
