using System;
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
        public ResponseModel(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public ResponseModel(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
        public T Data { get; set; }
        public string Message { get; set; }
        public Boolean Success { get; set; }

        public void ChangeToSuccess()
        {
            Success = true;
            Message = string.Empty;
        }

        public static ResponseModel<T> GetSuccess()
        {
            return new ResponseModel<T> { Success = true, Message = "Success!" };
        }

        public static ResponseModel<T> GetSaveSuccess(T data)
        {
            return new ResponseModel<T> { Success = true, Message = "Save Successful!", Data = data };
        }

        public static ResponseModel<T> GetError(string msg)
        {
            return new ResponseModel<T> { Success = false, Message = msg };
        }
    }
}
