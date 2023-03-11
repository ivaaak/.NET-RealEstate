using MediatR;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.MediatR.Queries;
using RealEstate.Shared.Models.DTOs.Estates;
using RealEstate.Shared.Models.Entities.Estates;

namespace RealEstate.Shared.MediatR.Handlers.Query
{
    public class GetEstateListHandler : IRequestHandler<GetEstateListQuery, List<EstateDTO>>
    {
        private readonly IApplicationDbRepository repo;

        public GetEstateListHandler(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<List<EstateDTO>> Handle(GetEstateListQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(
               repo.All<Estate>()
                   .Select(p => new EstateDTO
                   {
                       Id = p.Id,
                       //AUTOMAPPER
                   })
               .ToList());
        }
    }
}
