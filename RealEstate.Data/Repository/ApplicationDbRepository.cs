using RealEstate.Data.Context;

namespace RealEstate.Data.Repository
{
    public class ApplicationDbRepository : Repository, IApplicationDbRepository
    {
        public ApplicationDbRepository(_CombinedContext context)
        {
            Context = context;
        }
    }
}
