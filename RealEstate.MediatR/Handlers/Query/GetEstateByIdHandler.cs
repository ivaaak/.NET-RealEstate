using MediatR;
using RealEstate.Data.Repository;
using RealEstate.MediatR.Queries;
using RealEstate.Models.DTOs.Estates;
using RealEstate.Models.Entities.Estates;

namespace RealEstate.MediatR.Handlers.Query
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
