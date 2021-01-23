using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Enums
{
   public enum BillSettingsEnum
    {
        BILL_SUFFIX, 
        BILL_PREFIX,
        BILL_BODY,
        BillCurrentIndex,
        //BILL_END_NUMBER, BILL_START_NUMBER
    }

    public enum ReferencesTypeEnum
    {
        Sale,
        Purchase,
        Payment,
             
    }
}
