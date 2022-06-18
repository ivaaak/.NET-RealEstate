using Microsoft.EntityFrameworkCore;
using RealEstate.Core.Contracts;
using RealEstate.Core.Models;
using RealEstate.Infrastructure.Data;
using RealEstate.Infrastructure.Data.Repositories;

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
