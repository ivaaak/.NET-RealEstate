using Microsoft.AspNetCore.Mvc;
using RealEstate.Core.Exceptions;
using RealEstate.Infrastructure.Context;

namespace RealEstate.Web.Middleware
{
    public class CustomExceptionHandler
    {
        private readonly RequestDelegate next;

        public CustomExceptionHandler(RequestDelegate next) => this.next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                {
                    var result = new ViewResult
                    {
                        ViewName = "~/Views/Shared/NotFound.cshtml",
                    };

                    if (!context.Response.HasStarted)
                    {
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        await context.WriteResultAsync(result);
                    }
                }
                else if (ex is ForbiddenException)
                {
                    var result = new ViewResult
                    {
                        ViewName = "~/Views/Shared/Forbidden.cshtml",
                    };


                    if (!context.Response.HasStarted)
                    {
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        await context.WriteResultAsync(result);
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
