using AutoMapper;
using AutoMapper.QueryableExtensions;

using MediatR;
using RealEstate.Core.ViewModels.Search;
using RealEstate.CQRS.Queries;
using RealEstate.Infrastructure.Entities.Clients;
using RealEstate.Infrastructure.Entities.Estates;
using RealEstate.Infrastructure.Entities.Listings;

namespace RealEstate.CQRS.Handlers.Query
{
    public class SearchHandler : IRequestHandler<SearchQuery, SearchViewModel>
    {
        //change to IDeletableEntityRepository;
        private readonly List<Client> clientsRepository;
        private readonly List<Estate> estatesRepository;
        private readonly List<Listing> listingsRepository;
        private readonly IMapper mapper;

        public SearchHandler(
            List<Client> clientsRepository,
            List<Estate> estatesRepository,
            List<Listing> listingsRepository,
            IMapper mapper)
        {
            this.clientsRepository = clientsRepository;
            this.estatesRepository = estatesRepository;
            this.listingsRepository = listingsRepository;
            this.mapper = mapper;
        }

        public async Task<SearchViewModel> Handle(SearchQuery request, CancellationToken cancellationToken)
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
                .Where(p => p.Name.ToLower().Contains(queryNormalized))
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
