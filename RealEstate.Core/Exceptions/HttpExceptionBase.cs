using System.Net;

namespace RealEstate.Core.Exceptions
{
    public class HttpExceptionBase : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public object Content { get; set; }

        public HttpExceptionBase(HttpStatusCode statusCode, string message = null, Exception innerException = null)
            : base(message, innerException)
        {
            this.StatusCode = statusCode;
        }
    }
}
