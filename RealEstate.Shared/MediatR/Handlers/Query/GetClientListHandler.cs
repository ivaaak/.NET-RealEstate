using MediatR;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.MediatR.Queries;
using RealEstate.Shared.Models.DTOs.Clients;
using RealEstate.Shared.Models.Entities.Clients;

namespace RealEstate.Shared.MediatR.Handlers.Query
{
    public class GetClientListHandler : IRequestHandler<GetClientListQuery, List<ClientDTO>>
    {
        private readonly IApplicationDbRepository repo;
        public GetClientListHandler(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public Task<List<ClientDTO>> Handle(GetClientListQuery request, CancellationToken cancellationToken)
        {
            var clients = repo.All<Client>()
                .Select(u => new ClientDTO
                {
                    Id = u.Id,
                    Client_Details = u.Client_Details,
                    Client_Address = u.Client_Address,
                    Client_Name = u.Client_Name,
                })
                .ToList();

            return Task.FromResult(clients);
        }
    }
}
