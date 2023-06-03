using Microsoft.AspNetCore.Builder;

namespace RealEstate.Shared.Core.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
            => builder.UseMiddleware<CustomExceptionHandler>();
    }
}
