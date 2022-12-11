using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.CQRS.Queries;
using RealEstate.Data.Repository;
using RealEstate.Infrastructure.LookupModels;
using RealEstate.Models.Entities.Clients;
using RealEstate.Models.ViewModels.Search;

namespace RealEstate.CQRS.Handlers.Query
{
    public class ClientSearchHandler : IRequestHandler<CombinedSearchQuery, SearchViewModel>
    {
        private readonly IDeletableEntityRepository<Client> clientsRepository;
        private readonly IMapper mapper;

        public ClientSearchHandler(
            IDeletableEntityRepository<Client> clientsRepository,
            IMapper mapper)
        {
            this.clientsRepository = clientsRepository;
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
                .Where(p => p.UserName
                    .ToLower()
                    .Contains(queryNormalized))
                .OrderBy(p => p.UserName)
                .ProjectTo<ClientLookupModel>(this.mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);


            var dataModel = new SearchViewModel
            {
                SearchQuery = request.Query,
                Clients = (IEnumerable<Client>)clients,
            };

            return dataModel;
        }
    }
}
