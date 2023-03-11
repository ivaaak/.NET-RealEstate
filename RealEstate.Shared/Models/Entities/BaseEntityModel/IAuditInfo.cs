namespace RealEstate.Shared.Models.Entities.BaseEntityModel
{
    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
