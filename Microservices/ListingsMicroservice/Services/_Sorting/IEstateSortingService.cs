using RealEstate.Shared.Models.Entities.Estates;

namespace ListingsMicroservice.Services._Sorting
{
    public interface IEstateSortingService
    {
        public List<Estate> SortById(List<Estate> estates);

        public List<Estate> SortByIdDescending(List<Estate> estates);

        public List<Estate> SortByName(List<Estate> estates);

        public List<Estate> SortByNameDescending(List<Estate> estates);

        public List<Estate> SortByCity(List<Estate> estates);

        public List<Estate> SortByCityDescending(List<Estate> estates);

        public List<Estate> SortByFloorSpace(List<Estate> estates);

        public List<Estate> SortByFloorSpaceDescending(List<Estate> estates);

        public List<Estate> SortByType(List<Estate> estates);

        public List<Estate> SortByTypeDescending(List<Estate> estates);

        public List<Estate> SortByYearBuilt(List<Estate> estates);

        public List<Estate> SortByYearBuiltDescending(List<Estate> estates);

        public List<Estate> SortByPetsAllowed(List<Estate> estates);

        public List<Estate> SortByPetsAllowedDescending(List<Estate> estates);

        public List<Estate> SortByNrOfBedrooms(List<Estate> estates);

        public List<Estate> SortByNrOfBedroomsDescending(List<Estate> estates);

        public List<Estate> SortByNrOfBathrooms(List<Estate> estates);

        public List<Estate> SortByNrOfBathroomsDescending(List<Estate> estates);

        public List<Estate> SortByMultiple(List<Estate> estates);
    }
}
