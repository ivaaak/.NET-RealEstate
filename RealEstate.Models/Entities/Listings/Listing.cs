using RealEstate.Models.Entities.BaseEntityModel;
using RealEstate.Models.Entities.Estates;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models.Entities.Listings
{
    public class Listing : IDeletableEntity
    {
        [Key]
        public int Id { get; init; }

        public string Name { get; set; }

        public Estate Estate { get; set; }

        public int Price { get; set; }

        public double PricePerSquareMeter
        {
            set
            {
                if (value > 0 && Estate != null)
                {
                    //value = Price / Property.SquareMeters;
                }
            }
        }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public int Year { get; set; }

        public bool IsPublic { get; set; }

        public DateTime DateBuilt { get; set; }

        public DateTime DateListed { get; set; }

        public int SquareMeters { get; set; }

        public Estate_Type Estate_Type { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; init; }

        public int EmployeeId { get; init; }

        public Employee? Employee { get; init; }

        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
