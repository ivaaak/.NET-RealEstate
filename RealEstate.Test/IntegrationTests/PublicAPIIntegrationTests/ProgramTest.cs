using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace RealEstate.Test.IntegrationTests.PublicAPIIntegrationTests
{
    [TestClass]
    public class ProgramTest
    {
        private static WebApplicationFactory<Program> _application = new();

        public static HttpClient NewClient
        {
            get
            {
                return _application.CreateClient();
            }
        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext _)
        {
            _application = new WebApplicationFactory<Program>();

        }
    }
}
