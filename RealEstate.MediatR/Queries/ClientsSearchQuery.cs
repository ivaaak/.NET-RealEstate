using MediatR;
using RealEstate.Models.DTOs.Search;

namespace RealEstate.MediatR.Queries
{
    public class ClientsSearchQuery : IRequest<SearchDTO>
    {
        public ClientsSearchQuery(string query)
        {
            Query = query;
        }

        public string? Query { get; set; }
    }
}
