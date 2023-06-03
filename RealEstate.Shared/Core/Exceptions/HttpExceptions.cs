#nullable disable
using System.Net;

namespace RealEstate.Shared.Core.Exceptions
{
    public static class HttpExceptions
    {
        #region Client Errors

        public static HttpException BadRequestException(object content = null, string message = null)
        {
            return new HttpException(HttpStatusCode.BadRequest, message)
            {
                Content = content,
            };
        }

        public static HttpException UnauthorizedException(object content = null, string message = null)
        {
            return new HttpException(HttpStatusCode.Unauthorized, message)
            {
                Content = content,
            };
        }

        public static HttpException NotFoundException(object content = null, string message = null)
        {
            return new HttpException(HttpStatusCode.NotFound, message)
            {
                Content = content,
            };
        }

        #endregion

        #region Service Errors

        #endregion
    }
}
