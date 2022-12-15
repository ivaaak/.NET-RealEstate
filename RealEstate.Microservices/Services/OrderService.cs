using RealEstate.Data.Repository;
using RealEstate.Microservices.Contracts;

namespace RealEstate.Microservices.Services
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
