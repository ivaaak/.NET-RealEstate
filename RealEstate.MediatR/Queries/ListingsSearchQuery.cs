using MediatR;
using RealEstate.Models.DTOs.Search;

namespace RealEstate.MediatR.Queries
{
    public class ListingsSearchQuery : IRequest<SearchDTO>
    {
        public string? Query { get; set; }
    }
}
