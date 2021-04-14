using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Inventory
{

    public class MovementListModel
    {
        public List<MovementModel> DataList { get; set; }

        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int Offset { get; set; }
    }

    public class MovementModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Reference { get; set; }
        public string AdjustmentCode { get; set; }

        public decimal Quantity { get; set; }

        public string Date { get; set; }

        public int ProductId { get; set; }
    }
}
