namespace RealEstate.Shared.Models.Entities.BaseEntityModel
{
    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
