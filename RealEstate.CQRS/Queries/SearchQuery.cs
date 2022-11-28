using MediatR;
using RealEstate.Core.ViewModels.Search;

namespace RealEstate.CQRS.Queries
{
    public class SearchQuery : IRequest<SearchQueryViewModel>
    {
        public string? Query { get; set; }
    }
}
