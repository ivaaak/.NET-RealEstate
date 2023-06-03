using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RealEstate.Test.IntegrationTests.PublicAPIIntegrationTests
{
    [TestClass]
    public class ProgramTest
    {
        private static WebApplicationFactory<ProgramTest> _application = new();

        public static HttpClient NewClient
        {
            get
            {
                return _application.CreateClient();
            }
        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _)
        {
            _application = new WebApplicationFactory<ProgramTest>();

        }
    }
}
