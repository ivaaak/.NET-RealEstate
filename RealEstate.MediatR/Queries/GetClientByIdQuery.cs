using MediatR;
using RealEstate.Models.ViewModels.Clients;

namespace RealEstate.MediatR.Queries
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
