using RealEstate.Infrastructure.Data.Enumerations;
using RealEstate.Infrastructure.Entities.Estates;
using RealEstate.Infrastructure.Entities.Listings;

namespace RealEstate.Core.ViewModels.Estates
{
    public class EstateViewModel
    {
        public int Id { get; init; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public int Year { get; set; }

        public bool IsPublic { get; set; }

        public DateTime DateBuilt { get; set; }

        public DateTime DateListed { get; set; }

        public int SquareMeters { get; set; }

        public PropertyType PropertyType { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; init; }

        public int EmployeeId { get; init; }

        public Employee? Employee { get; init; }
    }
}