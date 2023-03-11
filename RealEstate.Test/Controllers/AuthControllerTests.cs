using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using RealEstate.ApiGateway.Authentication.Contracts;
using RealEstate.ApiGateway.Controllers;
using RealEstate.Shared.Models.Entities.Identity;
using Xunit;

namespace RealEstate.Test.Controllers
{
    public class AuthControllerTests
    {
        private Mock<IAuth0Service> mockAuthService;
        private AuthController controller;

        public AuthControllerTests()
        {
            // Set up mock dependencies
            mockAuthService = new Mock<IAuth0Service>();

            // Set up the controller
            controller = new AuthController(
                _roleManager: null,
                _userManager: null,
                _service: null,
                _mediator: null,
                _mapper: null,
                _authService: mockAuthService.Object);
        }

        [Fact]
        public async void TestGetUserInfo()
        {
            // Set up the mock service
            mockAuthService
                .Setup(x => x.GetUserInfo(It.IsAny<string>()))
                .ReturnsAsync(new ApplicationUser());

            // Call the action method
            var result = await controller.GetUserInfo("access_token");

            // Verify the result
            Assert.IsAssignableFrom(typeof(OkObjectResult), result);
            Assert.IsAssignableFrom(typeof(ApplicationUser), ((OkObjectResult)result).Value);
        }

        [Fact]
        public async void TestGetAccessToken()
        {
            // Set up the mock service
            mockAuthService
                .Setup(x => x.GetAccessToken(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync("access_token");

            // Call the action method
            var result = await controller.GetAccessToken("code", "redirect_uri");

            // Verify the result
            Assert.IsAssignableFrom((Type)result, typeof(OkObjectResult));
            Assert.AreEqual(((OkObjectResult)result).Value, "access_token");
        }

        [Fact]
        public void TestGetAuthorizationUrl()
        {
            // Set up the mock service
            mockAuthService
                .Setup(x => x.GetAuthorizationUrl(It.IsAny<string>(), It.IsAny<string>()))
                .Returns("auth_url");

            // Call the action method
            var result = controller.GetAuthorizationUrl("redirect_uri", "state");

            // Verify the result
            Assert.IsAssignableFrom((Type)result, typeof(OkObjectResult));
            Assert.AreEqual(((OkObjectResult)result).Value, "auth_url");
        }

        [Fact]
        public void TestRevokeAccessToken()
        {
            // Set up the mock service
            mockAuthService
                .Setup(x => x.RevokeAccessToken(It.IsAny<string>()))
                .Returns(Task.FromResult(true));


            // Call the action method
            var result = controller.RevokeAccessToken("access_token");

            // Verify the result
            Assert.IsAssignableFrom(result.GetType(), typeof(OkObjectResult));
            Assert.True((bool)((OkObjectResult)result).Value);
        }

        [Fact]
        public void TestRenewAccessToken()
        {
            // Set up the mock service
            mockAuthService
                .Setup(x => x.RenewAccessToken(It.IsAny<string>()))
                .Returns(Task.FromResult("access_token"));


            // Call the action method
            var result = controller.RenewAccessToken("refresh_token");

            // Verify the result
            Assert.IsAssignableFrom(typeof(OkObjectResult), result);
            Assert.AreEqual("access_token", ((OkObjectResult)result).Value);
        }

    }
}
