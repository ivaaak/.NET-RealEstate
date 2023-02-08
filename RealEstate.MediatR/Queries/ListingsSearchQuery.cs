using MediatR;
using RealEstate.Models.ViewModels.Search;

namespace RealEstate.MediatR.Queries
{
    public class ListingsSearchQuery : IRequest<SearchViewModel>
    {
        public string? Query { get; set; }
    }
}
