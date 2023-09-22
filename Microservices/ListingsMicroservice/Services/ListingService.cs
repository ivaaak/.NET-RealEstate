#nullable disable
using ListingsMicroservice.Data.Repository;
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Models.DTOs.Listings;
using RealEstate.Shared.Models.Entities.Listings;

namespace ListingsMicroservice.Services
{
    public class ListingService : IListingService
    {
        private readonly IListingsDbRepository repo;

        public ListingService(IListingsDbRepository _repo)
        {
            repo = _repo;
        }


        // CREATE
        public async Task<Listing> Create(Listing model)
        {
            await repo.AddAsync(model);
            return model;
        }

        // GET BY ID
        public async Task<Listing> GetListingById(int id)
        {
            return await repo.GetByIdAsync<Listing>(id);
        }

        // GET FOR EDIT
        public async Task<ListingDTO> GetListingForEdit(int id)
        {
            var listing = await repo.GetByIdAsync<Listing>(id);

            return new ListingDTO()
            {
                Id = listing.Id,
                ImageUrl = listing.ImageUrl,
                Estate_Type = listing.Estate_Type,
                IsPublic = listing.IsPublic,
                Description = listing.Description,
            };
        }

        // GET ALL
        public async Task<IEnumerable<ListingDTO>> GetListings()
        {
            return await repo.All<Listing>()
            .Select(listing => new ListingDTO()
            {
                Id = listing.Id,
                Name = listing.Name,
                ImageUrl = listing.ImageUrl,
                Estate_Type = listing.Estate_Type,
                IsPublic = listing.IsPublic,
                SquareMeters = listing.Estate.Floor_Space_Square_Meters,
                Description = listing.Description,
            })
            .ToListAsync();
        }

        // UPDATE
        public async Task<bool> UpdateListing(ListingDTO model)
        {
            bool result = false;
            var listing = await repo.GetByIdAsync<Listing>(model.Id);

            if (listing != null)
            {
                listing.Name = model.Name;
                listing.ImageUrl = model.ImageUrl;
                listing.IsPublic = model.IsPublic;
                listing.Estate.Floor_Space_Square_Meters = model.SquareMeters;
                listing.Description = model.Description;

                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        // HARD DELETE
        public async Task<bool> DeleteListing(int id)
        {
            bool result = false;
            var listing = await repo.GetByIdAsync<Listing>(id);

            if (listing != null)
            {
                repo.Delete(listing);
                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        // SOFT DELETE
        public async Task<bool> SoftDeleteListing(int id)
        {
            bool result = false;
            var listing = await repo.GetByIdAsync<Listing>(id);

            if (listing != null)
            {
                listing.IsDeleted = true;
                listing.DeletedOn = DateTime.UtcNow;
                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }


        // SEARCH 
        public async Task<IEnumerable<ListingDTO>> SearchListings(string searchTerm)
        {
            // Build a LINQ query to search the repository for listings that match the search term
            var query = from listing in repo.All<Listing>()
                        where
                listing.Name.Contains(searchTerm) ||
                listing.Description.Contains(searchTerm) ||
                listing.Estate_Type.ToString().Contains(searchTerm) ||
                listing.Estate.Estate_Name.Contains(searchTerm) ||
                listing.Estate.Estate_Description.Contains(searchTerm) ||
                listing.Estate.City.ToString().Contains(searchTerm)
                        select listing;

            // Execute the query and return the matching listings as a list of ListingViewModel objects
            return await query.Select(listing => new ListingDTO()
            {
                Id = listing.Id,
                Name = listing.Name,
                ImageUrl = listing.ImageUrl,
                Estate_Type = listing.Estate_Type,
                IsPublic = listing.IsPublic,
                SquareMeters = listing.Estate.Floor_Space_Square_Meters,
                Description = listing.Description,
            }).ToListAsync();
        }
    }
}
