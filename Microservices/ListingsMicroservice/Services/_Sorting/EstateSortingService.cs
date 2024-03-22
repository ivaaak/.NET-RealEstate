using RealEstate.Shared.Models.Entities.Estates;

namespace ListingsMicroservice.Services._Sorting
{
    public class EstateSortingService : IEstateSortingService
    {
        public EstateSortingService()
        { }


        public List<Estate> SortById(List<Estate> estates)
        {
            var sortedEstates = estates
                .OrderBy(e => e.Id)
                .ToList();

            return sortedEstates;
        }
        public List<Estate> SortByIdDescending(List<Estate> estates)
        {
            var sortedEstates = estates
                .OrderByDescending(e => e.Id)
                .ToList();

            return sortedEstates;
        }



        public List<Estate> SortByName(List<Estate> estates)
        {
            var sortedEstates = estates
                .OrderBy(e => e.Name)
                .ToList();

            return sortedEstates;
        }
        public List<Estate> SortByNameDescending(List<Estate> estates)
        {
            var sortedEstates = estates
                .OrderByDescending(e => e.Name)
                .ToList();

            return sortedEstates;
        }



        public List<Estate> SortByCity(List<Estate> estates)
        {
            var sortedEstates = estates
                .OrderBy(e => e.City)
                .ToList();

            return sortedEstates;
        }
        public List<Estate> SortByCityDescending(List<Estate> estates)
        {
            var sortedEstates = estates
                .OrderByDescending(e => e.City)
                .ToList();

            return sortedEstates;
        }



        public List<Estate> SortByFloorSpace(List<Estate> estates)
        {
            var sortedEstates = estates
                .OrderBy(e => e.Floor_Space_Square_Meters)
                .ToList();

            return sortedEstates;
        }
        public List<Estate> SortByFloorSpaceDescending(List<Estate> estates)
        {
            var sortedEstates = estates
                .OrderByDescending(e => e.Floor_Space_Square_Meters)
                .ToList();

            return sortedEstates;
        }



        public List<Estate> SortByType(List<Estate> estates)
        {
            var sortedEstates = estates
                .OrderBy(e => e.Type)
                .ToList();

            return sortedEstates;
        }
        public List<Estate> SortByTypeDescending(List<Estate> estates)
        {
            var sortedEstates = estates
                .OrderByDescending(e => e.Type)
                .ToList();

            return sortedEstates;
        }



        public List<Estate> SortByYearBuilt(List<Estate> estates)
        {
            var sortedEstates = estates
                .OrderBy(e => e.YearBuilt)
                .ToList();

            return sortedEstates;
        }
        public List<Estate> SortByYearBuiltDescending(List<Estate> estates)
        {
            var sortedEstates = estates
                .OrderByDescending(e => e.YearBuilt)
                .ToList();

            return sortedEstates;
        }



        public List<Estate> SortByPetsAllowed(List<Estate> estates)
        {
            var sortedEstates = estates
                .OrderBy(e => e.Pets_Allowed)
                .ToList();

            return sortedEstates;
        }
        public List<Estate> SortByPetsAllowedDescending(List<Estate> estates)
        {
            var sortedEstates = estates
                .OrderByDescending(e => e.Pets_Allowed)
                .ToList();

            return sortedEstates;
        }



        public List<Estate> SortByNrOfBedrooms(List<Estate> estates)
        {
            var sortedEstates = estates
                .OrderBy(e => e.Bedrooms)
                .ToList();

            return sortedEstates;
        }
        public List<Estate> SortByNrOfBedroomsDescending(List<Estate> estates)
        {
            var sortedEstates = estates
                .OrderByDescending(e => e.Bedrooms)
                .ToList();

            return sortedEstates;
        }



        public List<Estate> SortByNrOfBathrooms(List<Estate> estates)
        {
            var sortedEstates = estates
                .OrderBy(e => e.Bathrooms)
                .ToList();

            return sortedEstates;
        }
        public List<Estate> SortByNrOfBathroomsDescending(List<Estate> estates)
        {
            var sortedEstates = estates
                .OrderByDescending(e => e.Bathrooms)
                .ToList();

            return sortedEstates;
        }



        public List<Estate> SortByMultiple(List<Estate> estates)
        {
            var sortedEstates = estates.OrderBy(e => e.Name)
                           .ThenBy(e => e.City.City_Name)
                           .ThenBy(e => e.Id)
                           .ThenBy(e => e.Floor_Space_Square_Meters)
                           .ThenBy(e => e.Balconies)
                           .ThenBy(e => e.Bedrooms)
                           .ThenBy(e => e.Bathrooms)
                           .ThenBy(e => e.Garages)
                           .ThenBy(e => e.Type)
                           .ThenBy(e => e.YearBuilt)
                           .ThenBy(e => e.Pets_Allowed)
                           .ThenBy(e => e.Name)
                           .ToList();

            return sortedEstates;
        }

    }
}
