using MediatR;
using RealEstate.Core.ViewModels.Clients;
using RealEstate.CQRS.Queries;
using RealEstate.Infrastructure.Entities.Clients;
using RealEstate.Infrastructure.Repositories;

namespace RealEstate.CQRS.Handlers.Read
{
    public class GetClientListHandler : IRequestHandler<GetClientListQuery, List<ClientViewModel>>
    {
        private readonly IApplicationDbRepository repo;
        public GetClientListHandler(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public Task<List<ClientViewModel>> Handle(GetClientListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repo.All<Client>()
                .Select(u => new ClientViewModel
                {
                    Client_Id = u.Client_Id,
                    Client_Details = u.Client_Details,
                    Client_Address = u.Client_Address,
                    Client_Name = u.Client_Name,
                })
                .ToList());
        }
    }
}
