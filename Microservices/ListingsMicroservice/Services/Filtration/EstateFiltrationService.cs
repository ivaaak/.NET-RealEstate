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
            string estateName = null, int cityId = 0, int estateTypeId = 0,
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
                filteredEstates = filteredEstates.Where(x => x.Estate_Name.Contains(estateName));
            }

            if (cityId != 0)
            {
                filteredEstates = filteredEstates.Where(x => x.City_Id == cityId);
            }

            if (estateTypeId != 0)
            {
                filteredEstates = filteredEstates.Where(x => x.Estate_Type_Id == estateTypeId);
            }

            filteredEstates = filteredEstates
                .Where(x => x.Floor_Space_Square_Meters >= minFloorSpace && x.Floor_Space_Square_Meters <= maxFloorSpace);

            filteredEstates = filteredEstates
                .Where(x => x.Number_Of_Balconies >= minNumberOfBalconies && x.Number_Of_Balconies <= maxNumberOfBalconies);

            filteredEstates = filteredEstates
                .Where(x => x.Balconies_Space >= minBalconiesSpace && x.Balconies_Space <= maxBalconiesSpace);

            filteredEstates = filteredEstates
                .Where(x => x.Number_Of_Bedrooms >= minNumberOfBedrooms && x.Number_Of_Bedrooms <= maxNumberOfBedrooms);

            filteredEstates = filteredEstates
                .Where(x => x.Number_Of_Bathrooms >= minNumberOfBathrooms && x.Number_Of_Bathrooms <= maxNumberOfBedrooms);

            // ... more property checks
            return estates;
        }


        // Filter using an object
        public async Task<List<Estate>> FilterEstatesExact(IQueryable<Estate> estates, EstateFilter filter)
        {
            var query = estates;

            if (filter.Estate_Name.Length > 0)
            {
                query = query.Where(x => x.Estate_Name.Contains(filter.Estate_Name.ToString()));
            }

            if (filter.Estate_Description.Length > 0)
            {
                query = query.Where(x => x.Estate_Description.Contains(filter.Estate_Description.ToString()));
            }

            if (filter.Pets_Allowed.HasValue)
            {
                query = query.Where(x => x.Pets_Allowed == filter.Pets_Allowed.Value);
            }

            if (filter.City_Id.HasValue)
            {
                query = query.Where(x => x.City_Id == filter.City_Id.Value);
            }

            if (filter.Estate_Type_Id.HasValue)
            {
                query = query.Where(x => x.Estate_Type_Id == filter.Estate_Type_Id.Value);
            }

            if (filter.Number_Of_Bedrooms.HasValue)
            {
                query = query.Where(x => x.Number_Of_Bedrooms == filter.Number_Of_Bedrooms.Value);
            }

            if (filter.Number_Of_Bathrooms.HasValue)
            {
                query = query.Where(x => x.Number_Of_Bathrooms == filter.Number_Of_Bathrooms.Value);
            }

            if (filter.Number_Of_Balconies.HasValue)
            {
                query = query.Where(x => x.Number_Of_Balconies == filter.Number_Of_Balconies.Value);
            }

            if (filter.Number_Of_Garages.HasValue)
            {
                query = query.Where(x => x.Number_Of_Garages == filter.Number_Of_Garages.Value);
            }

            if (filter.Number_Of_ParkingSpaces.HasValue)
            {
                query = query.Where(x => x.Number_Of_Parking_Spaces == filter.Number_Of_ParkingSpaces.Value);
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
