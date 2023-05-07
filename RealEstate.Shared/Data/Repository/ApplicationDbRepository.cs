using Microsoft.EntityFrameworkCore;

namespace RealEstate.Shared.Data.Repository
{
    public class ApplicationDbRepository : Repository, IApplicationDbRepository
    {
        public ApplicationDbRepository(DbContext context)
        {
            Context = context;
        }
    }
}
