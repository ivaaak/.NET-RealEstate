using Microsoft.EntityFrameworkCore;
using RealEstate.Data.Repository;
using RealEstate.Models.Entities.Estates;
using RealEstate.Models.Entities.Listings;
using RealEstate.Models.ViewModels.Listings;

namespace RealEstate.Microservices.Listings
{
    public class ListingService : IListingService
    {
        private readonly IApplicationDbRepository repo;

        public ListingService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }


        // CREATE
        public async void Create(Listing model)
        {
            await repo.AddAsync(model);
        }

        // GET BY ID
        public async Task<Listing> GetListingById(int id)
        {
            return await repo.GetByIdAsync<Listing>(id);
        }

        // GET FOR EDIT
        public async Task<ListingViewModel> GetListingForEdit(int id)
        {
            var listing = await repo.GetByIdAsync<Listing>(id);

            return new ListingViewModel()
            {
                Id = listing.Id,
                Title = listing.Title,
                ImageUrl = listing.ImageUrl,
                Estate_Type = listing.Estate_Type,
                IsPublic = listing.IsPublic,
                SquareMeters = listing.SquareMeters,
                Description = listing.Description,
            };
        }

        // GET ALL
        public async Task<IEnumerable<ListingViewModel>> GetListings()
        {
            return await repo.All<Listing>()
            .Select(listing => new ListingViewModel()
            {
                Id = listing.Id,
                Title = listing.Title,
                ImageUrl = listing.ImageUrl,
                Estate_Type = listing.Estate_Type,
                IsPublic = listing.IsPublic,
                SquareMeters = listing.SquareMeters,
                Description = listing.Description,
            })
            .ToListAsync();
        }

        // UPDATE
        public async Task<bool> UpdateListing(ListingViewModel model)
        {
            bool result = false;
            var listing = await repo.GetByIdAsync<Listing>(model.Id);

            if (listing != null)
            {
                listing.Title = model.Title;
                listing.ImageUrl = model.ImageUrl;
                listing.IsPublic = model.IsPublic;
                listing.SquareMeters = model.SquareMeters;
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
        public async Task<IEnumerable<ListingViewModel>> SearchListings(string searchTerm)
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
            return await query.Select(listing => new ListingViewModel()
            {
                Id = listing.Id,
                Title = listing.Title,
                ImageUrl = listing.ImageUrl,
                Estate_Type = listing.Estate_Type,
                IsPublic = listing.IsPublic,
                SquareMeters = listing.SquareMeters,
                Description = listing.Description,
            }).ToListAsync();
        }
    }
}
