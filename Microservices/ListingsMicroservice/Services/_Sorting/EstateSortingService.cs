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
                .OrderBy(e => e.Estate_Name)
                .ToList();

            return sortedEstates;
        }
        public List<Estate> SortByNameDescending(List<Estate> estates)
        {
            var sortedEstates = estates
                .OrderByDescending(e => e.Estate_Name)
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
                .OrderBy(e => e.Estate_Type)
                .ToList();

            return sortedEstates;
        }
        public List<Estate> SortByTypeDescending(List<Estate> estates)
        {
            var sortedEstates = estates
                .OrderByDescending(e => e.Estate_Type)
                .ToList();

            return sortedEstates;
        }



        public List<Estate> SortByYearBuilt(List<Estate> estates)
        {
            var sortedEstates = estates
                .OrderBy(e => e.Estate_Year_Built)
                .ToList();

            return sortedEstates;
        }
        public List<Estate> SortByYearBuiltDescending(List<Estate> estates)
        {
            var sortedEstates = estates
                .OrderByDescending(e => e.Estate_Year_Built)
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
                .OrderBy(e => e.Number_Of_Bedrooms)
                .ToList();

            return sortedEstates;
        }
        public List<Estate> SortByNrOfBedroomsDescending(List<Estate> estates)
        {
            var sortedEstates = estates
                .OrderByDescending(e => e.Number_Of_Bedrooms)
                .ToList();

            return sortedEstates;
        }



        public List<Estate> SortByNrOfBathrooms(List<Estate> estates)
        {
            var sortedEstates = estates
                .OrderBy(e => e.Number_Of_Bathrooms)
                .ToList();

            return sortedEstates;
        }
        public List<Estate> SortByNrOfBathroomsDescending(List<Estate> estates)
        {
            var sortedEstates = estates
                .OrderByDescending(e => e.Number_Of_Bathrooms)
                .ToList();

            return sortedEstates;
        }



        public List<Estate> SortByMultiple(List<Estate> estates)
        {
            var sortedEstates = estates.OrderBy(e => e.Estate_Name)
                           .ThenBy(e => e.City.City_Name)
                           .ThenBy(e => e.Id)
                           .ThenBy(e => e.Floor_Space_Square_Meters)
                           .ThenBy(e => e.Number_Of_Balconies)
                           .ThenBy(e => e.Number_Of_Bedrooms)
                           .ThenBy(e => e.Number_Of_Bathrooms)
                           .ThenBy(e => e.Number_Of_Garages)
                           .ThenBy(e => e.Estate_Type)
                           .ThenBy(e => e.Estate_Year_Built)
                           .ThenBy(e => e.Pets_Allowed)
                           .ThenBy(e => e.Estate_Name)
                           .ThenBy(e => e.Estate_Status_Id)
                           .ThenBy(e => e.Estate_Year_Listed)
                           .ToList();

            return sortedEstates;
        }

    }
}
