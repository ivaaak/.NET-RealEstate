using MediatR;
using RealEstate.Core.ViewModels.Estates;
using RealEstate.CQRS.Queries;
using RealEstate.Infrastructure.Entities.Estates;
using RealEstate.Infrastructure.Repositories;

namespace RealEstate.CQRS.Handlers.Query
{
    public class GetEstateByIdHandler : IRequestHandler<GetEstateByIdQuery, EstateViewModel>
    {
        private readonly IApplicationDbRepository repo;

        public GetEstateByIdHandler(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<EstateViewModel> Handle(GetEstateByIdQuery query, CancellationToken cancellationToken)
        {
            int id = query.Id;

            var property = await Task.FromResult(repo.GetByIdAsync<Estate>(id).Result);

            var propVM = new EstateViewModel //add automapper
            {
                Id = property.Id,
                //AUTOMAPPER
            };
            return propVM;
        }
    }
}
