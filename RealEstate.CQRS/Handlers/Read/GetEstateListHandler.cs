using MediatR;
using RealEstate.Core.ViewModels.Estates;
using RealEstate.CQRS.Queries;
using RealEstate.Infrastructure.Entities.Estates;
using RealEstate.Infrastructure.Repositories;

namespace RealEstate.CQRS.Handlers.Read
{
    public class GetEstateListHandler : IRequestHandler<GetEstateListQuery, List<EstateViewModel>>
    {
        private readonly IApplicationDbRepository repo;

        public GetEstateListHandler(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<List<EstateViewModel>> Handle(GetEstateListQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(
               repo.All<Estate>()
                   .Select(p => new EstateViewModel
                   {
                       Id = p.Id,
                       //AUTOMAPPER
                   })
               .ToList());
        }
    }
}
