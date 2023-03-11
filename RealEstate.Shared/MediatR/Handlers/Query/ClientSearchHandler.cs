using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.MediatR.Queries;
using RealEstate.Shared.Models.DTOs.Search;
using RealEstate.Shared.Models.Entities.Clients;

namespace RealEstate.Shared.MediatR.Handlers.Query
{
    public class ClientSearchHandler : IRequestHandler<CombinedSearchQuery, SearchDTO>
    {
        private readonly IDeletableEntityRepository<Client> clientsRepository;
        private readonly IMapper mapper;

        public ClientSearchHandler(
            IDeletableEntityRepository<Client> clientsRepository,
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
                .AllAsNoTracking()
                .Where(p => p.UserName
                    .ToLower()
                    .Contains(queryNormalized))
                .OrderBy(p => p.UserName)
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
