using MediatR;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.MediatR.BehaviorModels.ResponseModels;
using RealEstate.Shared.MediatR.Commands.Delete;
using RealEstate.Shared.Models.Entities.Estates;

namespace RealEstate.Shared.MediatR.Handlers.Delete
{
    public class DeleteEstateByIdHandler : IRequestHandler<DeleteEstateByIdCommand, Response>
    {
        private readonly IApplicationDbRepository repo;

        public DeleteEstateByIdHandler(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public Task<Response> Handle(DeleteEstateByIdCommand request, CancellationToken cancellationToken)
        {
            int id = request.Id;
            var estate = repo.GetByIdAsync<Estate>(id);
            repo.DeleteAsync<Estate>(estate);

            return (Task<Response>)Task.CompletedTask;
        }
    }
}
