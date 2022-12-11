using MediatR;
using RealEstate.CQRS.Queries;
using RealEstate.Data.Repository;
using RealEstate.Models.Entities.Estates;
using RealEstate.Models.ViewModels.Estates;

namespace RealEstate.CQRS.Handlers.Query
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
