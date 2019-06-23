using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Core.Models
{
    public class ResponseModel<T>
    {
        public T data { get; set; }

        public bool isSuccessful { get; }

     
        public string message { get; } = "Operation Successful";

        public ResponseModel(T Data, bool IsSuccessful = true,string Message = "Operation Successful")
        {
            this.data = Data;
            this.isSuccessful = IsSuccessful;
            this.message = Message;
         
            
        }

    }
}
