using MediatR;
using RealEstate.CQRS.Queries;
using RealEstate.Data.Repository;
using RealEstate.Models.Entities.Estates;
using RealEstate.Models.ViewModels.Estates;

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
