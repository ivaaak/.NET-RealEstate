using MediatR;
using RealEstate.Data.Repository;
using RealEstate.MediatR.Queries;
using RealEstate.Models.Entities.Estates;
using RealEstate.Models.ViewModels.Estates;

namespace RealEstate.MediatR.Handlers.Query
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
