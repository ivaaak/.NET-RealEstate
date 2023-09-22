#nullable disable
using MediatR;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.MediatR.Queries;
using RealEstate.Shared.Models.DTOs.Clients;
using RealEstate.Shared.Models.Entities.Clients;

namespace RealEstate.Shared.MediatR.Handlers.Query
{
    public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, ClientDTO>
    {
        private readonly IApplicationDbRepository repo;

        public string Id { get; set; }

        public GetClientByIdHandler(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public GetClientByIdHandler(string id)
        {
            Id = id;
        }

        public Task<ClientDTO> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            string id = request.Id;

            var foundUser = repo.GetByIdAsync<Client>(id).Result;

            var userViewModel = new ClientDTO
            {
                Id = foundUser.Id,
                Client_Name = foundUser.Client_Name,
                Client_Details = foundUser.Client_Details,
                EMail = foundUser.EMail,
                Contact = foundUser.Contact,
                Client_Address = foundUser.Client_Address,
            };

            return Task.FromResult(userViewModel);
        }
    }
}
