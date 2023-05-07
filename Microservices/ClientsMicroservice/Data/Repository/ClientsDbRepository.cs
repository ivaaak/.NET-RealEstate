using ClientsMicroservice.Data.Context;

namespace RealEstate.Shared.Data.Repository
{
    public class ClientsDbRepository : Repository, IClientsDbRepository
    {
        public ClientsDbRepository(ClientsDBContext context)
        {
            Context = context;
        }
    }
}
