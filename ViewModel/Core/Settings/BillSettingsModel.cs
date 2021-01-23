using ViewModel.Enums;

namespace ViewModel.Core.Settings
{
    public class BillSettingsModel
    {

        public string Body { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }

        public long CurrentIndex { get; set; }
        public string ReceiptNo { get; set; }
        public ReferencesTypeEnum Type { get; set; }

        public static BillSettingsModel GetNewInstance()
        {
            return new BillSettingsModel()
            {
                Prefix = "",
                Suffix = "",
                Body = "",
            };
        }

        
    }
}
