using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data.Repository;
using RealEstate.Infrastructure.LookupModels;
using RealEstate.MediatR.Queries;
using RealEstate.Models.Entities.Estates;
using RealEstate.Models.ViewModels.Search;

namespace RealEstate.MediatR.Handlers.Query
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

            var estates = await estatesRepository
                .AllAsNoTracking()
                .Where(p => p.Estate_Name
                    .ToLower()
                    .Contains(queryNormalized))
                .OrderBy(p => p.Estate_Name)
                .ProjectTo<EstateLookupModel>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var dataModel = new SearchViewModel
            {
                SearchQuery = request.Query,
                Estates = (IEnumerable<Estate>)estates,
            };

            return dataModel;
        }
    }
}
