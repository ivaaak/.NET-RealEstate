using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Authentication.Contracts;
using RealEstate.Data.Repository;
using RealEstate.Infrastructure.Filters;
using RealEstate.Models.Entities.Estates;
using RealEstate.Models.Entities.Identity;
using StackExchange.Redis;

namespace RealEstate.API.Controllers
{
    [Authorize]
    [AjaxFilter]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")] // api/auth/
    public class CacheController : BaseController
    {
        private readonly IDatabase cache;

        private readonly IRepository repository;

        public CacheController(
            RoleManager<IdentityRole> _roleManager,
            UserManager<ApplicationUser> _userManager,
            IUserService _service,
            IMediator _mediator,
            IMapper _mapper,
            IRepository _repository)
            : base(_roleManager, _userManager, _service, _mediator, _mapper)
        {
            var redisConnectionString = "localhost";
            var redis = ConnectionMultiplexer.Connect(redisConnectionString);
            cache = redis.GetDatabase();
            // separate caches for each context?
            repository = _repository;
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
        [Route("getEstate/{id}")]
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
            var item = await repository.GetByIdAsync<Estate>(id);

            // Re-Cache the item
            cache.StringSet(cacheKey, item.ToString(), TimeSpan.FromMinutes(5));

            // Return the item
            return Ok(item);
        }


        [HttpGet]
        [Route("getEstates")]
        [ResponseCache(Duration = 60)]
        public IActionResult GetCachedEstates()
        {
            var cacheKey = $"item:";
            var cachedValue = cache.StringGet(cacheKey);
            if (cachedValue.HasValue)
            {
                return Ok(cachedValue);
            }

            var item = repository.All<Estate>();

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
        [Route("setEstate")]
        [ResponseCache(Duration = 60)]
        public IActionResult SetEstate(Estate estateObject)
        {
            var cacheKey = Guid.NewGuid().ToString();
            cache.StringSet(cacheKey, estateObject.ToString(), TimeSpan.FromMinutes(5));

            return Ok(cacheKey);
        }

        [HttpGet]
        [Route("setEstates")]
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
    }
}