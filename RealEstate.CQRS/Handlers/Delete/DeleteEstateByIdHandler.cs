using MediatR;
using RealEstate.CQRS.BehaviorModels.ResponseModels;
using RealEstate.CQRS.Commands.Delete;
using RealEstate.Data.Repository;
using RealEstate.Models.Entities.Estates;

namespace RealEstate.CQRS.Handlers.Delete
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
