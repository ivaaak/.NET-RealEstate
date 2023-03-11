using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.MediatR.Queries;
using RealEstate.Shared.Models.DTOs.Estates;
using RealEstate.Shared.Models.DTOs.Search;
using RealEstate.Shared.Models.Entities.Estates;

namespace RealEstate.Shared.MediatR.Handlers.Query
{
    public class EstatesSearchHandler : IRequestHandler<CombinedSearchQuery, SearchDTO>
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

        public async Task<SearchDTO> Handle(CombinedSearchQuery request, CancellationToken cancellationToken)
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
                .ProjectTo<EstateDTO>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var dataModel = new SearchDTO
            {
                SearchQuery = request.Query,
                Estates = (IEnumerable<Estate>)estates,
            };

            return dataModel;
        }
    }
}
