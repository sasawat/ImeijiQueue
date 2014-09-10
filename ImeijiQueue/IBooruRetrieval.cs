using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImeijiQueue
{
    interface IBooruRetrieval
    {

        byte[] getImage();

        String getSauceURL();

        String getTitle();

    }

    [Serializable]
    public class BooruRetrievalFailedException : Exception
    {
        public errCode error {get; private set;}
        public enum errCode {NetworkError, ParseFailed, SauceFailed}

        public BooruRetrievalFailedException() { }
        public BooruRetrievalFailedException(errCode errorcode)
        {
            error = errorcode;
        }

        public BooruRetrievalFailedException(errCode errorcode, Exception inner) : base("", inner)
        {
            error = errorcode;
        }
        public BooruRetrievalFailedException(string message) : base(message) { }
        public BooruRetrievalFailedException(string message, Exception inner) : base(message, inner) { }
        protected BooruRetrievalFailedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
