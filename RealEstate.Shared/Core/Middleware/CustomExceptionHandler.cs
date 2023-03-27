using Microsoft.AspNetCore.Http;
using RealEstate.Shared.Core.Exceptions;

namespace RealEstate.Shared.Core.Middleware
{
    public class CustomExceptionHandler
    {
        private readonly RequestDelegate next;

        public CustomExceptionHandler(RequestDelegate next) => this.next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                {
                    if (!context.Response.HasStarted)
                    {
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        //await context.WriteResultAsync(result);
                    }
                }
                else if (ex is ForbiddenException)
                {
                    if (!context.Response.HasStarted)
                    {
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        //await context.WriteResultAsync(result);
                    }
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status204NoContent;
                }
            }
        }
    }
}
