using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Data.Context;

namespace RealEstate.Shared.Data.Repository
{
    public class EstatesDbRepository : Repository, IEstatesDbRepository
    {
        public EstatesDbRepository(EstatesDBContext context)
        {
            Context = context;
        }
    }
}
