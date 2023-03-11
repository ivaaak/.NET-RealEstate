using MediatR;
using RealEstate.Shared.Models.DTOs.Clients;

namespace RealEstate.Shared.MediatR.Queries
{
    public class GetClientByIdQuery : IRequest<ClientDTO>
    //returns ClientViewModel
    {
        public string Id { get; set; }

        public GetClientByIdQuery(string Id)
        {
            this.Id = Id;
        }
    }
}
