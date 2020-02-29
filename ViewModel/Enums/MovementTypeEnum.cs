using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Enums
{
    public enum MovementTypeEnum
    {
        POReceive, DirectReceive,

        SOIssue,
        /// <summary>
        /// Direct Issue all units in an Inventory Unit. Only the selected inventory unit is issued. 
        /// </summary>
        DirectIssueInventoryUnit,
        /// <summary>
        /// Direct Issue which allows user to select any product
        /// </summary>
        DirectIssueAny,

        TOMove,
        DirectMoveInventoryUnit,
        DirectMoveAny
    }
}
