using MediatR;
using RealEstate.Core.ViewModels;
using RealEstate.CQRS.Queries;
using RealEstate.Infrastructure.Data;
using RealEstate.Infrastructure.Data.Repositories;

namespace RealEstate.CQRS.Handlers
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
            // how get ID???
            int id = query.Id;

            var property = await Task.FromResult(repo.GetByIdAsync<Property>(id).Result);

            var propVM = new PropertyViewModel //add automapper
            {
                Id = property.Id,
                Agent = property.Agent,
                AgentId = property.AgentId,
                Category = property.Category,
                CategoryId = property.CategoryId,
                DateBuilt = property.DateBuilt,
                DateListed = property.DateListed,
                Description = property.Description,
                ImageUrl = property.ImageUrl,
                IsPublic = property.IsPublic,
                PropertyType = property.PropertyType,
                SquareMeters = property.SquareMeters,
                Title = property.Title,
                Year = property.Year,
            };
            return propVM;
        }
    }
}
