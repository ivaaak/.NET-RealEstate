namespace RealEstate.Data.Interfaces
{
    public interface IRedisService<T>
    {
        Task<T> Get(string key);

        Task Save(string key, T obj, TimeSpan? expiration = null);

        Task Delete(string key);
    }
}
