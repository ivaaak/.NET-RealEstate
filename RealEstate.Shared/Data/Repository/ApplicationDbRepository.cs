using RealEstate.Shared.Data.Context;

namespace RealEstate.Shared.Data.Repository
{
    public class ApplicationDbRepository : Repository, IApplicationDbRepository
    {
        public ApplicationDbRepository(_CombinedContext context)
        {
            Context = context;
        }
    }
}
