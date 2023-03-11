using MediatR;
using RealEstate.Shared.Models.DTOs.Clients;

namespace RealEstate.Shared.MediatR.Queries
{
    public class GetClientListQuery : IRequest<List<ClientDTO>>
    {
        // As this lists all People it doesnt take in any parameter
    }
}
