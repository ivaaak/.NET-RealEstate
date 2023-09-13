using AutoMapper;
using EstatesMicroservice.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.Models.Entities.Estates;
using RealEstate.Shared.Models.QueryObjects;

namespace EstatesMicroservice.Tests
{
    [TestClass]
    public class EstateQueryServiceTests
    {
        private Mock<IRepository> repositoryMock;
        private Mock<IMapper> mapperMock;
        private EstateQueryService estateQueryService;

        [TestInitialize]
        public void Initialize()
        {
            repositoryMock = new Mock<IRepository>();
            mapperMock = new Mock<IMapper>();
            estateQueryService = new EstateQueryService(repositoryMock.Object, mapperMock.Object);
        }

        [TestMethod]
        public void ApplySorting_SortsBySpecifiedColumn()
        {
            // Arrange
            var criteria = new SearchCriteriaObject { SortByColumn = "SomeProperty" };
            var estates = new List<Estate>
            {
                new Estate { Estate_Name = "C" },
                new Estate { Estate_ImageUrl = "B" },
                new Estate { Estate_Description = "A" }
            }.AsQueryable();

            repositoryMock.Setup(r => r.All<Estate>()).Returns(estates);

            // Act
            var result = estateQueryService.FindByCriteriaAsync(criteria).Result;

            // Assert
            Assert.AreEqual(3, result.TotalItems); // Assuming there are 3 items in the unsorted list
            Assert.AreEqual("A", result.Items.First().Estate_Name); // First item should be "A" due to ascending sorting
            Assert.AreEqual("C", result.Items.Last().Estate_Description); // Last item should be "C" due to ascending sorting
        }

        [TestMethod]
        public void ApplyFiltering_FiltersBySpecifiedColumn()
        {
            // Arrange
            var criteria = new SearchCriteriaObject { FilterByColumn = "Estate_Name", SearchTerm = "search" };
            var estates = new List<Estate>
            {
                new Estate { Estate_Name = "searchTerm" },
                new Estate { Estate_Name = "otherTerm" },
                new Estate { Estate_Name = "anotherSearchTerm" }
            }.AsQueryable();
            repositoryMock.Setup(r => r.All<Estate>()).Returns(estates);

            // Act
            var result = estateQueryService.FindByCriteriaAsync(criteria).Result;

            // Assert
            Assert.AreEqual(2, result.TotalItems); // Assuming 2 items match the filter
            CollectionAssert.AreEqual(new[] { "searchTerm", "anotherSearchTerm" }, result.Items.Select(e => e.Estate_Name).ToList());
        }

        [TestMethod]
        public void ApplyPagination_ReturnsPagedResults()
        {
            // Arrange
            var criteria = new SearchCriteriaObject { PageNumber = 2, PageSize = 2 };
            var estates = new List<Estate>
            {
                new Estate { Estate_Name = "A" },
                new Estate { Estate_Name = "B" },
                new Estate { Estate_Name = "C" },
                new Estate { Estate_Name = "D" }
            }.AsQueryable();

            repositoryMock.Setup(r => r.All<Estate>()).Returns(estates);

            // Act
            var result = estateQueryService.FindByCriteriaAsync(criteria).Result;

            // Assert
            Assert.AreEqual(4, result.TotalItems); // Assuming there are 4 items in the list
            Assert.AreEqual(2, result.PageNumber); // Page number should be 2
            Assert.AreEqual(2, result.PageSize); // Page size should be 2
            Assert.AreEqual(2, result.Items.Count()); // Page should contain 2 items
            CollectionAssert.AreEqual(new[] { "C", "D" }, result.Items.Select(e => e.Estate_Name).ToList());
        }
    }
}
