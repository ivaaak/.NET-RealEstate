using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using RealEstate.Core.Interfaces;
using RealEstate.Core.ViewModels.Search;
using RealEstate.CQRS.Queries;
using RealEstate.Infrastructure.Entities.Clients;
using RealEstate.Infrastructure.Entities.Estates;
using RealEstate.Infrastructure.Entities.Listings;

namespace RealEstate.CQRS.Handlers.Query
{
    public class CombinedSearchHandler : IRequestHandler<CombinedSearchQuery, SearchViewModel>
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

        public async Task<SearchViewModel> Handle(CombinedSearchQuery request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrWhiteSpace(request.Query))
            {
                //throw new InvalidSearchQueryException();
            }

            var queryNormalized = request.Query.ToLower();

            var clients = await this.clientsRepository
                .AllAsNoTracking()
                .Where(p => p.UserName.ToLower().Contains(queryNormalized))
                .OrderBy(p => p.UserName)
                .ProjectTo<ClientLookupModel>(this.mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var estates = await this.estatesRepository
                .AllAsNoTracking()
                .Where(p => p.Estate_Name.ToLower().Contains(queryNormalized))
                .OrderBy(p => p.Name)
                .ProjectTo<EstateLookupModel>(this.mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var listings = await this.listingsRepository
              .AllAsNoTracking()
              .Where(p => p.Name.ToLower().Contains(queryNormalized))
              .OrderBy(p => p.Name)
              .ProjectTo<ListingLookupModel>(this.mapper.ConfigurationProvider)
              .ToListAsync(cancellationToken);

            var dataModel = new SearchViewModel
            {
                SearchQuery = request.Query,
                Clients = clients,
                Estates = estates,
                Listings = listings
            };

            return dataModel;
        }
    }
}
