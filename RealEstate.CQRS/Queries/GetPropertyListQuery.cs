using MediatR;
using RealEstate.Core.ViewModels;

namespace RealEstate.CQRS.Queries
{
    public class GetPropertyListQuery : IRequest<List<PropertyViewModel>>
    {
        // As this lists all Properties it doesnt take in any parameter
    }
}
