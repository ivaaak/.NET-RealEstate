using ContractsMicroservice.Data.Context;

namespace RealEstate.Shared.Data.Repository
{
    public class ContractsDbRepository : Repository, IContractsDbRepository
    {
        public ContractsDbRepository(ContractsDBContext context)
        {
            Context = context;
        }
    }
}
