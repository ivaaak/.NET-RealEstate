#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using RealEstate.Shared.Models.Entities.Listings;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Shared.Models.Entities.Estates
{
    public class Estate : IDeletableEntity
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Estate_Name { get; set; }

        [ForeignKey("City_Id")]
        public int City_Id { get; set; }
        public City City { get; set; }
        public int Estate_Type_Id { get; set; }
        public decimal Floor_Space_Square_Meters { get; set; }
        public int Number_Of_Balconies { get; set; }
        public decimal Balconies_Space { get; set; }
        public int Number_Of_Bedrooms { get; set; }
        public int Number_Of_Bathrooms { get; set; }
        public int Number_Of_Garages { get; set; }
        public int Number_Of_Parking_Spaces { get; set; }
        public bool Pets_Allowed { get; set; }
        public string Estate_Description { get; set; }
        public string Estate_Status_Id { get; set; }
        public string Estate_ImageUrl { get; set; }
        public int Estate_Year_Built { get; set; }
        public int Estate_Year_Listed { get; set; }
        public string Build_Material { get; set; }
        public int? Is_On_Floor { get; set; }
        public int? Bulding_Floors { get; set; }
        public Address Address { get; set; }
        public Listing Listing { get; set; }
        public string Listing_Id { get; set; }
        public Estate_Type Estate_Type { get; set; }


        // IDeletableEntity
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }

        /*
        public virtual bool IsValid()
        {
            var validation = new EstateValidation();
            validation.ValidateID();
            validation.ValidateTitle();

            ValidationResult = validation.Validate(this);
            return ValidationResult.IsValid;
        }*/
    }
}
