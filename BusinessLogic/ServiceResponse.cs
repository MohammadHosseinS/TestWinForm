using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public  class ServiceResponse<T>
    {
        public bool Success { get; private set; } = true;
        public T Data { get; private set; }
        public Exception Exception { get; private set; }

        public void SetState(bool success)
        {
            Success = success;
        }

        public void SetData(T data)
        {
            Data = data;
        }

        public void SetError(Exception ex)
        {
            Exception = ex;
        }

        public string GetError()
        {
            return Exception.Message;
        }
    }
}
