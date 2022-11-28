using MediatR;
using RealEstate.Core.ViewModels.Clients;
using RealEstate.CQRS.Queries;
using RealEstate.Infrastructure.Entities.Clients;
using RealEstate.Infrastructure.Repositories;

namespace RealEstate.CQRS.Handlers.Read
{
    public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, ClientViewModel>
    {
        public string Id { get; set; }

        private readonly IApplicationDbRepository repo;

        public GetClientByIdHandler(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public GetClientByIdHandler(string id)
        {
            Id = id;
        }

        public async Task<ClientViewModel> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            string id = request.Id;

            var foundUser = await repo.GetByIdAsync<Client>(id);

            var userViewModel = new ClientViewModel
            {
                Client_Id = foundUser.Id,
                Client_Name = foundUser.Client_Name,
                Client_Details = foundUser.Client_Details,
                EMail = foundUser.Email,
                Contact = foundUser.Contact,
                Client_Address = foundUser.Client_Address,
            };

            return userViewModel;
        }
    }
}
