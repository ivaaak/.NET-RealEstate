#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Shared.Models.Entities.Estates
{
    public class Category : IDeletableEntity
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public IEnumerable<Estate> Estates { get; init; } = new List<Estate>();

        public Estate Estate { get; set; }
        public int Estate_Id { get; set; }

        // IDeletableEntity
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}