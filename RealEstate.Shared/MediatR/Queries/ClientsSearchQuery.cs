using MediatR;
using RealEstate.Shared.Models.DTOs.Search;

namespace RealEstate.Shared.MediatR.Queries
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
