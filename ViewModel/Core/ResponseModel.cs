﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core
{

    public class ResponseModel<T>
    {
        public ResponseModel()
        {
            Message = string.Empty;
        }
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
