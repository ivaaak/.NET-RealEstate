#nullable disable
namespace RealEstate.Shared.Models.Entities.Misc
{
    public class ListingFilter
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Estate_Id { get; set; }
        public int? Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int? Year { get; set; }
        public bool? IsPublic { get; set; }
        public DateTime? DateBuilt { get; set; }
        public DateTime? DateListed { get; set; }
        public int? ExactSquareMeters { get; set; }
        public int? Estate_Type_Id { get; set; }
        public int? CategoryId { get; set; }
        public int? EmployeeId { get; set; }

        // Ranges

        public int? MinSquareMeters { get; set; }
        public int? MaxSquareMeters { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? MinPricePerSquareMeter { get; set; }
        public int? MaxPricePerSquareMeter { get; set; }
    }
}
