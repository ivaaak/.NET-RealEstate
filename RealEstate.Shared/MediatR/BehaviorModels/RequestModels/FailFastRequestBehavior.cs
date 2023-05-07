#nullable disable
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using RealEstate.Shared.MediatR.BehaviorModels.ResponseModels;

namespace RealEstate.Shared.MediatR.BehaviorModels.RequestModels
{
    public class FailFastRequestBehavior<TRequest, TResponse>
      : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
      where TResponse : Response
    {
        private readonly IEnumerable<IValidator> _validators;

        public FailFastRequestBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var failures = _validators
                .Select(v => v.Validate((IValidationContext)request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            return failures.Any()
                ? Errors(failures)
                : next();
        }

        private static Task<TResponse> Errors(IEnumerable<ValidationFailure> failures)
        {
            var response = new Response();

            foreach (var failure in failures)
            {
                response.AddError(failure.ErrorMessage);
            }

            return Task.FromResult(response as TResponse);
        }
    }
}
