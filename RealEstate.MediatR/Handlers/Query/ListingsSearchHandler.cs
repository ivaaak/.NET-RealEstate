using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data.Repository;
using RealEstate.Infrastructure.LookupModels;
using RealEstate.MediatR.Queries;
using RealEstate.Models.DTOs.Search;
using RealEstate.Models.Entities.Listings;

namespace RealEstate.MediatR.Handlers.Query
{
    public class ListingsSearchHandler : IRequestHandler<CombinedSearchQuery, SearchDTO>
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

        public async Task<SearchDTO> Handle(CombinedSearchQuery request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrWhiteSpace(request.Query))
            {
                //throw new InvalidSearchQueryException();
            }

            var queryNormalized = request.Query.ToLower();

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
                Listings = (IEnumerable<Listing>)listings
            };

            return dataModel;
        }
    }
}
