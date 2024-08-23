using System.Net;
using System.Runtime.Serialization;

namespace TopMovies.Business
{
    [Serializable]
    public class HttpRequestExceptionEx : Exception
    {
        private HttpStatusCode statusCode;
        private string jsonResult;

        public HttpRequestExceptionEx()
        {
        }

        public HttpRequestExceptionEx(string? message) : base(message)
        {
        }

        public HttpRequestExceptionEx(HttpStatusCode statusCode, string jsonResult)
        {
            this.statusCode = statusCode;
            this.jsonResult = jsonResult;
        }

        public HttpRequestExceptionEx(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected HttpRequestExceptionEx(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}