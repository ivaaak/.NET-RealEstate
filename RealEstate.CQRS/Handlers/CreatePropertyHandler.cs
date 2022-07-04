using MediatR;
using RealEstate.CQRS.Commands;
using RealEstate.CQRS.Responses;
using RealEstate.Infrastructure.Data;
using RealEstate.Infrastructure.Data.Repositories;

namespace RealEstate.CQRS.Handlers
{
    public class CreatePropertyHandler : IRequestHandler<CreatePropertyCommand, Response>
    {
        private readonly IApplicationDbRepository repo;

        public CreatePropertyHandler(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public Task<Response> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            var property = request.Property;

            repo.AddAsync<Property>(property);

            return (Task<Response>)Task.CompletedTask;
        }
    }
}
