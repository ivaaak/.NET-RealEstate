using MediatR;
using RealEstate.Shared.Models.DTOs.Search;

namespace RealEstate.Shared.MediatR.Queries
{
    public class ListingsSearchQuery : IRequest<SearchDTO>
    {
        public string? Query { get; set; }
    }
}
