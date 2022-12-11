using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.CQRS.Queries;
using RealEstate.Data.Repository;
using RealEstate.Infrastructure.LookupModels;
using RealEstate.Models.Entities.Listings;
using RealEstate.Models.ViewModels.Search;

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
                Listings = (IEnumerable<Listing>)listings
            };

            return dataModel;
        }
    }
}
