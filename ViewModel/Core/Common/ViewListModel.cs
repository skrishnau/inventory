﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core
{
    public class ViewListModel<T>
    {
        public List<T> DataList { get; set; }

        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int Offset { get; set; }
    }
}
