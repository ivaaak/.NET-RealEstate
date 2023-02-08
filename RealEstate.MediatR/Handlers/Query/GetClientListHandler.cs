using MediatR;
using RealEstate.Data.Repository;
using RealEstate.MediatR.Queries;
using RealEstate.Models.Entities.Clients;
using RealEstate.Models.ViewModels.Clients;

namespace RealEstate.MediatR.Handlers.Query
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
