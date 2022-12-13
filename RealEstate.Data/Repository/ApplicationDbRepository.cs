using RealEstate.Data.Context;

namespace RealEstate.Data.Repository
{
    public class ApplicationDbRepository : Repository, IApplicationDbRepository
    {
        public ApplicationDbRepository(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}
