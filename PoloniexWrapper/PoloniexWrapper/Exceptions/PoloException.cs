using System;
using Newtonsoft.Json;

namespace PoloniexWrapper.Exceptions
{
    public class PoloException : Exception
    {        
        public PoloException() { }

        public PoloException(string message) : base(message) { }

        public PoloException(string message, Exception innerException) : base(message, innerException) { }
    }
}
