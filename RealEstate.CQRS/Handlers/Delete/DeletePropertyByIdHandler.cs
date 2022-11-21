using MediatR;
using RealEstate.CQRS.Commands;
using RealEstate.CQRS.Responses;
using RealEstate.Infrastructure.Entities;
using RealEstate.Infrastructure.Repositories;

namespace RealEstate.CQRS.Handlers.Delete
{
    public class DeletePropertyByIdHandler : IRequestHandler<DeletePropertyByIdCommand, Response>
    {
        private readonly IApplicationDbRepository repo;

        public DeletePropertyByIdHandler(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public Task<Response> Handle(DeletePropertyByIdCommand request, CancellationToken cancellationToken)
        {
            int id = request.Id;
            var property = repo.GetByIdAsync<Property>(id);
            repo.DeleteAsync<Property>(property);

            return (Task<Response>)Task.CompletedTask;
        }
    }
}
