using MediatR;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.MediatR.BehaviorModels.ResponseModels;
using RealEstate.Shared.MediatR.Commands.Create;

namespace RealEstate.Shared.MediatR.Handlers.Create
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
