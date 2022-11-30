using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RealEstate.API.Filters
{
    public class AjaxFilterAttribute : ActionFilterAttribute, IAsyncActionFilter
    {
        private const string XmlHttpRequest = "XMLHttpRequest";
        private const string RequestedWithHeader = "X-Requested-With";

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var request = context.HttpContext.Request;

            if (IsAjaxRequest(request))
            {
                await next();
            }
            else
            {
                context.Result = new ForbidResult();
            }
        }

        private bool IsAjaxRequest(HttpRequest request)
        {
            bool isAjaxRequest = false;

            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            else if (request.Headers != null)
            {
                isAjaxRequest = request.Headers[RequestedWithHeader] == XmlHttpRequest;
            }
            return isAjaxRequest;
        }
    }
}