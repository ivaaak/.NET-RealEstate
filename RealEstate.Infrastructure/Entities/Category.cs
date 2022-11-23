using RealEstate.Infrastructure.Entities.Estates;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Infrastructure.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public IEnumerable<Estate> Properties { get; init; } = new List<Estate>();
    }
}