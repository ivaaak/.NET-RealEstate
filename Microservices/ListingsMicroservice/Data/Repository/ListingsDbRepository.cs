using ListingsMicroservice.Data.Context;
using ListingsMicroservice.Data.Repository;

namespace RealEstate.Shared.Data.Repository
{
    public class ListingsDbRepository : Repository, IListingsDbRepository
    {
        public ListingsDbRepository(ListingsDBContext context)
        {
            Context = context;
        }
    }
}
