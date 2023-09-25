using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Data.Cache;

namespace RealEstate.Shared.Data.Repository
{
    public class ApplicationDbRepository : Repository, IApplicationDbRepository
    {
        public ApplicationDbRepository(DbContext context, ICacheService cacheService)
        {
            Context = context;
            _cacheService = cacheService;
        }
    }
}
