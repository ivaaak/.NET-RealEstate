using MediatR;
using RealEstate.Models.ViewModels.Clients;

namespace RealEstate.CQRS.Queries
{
    public class GetClientByIdQuery : IRequest<ClientViewModel>
    //returns ClientViewModel
    {
        public string Id { get; set; }

        public GetClientByIdQuery(string Id)
        {
            this.Id = Id;
        }
    }
}
