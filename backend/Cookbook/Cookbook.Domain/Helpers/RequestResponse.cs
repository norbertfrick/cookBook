using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Domain.Helpers
{
    public class RequestResponse<T>
    {
        public RequestResponse(bool isSuccess, T data, string message)
        {
            IsSuccess = isSuccess;
            Data = data;
            Message = message;
        }

        public RequestResponse(bool isSuccess, T data): this(isSuccess, data, string.Empty)
        {
        }

        public bool IsSuccess { get; set; }

        public T? Data { get; set; }

        public string Message { get; set; }
    }

    public class RequestResponse : RequestResponse<object>
    {
        public RequestResponse(bool isSuccess, object data, string message) : base(isSuccess, data, message)
        {
        }

        public RequestResponse(bool isSuccess, object data) : base(isSuccess, data)
        {

        }
    }
}
