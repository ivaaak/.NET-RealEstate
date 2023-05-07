#nullable disable
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Shared.Models.Entities.BaseEntityModel
{
    public abstract class BaseModel<TKey>
       where TKey : IComparable<TKey>, IEquatable<TKey>
    {
        [Key]
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
