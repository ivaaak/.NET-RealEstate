using MediatR;
using RealEstate.CQRS.Queries;
using RealEstate.Data.Repository;
using RealEstate.Models.Entities.Clients;
using RealEstate.Models.ViewModels.Clients;

namespace RealEstate.CQRS.Handlers.Query
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
            var clients = repo.All<Client>()
                .Select(u => new ClientViewModel
                {
                    Client_Id = u.Client_Id,
                    Client_Details = u.Client_Details,
                    Client_Address = u.Client_Address,
                    Client_Name = u.Client_Name,
                })
                .ToList();

            return Task.FromResult(clients);
        }
    }
}
