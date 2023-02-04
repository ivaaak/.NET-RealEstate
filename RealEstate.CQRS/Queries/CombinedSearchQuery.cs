using MediatR;
using RealEstate.Models.ViewModels.Search;

namespace RealEstate.MediatR.Queries
{
    public class CombinedSearchQuery : IRequest<SearchDTO>
    {
        public string? Query { get; set; }
    }
}
