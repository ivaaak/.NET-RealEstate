namespace RealEstate.Shared.Data.Cache
{
    public interface ICacheService
    {
        // GET AN ITEM BY ID
        T Get<T>(string key);

        // SET AN ITEM AND ID
        void Set<T>(string key, T value);

        // SET AN ITEM WITH EXPIRATION
        void Set<T>(string key, T value, TimeSpan expiration);

        // CHECK IF A KEY EXISTS
        bool KeyExists(string key);

        // REMOVE AN ITEM
        void Remove(string key);

        // INCREMENT AN ITEMS VALUE
        long Increment(string key, long value);

        // DECREMENT AN ITEMS VALUE
        long Decrement(string key, long value);

        // SET MULTIPLE ITEMS
        void SetMultiple<T>(IEnumerable<KeyValuePair<string, T>> values);

        // REMOVE MULTIPLE ITEMS
        void RemoveMultiple(IEnumerable<string> keys);

        // GET ALL KEYS
        IEnumerable<string> GetAllKeys();

        // GET ALL VALUES
        IEnumerable<T> GetAllValues<T>();

        // GET A VALUE OR A DEFAULT VALUE
        T GetOrDefault<T>(string key, T defaultValue);

        // GET A VALUE OR EXECUTE A FUNC(CREATE IF DOESNT EXIST)
        T GetOrExecute<T>(string key, Func<T> func);

        // GET A VALUE OR EXECUTE A FUNC WITH AN EXPIRATION
        T GetOrExecute<T>(string key, Func<T> func, TimeSpan expiration);

        // Retrieving a Value and Setting a Default Value If It Does Not Exist
        T GetAndSetDefault<T>(string key, T defaultValue);

        //Retrieving a Value and Setting a Default Value If It Does Not Exist with Expiration
        T GetAndSetDefault<T>(string key, T defaultValue, TimeSpan expiration);
    }
}
