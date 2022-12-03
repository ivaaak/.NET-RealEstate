using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using RealEstate.Core.Interfaces;
using RealEstate.Core.LookupModels;
using RealEstate.Core.ViewModels.Search;
using RealEstate.CQRS.Queries;
using RealEstate.Infrastructure.Entities.Listings;

namespace RealEstate.CQRS.Handlers.Query
{
    public class ListingsSearchHandler : IRequestHandler<CombinedSearchQuery, SearchViewModel>
    {
        private readonly IDeletableEntityRepository<Listing> listingsRepository;
        private readonly IMapper mapper;

        public ListingsSearchHandler(
            IDeletableEntityRepository<Listing> listingsRepository,
            IMapper mapper)
        {
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

            var listings = await this.listingsRepository
              .AllAsNoTracking()
              .Where(p => p.Name
                    .ToLower()
                    .Contains(queryNormalized))
              .OrderBy(p => p.Name)
              .ProjectTo<ListingsLookupModel>(this.mapper.ConfigurationProvider)
              .ToListAsync(cancellationToken);

            var dataModel = new SearchViewModel
            {
                SearchQuery = request.Query,
                Listings = listings
            };

            return dataModel;
        }
    }
}
