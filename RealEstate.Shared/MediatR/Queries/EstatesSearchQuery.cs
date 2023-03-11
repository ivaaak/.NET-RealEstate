using MediatR;
using RealEstate.Shared.Models.DTOs.Search;

namespace RealEstate.Shared.MediatR.Queries
{
    public class EstatesSearchQuery : IRequest<SearchDTO>
    {
        public EstatesSearchQuery()
        {
        }

        public EstatesSearchQuery(string query)
        {
            Query = query;
        }

        public string? Query { get; set; }

        public string? City { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Sort { get; set; }
    }
}
