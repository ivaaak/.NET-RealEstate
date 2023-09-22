#nullable disable
using Newtonsoft.Json;
using StackExchange.Redis;
using IDatabase = StackExchange.Redis.IDatabase;

namespace RealEstate.Shared.Data.Cache
{
    public class CacheService : ICacheService
    {
        private readonly IDatabase _cache;

        public CacheService(string connectionString)
        {
            var connection = ConnectionMultiplexer.Connect(connectionString);
            _cache = connection.GetDatabase();
        }

        // GET AN ITEM BY ID
        public T Get<T>(string key)
        {
            var value = _cache.StringGet(key);
            return value.HasValue ? JsonConvert.DeserializeObject<T>(value) : default;
        }

        // SET AN ITEM AND ID
        public void Set<T>(string key, T value)
        {
            _cache.StringSet(key, JsonConvert.SerializeObject(value));
        }

        // SET AN ITEM WITH EXPIRATION
        public void Set<T>(string key, T value, TimeSpan expiration)
        {
            _cache.StringSet(key, JsonConvert.SerializeObject(value), expiration);
        }

        // CHECK IF A KEY EXISTS
        public bool KeyExists(string key)
        {
            return _cache.KeyExists(key);
        }

        // REMOVE AN ITEM
        public void Remove(string key)
        {
            _cache.KeyDelete(key);
        }

        // INCREMENT AN ITEMS VALUE
        public long Increment(string key, long value)
        {
            return _cache.StringIncrement(key, value);
        }

        // DECREMENT AN ITEMS VALUE
        public long Decrement(string key, long value)
        {
            return _cache.StringDecrement(key, value);
        }

        // SET MULTIPLE ITEMS
        public void SetMultiple<T>(IEnumerable<KeyValuePair<string, T>> values)
        {
            var entries = values.Select(x => new KeyValuePair<RedisKey, RedisValue>(x.Key, JsonConvert.SerializeObject(x.Value)));
            _cache.StringSet(entries.ToArray());
        }

        // REMOVE MULTIPLE ITEMS
        public void RemoveMultiple(IEnumerable<string> keys)
        {
            _cache.KeyDelete(keys.Select(x => (RedisKey)x).ToArray());
        }

        // GET ALL KEYS
        public IEnumerable<string> GetAllKeys()
        {
            var endpoints = _cache.Multiplexer.GetEndPoints();
            var server = _cache.Multiplexer.GetServer(endpoints[0]);
            var keys = server.Keys(_cache.Database);
            return keys.Select(x => x.ToString());
        }

        // GET ALL VALUES
        public IEnumerable<T> GetAllValues<T>()
        {
            var keys = GetAllKeys();
            var values = _cache.StringGet(keys.Select(x => (RedisKey)x).ToArray());
            return values.Select(x => JsonConvert.DeserializeObject<T>(x));
        }

        // GET A VALUE OR A DEFAULT VALUE
        public T GetOrDefault<T>(string key, T defaultValue)
        {
            var value = _cache.StringGet(key);
            return value.HasValue ? JsonConvert.DeserializeObject<T>(value) : defaultValue;
        }

        // GET A VALUE OR EXECUTE A FUNC (CREATE IF DOESNT EXIST)
        public T GetOrExecute<T>(string key, Func<T> func)
        {
            var value = _cache.StringGet(key);
            if (value.HasValue)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            else
            {
                var result = func();
                _cache.StringSet(key, JsonConvert.SerializeObject(result));
                return result;
            }
        }

        // GET A VALUE OR EXECUTE A FUNC WITH AN EXPIRATION
        public T GetOrExecute<T>(string key, Func<T> func, TimeSpan expiration)
        {
            var value = _cache.StringGet(key);
            if (value.HasValue)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            else
            {
                var result = func();
                _cache.StringSet(key, JsonConvert.SerializeObject(result), expiration);
                return result;
            }
        }

        // Retrieving a Value and Setting a Default Value If It Does Not Exist
        public T GetAndSetDefault<T>(string key, T defaultValue)
        {
            var value = _cache.StringGet(key);
            if (value.HasValue)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            else
            {
                _cache.StringSet(key, JsonConvert.SerializeObject(defaultValue));
                return defaultValue;
            }
        }

        //Retrieving a Value and Setting a Default Value If It Does Not Exist with Expiration
        public T GetAndSetDefault<T>(string key, T defaultValue, TimeSpan expiration)
        {
            var value = _cache.StringGet(key);
            if (value.HasValue)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            else
            {
                _cache.StringSet(key, JsonConvert.SerializeObject(defaultValue), expiration);
                return defaultValue;
            }
        }
    }
}
