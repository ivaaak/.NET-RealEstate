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
    public class EstatesSearchHandler : IRequestHandler<CombinedSearchQuery, SearchViewModel>
    {
        private readonly IDeletableEntityRepository<Estate> estatesRepository;
        private readonly IMapper mapper;

        public EstatesSearchHandler(
            IDeletableEntityRepository<Estate> estatesRepository,
            IMapper mapper)
        {
            this.estatesRepository = estatesRepository;
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

            var estates = await this.estatesRepository
                .AllAsNoTracking()
                .Where(p => p.Name.ToLower().Contains(queryNormalized))
                .OrderBy(p => p.Name)
                .ProjectTo<EstateLookupModel>(this.mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var dataModel = new SearchViewModel
            {
                SearchQuery = request.Query,
                Estates = estates,
            };

            return dataModel;
        }
    }
}
