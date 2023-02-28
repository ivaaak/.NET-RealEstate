namespace RealEstate.Data.Interfaces
{
    public interface IDatabaseQueryRunner : IDisposable
    {
        Task RunQueryAsync(string query, params object[] parameters);
    }
}
