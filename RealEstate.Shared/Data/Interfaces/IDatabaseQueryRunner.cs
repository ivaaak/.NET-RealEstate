namespace RealEstate.Shared.Data.Interfaces
{
    public interface IDatabaseQueryRunner : IDisposable
    {
        Task RunQueryAsync(string query, params object[] parameters);
    }
}
