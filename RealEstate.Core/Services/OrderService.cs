using RealEstate.Core.ServiceContracts;
using RealEstate.Infrastructure.Repositories;

namespace RealEstate.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IApplicationDbRepository repo;

        public OrderService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }
        

    }
}
