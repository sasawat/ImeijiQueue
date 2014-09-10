using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImeijiQueue
{
    interface ISauce
    {
        String getTitle();

        String getSauceURL();
    }

    [Serializable]
    public class SauceLookupFailedException : Exception
    {
        public errCode error {get; private set;}
        public enum errCode {SauceNotFound, NetworkError, ParseFailed}

        public SauceLookupFailedException() { }
        public SauceLookupFailedException(errCode errorcode)
        {
            error = errorcode;
        }
        public SauceLookupFailedException(string message) : base(message) { }
        public SauceLookupFailedException(string message, Exception inner) : base(message, inner) { }
        protected SauceLookupFailedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

    }
}
