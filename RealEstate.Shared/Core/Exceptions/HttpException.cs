#nullable disable
using System.Net;

namespace RealEstate.Shared.Core.Exceptions
{
    public class HttpException : HttpBaseException
    {
        public HttpException(HttpStatusCode statusCode, string message, Exception innerException = null)
            : base(statusCode, message, innerException)
        {
        }
    }
}
