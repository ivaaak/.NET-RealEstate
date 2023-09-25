using ContractsMicroservice.Data.Context;
using RealEstate.Shared.Data.Cache;

namespace RealEstate.Shared.Data.Repository
{
    public class ContractsDbRepository : Repository, IContractsDbRepository
    {
        public ContractsDbRepository(ContractsDBContext context, ICacheService cacheService)
        {
            Context = context;
            _cacheService = cacheService;
        }
    }
}
