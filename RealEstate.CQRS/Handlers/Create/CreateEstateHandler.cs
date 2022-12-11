using MediatR;
using RealEstate.CQRS.BehaviorModels.ResponseModels;
using RealEstate.CQRS.Commands.Create;
using RealEstate.Data.Repository;

namespace RealEstate.CQRS.Handlers.Create
{
    public class CreateEstateHandler : IRequestHandler<CreateEstateCommand, Response>
    {
        private readonly IApplicationDbRepository repo;

        public CreateEstateHandler(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public Task<Response> Handle(CreateEstateCommand request, CancellationToken cancellationToken)
        {
            var estate = request.Estate;

            repo.AddAsync(estate);

            return (Task<Response>)Task.CompletedTask;
        }
    }
}
