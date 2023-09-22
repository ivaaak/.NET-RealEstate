namespace RealEstate.Shared.Models.Entities.BaseEntityModel
{
    public interface IDeletableEntity
    {
        string Id { get; set; }

        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
