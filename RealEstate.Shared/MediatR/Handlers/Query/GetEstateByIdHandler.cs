using MediatR;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.MediatR.Queries;
using RealEstate.Shared.Models.DTOs.Estates;
using RealEstate.Shared.Models.Entities.Estates;

namespace RealEstate.Shared.MediatR.Handlers.Query
{
    public class GetEstateByIdHandler : IRequestHandler<GetEstateByIdQuery, EstateDTO>
    {
        private readonly IApplicationDbRepository repo;

        public GetEstateByIdHandler(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<EstateDTO> Handle(GetEstateByIdQuery query, CancellationToken cancellationToken)
        {
            int id = query.Id;

            var property = await Task.FromResult(repo.GetByIdAsync<Estate>(id).Result);

            var propVM = new EstateDTO //add automapper
            {
                Id = property.Id,
                //AUTOMAPPER
            };
            return propVM;
        }
    }
}
