using ClientsMicroservice.Data.Context;
using RealEstate.Shared.Data.Cache;

namespace RealEstate.Shared.Data.Repository
{
    public class ClientsDbRepository : Repository, IClientsDbRepository
    {
        public ClientsDbRepository(ClientsDBContext context, ICacheService cacheService)
        {
            Context = context;
            _cacheService = cacheService;
        }
    }
}
