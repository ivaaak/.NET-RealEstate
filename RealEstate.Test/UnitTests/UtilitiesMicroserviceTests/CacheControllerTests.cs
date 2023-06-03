#nullable disable
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.Models.Entities.Estates;
using StackExchange.Redis;
using UtilitiesMicroservice.Controllers;
using Xunit;

namespace RealEstate.Test.UnitTests.UtilitiesMicroserviceTests
{
    public class CacheControllerTests
    {
        private readonly CacheController _controller;
        private readonly IRepository _repository;

        public CacheControllerTests(IRepository repository)
        {
            // Set up the necessary dependencies for the controller
            var redisConnectionString = "localhost";
            var redis = ConnectionMultiplexer.Connect(redisConnectionString);
            _ = redis.GetDatabase();
            _repository = repository;
            _controller = new CacheController(repository: _repository, logger: null);
        }

        [Fact]
        public async Task GetEstateReturnsOkResult()
        {
            // Arrange
            var id = 1;

            // Act
            var result = await _controller.GetEstate(id);

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetEstateReturnsEstateObject()
        {
            // Arrange
            var id = 1;

            // Act
            var result = await _controller.GetEstate(id) as OkObjectResult;

            // Assert
            Assert.IsAssignableFrom<Estate>(result.Value);
        }

        [Fact]
        public void GetCachedEstatesReturnsOkResult()
        {
            // Act
            var result = _controller.GetCachedEstates();

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }
        [Fact]
        public void GetCachedEstatesReturnsListOfEstates()
        {
            // Act
            var result = _controller.GetCachedEstates() as OkObjectResult;

            // Assert
            Assert.IsAssignableFrom<List<Estate>>(result.Value);
        }

        [Fact]
        public void SetEstateReturnsOkResult()
        {
            // Arrange
            var estate = new Estate();

            // Act
            var result = _controller.SetEstate(estate);

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }

        [Fact]
        public void SetEstateSetsEstateInCache(IDatabase cache)
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
        public void SetCachedEstatesReturnsOkResult()
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
            var controller = new CacheController(repository: _repository, logger: null);

            // Act
            var result = controller.GetCachedEstates();

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }

        [Fact]
        public void GetCachedEstates_ReturnsListOfEstates(IDatabase cache)
        {
            // Arrange
            var controller = new CacheController(repository: _repository, logger: null);

            // Act
            var result = controller.GetCachedEstates() as OkObjectResult;

            // Assert
            Assert.IsAssignableFrom<List<Estate>>(result.Value);
        }

        [Fact]
        public void GetEstate_ReturnsOkResult(IDatabase cache)
        {
            // Arrange
            var controller = new CacheController(repository: _repository, logger: null);

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
            var controller = new CacheController(repository: _repository, logger: null);

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
            var controller = new CacheController(repository: _repository, logger: null);

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
