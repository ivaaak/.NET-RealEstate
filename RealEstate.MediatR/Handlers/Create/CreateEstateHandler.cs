using MediatR;
using RealEstate.Data.Repository;
using RealEstate.MediatR.BehaviorModels.ResponseModels;
using RealEstate.MediatR.Commands.Create;

namespace RealEstate.MediatR.Handlers.Create
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
