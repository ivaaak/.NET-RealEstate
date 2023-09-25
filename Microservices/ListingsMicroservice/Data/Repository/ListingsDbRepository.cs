using ListingsMicroservice.Data.Context;
using ListingsMicroservice.Data.Repository;
using RealEstate.Shared.Data.Cache;

namespace RealEstate.Shared.Data.Repository
{
    public class ListingsDbRepository : Repository, IListingsDbRepository
    {
        public ListingsDbRepository(ListingsDBContext context, ICacheService cacheService)
        {
            Context = context; 
            _cacheService = cacheService;
        }
    }
}
