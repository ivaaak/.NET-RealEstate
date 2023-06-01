#nullable disable
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.MediatR.Queries;
using RealEstate.Shared.Models.DTOs.Listings;
using RealEstate.Shared.Models.DTOs.Search;
using RealEstate.Shared.Models.Entities.Listings;

namespace RealEstate.Shared.MediatR.Handlers.Query
{
    public class ListingsSearchHandler : IRequestHandler<CombinedSearchQuery, SearchDTO>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public ListingsSearchHandler(
            IRepository repository,
            IMapper mapper)
        {
            this.repository = repository;
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

            var listings = await repository
              .All<Listing>()
              .Where(p => p.Name
                    .ToLower()
                    .Contains(queryNormalized))
              .OrderBy(p => p.Name)
              .ProjectTo<ListingDTO>(mapper.ConfigurationProvider)
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
