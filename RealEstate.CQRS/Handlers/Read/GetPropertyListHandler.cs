using MediatR;
using RealEstate.Core.ViewModels;
using RealEstate.CQRS.Queries;
using RealEstate.Infrastructure.Data;
using RealEstate.Infrastructure.Entities;
using RealEstate.Infrastructure.Entities.Estates;
using RealEstate.Infrastructure.Repositories;

namespace RealEstate.CQRS.Handlers.Get
{
    public class GetPropertyListHandler : IRequestHandler<GetPropertyListQuery, List<PropertyViewModel>>
    {
        private readonly IApplicationDbRepository repo;

        public GetPropertyListHandler(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<List<PropertyViewModel>> Handle(GetPropertyListQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(
               repo.All<Estate>()
                   .Select(p => new PropertyViewModel
                   {
                       Id = p.Id,
                       //AUTOMAPPER
                   })
               .ToList());
        }
    }
}
