using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public T data { get; }

        public DataResult(T Data, bool success, string message):base(success, message)
        {
            data = Data;
        }
        public DataResult(T Data,bool success):base(success)
        {
            data = Data;
        }
    }
}
