using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using RealEstate.ApiGateway.Controllers;
using RealEstate.Shared.Models.Entities.Identity;
using Xunit;

namespace RealEstate.Test.Microservices.Controllers
{
    public class BaseControllerTest : BaseController
    {
        public BaseControllerTest(
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            //IUserService service,
            IMediator mediator,
            IMapper mapper)
            : base(roleManager, userManager, mediator, mapper)
        {
        }

        public RoleManager<IdentityRole> RoleManager => RoleManager;
        public UserManager<ApplicationUser> UserManager => UserManager;
        //public IUserService Service => Service;
        public new IMediator? Mediator => Mediator;
        public IMapper Mapper => Mapper;

        [Fact]
        public void TestBaseController_SetsFieldsCorrectly()
        {
            // Arrange
            var roleManager = Mock.Of<RoleManager<IdentityRole>>();
            var userManager = Mock.Of<UserManager<ApplicationUser>>();
            //var service = Mock.Of<IUserService>();
            var mediator = Mock.Of<IMediator>();
            var mapper = Mock.Of<IMapper>();

            var controller = new BaseController(roleManager, userManager, mediator, mapper);

            // Assert
            Assert.AreEqual(roleManager, controller.GetMediator());
            Assert.AreEqual(userManager, controller.GetUserManager());
            //Assert.AreEqual(service, controller.GetUserService());
            Assert.AreEqual(mediator, controller.GetMediator());
            Assert.AreEqual(mapper, controller.GetMapper());
        }


        [Fact]
        public void Constructor_SetsRoleManager()
        {
            // Act
            var controller = new BaseController(RoleManager, null, null, null);

            // Assert
            Assert.AreEqual(RoleManager, controller.GetRoleManager());
        }

        [Fact]
        public void Constructor_SetsUserManager()
        {
            // Arrange
            var userManager = new Mock<UserManager<ApplicationUser>>().Object;

            // Act
            var controller = new BaseController(null, userManager, null, null);

            // Assert
            Assert.AreEqual(userManager, controller.GetUserManager());
        }

        [Fact]
        public void Constructor_SetsService()
        {
            // Arrange
            //var service = new Mock<IUserService>().Object;

            // Act
            var controller = new BaseController(null, null, null, null);

            // Assert
            //Assert.AreEqual(service, controller.GetUserService());
        }

        [Fact]
        public void Constructor_SetsMediator()
        {
            // Arrange
            var mediator = new Mock<IMediator>().Object;

            // Act
            var controller = new BaseController(null, null, mediator, null);

            // Assert
            Assert.AreEqual(mediator, controller.GetMediator());
        }

        [Fact]
        public void Constructor_SetsMapper()
        {
            // Arrange
            var mapper = new Mock<IMapper>().Object;

            // Act
            var controller = new BaseController(null, null, null, mapper);

            // Assert
            Assert.AreEqual(mapper, controller.GetMapper());
        }

        [Fact]
        public void Mediator_GetsMediatorFromHttpContext()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var httpContextMock = new Mock<HttpContext>();
            httpContextMock
                .SetupGet(h => h.RequestServices)
                .Returns(new ServiceCollection().AddSingleton(mediatorMock.Object).BuildServiceProvider());
            var controller = new BaseController(null, null, null, null);
            controller.ControllerContext.HttpContext = httpContextMock.Object;

            // Act
            var result = controller.GetMediator();

            // Assert
            Assert.AreSame(mediatorMock.Object, result);
        }

    }
}
