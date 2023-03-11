namespace RealEstate.ApiGateway.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
            => builder.UseMiddleware<CustomExceptionHandler>();
        //todo - add diff middlewares
    }
}
