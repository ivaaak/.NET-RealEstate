using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RealEstate.Filters
{
    public class AjaxFilterAttribute : ActionFilterAttribute, IAsyncActionFilter
    {
        private const string RequestedWithHeader = "X-Requested-With";
        private const string XmlHttpRequest = "XMLHttpRequest";

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var request = context.HttpContext.Request;

            if (this.IsAjaxRequest(request))
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

            if (request.Headers != null)
            {
                isAjaxRequest = request.Headers[RequestedWithHeader] == XmlHttpRequest;
            }

            return isAjaxRequest;
        }
    }
}