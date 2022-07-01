using MediatR;
using RealEstate.Core.Models;
using RealEstate.CQRS.Queries;
using RealEstate.Infrastructure.Data.Repositories;

namespace RealEstate.CQRS.Handlers
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, UserViewModel>
    {
        private readonly IApplicationDbRepository repo;
        public GetPersonByIdHandler(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public Task<UserViewModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;
            return Task.FromResult(repo.GetByIdAsync<UserViewModel>(id).Result); //repo works?
        }
    }
}
