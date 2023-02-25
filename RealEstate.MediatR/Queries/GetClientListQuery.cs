using MediatR;
using RealEstate.Models.DTOs.Clients;

namespace RealEstate.MediatR.Queries
{
    public class GetClientListQuery : IRequest<List<ClientDTO>>
    {
        // As this lists all People it doesnt take in any parameter
    }
}
