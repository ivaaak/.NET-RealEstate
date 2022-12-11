using MediatR;
using RealEstate.Models.ViewModels.Search;

namespace RealEstate.CQRS.Queries
{
    public class EstatesSearchQuery : IRequest<SearchViewModel>
    {
        public string? Query { get; set; }
    }
}
