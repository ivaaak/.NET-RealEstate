using RealEstate.Shared.Data.Context;

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
