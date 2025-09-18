using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderAbstract.Classes
{
    public class RequestResult<T>
    {
        public bool IsSuccess => Result != null;
        public T Result { get; set; }
        public Exception? Exception { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
