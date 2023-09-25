using RealEstate.Shared.Data.Cache;
using RealEstate.Shared.Data.Context;

namespace RealEstate.Shared.Data.Repository
{
    public class EstatesDbRepository : Repository, IEstatesDbRepository
    {
        public EstatesDbRepository(EstatesDBContext context, ICacheService cacheService)
        {
            Context = context;
            _cacheService = cacheService;
        }
    }
}
