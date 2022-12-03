using MediatR;
using RealEstate.Core.ViewModels.Search;

namespace RealEstate.CQRS.Queries
{
    public class EstatesSearchQuery : IRequest<SearchViewModel>
    {
        public string? Query { get; set; }
    }
}
