using MediatR;
using RealEstate.Data.Repository;
using RealEstate.MediatR.Queries;
using RealEstate.Models.DTOs.Estates;
using RealEstate.Models.Entities.Estates;

namespace RealEstate.MediatR.Handlers.Query
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
