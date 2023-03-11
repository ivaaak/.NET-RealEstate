using MediatR;
using RealEstate.Shared.Models.DTOs.Estates;

namespace RealEstate.Shared.MediatR.Queries
{
    public class GetEstateListQuery : IRequest<List<EstateDTO>>
    {
        // As this lists all Properties it doesnt take in any parameter
    }
}
