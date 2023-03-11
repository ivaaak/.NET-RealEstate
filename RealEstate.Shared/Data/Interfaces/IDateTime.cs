namespace RealEstate.Shared.Data.Interfaces
{
    public interface IDateTime
    {
        DateTime Now { get; }

        DateTime UtcNow { get; }
    }
}
