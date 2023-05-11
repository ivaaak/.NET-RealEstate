using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.Models.Entities.Estates;
using StackExchange.Redis;

namespace UtilitiesMicroservice.Controllers
{
    [Authorize]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")] // api/cache/
    public class CacheController : ControllerBase
    {
        private readonly IDatabase cache;

        private readonly IRepository _repository;

        private readonly ILogger<CacheController> _logger;

        public CacheController(
            IRepository repository,
            ILogger<CacheController> logger)
        {
            var redisConnectionString = "localhost";
            var redis = ConnectionMultiplexer.Connect(redisConnectionString);
            cache = redis.GetDatabase();
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        /// <summary>
        /// Gets an estate which is cached.
        /// </summary>
        /// <param name="id"> id - int </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /api/cache/getestate/5
        ///
        /// </remarks>
        [HttpGet]
        [Route("/{id}")]
        [ResponseCache(Duration = 60)]
        public async Task<IActionResult> GetEstate(int id)
        {
            // Check if the item is in the cache
            var cacheKey = $"item:{id}";
            var cachedValue = cache.StringGet(cacheKey);
            if (cachedValue.HasValue)
            {
                // Return the cached item
                return Ok(cachedValue);
            }

            // Get the item from the database
            var item = await _repository.GetByIdAsync<Estate>(id);

            // Re-Cache the item
            cache.StringSet(cacheKey, item.ToString(), TimeSpan.FromMinutes(5));

            // Return the item
            return Ok(item);
        }


        [HttpGet]
        [ResponseCache(Duration = 60)]
        public IActionResult GetCachedEstates()
        {
            var cacheKey = $"item:";
            var cachedValue = cache.StringGet(cacheKey);
            if (cachedValue.HasValue)
            {
                return Ok(cachedValue);
            }

            var item = _repository.All<Estate>();

            cache.StringSet(cacheKey, item.ToString(), TimeSpan.FromMinutes(5));

            return Ok(item);
        }


        /// <summary>
        /// Sets an estate to the redis cache.
        /// </summary>
        /// <param name="estateObject"> estateObject - object </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /api/cache/setestate
        ///
        /// </remarks>
        [HttpGet]
        [ResponseCache(Duration = 60)]
        public IActionResult SetEstate(Estate estateObject)
        {
            var cacheKey = Guid.NewGuid().ToString();
            cache.StringSet(cacheKey, estateObject.ToString(), TimeSpan.FromMinutes(5));

            return Ok(cacheKey);
        }

        [HttpGet]
        [ResponseCache(Duration = 60)]
        public IActionResult SetCachedEstates(List<Estate> estatesList)
        {
            foreach (var estate in estatesList)
            {
                var cacheKey = $"item:";
                cache.StringSet(cacheKey, estate.ToString(), TimeSpan.FromMinutes(5));
            }

            return Ok(estatesList);
        }

        [HttpGet]
        [AllowAnonymous]
        //http://localhost:9007/api/cache/gethealth
        //http://localhost:9000/api/cache/gethealth behind gateway
        public string getHealth() => "Utilities Microservice up and running";
    }
}