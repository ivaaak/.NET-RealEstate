namespace RealEstate.Data.Interfaces
{
    public interface IDateTime
    {
        DateTime Now { get; }

        DateTime UtcNow { get; }
    }
}
