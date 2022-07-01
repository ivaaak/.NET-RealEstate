using MediatR;
using RealEstate.Core.Models;
using RealEstate.CQRS.Queries;
using RealEstate.Infrastructure.Data;
using RealEstate.Infrastructure.Data.Repositories;

namespace RealEstate.CQRS.Handlers
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
               repo.All<Property>()
                   .Select(p => new PropertyViewModel
                   {
                       Id = p.Id,
                       Agent = p.Agent,
                       AgentId = p.AgentId,
                       Category = p.Category,
                       CategoryId = p.CategoryId,
                       DateBuilt = p.DateBuilt,
                       DateListed = p.DateListed,
                       Description = p.Description,
                       ImageUrl = p.ImageUrl,
                       IsPublic = p.IsPublic,
                       PropertyType = p.PropertyType,
                       SquareMeters = p.SquareMeters,
                       Title = p.Title,
                       Year = p.Year
                   })
               .ToList());
        }
    }
}
