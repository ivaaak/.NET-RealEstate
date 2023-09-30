using RealEstate.Shared.Data.Cache;
using RealEstate.Shared.Data.Context;

namespace RealEstate.Shared.Data.Repository
{
    public class ApplicationDbRepository : Repository, IApplicationDbRepository
    {
        public ApplicationDbRepository(CombinedAppContext context, ICacheService cacheService)
        {
            Context = context;
            _cacheService = cacheService;
        }
    }
}
