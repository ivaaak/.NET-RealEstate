#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Shared.Models.Entities.Estates
{
    public class Category : IDeletableEntity
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public IEnumerable<Estate> Estates { get; init; } = new List<Estate>();


        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Estate Estate { get; set; }
        public int Estate_Id { get; set; }

    }
}