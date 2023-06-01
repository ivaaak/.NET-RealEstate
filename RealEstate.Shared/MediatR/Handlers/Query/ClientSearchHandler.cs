#nullable disable
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.MediatR.Queries;
using RealEstate.Shared.Models.DTOs.Clients;
using RealEstate.Shared.Models.DTOs.Search;
using RealEstate.Shared.Models.Entities.Clients;

namespace RealEstate.Shared.MediatR.Handlers.Query
{
    public class ClientSearchHandler : IRequestHandler<CombinedSearchQuery, SearchDTO>
    {
        private readonly IRepository clientsRepository;
        private readonly IMapper mapper;

        public ClientSearchHandler(
            IRepository clientsRepository,
            IMapper mapper)
        {
            this.clientsRepository = clientsRepository;
            this.mapper = mapper;
        }

        public async Task<SearchDTO> Handle(CombinedSearchQuery request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrWhiteSpace(request.Query))
            {
                //throw new InvalidSearchQueryException();
            }

            var queryNormalized = request.Query.ToLower();

            var clients = await clientsRepository
                .All<Client>()
                .Where(p => p.Client_Name
                    .ToLower()
                    .Contains(queryNormalized))
                .OrderBy(p => p.Client_Name)
                .ProjectTo<ClientDTO>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);


            var dataModel = new SearchDTO
            {
                SearchQuery = request.Query,
                Clients = (IEnumerable<Client>)clients,
            };

            return dataModel;
        }
    }
}
