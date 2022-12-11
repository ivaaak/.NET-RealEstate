using MediatR;
using RealEstate.Models.ViewModels.Clients;

namespace RealEstate.CQRS.Queries
{
    public class GetClientListQuery : IRequest<List<ClientViewModel>>
    {
        // As this lists all People it doesnt take in any parameter
    }
}
