using RealEstate.Infrastructure.Context;

namespace RealEstate.Infrastructure.Repositories
{
    public class ApplicationDbRepository : Repository, IApplicationDbRepository
    {
        public ApplicationDbRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }
    }
}
