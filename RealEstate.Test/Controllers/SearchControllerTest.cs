using ListingsMicroservice.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using RealEstate.Models.Entities.Estates;
using Xunit;

namespace RealEstate.Test.Controllers
{
    public class SearchControllerTest
    {
        private IMediator _mediator;
        private SearchController controller;

        public SearchControllerTest()
        {
            // Set up mock dependencies
            //_mediator = new Mock<IMediator>();

            // Set up the controller
            controller = new SearchController(
                _roleManager: null,
                _userManager: null,
                _service: null,
                _mediator: null,
                _mapper: null);
        }


        [Fact]
        public void Search_ReturnsOkResult()
        {
            // Act
            var result = controller.Search("test");

            // Assert
            Assert.IsAssignableFrom<OkResult>(result);
        }

        [Fact]
        public void Client_ReturnsOkResult()
        {
            // Act
            var result = controller.Client("test");

            // Assert
            Assert.IsAssignableFrom<OkResult>(result);
        }

        [Fact]
        public void Estate_ReturnsOkResult()
        {
            // Act
            var result = controller.Estate("test");

            // Assert
            Assert.IsAssignableFrom<OkResult>(result);
        }

        [Fact]
        public void Listing_ReturnsOkResult()
        {
            // Act
            var result = controller.Listing("test");

            // Assert
            Assert.IsAssignableFrom<OkResult>(result);
        }

        [Fact]
        public void ByParameters_ReturnsOkResult()
        {
            // Act
            var result = controller.ByParameters(city: "test", minPrice: 1, maxPrice: 100, id: "1", name: "test", sort: "test");

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }

        [Fact]
        public void ByParameters_CityOnly_ReturnsOkResult()
        {
            // Act
            var result = controller.ByParameters(city: "test", minPrice: null, maxPrice: null, id: null, name: null, sort: null);

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }

        [Fact]
        public void ByParameters_MinPriceOnly_ReturnsOkResult()
        {
            // Act
            var result = controller.ByParameters(city: null, minPrice: 1, maxPrice: null, id: null, name: null, sort: null);

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }

        [Fact]
        public void ByParameters_MaxPriceOnly_ReturnsOkResult()
        {
            // Act
            var result = controller.ByParameters(city: null, minPrice: null, maxPrice: 100, id: null, name: null, sort: null);

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }

        [Fact]
        public void ByParameters_IdOnly_ReturnsOkResult()
        {
            // Act
            var result = controller.ByParameters(city: null, minPrice: null, maxPrice: null, id: "1", name: null, sort: null);

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }

        [Fact]
        public void ByParameters_NameOnly_ReturnsOkResult()
        {
            // Act
            var result = controller.ByParameters(city: null, minPrice: null, maxPrice: null, id: null, name: "name string", sort: null);

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }


        // COMPARE VALUES
        [Fact]
        public void ByParameters_CityMatch_ReturnsExpectedValues()
        {
            // Act
            var result = controller.ByParameters(city: "test", minPrice: null, maxPrice: null, id: null, name: null, sort: null).Result;

            // Assert
            Assert.AreEqual("test", ((IEnumerable<Estate>)result.Value).First().City);
        }

        [Fact]
        public void ByParameters_MinPriceMatch_ReturnsExpectedValues()
        {
            // Act
            var result = controller.ByParameters(city: null, minPrice: 1, maxPrice: null, id: null, name: null, sort: null).Result;

            // Assert
            Assert.True(((IEnumerable<Estate>)result.Value).All(x => x.Listing.Price >= 1));
        }

        [Fact]
        public void ByParameters_MaxPriceMatch_ReturnsExpectedValues()
        {
            // Act
            var result = controller.ByParameters(city: null, minPrice: null, maxPrice: 100, id: null, name: null, sort: null).Result;
            
            // Assert
            if(result.Value != null)
            {
                Assert.True(result.Value.All(x => x.Listing.Price <= 100));
            }
        }

        [Fact]
        public void ByParameters_IdMatch_ReturnsExpectedValues()
        {
            // Act
            var result = controller.ByParameters(city: null, minPrice: null, maxPrice: null, id: "1", name: null, sort: null).Result;

            // Assert
            Assert.AreEqual("1", (result.Value as IEnumerable<Estate>).First().Id);
        }

        [Fact]
        public void ByParameters_NameMatch_ReturnsExpectedValues()
        {
            // Arrange
            var expectedName = "test name";

            // Act
            var result =  controller.ByParameters(city: null, minPrice: null, maxPrice: null, id: null, name: expectedName, sort: null).Result;

            // Assert
            Assert.AreEqual(expectedName, ((IEnumerable<Estate>)result.Value).First().Estate_Name);
        }
// ADD CORS
    }
}
