#nullable disable
using MediatR;
using Microsoft.AspNetCore.Http;

namespace RealEstate.Shared.MediatR.PipelineBehaviour
{
    public class AuthenticationBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationBehavior(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (!httpContext.User.Identity.IsAuthenticated)
            {
                throw new UnauthorizedAccessException();
            }

            return await next();
        }


        public async Task<TResponse> Handle(TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var user = _httpContextAccessor.HttpContext.User;

            if (!user.Identity.IsAuthenticated ||
                !user.IsInRole("admin") ||
                !IsAuthorized())
            {
                throw new UnauthorizedAccessException();
            }

            return await next();
        }

        private bool IsAuthorized()
        {
            var context = _httpContextAccessor.HttpContext;

            var user = context.User;

            if (!user.Identity.IsAuthenticated || !user.IsInRole("admin"))
            {
                return false;
            }
            return true;
        }
    }
}
