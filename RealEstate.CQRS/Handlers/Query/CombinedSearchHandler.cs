using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data.Repository;
using RealEstate.Infrastructure.LookupModels;
using RealEstate.MediatR.Queries;
using RealEstate.Models.Entities.Clients;
using RealEstate.Models.Entities.Estates;
using RealEstate.Models.Entities.Listings;
using RealEstate.Models.ViewModels.Search;

namespace RealEstate.MediatR.Handlers.Query
{
    public class CombinedSearchHandler : IRequestHandler<CombinedSearchQuery, SearchDTO>
    {
        private readonly IDeletableEntityRepository<Client> clientsRepository;
        private readonly IDeletableEntityRepository<Estate> estatesRepository;
        private readonly IDeletableEntityRepository<Listing> listingsRepository;
        private readonly IMapper mapper;

        public CombinedSearchHandler(
            IDeletableEntityRepository<Client> clientsRepository,
            IDeletableEntityRepository<Estate> estatesRepository,
            IDeletableEntityRepository<Listing> listingsRepository,
            IMapper mapper)
        {
            this.clientsRepository = clientsRepository;
            this.estatesRepository = estatesRepository;
            this.listingsRepository = listingsRepository;
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
                .ProjectTo<ClientLookupModel>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var estates = await estatesRepository
                .AllAsNoTracking()
                .Where(p => p.Estate_Name
                    .ToLower()
                    .Contains(queryNormalized))
                .OrderBy(p => p.Estate_Name)
                .ProjectTo<EstateLookupModel>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var listings = await listingsRepository
              .AllAsNoTracking()
              .Where(p => p.Name
                    .ToLower()
                    .Contains(queryNormalized))
              .OrderBy(p => p.Name)
              .ProjectTo<ListingsLookupModel>(mapper.ConfigurationProvider)
              .ToListAsync(cancellationToken);

            var dataModel = new SearchDTO
            {
                SearchQuery = request.Query,
                Clients = (IEnumerable<Client>)clients,
                Estates = (IEnumerable<Estate>)estates,
                Listings = (IEnumerable<Listing>)listings
                // implementing mapping will fix this
            };

            return dataModel;
        }
    }
}
