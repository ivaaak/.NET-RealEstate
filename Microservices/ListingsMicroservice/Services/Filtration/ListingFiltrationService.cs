using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Models.Entities.Listings;
using RealEstate.Shared.Models.Entities.Misc;

namespace ListingsMicroservice.Services.Filtration
{
    public class ListingFiltrationService : IFiltrationService
    {
        public async Task<List<Listing>> FilterListings(IQueryable<Listing> listings, ListingFilter filter, Listing x)
        {
            var query = listings;

            if (filter.Estate_Id.Any())
            {
                query = query.Where(x => x.Estate.Id == filter.Estate_Id);
            }

            if (filter.CategoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == filter.CategoryId.Value);
            }

            if (filter.Price.HasValue)
            {
                query = query.Where(x => x.Price <= filter.Price.Value);
            }

            if (filter.ExactSquareMeters.HasValue)
            {
                query = query.Where(x => x.Estate.Floor_Space_Square_Meters == filter.ExactSquareMeters.Value);
            }

            if (filter.MinSquareMeters.HasValue)
            {
                query = query.Where(x => x.Estate.Floor_Space_Square_Meters >= filter.MinSquareMeters.Value);
            }

            if (filter.MaxSquareMeters.HasValue)
            {
                query = query.Where(x => x.Estate.Floor_Space_Square_Meters <= filter.MaxSquareMeters.Value);
            }

            if (filter.MinPrice.HasValue)
            {
                query = query.Where(x => x.Price >= filter.MinPrice.Value);
            }

            if (filter.MaxPrice.HasValue)
            {
                query = query.Where(x => x.Price <= filter.MaxPrice.Value);
            }

            if (filter.MinPricePerSquareMeter.HasValue)
            {
                query = query.Where(x => x.PricePerSquareMeter >= filter.MinPricePerSquareMeter.Value);
            }

            if (filter.MaxPricePerSquareMeter.HasValue)
            {
                query = query.Where(x => x.PricePerSquareMeter <= filter.MaxPricePerSquareMeter.Value);
            }


            return await query.ToListAsync();
        }
        /*
        var filter = new ListingFilter
        {
            EstateId = 1,
            CategoryId = 2,
            Price = 100000,
            SquareMeters = 150
        };

        var filteredListings = await FilterListings(listings, filter);
        */
    }
}
