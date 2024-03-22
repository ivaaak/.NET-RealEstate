#nullable disable
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Models.Entities.Estates;
using RealEstate.Shared.Models.Entities.Misc;

namespace ListingsMicroservice.Services.Filtration
{
    // Unused way of filtering as a showcase
    public class EstateFiltrationService : IFiltrationService
    {
        public IEnumerable<Estate> FilterEstatesForRange(IEnumerable<Estate> estates,
            string estateName = null, string cityId = null, int estateTypeId = 0,
            decimal minFloorSpace = 0, decimal maxFloorSpace = decimal.MaxValue,
            int minNumberOfBalconies = 0, int maxNumberOfBalconies = int.MaxValue,
            decimal minBalconiesSpace = 0, decimal maxBalconiesSpace = decimal.MaxValue,
            int minNumberOfBedrooms = 0, int maxNumberOfBedrooms = int.MaxValue,
            int minNumberOfBathrooms = 0, int maxNumberOfBathrooms = int.MaxValue,
            int minNumberOfGarages = 0, int maxNumberOfGarages = int.MaxValue,
            int minNumberOfParkingSpaces = 0, int maxNumberOfParkingSpaces = int.MaxValue,
            bool? petsAllowed = null, string estateStatusId = null,
            int minEstateYearBuilt = 0, int maxEstateYearBuilt = int.MaxValue,
            int minEstateYearListed = 0, int maxEstateYearListed = int.MaxValue,
            bool onlyNotDeleted = true)
        {
            IEnumerable<Estate> filteredEstates = estates;

            if (onlyNotDeleted)
            {
                filteredEstates = filteredEstates.Where(x => !x.IsDeleted);
            }

            if (estateName != null)
            {
                filteredEstates = filteredEstates.Where(x => x.Name.Contains(estateName));
            }

            if (cityId.Length > 0)
            {
                filteredEstates = filteredEstates.Where(x => x.City_Id == cityId);
            }

            filteredEstates = filteredEstates
                .Where(x => x.Floor_Space_Square_Meters >= minFloorSpace && x.Floor_Space_Square_Meters <= maxFloorSpace);

            filteredEstates = filteredEstates
                .Where(x => x.Balconies >= minNumberOfBalconies && x.Balconies <= maxNumberOfBalconies);

            filteredEstates = filteredEstates
                .Where(x => x.Bedrooms >= minNumberOfBedrooms && x.Bedrooms <= maxNumberOfBedrooms);

            filteredEstates = filteredEstates
                .Where(x => x.Bathrooms >= minNumberOfBathrooms && x.Bathrooms <= maxNumberOfBedrooms);

            // ... more property checks
            return estates;
        }


        // Filter using an object
        public async Task<List<Estate>> FilterEstatesExact(IQueryable<Estate> estates, EstateFilter filter)
        {
            var query = estates;

            if (filter.Name.Length > 0)
            {
                query = query.Where(x => x.Name.Contains(filter.Name.ToString()));
            }

            if (filter.Summary.Length > 0)
            {
                query = query.Where(x => x.Summary.Contains(filter.Summary.ToString()));
            }

            if (filter.Pets_Allowed)
            {
                query = query.Where(x => x.Pets_Allowed == filter.Pets_Allowed);
            }

            if (filter.City_Id.Length > 0)
            {
                query = query.Where(x => x.City_Id == filter.City_Id);
            }


            if (filter.Bedrooms != 0)
            {
                query = query.Where(x => x.Bedrooms == filter.Bedrooms);
            }

            if (filter.Bathrooms != 0)
            {
                query = query.Where(x => x.Bathrooms == filter.Bathrooms);
            }

            if (filter.Balconies != 0)
            {
                query = query.Where(x => x.Balconies == filter.Balconies);
            }

            if (filter.Garages != 0)
            {
                query = query.Where(x => x.Garages == filter.Garages);
            }

            return await query.ToListAsync();
        }

        /*
        var filter = new EstateFilter
        {
            CityId = 1,
            EstateTypeId = 2,
            NumberOfBedrooms = 3,
            NumberOfBathrooms = 2
        };

        var filteredEstates = await FilterEstates(estates, filter);
        */
    }
}
