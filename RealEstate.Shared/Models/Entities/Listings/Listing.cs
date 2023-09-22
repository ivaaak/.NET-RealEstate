#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using RealEstate.Shared.Models.Entities.Estates;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Shared.Models.Entities.Listings
{
    public class Listing : IDeletableEntity
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Estate Estate { get; set; }

        public string Estate_Id { get; set; }

        public int Price { get; set; }

        public double PricePerSquareMeter { get; set; }

        public bool Is_From_An_Agency { get; set; }

        public string ImageUrl { get; set; }

        public List<Comment> Comments { get; set; }
        public bool IsPublic { get; set; }

        public DateTime DateBuilt { get; set; }

        public DateTime DateListed { get; set; }



        public Estate_Type Estate_Type { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; init; }

        public Address Address { get; set; }

        public ListingStats ListingStats { get; set; }

        public int EmployeeId { get; init; }
        public Employee Employee { get; init; }

        public string Agent_Id { get; set; }
        public Agent Agent { get; set; }
        public PriceHistory PriceHistory { get; set; }

        [NotMapped]
        public List<PriceHistory> PriceHistories { get; set; }
        public List<Review> Reviews { get; set; }


        // IDeletableEntity
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
