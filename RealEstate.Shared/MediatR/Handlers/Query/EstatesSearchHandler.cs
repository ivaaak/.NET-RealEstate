#nullable disable
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
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public EstatesSearchHandler(
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

            var estates = await repository
                .All<Estate>()
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
