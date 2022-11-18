using MediatR;
using RealEstate.Core.ViewModels;

namespace RealEstate.CQRS.Queries
{
    public class SearchQuery : IRequest<SearchQueryViewModel>
    {
        public string? Query { get; set; }
    }
}
