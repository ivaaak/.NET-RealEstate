using MediatR;
using RealEstate.Core.ViewModels.Search;

namespace RealEstate.CQRS.Queries
{
    public class CombinedSearchQuery : IRequest<SearchViewModel>
    {
        public string? Query { get; set; }
    }
}
