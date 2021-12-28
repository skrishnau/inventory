using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Enums
{
    public enum AdjustmentTypeEnum
    {
        Positive, Negative
    }

    public enum AdjustmentCodeEnum
    {
        PO_Receive,
        Damage,
        Cancelled,
        Disassembled,
        Consumed,
    }
}
