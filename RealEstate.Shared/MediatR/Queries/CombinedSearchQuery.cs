using MediatR;
using RealEstate.Shared.Models.DTOs.Search;

namespace RealEstate.Shared.MediatR.Queries
{
    public class CombinedSearchQuery : IRequest<SearchDTO>
    {
        public string? Query { get; set; }
    }
}
