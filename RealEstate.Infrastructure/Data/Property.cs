using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Infrastructure.Data
{
    public class Property
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [StringLength(100)]
        public string? Title { get; set; }

        [Required]
        [StringLength(600)]
        public string? Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int Year { get; set; }

        public bool IsPublic { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DateBuilt { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateListed { get; set; }

        public int SquareMeters { get; set; }
        
        [Required]
        public PropertyType PropertyType { get; set; }


        public int CategoryId { get; set; }

        public Category Category { get; init; }

        public int AgentId { get; init; }

        public Agent Agent { get; init; }

    }
}
