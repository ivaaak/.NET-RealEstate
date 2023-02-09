using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using RealEstate.Data.Repository;
using RealEstate.Models.Entities.Estates;
using StackExchange.Redis;
using UtilitiesMicroservice.Controllers;
using Xunit;

namespace RealEstate.Test.Controllers
{
    public class CacheControllerTests
    {
        private readonly CacheController _controller;
        private readonly IRepository _repository;

        public CacheControllerTests()
        {
            // Set up the necessary dependencies for the controller
            var redisConnectionString = "localhost";
            var redis = ConnectionMultiplexer.Connect(redisConnectionString);
            var cache = redis.GetDatabase();
            //_repository = new Repository();
            _controller = new CacheController(
                _roleManager: null,
                _userManager: null,
                _service: null,
                _mediator: null,
                _mapper: null,
                _repository: _repository
            );
        }

        [Fact]
        public async void GetEstate_ReturnsOkResult()
        {
            // Arrange
            var id = 1;

            // Act
            var result = await _controller.GetEstate(id);

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }

        [Fact]
        public async void GetEstate_ReturnsEstateObject()
        {
            // Arrange
            var id = 1;

            // Act
            var result = await _controller.GetEstate(id) as OkObjectResult;

            // Assert
            Assert.IsAssignableFrom<Estate>(result.Value);
        }

        [Fact]
        public void GetCachedEstates_ReturnsOkResult()
        {
            // Act
            var result = _controller.GetCachedEstates();

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }
        [Fact]
        public void GetCachedEstates_ReturnsListOfEstates()
        {
            // Act
            var result = _controller.GetCachedEstates() as OkObjectResult;

            // Assert
            Assert.IsAssignableFrom<List<Estate>>(result.Value);
        }

        [Fact]
        public void SetEstate_ReturnsOkResult()
        {
            // Arrange
            var estate = new Estate();

            // Act
            var result = _controller.SetEstate(estate);

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }

        [Fact]
        public void SetEstate_SetsEstateInCache(IDatabase cache)
        {
            // Arrange
            var estate = new Estate();

            // Act
            var result = _controller.SetEstate(estate) as OkObjectResult;
            var cacheKey = result.Value as string;
            var cachedValue = cache.StringGet(cacheKey);

            // Assert
            Assert.True(cachedValue.HasValue);
        }

        [Fact]
        public void SetCachedEstates_ReturnsOkResult()
        {
            // Arrange
            var estates = new List<Estate>
            {
                new Estate(),
                new Estate()
            };

            // Act
            var result = _controller.SetCachedEstates(estates);

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }

        [Fact]
        public void SetCachedEstates_SetsEstatesInCache(IDatabase cache)
        {
            // Arrange
            var estates = new List<Estate>
            {
                new Estate(),
                new Estate()
            };

            // Act
            _controller.SetCachedEstates(estates);
            var cacheKey = "item:";
            var cachedValue = cache.StringGet(cacheKey);

            // Assert
            Assert.True(cachedValue.HasValue);
        }

        [Fact]
        public void GetCachedEstates_ReturnsOkResult(IDatabase cache)
        {
            // Arrange
            var controller = new CacheController(
                _roleManager: null,
                _userManager: null,
                _service: null,
                _mediator: null,
                _mapper: null,
                _repository: _repository
            );

            // Act
            var result = controller.GetCachedEstates();

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }

        [Fact]
        public void GetCachedEstates_ReturnsListOfEstates(IDatabase cache)
        {
            // Arrange
            var controller = new CacheController(
                _roleManager: null,
                _userManager: null,
                _service: null,
                _mediator: null,
                _mapper: null,
                _repository: _repository
            );

            // Act
            var result = controller.GetCachedEstates() as OkObjectResult;

            // Assert
            Assert.IsAssignableFrom<List<Estate>>(result.Value);
        }

        [Fact]
        public void GetEstate_ReturnsOkResult(IDatabase cache)
        {
            // Arrange
            var controller = new CacheController(
                _roleManager: null,
                _userManager: null,
                _service: null,
                _mediator: null,
                _mapper: null,
                _repository: _repository
            );
            var id = 1;

            // Act
            var result = controller.GetEstate(id);

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }

        [Fact]
        public void GetEstate_ReturnsEstate(IDatabase cache)
        {
            // Arrange
            var controller = new CacheController(
                _roleManager: null,
                _userManager: null,
                _service: null,
                _mediator: null,
                _mapper: null,
                _repository: _repository
            );
            var id = 1;

            // Act
            var result = controller.GetEstate(id);

            // Assert
            Assert.IsAssignableFrom<Estate>(result);
        }

        [Fact]
        public void GetEstate_ReturnsCachedEstate(IDatabase cache)
        {
            // Arrange
            var controller = new CacheController(
                _roleManager: null,
                _userManager: null,
                _service: null,
                _mediator: null,
                _mapper: null,
                _repository: _repository
            );
            var id = 1;
            var cacheKey = $"item:{id}";
            var estate = new Estate();
            cache.StringSet(cacheKey, estate.ToString(), TimeSpan.FromMinutes(5));

            // Act
            var result = controller.GetEstate(id);

            // Assert
            Assert.AreEqual(estate, result);
        }

    }
}
