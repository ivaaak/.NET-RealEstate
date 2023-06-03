#nullable disable
using System.Net;

namespace RealEstate.Shared.Core.Exceptions
{
    public class HttpBaseException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public object Content { get; set; }

        public HttpBaseException(HttpStatusCode statusCode, string message = null, Exception innerException = null)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }
}
