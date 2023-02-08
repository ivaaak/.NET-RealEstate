using MediatR;
using RealEstate.Models.ViewModels.Search;

namespace RealEstate.MediatR.Queries
{
    public class CombinedSearchQuery : IRequest<SearchViewModel>
    {
        public string? Query { get; set; }
    }
}
