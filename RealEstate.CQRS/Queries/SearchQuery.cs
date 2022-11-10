using MediatR;
using RealEstate.Infrastructure.Models;

namespace RealEstate.CQRS.Queries
{
    public class SearchQuery : IRequest<SearchQueryViewModel>
    {
        public string? Query { get; set; }
    }
}
