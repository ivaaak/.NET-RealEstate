using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.MediatR.Commands.Create;
using RealEstate.MediatR.Commands.Delete;
using RealEstate.MediatR.Queries;
using RealEstate.Data.Repository;
using RealEstate.MediatR.BehaviorModels.ResponseModels;
using RealEstate.Models.Entities.Estates;
using RealEstate.Models.ViewModels.Estates;
using RealEstate.Models.ViewModels.Search;

namespace RealEstate.Microservices.Estates
{
    public class EstateService : IEstateService
    {
        private readonly IRepository repo;

        private IMediator mediator;

        public EstateService(
            IRepository _repo,
            IMediator _mediator)
        {
            repo = _repo;
            mediator = _mediator;
        }

        // CREATE
        public async void Create(Estate model)
        {
            await repo.AddAsync(model);
        }

        // GET BY ID
        public async Task<Estate> GetEstateById(int id)
        {
            return await repo.GetByIdAsync<Estate>(id);
        }

        // GET FOR EDIT
        public async Task<EstateDTO> GetEstateForEdit(int id)
        {
            var estate = await repo.GetByIdAsync<Estate>(id);

            return new EstateDTO()
            {
                Id = estate.Id,
                Estate_Name = estate.Estate_Name,
                City_Id = estate.City_Id,
                City = estate.City,
                Estate_Type_Id = estate.Estate_Type_Id,
                Floor_Space = estate.Floor_Space_Square_Meters,
                Number_Of_Balconies = estate.Number_Of_Balconies,
                Balconies_Space = estate.Balconies_Space,
                Number_Of_Bedrooms = estate.Number_Of_Bedrooms,
                Number_Of_Bathrooms = estate.Number_Of_Bathrooms,
                Number_Of_Garages = estate.Number_Of_Garages,
                Number_Of_Parking_Spaces = estate.Number_Of_Parking_Spaces,
                Pets_Allowed = estate.Pets_Allowed,
                Estate_Description = estate.Estate_Description,
                Estate_Status_Id = estate.Estate_Status_Id,
                Estate_ImageUrl = estate.Estate_ImageUrl,
                Estate_Year_Built = estate.Estate_Year_Built,
                Estate_Year_Listed = estate.Estate_Year_Listed,
                Listing = estate.Listing,
                Estate_Type = estate.Estate_Type,
            };
        }

        // GET ALL
        public async Task<IEnumerable<EstateDTO>> GetEstates()
        {
            return await repo.All<Estate>()
            .Select(e => new EstateDTO()
            {
                Id = e.Id,
                Estate_Name = e.Estate_Name,
                City_Id = e.City_Id,
                City = e.City,
                Estate_Type_Id = e.Estate_Type_Id,
                Floor_Space = e.Floor_Space_Square_Meters,
                Number_Of_Balconies = e.Number_Of_Balconies,
                Balconies_Space = e.Balconies_Space,
                Number_Of_Bedrooms = e.Number_Of_Bedrooms,
                Number_Of_Bathrooms = e.Number_Of_Bathrooms,
                Number_Of_Garages = e.Number_Of_Garages,
                Number_Of_Parking_Spaces = e.Number_Of_Parking_Spaces,
                Pets_Allowed = e.Pets_Allowed,
                Estate_Description = e.Estate_Description,
                Estate_Status_Id = e.Estate_Status_Id,
                Estate_ImageUrl = e.Estate_ImageUrl,
                Estate_Year_Built = e.Estate_Year_Built,
                Estate_Year_Listed = e.Estate_Year_Listed,
                Listing = e.Listing,
                Estate_Type = e.Estate_Type,
            })
            .ToListAsync();
        }

        // UPDATE
        public async Task<bool> UpdateEstate(int id, EstateDTO model)
        {
            bool result = false;
            // Search for the model using the id
            var estate = await repo.GetByIdAsync<Estate>(id);

            if (estate != null)
            {
                // Set the props to the new model
                estate.Estate_Name = model.Estate_Name;
                estate.City_Id = model.City_Id;
                estate.City = model.City;
                estate.Estate_Type_Id = model.Estate_Type_Id;
                estate.Floor_Space_Square_Meters = model.Floor_Space;
                estate.Number_Of_Balconies = model.Number_Of_Balconies;
                estate.Balconies_Space = model.Balconies_Space;
                estate.Number_Of_Bedrooms = model.Number_Of_Bedrooms;
                estate.Number_Of_Bathrooms = model.Number_Of_Bathrooms;
                estate.Number_Of_Garages = model.Number_Of_Garages;
                estate.Number_Of_Parking_Spaces = model.Number_Of_Parking_Spaces;
                estate.Pets_Allowed = model.Pets_Allowed;
                estate.Estate_Description = model.Estate_Description;
                estate.Estate_Status_Id = model.Estate_Status_Id;
                estate.Estate_ImageUrl = model.Estate_ImageUrl;
                estate.Estate_Year_Built = model.Estate_Year_Built;
                estate.Estate_Year_Listed = model.Estate_Year_Listed;
                estate.Listing = model.Listing;
                estate.Estate_Type = model.Estate_Type;

                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        // HARD DELETE
        public async Task<bool> HardDeleteEstate(int id)
        {
            bool result = false;
            var estate = await repo.GetByIdAsync<Estate>(id);

            if (estate != null)
            {
                repo.Delete(estate);
                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        // SOFT DELETE
        public async Task<bool> SoftDeleteEstate(int id)
        {
            bool result = false;
            var estate = await repo.GetByIdAsync<Estate>(id);

            if (estate != null)
            {
                estate.IsDeleted = true;
                estate.DeletedOn = DateTime.UtcNow;
                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        // SEARCH
        public async Task<IEnumerable<EstateDTO>> SearchEstates(string searchTerm)
        {
            return await repo.All<Estate>()
            .Where(e =>
                e.Estate_Name.Contains(searchTerm) ||
                e.Estate_Description.Contains(searchTerm) ||
                e.Estate_Type.Type_Name.Contains(searchTerm) ||
                e.Listing.Name.Contains(searchTerm))
            .Select(e => new EstateDTO()
            {
                Id = e.Id,
                Estate_Name = e.Estate_Name,
                City_Id = e.City_Id,
                City = e.City,
                Estate_Type_Id = e.Estate_Type_Id,
                Floor_Space = e.Floor_Space_Square_Meters,
                Number_Of_Balconies = e.Number_Of_Balconies,
                Balconies_Space = e.Balconies_Space,
                Number_Of_Bedrooms = e.Number_Of_Bedrooms,
                Number_Of_Bathrooms = e.Number_Of_Bathrooms,
                Number_Of_Garages = e.Number_Of_Garages,
                Number_Of_Parking_Spaces = e.Number_Of_Parking_Spaces,
                Pets_Allowed = e.Pets_Allowed,
                Estate_Description = e.Estate_Description,
                Estate_Status_Id = e.Estate_Status_Id,
                Estate_ImageUrl = e.Estate_ImageUrl,
                Estate_Year_Built = e.Estate_Year_Built,
                Estate_Year_Listed = e.Estate_Year_Listed,
                Listing = e.Listing,
                Estate_Type = e.Estate_Type,
            })
            .ToListAsync();
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

