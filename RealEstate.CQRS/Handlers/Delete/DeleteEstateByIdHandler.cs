using MediatR;
using RealEstate.Data.Repository;
using RealEstate.MediatR.BehaviorModels.ResponseModels;
using RealEstate.MediatR.Commands.Delete;
using RealEstate.Models.Entities.Estates;

namespace RealEstate.MediatR.Handlers.Delete
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
