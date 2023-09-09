using AutoMapper;
using EstatesMicroservice.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.MediatR.BehaviorModels.ResponseModels;
using RealEstate.Shared.MediatR.Commands.Create;
using RealEstate.Shared.MediatR.Commands.Delete;
using RealEstate.Shared.MediatR.Queries;
using RealEstate.Shared.Models.DTOs.Estates;
using RealEstate.Shared.Models.DTOs.Search;
using RealEstate.Shared.Models.Entities.Estates;

namespace EstatesMicroservice.Services
{
    public class EstateService : IEstateService
    {
        private readonly IRepository repository;

        private readonly IMapper mapper;

        private readonly IMediator mediator;

        public EstateService(
            IRepository repository,
            IMapper mapper,
            IMediator mediator)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        // CREATE
        public async Task Create(Estate model)
        {
            await repository.AddAsync(model);
        }

        // GET BY ID
        public async Task<Estate> GetEstateById(int id)
        {
            return await repository.GetByIdAsync<Estate>(id);
        }

        // GET FOR EDIT
        public async Task<EstateDTO> GetEstateForEdit(int id)
        {
            var estate = await repository.GetByIdAsync<Estate>(id);

            return mapper.Map<EstateDTO>(estate);
        }

        // GET ALL
        public async Task<IEnumerable<EstateDTO>> GetEstates()
        {
            var estates = await repository.All<Estate>().ToListAsync();

            return mapper.Map<IEnumerable<EstateDTO>>(estates);
        }

        // UPDATE
        public async Task<bool> UpdateEstate(int id, EstateDTO model)
        {
            // Search for the model using the id
            var estate = await repository.GetByIdAsync<Estate>(id);

            if (estate != null)
            {
                // Use AutoMapper to map properties from model to estate
                mapper.Map(model, estate);

                await repository.SaveChangesAsync();
                return true;
            }

            return false;
        }

        // HARD DELETE
        public async Task<bool> HardDeleteEstate(int id)
        {
            bool result = false;
            var estate = await repository.GetByIdAsync<Estate>(id);

            if (estate != null)
            {
                repository.Delete(estate);
                await repository.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        // SOFT DELETE
        public async Task<bool> SoftDeleteEstate(int id)
        {
            bool result = false;
            var estate = await repository.GetByIdAsync<Estate>(id);

            if (estate != null)
            {
                estate.IsDeleted = true;
                estate.DeletedOn = DateTime.UtcNow;
                await repository.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        // SEARCH
        public async Task<IEnumerable<EstateDTO>> SearchEstates(string searchTerm)
        {
            var estates = await repository.All<Estate>()
                .Where(e =>
                    e.Estate_Name.Contains(searchTerm) ||
                    e.Estate_Description.Contains(searchTerm) ||
                    e.Estate_Type.Type_Name.Contains(searchTerm) ||
                    e.Listing.Name.Contains(searchTerm))
                .ToListAsync();

            return mapper.Map<IEnumerable<EstateDTO>>(estates);
        }

        // SEARCH ASYNC Method
        public async Task<IEnumerable<EstateDTO>> SearchEstatesAsync(string searchTerm)
        {
            var estates = await repository.All<Estate>()
                .Where(e =>
                    e.Estate_Name.Contains(searchTerm) ||
                    e.Estate_Description.Contains(searchTerm) ||
                    e.Estate_Type.Type_Name.Contains(searchTerm) ||
                    e.Listing.Name.Contains(searchTerm))
                .ToListAsync();

            return estates.Select(e => mapper.Map<EstateDTO>(e));
        }

    // MEDIATOR 

        // MEDIATOR CREATE ESTATE
        public async Task<Response> MediatorCreateEstate(Estate estate)
        {
            return await mediator.Send(new CreateEstateCommand(estate));
        }

        // MEDIATOR GET BY ID
        public async Task<EstateDTO> MediatorGetEstateById(int id)
        {
            return await mediator.Send(new GetEstateByIdQuery(id));
        }

        // MEDIATOR GET ALL
        public async Task<List<EstateDTO>> MediatorGetEstates()
        {
            return await mediator.Send(new GetEstateListQuery());
        }

        // MEDIATOR DELETE
        public async Task<Response> MediatorDeleteEstate(int estateId)
        {
            return await mediator.Send(new DeleteEstateByIdCommand(estateId));
        }

        // MEDIATOR SEARCH
        public async Task<SearchDTO> MediatorSearchEstate(string query)
        {
            return await mediator.Send(new EstatesSearchQuery(query));
        }
    }
}

