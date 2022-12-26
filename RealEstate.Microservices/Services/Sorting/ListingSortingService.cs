using RealEstate.Data.Repository;
using RealEstate.Models.Entities.Listings;

namespace RealListing.Microservices.Services.Sorting
{
    public class ListingSortingService
    {
        private readonly IApplicationDbRepository repo;

        public ListingSortingService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }


        public List<Listing> SortById(List<Listing> listings)
        {
            var sortedListings = listings
                .OrderBy(e => e.Id)
                .ToList();

            return sortedListings;
        }
        public List<Listing> SortByIdDescending(List<Listing> listings)
        {
            var sortedListings = listings
                .OrderByDescending(e => e.Id)
                .ToList();

            return sortedListings;
        }



        public List<Listing> SortByName(List<Listing> listings)
        {
            var sortedListings = listings
                .OrderBy(e => e.Name)
                .ToList();

            return sortedListings;
        }
        public List<Listing> SortByNameDescending(List<Listing> listings)
        {
            var sortedListings = listings
                .OrderByDescending(e => e.Name)
                .ToList();

            return sortedListings;
        }



        public List<Listing> SortByPrice(List<Listing> listings)
        {
            var sortedListings = listings
                .OrderBy(e => e.Price)
                .ToList();

            return sortedListings;
        }
        public List<Listing> SortByPriceDescending(List<Listing> listings)
        {
            var sortedListings = listings
                .OrderByDescending(e => e.Price)
                .ToList();

            return sortedListings;
        }



        public List<Listing> SortByDescription(List<Listing> listings)
        {
            var sortedListings = listings
                .OrderBy(e => e.Description)
                .ToList();

            return sortedListings;
        }
        public List<Listing> SortByDescriptionDescending(List<Listing> listings)
        {
            var sortedListings = listings
                .OrderByDescending(e => e.Description)
                .ToList();

            return sortedListings;
        }



        public List<Listing> SortByDateBuilt(List<Listing> listings)
        {
            var sortedListings = listings
                .OrderBy(e => e.DateBuilt)
                .ToList();

            return sortedListings;
        }
        public List<Listing> SortByDateBuiltDescending(List<Listing> listings)
        {
            var sortedListings = listings
                .OrderByDescending(e => e.DateBuilt)
                .ToList();

            return sortedListings;
        }



        public List<Listing> SortByCategory(List<Listing> listings)
        {
            var sortedListings = listings
                .OrderBy(e => e.Category)
                .ToList();

            return sortedListings;
        }
        public List<Listing> SortByCategoryDescending(List<Listing> listings)
        {
            var sortedListings = listings
                .OrderByDescending(e => e.Category)
                .ToList();

            return sortedListings;
        }



        public List<Listing> SortBySquareMeters(List<Listing> listings)
        {
            var sortedListings = listings
                .OrderBy(e => e.SquareMeters)
                .ToList();

            return sortedListings;
        }
        public List<Listing> SortBySquareMetersDescending(List<Listing> listings)
        {
            var sortedListings = listings
                .OrderByDescending(e => e.SquareMeters)
                .ToList();

            return sortedListings;
        }



        public List<Listing> SortByDateListed(List<Listing> listings)
        {
            var sortedListings = listings
                .OrderBy(e => e.DateListed)
                .ToList();

            return sortedListings;
        }
        public List<Listing> SortByDateListedDescending(List<Listing> listings)
        {
            var sortedListings = listings
                .OrderByDescending(e => e.DateListed)
                .ToList();

            return sortedListings;
        }



        public List<Listing> SortByEstateType(List<Listing> listings)
        {
            var sortedListings = listings
                .OrderBy(e => e.Estate_Type)
                .ToList();

            return sortedListings;
        }
        public List<Listing> SortByEstateTypeDescending(List<Listing> listings)
        {
            var sortedListings = listings
                .OrderByDescending(e => e.Estate_Type)
                .ToList();

            return sortedListings;
        }



        public List<Listing> SortByMultiple(List<Listing> listings)
        {
            var sortedListings = listings.OrderBy(e => e.Name)
                           .ThenBy(e => e.SquareMeters)
                           .ThenBy(e => e.Title)
                           .ThenBy(e => e.Category)
                           .ThenBy(e => e.DateBuilt)
                           .ThenBy(e => e.DateListed)
                           .ThenBy(e => e.Description)
                           .ThenBy(e => e.Estate_Type)
                           .ThenBy(e => e.IsPublic)
                           .ThenBy(e => e.Price)
                           .ThenBy(e => e.Year)
                           .ToList();

            return sortedListings;
        }

    }
}
