using MediatR;
using RealEstate.Core.Models;

namespace RealEstate.CQRS.Queries
{
    public class GetPersonListQuery : IRequest<List<UserListViewModel>>
    {
        // As this lists all People it doesnt take in any parameter
    }
}
