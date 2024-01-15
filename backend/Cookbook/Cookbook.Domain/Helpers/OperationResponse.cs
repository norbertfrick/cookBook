using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Domain.Helpers
{
    public class OperationResponse
    {
        public OperationResponse(bool isSuccess, object data, string message)
        {
            IsSuccess = isSuccess;
            Data = data;
            Message = message;
        }

        public OperationResponse(bool isSuccess, object data): this(isSuccess, data, string.Empty)
        {
        }

        public bool IsSuccess { get; set; }

        public object Data { get; set; }

        public string Message { get; set; }
    }
}
