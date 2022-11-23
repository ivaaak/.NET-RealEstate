using MediatR;
using RealEstate.Core.ViewModels;
using RealEstate.CQRS.Queries;
using RealEstate.Infrastructure.Entities.Estates;
using RealEstate.Infrastructure.Repositories;

namespace RealEstate.CQRS.Handlers.Get
{
    public class GetPropertyByIdHandler : IRequestHandler<GetPropertyByIdQuery, PropertyViewModel>
    {
        private readonly IApplicationDbRepository repo;

        public GetPropertyByIdHandler(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<PropertyViewModel> Handle(GetPropertyByIdQuery query, CancellationToken cancellationToken)
        {
            int id = query.Id;

            var property = await Task.FromResult(repo.GetByIdAsync<Estate>(id).Result);

            var propVM = new PropertyViewModel //add automapper
            {
                Id = property.Id,
                //AUTOMAPPER
            };
            return propVM;
        }
    }
}
